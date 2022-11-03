using Domen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public static class ComputerProvider
    {
        public static int AddToList(List<Computer> comps, Computer comp)
        {
            comps.Add(comp);
            return comp.ComputerId;
        }

        public static bool DeleteFromList(List<Computer> comps, int id)
        {
            int phone = comps.FindIndex(x => x.ComputerId == id);
            comps.RemoveAt(phone);
            return true;
        }

        public static List<Computer> GetAllFromList(List<Computer> list)
        {
            return list;
        }

        public static Computer GetPhoneById(List<Computer> list,int id)
        {
            return list.FirstOrDefault(x => x.ComputerId == id);
        }

        public static string UpdateList(List<Computer> list, Computer comp)
        {
            int item = list.FindIndex(x => x.ComputerId == comp.ComputerId);
            list[item] = comp;

            return comp.Name;
        }
    }
}
