using System;
using System.IO;
using System.Text;
using Xunit;

namespace AspNetSandBox.Tests
{
    /// <summary>Test class for File Operations.</summary>
    public class FileOperationWithBooksTests
    {
        /// <summary>Test for enumerating all the files.</summary>
        [Fact]
        public void EnumerateFilesTest()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(".");
            var files = directoryInfo.EnumerateFiles();
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
        }

        /// <summary>Test for creating file.</summary>
        [Fact]
        public void CreateFilesTest()
        {
            File.WriteAllText("newSettings.json", @"{
                                                      ""ConnectionStrings"": {
                                                        ""DefaultConnection"": ""Database=SandboxDb; Host=localhost; Port=5432; User Id=postgres; Password=mZqWLH6zBKRh1x6TYtn6; Trust Server Certificate=true"",
                                                        ""HerokuPostgresConnection"": ""Database=d2n671ck6p1p4a; Host=ec2-54-155-61-133.eu-west-1.compute.amazonaws.com; Port=5432; User Id=sjptvypdgadked; Password=bd6070f8c42539490991a5c9b5b523eccf1cd13fa59f9b8a4cf816748ae43200; SSL Mode=Require;Trust Server Certificate=true"",
                                                        ""LocalPostgresConnection"": ""Server=127.0.0.1;Port=5432;Database=AspNetSandbox-Timi;User Id=postgres;Password=mZqWLH6zBKRh1x6TYtn6;"",
                                                        ""SqlConnection"": ""Server=(localdb)\\mssqllocaldb;Database=aspnet-AspNetSandBox-E353A998-BA8D-429F-A865-103ED58DBF92;Trusted_Connection=True;MultipleActiveResultSets=true""
                                                      },
                                                      ""Logging"": {
                                                        ""LogLevel"": {
                                                          ""Default"": ""Information"",
                                                          ""Microsoft"": ""Warning"",
                                                          ""Microsoft.Hosting.Lifetime"": ""Information""
                                                        }
                                                      },
                                                      ""AllowedHosts"": ""*""
                                                    }

                                                    ");
        }

        /// <summary>Test for reading a file step by step using filestream.</summary>
        [Fact]
        public void ReadFilesTest()
        {
            using (var fs = File.OpenRead("newSettings.json"))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    string returnedString = temp.GetString(b);
                    Console.WriteLine(returnedString);
                }
            }
        }
    }
}
