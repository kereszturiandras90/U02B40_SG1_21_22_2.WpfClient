using U02B40_HFT_2021221.WpfClient.Models;
using U02B40_HFT_2021221.WpfClient.ViewModels;
using System.Windows;

namespace U02B40_HFT_2021221.WpfClient
{
    /// <summary>
    /// Interaction logic for TransactionEditorWindow.xaml
    /// </summary>
    public partial class TransactionEditorWindow : Window
    {
        public TransactionModel Transaction { get; set; }
        bool enableEdit;

        public TransactionEditorWindow(TransactionModel transaction = null, bool enableEdit = true)
        {
            InitializeComponent();
            Transaction = transaction == null
                ? new TransactionModel() { TransferTime = System.DateTime.Today}
                : new TransactionModel(transaction);

            this.enableEdit = enableEdit;
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            if (Transaction == null)
            {
                MessageBox.Show("Please, do not leave the details empty!");
                DialogResult = false;
            }
            else
            {
                if (enableEdit)
                {
                    DialogResult = true;
                }
                else
                {
                    Close();
                }
            }
           
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            if (enableEdit)
            {
                DialogResult = false;
            }
            else
            {
                Close();
            }
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var vm = (TransactionEditorVM)Resources["VM"];
            vm.CurrentTransaction = Transaction;
            vm.EditEnabled = enableEdit;
            
        }
    }
}
