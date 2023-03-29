using CaseManagementSystem.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseManagementSystem.ViewModels;
using CaseManagementSystem.Data;
using CaseManagementSystem.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using static CaseManagementSystem.Models.Case;

namespace CaseManagementSystem.ViewModels
{
    public class MainPageViewModel : ObservableObject, IDisposable
    {

        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly AppDbContext _dbContext;

        public RelayCommand GoToNewCasePageCommand { get; }

        private ObservableCollection<Case> _cases;
        public ObservableCollection<Case> Cases
        {
            get { return _cases; }
            set { SetProperty(ref _cases, value); }
        }

       

        public MainWindowViewModel MainWindowViewModel
        {
            get { return _mainWindowViewModel; }
        }

        private Case _selectedCase;
        public Case SelectedCase
        {
            get { return _selectedCase; }
            set
            {
                SetProperty(ref _selectedCase, value);
                if (value != null)
                {
                    _mainWindowViewModel.SelectedCase = value;
                    _mainWindowViewModel.GoToCaseDetailsPage();
                }
            }
        }

        public RelayCommand<object> RemoveCaseCommand { get; }

        public RelayCommand<object> UpdateCaseStatusCommand { get; }
        public ICommand ChangeStatusCommand { get; }

        public MainPageViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _dbContext = new AppDbContext();

            GoToNewCasePageCommand = new RelayCommand(() =>
            {
                _mainWindowViewModel.GoToNewCasePageCommand.Execute(null);
            });

            ChangeStatusCommand = new RelayCommand(async () => await ChangeCaseStatus(SelectedCase.CaseId, "In Progress"));
            RemoveCaseCommand = new RelayCommand<object>(async param => await RemoveCase(param));
            UpdateCaseStatusCommand = new RelayCommand<object>(async param => await UpdateCaseStatus(param));


            LoadCases();

        }

        public void LoadCases()
        {
            var cases = _dbContext.Cases.ToList();
            Cases = new ObservableCollection<Case>(cases);
        }

        public async Task AddNewCase(string firstName, string lastName, string email, string phoneNumber, string description)
        {
            Case newCase = new Case
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Description = description,
                CreatedAt = DateTime.Now,
                Status = "Not Started"
            };

            _dbContext.Cases.Add(newCase);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddComment(int caseId, string content)
        {
            CaseComment comment = new CaseComment
            {
                CaseId = caseId,
                Content = content,
                CreatedAt = DateTime.Now
            };

            _dbContext.CaseComments.Add(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ChangeCaseStatus(int caseId, string newStatus)
        {
            Case caseToUpdate = await _dbContext.Cases.FindAsync(caseId);
            if (caseToUpdate != null)
            {
                caseToUpdate.Status = newStatus;
                _dbContext.Cases.Update(caseToUpdate);
                await _dbContext.SaveChangesAsync();
            }
            LoadCases();
        }

        public void GoToMainPage()
        {
            _mainWindowViewModel.GoToMainPageCommand.Execute(null);
        }


        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public List<CaseStatus> AvailableStatuses { get; } = Enum.GetValues(typeof(CaseStatus)).Cast<CaseStatus>().ToList();


        public async Task RemoveCase(object caseToRemove)
        {
            if (caseToRemove is Case caseInstance)
            {
                _dbContext.Cases.Remove(caseInstance);
                await _dbContext.SaveChangesAsync();
                LoadCases();
            }
        }

        public async Task UpdateCaseStatus(object selectedCase)
        {
            if (selectedCase is Case caseToUpdate)
            {
                _dbContext.Update(caseToUpdate);
                await _dbContext.SaveChangesAsync();
                LoadCases();
            }
        }
        public async Task UpdateCaseStatus(Case selectedCase)
        {
            using var dbContext = new AppDbContext();
            dbContext.Cases.Update(selectedCase);
            await dbContext.SaveChangesAsync();
        }


        public List<string> StatusList { get; } = new List<string> { "Open", "In Progress", "Closed" };

    }
}
