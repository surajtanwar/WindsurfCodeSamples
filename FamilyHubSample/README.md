# FamilyHubSample (Tizen NUI, Tizen 7.0)

This is a basic Tizen NUI sample application for FamilyHub (Tizen 7.0).

## Prerequisites
- Windows OS
- [Tizen Studio](https://developer.tizen.org/development/tizen-studio/download) with .NET workload, or Visual Studio with Tizen extension
- Tizen 7.0 FamilyHub emulator or device

## Build & Package

### Using Visual Studio:
1. Open `FamilyHubSample.sln` in Visual Studio (with Tizen tools installed).
2. Right-click the project > **Build**.
3. Right-click the project > **Package** to generate `.tpk` in the `bin/Debug/tizen7.0/` directory.

### Using CLI (Tizen Studio):
1. Open a terminal and navigate to the project directory:
   ```
   cd FamilyHubSample
   ```
2. Build the project:
   ```
   tizen build-dotnet
   ```
3. Package the project:
   ```
   tizen package -t tpk -s <your-sign-profile>
   ```
   The `.tpk` file will be in `./bin/Debug/tizen7.0/`.

## Run
- Deploy the `.tpk` to your FamilyHub device or emulator using Tizen Studio or CLI:
  ```
  tizen install -n FamilyHubSample-1.0.0.tpk
  ```

## Notes
- The UI shows a simple welcome label centered on screen.
- You can extend `MainApp.cs` for more features.

---
For more details, see the [Tizen .NET NUI documentation](https://docs.tizen.org/application/dotnet/guides/nui/overview/).
