using Exercism.Analyzers.CSharp.Analyzers.Gigasecond;
using Exercism.Analyzers.CSharp.Analyzers.Shared;

namespace Exercism.Analyzers.CSharp.Analyzers.ResistorColor
{
    internal static class ResistorColorAnalyzer
    {
        public static SolutionAnalysis Analyze(ResistorColorSolution solution) =>
            solution.DisapproveWhenInvalid() ??
            solution.ApproveWhenValid() ??
            solution.ReferToMentor();

        private static SolutionAnalysis DisapproveWhenInvalid(this ResistorColorSolution solution) =>
            solution.ContinueAnalysis();

        private static SolutionAnalysis ApproveWhenValid(this ResistorColorSolution solution)
        {
//            if (solution.UsesMathPow)
//                solution.AddComment(GigasecondComments.UseScientificNotationNotMathPow(solution.GigasecondValue));
//
//            if (solution.UsesDigitsWithoutSeparator)
//                solution.AddComment(GigasecondComments.UseScientificNotationOrDigitSeparators(solution.GigasecondValue));
//
//            if (solution.AssignsToParameterAndReturns ||
//                solution.AssignsToVariableAndReturns)
//                solution.AddComment(SharedComments.DoNotAssignAndReturn);
//
//            if (solution.UsesLocalVariable &&
//                !solution.UsesLocalConstVariable)
//                solution.AddComment(SharedComments.ConvertVariableToConst(solution.GigasecondValueVariableName));
//
//            if (solution.UsesField &&
//                !solution.UsesConstField)
//                solution.AddComment(SharedComments.ConvertFieldToConst(solution.GigasecondValueFieldName));
//
//            if (solution.UsesField &&
//                !solution.UsesPrivateField)
//                solution.AddComment(SharedComments.UsePrivateVisibility(solution.GigasecondValueFieldName));
//
//            if (solution.UsesSingleLine &&
//                !solution.UsesExpressionBody)
//                solution.AddComment(SharedComments.UseExpressionBodiedMember(solution.ColorCodeMethodName));
//
//            if (solution.UsesScientificNotation ||
//                solution.UsesDigitsWithSeparator ||
//                solution.HasComments)
//                return solution.Approve();

            return solution.ContinueAnalysis();
        }
    }
}