﻿namespace FunL_backend.Dtos.NewFolder
{
    public class RegisterUserDto
    {
        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string ConfirmPassword { get; set;}
    }
}
