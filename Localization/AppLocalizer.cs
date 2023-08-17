using Microsoft.Extensions.Localization;

namespace Localization;

public class AppLocalizer : LocalizerBase
{
    public AppLocalizer(IStringLocalizerFactory factory) :
        base(factory)
    {
    }

    public string Title => Localization();
    public string About => Localization();
    public string Home => Localization();
    public string Loading => Localization();
}