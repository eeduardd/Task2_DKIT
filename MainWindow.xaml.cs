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

namespace WPF_App_Task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _hasCode;
        private bool _cancelChanges;
        public MainWindow()
        {
            InitializeComponent();

            _cancelChanges = false;
            var user = new User("Dkit", "dkit@test.com", "DkitGit");
            _hasCode = user.GetHashCode();
            DataContext = user;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DataContext.GetHashCode() != _hasCode && !_cancelChanges)
            {
                MDSnackbarUnsavedChanges.IsActive = true;
                e.Cancel = true;
            }
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TxbName.Text == "" | TxbGithub.Text == "" | TxbEmail.Text == "")
            {
                MDSnackbarUnfilledFields.IsActive = true;

                
            }
            else if (DataContext.GetHashCode() != _hasCode && !_cancelChanges)
            {
                MDSnackbarUnsavedChanges.IsActive = true;
            }
        }

        private void SnackbarMessage_ActionClick(object sender, RoutedEventArgs e)
        {
            MDSnackbarUnsavedChanges.IsActive = false;
            _cancelChanges = true;
            Close();
        }

        private void SnackbarMessage_UnfilledFields(object sender, RoutedEventArgs e)
        {
            MDSnackbarUnfilledFields.IsActive = false;
            _cancelChanges = true;
        }
    }
}
