using Eshop.Application.Service.Interfaces;
using Eshop.Data.DTOs.Account;
using Eshop.Data.Entities.Account;
using Eshop.Data.Repository;
using Microsoft.EntityFrameworkCore;

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

  public async Task<RegisterOrLoginStatus> RegisterOrLoginUser(RegisterUserDTO dto)
  {
    var checkUser = await CheckUserExistsMobile(dto.MobileNumber);
    if (checkUser)
    {
      var user = await _userRepository.GetQuery().FirstAsync(u => u.MobileNumber == dto.MobileNumber);
      user.MobileActivationNumber = new Random().Next(10000, 99999).ToString();
      _userRepository.UpdateEntity(user);

      await _userRepository.SaveChangesAsync();
      return RegisterOrLoginStatus.RedirectToSendActivationNumber;
    }

    var newUser = new User
    {
      MobileNumber = dto.MobileNumber,
      MobileActivationNumber = new Random().Next(10000, 99999).ToString()
    };
    await _userRepository.AddEntity(newUser);
    await _userRepository.SaveChangesAsync();
    return RegisterOrLoginStatus.Susccess;
  }

  public async Task<bool> CheckUserExistsMobile(string mobile)
  {
    return await _userRepository.GetQuery().AnyAsync(u => u.MobileNumber == mobile);
  }

  public async Task<EditUserInfoDTO> GetEditUserInfo(long userId)
  {
    throw new NotImplementedException();
  }

  public async Task EditUserDetails(EditUserInfoDTO dto)
  {
    throw new NotImplementedException();
  }

  public async Task<UserDetailDTO> GetUserDetails(long userId)
  {
    throw new NotImplementedException();
  }

  public async Task<bool> SendActivationSms(string mobile)
  {
    throw new NotImplementedException();
  }

  #endregion
}