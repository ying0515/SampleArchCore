﻿using SampleArch.Model;
using SampleArch.Model.Database.POCO;
using SampleArch.Repository.Interface;
using SampleArch.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleArch.Service
{
    public class PersonService : EntityService<Person>, IPersonService
    {
        IUnitOfWork _unitOfWork;
        IPersonRepository _personRepository;

        public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository)
            : base(unitOfWork, personRepository)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
        }


        public Person GetById(long Id)
        {
            return _personRepository.GetById(Id);
        }
    }
}
