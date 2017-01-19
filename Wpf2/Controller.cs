using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf2
{
    class Controller
    {
        private static Controller instance;
        private Repository repository;
        public Person CurrentPerson { get; private set; }
        public int PersonCount { get; private set; }
        public int PersonIndex { get; private set; }

        private Controller()
        {
            CurrentPerson = null;
            repository = new Repository();
            PersonCount = 0;
            PersonIndex = -1;
        }
        public static Controller GetInstance()
        {
            if (instance== null)
            {
                instance = new Controller();
            }
            return instance;
        }

        public void AddPerson()
        {
            Person person = new Person();
            CurrentPerson = person;
            repository.AddPerson(person);
            PersonCount = repository.PersonList.Count();
            PersonIndex = PersonCount-1;
        }

        public void DeletePerson()
        {
            if (CurrentPerson != null)
            {
                repository.RemovePerson(CurrentPerson);
                PersonIndex--;
                PersonCount = repository.PersonList.Count();
                CurrentPerson = repository.GetPersonAtIndex(PersonIndex);
            }
        }

        public void NextPerson()
        {
            if (PersonIndex < PersonCount - 1)
            {
                PersonIndex++;
                CurrentPerson = repository.GetPersonAtIndex(PersonIndex);
            }
        }
        public void PrevPerson()
        {
            if (PersonIndex > 0)
            {
                PersonIndex--;
                CurrentPerson = repository.GetPersonAtIndex(PersonIndex);
            }
        }


    }
}
