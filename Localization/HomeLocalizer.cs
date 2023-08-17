using Microsoft.Extensions.Localization;

namespace Localization;

public class HomeLocalizer : LocalizerBase
{
    public HomeLocalizer(IStringLocalizerFactory factory) :
        base(factory)
    {
    }

    public string Title => Localization();
    public string Header => Localization();
    public string Welcome => Localization();
    public string SurveyTitle => Localization();
    public string EnumLocalization => Localization();
}