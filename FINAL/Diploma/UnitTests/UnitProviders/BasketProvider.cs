using Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.UnitProviders
{
    public static class BasketProvider
    {
        public static int AddToList(List<Basket> list, Basket el)
        {
            list.Add(el);
            return el.BasketId;
        }

        public static bool DeleteFromList(List<Basket> list, int id)
        {
            int item = list.FindIndex(x => x.BasketId == id);
            list.RemoveAt(item);
            return true;
        }

        public static List<Basket> GetAllFromList(List<Basket> list)
        {
            return list;
        }

        public static Basket GetPhoneById(List<Basket> list, int id)
        {
            return list.FirstOrDefault(x => x.BasketId == id);
        }
    }
}
