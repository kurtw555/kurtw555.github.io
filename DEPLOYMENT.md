# EPA Hydraulic Gradient Calculator - Deployment Guide

## Prerequisites
- .NET 9 SDK installed
- Git (for GitHub Pages deployment)

## Build for Production
```bash
dotnet publish -c Release
```

## Static File Deployment

### Option 1: GitHub Pages
1. Create a new repository on GitHub
2. Copy all files from `bin/Release/net9.0/publish/` to your repository
3. Go to repository Settings ? Pages
4. Select "Deploy from a branch" and choose main/master
5. Your app will be available at `https://yourusername.github.io/repositoryname`

### Option 2: Netlify
1. Visit netlify.com and sign up
2. Drag the `publish` folder to Netlify's deployment area
3. Your app will get a random URL (you can customize it)

### Option 3: Azure Static Web Apps
1. Install Azure CLI: `az login`
2. Create resource group: `az group create --name hydraulic-gradient-rg --location eastus`
3. Deploy: `az staticwebapp create --name hydraulic-gradient --resource-group hydraulic-gradient-rg --source .`

### Option 4: Local IIS (Windows)
1. Install IIS with Static Content feature
2. Copy publish folder to `C:\inetpub\wwwroot\hydraulic-gradient`
3. Create new website in IIS Manager
4. Access via `http://localhost/hydraulic-gradient`

## Files to Deploy
Deploy everything in the `bin/Release/net9.0/publish/` folder:
- index.html
- _framework/ (contains .NET runtime)
- css/
- lib/
- All other static assets

## Configuration Notes
- The app runs entirely in the browser (client-side)
- No server-side requirements
- Works offline after initial load
- HTTPS recommended but not required

## Customization Before Deployment
- Update `wwwroot/index.html` title if needed
- Modify `wwwroot/css/app.css` for custom branding
- Add your organization's logo/styling