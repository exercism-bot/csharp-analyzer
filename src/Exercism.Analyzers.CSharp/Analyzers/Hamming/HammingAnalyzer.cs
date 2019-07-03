namespace Exercism.Analyzers.CSharp.Analyzers.Hamming
{
    internal static class HammingAnalyzer
    {
        public static SolutionAnalysis Analyze(ParsedSolution parsedSolution) =>
            Analyze(HammingSolutionParser.Parse(parsedSolution));

        private static SolutionAnalysis Analyze(HammingSolution hammingSolution) =>
            hammingSolution.DisapproveWhenInvalid() ??
            hammingSolution.ApproveWhenValid() ??
            hammingSolution.ApproveWhenOptimal() ??
            hammingSolution.ReferToMentor();

        private static SolutionAnalysis DisapproveWhenInvalid(this HammingSolution hammingSolution) =>
            hammingSolution.ContinueAnalysis();

        private static SolutionAnalysis ApproveWhenValid(this HammingSolution hammingSolution) =>
            hammingSolution.ContinueAnalysis();

        private static SolutionAnalysis ApproveWhenOptimal(this HammingSolution hammingSolution)
        {
            if (hammingSolution.NumberOfStatements == 2 &&
                hammingSolution.StartsWithIfStatement &&
                hammingSolution.IfStatementThrowsArgumentException &&
                hammingSolution.ComparesLengthsUsingNotEqual &&
                hammingSolution.EndsWithLinqWhereSolution)
                return hammingSolution.ApproveAsOptimal();

            return hammingSolution.ContinueAnalysis();
        }
    }
}