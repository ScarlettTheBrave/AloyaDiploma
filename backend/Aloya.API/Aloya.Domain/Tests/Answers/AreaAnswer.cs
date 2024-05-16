using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aloya.Domain.Tests.Tasks;

namespace Aloya.Domain.Tests.Answers
{
    public class AreaAnswer()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AreaTaskId { get; set; }
        public bool IsRight { get; set; } = false;
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
    }
}
