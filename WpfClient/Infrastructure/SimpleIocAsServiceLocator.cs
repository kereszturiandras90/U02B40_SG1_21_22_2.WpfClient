using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace U0240_HFT_2021221.WpfClient.Infrastructure
{
    public class SimpleIocAsServiceLocator : SimpleIoc, IServiceLocator
    {
        public static SimpleIocAsServiceLocator Instance { get; private set; } = new SimpleIocAsServiceLocator();
    }
}
