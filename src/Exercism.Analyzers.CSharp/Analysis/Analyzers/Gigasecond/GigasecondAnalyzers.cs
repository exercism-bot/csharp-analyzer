using Microsoft.CodeAnalysis.Diagnostics;

namespace Exercism.Analyzers.CSharp.Analysis.Analyzers.Gigasecond
{
    internal static class GigasecondAnalyzers
    {
        public static readonly DiagnosticAnalyzer[] All = 
        {
            new UseExponentNotationAnalyzer()
        };
    }
}