using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Exercism.Analyzers.CSharp.Analyzers.Shared.SharedSyntaxFactory;

namespace Exercism.Analyzers.CSharp.Analyzers.ResistorColor
{
    internal static class ResistorColorSyntaxFactory
    {
        public static SeparatedSyntaxList<ExpressionSyntax> ResistorColorColorsSeparatedSyntaxList() =>
            SeparatedSyntaxList<ExpressionSyntax>(
                StringLiteralExpression("black"),
                StringLiteralExpression("brown"),
                StringLiteralExpression("red"),
                StringLiteralExpression("orange"),
                StringLiteralExpression("yellow"),
                StringLiteralExpression("green"),
                StringLiteralExpression("blue"),
                StringLiteralExpression("violet"),
                StringLiteralExpression("grey"),
                StringLiteralExpression("white")
            );
    }
}