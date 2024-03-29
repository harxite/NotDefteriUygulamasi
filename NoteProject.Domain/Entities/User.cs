﻿using NoteProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public UserType UserType { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
