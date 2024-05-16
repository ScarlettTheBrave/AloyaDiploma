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
    public class ImageAnswer()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ImageTaskId { get; set; }
        public byte[] Photo { get; set; } = new byte[0];
        public bool isRight { get; set; } = false;
    }
}
