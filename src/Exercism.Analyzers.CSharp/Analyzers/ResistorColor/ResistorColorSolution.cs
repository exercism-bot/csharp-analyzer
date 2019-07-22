using System;
using Exercism.Analyzers.CSharp.Analyzers.Shared;
using Exercism.Analyzers.CSharp.Analyzers.Syntax;
using Exercism.Analyzers.CSharp.Analyzers.Syntax.Comparison;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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

//        private FieldDeclarationSyntax AddSecondsFieldArgument =>
//            AddSecondsArgumentVariable.FieldDeclaration();
        
        private ExpressionSyntax ColorCodeMethodReturnedExpression =>
            ColorCodeMethod.ReturnedExpression();

        public string ColorCodeMethodName =>
            ColorCodeMethod.Identifier.Text;

//        public string ColorCodeMethodParameterName =>
//            ColorCodeMethodParameter.Identifier.Text;

        private ExpressionSyntax ColorsMethodReturnedExpression =>
            ColorsMethod.ReturnedExpression();

        public string ColorsMethodName =>
            ColorsMethod.Identifier.Text;
        
        
        

        

  

//        public bool UsesExpressionBody =>
//            ColorCodeMethod.UsesExpressionBody();
//
//        public bool UsesSingleLine =>
//            ColorCodeMethod.UsesSingleLine();
//
//        public bool UsesConstField =>
//            UsesField && AddSecondsFieldArgument.IsConst();
//
//        public bool UsesPrivateField =>
//            UsesField && AddSecondsFieldArgument.IsPrivate();
//
//        public bool UsesField =>
//            AddSecondsArgumentType == ArgumentType.Field;
//
//        public bool DoesNotUseAddSeconds =>
//            AddSecondsInvocationExpression == null;
//
//        public bool CreatesNewDatetime =>
//            ColorCodeMethod.CreatesObjectOfType<DateTime>();
//
//        public bool UsesLocalConstVariable =>
//            UsesLocalVariable &&
//            AddSecondsLocalArgument.IsConst;
//
//        public bool UsesLocalVariable =>
//            AddSecondsArgumentType == ArgumentType.Local;
//
//        public bool AssignsToParameterAndReturns =>
//            AddMethodReturnType == ReturnType.ParameterAssigment;
//
//        public bool AssignsToVariableAndReturns =>
//            AddMethodReturnType == ReturnType.VariableAssignment;
    }
}