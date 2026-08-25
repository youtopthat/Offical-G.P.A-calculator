## GPA Calculator

A .NET 8 console app that calculates GPA from class grades and credits.

### Run from source

```bash
dotnet run --project MyApp/MyApp.csproj
```

### Enter grades

For each class, enter either a letter grade (`A`, `B`, `C`, `D`, or `F`) or a
percentage from `0` to `100`. Numerical grades are converted to the 4.0 scale:

| Numerical grade | GPA points |
| --- | ---: |
| 90-100 | 4.0 |
| 80-89.99 | 3.0 |
| 70-79.99 | 2.0 |
| 60-69.99 | 1.0 |
| 0-59.99 | 0.0 |

Credits must be a number greater than zero. The final GPA is weighted by the
number of credits for each class.

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

### Browser version

The browser calculator is deployed automatically to GitHub Pages at:

https://youtopthat.github.io/vigilant-octo-guide/
