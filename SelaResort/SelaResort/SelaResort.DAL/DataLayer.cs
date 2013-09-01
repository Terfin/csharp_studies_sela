using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Data.Linq;

namespace SelaResort.DAL
{
    public class DataLayer
    {
        private static DataLayer _instance;
        private SelaResortContext context = new SelaResortContext();
        public static DataLayer Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataLayer();
                }
                return _instance;
            }
        }

        private DataLayer()
        {
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public List<T> ReadCollection<T>() where T : class, IComparable
        {
            using (SelaResortContext context = new SelaResortContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public void AddEntity<T>(T Entity) where T : class
        {
            using (SelaResortContext context = new SelaResortContext())
            {
                context.Entry(Entity).State = System.Data.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void AddCollection<T>(IEnumerable<T> EntitySet) where T : class
        {
            using (SelaResortContext context = new SelaResortContext())
            {
                foreach (var item in EntitySet)
                {
                    context.Set<T>().Add(item);
                }
            }
        }

        public void UpdateDB()
        {
            using (SelaResortContext context =new SelaResortContext())
            {
                context.SaveChanges();
            }
        }

        public void RemoveEntity<T>(T Entity) where T : class
        {
            using (SelaResortContext context = new SelaResortContext())
            {
                context.Set<T>().Remove(Entity);
            }
        }

        public void RemoveCollection<T>(IEnumerable<T> EntitySet) where T : class
        {
            using (SelaResortContext context = new SelaResortContext())
            {
                foreach (var item in EntitySet)
                {
                    context.Set<T>().Remove(item);
                }
            }
        }
    }
}
