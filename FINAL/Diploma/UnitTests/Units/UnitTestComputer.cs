using Moq;
using Application.Interfaces;
using Domen.Models;
using Application.Providers;
using AutoFixture;
using Microsoft.EntityFrameworkCore;

namespace UnitTests
{
    public class UnitTestComputer
    {
        [Fact]
        public void Create_ValidProduct_AddedToList()
        {
            // Arrange
            Computer newPhone = new Computer() { ComputerId = 1, Name = "testPhone", Description = "not", Url = "url", Price = 1 };
            List<Computer> phones = new List<Computer>();

            //Act
            ComputerProvider.AddToList(phones, newPhone);

            //Assert
            Assert.True(phones.Count == 1);
            Assert.Contains<Computer>(newPhone, phones);
        }

        [Fact]
        public void Delete_ValidProduct_DeletetFromList()
        {
            //Arrange
            List<Computer> phones = new List<Computer>();
            Computer newPhone = new Computer() { ComputerId = 1, Name = "testPhone", Description = "not", Url = "url", Price = 1 };

            //Act
            var id = ComputerProvider.AddToList(phones, newPhone);
            var deleted = ComputerProvider.DeleteFromList(phones, id);

            //Assert
            Assert.True(deleted);
        }

        [Fact]
        public void GetAll_ValidProduct_GetAllFromList()
        {
            //Arrange
            List<Computer> phones = new List<Computer>();
            Computer phone1 = new Computer() { ComputerId = 1, Name = "testPhone", Description = "not", Url = "url", Price = 1 };
            Computer phone2 = new Computer() { ComputerId = 2, Name = "testPhone", Description = "not", Url = "url", Price = 1 };

            //Act 
            var id1 = ComputerProvider.AddToList(phones, phone1);
            var id2 = ComputerProvider.AddToList(phones, phone2);
            var get = ComputerProvider.GetAllFromList(phones);

            //Assert
            Assert.NotNull(get);
        }

        [Fact]
        public void GetById_ValidProduct_GetByIdFromList()
        {
            //Arrange
            List<Computer> phones = new List<Computer>();
            Computer phone = new Computer() { ComputerId = 1, Name = "testPhone", Description = "not", Url = "url", Price = 1 };


            //Act 
            var id = ComputerProvider.AddToList(phones, phone);
            var get = ComputerProvider.GetPhoneById(phones, id);

            //Assert
            Assert.NotNull(get);
        }

        [Fact]
        public void Update_ValidProduct_UpdateList()
        {
            //Arrange
            List<Computer> phones = new List<Computer>();
            Computer phone = new Computer() { ComputerId = 1, Name = "testPhone", Description = "not", Url = "url", Price = 1 };
            Computer updated = new Computer() { ComputerId = 1, Name = "new", Description = "not", Url = "url", Price = 1 };


            //Act
            var id = ComputerProvider.AddToList(phones, phone);
            var name = ComputerProvider.UpdateList(phones, updated);

            //Assert
            Assert.Equal("new", name);
        }
    }
}