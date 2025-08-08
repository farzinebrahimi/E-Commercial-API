using System.ComponentModel.DataAnnotations;

namespace Eshop.Data.DTOs.Account;

public class LoginDTO
{
    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(11, ErrorMessage = "نمی تواند بیشتر از {۱} کاراکتر باشد {۰}")]
    [MinLength(11, ErrorMessage = "نمی تواند کمتر از {۱} کاراکتر باشد {۰}")]
    public string MobileNumber { get; set; }

    public string? ReturnUrl { get; set; }
}