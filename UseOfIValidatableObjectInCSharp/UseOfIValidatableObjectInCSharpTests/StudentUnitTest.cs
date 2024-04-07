using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using UseOfIValidatableObjectInCSharp; 

public class StudentsControllerTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly WebApplicationFactory<Startup> _factory;

    public StudentsControllerTests(WebApplicationFactory<Startup> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Post_EndpointReturnsSuccessAndCorrectContentType()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.PostAsync("/Students", new StringContent("{\r\n  \"email\": \"testemail@gmail.com\",\r\n  \"telephone\": \"+134234\",\r\n  \"documentList\": [\r\n    {\r\n      \"documentName\": \"test.pdf\",\r\n      \"createdDate\": \"2024-04-07T17:53:58.566Z\",\r\n      \"expiryDate\": \"2024-04-10T17:53:58.566Z\"\r\n    }\r\n  ]\r\n}", System.Text.Encoding.UTF8, "application/json"));

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Post_EndpointReturnsBadRequestForInvalidModel()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.PostAsync("/Students", new StringContent("{\"Email\":\"invalid_email\",\"Telephone\":\"+1234567890\"}", System.Text.Encoding.UTF8, "application/json"));

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }
}
