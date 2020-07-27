using System.Threading.Tasks;
using Microsoft.Build.Locator;
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
            var solution = await workspace.OpenSolutionAsync(args[0]);

            await SyntaxQueryDemo.ListAsync(solution);
            // await SyntaxVisitorDemo.ListAsync(solution);
            // await SymbolDemo.ListAsync(solution);
            // await DependenciesDemo.ListAllUsedTypes(solution);
            // await RewriterDemo.UpshiftAllStrings(workspace);
        }
    }
}