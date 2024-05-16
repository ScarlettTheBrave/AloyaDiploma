using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aloya.Domain.Tests.Answers;

namespace Aloya.Domain.Tests.Tasks
{
    public class ImageTask
    {
        public ImageTask()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TestId { get; set; }
        public string? Name { get; set; }
        public ICollection<ImageAnswer> Images { get; set; } = new List<ImageAnswer>();
        public string Question { get; set; } = null!;
        public double Cost { get; set; } = 20.0d;
    }
}
