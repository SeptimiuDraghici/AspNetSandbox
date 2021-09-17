using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandBox.Tests
{
    /// <summary>Tests for startup methods.</summary>
    public class StartupTests
    {
        /// <summary>Checks the conversion to ef connection string.</summary>
        [Fact]
        public void CheckConversionToEFConnectionString()
        {
            // Assume
            string databaseUrl = "postgres://sjptvypdgadked:bd6070f8c42539490991a5c9b5b523eccf1cd13fa59f9b8a4cf816748ae43200@ec2-54-155-61-133.eu-west-1.compute.amazonaws.com:5432/d2n671ck6p1p4a";

            // Act
            string convertedConnectionString = Startup.ConvertConnectionString(databaseUrl);

            // Assert
            Assert.Equal("Database=d2n671ck6p1p4a; Host=ec2-54-155-61-133.eu-west-1.compute.amazonaws.com; Port=5432; User Id=sjptvypdgadked; Password=bd6070f8c42539490991a5c9b5b523eccf1cd13fa59f9b8a4cf816748ae43200; SSL Mode=Require;Trust Server Certificate=true", convertedConnectionString);
        }
    }
}
