using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcDemo4.BL.Interface;
using MvcDemo4.DAL.Database;
using MvcDemo4.DAL.Entity;

namespace MvcDemo4.BL.Repository
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly DbContainer db;

        public TrainerRepository(DbContainer db)
        {
            this.db = db;
        }
        public IEnumerable<Trainer> GetTrainers()
        {
            var data = db.Trainer.Select(a => a);
            return data;
        }

        public Trainer GetTrainerById(int id)
        {
            var data = db.Trainer.Where(a => a.Id == id).FirstOrDefault();
            return data; ;
        }
        public void CreateTrainer(Trainer obj)
        {
           Trainer trainer = new Trainer(); 
            trainer.Name = obj.Name;
            trainer.Description = obj.Description;
            trainer.HireDate=obj.HireDate;
            trainer.Website = obj.Website;  
            trainer.Email = obj.Email;

            db.Add(trainer);
            db.SaveChanges();
        }
        public void DeleteTrainer(Trainer obj)
        {
            db.Entry(obj).State = EntityState.Deleted;

        }

        public void EditTrainer(Trainer obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

    }
}
