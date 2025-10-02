@echo off
echo ?? GitHub Deployment Helper for EPA Hydraulic Gradient Calculator
echo =================================================================
echo.

REM Check if we're in a git repository
if not exist ".git" (
    echo ? This directory is not a Git repository.
    echo Please run this script from your project root directory.
    pause
    exit /b 1
)

REM Check for uncommitted changes
git status --porcelain > temp_status.txt
for /f %%i in ("temp_status.txt") do set size=%%~zi
del temp_status.txt

if %size% gtr 0 (
    echo ?? You have uncommitted changes. Let's commit them first.
    echo.
    git status
    echo.
    set /p commit_msg="Commit message: "
    git add .
    git commit -m "%commit_msg%"
)

REM Push to GitHub
echo ?? Pushing to GitHub...
git push origin main

echo.
echo ? Deployment initiated!
echo.
echo Your app will be available at:
echo https://YOURUSERNAME.github.io/REPOSITORYNAME/
echo.
echo ??  It may take 2-3 minutes for the deployment to complete.
echo Check the Actions tab in your GitHub repository for deployment status.
echo.
pause