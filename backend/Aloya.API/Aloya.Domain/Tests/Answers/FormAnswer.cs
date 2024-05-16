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
    public class FormAnswer()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FormTaskId { get; set; }
        public string Text { get; set; }
        public bool IsRight { get; set; } = false;
       

    }
}
