# Cake.Json
A set of aliases for http://cakebuild.net to help with JSON Serialization and manipulation.

![AppVeyor](https://ci.appveyor.com/api/projects/status/github/redth/Cake.Json)

You can easily reference Cake.Json directly in your build script via a cake addin:

```csharp
#addin nuget:?package=Cake.Json
#addin nuget:?package=Newtonsoft.Json&version=12.0.2
```

NOTE: It's very important at this point in time to specify the Newtonsoft.Json package *and* the version _12.0.2_ for it.

## Aliases

Please visit the Cake Documentation for a list of available aliases:

[http://cakebuild.net/dsl/json](http://cakebuild.net/dsl/json)

## Discussion

For questions and to discuss ideas & feature requests, use the [GitHub discussions on the Cake GitHub repository](https://github.com/cake-build/cake/discussions), under the [Extension Q&A](https://github.com/cake-build/cake/discussions/categories/extension-q-a) category.

[![Join in the discussion on the Cake repository](https://img.shields.io/badge/GitHub-Discussions-green?logo=github)](https://github.com/cake-build/cake/discussions)


## Apache License 2.0
Apache Cake.Json Copyright 2015. The Apache Software Foundation This product includes software developed at The Apache Software Foundation (http://www.apache.org/).
