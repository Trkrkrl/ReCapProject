using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOS
{
    public class ChangePasswordDto : IDto
    {
        public string Email { get; set; }
        public string OldPassWord { get; set; }
        public string NewPassword { get; set; }
    }
}
