using Aloya.Contract.Dtos;
using Aloya.Domain.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Core.Maps
{
    public class ModuleMapper
    {
        private static ModuleMapper? _instance = null;
        private static readonly object _locker = new object();
        protected ModuleMapper() { }

        public static ModuleMapper Instance
        {
            get
            {
                lock (_locker)
                {
                    if (_instance is null)
                    {
                        _instance = new ModuleMapper();
                    }
                }
                return _instance;
            }
        }
        public static ModuleDTO MapToDTO(Module entity)
            => new ModuleDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Colour = entity.Colour,
                Image = ByteConverter.GetString(entity.Photo)
            };
        public static Module MapToEntity(ModuleDTO dto)
            => new Module
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                
            };
    }
}
