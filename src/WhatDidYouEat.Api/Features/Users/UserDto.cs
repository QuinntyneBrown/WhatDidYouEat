using WhatDidYouEat.Core.Models;
using System;

namespace WhatDidYouEat.API.Features.Users
{
    public class UserDto
    {        
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }

    public static class UserExtensions
    {        
        public static UserDto ToDto(this User user)
            => new UserDto
            {
                UserId = user.UserId,
                
            };
    }
}
