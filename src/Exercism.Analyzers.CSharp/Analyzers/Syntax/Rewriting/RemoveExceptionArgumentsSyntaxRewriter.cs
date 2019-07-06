using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Exercism.Analyzers.CSharp.Analyzers.Syntax.Rewriting
{
    internal class RemoveExceptionArgumentsSyntaxRewriter : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            if (node.Type is IdentifierNameSyntax identifierName &&
                identifierName.Identifier.Text.EndsWith("Exception"))
                return base.VisitObjectCreationExpression(node.WithArgumentList(ArgumentList()));
            
            return base.VisitObjectCreationExpression(node);
        }
    }
}