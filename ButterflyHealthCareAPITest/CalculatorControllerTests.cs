using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;

namespace ButterflyHealthCareAPI.Tests
{
    public class CalculatorControllerTests : IClassFixture<WebApplicationFactory<ButterflyHealthCareAPI.Program>>
    {
        private readonly HttpClient _client;

        public CalculatorControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient(); // Create an HTTP client to test the app
        }

        // Test for Add endpoint
        [Fact]
        public async Task Add_ShouldReturnSum_WhenValidNumbersAreProvided()
        {
            var response = await _client.PostAsync("/api/Calculator/Add?firstNumber=3&secondNumber=5", null);

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var sum = JsonSerializer.Deserialize<int>(result);
            sum.Should().Be(8);
        }

        // Test for Substract endpoint
        [Fact]
        public async Task Substract_ShouldReturnDifference_WhenValidNumbersAreProvided()
        {
            var response = await _client.PostAsync("/api/Calculator/Substract?firstNumber=10&secondNumber=3", null);

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var difference = JsonSerializer.Deserialize<int>(result);
            difference.Should().Be(7);
        }

        // Test for Multiply endpoint
        [Fact]
        public async Task Multiply_ShouldReturnProduct_WhenValidNumbersAreProvided()
        {
            var response = await _client.PostAsync("/api/Calculator/Multiply?firstNumber=4&secondNumber=6", null);

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var product = JsonSerializer.Deserialize<int>(result);
            product.Should().Be(24);
        }

        // Test for Divide endpoint
        [Fact]
        public async Task Divide_ShouldReturnQuotient_WhenValidNumbersAreProvided()
        {
            var response = await _client.PostAsync("/api/Calculator/Divide?firstNumber=20&secondNumber=4", null);

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var quotient = JsonSerializer.Deserialize<int>(result);
            quotient.Should().Be(5);
        }

        // Test Divide by Zero (BadRequest)
        [Fact]
        public async Task Divide_ShouldReturnBadRequest_WhenDivisionByZeroOccurs()
        {
            var response = await _client.PostAsync("/api/Calculator/Divide?firstNumber=20&secondNumber=0", null);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            var errorMessage = await response.Content.ReadAsStringAsync();
            errorMessage.Should().Contain("Division by zero is not allowed.");
        }
    }
}
