using System.Text;

namespace ULW.CN.Controllers;

public class OpenAPICommunicationController
{
    private readonly string _apiKey = "GPSn5XsMwz4bDyROwiaRz0GIvnHO9nCt";

    public async Task<string> SendRequest(string prompt)
    {
        int maxTokens = 50;

        var requestBody = new
        {
            prompt = prompt,
            max_tokens = maxTokens
        };

        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

                var jsonRequest = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);

                // Set the Content-Type header on the StringContent object
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://api.openai.com/v1/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    // Read and return the response
                    string responses = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responses);

                    Console.ReadKey();
                    Console.ReadKey();

                    return responses;
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred: {ex.Message}");
        }
    }
}