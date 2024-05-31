using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MvcDemo4.DAL.Entity;

namespace MvcDemo4.BL.Interface
{
    public interface ICityRepository
    {
        IEnumerable<City> Get(Expression<Func<City,bool>>filter =null);

        City GetById(int id);
    }
}
