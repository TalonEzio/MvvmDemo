using MvvmDemo.Models;

namespace MvvmDemo.ViewModels
{
    public class PersonViewModel(Person person) : BindableObject
    {

        public string FirstName
        {
            get => person.FirstName;
            set => SetProperty(person.FirstName, value, person, (innerPerson, firstName) => innerPerson.FirstName = firstName);
        }
        public string LastName
        {
            get => person.LastName;
            set => SetProperty(person.LastName, value, person, (innerPerson, lastName) => innerPerson.FirstName = lastName);
        }

        private bool _checked;

        public bool Checked
        {
            get => _checked;
            set
            {
                var status = SetField(ref _checked, value);
                if (status)
                {
                    CheckHandler.Invoke(this, Checked);
                }
            }
        }
        public  required EventHandler<bool> CheckHandler { get; set; }
    }
}
