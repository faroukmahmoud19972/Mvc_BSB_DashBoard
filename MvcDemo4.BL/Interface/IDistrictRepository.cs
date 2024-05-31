using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MvcDemo4.DAL.Entity;

namespace MvcDemo4.BL.Interface
{
    public interface IDistrictRepository
    {
        IEnumerable<District> Get(Expression<Func<District, bool>> filter = null);

        District GetById(int id);
    }
}
