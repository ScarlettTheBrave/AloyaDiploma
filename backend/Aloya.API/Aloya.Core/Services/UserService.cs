using Aloya.Core.Interfaces;
using Aloya.Core.Maps;
using Aloya.Domain.Auth;
using Aloya.Domain.Enums;
using Aloya.Domain.Validators;
using Aloya.Infrastructure.Data;
using Aloya.Transfer.Dtos;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Aloya.Core.Services
{
    public class UserService(IPasswordHasher passwordHasher, IJwtProvider jwtProvider, DataContext context) : IUserService
    {
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IJwtProvider _jwtProvider = jwtProvider;
        private readonly DataContext _context = context;

        private readonly PasswordValidator _passwordValidator = new PasswordValidator();
        private readonly EmailValidator _emailValidator = new EmailValidator();
        private readonly PhoneValidator _phoneValidator = new PhoneValidator();
        public async Task<bool> Register(string username, string email, string password)
        {
            try
            {
                bool a = PasswordValidate(password);
                bool b = EmailValidate(email);
                if (a && b)
                {
                    var hashedPassword = _passwordHasher.Generate(password);
                    var user = new UserEntity();
                    var passwordUser = new Password()
                    {
                        Value = hashedPassword,
                    };
                    var verifyUser = new Verify()
                    {
                        Email = email,
                    };
                    user.Username = username;
                    user.Password = passwordUser;
                    user.Verify = verifyUser;
                    user.Admicies.Add(new UserAdmicy()
                    {
                        role = Role.Student

                    }); ;
                    await _context.Passwords.AddAsync(passwordUser);
                    await _context.Verifys.AddAsync(verifyUser);
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public async Task<(string token, UserDTO userDTO)> Login(string email, string password)
        {
            try
            {
                var user = await _context.Users.Include(u => u.Password).Include(u => u.Verify).Include(u => u.Admicies).FirstOrDefaultAsync(u => u.Verify.Email!.Equals(email))
                    ?? throw new NullReferenceException();
                if (user.Password is null)
                    throw new NullReferenceException(nameof(user));
                string passwordHashed = user.Password.Value.ToString();
                var result = _passwordHasher.Verify(password, passwordHashed);
                if (result is false)
                    throw new ArgumentException("failed to login");

                var token = _jwtProvider.GenerateToken(user);
                return (token, UserMapper.MapToDTO(user));
            }
            catch (ArgumentException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return ("incorrect login",null);
            }
            catch (NullReferenceException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return ("email or password is incorrect!",null);
            }
        }

        public async Task<bool> Verify(int id, string phone)
        {
            try
            {
                var a = PhoneValidate(phone);
                if (a)
                {
                    var user = await _context.Users.Include(u => u.Verify).FirstOrDefaultAsync(u => u.Id.Equals(id))
                        ?? throw new ArgumentNullException();
                    var isAlready = _context.Verifys.Any(v => v.Phone == phone);
                    if (isAlready)
                        throw new ArgumentException("this phone is already verified");
                    if (user.Verify is null)
                        throw new NullReferenceException(nameof(user.Verify));
                    user.Verify.Phone = phone;
                    user.Verify.IsVerified = true;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
            catch(ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
            catch (ArgumentException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
            catch(NullReferenceException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> ChangeUser(int id, byte[] avatar, string username,string firstname,string lastname)
        {
            try
            {
                var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id)) 
                    ?? throw new NullReferenceException("That user is invalid");
                currentUser.Avatar = avatar;
                currentUser.Username = username;
                currentUser.FirstName = firstname;
                currentUser.LastName = lastname;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        private bool EmailValidate(string email)
        {
            try
            {
                var validationResult = _emailValidator.Validate(email);
                if (!validationResult.IsValid)
                    throw new Exception("Badly Email");
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }
        private bool PasswordValidate(string password) {
            try
            {
                var validationResult = _passwordValidator.Validate(password);
                if (!validationResult.IsValid)
                    throw new Exception("Badly Password");
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        private bool PhoneValidate(string phone)
        {
            try
            {
                var validationResult = _phoneValidator.Validate(phone);
                if (!validationResult.IsValid)
                    throw new Exception("Bad number");
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<bool> ChangePassword(int id, string password,string confirm)
        {
            try
            {
                var a = PasswordValidate(password);
                if (a)
                {
                    var user = await _context.Users.Include(u => u.Password).FirstOrDefaultAsync(u => u.Id.Equals(id))
                        ?? throw new NullReferenceException();
                    if (user.Password is null)
                        throw new NullReferenceException(nameof(user));
                    string passwordHashed = user.Password.Value.ToString();
                    var result = _passwordHasher.Verify(confirm, passwordHashed);
                    if (result is false)
                        throw new Exception();
                    user.Password.Value = _passwordHasher.Generate(password);
                    await _context.SaveChangesAsync();
                    return true;
                }
               else return false;
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }
    }
}
