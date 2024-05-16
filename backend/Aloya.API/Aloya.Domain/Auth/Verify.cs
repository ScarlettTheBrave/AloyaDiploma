using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Domain.Auth
{
    public class Verify
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Phone {  get; set; }
        public string? Email { get; set; }
        public bool IsVerified { get; set; } = false;
        public int UserId { get; set; }
    }
}
