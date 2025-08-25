using System.ComponentModel.DataAnnotations;

namespace WebStoreApi.Models
{
    public class UserDto
    {
        [Required, Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Required, EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Address must be at least 8 characters long")]
        [MaxLength(16, ErrorMessage = "Address must be at most 100 characters long")]
        public string? Address { get; set; }
    }
}
