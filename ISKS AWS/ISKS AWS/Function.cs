using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace ISKS.AWS
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest input, ILambdaContext context)
        {
            var response = new APIGatewayProxyResponse
            {
                Body = "Please use HTTP get and a name query string parameter",
                StatusCode = 200,
            };

            if (input.HttpMethod == "GET")
            {
                input.QueryStringParameters.TryGetValue("name", out var name);
                response.Body = $"Hello {name}!";
            }
            return response;
        }
    }
}
