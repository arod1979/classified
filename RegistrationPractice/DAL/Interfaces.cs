using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    namespace RegistrationPractice.DAL
    {
        public interface IRepository<T> where T : class
        {
            void Add(T entity);
            void Delete(T entity);
            void Delete(int id);
            void Update(T entity);

        }

        public interface fuck
        {
            void Add();
        }

        public class fuck2 : fuck
        {
            public void Add() { }
        }



        public class EFRepository<Item>
        {
            public void Add(Item item) { }
            public void Delete(Item item) { }
            public void Delete(int id) { }
            public void Update(Item item) { }
        }

        //public class Repository<T> where T : class
        //{


        //    public void Add(T entity)
        //    {
        //        throw new NotImplementedException();
        //    }


        //    public void Delete(int id) { }

        //    public void Delete(T entity)
        //    {
        //        throw new NotImplementedException();
        //    }



        //    public void Update(T entity)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    
}