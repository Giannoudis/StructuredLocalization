using Microsoft.Extensions.Localization;

namespace Localization;

public class HomeLocalizer : LocalizerBase
{
    public HomeLocalizer(IStringLocalizerFactory factory) :
        base(factory)
    {
    }

    public string Title => PropertyValue();
    public string Header => PropertyValue();
    public string Welcome => PropertyValue();
    public string SurveyTitle => PropertyValue();
    public string EnumLocalization => PropertyValue();
}