using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CaseManagementSystem.Data;
using CaseManagementSystem.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System.Linq;

namespace CaseManagementSystem.ViewModels
{
    public class CaseDetailsPageViewModel : ObservableObject
    {
        private readonly MainPageViewModel _mainPageViewModel;
        private readonly AppDbContext _dbContext;

        public RelayCommand GoToMainPageCommand { get; }
        public RelayCommand AddCommentCommand { get; }

        private Case _selectedCase;
        public Case SelectedCase
        {
            get { return _selectedCase; }
            set { SetProperty(ref _selectedCase, value); }
        }

        private ObservableCollection<CaseComment> _caseComments;
        public ObservableCollection<CaseComment> CaseComments
        {
            get { return _caseComments; }
            set { SetProperty(ref _caseComments, value); }
        }

        private string _commentText;
        public string CommentText
        {
            get { return _commentText; }
            set { SetProperty(ref _commentText, value); }
        }

        public CaseDetailsPageViewModel(MainPageViewModel mainPageViewModel, Case selectedCase)
        {
            _mainPageViewModel = mainPageViewModel;
            _dbContext = new AppDbContext();
            SelectedCase = selectedCase;
            GoToMainPageCommand = new RelayCommand(() => _mainPageViewModel.GoToMainPage());
            AddCommentCommand = new RelayCommand(async () => await AddComment());
            LoadCommentsForSelectedCase();
        }

        private async void LoadComments()
        {
            var comments = await _dbContext.CaseComments.ToListAsync();
            CaseComments = new ObservableCollection<CaseComment>(comments);
        }

        public async Task AddComment()
        {
            CaseComment comment = new CaseComment
            {
                CaseId = SelectedCase.CaseId,
                Content = CommentText,
                CreatedAt = DateTime.Now
            };

            _dbContext.CaseComments.Add(comment);
            await _dbContext.SaveChangesAsync();
            LoadCommentsForSelectedCase();
            CommentText = string.Empty;
        }

        private async void LoadCommentsForSelectedCase()
        {
            var caseComments = await _dbContext.CaseComments
                .Where(c => c.CaseId == SelectedCase.CaseId)
            .ToListAsync();

            CaseComments = new ObservableCollection<CaseComment>(caseComments);
        }

    }
}
