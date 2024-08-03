using System.ComponentModel.DataAnnotations;

namespace Photon.DTOs.Request;

public record UserLoginDto([Required] string Username, [Required] string Password);