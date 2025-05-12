@echo off
REM Build, package, and install Tizen .tpk to emulator automatically
REM Set your certificate profile name below
set PROFILE_NAME=tizen_cert

REM Build the project
call dotnet build -c Release

REM Package the app as .tpk 
call tizen package -t tpk -s %PROFILE_NAME%

REM Find the generated .tpk file (assuming only one .tpk in bin/tpk)
for %%f in (bin\tpk\*.tpk) do set TPK_FILE=%%f

REM Install the .tpk on the default emulator (change to your emulator name if needed)
call tizen install -n %TPK_FILE% --target emulator-26101

REM Launch the application (appid must match tizen-manifest.xml)
call tizen run -p org.example.tizennuiloginapp --target emulator-26101

echo Deployment complete. If you see errors, check your emulator/device name and certificate profile.
pause
