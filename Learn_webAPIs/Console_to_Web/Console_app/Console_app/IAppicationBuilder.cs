using System;

namespace Console_app
{
    public interface IAppicationBuilder
    {
        void UseEndPoints(Func<object, object> value);
        void UseEndpoints(Action<object> value);
        void UseRouting();
    }
}