using Aloya.Contract.Dtos;
using Aloya.Core.Interfaces;
using Aloya.Core.Maps;
using Aloya.Domain.Auth;
using Aloya.Domain.Module;
using Aloya.Domain.Tests;
using Aloya.Infrastructure.Data;
using Aloya.Transfer.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Core.Services
{
    public class AdminService(DataContext context) : IAdminService
    {
        private readonly DataContext _context = context;
        public async Task<bool> CreateModule(Module module)
        {
            try
            {
                if (module is null)
                    throw new ArgumentNullException("user is null");
                await _context.AddAsync(module);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public  async Task<bool> CreateTest(GlobalTest test)
        {
            try
            {
                if (test is null)
                    throw new ArgumentNullException("Test is null");
                await _context.AddAsync(test);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> CreateUser(UserEntity user)
        {
            try
            {
                if (user is null)
                    throw new ArgumentNullException("user is null");
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(ArgumentNullException ex)  
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> DeleteModule(int id)
        {
            try
            {
                var delModule = await _context.Modules.FirstOrDefaultAsync(m => m.Id.Equals(id))
                    ?? throw new InvalidOperationException("Module is not found");
                _context.Remove(delModule);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> DeleteTest(int id)
        {
            try
            {
                var delTest = await _context.GlobalTests.FirstOrDefaultAsync(t => t.Id.Equals(id))
                    ?? throw new InvalidOperationException("Test is not found");
                _context.Remove(delTest);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
           try
            {
                var delUser = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id))
                    ?? throw new InvalidOperationException("User is not found");
                _context.Remove(delUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<IQueryable<ModuleDTO>> GetAllModules()
        {
            var modulesList = await _context.Modules.ToListAsync();
            return modulesList.Select(ModuleMapper.MapToDTO).AsQueryable();
        }

        public async Task<IQueryable<GlobalTestDTO>> GetAllTests()
        {
            var testsList = await _context.GlobalTests.ToListAsync();
            return testsList.Select(GlobalTestMapper.MapToDTO).AsQueryable();
        }

        public async Task<IQueryable<UserDTO>> GetAllUsers()
        {
            var usersList = await _context.Users.ToListAsync();
            usersList.ForEach( u => 
                u.Admicies = _context.userAdmicies
                    .Where(a => a.userId.Equals(u.Id))
                    .ToList());
            return usersList.Select(UserMapper.MapToDTO).AsQueryable();
        }

        public async Task<Module> GetSingleModule(int id)
        {
            try
            {
                var selModule = await _context.Modules
                    .Include(m => m.Lections)
                        .ThenInclude(l => l.Illustrations)
                    .Include(m => m.Lections)
                        .ThenInclude(l => l.Links)
                    .Include(m => m.Test).FirstOrDefaultAsync(m => m.Id.Equals(id)) 
                    ?? throw new InvalidOperationException("Module is undefined.");
                return selModule;
            }
            catch(InvalidOperationException ex) 
            {
                Console.WriteLine(ex.ToString());
                return new Module() 
                { 
                    Name = "Invalid module"
                };
            }
        }

        public async Task<GlobalTest> GetSingleTest(int id)
        {
            try
            {
                var selTest = await _context.GlobalTests.FirstOrDefaultAsync(t => t.Id.Equals(id))
                    ?? throw new InvalidOperationException("Test is undefined.");
                return selTest;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return new GlobalTest()
                {
                    Name = "Invalid test"
                };
            }
        }

        public async Task<UserEntity> GetSingleUser(int id)
        {
            try
            {
                var selTest = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id))
                    ?? throw new InvalidOperationException("User is undefined.");
                return selTest;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return new UserEntity()
                {
                    Username = "Invalid user"
                };
            }
        }

        public async Task<bool> UpdateModule(Module module)
        {
            try
            {
                var originalModule = await _context.Modules.FirstOrDefaultAsync(m => m.Id.Equals(module.Id))
                    ?? throw new InvalidOperationException("Module for update is not found");
                originalModule.Name = module.Name;
                originalModule.Photo = module.Photo;
                originalModule.Description = module.Description;
                originalModule.Colour = module.Colour;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
            
        }

        public async Task<bool> UpdateTest(GlobalTest test)
        {
            try
            {
                var originalTest = await _context.GlobalTests.FirstOrDefaultAsync(t => t.Id.Equals(test.Id))
                    ?? throw new InvalidOperationException("Test is not found");
                originalTest.Name = test.Name;
                originalTest.AreaTests = test.AreaTests;
                originalTest.FormTests = test.FormTests;
                originalTest.ImageTests = test.ImageTests;
                originalTest.MaxCost = test.MaxCost;
                await _context.SaveChangesAsync();
                return true;

            }
            catch(InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> UpdateUser(UserEntity user)
        {
            try
            {
                var originalUser = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(user.Id))
                    ?? throw new InvalidOperationException("User is not found");
                originalUser.FirstName = user.FirstName;
                originalUser.LastName = user.LastName;
                originalUser.Avatar = user.Avatar;
                originalUser.Admicies = user.Admicies;
                originalUser.Username = user.Username;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
    }
}
