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
            //context.Logger.LogLine("This is useful for debugging!"); 
            return new APIGatewayProxyResponse()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "Go Serverless v1.0! Your function executed successfully!",
            };
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
