using Aloya.Contract.Dtos;
using Aloya.Domain.Module;
using Aloya.Domain.Tests;
using Aloya.Domain.Tests.Answers;
using Aloya.Domain.Tests.Tasks;
using Aloya.Domain.Theory;
using Aloya.Transfer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Core.Interfaces
{
    public interface ITeacherService
    {
        Task<bool> DeleteModule(int id);
        Task<bool> CreateTest(GlobalTestDTO test);
        Task<bool> DeleteTest(int id);
        Task<bool> UpdateTest(GlobalTest test);
        Task<bool> CreateModule(string name, string description, string colour, string? photo);
        Task<bool> UpdateModule(Module module);
        Task<bool> CreateLection(LectionDto lectionDto);
        Task<bool> DeleteLection(int id);
        Task<bool> UpdateLection(Lection lection);
        Task<bool> CreateLink(Link link);
        Task<bool> DeleteLink(int id);
        Task<bool> UpdateLink(Link link);
        Task<bool> CreateIllustration(Illustration illustration);
        Task<bool> DeleteIllustration(int id);
        Task<bool> UpdateIllustration(Illustration illustration);

        Task<bool> CreateImageTask(ImageTask imageTask);
        Task<bool> DeleteImageTask(int id);
        Task<bool> UpdateImageTask(ImageTask imageTask);
        Task<bool> CreateFormTask(FormTask form);
        Task<bool> DeleteFormTask(int id);
        Task<bool> UpdateFormTask(FormTask form);
        Task<bool> CreateAreaTask(AreaTask area);
        Task<bool> DeleteAreaTask(int id);
        Task<bool> UpdateAreaTask(AreaTask area);
        Task<bool> CreateFormAnswer(FormAnswer answer);
        Task<bool> DeleteFormAnswer(int id);
        Task<bool> UpdateFormAnswer(FormAnswer answer);
        Task<bool> CreateAreaAnswer(AreaAnswer answer);
        Task<bool> DeleteAreaAnswer(int id);
        Task<bool> UpdateAreaAnswer(AreaAnswer answer);
        Task<bool> CreateImageAnswer(ImageAnswer answer);
        Task<bool> DeleteImageAnswer(int id);
        Task<bool> UpdateImageAnswer(ImageAnswer answer);



    }
}
