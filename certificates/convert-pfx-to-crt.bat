REM convert pfx to crt and key file
REM extract the key
C:\OpenSSL-Win64\bin\openssl.exe pkcs12 -in localhost.pfx -nocerts -out localhost.key -password pass:p@ss1234 -passin pass:p@ss1234 -passout pass:p@ss1234

REM extract the crt
C:\OpenSSL-Win64\bin\openssl.exe pkcs12 -in localhost.pfx -clcerts -nokeys -out localhost.crt -password pass:p@ss1234

REM sometimes you need to have an unencrypted .key file to import on some devices
REM C:\OpenSSL-Win64\bin\openssl.exe rsa -in localhost.key -out localhost_unencrypted.key -passin pass:p@ss1234 -passout pass:p@ss1234

REM convert crt and key file to pfx
REM C:\OpenSSL-Win64\bin\openssl.exe pkcs12 -export -out localhost.pfx -inkey localhost.key -in localhost.crt -password pass:p@ss1234