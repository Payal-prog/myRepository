New-VMSwitch -SwitchName "V2-VM-NAT" -SwitchType Internal
New-NetIPAddress -IPAddress 10.0.42.1 -PrefixLength 24 -InterfaceIndex (Get-NetIPInterface | ? {$_.ifAlias -like '*V2-VM-NAT*' -and $_.AddressFamily -eq 'IPv4'}).ifIndex
New-NetNat -Name V2-VM-NAT-Network -InternalIPInterfaceAddressPrefix 10.0.42.0/24

netsh interface portproxy add v4tov4 listenport=8888 connectaddress=10.0.42.10 connectport=8888 protocol=tcp
netsh advfirewall firewall add rule name="JBoss http" protocol=TCP dir=in localport=8888 action=allow
netsh interface portproxy add v4tov4 listenport=8443 connectaddress=10.0.42.10 connectport=8443 protocol=tcp
netsh advfirewall firewall add rule name="JBoss https" protocol=TCP dir=in localport=8443 action=allow
netsh interface portproxy add v4tov4 listenport=7750 connectaddress=10.0.42.10 connectport=7750 protocol=tcp
netsh advfirewall firewall add rule name="Socket Server Port" protocol=TCP dir=in localport=7750 action=allow
netsh interface portproxy add v4tov4 listenport=1521 connectaddress=10.0.42.10 connectport=1521 protocol=tcp
netsh advfirewall firewall add rule name="Oracle" protocol=TCP dir=in localport=1521 action=allow




 