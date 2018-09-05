using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

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
                Body = JsonConvert.SerializeObject(new ResponseMessage("Please set the query string 'name'")),
                StatusCode = 200
            };

            if (input.HttpMethod == "GET")
            {
                input.QueryStringParameters.TryGetValue("name", out var name);
                response.Body = JsonConvert.SerializeObject(new ResponseMessage($"Hello {name}!"));
            }
            return response;
        }

        class ResponseMessage
        {
            public string Message { get; set; }

            public ResponseMessage(string message)
            {
                Message = message;
            }
        }
    }
}
