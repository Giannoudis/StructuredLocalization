using Microsoft.Extensions.Localization;

namespace Localization;

public class CounterLocalizer : LocalizerBase
{
    public CounterLocalizer(IStringLocalizerFactory factory) :
        base(factory)
    {
    }

    public string Title => Localization();
    public string Click => Localization();
    public string CurrentCount(int currentCount) =>
        ApplyParameter(Localization(), nameof(currentCount), currentCount);
}