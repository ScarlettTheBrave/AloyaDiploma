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
    public record FormTask
    {
        public FormTask()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TestId { get; set; }
        public string Question { get; set; } = string.Empty;
        public ICollection<FormAnswer>? Answers { get; set; } = new List<FormAnswer>(); 
        public int Cost { get; set; } = 10;
    }
}
