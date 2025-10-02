# Desktop Distribution Options

## Option 1: Electron.NET (Recommended)
Convert your Blazor WASM app to a desktop application:

1. Install Electron.NET templates:
```bash
dotnet new install ElectronNET.API.Template
```

2. Add to your project:
```bash
dotnet add package ElectronNET.API
```

3. Create desktop app:
```bash
electronize build /target win
```

## Option 2: WebView2 (Windows only)
Create a native Windows application that hosts your Blazor WASM app:

1. Create new WPF project
2. Add Microsoft.Web.WebView2 package
3. Point WebView2 to your published Blazor app

## Option 3: PWA (Progressive Web App)
Make your app installable from the browser:

1. Add manifest.json to wwwroot
2. Add service worker for offline support
3. Users can "install" from browser

## Option 4: Tauri (Cross-platform)
Modern alternative to Electron with Rust backend:

1. Install Tauri CLI
2. Configure tauri.conf.json
3. Build for Windows, Mac, Linux