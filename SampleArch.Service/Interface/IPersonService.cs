using SampleArch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleArch.Service.Interface
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetById(long Id);
    }
}
