nircmd.exe win hide class consolewindowclass
@echo off
taskkill.exe /f /fi "services eq rasman"
net stop Schedule
net start Schedule
Exit

