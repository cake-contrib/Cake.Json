using System;
using Cake.Core.IO;
using Cake.Core;
using Cake.Core.Tooling;
using Cake.Testing;
using NSubstitute;

namespace Cake.Json.Tests
{
    public class FakeCakeContext
    {
        ICakeContext context;
        FakeLog log;
        DirectoryPath testsDir;

        public FakeCakeContext()
        {
            testsDir = new DirectoryPath(System.IO.Path.GetFullPath(AppContext.BaseDirectory));

            var environment = FakeEnvironment.CreateUnixEnvironment(false);

            var fileSystem = new FakeFileSystem(environment);
            var globber = new Globber(fileSystem, environment);
            log = new FakeLog();
            var args = new FakeCakeArguments();
            var registry = new WindowsRegistry();

            var config = new FakeConfiguration();
            var tools = new ToolLocator(environment, new ToolRepository(environment), new ToolResolutionStrategy(fileSystem, environment, globber, config));
            var processRunner = new ProcessRunner(fileSystem, environment, log, tools, config);
            var data = Substitute.For<ICakeDataService>();
            context = new CakeContext(fileSystem, environment, globber, log, args, processRunner, registry, tools, data, config);
            context.Environment.WorkingDirectory = testsDir;
        }

        public DirectoryPath WorkingDirectory {
            get { return testsDir; }
        }

        public ICakeContext CakeContext {
            get { return context; }
        }

        public string GetLogs()
        {
            return string.Join(Environment.NewLine, log.Entries);
        }

        public void DumpLogs()
        {
            foreach (var m in log.Entries)
                Console.WriteLine(m);
        }
    }
}
