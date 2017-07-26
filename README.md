# CK-ControlChannel abstractions

High-level interfaces for CK.ControlChannel.Server and CK.ControlChannel.Client.

## Build requirements

- Windows
- Powershell
- [.NET Core SDK 1.0.4](https://www.microsoft.com/net/download/core) (with .NET Core 1.1)
- [Visual Studio 2017](https://www.visualstudio.com/) (any edition) with .NET framework build tools

## Build instructions

1. Clone the repository
2. In Powershell, run `CodeCakeBuilder/Bootstrap.ps1`
3. Run `CodeCakeBuilder/bin/Release/CodeCakeBuilder.exe`

## NuGet packages

| Feed | Version |
| --- | --- |
| Stable | [![NuGet Badge](https://buildstats.info/nuget/CK.ControlChannel.Abstractions)](https://www.nuget.org/packages/CK.ControlChannel.Abstractions) |
| Unstable | [![NuGet Badge](https://buildstats.info/nuget/CK.ControlChannel.Abstractions?includePreReleases=true)](https://www.nuget.org/packages/CK.ControlChannel.Abstractions) |
| CI | [![MyGet Badge](https://buildstats.info/myget/invenietis-preview/CK.ControlChannel.Abstractions)](https://www.myget.org/feed/invenietis-preview/package/nuget/CK.ControlChannel.Abstractions) |

## Build status

| Branch   | Visual Studio 2017 |
| -------- | ------- |
| *(latest)* | [![Latest build](https://img.shields.io/appveyor/ci/olivier-spinelli/ck-controlchannel-abstractions.svg)](https://ci.appveyor.com/project/olivier-spinelli/ck-controlchannel-abstractions) |
| `master`   | [![Latest master build](https://img.shields.io/appveyor/ci/olivier-spinelli/ck-controlchannel-abstractions/master.svg)](https://ci.appveyor.com/project/olivier-spinelli/ck-controlchannel-abstractions) |
| `develop`  | [![Latest develop build](https://img.shields.io/appveyor/ci/olivier-spinelli/ck-controlchannel-abstractions/develop.svg)](https://ci.appveyor.com/project/olivier-spinelli/ck-controlchannel-abstractions) |

## Contributing

Anyone and everyone is welcome to contribute. Please take a moment to
review the [guidelines for contributing](CONTRIBUTING.md).

## License

Assets in this repository are licensed with the MIT License. For more information, please see [LICENSE.md](LICENSE.md).

## Open-source licenses

This repository and its components use the following open-source projects:

- [Invenietis/CK-Core](https://github.com/Invenietis/CK-Core), licensed under the [GNU Lesser General Public License v3.0](https://github.com/Invenietis/CK-Core/blob/master/LICENSE)
- [Invenietis/CK-Text](https://github.com/Invenietis/CK-Text), licensed under the [MIT License](https://github.com/Invenietis/CK-Text/blob/master/LICENSE)
- [Invenietis/CK-ActivityMonitor](https://github.com/Invenietis/CK-ActivityMonitor), licensed under the [GNU Lesser General Public License v3.0](https://github.com/Invenietis/CK-ActivityMonitor/blob/master/LICENSE)
