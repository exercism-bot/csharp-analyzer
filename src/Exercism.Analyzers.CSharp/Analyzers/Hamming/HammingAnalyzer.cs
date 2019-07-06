using static Exercism.Analyzers.CSharp.Analyzers.Shared.SharedComments;

namespace Exercism.Analyzers.CSharp.Analyzers.Hamming
{
    internal static class HammingAnalyzer
    {
        public static SolutionAnalysis Analyze(ParsedSolution parsedSolution) =>
            Analyze(HammingSolutionParser.Parse(parsedSolution));

        private static SolutionAnalysis Analyze(HammingSolution hammingSolution) =>
            hammingSolution.DisapproveWhenInvalid() ??
            hammingSolution.ApproveWhenValid() ??
            hammingSolution.ReferToMentor();

        private static SolutionAnalysis DisapproveWhenInvalid(this HammingSolution hammingSolution)
        {
            if (hammingSolution.InvalidExceptionThrown ||
                hammingSolution.StartsWithIfStatement)
                hammingSolution.AddComment(DoesNotPassAllTests);

            if (hammingSolution.IfStatementThrowsArgumentException)
            {
                if (!hammingSolution.ComparesLengthsUsingNotEqual)
                    hammingSolution.AddComment(DoesNotPassAllTests);
            }
            else
            {
                if (!hammingSolution.ComparesLengthsUsingEqual)
                    hammingSolution.AddComment(DoesNotPassAllTests);
            }

            return hammingSolution.HasComments()
                ? hammingSolution.Disapprove()
                : hammingSolution.ContinueAnalysis();
        }

        private static SolutionAnalysis ApproveWhenValid(this HammingSolution hammingSolution)
        {
            if (hammingSolution.NumberOfStatements != 2 ||
                hammingSolution.ComparesLengthsUsingUnknown)
                return hammingSolution.ContinueAnalysis();
            
            if (hammingSolution.ComparesLengthsUsingNotEqual &&
                (hammingSolution.EndsWithLinqWhereSolution || hammingSolution.EndsWithLinqZipSolution))
                return hammingSolution.Approve();

            return hammingSolution.ContinueAnalysis();
        }
    }
}