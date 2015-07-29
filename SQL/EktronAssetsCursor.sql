DECLARE @CiaranTemp table
(		
	ID int,
	ReferenceNo VARCHAR(MAX),
	Description VARCHAR(MAX),
	Reference VARCHAR(MAX),
	ActionType VARCHAR(MAX),
	Category VARCHAR(MAX),
	Owner VARCHAR(MAX),
	DueDate VARCHAR(MAX), 
	CompletionDate VARCHAR(MAX),
	CompletionComment VARCHAR(MAX),
	location VARCHAR(MAX)
)

declare @XML XML
declare @contentID bigint
declare @locationID nvarchar(2000)
declare @location VARCHAR(MAX)
declare @Parent nvarchar(2000)


declare html_cursor cursor for 
 select content_id, CAST (content_html AS XML) from dbo.content where content_html like '%<completiondate></completiondate>%' 
open html_cursor 
FETCH NEXT FROM html_cursor into @contentID, @XML
WHILE @@FETCH_STATUS = 0
BEGIN 
	select @Parent = meta_value from dbo.content_meta_tbl where content_id = @contentID and meta_type_id = 173
	select @locationID = meta_value from dbo.content_meta_tbl where content_id = @Parent and meta_type_id = 168
	select @location = content_title from dbo.content where content_id = @locationID

	INSERT INTO @CiaranTemp(id, ReferenceNo, Description, Reference, ActionType, Category, Owner, DueDate, CompletionDate, CompletionComment, location)
	SELECT	@contentID,
		Data.Col.value('ReferenceNo[1]', 'VARCHAR(MAX)') as ReferenceNo,
		Data.Col.value('Description[1]', 'VARCHAR(MAX)') as Description,
		Data.Col.value('Reference[1]', 'VARCHAR(MAX)') as Reference,
		Data.Col.value('ActionType[1]', 'VARCHAR(MAX)') as ActionType,
		Data.Col.value('Category[1]', 'VARCHAR(MAX)') as Category,
		Data.Col.value('Owner[1]', 'VARCHAR(MAX)') as Owner,
		Data.Col.value('DueDate[1]', 'VARCHAR(MAX)') as DueDate,
		Data.Col.value('CompletionDate[1]', 'VARCHAR(MAX)') as CompletionDate,
		Data.Col.value('CompletionComment[1]', 'VARCHAR(MAX)') as CompletionComment,
		@location
	FROM @XML.nodes('/root/DisplayActions/IndividualActionDetails') As Data(Col)

	FETCH NEXT FROM html_cursor into @contentID, @XML
END 
CLOSE html_cursor
DEALLOCATE html_cursor
select * from @CiaranTemp where location like '%Fiddlers Ferry%' and CompletionDate = ''
