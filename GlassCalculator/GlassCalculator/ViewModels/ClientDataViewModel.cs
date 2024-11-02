using GlassCalculator.Models;
using System.ComponentModel;

namespace GlassCalculator.ViewModels
{
    public class ClientDataViewModel : INotifyPropertyChanged
    {
        private ClientData _clientData;

        public ClientDataViewModel()
        {
            _clientData = new ClientData();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Command SubmitCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
