using System.ComponentModel.DataAnnotations;

namespace Eshop.Data.DTOs.Account;

public class EditUserInfoDTO
{   
    [Display(Name = "نام و نام  خانوادگی")]
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(5, ErrorMessage = "نمی تواند بیشتر از {۱} کاراکتر باشد {۰}")]
    public string? FullName { get; set; }
    
    [Display(Name = "ایمیل")]
    [MaxLength(5, ErrorMessage = "نمی تواند بیشتر از {۱} کاراکتر باشد {۰}")]
    public string? Email { get; set; }
    
    [Display(Name = "آدرس")]
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(5, ErrorMessage = "نمی تواند بیشتر از {۱} کاراکتر باشد {۰}")]
    public string? Address { get; set; }
    [Display(Name = "کدپستی")]
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(10, ErrorMessage = "نمی تواند بیشتر از {۱} کاراکتر باشد {۰}")]
    [MinLength(10, ErrorMessage = "نمی تواند کمتر از {۱} کاراکتر باشد {۰}")]
    public string? PostCode { get; set; }
}