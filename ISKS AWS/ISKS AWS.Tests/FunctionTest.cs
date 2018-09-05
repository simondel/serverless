using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using System.Collections.Generic;
using Xunit;

namespace ISKS.AWS.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            var queryParams = new Dictionary<string, string>
            {
                { "name", "TestUser" }
            };
            var result = function.FunctionHandler(new APIGatewayProxyRequest { HttpMethod = "GET", QueryStringParameters = queryParams }, context);

            Assert.Equal("Hello TestUser!", result.Body);
        }
    }
}
