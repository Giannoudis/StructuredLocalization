using Microsoft.Extensions.Localization;

namespace Localization;

public class SurveyLocalizer : LocalizerBase
{
    public SurveyLocalizer(IStringLocalizerFactory factory) :
        base(factory)
    {
    }

    public string PromptStart => PropertyValue();
    public string PromptSurvey => PropertyValue();
    public string PromptEnd => PropertyValue();
}