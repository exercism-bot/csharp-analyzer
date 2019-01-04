using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Exercism.Analyzers.CSharp.IntegrationTests.Helpers
{
    public abstract class SolutionAnalysisTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly FakeExercise _fakeExercise;
        private readonly FakeExercismCommandLineInterface _fakeExercismCommandLineInterface;

        protected SolutionAnalysisTests(WebApplicationFactory<Startup> factory, FakeExercise fakeExercise)
        {
            _fakeExercise = fakeExercise;
            _fakeExercismCommandLineInterface = new FakeExercismCommandLineInterface();
            _httpClient = AnalysisTestsHttpClientFactory.Create(factory, _fakeExercismCommandLineInterface);
        }

        protected async Task AnalysisDoesNotReturnComment([CallerMemberName]string testMethodName = "")
        {
            var comments = await GetCommentsFromAnalysis(testMethodName).ConfigureAwait(false);
            Assert.Empty(comments);
        }

        protected async Task AnalysisReturnsComment(string expected, [CallerMemberName]string testMethodName = "")
        {   
            var comments = await GetCommentsFromAnalysis(testMethodName).ConfigureAwait(false);
            Assert.Contains(expected, comments);
        }

        private async Task<string[]> GetCommentsFromAnalysis(string testMethodName)
        {
            var fakeSolution = CreateFakeSolution(testMethodName);
            _fakeExercismCommandLineInterface.Configure(fakeSolution);

            var response = await RequestAnalysis(fakeSolution).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<string[]>().ConfigureAwait(false);
        }

        private FakeSolution CreateFakeSolution(string testMethodName) =>
            new FakeSolution(TestMethodNameToImplementationFile(testMethodName), _fakeExercise, SolutionCategory);

        private Task<HttpResponseMessage> RequestAnalysis(FakeSolution fakeSolution)
        {
            var fakeSolutionUrl = $"/api/analyze/{fakeSolution.Id}";
            return _httpClient.GetAsync(fakeSolutionUrl);
        }

        private static string TestMethodNameToImplementationFile(string testMethodName) =>
            testMethodName
                .Replace("DoesNotReturnComment", string.Empty)
                .Replace("ReturnsComment", string.Empty);
        
        private string SolutionCategory => GetType().Name.Replace("Tests", "");
    }
}