using Moq;
using Application.Interfaces;
using Domen.Models;
using Application.Providers;
using AutoFixture;
using Microsoft.EntityFrameworkCore;

namespace UnitTests
{
    public class UnitTestPhone
    {
        [Fact]
        public void Create_ValidProduct_AddedToList()
        {
            // Arrange
            Phone newPhone = new Phone() { PhoneId = 1, Name = "testPhone", Description = "not", Url = "url", Price = 1 };
            List<Phone> phones = new List<Phone>();

            //Act
            PhoneProvider.AddToList(phones, newPhone);

            //Assert
            Assert.True(phones.Count == 1);
            Assert.Contains<Phone>(newPhone, phones);
        }

        [Fact]
        public void Delete_ValidProduct_DeletetFromList()
        {
            //Arrange
            List<Phone> phones = new List<Phone>();
            Phone newPhone = new Phone() { PhoneId = 1, Name = "testPhone", Description = "not", Url = "url", Price = 1 };

            //Act
            var id = PhoneProvider.AddToList(phones, newPhone);
            var deleted = PhoneProvider.DeleteFromList(phones, id);

            //Assert
            Assert.True(deleted);
        }

        [Fact]
        public void GetAll_ValidProduct_GetAllFromList()
        {
            //Arrange
            List<Phone> phones = new List<Phone>();
            Phone phone1 = new Phone() { PhoneId = 1, Name = "testPhone", Description = "not", Url = "url", Price = 1 };
            Phone phone2 = new Phone() { PhoneId = 2, Name = "testPhone", Description = "not", Url = "url", Price = 1 };

            //Act 
            var id1 = PhoneProvider.AddToList(phones, phone1);
            var id2 = PhoneProvider.AddToList(phones, phone2);
            var get = PhoneProvider.GetAllFromList(phones);

            //Assert
            Assert.NotNull(get);
        }

        [Fact]
        public void GetById_ValidProduct_GetByIdFromList()
        {
            //Arrange
            List<Phone> phones = new List<Phone>();
            Phone phone = new Phone() { PhoneId = 1, Name = "testPhone", Description = "not", Url = "url", Price = 1 };


            //Act 
            var id = PhoneProvider.AddToList(phones, phone);
            var get = PhoneProvider.GetPhoneById(phones, id);

            //Assert
            Assert.NotNull(get);
        }

        [Fact]
        public void Update_ValidProduct_UpdateList()
        {
            //Arrange
            List<Phone> phones = new List<Phone>();
            Phone phone = new Phone() { PhoneId = 1, Name = "testPhone", Description = "not", Url = "url", Price = 1 };
            Phone updated = new Phone() { PhoneId = 1, Name = "new", Description = "not", Url = "url", Price = 1 };


            //Act
            var id = PhoneProvider.AddToList(phones, phone);
            var name = PhoneProvider.UpdateList(phones, updated);

            //Assert
            Assert.Equal("new", name);
        }
    }
}