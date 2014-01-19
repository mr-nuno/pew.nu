using Microsoft.Practices.ServiceLocation;

namespace PEW.Core
{
    public class Utilities
    {
        public static T Use<T>()
        {
            var o = ServiceLocator.Current.GetInstance<T>();
            return o;
        }
    }
}
