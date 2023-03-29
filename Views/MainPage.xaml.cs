using CaseManagementSystem.Models;
using CaseManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CaseManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var datagrid = (DataGrid)sender;
            if (datagrid.SelectedItem == null) return;

            var vm = (MainPageViewModel)DataContext;
            if (vm.SelectedCase != null)
            {
                vm.MainWindowViewModel.SelectedCase = vm.SelectedCase;
                vm.MainWindowViewModel.GoToCaseDetailsPage();
            }
        }

        private async void statusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vm = (MainPageViewModel)DataContext;
            var comboBox = (ComboBox)sender;
            var selectedCase = (Case)comboBox.DataContext;

            if (selectedCase != null && e.AddedItems.Count > 0)
            {
                var selectedStatus = e.AddedItems[0] as string;
                selectedCase.Status = selectedStatus;
                await vm.UpdateCaseStatus(selectedCase);
            }
        }


    }
}
