using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Contract.Dtos
{
    public record ModuleDTO
    {
        public ModuleDTO()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public string Colour { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty; 
        
    }
}
