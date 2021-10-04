using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BasicAuthAPI.Models
{
    [Keyless]
    public class UserRole
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
