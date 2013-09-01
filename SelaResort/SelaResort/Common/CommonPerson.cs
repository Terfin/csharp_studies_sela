using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public abstract class CommonPerson : IComparable
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
        public string Address { get; set; }
        public virtual List<CommonOrder> Orders { get; set; }

        public virtual int CompareTo(object obj)
        {
            int res = 0;
            var otherPerson = (CommonPerson)obj;
            if (FirstName != otherPerson.FirstName)
            {
                res--;
            }
            if (LastName != otherPerson.LastName)
            {
                res--;
            }
            if (BirthDate != otherPerson.BirthDate)
            {
                res--;
            }
            return res;
        }
    }
}
