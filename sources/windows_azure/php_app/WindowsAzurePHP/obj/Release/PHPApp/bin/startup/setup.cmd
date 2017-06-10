cd "%~dp0"
md appdata
reg add "hku\.default\software\microsoft\windows\currentversion\explorer\user shell folders" /v "Local AppData" /t REG_EXPAND_SZ /d "%~dp0appdata" /f 
WebPICmdLine.exe /accepteula /Products:PHP53
WebPICmdLine.exe /accepteula /Products:SQLDriverPHP53IIS
WebPICmdLine.exe /accepteula /Products:WinCache53
reg add "hku\.default\software\microsoft\windows\currentversion\explorer\user shell folders" /v "Local AppData" /t REG_EXPAND_SZ /d %%USERPROFILE%%\AppData\Local /f 
net start w3svc
iisreset /start
exit /b 0