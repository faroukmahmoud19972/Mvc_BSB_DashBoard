
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcDemo4.DAL.Entity;

namespace MvcDemo4.BL.Interface
{
    public interface ITrainerRepository
    {
        IEnumerable<Trainer>GetTrainers();
        Trainer GetTrainerById(int id);

        void CreateTrainer(Trainer obj);

        void EditTrainer(Trainer obj);
        void DeleteTrainer(Trainer obj);

    }
}
