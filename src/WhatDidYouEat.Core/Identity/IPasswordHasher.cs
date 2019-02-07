using System;
using System.Collections.Generic;
using System.Text;

namespace WhatDidYouEat.Core.Identity
{
    public interface IPasswordHasher
    {
        string HashPassword(Byte[] salt, string password);
    }
}
