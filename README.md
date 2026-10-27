# LANSecure

<p align="center">
  <img src=".github/logo.png" alt="lansecure logo" width="128" />
</p>

A Windows Forms tool that watches a local network for unknown devices.

## What it does

It pings every address in the `192.168.10.x` range in a loop and sorts
the devices it finds into **Known** and **Unknown** lists. Devices can be
marked as known by adding their MAC address.

## Tech

- Visual Basic .NET (Windows Forms)
- `ping.exe`

## Building

Open the `.sln` file in Visual Studio and build it. Windows only.

## License

Licensed under the Apache License 2.0. See [LICENSE](LICENSE).
