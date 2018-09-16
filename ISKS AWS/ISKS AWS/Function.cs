using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
        public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var response = new APIGatewayProxyResponse()
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Body = "Please set query param 'name'!",
            };
            
            if (request.HttpMethod == "GET" && request.QueryStringParameters != null && request.QueryStringParameters.Any(kv => kv.Key == "name"))
            {
                response.Body = $"Hello {request.QueryStringParameters.Single(kv => kv.Key == "name").Value}!";
                response.StatusCode = (int)HttpStatusCode.OK,
            }

            return response;
        }
    }
}
