using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaperFlowWpf.Controller
{
    public class SciHubPdfFetcher
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<string> GetPdfUrlAsync(string doi)
        {
            try
            {
                string sciHubUrl = $"https://sci-hub.se/{doi}";
                HttpResponseMessage response = await _httpClient.GetAsync(sciHubUrl);
                response.EnsureSuccessStatusCode();
                string htmlContent = await response.Content.ReadAsStringAsync();

                string pattern = @"<embed[^>]+src=""(?<url>[^""]+)""";
                Match match = Regex.Match(htmlContent, pattern);
                if (match.Success)
                {
                    string pdfUrl = match.Groups["url"].Value;
                    if (pdfUrl.StartsWith("//"))
                    {
                        pdfUrl = "https:" + pdfUrl;
                    }
                    return pdfUrl;
                }
                else
                {
                    throw new Exception("PDF URL not found in Sci-Hub response.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching PDF URL: {ex.Message}");
                return null;
            }
        }
    }
}
