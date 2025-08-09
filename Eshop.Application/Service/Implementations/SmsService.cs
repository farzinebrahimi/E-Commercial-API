using Eshop.Application.Service.Interfaces;

namespace Eshop.Application.Service.Implementations;

public class SmsService : ISmsService
{
  private readonly string apiKey = Environment.GetEnvironmentVariable("API_KEY"); 

  public Task SendVerification(string mobile, string code)
  {
    
  }
}