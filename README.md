# md2pdf

md2pdf is a simple cross-platform command-line application written in .NET that converts Markdown (.md) files to PDF using QuestPDF, QuestPDF.Markdown and Markdig.

## Features

- Convert Markdown (.md) to PDF via command-line
- Drag-and-drop a `.md` file onto the executable (Windows) to convert
- Supports framework-dependent and self-contained deployments

## Prerequisites

- .NET SDK 9.0 or later (download from https://dotnet.microsoft.com/download)
- Visual Studio Code (https://code.visualstudio.com/)

## Getting Started with VS Code

1. Open the project in VS Code:
   ```powershell
   cd <location of md2pdf project>
   code .
   ```
2. Restore dependencies and build:
   - Press `Ctrl+Shift+B` (Windows) or `⇧⌘B` (macOS) to run the default build task.

## Publish Options

You can publish the application in two modes:

1. Framework-dependent (smaller output, requires .NET runtime on target machine)
2. Self-contained (larger output, no .NET runtime required)

### Windows (win-x64)

Framework-dependent:

```powershell
dotnet publish -c Release -r win-x64 --self-contained false -o publish\win-x64\framework-dependent
```

Self-contained (single file):

```powershell
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o publish\win-x64\self-contained
```

**Output**:

- Framework-dependent: `publish\win-x64\framework-dependent\md2pdf.exe` plus DLLs
- Self-contained: `publish\win-x64\self-contained\md2pdf.exe` (single executable)

### macOS (osx-x64)

Framework-dependent:

```bash
dotnet publish -c Release -r osx-x64 --self-contained false -o publish/osx-x64/framework-dependent
```

Self-contained (single file):

```bash
dotnet publish -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true -o publish/osx-x64/self-contained
```

**Output**:

- Framework-dependent: `publish/osx-x64/framework-dependent/md2pdf` plus DLLs
- Self-contained: `publish/osx-x64/self-contained/md2pdf` (single executable)

## Usage

```powershell
# Convert a Markdown file to PDF
md2pdf path\to\file.md
```

- The PDF will be generated in the same directory with the same base name (`file.pdf`).

### Drag-and-Drop (Windows)

Drag a `.md` file onto `md2pdf.exe` in File Explorer; a PDF with the same name will be created alongside the source.

## Deployment

- **Framework-dependent**: Copy the entire `framework-dependent` output folder to the target machine. Ensure the .NET runtime (9.0+) is installed.
- **Self-contained**: Copy the single executable from the `self-contained` output folder to the target machine. No .NET runtime required.

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.

## Third-Party Notices

This project uses the following third-party libraries:

- Markdig ([BSD 2-Clause "Simplified" License](https://github.com/xoofx/markdig/blob/master/license.txt))
- QuestPDF ([MIT/Paid Licenses](https://github.com/QuestPDF/QuestPDF/blob/main/LICENSE.md))
- QuestPDF.Markdown ([MIT License](https://github.com/christiaanderidder/QuestPDF.Markdown/blob/main/LICENSE))
