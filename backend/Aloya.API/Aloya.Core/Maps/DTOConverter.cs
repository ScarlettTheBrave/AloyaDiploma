using Aloya.Domain.Tests.Answers;
using Aloya.Domain.Tests.Tasks;
using Aloya.Domain.Tests;
using Aloya.Transfer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Core.Maps
{
    public static class DTOConverter
    {
        public static GlobalTest ToGlobalTest(GlobalTestDTO dto)
        {
            return new GlobalTest()
            {
                Name = dto.Name,
                MaxCost = dto.MaxCost,
                ModuleId = dto.ModuleId,
                AreaTests = dto.areaTests.Select(a => ToAreaTask(a)).ToList(),
                ImageTests = dto.imageTests.Select(a => ToImageTask(a)).ToList(),
                FormTests = dto.formTests.Select(f => ToFormTask(f)).ToList()
                
             
                };
        }

        public static AreaTask ToAreaTask(AreaTaskDTO dto)
        {
            return new AreaTask
            {
                Name = dto.Name,
                TestId = dto.TestId,
                photo = ByteConverter.GetBytes(dto.photo),
                AreaAnswers = dto.AreaAnswers.Select(ToAreaAnswer).ToList(),
                Question = dto.Question,
                Cost = dto.Cost
            };
        }

        public static ImageTask ToImageTask(ImageTaskDTO dto)
        {
            return new ImageTask
            {
                Name = dto.Name,
                TestId = dto.TestId,
                Images = dto.images.Select(ToImageAnswer).ToList(),
                Question = dto.Question,
                Cost = dto.Cost
            };
        }

        public static FormTask ToFormTask(FormTask dto)
        {
            return new FormTask
            {
                Name = dto.Name,
                TestId = dto.TestId,
                Question = dto.Question,
                Answers = dto.Answers.Select(ToFormAnswer).ToList(),
            };
        }
        public static FormAnswer ToFormAnswer(FormAnswer fa)
        {
            return new FormAnswer
            {
                FormTaskId = fa.FormTaskId,
                Text = fa.Text,
                IsRight = fa.IsRight,
            };
        }
        public static AreaAnswer ToAreaAnswer(AreaAnswer dto)
        {
            return new AreaAnswer
            {
                AreaTaskId = dto.AreaTaskId,
                X = dto.X,
                Y = dto.Y,
                Radius = dto.Radius,
                IsRight = dto.IsRight
            };
        }

        public static ImageAnswer ToImageAnswer(ImageAnswerDTO dto)
        {
            return new ImageAnswer
            {
                ImageTaskId = dto.ImageTaskId,
                Photo = ByteConverter.GetBytes(dto.photo),
                isRight = dto.isRight
            };
        }

    }
}
