# BuildTasks.TextTemplating
A cross-platform msbuild/xbuild task and nuget package for transforming T4 templates.

## Usage

Install the BuildTasks.TextTemplating nuget package and add some T4 files to your project.
Set `TextTemplatingFileGenerator` as custom tool for the *.tt file. During the build the output file
will be generated. This works on both .NET and Mono as well as in Visual Studio and MonoDevelop.

## Requirements

This package depends on MSBuild 14.0 which is either included in VS 2015 avaialble here https://www.visualstudio.com/downloads/#visual-studio-community-2015-with-update-3-free or in Microsoft Build Tools 2015 (for build machines) available here https://www.visualstudio.com/downloads/#microsoft-build-tools-2015-update-3

## Availability

This project is built on Appveyor [![Build status](https://ci.appveyor.com/api/projects/status/qelvdjvl3e3a0ga3?svg=true)](https://ci.appveyor.com/project/tomap/buildtasks-texttemplating)
 and published on Nuget 

## License

This package is licensed under MIT License. See LICENSE file