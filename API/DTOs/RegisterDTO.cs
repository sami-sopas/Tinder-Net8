using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDTO
{
    [Required]
    [MaxLength(100)] //Validaicones
    public required string Username { get; set; }

    [Required]
    [StringLength(16, MinimumLength = 10)] 
    public required string Password { get; set; }


}
