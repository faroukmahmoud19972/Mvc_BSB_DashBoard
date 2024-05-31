using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcDemo4.DAL.Entity;

namespace MvcDemo4.BL.Interface
{
    public interface ICountryRepository
    {
        IEnumerable<Country> Get();

        Country GetById(int id);
    }
}
