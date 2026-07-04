using FakestoreEcommerceTests.Models;
using FakestoreEcommerceTests.TestSupport;
using System.IO;
using System.Text.Json;

namespace FakestoreEcommerceTests.Helpers
{
    public static class TestUserFactory
    {
        public static TestUser CreateRandomUser()
        {
            return new TestUser
            {
                Email = Utils.GenerateRandomEmail(),
                Password = $"{Utils.GenerateRandomText(12)}Aa1!"
            };
        }

        public static TestUser GetUser(string userName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "users.json");
            var json = File.ReadAllText(filePath);
            var users = JsonSerializer.Deserialize<Dictionary<string, TestUser>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (users == null || !users.ContainsKey(userName))
            {
                throw new KeyNotFoundException($"Test user '{userName}' not found in {filePath}.");
            }

            return users[userName];
        }
    }
}
