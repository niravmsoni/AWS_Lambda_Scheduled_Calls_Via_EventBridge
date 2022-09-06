using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWS_Lambda_Scheduled_Calls_Via_EventBridge;

public class Function
{

    /// <summary>
    /// A simple function that makes a rest call to endpoint and returns deserialized object
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<User> FunctionHandler(ILambdaContext context)
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<User>(content);
    }
}

public class User
{
    public string UserId { get; set; }
    public string Id { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }

    public DateTime CalledAt { get { return DateTime.Now; } }
}