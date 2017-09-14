#tool nuget:?package=NUnit.ConsoleRunner

var sln = "./Cake.Json.sln";
var nuspec = "./Cake.Json.nuspec";
var nugetVersion = Argument ("nuget_version", EnvironmentVariable ("NUGET_VERSION") ?? "1.0.0.0");
var target = Argument ("target", "build");
var configuration = Argument("configuration", EnvironmentVariable ("CONFIGURATION") ?? "Release");
var framework = Argument("framework", EnvironmentVariable ("FRAMEWORK") ?? "netcoreapp2.0");

Task ("build").Does (() =>
{
	NuGetRestore (sln);

	var settings = new DotNetCoreBuildSettings
    {
      Configuration = configuration
    };

	DotNetCoreBuild (sln, settings);
});

Task ("package").IsDependentOn("build").Does (() =>
{
	EnsureDirectoryExists ("./output/");

	var settings = new NuGetPackSettings {
		OutputDirectory = "./output/",		
        Properties = new Dictionary<string,string>(),
		Version = nugetVersion,
	};
	
	settings.Properties.Add("configuration", configuration);
	NuGetPack (nuspec, settings);
});

Task ("clean").Does (() =>
{
	CleanDirectories ("./**/bin");
	CleanDirectories ("./**/obj");
});

Task("test").IsDependentOn("package").Does(() =>
{
	var testsPath = "./Cake.Json.Tests";
	Information("Tests path: {0}", testsPath);
	DotNetCoreTest(testsPath);
});

Task ("Default")
	.IsDependentOn ("test");

RunTarget (target);
