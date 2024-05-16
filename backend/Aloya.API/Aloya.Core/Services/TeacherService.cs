using Aloya.Contract.Dtos;
using Aloya.Core.Interfaces;
using Aloya.Core.Maps;
using Aloya.Domain.Module;
using Aloya.Domain.Tests;
using Aloya.Domain.Tests.Answers;
using Aloya.Domain.Tests.Tasks;
using Aloya.Domain.Theory;
using Aloya.Infrastructure.Data;
using Aloya.Transfer.Dtos;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Core.Services
{
   public class TeacherService(DataContext context) : ITeacherService 
    {
        private readonly DataContext _context = context;
        public async Task<bool> CreateModule(string name, string description, string colour, string? photo)
        {
            try
            {

                var module = new Module()
                {
                    Name = name,
                    Description = description,
                    Colour = colour,
                    Photo = ByteConverter.GetBytes(photo)
                };
                
                ArgumentNullException.ThrowIfNull(module);
                await _context.AddAsync(module);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
        }
        public async Task<bool> DeleteModule(int id)
        {
            try
            {
                var selMod = await _context.Modules.FirstOrDefaultAsync(m => m.Id.Equals(id))
                    ?? throw new InvalidOperationException("Module not found");
                _context.Remove(selMod);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> UpdateModule(Module module)
        {
            try
            {
                var selMod = await _context.Modules.FirstOrDefaultAsync(m => m.Id.Equals(module.Id))
                    ?? throw new InvalidOperationException("Module for update not found.");
                selMod.Colour = module.Colour;
                selMod.Description = module.Description;
                selMod.Name = module.Name;
                selMod.Photo = module.Photo;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> CreateLection(LectionDto lectionDto)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(() => lectionDto);

                var lection = new Lection()
                {
                    ModuleId = lectionDto.ModuleId,
                    Name = lectionDto.Name,
                    Description = lectionDto.Description,
                    Text = lectionDto.Text,
                    Illustrations = lectionDto.Illustrations.Select(illustrationDto => new Illustration()
                    {
                        Photo = ByteConverter.GetBytes(illustrationDto.PhotoBase64),
                        LectionId = illustrationDto.LectionId,
                        Name = illustrationDto.Name

                    }).ToList(),
                    Links = lectionDto.Links
                };
                await _context.Lections.AddAsync(lection);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                    return false;
            }
        }
        public async Task<bool> DeleteLection(int id)
        {
            try
            {
                var selLection = await _context.Lections.FirstOrDefaultAsync(l => l.Id.Equals(id))
                    ?? throw new InvalidOperationException("Lection not found.");
                _context.Lections.Remove(selLection);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> UpdateLection(Lection lection)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(lection);
                var selLection = await _context.Lections.FirstOrDefaultAsync(l => l.Id.Equals(lection.Id))
                    ?? throw new InvalidOperationException();
                selLection.Description = lection.Description;
                selLection.Text = lection.Text;
                selLection.ModuleId = lection.ModuleId;
                selLection.Name = lection.Name;
                selLection.Illustrations = selLection.Illustrations;
                selLection.Links = selLection.Links;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
            catch(InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> CreateLink(Link link)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(link);
                await _context.Links.AddAsync(link);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> DeleteLink(int id)
        {
            try
            {
                var selLink = await _context.Links.FirstOrDefaultAsync(l => l.Id.Equals(id))
                    ?? throw new InvalidOperationException();
                _context.Remove(selLink);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> UpdateLink(Link link)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(link);
                var selLink = await _context.Links.FirstOrDefaultAsync(l => l.Id.Equals(link.Id))
                    ?? throw new InvalidOperationException();
                selLink.LectionId = link.LectionId;
                selLink.Name = link.Name;
                selLink.Type = link.Type;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> CreateIllustration(Illustration image)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(image);
                await _context.Illustrations.AddAsync(image);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> DeleteIllustration(int id)
        {
            try
            {
                var selImage = await _context.Illustrations.FirstOrDefaultAsync(l => l.Id.Equals(id))
                    ?? throw new InvalidOperationException();
                _context.Remove(selImage);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> UpdateIllustration(Illustration image)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(image);
                var selImage = await _context.Illustrations.FirstOrDefaultAsync(l => l.Id.Equals(image.Id))
                      ?? throw new InvalidOperationException();
                selImage.Name = image.Name;
                selImage.Photo = image.Photo;
                selImage.LectionId = image.LectionId;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> CreateImageTask(ImageTask task)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(task);
                await _context.AddAsync(task);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(ArgumentException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> DeleteImageTask(int id)
        {
            try
            {
                var selTask = await _context.ImageTasks.FirstOrDefaultAsync(t => t.Id.Equals(id))
                    ?? throw new InvalidOperationException();
                _context.Remove(selTask);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> UpdateImageTask(ImageTask task)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(task);
                var selTask = await _context.ImageTasks.FirstOrDefaultAsync(t => t.Id.Equals(task.Id))
                    ?? throw new InvalidOperationException();
                selTask.Question = task.Question;
                selTask.TestId = task.TestId;
                selTask.Cost = task.Cost;
                selTask.TestId = task.TestId;
                selTask.Images = task.Images;
                selTask.Name = task.Name;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> CreateFormTask(FormTask task)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(task);
                await _context.AddAsync(task);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> DeleteFormTask(int id)
        {
            try
            {
                var selTask = await _context.FormTasks.FirstOrDefaultAsync(t => t.Id.Equals(id))
                    ?? throw new InvalidOperationException();
                _context.Remove(selTask);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> UpdateFormTask(FormTask task)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(task);
                var selTask = await _context.FormTasks.FirstOrDefaultAsync(t => t.Id.Equals(task.Id))
                    ?? throw new InvalidOperationException();
                selTask.Question = task.Question;
                selTask.Cost = task.Cost;
                selTask.Answers = task.Answers;
                selTask.Name = task.Name;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> CreateAreaTask(AreaTask task)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(task);
                await _context.AddAsync(task);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> DeleteAreaTask(int id)
        {
            try
            {
                var selTask = await _context.AreaTasks.FirstOrDefaultAsync(t => t.Id.Equals(id))
                    ?? throw new InvalidOperationException();
                _context.Remove(selTask);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> UpdateAreaTask(AreaTask task)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(task);
                var selTask = await _context.AreaTasks.FirstOrDefaultAsync(t => t.Id.Equals(task.Id))
                    ?? throw new InvalidOperationException();
                selTask.Question = task.Question;
                selTask.TestId = task.TestId;
                selTask.Cost = task.Cost;
                selTask.TestId = task.TestId;
                selTask.AreaAnswers = task.AreaAnswers;
                selTask.Name = task.Name;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> CreateFormAnswer(FormAnswer answer)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(answer);
                await _context.AddAsync(answer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> DeleteFormAnswer(int id)
        {
            try
            {
                var selAnswer = await _context.FormAnswers.FirstOrDefaultAsync(a => a.Id.Equals(id))
                    ?? throw new InvalidOperationException("Answer not found");
                _context.Remove(selAnswer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> UpdateFormAnswer(FormAnswer answer)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(answer);
                var selAnswer = await _context.FormAnswers.FirstOrDefaultAsync(a => a.Id.Equals(answer.Id)) 
                    ?? throw new InvalidOperationException();
                selAnswer.IsRight = answer.IsRight;
                selAnswer.FormTaskId = answer.FormTaskId;
                selAnswer.Text = answer.Text;
                await _context.SaveChangesAsync();
                return true;

            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> CreateAreaAnswer(AreaAnswer answer)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(answer);
                await _context.AddAsync(answer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> DeleteAreaAnswer(int id)
        {
            try
            {
                var selAnswer = await _context.AreaAnswers.FirstOrDefaultAsync(a => a.Id.Equals(id))
                    ?? throw new InvalidOperationException("Answer not found");
                _context.Remove(selAnswer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> UpdateAreaAnswer(AreaAnswer answer)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(answer);
                var selAnswer = await _context.AreaAnswers.FirstOrDefaultAsync(a => a.Id.Equals(answer.Id))
                    ?? throw new InvalidOperationException();
                selAnswer.IsRight = answer.IsRight;
                selAnswer.AreaTaskId = answer.AreaTaskId;
                selAnswer.X = answer.X;
                selAnswer.Y = answer.Y;
                selAnswer.Radius = answer.Radius;
                selAnswer.IsRight = answer.IsRight;
                await _context.SaveChangesAsync();
                return true;

            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> CreateImageAnswer(ImageAnswer answer)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(answer);
                await _context.AddAsync(answer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> DeleteImageAnswer(int id)
        {
            try
            {
                var selAnswer = await _context.ImageAnswers.FirstOrDefaultAsync(a => a.Id.Equals(id))
                    ?? throw new InvalidOperationException("Answer not found");
                _context.Remove(selAnswer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> UpdateImageAnswer(ImageAnswer answer)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(answer);
                var selAnswer = await _context.ImageAnswers.FirstOrDefaultAsync(a => a.Id.Equals(answer.Id))
                    ?? throw new InvalidOperationException();
                selAnswer.isRight = answer.isRight;
                selAnswer.ImageTaskId = answer.ImageTaskId;
                selAnswer.Photo = answer.Photo;
                await _context.SaveChangesAsync();
                return true;

            }
            catch (ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }

        public async Task<bool> CreateTest(GlobalTestDTO test)
        {
            try
            {

                ArgumentNullException.ThrowIfNull(test);
                var issueTest = DTOConverter.ToGlobalTest(test);
                await _context.AddAsync(issueTest);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(ArgumentNullException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
        public async Task<bool> DeleteTest(int id)
        {
            try
            {
                var test = await _context.GlobalTests.FirstOrDefaultAsync(t => t.Id.Equals(id))
                    ?? throw new InvalidOperationException("Test not found");
                _context.Remove(test);
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
                var selTest = await _context.GlobalTests.FirstOrDefaultAsync(t => t.Id.Equals(test.Id))
                    ?? throw new InvalidOperationException("Test not found");
                selTest.Name = test.Name;
                selTest.AreaTests = test.AreaTests;
                selTest.FormTests = test.FormTests;
                selTest.ImageTests = test.ImageTests;
                selTest.ModuleId = test.ModuleId;
                selTest.MaxCost = test.MaxCost;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
        }
    }
}
