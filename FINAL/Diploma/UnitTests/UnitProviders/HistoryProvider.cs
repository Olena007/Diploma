using Domen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public static class HistoryProvider
    {
        public static int AddToList(List<History> list, History el)
        {
            list.Add(el);
            return el.HistoryId;
        }

        public static bool DeleteFromList(List<History> list, int id)
        {
            int item = list.FindIndex(x => x.HistoryId == id);
            list.RemoveAt(item);
            return true;
        }

        public static List<History> GetAllFromList(List<History> list)
        {
            return list;
        }

    }
}
