namespace TestingRestSharp
{

    using System.Net;

    using AutoFixture;

    using FluentAssertions;

    using Newtonsoft.Json.Linq;

    using RestSharp;

    using TestingRestSharp.src.model;

    using Xunit;
    using Xunit.Abstractions;

    public class ReqresRestSharp
    {
        private readonly ITestOutputHelper output;
        private RestClient client;
        private Fixture fixture;
        private User userRandom;

        public ReqresRestSharp(ITestOutputHelper output)
        {
            client = new RestClient("https://reqres.in");
            this.output = output;
            fixture = new Fixture();
            userRandom = fixture.Create<User>();

        }

        [Fact]
        public void Get_List_Users()
        {
            // Arrange
            var request = new RestRequest("/api/users?page=2");

            // Act
            IRestResponse response = client.Execute(request, Method.GET);
            string json = response.Content;
            JObject users = JObject.Parse(json);
            var statusCode = response.StatusCode.ToString();
            var expectedStatusCode = "OK";

            // Assert
            statusCode.Should().Be(expectedStatusCode);

            var name = users["data"][0]["first_name"].ToString();
            var expectedName = "Eve";

            // Assert
            name.Should().Be(expectedName);
        }

        [Fact]
        public void Get_User_Not_Found()
        {
            // Arrange
            var request = new RestRequest("/api/users/23");

            // Act
            IRestResponse response = client.Execute(request, Method.GET);

            var statusCode = response.StatusCode;
            var content = response.Content;

            // Assert
            statusCode.Should().Be(HttpStatusCode.NotFound);
            content.Should().Be("{}");
        }

        [Fact]
        public void Post_Create_User_()
        {
            // Arrange
            var request = new RestRequest("/api/users");


            // Act
            var requestBody = new User()
            {
                name = userRandom.name,
                job = userRandom.job
            };

            request.AddJsonBody(requestBody);
            client.Execute(request);
            IRestResponse response = client.Execute(request, Method.POST);

            var statusCode = response.StatusCode;
            var content = response.Content;

            // Assert
            statusCode.Should().Be(HttpStatusCode.Created);
            output.WriteLine(content.ToString());

        }
    }
}
