using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models
{
    [Table("BasketComp")]
    public class BasketComp
    {
        [Key]
        public int BasketId { get; set; }
        public int? PhoneId { get; set; }
        public int? ComputerId { get; set; }
        public int? ClientId { get; set; }
        public int? Count { get; set; }

        public virtual Client? Client { get; set; }
        public virtual Computer? Computer { get; set; }
        public virtual Phone? Phone { get; set; }
        public virtual ICollection<History>? Histories { get; set; }
    }
}
