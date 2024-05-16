using Aloya.Contract.Dtos;
using Aloya.Core.Interfaces;
using Aloya.Domain.Auth;
using Aloya.Domain.Module;
using Aloya.Domain.Tests;
using Aloya.Transfer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aloya.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AdminController(IAdminService adminService) : ControllerBase
    { 

        private readonly IAdminService _adminService = adminService;
        [Authorize(Policy = "AdminPolicy")]
        [HttpGet("Users", Name = "GetAllUsers")]
        public async Task<IQueryable<UserDTO>> GetUsers()
            => await _adminService.GetAllUsers();
      
        [HttpGet("Modules", Name = "GetAllModules")]
        public async Task<IEnumerable<ModuleDTO>> GetModules()
            => await _adminService.GetAllModules();
        [Authorize(Policy = "AdminPolicy")]
        [HttpGet("Tests",Name = "GetAllTests")]
        public async Task<IQueryable<GlobalTestDTO>> GetTests()
            => await _adminService.GetAllTests();
        [Authorize(Policy = "AdminPolicy")]
        [HttpGet("User", Name = "GetSingleUser" )]
        public async Task<UserEntity> GetSingleUser(int id)
            => await _adminService.GetSingleUser(id);
        [HttpGet("Module", Name = "GetSingleModule")]
        public async Task<Module> GetSingleModule(int id)
            => await _adminService.GetSingleModule(id);
        [Authorize(Policy = "TeacherPolicy")]
        [HttpGet("Test", Name = "GetSingleTest")]
        public async Task<GlobalTest> GetSingleTest(int id)
            => await _adminService.GetSingleTest(id);
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("AddUser")]
        public async Task<bool> CreateUser(UserEntity user)
            => await _adminService.CreateUser(user);
        [Authorize(Policy = "AdminPolicy")]
        [HttpPut("UpdateUser")]
        public async Task<bool> UpdateUser(UserEntity user)
            => await _adminService.UpdateUser(user);
        [Authorize(Policy = "AdminPolicy")]
        [HttpDelete("DeleteUser")]
        public async Task<bool> DeleteUser(int id)
            => await _adminService.DeleteUser(id);
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("AddModule")]
        public async Task<bool> CreateModule(Module module)
            => await _adminService.CreateModule(module);
        [Authorize(Policy = "AdminPolicy")]
        [HttpPut("UpdateModule")]
        public async Task<bool> UpdateModule(Module module) 
            => await _adminService.UpdateModule(module);
        [Authorize(Policy = "AdminPolicy")]
        [HttpDelete("DeleteModule")]
        public async Task<bool> DeleteModule(int id)
            => await _adminService.DeleteModule(id);
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("AddTest")]
        public async Task<bool> CreateTest(GlobalTest test)
            => await _adminService.CreateTest(test);
        [Authorize(Policy = "AdminPolicy")]
        [HttpPut("UpdateTest")]
        public async Task<bool> UpdateTest(GlobalTest test)
            => await _adminService.UpdateTest(test);
        [Authorize(Policy = "AdminPolicy")]
        [HttpDelete("DeleteTest")]
        public async Task<bool> DeleteTest(int id)
            => await _adminService.DeleteTest(id);

    }
}
