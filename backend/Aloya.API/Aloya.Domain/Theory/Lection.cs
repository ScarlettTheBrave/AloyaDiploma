using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aloya.Domain.Module;

namespace Aloya.Domain.Theory
{
    public class Lection
    {
        public Lection()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Text { get; set; } = null!;
        public int ModuleId { get; set; }
        public virtual ICollection<Link> Links { get; set; } = new List<Link>();
        public virtual ICollection<Illustration> Illustrations { get; set; } = new List<Illustration>();
    }
}
