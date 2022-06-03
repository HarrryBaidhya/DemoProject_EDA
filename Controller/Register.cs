using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IRegister
    {
        List<StaffModel> GetAllStaff();
        void Create(StaffModel staff);
        void SaveChanges();
        //void GetById(int id);


        
        void Update( StaffModel staff);
        object get(int id);
        bool Delete(int id);
        StaffModel GetStaffById(int id);
       
        // object Find(int id);
        // void Delete(int id);
        // bool ValidateUser(int id);

    }
    public class Register : IRegister
    {
        private readonly KtMPracticeContext Context;
        public Register(KtMPracticeContext context)
        {
            Context = context;
        }
        
        public void Create(StaffModel staff)
        {
            var Entity = new DAL.Context.Registtration
            {
                Email = staff.Email,
                FullName = staff.FullName,
                LastName = staff.LastName,
                Address = staff.Address,
            };

            Context.Registtrations.Add(Entity);
            Context.SaveChanges();

        }



        public List<StaffModel> GetAllStaff()
        {
            var Stafflist = Context.Registtrations.Select(n => new StaffModel
            {
                Id = n.Id,
                Email = n.Email,
                FullName = n.FullName,
                LastName = n.LastName,
                Address = n.Address


            }).ToList();
            
            return Stafflist;
        }

        public StaffModel GetStaffById(int id)
        {
            var Staff = Context.Registtrations.Where(a => a.Id == id).Select(n => new StaffModel
            {
                Id = n.Id,
                Email = n.Email,
                FullName = n.FullName,
                LastName = n.LastName,
                Address = n.Address


            }).FirstOrDefault();

            return Staff;
        }
        public void SaveChanges()
        {

        }

        public void Delete()
        {
        }
        





        public void Update( StaffModel staff)
            
            {
            //var Entity = new DAL.Context.Registtration
            //{
            //    Email = staff.Email,
            //    FullName = staff.FullName,
            //    LastName = staff.LastName,
            //    Password = staff.Password,
            //};
            var Entity = Context.Registtrations.Where(a => a.Id == staff.Id).FirstOrDefault();
            Entity.Email = staff.Email;
            Entity.FullName = staff.FullName;
            Entity.LastName = staff.LastName;
            Entity.Address = staff.Address;
            Context.Update(Entity);
            //Context.Entry(Entity).State = EntityState.Modified;
            Context.SaveChanges();

        }






        public object get(int id)
        {
            return(id);
        }

        public bool Delete(int id)
        {
            var Entity = Context.Registtrations.Where(e=> e.Id == id).FirstOrDefault();
            if (Entity != null)
            {

                Context.Entry(Entity).State = EntityState.Deleted;
                //Context.Registtrations.Remove(Entity);
                Context.SaveChanges();

                return true;
            }
            return false;
        }

       





        //public void Delete(int id)
        //{

        //    var result = Context.Registtrations.FirstOrDefault(d => d.Id == id); if(result != null)
        //    {
        //        Context.Registtrations.Remove(result);
        //        Context.SaveChanges();
        //    }


    }
       
    }

