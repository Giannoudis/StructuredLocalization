using Microsoft.Extensions.Localization;

namespace Localization;

public class Localizer : LocalizerBase
{
    public Localizer(IStringLocalizerFactory factory) :
        base(factory, nameof(Localizer))
    {
        App = new(factory);
        Home = new(factory);
        Survey = new(factory);
        Counter = new(factory);
        Forecast = new(factory);
    }

    public AppLocalizer App { get; }
    public HomeLocalizer Home { get; }
    public SurveyLocalizer Survey { get; }
    public CounterLocalizer Counter { get; }
    public ForecastLocalizer Forecast { get; }
}