namespace Eshop.Application.Service.Interfaces;

public interface ISmsService
{
  Task SendVerificationSms(string mobile, string code);
}