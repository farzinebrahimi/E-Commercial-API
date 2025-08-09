using Eshop.Data.DTOs.Account;

namespace Eshop.Application.Service.Interfaces;

public interface IUserService : IAsyncDisposable
{
    #region Register & Login

    Task RegisterOrLoginUser(RegisterUserDTO dto);
    Task<bool> CheckUserExistsMobile(string mobile);
    Task<EditUserInfoDTO> GetEditUserInfo(long userId);
    
    Task EditUserDetails(EditUserInfoDTO dto);
    Task<UserDetailDTO> GetUserDetails(long userId);
    Task<bool> SendActivationSms(string mobile);
    #endregion
}