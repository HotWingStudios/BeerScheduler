using DontPanic.Helpers;

namespace BeerScheduler.Utilities
{
    public static class ClassFactory
    {
        private static readonly ProxyFactory Factory = new ProxyFactory();

        public static T CreateClass<T>() where T : class
        {
            return Factory.Proxy<T>();
        }

        public static void OverrideProxy<TContract, TImpl>(TImpl impl)
            where TContract : class
            where TImpl : TContract
        {
            Factory.AddProxyOverride<TContract>(impl);
        }
    }
}
