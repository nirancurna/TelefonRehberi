using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        IPersonDal _personDal;
        

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
           
        }
        
        [ValidationAspect(typeof(PersonValidator))]
        public IResult Add(Person person)
        {
           IResult result = BusinessRules.Run(CheckIfPersonNameExists(person.PersonName,person.PersonSurname),
                CheckIfPhoneNumberExists(person.PhoneNumber));

            if(result!=null)
            { 
                return result; 
            }
                
             _personDal.Add(person);
              return new SuccessResult(Messages.PersonAdded);
                
           
            
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult <List<Person>> GetAll()
        {
            if (DateTime.Now.Hour == 10)
                 {
                return new ErrorDataResult<List<Person>>(Messages.MaintenanceTime);
        }

            return new SuccessDataResult<List<Person>>(_personDal.GetAll(),Messages.PeopleListed);
            
        }

        public IDataResult<List<Person>> GetAllByPersonId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Person> GetById(int personId)
        {
            return new SuccessDataResult<Person>(_personDal.Get(p => p.PersonId == personId));
        }

        public  IDataResult<List<PersonDetailDto>> GetPersonDetails()
        {
            return new SuccessDataResult<List<PersonDetailDto>>(_personDal.GetPersonDetails());
        }
        [ValidationAspect(typeof(PersonValidator))]
        public IResult Update(Person person)
        {
            throw new NotImplementedException();
        }
        private IResult CheckIfPhoneNumberExists(string phoneNumber)
        {
            var result = _personDal.GetAll(p => p.PhoneNumber == phoneNumber).Any();
            if (result)
            {
                return new ErrorResult(Messages.PhoneNumberAlreadyExists);
            }
            return new SuccessResult();

        }
        private IResult CheckIfPersonNameExists(string personName,string personSurname)
        {
            var result = _personDal.GetAll(p => p.PersonName == personName && p.PersonSurname == personSurname).Any();
            if (result)
            {
                return new ErrorResult(Messages.PersonNameAlreadyExists);
            }
            return new SuccessResult();
        }
        
    }
}
