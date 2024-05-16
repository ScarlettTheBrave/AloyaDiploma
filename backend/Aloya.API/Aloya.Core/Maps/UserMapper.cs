using Aloya.Domain.Auth;
using Aloya.Transfer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Core.Maps
{
    public class UserMapper
    {
        private static UserMapper? _instance = null;
        private static readonly object _locker = new object();
        protected UserMapper() { }

        public static UserMapper Instance
        {
            get
            {
                lock (_locker)
                {
                    if (_instance is null)
                    {
                        _instance = new UserMapper();
                    }
                }
                return _instance;
            }
        }
        public static UserDTO MapToDTO(UserEntity entity)
            => new UserDTO
            {
                Id = entity.Id,
                Username = entity.Username,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Admicies = entity.Admicies,
                Verify = entity.Verify,
                Photo = ByteConverter.GetString(entity.Avatar),
            };

        public static UserEntity MapToUser(UserDTO dto)
            => new UserEntity
            {
                Id = dto.Id,
                Username = dto.Username,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Admicies = dto.Admicies,
                Verify = dto.Verify
            };
    }
}
