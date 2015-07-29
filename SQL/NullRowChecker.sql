declare @Table varchar(max)
declare @Row varchar(max)
declare @select varchar(max)
declare @condition varchar(max)
declare @query varchar(max)
declare @counter int
create table #KainosResultTable (TABLE_NAME varchar(max), ROW_COUNT int)
declare tableCursor cursor for select TABLE_NAME from information_schema.tables
open tableCursor
	fetch next from tableCursor into @Table
	while @@FETCH_STATUS = 0
	BEGIN
		set @select = 'SELECT count(*) ' + ' FROM ' + @table + ' with(nolock) where '
		set @condition = ''
		declare rowCursor cursor for select COLUMN_NAME from information_schema.columns where TABLE_NAME = @Table
		open rowCursor
			fetch next from rowCursor into @Row	 
			while @@FETCH_STATUS = 0
			BEGIN 	 
				set @condition = @condition + '[' + @row + ']' + ' is null '
				fetch next from rowCursor into @Row
				if @@FETCH_STATUS = 0
					set @condition = @condition + ' and '	
			END
			close rowCursor
			deallocate rowCursor
			set @query = @select  + @condition
			select @query
			begin try 
				create table #KainosCounterTable (counter int)
				insert into #KainosCounterTable exec(@query)
				select counter from #KainosCounterTable
				select @counter = counter from #KainosCounterTable
				drop table #KainosCounterTable	
				insert into #KainosResultTable(TABLE_NAME, ROW_COUNT) (select @Table, @counter)
			end try 
			begin catch 
				drop table #KainosCounterTable
				select @query
				select ERROR_MESSAGE()
			end catch
		fetch next from tableCursor into @Table
	END
close tableCursor
deallocate tableCursor

select * from #KainosResultTable order by ROW_COUNT desc
--drop table #KainosResultTable
