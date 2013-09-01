using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelaResort.DAL;
using Common;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace SelaResortBL
{
    public static class ResortFuncBase
    {
        private static DataLayer dal = DataLayer.Instance;
        public static void ValidateExists<T>(T entity) where T : class, IComparable
        {
            List<T> e = dal.ReadCollection<T>();
            var FoundEntity = e.Where(x => x.CompareTo(entity) == 0).SingleOrDefault();
            if (FoundEntity != null)
            {
                throw new ValidationException(entity.ToString() + " already exists");
            }
        }

        public static void ValidateEmail(CommonEmployee employee)
        {
            if (employee.Email != employee.ConfirmEmail)
            {
                ValidationException ex = new ValidationException("Email addresses do not match");
                ex.Data["Property"] = "Email";
                throw ex;
            }
        }

        public static void ValidatePassword(CommonEmployee employee)
        {
            if (employee.Password != employee.ConfirmPassword)
            {
                ValidationException ex = new ValidationException("Passwords do not match");
                ex.Data["Property"] = "Password";
                throw ex;
            }
        }
    }
}
