using AndcultureCode.CSharp.Conductors;
using AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Providers;
using Telerik.Sitefinity.Modules.Pages;

namespace AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Conductors
{
    public abstract class CustomProviderConductorBase : Conductor
    {
        protected ICustomPageProvider getProvider()
        {
            var manager = PageManager.GetManager("CustomProvider");

            // Get the provider
            return manager.Provider as ICustomPageProvider;
        }
    }
}
