using System.ComponentModel.DataAnnotations;

namespace Photon.DTOs;

public record UserLoginDto([Required] string Username, [Required] string Password);