using Moq;
using Application.Interfaces;
using Domen.Models;
using UnitTests.UnitProviders;
using AutoFixture;
using Microsoft.EntityFrameworkCore;

namespace UnitTests
{
    public class UnitTestBasket
    {
        [Fact]
        public void Create_ValidProduct_AddedToList()
        {
            // Arrange
            Basket newPhone = new Basket() { BasketId = 1, PhoneId = 1, ComputerId = 1, ClientId = 1, Count = null };
            List<Basket> phones = new List<Basket>();

            //Act
            BasketProvider.AddToList(phones, newPhone);

            //Assert
            Assert.True(phones.Count == 1);
            Assert.Contains<Basket>(newPhone, phones);
        }

        [Fact]
        public void Delete_ValidProduct_DeletetFromList()
        {
            //Arrange
            List<Basket> phones = new List<Basket>();
            Basket newPhone = new Basket() { BasketId = 1, PhoneId = 1, ComputerId = 1, ClientId = 1, Count = null };

            //Act
            var id = BasketProvider.AddToList(phones, newPhone);
            var deleted = BasketProvider.DeleteFromList(phones, id);

            //Assert
            Assert.True(deleted);
        }

        [Fact]
        public void GetAll_ValidProduct_GetAllFromList()
        {
            //Arrange
            List<Basket> phones = new List<Basket>();
            Basket phone1 = new Basket() { BasketId = 1, PhoneId = 1, ComputerId = 1, ClientId = 1, Count = null };
            Basket phone2 = new Basket() { BasketId = 1, PhoneId = 1, ComputerId = 1, ClientId = 1, Count = null };

            //Act 
            var id1 = BasketProvider.AddToList(phones, phone1);
            var id2 = BasketProvider.AddToList(phones, phone2);
            var get = BasketProvider.GetAllFromList(phones);

            //Assert
            Assert.NotNull(get);
        }

        [Fact]
        public void GetById_ValidProduct_GetByIdFromList()
        {
            //Arrange
            List<Basket> phones = new List<Basket>();
            Basket phone = new Basket() { BasketId = 1, PhoneId = 1, ComputerId = 1, ClientId = 1, Count = null };


            //Act 
            var id = BasketProvider.AddToList(phones, phone);
            var get = BasketProvider.GetPhoneById(phones, id);

            //Assert
            Assert.NotNull(get);
        }

    }
}