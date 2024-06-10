nircmd.exe win hide class consolewindowclass
:RASA
ping 127.0.0.1 -n 20
rasdial "VPN Connection" Ontvpn Test2017!
route add 192.168.4.0 mask 255.255.255.0 172.25.0.1  -p
route add 10.5.13.0 mask 255.255.255.0 172.25.0.1  -p

net start iphlpsvc

netsh interface portproxy add v4tov4 listenport=8888 connectaddress=10.0.42.10 connectport=8888 protocol=tcp
netsh interface portproxy add v4tov4 listenport=8443 connectaddress=10.0.42.10 connectport=8443 protocol=tcp
netsh interface portproxy add v4tov4 listenport=7750 connectaddress=10.0.42.10 connectport=7750 protocol=tcp
netsh interface portproxy add v4tov4 listenport=1521 connectaddress=10.0.42.10 connectport=1521 protocol=tcp

:RPNG
set respp=good
ping -n 1 172.25.0.1|findstr /I /C:"timed out" /C:"host unreachable" /C:"could not find host"
if %errorlevel%==0 set respp=bad
IF "%respp%"=="bad" GOTO RASA
GOTO RPNG
