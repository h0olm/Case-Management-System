using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CaseManagementSystem.ViewModels;
using CaseManagementSystem.Data;
using CaseManagementSystem.Models;
using CaseManagementSystem.Views;

namespace CaseManagementSystem.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public RelayCommand GoToMainPageCommand { get; }
        public RelayCommand GoToNewCasePageCommand { get; }
        public RelayCommand GoToCaseDetailsPageCommand { get; }

        public MainPageViewModel MainPageViewModel { get; }

        public MainWindowViewModel()
        {
            MainPageViewModel = new MainPageViewModel(this);
            GoToMainPageCommand = new RelayCommand(GoToMainPage);
            GoToNewCasePageCommand = new RelayCommand(GoToNewCasePage);
            GoToCaseDetailsPageCommand = new RelayCommand(GoToCaseDetailsPage);
            GoToMainPage();
        }

        private void GoToMainPage()
        {
            MainPageViewModel.LoadCases();
            CurrentView = new MainPage(MainPageViewModel);
        }

        private void GoToNewCasePage()
        {
            CurrentView = new NewCasePage(new NewCasePageViewModel(MainPageViewModel));
        }

        public Case SelectedCase { get; set; }

        public void GoToCaseDetailsPage()
        {
            if (SelectedCase != null)
            {
                CurrentView = new CaseDetailsPage(new CaseDetailsPageViewModel(MainPageViewModel, SelectedCase));
            }
        }

    }
}
