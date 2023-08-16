using Microsoft.Extensions.Localization;

namespace Localization;

public class ForecastLocalizer : LocalizerBase
{
    public ForecastLocalizer(IStringLocalizerFactory factory) :
        base(factory)
    {
    }

    public string Title => PropertyValue();
    public string Description => PropertyValue();
    public string Date => PropertyValue();
    public string TempCelsius => PropertyValue();
    public string TempFahrenheit => PropertyValue();
    public string Summary => PropertyValue();
}