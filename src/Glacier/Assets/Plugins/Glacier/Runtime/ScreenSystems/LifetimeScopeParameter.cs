using VContainer;
using VContainer.Unity;

namespace Glacier.ScreenSystems
{
    public class LifetimeScopeParameter<TParam> : LifetimeScope
    {
        #region properties

        public TParam Parameter { get; set; }

        #endregion

        #region methods

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(Parameter);
        }

        #endregion
    }
}