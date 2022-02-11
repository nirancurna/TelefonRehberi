﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonTest(); static void PersonTest()
            {
               PersonManager personManager = new PersonManager(new EfPersonDal());

                var result = personManager.GetPersonDetails();
                if (result.Success == true)
                {
                    foreach (var person in result.Data)
                    {
                        Console.WriteLine(person.PersonName + "/" + person.PersonSurname);
                    }
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }

        }
    }
}

