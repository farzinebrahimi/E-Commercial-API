using System.ComponentModel.DataAnnotations;

namespace Eshop.Data.DTOs.Account;

public class MobileActivationDTO
{
    [Display(Name = "Activation Code")]
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(5, ErrorMessage = "نمی تواند بیشتر از {۱} کاراکتر باشد {۰}")]
    [MinLength(5, ErrorMessage = "نمی تواند کمتر از {۱} کاراکتر باشد {۰}")]
    public string ActivationCode { get; set; }
    
    public string? ReturnUrl { get; set; }
}