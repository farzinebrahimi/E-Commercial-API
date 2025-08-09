using Eshop.Application.Service.Interfaces;
using Eshop.Data.DTOs.Account;
using Eshop.Data.Entities.Account;
using Eshop.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Application.Service.Implementations
{
  public class UserService : IUserService
  {
    #region CTOR

    private readonly IGenericRepository<User> _userRepository;
    private readonly ISmsService _smsService;

    public UserService(IGenericRepository<User> userRepository, ISmsService smsService)
    {
      _userRepository = userRepository;
      _smsService = smsService;
    }

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

    public async Task RegisterOrLoginUser(RegisterUserDTO dto)
    {
      var checkUser = await CheckUserExistsMobile(dto.MobileNumber);
      //Login user
      if (checkUser)
      {
        var user = await _userRepository.GetQuery().FirstAsync(u => u.MobileNumber == dto.MobileNumber);
        user.MobileActivationNumber = new Random().Next(10000, 99999).ToString();
        _userRepository.UpdateEntity(user);
        await _userRepository.SaveChangesAsync();
        await _smsService.SendVerificationSms(dto.MobileNumber, user.MobileActivationNumber);
      }

      //register new user
      var newUser = new User
      {
        MobileNumber = dto.MobileNumber,
        MobileActivationNumber = new Random().Next(10000, 99999).ToString()
      };
      await _userRepository.AddEntity(newUser);
      await _userRepository.SaveChangesAsync();
      await _smsService.SendVerificationSms(dto.MobileNumber, newUser.MobileActivationNumber);
    }

    public async Task<bool> CheckUserExistsMobile(string mobile)
    {
      return await _userRepository.GetQuery().AnyAsync(u => u.MobileNumber == mobile);
    }

    public async Task<EditUserInfoDTO> GetEditUserInfo(long userId)
    {
      var user = await _userRepository.GetByIdAsync(userId);
      return new EditUserInfoDTO
      {
        Address = user.Address,
        Email = user.Email,
        FullName = user.FullName,
        PostCode = user.PostCode,
      };
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
      var user = await _userRepository.GetQuery().FirstOrDefaultAsync(u => u.MobileNumber == mobile);
      if (user == null) return false;
      
      user.MobileActivationNumber = new Random().Next(10000, 99999).ToString();
      await _smsService.SendVerificationSms(mobile, user.MobileActivationNumber);

      return true;
    }

    #endregion
  }
}