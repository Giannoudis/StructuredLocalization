using Microsoft.Extensions.Localization;

namespace Localization;

public class ForecastLocalizer : LocalizerBase
{
    public ForecastLocalizer(IStringLocalizerFactory factory) :
        base(factory)
    {
    }

    public string Title => Localization();
    public string Description => Localization();
    public string Date => Localization();
    public string TempCelsius => Localization();
    public string TempFahrenheit => Localization();
    public string Summary => Localization();
}