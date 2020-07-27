using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynDemo
{
    public class ListTypesWalker : CSharpSyntaxWalker
    {
        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            Write(node);
            base.VisitClassDeclaration(node);
        }

        public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            Write(node);
            base.VisitInterfaceDeclaration(node);
        }
        
        private static void Write(BaseTypeDeclarationSyntax node)
        {
            var namespaceDeclarationSyntax = node.FirstAncestorOrSelf<NamespaceDeclarationSyntax>();
            var typeName = node.Identifier.Text;
            var namespaceName = namespaceDeclarationSyntax?.Name.ToString();
            Console.WriteLine($"{namespaceName}.{typeName}");
        }
    }
}