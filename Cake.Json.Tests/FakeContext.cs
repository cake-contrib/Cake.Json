using System;
using Cake.Core.IO;
using Cake.Core;
using System.Collections.Generic;
using Cake.Testing;

namespace Cake.Json.Tests
{
    public class FakeCakeContext
    {
        ICakeContext context;
        FakeLog log;
        DirectoryPath testsDir;


        public FakeCakeContext ()
        {
            testsDir = new DirectoryPath (
                System.IO.Path.GetFullPath(
                    System.IO.Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "../../")));

            var environment = Cake.Testing.FakeEnvironment.CreateUnixEnvironment (false);

            var fileSystem = new Cake.Testing.FakeFileSystem (environment);
            var globber = new Globber (fileSystem, environment);
            log = new Cake.Testing.FakeLog ();
            var args = new FakeCakeArguments ();
            var processRunner = new ProcessRunner (environment, log);
            var registry = new WindowsRegistry ();

            context = new CakeContext (fileSystem, environment, globber, log, args, processRunner, registry);
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
