title RAS
:RASA
ping 127.0.0.1 -n 20
rasdial "VPN Connection" OntVPN Test2017!
route add 10.5.13.0 mask 255.255.255.0 172.25.0.1  -p
route add 192.168.4.0 mask 255.255.255.0 172.25.0.1  -p
net start iphlpsvc
:RPNG
set respp=good
ping -n 1 172.25.0.1|findstr /I /C:"timed out" /C:"host unreachable" /C:"could not find host"
if %errorlevel%==0 set respp=bad
IF "%respp%"=="bad" GOTO RASA
GOTO RPNG
