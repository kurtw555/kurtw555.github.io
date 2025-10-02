#!/bin/bash

echo "?? GitHub Deployment Helper for EPA Hydraulic Gradient Calculator"
echo "================================================================="
echo ""

# Check if we're in a git repository
if [ ! -d ".git" ]; then
    echo "? This directory is not a Git repository."
    echo "Please run this script from your project root directory."
    exit 1
fi

# Check if we have uncommitted changes
if [ -n "$(git status --porcelain)" ]; then
    echo "?? You have uncommitted changes. Let's commit them first."
    echo ""
    git status
    echo ""
    read -p "Commit message: " commit_msg
    git add .
    git commit -m "$commit_msg"
fi

# Push to GitHub
echo "?? Pushing to GitHub..."
git push origin main

echo ""
echo "? Deployment initiated!"
echo ""
echo "Your app will be available at:"
echo "https://$(git config --get remote.origin.url | sed 's/.*github.com[:/]\([^/]*\)\/\([^.]*\).*/\1.github.io\/\2/')/"
echo ""
echo "??  It may take 2-3 minutes for the deployment to complete."
echo "Check the Actions tab in your GitHub repository for deployment status."