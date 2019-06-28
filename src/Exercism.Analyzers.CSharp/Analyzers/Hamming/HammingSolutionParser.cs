using Exercism.Analyzers.CSharp.Analyzers.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            var distanceMethodReturnedExpression = distanceMethod.ReturnedExpression();
            
            return new HammingSolution(solution, distanceMethod, firstStrandParameter, secondStrandParameter, distanceMethodReturnedExpression);
        }
        
        private static ClassDeclarationSyntax HammingClass(this ParsedSolution solution) =>
            solution.SyntaxRoot.GetClass("Hamming");
        
        private static MethodDeclarationSyntax DistanceMethod(this ClassDeclarationSyntax hammingClass) =>
            hammingClass?.GetMethod("Distance");
    }
}