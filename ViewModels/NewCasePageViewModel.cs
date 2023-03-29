using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using CaseManagementSystem.ViewModels;
using CaseManagementSystem.Data;
using CaseManagementSystem.Models;
using CaseManagementSystem.Views;

namespace CaseManagementSystem.ViewModels
{
    public class NewCasePageViewModel : ObservableObject
    {
        private readonly MainPageViewModel _mainPageViewModel;

        public NewCasePageViewModel(MainPageViewModel mainPageViewModel)
        {
            _mainPageViewModel = mainPageViewModel;
            CreateCaseCommand = new RelayCommand(CreateCase);
            GoToMainPageCommand = new RelayCommand(GoToMainPage);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }

        public ICommand CreateCaseCommand { get; }
        public ICommand GoToMainPageCommand { get; }

        private async void CreateCase()
        {
            try
            {
                await _mainPageViewModel.AddNewCase(FirstName, LastName, Email, PhoneNumber, Description);
                System.Diagnostics.Debug.WriteLine("Case created successfully");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating case: {ex}");
            }
        }

        private void GoToMainPage()
        {
            _mainPageViewModel.GoToMainPage();
        }
    }
}
