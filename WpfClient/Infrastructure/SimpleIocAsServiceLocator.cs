using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace U02B40_HFT_2021221.WpfClient.Infrastructure
{
    /*public class SimpleIocAsServiceLocator : SimpleIoc, IServiceLocator
    {
        public static SimpleIocAsServiceLocator Instance { get; private set; } = new SimpleIocAsServiceLocator();
    }*/
    public class SimpleIocAsServiceLocator: SimpleIoc, IServiceLocator
    {
        public static SimpleIocAsServiceLocator Instance { get; private set; } = new SimpleIocAsServiceLocator();
    }
}
