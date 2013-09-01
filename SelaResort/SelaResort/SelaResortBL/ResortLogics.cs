using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelaResort.DAL;
using Common;
using System.ComponentModel.DataAnnotations;

namespace SelaResortBL
{
    public class ResortLogics
    {
        DataLayer db = DataLayer.Instance;
        
        public delegate bool ValidFunc(CommonPerson person, out string ErrMsg);

        public void commitChanges()
        {
            db.Commit();
        }

        public void commitChanges(List<CommonPerson> people, Action<CommonPerson> operation)
        {
            people.ForEach(operation);   
        }

        public List<T> GetEntities<T>(Func<T, bool> func = null) where T : class, IComparable
        {
            if (func != null)
            {
                return db.ReadCollection<T>().Where(func).ToList();
            }
            return db.ReadCollection<T>();
        }

        public string AddEntity<T>(T entity, params Action<T>[] validateMethods) where T : class
        {
            var error = ValidateEntity(entity, validateMethods);
            if (error != null)
            {
                return error;
            }
            db.AddEntity(entity);
            return error;
        }

        public List<string> AddEntities<T>(List<T> Entities, params Action<T>[] validateMethods) where T : class
        {
            return Entities.Select(x => AddEntity(x, validateMethods)).ToList();
        }

        private string ValidateEntity<T>(T entity, Action<T>[] validations)
        {
            foreach (var method in validations)
            {
                try
                {
                    method(entity);
                }
                catch (ValidationException e)
                {
                    return e.Message;
                }
            }
            return null;
        }

        public string UpdateEntity<T>(T Entity, params Action<T>[] validateMethods) where T: class
        {
            string error = null;
            if (validateMethods != null && validateMethods.Length > 0)
            {
                error = ValidateEntity(Entity, validateMethods);
                if (error != null)
                {
                    return error;
                }
            }
            db.UpdateDB();
            return error;
        }
    }
}
