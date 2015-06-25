# BuildTasks.TextTemplating
A cross-platform msbuild/xbuild task and nuget package for transforming T4 templates.

## Usage

Install the BuildTasks.TextTemplating nuget package and add some T4 files to your project.
Set `TextTemplatingFileGenerator` as custom tool for the *.tt file. During the build the output file
will be generated. This works on both .NET and Mono as well as in Visual Studio and MonoDevelop.
