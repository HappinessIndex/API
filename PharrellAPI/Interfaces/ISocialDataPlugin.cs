using System.Collections.Generic;

namespace Interfaces
{
    public interface ISocialDataPlugin
    {
        IEnumerable<ISocialDatum> FetchSocialData();
    }
}