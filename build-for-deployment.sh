#!/bin/bash

echo "Building EPA Hydraulic Gradient Calculator for production..."
cd HydraulicGradient
dotnet publish -c Release

echo ""
echo "Build complete! Files are ready for deployment in:"
echo "$(pwd)/bin/Release/net9.0/publish/"
echo ""
echo "Next steps:"
echo "1. Upload the contents of the publish folder to your web server"
echo "2. Ensure your web server serves static files"
echo "3. Access your application via the web server URL"
echo ""

# Optional: Create a zip file for easy upload
if command -v zip &> /dev/null; then
    echo "Creating deployment zip file..."
    cd bin/Release/net9.0/publish
    zip -r ../../../../hydraulic-gradient-deploy.zip .
    cd ../../../../
    echo "Deployment zip created: hydraulic-gradient-deploy.zip"
fi