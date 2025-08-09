using Eshop.Application.Service.Interfaces;
using Eshop.Data.DTOs.Account;
using Eshop.Data.Entities.Account;
using Eshop.Data.Repository;

namespace Eshop.Application.Service.Implementations;

public class UserService : IUserService
{
    #region CTOR

    private readonly IGenericRepository<User> _userRepository;

    public UserService(IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async ValueTask DisposeAsync()
    {
        await _userRepository.DisposeAsync();
    }

    #endregion

    #region Register Method

    public Task<RegisterOrLoginStatus> RegisterOrLoginUser(RegisterUserDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckUserExistsMobile(string mobile)
    {
        throw new NotImplementedException();
    }

    public Task<EditUserInfoDTO> GetEditUserInfo(long userId)
    {
        throw new NotImplementedException();
    }

    public Task EditUserDetails(EditUserInfoDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<UserDetailDTO> GetUserDetails(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SendActivationSms(string mobile)
    {
        throw new NotImplementedException();
    }

    #endregion
}