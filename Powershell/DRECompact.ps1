#Compact the IDOL indexes and create a Event in the Windows log
#
# Set-ExecutionPolicy remotesigned -scope currentUser in order to run script
#

#Create an event log 
$EventLog=new-object System.Diagnostics.EventLog("Application")
$EventLog.Source="DRECompacting"
$infoEvent=[System.Diagnostics.EventLogEntryType]::Information

#Compact the indexes
$result = (New-Object System.Net.WebClient).DownloadString("http://localhost:9001/DRECOMPACT")
#log the output
$EventLog.WriteEntry("IDOL DRECompact Started: " + $result,$infoevent,1337)

#clean up
Remove-Variable EventLog
Remove-Variable infoEvent
Remove-Variable result