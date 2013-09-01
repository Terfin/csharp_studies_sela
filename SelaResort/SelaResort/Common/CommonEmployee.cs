using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common
{
    public class CommonEmployee : CommonPerson, ICloneable
    {
        [Required]
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }
        [NotMapped]
        public string ConfirmEmail { get; set; }
        public string Remarks { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required]
        public virtual Positions Position { get; set; }

        public bool IsPasswordConfirmed()
        {
            return this.Password == this.ConfirmPassword;
        }

        public bool IsEmailConfirmed()
        {
            return this.Email == this.ConfirmEmail;
        }

        public override string ToString()
        {
            if (FirstName != null && LastName != null)
            {
                return FirstName + " " + LastName;
            }
            else
            {
                return Email;
            }
        }

        public override int CompareTo(object obj)
        {
            int res = 0;
            var otherEmp = (CommonEmployee)obj;
            if (Email != otherEmp.Email)
            {
                res--;
            }
            return res;
        }

        public object Clone()
        {
            return new CommonEmployee()
            {
                Address = this.Address,
                BirthDate = this.BirthDate,
                Email = this.Email,
                FirstName = this.FirstName,
                HireDate = this.HireDate,
                LastName = this.LastName,
                Orders = this.Orders,
                Password = this.Password,
                Position = this.Position,
                Remarks = this.Remarks
            };
        }

        public void Clear()
        {
            Address = null;
            BirthDate = default(DateTime);
            Email = null;
            FirstName = null;
            HireDate = default(DateTime);
            LastName = null;
            Orders = null;
            Password = null;
            Position = default(Positions);
            Remarks = null;
        }
    }
}
