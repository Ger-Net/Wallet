using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet22.MVVM.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public List<Operation>? Operations { get; set; }
        public List<User>? Friends { get; set; }
    }
}
