using System;
using System.Runtime.Serialization;

namespace Glacier.ScreenSystems
{
    /// <summary>
    /// LifetimeScopeの取得に失敗した際の例外。 
    /// </summary>
    [Serializable]
    public class LifetimeScopeNotFoundException : Exception
    {
        public LifetimeScopeNotFoundException()
            : base()
        {

        }

        public LifetimeScopeNotFoundException(string message)
            : base(message)
        {

        }

        public LifetimeScopeNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        protected LifetimeScopeNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }

    /// <summary>
    /// ContainerのResolveで指定のクラスの取得に失敗した際の例外。
    /// </summary>
    [Serializable]
    public class ContainerResolveException : Exception
    {
        public ContainerResolveException()
            : base()
        {

        }

        public ContainerResolveException(string message)
            : base(message)
        {

        }

        public ContainerResolveException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        protected ContainerResolveException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}