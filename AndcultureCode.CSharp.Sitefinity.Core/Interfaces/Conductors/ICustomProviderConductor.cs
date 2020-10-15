using AndcultureCode.CSharp.Core.Interfaces.Conductors;

namespace AndcultureCode.CSharp.Sitefinity.Core.Interfaces.Conductors
{
    public interface ICustomProviderConductor : IConductor,
        ICustomProviderCreateConductor,
        ICustomProviderDeleteConductor,
        ICustomProviderReadConductor,
        ICustomProviderUpdateConductor
    {
        
    }
}
