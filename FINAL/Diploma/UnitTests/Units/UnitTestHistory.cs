using Moq;
using Application.Interfaces;
using Domen.Models;
using Application.Providers;
using AutoFixture;
using Microsoft.EntityFrameworkCore;

namespace UnitTests
{
    public class UnitTestHistory
    {
        [Fact]
        public void Create_ValidProduct_AddedToList()
        {
            // Arrange
            History newPhone = new History() { HistoryId = 1, BasketId = 1, BasketCompId = null };
            List<History> phones = new List<History>();

            //Act
            HistoryProvider.AddToList(phones, newPhone);

            //Assert
            Assert.True(phones.Count == 1);
            Assert.Contains<History>(newPhone, phones);
        }

        [Fact]
        public void Delete_ValidProduct_DeletetFromList()
        {
            //Arrange
            List<History> phones = new List<History>();
            History newPhone = new History() { HistoryId = 1, BasketId = 1, BasketCompId = null };

            //Act
            var id = HistoryProvider.AddToList(phones, newPhone);
            var deleted = HistoryProvider.DeleteFromList(phones, id);

            //Assert
            Assert.True(deleted);
        }

        [Fact]
        public void GetAll_ValidProduct_GetAllFromList()
        {
            //Arrange
            List<History> phones = new List<History>();
            History phone1 = new History() { HistoryId = 1, BasketId = 1, BasketCompId = null };
            History phone2 = new History() { HistoryId = 1, BasketId = 1, BasketCompId = null };

            //Act 
            var id1 = HistoryProvider.AddToList(phones, phone1);
            var id2 = HistoryProvider.AddToList(phones, phone2);
            var get = HistoryProvider.GetAllFromList(phones);

            //Assert
            Assert.NotNull(get);
        }
    }
}