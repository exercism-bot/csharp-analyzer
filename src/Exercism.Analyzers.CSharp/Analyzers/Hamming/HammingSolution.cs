using Exercism.Analyzers.CSharp.Analyzers.Syntax;
using Exercism.Analyzers.CSharp.Analyzers.Syntax.Comparison;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Exercism.Analyzers.CSharp.Analyzers.Hamming
{
    internal class HammingSolution : ParsedSolution
    {
        private readonly MethodDeclarationSyntax _distanceMethod;
        private readonly ParameterSyntax _firstStrandParameter;
        private readonly ParameterSyntax _secondStrandParameter;
        private readonly StatementSyntax _firstStatement;
        private readonly StatementSyntax _secondStatement;
        private readonly ThrowStatementSyntax _thrownException;
        private readonly IfStatementSyntax _lengthComparisonIfStatement;
        private readonly HammingLengthComparison _lengthComparison;

        public HammingSolution(ParsedSolution solution,
            MethodDeclarationSyntax distanceMethod,
            ParameterSyntax firstStrandParameter,
            ParameterSyntax secondStrandParameter,
            StatementSyntax firstStatement,
            StatementSyntax secondStatement,
            ThrowStatementSyntax thrownException,
            IfStatementSyntax lengthComparisonIfStatement,
            HammingLengthComparison lengthComparison) : base(solution.Solution, solution.SyntaxRoot)
        {
            _distanceMethod = distanceMethod;
            _firstStrandParameter = firstStrandParameter;
            _secondStrandParameter = secondStrandParameter;
            _firstStatement = firstStatement;
            _secondStatement = secondStatement;
            _thrownException = thrownException;
            _lengthComparisonIfStatement = lengthComparisonIfStatement;
            _lengthComparison = lengthComparison;
        }

        public int NumberOfStatements =>
            _distanceMethod.IsExpressionBody() ? 1 : _distanceMethod.Body.Statements.Count;

        public bool StartsWithIfStatement =>
            _lengthComparisonIfStatement != null &&
            _firstStatement.IsEquivalentWhenNormalized(_lengthComparisonIfStatement);

        public bool IfStatementThrowsArgumentException =>
            _lengthComparisonIfStatement != null &&
            _lengthComparisonIfStatement.Statement.IsEquivalentWhenNormalized(
                Block(_thrownException));

        public bool ComparesLengthsUsingNotEqual =>
            _lengthComparison == HammingLengthComparison.NotEqual;
        
        public bool EndsWithLinqWhereSolution =>
            _secondStatement.IsEquivalentWhenNormalized(
                ReturnStatement(
                            InvocationExpression(
                                MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    InvocationExpression(
                                        MemberAccessExpression(
                                            SyntaxKind.SimpleMemberAccessExpression,
                                            IdentifierName("firstStrand"),
                                            IdentifierName("Where")))
                                    .WithArgumentList(
                                        ArgumentList(
                                            SingletonSeparatedList<ArgumentSyntax>(
                                                Argument(
                                                    ParenthesizedLambdaExpression(
                                                        BinaryExpression(
                                                            SyntaxKind.NotEqualsExpression,
                                                            IdentifierName("x"),
                                                            ElementAccessExpression(
                                                                IdentifierName("secondStrand"))
                                                            .WithArgumentList(
                                                                BracketedArgumentList(
                                                                    SingletonSeparatedList<ArgumentSyntax>(
                                                                        Argument(
                                                                            IdentifierName("i")))))))
                                                    .WithParameterList(
                                                        ParameterList(
                                                            SeparatedList<ParameterSyntax>(
                                                                new SyntaxNodeOrToken[]{
                                                                    Parameter(
                                                                        Identifier("x")),
                                                                    Token(SyntaxKind.CommaToken),
                                                                    Parameter(
                                                                        Identifier("i"))}))))))),
                                    IdentifierName("Count")))));
    }
}