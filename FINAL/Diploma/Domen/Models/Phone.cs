using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models
{
    [Table("Phone")]
    public class Phone
    {
        [Key]
        public int PhoneId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Url { get; set; } = null!;

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public virtual ICollection<Basket>? Baskets { get; set; }
        public virtual ICollection<BasketComp>? BasketComps { get; set; }
    }
}
