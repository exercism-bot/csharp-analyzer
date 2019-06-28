using Exercism.Analyzers.CSharp.Analyzers.Shared;

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

        private static SolutionAnalysis DisapproveWhenInvalid(this HammingSolution hammingSolution)
        {
            // TODO: implement

            return hammingSolution.HasComments()
                ? hammingSolution.DisapproveWithComment()
                : hammingSolution.ContinueAnalysis();
        }

        private static SolutionAnalysis ApproveWhenValid(this HammingSolution hammingSolution)
        {
            // TODO: implement

            return hammingSolution.HasComments() ?
                hammingSolution.ApproveWithComment() :
                hammingSolution.ContinueAnalysis();
        }

        private static SolutionAnalysis ApproveWhenOptimal(this HammingSolution hammingSolution)
        {
            // TODO: implement

            return hammingSolution.ContinueAnalysis();
        }
    }
}