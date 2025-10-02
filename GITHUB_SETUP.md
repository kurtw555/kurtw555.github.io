# GitHub Pages Deployment Guide

## ?? Prerequisites
- GitHub account
- Git installed on your computer
- Your Blazor WebAssembly project (completed ?)

## ?? Step-by-Step Setup

### Step 1: Create GitHub Repository
1. Go to [GitHub.com](https://github.com) and sign in
2. Click the "+" icon ? "New repository"
3. Repository name: `HydraulicGradient` (or your preferred name)
4. Description: `EPA Hydraulic Gradient Calculator - Blazor WebAssembly App`
5. Make it **Public** (required for free GitHub Pages)
6. ? Check "Add a README file"
7. Click "Create repository"

### Step 2: Clone and Upload Your Code
```bash
# Clone your new repository
git clone https://github.com/YOURUSERNAME/HydraulicGradient.git
cd HydraulicGradient

# Copy your project files to the repository
# (Copy all files from your current project directory)

# Add all files to git
git add .
git commit -m "Initial commit - EPA Hydraulic Gradient Calculator"
git push origin main
```

### Step 3: Enable GitHub Pages
1. Go to your repository on GitHub
2. Click **Settings** tab
3. Scroll down to **Pages** section (left sidebar)
4. Under "Source", select **GitHub Actions**
5. The workflow will automatically run and deploy your app

### Step 4: Access Your Application
After the GitHub Action completes (2-3 minutes):
- Your app will be available at: `https://YOURUSERNAME.github.io/HydraulicGradient/`
- Replace `YOURUSERNAME` with your actual GitHub username

## ?? Automatic Updates
Every time you push changes to the main branch:
1. GitHub Actions automatically builds your app
2. Deploys the latest version to GitHub Pages
3. Your live site updates within minutes

## ??? Customization Options

### Change Repository Name
If you want a different URL:
1. Go to repository **Settings**
2. Scroll to **Repository name**
3. Change name (this will change your URL)

### Custom Domain (Optional)
To use your own domain:
1. In **Settings** ? **Pages**
2. Add your custom domain
3. Configure DNS with your domain provider

## ?? Troubleshooting

### Build Fails
- Check the **Actions** tab for error details
- Ensure all files are committed and pushed
- Verify .NET 9 compatibility

### 404 Error
- Wait 5-10 minutes after first deployment
- Check that GitHub Pages is enabled
- Verify the URL format: `https://USERNAME.github.io/REPOSITORY-NAME/`

### App Loads but Blank
- Check browser console for errors
- Verify base href is correctly set by the workflow
- Clear browser cache and try again

## ?? Sharing Your App

Once deployed, you can share your calculator with:
- **Environmental consultants**
- **Students and educators**
- **Hydrogeologists**
- **EPA staff and researchers**

Your app provides the same functionality as the original EPA tool but with:
- ? Modern, responsive interface
- ? Faster performance
- ? Better mobile support
- ? Always available (no EPA server dependencies)

## ?? Next Steps

1. **Share the URL** with colleagues and students
2. **Add more features** (data export, visualization, etc.)
3. **Create documentation** for specific use cases
4. **Get feedback** from users
5. **Contribute improvements** back to the community

---

**Your app will be live at**: `https://YOURUSERNAME.github.io/HydraulicGradient/`

Replace `YOURUSERNAME` with your GitHub username!