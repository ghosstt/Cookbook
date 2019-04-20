REM clean certificate store
dotnet dev-certs https --clean

REM generate pfx, needs kestrel settings in appsettings.json
dotnet dev-certs https -ep "localhost.pfx" -p p@ss1234

REM generate pfx, no kestrel settings in appsettings.json needed
dotnet dev-certs https -ep "localhost.pfx" -p p@ss1234 --trust

REM generate crt and key file
REM C:\OpenSSL-Win64\bin\openssl.exe req -new -nodes -x509 -sha256 -newkey rsa:2048 -days 365 -keyout localhost.key -out localhost.crt -config certificate.cnf
