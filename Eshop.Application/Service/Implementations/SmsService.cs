using System.Net.Http.Json;
using Eshop.Application.Service.Interfaces;

namespace Eshop.Application.Service.Implementations;

public class SmsService : ISmsService
{
  private readonly string _apiKey = Environment.GetEnvironmentVariable("API_KEY"); 
  private readonly string _baseUrl = Environment.GetEnvironmentVariable("BASE_URL"); 
  private readonly string _sender = Environment.GetEnvironmentVariable("SENDER"); 
  private readonly string _otpPatternCode = Environment.GetEnvironmentVariable("OTPPATTERNCODE"); 
  private readonly IHttpClientFactory _httpClientFactory;

  public SmsService(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory;
  }

  public async Task SendVerificationSms(string mobile, string code)
  {
    var httpClient = _httpClientFactory.CreateClient("SmsService");
    var payload = new
    {
      code = _otpPatternCode,
      sender = _sender,
      recipient = mobile,
      Variable = new Dictionary<string, string>
      {
        { "verification-code", code }
      }
    };

    var response = await httpClient.PostAsJsonAsync(
      "/api/v1/sms/pattern/normal/send",
      payload
    );
    if (!response.IsSuccessStatusCode)
    {
      var error = await response.Content.ReadAsStringAsync();
      throw new HttpRequestException(
        $"ارسال پیامک ناموفق. وضعیت: {response.StatusCode}, خطا: {error}"
      );
    }
  }
}