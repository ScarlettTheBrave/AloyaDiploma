using Aloya.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Domain.Theory
{
    public class Link
    {
        public Link() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int LectionId { get; set; }
        public string? Name { get; set; }
        public LinkType Type { get; set; } = LinkType.Source;
    }
}
