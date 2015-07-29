foreach($command in (Get-Command))
{
	
	Get-Help $command.Name -Detailed | Select-Object name
	Get-Help $command.Name -Detailed | Select-Object synopsis
	$(Get-Help $command.Name -Detailed | Select-Object description).description
	$(Get-Help $command.Name -Detailed | Select-Object syntax ).syntax
	$(Get-Help $command.Name -Detailed | Select-Object parameters).parameters
	$(Get-Help $command.Name -Detailed | Select-Object inputTypes).inputTypes
	$(Get-Help $command.Name -Detailed | Select-Object returnValues).returnValues   
	$(Get-Help $command.Name -Detailed | Select-Object examples).examples
	$name =  $command.Name -replace "[^a-zA-Z0-9]", '' 
	$contents = Get-Help $command -Detailed
	$contents | Out-String | Out-File $("C:\PowerShell\"+$name+".txt")
}

