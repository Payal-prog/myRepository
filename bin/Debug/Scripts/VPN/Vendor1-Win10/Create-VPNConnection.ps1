# Disconnect all VPN connections
$vpnConnections = Get-VpnConnection | Select-Object -Property Name
foreach ($vpnConnection in $vpnConnections) {
    rasdial $vpnConnection.Name /disconnect
}

# Delete all existing VPN connections
Get-VpnConnection | ForEach-Object { Remove-VpnConnection -Name $_.Name -Force }

# Remove all tasks from the Task Scheduler
Get-ScheduledTask | ForEach-Object { Unregister-ScheduledTask -TaskName $_.TaskName -Confirm:$false }

# Create the VPN directory if it doesn't already exist
if (!(Test-Path "C:\Pong\VPN")) {
    New-Item -ItemType Directory -Path "C:\Pong\VPN" | Out-Null
}

# Move the necessary files to the VPN directory
#cd "Scripts\VPN\Vendor1-Win10\"
$files = @("Scripts\VPN\Vendor1-Win10\nircmd.exe", "Scripts\VPN\Vendor1-Win10\ras.bat", "Scripts\VPN\Vendor1-Win10\ras2.bat", "Scripts\VPN\Vendor1-Win10\rset.bat", "Scripts\VPN\Vendor1-Win10\rset.xml", "Scripts\VPN\Vendor1-Win10\VPNSTART1.xml", "Scripts\VPN\Vendor1-Win10\Create-VPNConnection.ps1")
foreach ($file in $files) {
    if (Test-Path $file) {
        Copy-Item -Path $file -Destination "C:\Pong\VPN" -Force
    } else {
        Write-Output "File $file not found."
    }
}

# Create the VPN connection using PowerShell
Add-VpnConnection -Name "VPN Connection" -ServerAddress "vpn.playfromhome.ca"
Set-VpnConnection -Name "VPN Connection" -TunnelType SSTP -EncryptionLevel Required -AuthenticationMethod CHAP,MSCHAPv2 -SplitTunneling $true -PassThru

# Create the tasks in the Task Scheduler
$tasks = @{
    "VPNSTART1" = "C:\Pong\VPN\VPNSTART1.xml"
    "rset" = "C:\Pong\VPN\rset.xml"
}
foreach ($task in $tasks.Keys) {
    if (Test-Path $tasks[$task]) {
        schtasks /create /xml $tasks[$task] /tn $task
    } else {
        Write-Output "XML file for task $task not found."
    }
}

# Start the VPNSTART1 task
schtasks /run /tn "VPNSTART1"