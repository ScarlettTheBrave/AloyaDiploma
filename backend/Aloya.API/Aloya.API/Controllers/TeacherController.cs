using Aloya.Contract.Dtos;
using Aloya.Core.Interfaces;
using Aloya.Domain.Auth;
using Aloya.Domain.Module;
using Aloya.Domain.Tests;
using Aloya.Domain.Tests.Answers;
using Aloya.Domain.Tests.Tasks;
using Aloya.Domain.Theory;
using Aloya.Transfer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Aloya.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "TeacherPolicy")]
    public class TeacherController(ITeacherService service) : ControllerBase
    {
        private readonly ITeacherService _service = service;

        [HttpPost(Name = "AddModule")]
        public async Task<IResult> AddModule([FromForm]string name, [FromForm] string description, [FromForm] string colour, [FromForm] string photo)
            => Results.Ok(await _service.CreateModule(name, description, colour, photo));
        [HttpDelete("DeleteModule")]
        public async Task<IResult> DeleteModule(int id)
            => Results.Ok(await _service.DeleteModule(id));
        [HttpPut("UpdateModule")]
        public async Task<IResult> UpdateModule(Module module)
            => Results.Ok(await _service.UpdateModule(module));
       
        [HttpPost("AddLection")]
        public async Task<IResult> AddLection( [FromBody]LectionDto lection)
            => Results.Ok(await _service.CreateLection(lection));
        [HttpDelete("DeleteLection")]
        public async Task<IResult> DeleteLection(int id)
            => Results.Ok(await _service.DeleteLection(id));
        [HttpPut("UpdateLection")]
        public async Task<IResult> UpdateLection(Lection lection)
            => Results.Ok(await _service.UpdateLection(lection));
        [HttpPost("AddTest")]
        public async Task<IResult> AddTest([FromBody]GlobalTestDTO test)
            => Results.Ok(await _service.CreateTest(test));
        [HttpDelete("DeleteTest")]
        public async Task<IResult> DeleteTest(int id)
            => Results.Ok(await _service.DeleteTest(id));
        [HttpPut("UpdateTest")]
        public async Task<IResult> UpdateTest(GlobalTest test)
            => Results.Ok(await _service.UpdateTest(test));
        [HttpPost("AddImage")]
        public async Task<IResult> AddImage(Illustration img)
            => Results.Ok(await _service.CreateIllustration(img));
        [HttpDelete("DeleteImage")]
        public async Task<IResult> DeleteImage(int id)
            => Results.Ok(await _service.DeleteIllustration(id));
        [HttpPut("UpdateImage")]
        public async Task<IResult> UpdateImage(Illustration img)
            => Results.Ok(await _service.UpdateIllustration(img));
        [HttpPost("AddLink")]
        public async Task<IResult> AddLink(Link link)
            => Results.Ok(await _service.CreateLink(link));
        [HttpDelete("DeleteLink")]
        public async Task<IResult> DeleteLink(int id)
            => Results.Ok(await _service.DeleteLink(id));
        [HttpPut("UpdateLink")]
        public async Task<IResult> UpdateLink(Link link)
            => Results.Ok(await _service.UpdateLink(link));
        [HttpPost("AddForm")]
        public async Task<IResult> AddFormTask(FormTask task)
            => Results.Ok(await _service.CreateFormTask(task));
        [HttpDelete("DeleteForm")]
        public async Task<IResult> DeleteFormTask(int id)
            => Results.Ok(await _service.DeleteFormTask(id));
        [HttpPut("UpdateForm")]
        public async Task<IResult> UpdateFormTask(FormTask task)
            => Results.Ok(await _service.UpdateFormTask(task));
        [HttpPost("AddFormAnswer")]
        public async Task<IResult> AddFormAnswer(FormAnswer answer)
            => Results.Ok(await _service.CreateFormAnswer(answer));
        [HttpDelete("DeleteFormAnswer")]
        public async Task<IResult> DeleteFormAnswer(int id)
            => Results.Ok(await _service.DeleteFormAnswer(id));
        [HttpPut("UpdateFormAnswer")]
        public async Task<IResult> UpdateFormAnswer(FormAnswer answer)
            => Results.Ok(await _service.UpdateFormAnswer(answer));
        [HttpPost("AddArea")]
        public async Task<IResult> AddAreaTask(AreaTask task)
            => Results.Ok(await _service.CreateAreaTask(task));

        [HttpDelete("DeleteArea")]
        public async Task<IResult> DeleteAreaTask(int id)
            => Results.Ok(await _service.DeleteAreaTask(id));

        [HttpPut("UpdateArea")]
        public async Task<IResult> UpdateAreaTask(AreaTask task)
            => Results.Ok(await _service.UpdateAreaTask(task));

        [HttpPost("AddAreaAnswer")]
        public async Task<IResult> AddAreaAnswer(AreaAnswer answer)
            => Results.Ok(await _service.CreateAreaAnswer(answer));

        [HttpDelete("DeleteAreaAnswer")]
        public async Task<IResult> DeleteAreaAnswer(int id)
            => Results.Ok(await _service.DeleteAreaAnswer(id));

        [HttpPut("UpdateAreaAnswer")]
        public async Task<IResult> UpdateAreaAnswer(AreaAnswer answer)
            => Results.Ok(await _service.UpdateAreaAnswer(answer));
        [HttpPost("AddImageTask")]
        public async Task<IResult> AddImageTask(ImageTask task)
    => Results.Ok(await _service.CreateImageTask(task));

        [HttpDelete("DeleteImageTask")]
        public async Task<IResult> DeleteImageTask(int id)
            => Results.Ok(await _service.DeleteImageTask(id));

        [HttpPut("UpdateImageTask")]
        public async Task<IResult> UpdateImageTask(ImageTask task)
            => Results.Ok(await _service.UpdateImageTask(task));

        [HttpPost("AddImageAnswer")]
        public async Task<IResult> AddImageAnswer(ImageAnswer answer)
            => Results.Ok(await _service.CreateImageAnswer(answer));

        [HttpDelete("DeleteImageAnswer")]
        public async Task<IResult> DeleteImageAnswer(int id)
            => Results.Ok(await _service.DeleteImageAnswer(id));

        [HttpPut("UpdateImageAnswer")]
        public async Task<IResult> UpdateImageAnswer(ImageAnswer answer)
            => Results.Ok(await _service.UpdateImageAnswer(answer));
    }

}
