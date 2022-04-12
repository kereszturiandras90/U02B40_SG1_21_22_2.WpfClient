using U02B40_HFT_2021221.WpfClient.BL.Implementation;
using U02B40_HFT_2021221.WpfClient.BL.Interfaces;
using U02B40_HFT_2021221.WpfClient.Infrastructure;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using U0240_HFT_2021221.WpfClient.Infrastructure;
using U02B40_HFT_2021221.WpfClient;

namespace U0240_HFT_2021221.WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIocAsServiceLocator.Instance);

            SimpleIocAsServiceLocator.Instance.Register<ITransactionEditorService, TransactionEditorViaWindowService>();
            SimpleIocAsServiceLocator.Instance.Register<ITransactionDisplayService, TransactionDisplayService>();
            SimpleIocAsServiceLocator.Instance.Register<ITransactionHandlerService, TransactionHandlerService>();
            SimpleIocAsServiceLocator.Instance.Register(() => Messenger.Default);
        }
    }
}
