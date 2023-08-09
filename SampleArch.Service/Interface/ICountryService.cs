using SampleArch.Model;
using SampleArch.Model.Database.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleArch.Service.Interface
{
    public interface ICountryService : IEntityService<Country>
    {
        Country GetById(int id);
    }
}
