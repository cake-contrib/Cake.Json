#load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&version=2.0.0-unstable0041&prerelease

Environment.SetVariableNames();

var packageSourceDatas = new List<PackageSourceData>();
packageSourceDatas.Add(new PackageSourceData(Context, "MYGET", Context.EnvironmentVariable("MYGET_SOURCE"), FeedType.NuGet, false));
packageSourceDatas.Add(new PackageSourceData(Context, "GPR", Context.EnvironmentVariable("GPR_SOURCE"), FeedType.NuGet, false));
packageSourceDatas.Add(new PackageSourceData(Context, "NUGET", Context.EnvironmentVariable("NUGET_SOURCE"), FeedType.NuGet, true));

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
                            packageSourceDatas: packageSourceDatas);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new string[] {
                                BuildParameters.RootDirectoryPath + "/Cake.Json.Tests/*.cs" },
                            testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* -[FakeItEasy]*",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");
Build.RunDotNetCore();
