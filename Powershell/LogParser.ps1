# LogParser.ps1
# Date: 22/01/2013
###################################################################
# $cert = @(Get-ChildItem cert:\LocalMachine\Root -codesigning)[0]
#  Set-AuthenticodeSignature .\LogParser.ps1 $cert
###################################################################

###################################################################
# Paramiters to script are not optional
###################################################################
Param(
    [parameter(Mandatory=$true)]
    [alias("d")]
	[String] 
    $inputDir,
    [parameter(Mandatory=$true)]
    [alias("o")]
	[String] 
    $outputfile)

###################################################################
# Delete the old version of the output file
###################################################################
if(Test-Path $outputfile)
{
	del $outputfile;
}

$fileList = ls $inputDir;
$("Date, Time, CaseRef, NumDocs, Deleted") | Out-File $outputfile -Append;	

###################################################################
# Process each file in the folder
###################################################################
foreach($file in $fileList)
{
	###################################################################
	# Don't process today's file
	###################################################################
	if ($file.Name -ne "parsed")
	{
		$content =  cat $file.fullname;
		foreach ($s in $content)
		{
		
			if ($s -match 'Removing documents from case')
			{
				$string = [String]$s;
				$tempString  = $string.substring($string.lastIndexOf("<")+1);
				$case = $tempString.substring(0, ($tempString.length -2));
				$date = $string.substring(0, 10) + ", ";
				$time = $string.substring(11,8) + ", ";
				$NumDocs = 0;
			}
			elseif($s -match 'Removing document DMSDocumentPK')
			{
				if ($s -match [String]$case)
				{
					$NumDocs++;
				}
			}
			elseif($s -match 'Removing case from system')
			{
				$string = [String]$s;
				$date = $string.substring(0, 10) + ", " ;
				$time = $string.substring(11,8) + ", ";
				$date + $time + $case + ", " + $NumDocs + ", Yes" | Out-File $outputfile -Append;	
				$case = '';
				$NumDocs = 0;
			}
			elseif($s -match ' EXCEPTION ')
			{	
				$date + $time + $case + ", " + $NumDocs  +  ", NO - FAILED" | Out-File $outputfile -Append;	
				$case = '';
				$NumDocs = 0;
			}
		}
		###################################################################
		# Move files after processing so they don't get processed twice
		###################################################################
		if (!$(Test-Path $($inputDir + "\parsed")))
		{
			mkdir $($inputDir + "\parsed");
		}
		if ($file.Name -ne "retentionDisposal.log")
		{
			mv $file.FullName $($inputDir + "\parsed");
		}
	}
	
}

###################################################################
# Get the login details for the mail server
###################################################################
#if (Test-Path $credFile)
#{
#	$AdminName = "";
#	$password = get-content $CredFile | convertto-securestring;
#	$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $AdminName,$password;
#	
#}
#else
#{
#	$AdminName = Read-Host "Enter the username used to send mail.";
#	Read-Host -AsSecureString | ConvertFrom-SecureString | Out-File $CredFile;
#	$password = get-content $CredFile | convertto-securestring;
#	$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $AdminName,$password;
#}

###################################################################
# Send the mail with today's date.
###################################################################
#$date = $(Get-Date).ToShortDateString();
#Send-MailMessage -To $to -From $from -Body "If there are any issues or questions please contact support." -Subject $("Retention and disposal case list for " + $date) -Attachments $outputfile -SmtpServer mail.kainos.com -Credential $cred; 

# SIG # Begin signature block
# MIIELQYJKoZIhvcNAQcCoIIEHjCCBBoCAQExCzAJBgUrDgMCGgUAMGkGCisGAQQB
# gjcCAQSgWzBZMDQGCisGAQQBgjcCAR4wJgIDAQAABBAfzDtgWUsITrck0sYpfvNR
# AgEAAgEAAgEAAgEAAgEAMCEwCQYFKw4DAhoFAAQUTy8uUAp9SnER7uv/8Qe6MB9i
# 9jqgggI9MIICOTCCAaagAwIBAgIQkoKPLk7AzbJLNlyj871btDAJBgUrDgMCHQUA
# MCYxJDAiBgNVBAMTG0thaW5vcyBTb2Z0d2FyZSBmb3IgdGhlIElDTzAeFw0xMzAx
# MjMxMjI5MjVaFw0zOTEyMzEyMzU5NTlaMCYxJDAiBgNVBAMTG0thaW5vcyBTb2Z0
# d2FyZSBmb3IgdGhlIElDTzCBnzANBgkqhkiG9w0BAQEFAAOBjQAwgYkCgYEAs2Jg
# 3ApdGh8rMd34gW8rskZPQJishY9w8jm7CtZcGjqGqrh886QqJ/bXR8k2baEcQVOA
# 8EY/2yH5v7DW571JKrmNukvRnzAJiC2TTkZ7Ef8LioMvglLpvIo/LrdwnOYXV6X+
# dbQTdJPlE/yWEN4lmI7auooFzcXE/Q0S1IYmzB8CAwEAAaNwMG4wEwYDVR0lBAww
# CgYIKwYBBQUHAwMwVwYDVR0BBFAwToAQU6C+XsFGVN9Q2xvjxzxy/qEoMCYxJDAi
# BgNVBAMTG0thaW5vcyBTb2Z0d2FyZSBmb3IgdGhlIElDT4IQdhZiLCPVGIFIkL35
# h4I6pDAJBgUrDgMCHQUAA4GBAE/n/yJ4K/Wr3SGcFenXT1hdaRTSaZXrfdR6JGCm
# PblubET9gN5tmk5uDFC0JsjgL/622O8Xg1jK5FFjbg0UWZsZM/qGCMGQWA7fhi0x
# SAcXrqfxzV8YRy6ByH8Sz6RXom7eWULka2nuVA9Ao4XnpMcR2JoBfUbZGP/A8ShX
# 4RjGMYIBWjCCAVYCAQEwOjAmMSQwIgYDVQQDExtLYWlub3MgU29mdHdhcmUgZm9y
# IHRoZSBJQ08CEJKCjy5OwM2ySzZco/O9W7QwCQYFKw4DAhoFAKB4MBgGCisGAQQB
# gjcCAQwxCjAIoAKAAKECgAAwGQYJKoZIhvcNAQkDMQwGCisGAQQBgjcCAQQwHAYK
# KwYBBAGCNwIBCzEOMAwGCisGAQQBgjcCARUwIwYJKoZIhvcNAQkEMRYEFN6LIjkB
# wiXWuTzWirp1/yK573SsMA0GCSqGSIb3DQEBAQUABIGArd2VllDoWsnLdcuqFCvd
# GQpn5mceHDpUL8mxOsCaQzI6QmCejjhlQaerEHCgnbIpTRijKDiVYI56j88Fhra9
# C0FmFcuYJdwAe8lQs9G3RkM+1jUo7BJ3ruX8VMtvOqgsYOUftrkXL6/PyWsx77kT
# o7dDRbtpv3rCruEemKn40/I=
# SIG # End signature block
