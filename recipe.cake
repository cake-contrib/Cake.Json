#load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&version=2.0.0-unstable0056&prerelease

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.Json",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.Json",
                            appVeyorAccountName: "cakecontrib",
                            shouldRunDotNetCorePack: true,
                            shouldRunDupFinder: false,
                            shouldRunInspectCode: false,
                            shouldRunGitVersion: true,
                            shouldRunCodecov: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new string[] {
                                BuildParameters.RootDirectoryPath + "/Cake.Json.Tests/*.cs" },
                            testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* -[FakeItEasy]*",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");
Build.RunDotNetCore();
