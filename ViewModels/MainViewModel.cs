using System.Collections.ObjectModel;
using MvvmDemo.Models;

namespace MvvmDemo.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _greeting = "Default greeting";

        public string Greeting
        {
            get => _greeting;
            set => SetField(ref _greeting, value);
        }

        public ObservableCollection<PersonViewModel> PersonViewModels { get; set; } = [];
        public override Task LoadAsync()
        {
            for (var i = 1; i <= 5; ++i)
            {
                var personViewModel = new PersonViewModel(
                    new Person()
                    {
                        FirstName = $"First {i}",
                        LastName = $"Last {i}",
                    })
                {
                    CheckHandler = (sender, check) =>
                    {
                        if (sender is not PersonViewModel viewModel) return;

                        Greeting =
                            $"Checkbox ({(check ? "Checked" : "UnChecked")}) for {viewModel.FirstName} {viewModel.LastName}";
                    }
                };

                PersonViewModels.Add(personViewModel);
            }
            return Task.CompletedTask;
        }

    }
}
