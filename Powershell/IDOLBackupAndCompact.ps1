################################################################
# Backup and compact indexes for a standalone IDOL server
################################################################
# Set-ExecutionPolicy remotesigned -scope currentUser in order to run script
################################################################

#################################################
# Config 										#
#################################################
$IDOLhost = "localhost";  						#IDOL Host
$IndexPort = "9001";      						#DIH Port 
$ActionPort = "9000";	  						#DAH Port
$IndexBackupDir = "C:/kainos/IDOLBackup";		#Backup dir
$PreviousBackUpDir = "C:/kainos/PreviousBackups";
$timeToWait = 120;								#Wait time between checks
#################################################

######################################
#Create a reference to the event log
######################################
$EventLog=new-object System.Diagnostics.EventLog("Application");
$EventLog.Source="IDOL index compact";
$infoEvent=[System.Diagnostics.EventLogEntryType]::Information;
$failureEvent=[System.Diagnostics.EventLogEntryType]::Error;
#######################################
# 
#######################################



#######################################
# Backup the indexes and log an event.
#######################################
$IndexResult = (New-Object System.Net.WebClient).DownloadString("http://"+$IDOLhost+":"+$IndexPort+"/DREBACKUP?"+$IndexBackupDir).subString(8,4);
$EventLog.WriteEntry("Index backup started, Job ID: " + $IndexResult,$infoevent,1);
#######################################
# Wait for the backup to finish
#######################################
$backupResponse = [xml](New-Object System.Net.WebClient).DownloadString("http://"+$IDOLhost+":"+$actionPort+"/action=IndexerGetStatus&Index="+$IndexResult);
while (($backupResponse.selectSingleNode("//item/description")."#text" -ne "Finished"))
{	
	#Wait
	sleep -Seconds $timeToWait;
	$backupResponse = [xml](New-Object System.Net.WebClient).DownloadString("http://"+$IDOLhost+":"+$actionPort+"/action=IndexerGetStatus&Index="+$IndexResult);	
	"WAITING ON JOB: " + $IndexResult
	"Current Status: " + $backupResponse.selectSingleNode("//item/description")."#text" 
}
########################################
# Only proceeed if the backup worked
########################################
if ($backupResponse.selectSingleNode("//item/status")."#text"  -ne "-1")
{
	#log a failure and exit
	$EventLog.WriteEntry("Backup failed for job ID: " + $IndexResult + " The index has not been compacted.",$failureEvent,1);
	"Backup failed on job: " + $IndexResult + ", With error:  " + $backupResponse.selectSingleNode("//item/description")."#text" 
}
#####################################
# Compact the Index
#####################################
else
{
	$IndexResult = (New-Object System.Net.WebClient).DownloadString("http://"+$IDOLhost+":"+$IndexPort+"/DRECOMPACT?Backup=false").subString(8,4);
	"Backup Successful.  Compacting index. Job ID: " + $IndexResult;
	$EventLog.WriteEntry("Compacting index Job ID: " + $IndexResult,$infoevent,2);
	$CompactResponse =  [xml](New-Object System.Net.WebClient).DownloadString("http://"+$IDOLhost+":"+$actionPort+"/action=IndexerGetStatus&Index="+$IndexResult)	
	while ($CompactResponse.selectSingleNode("//item/description")."#text"  -ne "Finished")
	{	
		sleep -Seconds $timeToWait;
		$CompactResponse = [xml](New-Object System.Net.WebClient).DownloadString("http://"+$IDOLhost+":"+$actionPort+"/action=IndexerGetStatus&Index="+$IndexResult);	
		"WAITING ON JOB: " + $IndexResult
		"Current Status: " + $CompactResponse.selectSingleNode("//item/description")."#text" 
	}
	##################################
	# Compact failed, restore backup
	##################################
	if ($CompactResponse.selectSingleNode("//item/status")."#text" -ne "-1")
	{
		#log a failure and exit
		$EventLog.WriteEntry("Compacting failed for Job ID: " + $IndexResult + ".  Restoring Backup",$failureEvent,2);
		"Compacting Failed. Restoring Backup."
		$IndexResult = (New-Object System.Net.WebClient).DownloadString("http://"+$IDOLhost+":"+$IndexPort"/DREINITIAL?IndexBackupDir"+).subString(8,4);
		$RestoreResponse = [xml](New-Object System.Net.WebClient).DownloadString("http://"+$IDOLhost+":"+$actionPort+"/action=IndexerGetStatus&Index="+$IndexResult);
		
	}
	else
	{
		$EventLog.WriteEntry("Compacting Completed for Job ID: " + $IndexResult,$infoevent,2);
		"Compacting completed."
	}
}
#####################################
# clean up
#####################################
Remove-Variable IDOLhost;
Remove-Variable IndexPort;
Remove-Variable ActionPort;
Remove-Variable IndexBackupDir;
Remove-Variable IndexResult;
Remove-Variable backupResponse;
Remove-Variable compactResponse;
Remove-Variable RestoreResponse;
Remove-Variable EventLog;
Remove-Variable infoEvent;