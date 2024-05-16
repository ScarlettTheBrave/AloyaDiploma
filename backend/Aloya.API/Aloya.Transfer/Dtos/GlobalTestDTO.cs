using Aloya.Domain.Tests.Answers;
using Aloya.Domain.Tests.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Transfer.Dtos
{
    public record GlobalTestDTO
    {
        public GlobalTestDTO()
        {
            
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public double MaxCost { get; set; } = 20.0d;
        public int ModuleId { get; set; }
        public ICollection<ImageTaskDTO> imageTests { get; set; } = new List<ImageTaskDTO>();
        public ICollection<FormTask> formTests { get; set; } = new List<FormTask>();
        public ICollection<AreaTaskDTO> areaTests { get; set; } = new List<AreaTaskDTO>();
       
    }

    public record FormTaskDTO()
    {
        //public int Id { get; set; }
        public string? Name { get; set; }
        public int TestId { get; set; }
        public string Question { get; set; } = string.Empty;
        public ICollection<FormAnswer>? Answers { get; set; } = new List<FormAnswer>();
        public int Cost { get; set; } = 10;
    }
    public record ImageTaskDTO()
    {
        //public int Id { get; set; }
        public int TestId { get; set; }
        public string? Name { get; set; }
        public ICollection<ImageAnswerDTO> images { get; set; } = new List<ImageAnswerDTO>();
        public string Question { get; set; } = null!;
        public double Cost { get; set; } = 20.0d;
    }
    public record ImageAnswerDTO()
    {
        //public int Id { get; set; }
        public int ImageTaskId { get; set; }
        public string photo { get; set; }
        public bool isRight { get; set; } = false;
    }
    public record AreaTaskDTO()
    {
        //public int Id { get; set; }
        public int TestId { get; set; }
        public string? Name { get; set; }
        public string photo { get; set; }
        public ICollection<AreaAnswer> AreaAnswers { get; set; } = new List<AreaAnswer>();
        public string Question { get; set; } = null!;
        public double Cost { get; set; } = 30;
    }
    
   
}
