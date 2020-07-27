using System;
using System.Threading.Tasks;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace RoslynDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            MSBuildLocator.RegisterDefaults();

            var workspace = MSBuildWorkspace.Create();
            workspace.LoadMetadataForReferencedProjects = true;
            
            workspace.WorkspaceFailed += OnWorkspaceFailed;

            var solution = await workspace.OpenSolutionAsync(args[0]);

            await SyntaxQueryDemo.ListAsync(solution);
            // await SyntaxVisitorDemo.ListAsync(solution);
            // await SymbolDemo.ListAsync(solution);
            // await DependenciesDemo.ListAllUsedTypes(solution);
            // await RewriterDemo.UpshiftAllStrings(workspace);
        }

        private static void OnWorkspaceFailed(object? sender, WorkspaceDiagnosticEventArgs e)
        {
            // Console.WriteLine(e.Diagnostic.Message);
        }
    }
}