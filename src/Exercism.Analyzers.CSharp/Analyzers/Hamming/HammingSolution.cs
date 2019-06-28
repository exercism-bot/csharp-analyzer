using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Exercism.Analyzers.CSharp.Analyzers.Hamming
{
    internal class HammingSolution : ParsedSolution
    {
        private readonly MethodDeclarationSyntax _distanceMethod;
        private readonly ParameterSyntax _firstStrandParameter;
        private readonly ParameterSyntax _secondStrandParameter;
        private readonly ExpressionSyntax _distanceMethodReturnedExpression;

        public HammingSolution(ParsedSolution solution, MethodDeclarationSyntax distanceMethod, ParameterSyntax firstStrandParameter, ParameterSyntax secondStrandParameter, ExpressionSyntax distanceMethodReturnedExpression) : base(solution.Solution, solution.SyntaxRoot)
        {
            _distanceMethod = distanceMethod;
            _firstStrandParameter = firstStrandParameter;
            _secondStrandParameter = secondStrandParameter;
            _distanceMethodReturnedExpression = distanceMethodReturnedExpression;
        }
    }
}