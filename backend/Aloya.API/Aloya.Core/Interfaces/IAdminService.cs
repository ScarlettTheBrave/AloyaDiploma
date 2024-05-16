using Aloya.Contract.Dtos;
using Aloya.Domain.Auth;
using Aloya.Domain.Module;
using Aloya.Domain.Tests;
using Aloya.Transfer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Core.Interfaces
{
    public interface IAdminService
    {
        Task<IQueryable<UserDTO>> GetAllUsers();
        Task<IQueryable<ModuleDTO>> GetAllModules();
        Task<IQueryable<GlobalTestDTO>> GetAllTests();
        Task<UserEntity> GetSingleUser(int id);
        Task<Module> GetSingleModule(int id);
        Task<GlobalTest> GetSingleTest(int id);
        Task<bool> CreateUser(UserEntity user);
        Task<bool> UpdateUser(UserEntity user);
        Task<bool> DeleteUser(int id);
        Task<bool> CreateModule(Module module);
        Task<bool> UpdateModule(Module module);
        Task<bool> DeleteModule(int id);
        Task<bool> CreateTest(GlobalTest test);
        Task<bool> UpdateTest(GlobalTest test);
        Task<bool> DeleteTest(int id);
    }
}
