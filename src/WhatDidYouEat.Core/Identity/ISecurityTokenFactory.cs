using System;
using System.Collections.Generic;
using System.Text;

namespace WhatDidYouEat.Core.Identity
{
    public interface ISecurityTokenFactory
    {
        string Create(Guid userId, string uniqueName);
    }
}
