## GPA Calculator

A .NET 8 console app that calculates GPA from class grades and credits.

### Run from source

```bash
dotnet run --project MyApp/MyApp.csproj
```

### Download a release

Open the repository's **Releases** page and download the archive for your operating system. Extract it, then run `MyApp` on Linux or `MyApp.exe` on Windows.

### Publish a release

Push the source and workflow once, then create a version tag:

```bash
git add MyApp README.md .github/workflows/release.yml .gitignore
git commit -m "Add automated releases"
git push origin main
git tag v1.0.0
git push origin v1.0.0
```

GitHub Actions will build self-contained Linux and Windows downloads and attach them to the new GitHub Release.
