using Moq;
using Application.Interfaces;
using Domen.Models;
using Application.Providers;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using UnitTests.UnitProviders;

namespace UnitTests
{
    public class UnitTestClient
    {
        [Fact]
        public void Register_ValidProduct_AddedToList()
        {
            // Arrange
            Client client = new Client() { Email = "a@a", Password = BCrypt.Net.BCrypt.HashPassword("1") };
            List<Client> clients = new List<Client>();

            //Act
            AuthProvider.AddToList(clients, client);

            //Assert
            Assert.True(clients.Count == 1);
            Assert.Contains<Client>(client, clients);
        }

        [Fact]
        public void Login_ValidProduct_AddedToList()
        {
            //Arrange
            List<Client> clients = new List<Client>();
            Client newClient = new Client() { Email = "a@a", Password = BCrypt.Net.BCrypt.HashPassword("1") };

            //Act
            var id = AuthProvider.AddToList(clients, newClient);
            AuthProvider.GetByEmail(clients, "a@a");
            var test = AuthProvider.Generate(id);


            //Assert
            Assert.NotEmpty(test);
        }

        
    }
}