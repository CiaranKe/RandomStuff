select 
          tblTrace.id
	, tblSession.host_name
	, tblSession.program_name
	, tblSession.login_name
	, tblTrace.status
	, tblTrace.path
	, tblTrace.start_time
	, tblTrace.stop_time
	, tblTrace.max_size
	, tblTrace.max_files
	, tblTrace.is_rollover
	, tblTrace.is_shutdown
	, tblTrace.is_default
	, tblTrace.reader_spid
from   sys.traces tblTrace
	  left outer join sys.dm_exec_sessions tblSession
	     on tblTrace.reader_spid = tblSession.session_id