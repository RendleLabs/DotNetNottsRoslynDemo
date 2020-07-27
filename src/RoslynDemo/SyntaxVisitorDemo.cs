using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace RoslynDemo
{
    class SyntaxVisitorDemo
    {
        public static async Task ListAsync(Solution solution)
        {
            var walker = new ListTypesWalker();

            foreach (var document in solution.Projects.SelectMany(p => p.Documents))
            {
                var root = await document.GetSyntaxRootAsync();
                if (root is null) continue;
                walker.Visit(root);
            }
        }
    }
}