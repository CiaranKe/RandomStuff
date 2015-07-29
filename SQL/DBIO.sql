--IO by database 
SELECT 
cast(DB_Name(a.database_id) as varchar) as Database_name,
b.physical_name, * 
FROM  
sys.dm_io_virtual_file_stats(null, null) a 
INNER JOIN sys.master_files b ON a.database_id = b.database_id and a.file_id = b.file_id
ORDER BY Database_Name

--Get a list of open sessions
SELECT login_name ,COUNT(session_id) AS session_count 
FROM sys.dm_exec_sessions 
GROUP BY login_name;


--Sessions with open transactions
SELECT s.* 
FROM sys.dm_exec_sessions AS s
WHERE EXISTS 
    (
    SELECT * 
    FROM sys.dm_tran_session_transactions AS t
    WHERE t.session_id = s.session_id
    )
    AND NOT EXISTS 
    (
    SELECT * 
    FROM sys.dm_exec_requests AS r
    WHERE r.session_id = s.session_id
    );

--Idle sessions with open transactions
SELECT s.* 
FROM sys.dm_exec_sessions AS s
WHERE EXISTS 
    (
    SELECT * 
    FROM sys.dm_tran_session_transactions AS t
    WHERE t.session_id = s.session_id
    )
    AND NOT EXISTS 
    (
    SELECT * 
    FROM sys.dm_exec_requests AS r
    WHERE r.session_id = s.session_id
    );



--Long running cursors
USE master;
GO
SELECT creation_time ,cursor_id 
    ,name ,c.session_id ,login_name 
FROM sys.dm_exec_cursors(0) AS c 
JOIN sys.dm_exec_sessions AS s 
   ON c.session_id = s.session_id 
WHERE DATEDIFF(mi, c.creation_time, GETDATE()) > 5;

--get list of connections
select * from sys.dm_exec_connections

--get index usage stats
select * from sys.dm_db_index_usage_stats

--get active transactions 
select * from sys.dm_tran_active_transactions

--get top 5 queries by CPU time
SELECT TOP 5 total_worker_time/execution_count AS [Avg CPU Time],
    SUBSTRING(st.text, (qs.statement_start_offset/2)+1, 
        ((CASE qs.statement_end_offset
          WHEN -1 THEN DATALENGTH(st.text)
         ELSE qs.statement_end_offset
         END - qs.statement_start_offset)/2) + 1) AS statement_text
FROM sys.dm_exec_query_stats AS qs
CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) AS st
ORDER BY total_worker_time/execution_count DESC;


--get wait times
select * from sys.dm_os_wait_stats


--get list of blocked requests
SELECT session_id ,status ,blocking_session_id
    ,wait_type ,wait_time ,wait_resource 
    ,transaction_id 
FROM sys.dm_exec_requests 
WHERE status = N'suspended';
GO

--match requests to locks
select * from  sys.dm_tran_locks
	join sys.dm_exec_requests
	on sys.dm_exec_requests.session_id = sys.dm_tran_locks.request_session_id
	

--get query that is blocking
select * from sys.dm_exec_requests
where blocking_session_id in
	(
		select blocking_session_id from sys.dm_exec_requests
			WHERE status = N'suspended';
	)
	
	--sys_objects
 
