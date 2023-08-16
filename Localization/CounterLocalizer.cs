using Microsoft.Extensions.Localization;

namespace Localization;

public class CounterLocalizer : LocalizerBase
{
    public CounterLocalizer(IStringLocalizerFactory factory) :
        base(factory)
    {
    }

    public string Title => PropertyValue();
    public string Click => PropertyValue();
    public string CurrentCount(int currentCount) =>
        ApplyParameter(PropertyValue(), nameof(currentCount), currentCount);
}