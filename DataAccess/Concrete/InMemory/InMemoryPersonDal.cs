using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryPersonDal : IPersonDal
    {
        List<Person> _people;
        public InMemoryPersonDal()
        {
            //sanki oracle,sql ve vbden yani veritabanından veri geliyormuş gibi gösterdim böyle sıralayarak yani ban liste oluşturttu.


            _people = new List<Person> {
            new Person{PersonId=1, PersonName="merve", PersonSurname="aydin",PersonMail="merveaydin@gmail.com" ,PhoneNumber="05057778811"},
            new Person{PersonId=1, PersonName="kagan", PersonSurname="atis",PersonMail="kaganatis@gmail.com" ,PhoneNumber="05057778822"},
            new Person{PersonId=1, PersonName="seher", PersonSurname="eren",PersonMail="sehereren@gmail.com" ,PhoneNumber="05057778833"},
            new Person{PersonId=1, PersonName="simge", PersonSurname="kuru",PersonMail="simgekuru@gmail.com" ,PhoneNumber="05057778844"},
            new Person{PersonId=1, PersonName="zeynep", PersonSurname="hopa",PersonMail="zeynephopa@gmail.com" ,PhoneNumber="05057778855"}
            };
        }

        public void Add(Person person)
        {
            _people.Add(person);
        }

        public void Delete(Person person)
        {

            //remove ile silemem çünkü referans tipi ama int, string vs olsa silerdim

            Person? personToDelete = _people.SingleOrDefault(p => p.PersonId == person.PersonId);

            _people.Remove(personToDelete);
        }

        public List<Person> GetAll()
        {
            return _people;
        }

        public void Update(Person person)
        {
            //gönderdiğim kişi idsine sahip olan listedeki kişiyi bulsun demek
            Person personToUpdate = _people.SingleOrDefault(p => p.PersonId == person.PersonId);
            personToUpdate.PersonName = person.PersonName;
            personToUpdate.PersonSurname = person.PersonSurname;
            personToUpdate.PersonMail = person.PersonMail;
            personToUpdate.PhoneNumber = person.PhoneNumber;

         }
        
        public List<Person> GetAll(Expression<Func<Person, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }
        public Person Get(Expression<Func<Person,bool>>filter)
        {
            throw new NotImplementedException();
        }

        public List<PersonDetailDto> GetPersonDetails()
        {
            throw new NotImplementedException();
        }
    }
}
