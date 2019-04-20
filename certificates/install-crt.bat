certutil -addstore -user -f “My” localhost.crt
certmgr /add localhost.crt /s /r localMachine root /all
@REM certmgr /add localhost.crt /s /r localMachine trustedpublisher
@pause