/*
sp_configure 'Show Advanced Options', 1
go
Reconfigure
go
sp_configure 'Blocked Process Threshold (s)'

sp_configure 'Blocked Process Threshold (s)', 1 
go
reconfigure

sp_configure 'Show Advanced Options', 1
go
Reconfigure
go
sp_configure 'Blocked Process Threshold (s)', 1 -- change value to minimum duration of blocking to capture
go
reconfigure
*/
-- Create a Queue
declare @rc int
declare @TraceID int
declare @maxfilesize bigint
declare @TraceFile nvarchar(245)
declare @StopTime datetime

set @maxfilesize = 50 
set @TraceFile = N'C:\traces\traceblockingtest2' --insert filename here excluding file extension
set @StopTime = '2013-07-26 23:59:59.000' --set date and time when trace should stop automatically

-- Please replace the text InsertFileNameHere, with an appropriate
-- filename prefixed by a path, e.g., c:\MyFolder\MyTrace. The .trc extension
-- will be appended to the filename automatically. If you are writing from
-- remote server to local drive, please use UNC path and make sure server has
-- write access to your network share 


exec @rc = sp_trace_create @TraceID output, 0, @TraceFile, @maxfilesize, @StopTime 
if (@rc != 0) goto error

-- Client side File and Table cannot be scripted

-- Set the events
declare @on bit
set @on = 1
exec sp_trace_setevent @TraceID, 137, 3, @on
exec sp_trace_setevent @TraceID, 137, 15, @on
exec sp_trace_setevent @TraceID, 137, 51, @on
exec sp_trace_setevent @TraceID, 137, 4, @on
exec sp_trace_setevent @TraceID, 137, 12, @on
exec sp_trace_setevent @TraceID, 137, 24, @on
exec sp_trace_setevent @TraceID, 137, 32, @on
exec sp_trace_setevent @TraceID, 137, 60, @on
exec sp_trace_setevent @TraceID, 137, 64, @on
exec sp_trace_setevent @TraceID, 137, 1, @on
exec sp_trace_setevent @TraceID, 137, 13, @on
exec sp_trace_setevent @TraceID, 137, 41, @on
exec sp_trace_setevent @TraceID, 137, 14, @on
exec sp_trace_setevent @TraceID, 137, 22, @on
exec sp_trace_setevent @TraceID, 137, 26, @on


EXEC sp_trace_setevent @TraceID,148,1,@on --Deadlock graph: TextData
EXEC sp_trace_setevent @TraceID,148,4,@on --Deadlock graph: TransactionID
EXEC sp_trace_setevent @TraceID,148,11,@on --Deadlock graph: LoginName
EXEC sp_trace_setevent @TraceID,148,12,@on --Deadlock graph: SPID
EXEC sp_trace_setevent @TraceID,148,14,@on --Deadlock graph: StartTime
EXEC sp_trace_setevent @TraceID,148,26,@on --Deadlock graph: ServerName
EXEC sp_trace_setevent @TraceID,148,41,@on --Deadlock graph: LoginSid
EXEC sp_trace_setevent @TraceID,148,51,@on --Deadlock graph: EventSequence
EXEC sp_trace_setevent @TraceID,148,60,@on --Deadlock graph: IsSystem
EXEC sp_trace_setevent @TraceID,148,64,@on --Deadlock graph: SessionLoginName


-- Set the Filters
declare @intfilter int
declare @bigintfilter bigint

-- Set the trace status to start
exec sp_trace_setstatus @TraceID, 1

-- display trace id for future references
select TraceID=@TraceID
goto finish

error: 
select ErrorCode=@rc

finish: 
go
