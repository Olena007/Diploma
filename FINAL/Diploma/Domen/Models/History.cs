using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models
{
    [Table("History")]
    public class History
    {
        [Key]
        public int HistoryId { get; set; }
        public int? BasketId { get; set; }
        public int? BasketCompId { get; set; }
        public virtual Basket? Basket { get; set; }
        public virtual BasketComp? BasketComp { get; set; }
    }
}
