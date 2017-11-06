using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing;
using Path = System.IO.Path;

namespace Cake.Json.Tests
{
    public class FakeCakeContext
    {
        ICakeContext context;
        FakeLog log;
        DirectoryPath testsDir;


        public FakeCakeContext ()
        {
            testsDir = new DirectoryPath(Path.GetFullPath(AppContext.BaseDirectory));

            var environment = FakeEnvironment.CreateUnixEnvironment (false);

            var fileSystem = new FakeFileSystem (environment);
            var globber = new Globber (fileSystem, environment);
            log = new FakeLog ();
            var args = new FakeCakeArguments ();
            var processRunner = new ProcessRunner (environment, log);
            var registry = new WindowsRegistry ();

            var tools = new ToolLocator(environment, new ToolRepository(environment), new ToolResolutionStrategy(fileSystem, environment, globber, new FakeConfiguration()));
            context = new CakeContext (fileSystem, environment, globber, log, args, processRunner, registry, tools);
            context.Environment.WorkingDirectory = testsDir;
        }

        public DirectoryPath WorkingDirectory {
            get { return testsDir; }
        }

        public ICakeContext CakeContext {
            get { return context; }
        }

        public string GetLogs ()
        {
            return string.Join(Environment.NewLine, log.Entries);
        }

        public void DumpLogs ()
        {
            foreach (var m in log.Entries)
                Console.WriteLine (m);
        }
    }
}
