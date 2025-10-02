@echo off
echo Building EPA Hydraulic Gradient Calculator for production...
cd HydraulicGradient
dotnet publish -c Release

echo.
echo Build complete! Files are ready for deployment in:
echo %CD%\bin\Release\net9.0\publish\
echo.
echo Next steps:
echo 1. Upload the contents of the publish folder to your web server
echo 2. Ensure your web server serves static files
echo 3. Access your application via the web server URL
echo.
pause