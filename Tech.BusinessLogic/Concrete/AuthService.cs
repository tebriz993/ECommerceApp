using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech.BusinessLogic.Abstract;
using Tech.BusinessLogic.Dtos;
using Tech.Core.Extensions;
using Tech.Core.Security;
using Tech.DataAccess.Abstract.Account;
using Tech.Entity.Concrete.Accounts;

namespace Tech.BusinessLogic.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        public AuthService(IAuthRepository userRepository, IMapper mapper)
        {
            _authRepository = userRepository;
            _mapper = mapper;
        }

        public async Task CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);



            byte[] passwordHash, passwordSalt;

            HashHelper.CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash.ByteToString();
            user.PasswordSalt = passwordSalt.ByteToString();
            await _authRepository.AddAsync(user);
            await _authRepository.SaveChangesAsync();
        }
    }
}
