$vhd=Get-VMHardDiskDrive -VMName "PT-01" 
Set-VMFirmware -VMName "PT-01" -FirstBootDevice $vhd
