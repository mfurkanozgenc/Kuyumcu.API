﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Domain.Common
{
    public class PersonEntity:EntityBase
    {
        public string FullName { get { return FirstName +" "+ LastName; } }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IdentificationNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public Gender? Gender { get; set; }
    }
    public enum Gender
    {
        men,
        women
    }
}
