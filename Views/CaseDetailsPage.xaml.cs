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
    /// Interaction logic for CaseDetailsPage.xaml
    /// </summary>
    public partial class CaseDetailsPage : UserControl
    {
        public CaseDetailsPage(CaseDetailsPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
