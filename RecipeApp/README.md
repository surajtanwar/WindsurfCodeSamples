# RecipeApp (Tizen NUI)

This is a sample Recipe Application for Tizen Mobile, built using Tizen NUI and the Tizen.NET.Sdl/1.1.9 SDK.

## Features
- Splash screen with app logo and title
- Main page placeholder

## Requirements
- Tizen SDK 8.0+
- .NET 7.0
- Visual Studio with Tizen tools or Tizen CLI

## How to Build & Run
1. Restore NuGet packages:
   ```
   dotnet restore
   ```
2. Build the project:
   ```
   dotnet build
   ```
3. Run on Tizen emulator/device:
   ```
   dotnet run
   ```

## Notes
- The splash screen uses `splash.jpg` from the project directory.
- Edit `Program.cs` to customize splash or main page.
