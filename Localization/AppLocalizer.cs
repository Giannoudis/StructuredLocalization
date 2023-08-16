using Microsoft.Extensions.Localization;

namespace Localization;

public class AppLocalizer : LocalizerBase
{
    public AppLocalizer(IStringLocalizerFactory factory) :
        base(factory)
    {
    }

    public string Title => PropertyValue();
    public string About => PropertyValue();
    public string Home => PropertyValue();
    public string Loading => PropertyValue();
}