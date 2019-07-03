using System;
using System.Linq;
using Exercism.Analyzers.CSharp.Analyzers.Syntax;
using Exercism.Analyzers.CSharp.Analyzers.Syntax.Comparison;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Exercism.Analyzers.CSharp.Analyzers.Shared.SharedSyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Exercism.Analyzers.CSharp.Analyzers.Hamming
{
    internal static class HammingSolutionParser
    {
        public static HammingSolution Parse(ParsedSolution solution)
        {
            var hammingClass = solution.HammingClass();
            var distanceMethod = hammingClass.DistanceMethod();
            var firstStrandParameter = distanceMethod.FirstParameter();
            var secondStrandParameter = distanceMethod.SecondParameter();
            var firstStatement = distanceMethod.Body?.Statements.ElementAt(0);
            var secondStatement = distanceMethod.Body?.Statements.ElementAt(1);
            var thrownException = distanceMethod.GetThrowStatement<ArgumentException>();
            var lengthComparisonIfStatement = distanceMethod.LengthComparisonIfStatement(firstStrandParameter, secondStrandParameter);
            var lengthComparison = lengthComparisonIfStatement.LengthComparison();
            
            return new HammingSolution(solution, distanceMethod, firstStrandParameter, secondStrandParameter, firstStatement, secondStatement, thrownException, lengthComparisonIfStatement, lengthComparison);
        }
        
        private static ClassDeclarationSyntax HammingClass(this ParsedSolution solution) =>
            solution.SyntaxRoot.GetClassDeclaration("Hamming");
        
        private static MethodDeclarationSyntax DistanceMethod(this ClassDeclarationSyntax hammingClass) =>
            hammingClass?.GetMethodDeclaration("Distance");
        
        private static IfStatementSyntax LengthComparisonIfStatement(this MethodDeclarationSyntax distanceMethod,
            ParameterSyntax firstStrandParameter, ParameterSyntax secondStrandParameter)
        {
            var firstStrandLength = SimpleMemberAccessExpression(IdentifierName(firstStrandParameter), IdentifierName("Length"));
            var secondStrandLength = SimpleMemberAccessExpression(IdentifierName(secondStrandParameter), IdentifierName("Length"));

            return distanceMethod.DescendantNodes<IfStatementSyntax>()
                .FirstOrDefault(ifStatement =>
                    ifStatement.Condition is BinaryExpressionSyntax binaryExpression &&
                    (binaryExpression.Left.IsEquivalentWhenNormalized(firstStrandLength) &&
                     binaryExpression.Right.IsEquivalentWhenNormalized(secondStrandLength) ||
                     binaryExpression.Left.IsEquivalentWhenNormalized(secondStrandLength) &&
                     binaryExpression.Right.IsEquivalentWhenNormalized(firstStrandLength)));
        }
        
        private static HammingLengthComparison LengthComparison(this IfStatementSyntax lengthComparisonIfStatement)
        {
            switch (lengthComparisonIfStatement?.Condition.Kind())
            {
                case SyntaxKind.NotEqualsExpression:
                    return HammingLengthComparison.NotEqual;
                case SyntaxKind.EqualsExpression:
                    return HammingLengthComparison.Equal;
                default:
                    return HammingLengthComparison.Unknown;
            }
        }
    }
}