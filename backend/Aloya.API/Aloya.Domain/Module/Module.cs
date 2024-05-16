using Aloya.Domain.Tests;
using Aloya.Domain.Theory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Domain.Module
{
        public class Module
        {
            public Module()
            {
            
            }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public string Description { get; set; } = string.Empty;
            public string Colour { get; set; } = string.Empty;
            public byte[]? Photo { get; set; } = new byte[0];
            public ICollection<Lection> Lections { get; set; } = new List<Lection>();
            public ICollection<GlobalTest> Test { get; set; } = new List<GlobalTest>();
    }
}

