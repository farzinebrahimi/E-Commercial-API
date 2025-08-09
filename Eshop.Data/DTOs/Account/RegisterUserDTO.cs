using System.ComponentModel.DataAnnotations;

namespace Eshop.Data.DTOs.Account;

public class RegisterUserDTO
{
    [Display(Name = "Mobile Number")]
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(11, ErrorMessage = "Max length 11")]
    [MinLength(11, ErrorMessage = "نمی تواند کمتر از {۱} کاراکتر باشد {۰}")]
    public string MobileNumber { get; set; }
    
    public string? ReturnUrl { get; set; }
}

public enum RegisterOrLoginStatus
{
    Susccess,
    MobileInUse
}