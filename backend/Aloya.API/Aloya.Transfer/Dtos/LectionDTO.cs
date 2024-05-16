using Aloya.Domain.Theory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Contract.Dtos
{
    public class LectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Text { get; set; } = null!;
        public int ModuleId { get; set; }
        public virtual ICollection<Link> Links { get; set; } = new List<Link>();
        public virtual ICollection<IllustrationDto> Illustrations { get; set; } = new List<IllustrationDto>();
    }

    public class IllustrationDto
    {
        public int Id { get; set; }
        public int LectionId { get; set; }
        public string Name { get; set; }
        public string PhotoBase64 { get; set; }
    }
}
