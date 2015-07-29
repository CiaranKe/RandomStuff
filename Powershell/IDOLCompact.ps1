#Compact the IDOL indexes and create a Event in the Windows log
#
# Set-ExecutionPolicy remotesigned in order to run script
#
$EventLog=new-object System.Diagnostics.EventLog("Application")
$EventLog.Source="DRECompacting"
$infoEvent=[System.Diagnostics.EventLogEntryType]::Information
$result = (New-Object System.Net.WebClient).DownloadString("http://localhost:9001/DRECOMPACT")
$EventLog.WriteEntry("IDOL DRECompact Started: " + $result,$infoevent,1337)