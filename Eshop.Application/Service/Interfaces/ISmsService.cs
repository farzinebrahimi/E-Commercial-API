namespace Eshop.Application.Service.Interfaces;

public interface ISmsService
{
  Task SendVerification(string mobile, string code);
}