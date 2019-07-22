using System.Linq;
using Exercism.Analyzers.CSharp.Analyzers.Syntax;
using Exercism.Analyzers.CSharp.Analyzers.Syntax.Comparison;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Exercism.Analyzers.CSharp.Analyzers.ResistorColor.ResistorColorSyntaxFactory;

namespace Exercism.Analyzers.CSharp.Analyzers.ResistorColor
{
    internal class ResistorColorSolution : Solution
    {
        public ResistorColorSolution(Solution solution) : base(solution)
        {
        }

        private ClassDeclarationSyntax ResistorColorClass =>
            SyntaxRoot.GetClass("ResistorColor");

        private MethodDeclarationSyntax ColorCodeMethod =>
            ResistorColorClass?.GetMethod("ColorCode");
        
        private MethodDeclarationSyntax ColorsMethod =>
            ResistorColorClass?.GetMethod("Colors");

        private InitializerExpressionSyntax ColorsInitializer =>
            ResistorColorClass
                .DescendantNodes<InitializerExpressionSyntax>()
                .FirstOrDefault(initializerExpression =>
                    initializerExpression.IsEquivalentWhenNormalized(
                        initializerExpression.WithExpressions(ResistorColorColorsSeparatedSyntaxList())));

        private ExpressionSyntax ColorCodeMethodReturnedExpression =>
            ColorCodeMethod.ReturnedExpression();

        public string ColorCodeMethodName =>
            ColorCodeMethod.Identifier.Text;

        private ExpressionSyntax ColorsMethodReturnedExpression =>
            ColorsMethod.ReturnedExpression();

        public string ColorsMethodName =>
            ColorsMethod.Identifier.Text;

        public bool ColorCodeMethodUsesExpressionBody =>
            ColorCodeMethod.UsesExpressionBody();

        public bool ColorCodeMethodUsesSingleLine =>
            // TODO: rename to CanBeConvertedToExpressionBody
            ColorCodeMethod.UsesSingleLine();
        
        public bool ColorsMethodUsesExpressionBody =>
            ColorsMethod.UsesExpressionBody();

        public bool ColorsMethodUsesSingleLine =>
            ColorsMethod.UsesSingleLine();
//
//        public bool UsesPrivateField =>
//            UsesField && AddSecondsFieldArgument.IsPrivate();
//
//        public bool UsesField =>
//            AddSecondsArgumentType == ArgumentType.Field;

    }
}