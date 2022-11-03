using Domen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public static class PhoneProvider
    {
        public static int AddToList(List<Phone> phones, Phone phone)
        {
            phones.Add(phone);
            return phone.PhoneId;
        }

        public static bool DeleteFromList(List<Phone> phones, int id)
        {
            int phone = phones.FindIndex(x => x.PhoneId == id);
            phones.RemoveAt(phone);
            return true;
        }

        public static List<Phone> GetAllFromList(List<Phone> list)
        {
            return list;
        }

        public static Phone GetPhoneById(List<Phone> list,int id)
        {
            return list.FirstOrDefault(x => x.PhoneId == id);
        }

        public static string UpdateList(List<Phone> list, Phone phone)
        {
            int item = list.FindIndex(x => x.PhoneId == phone.PhoneId);
            list[item] = phone;

            return phone.Name;
        }
    }
}
