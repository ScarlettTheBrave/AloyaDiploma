using Aloya.Domain.Tests;
using Aloya.Transfer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Core.Maps
{
    public class GlobalTestMapper
    {
        private static GlobalTestMapper? _instance = null;
        private static readonly object _locker = new object();
        protected GlobalTestMapper() { }

        public static GlobalTestMapper Instance
        {
            get
            {
                lock (_locker)
                {
                    if (_instance is null)
                    {
                        _instance = new GlobalTestMapper();
                    }
                }
                return _instance;
            }
        }
        public static GlobalTestDTO MapToDTO(GlobalTest entity)
            => new GlobalTestDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                MaxCost = entity.MaxCost
            };
        public static GlobalTest MapToEntity(GlobalTestDTO dto)
            => new GlobalTest
            {
                Id = dto.Id,
                Name = dto.Name,
                MaxCost = dto.MaxCost
            };
    }
}
