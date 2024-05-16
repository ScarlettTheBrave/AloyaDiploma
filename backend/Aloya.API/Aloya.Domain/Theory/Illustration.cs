using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Domain.Theory
{
    public class Illustration
    {
        public Illustration()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int LectionId { get; set; }
        public string Name { get; set; } = null!;
        public byte[]? Photo { get; set; }
    }
}
