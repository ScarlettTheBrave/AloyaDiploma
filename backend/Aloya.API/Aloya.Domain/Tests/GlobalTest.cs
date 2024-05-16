using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aloya.Domain.Tests.Tasks;
using Aloya.Domain.Module;
namespace Aloya.Domain.Tests
{
    public class GlobalTest
    {
        public GlobalTest()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string? Name { get; set; }

        public ICollection<AreaTask> AreaTests { get; set; } = new List<AreaTask>();
        public ICollection<ImageTask> ImageTests { get; set; } = new List<ImageTask>();
        public ICollection<FormTask> FormTests { get; set; } = new List<FormTask>();
        public double MaxCost { get; set; } = 20.0d;
    }
}
