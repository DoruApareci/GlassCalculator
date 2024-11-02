using GlassCalculator.Models;
using GlassCalculator.ViewModels;
using System.ComponentModel;

namespace GlassCalculator.Views.Pages;

public partial class ClientDataPage : ContentPage
{
    public ClientDataViewModel ViewModel { get; }

    public ClientDataPage()
    {
        InitializeComponent();
        ViewModel = (ClientDataViewModel)BindingContext;
        ViewModel.SubmitCommand = new Command(OnSubmitClicked);
    }

    private void OnSubmitClicked()
    {
        var clientData = new ClientData
        {
            FirstName = ViewModel.FirstName,
            LastName = ViewModel.LastName,
            Phone = ViewModel.Phone,
            Email = ViewModel.Email
        };

        DisplayAlert("Client Data", $"Name: {clientData.FirstName} {clientData.LastName}\nPhone: {clientData.Phone}\nEmail: {clientData.Email}", "OK");
    }
}