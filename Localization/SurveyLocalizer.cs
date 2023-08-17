using Microsoft.Extensions.Localization;

namespace Localization;

public class SurveyLocalizer : LocalizerBase
{
    public SurveyLocalizer(IStringLocalizerFactory factory) :
        base(factory)
    {
    }

    public string PromptStart => Localization();
    public string PromptSurvey => Localization();
    public string PromptEnd => Localization();
}