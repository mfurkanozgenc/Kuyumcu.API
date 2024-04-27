﻿using KuyumcuAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Application.Features.Queries.UserQueries.GetAllUserQuery
{
    public class GetAllUserQueryResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
    }
}
