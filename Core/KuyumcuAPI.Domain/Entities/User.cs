using KuyumcuAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Domain.Entities
{
    public class User : PersonEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public string ApiKey { get; set; }
        public ICollection<CashTransaction> CashTransactions { get; set; }
    }
    public enum Role
    {
        Admin,
        Employee
    }
}
