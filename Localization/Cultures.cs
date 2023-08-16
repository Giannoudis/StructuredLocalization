using System.Globalization;

namespace Localization;

public static class Cultures
{
    private static readonly Dictionary<string, CultureInfo> CultureCache = new();
    private static string DefaultCulture => SupportedCultures.First();

    public static string ResourcesPath => "Resources";

    /// <summary>
    /// Supported application cultures, default is the first entry
    /// </summary>
    public static List<string> SupportedCultures => new()
    {
        "en",
        "de"
    };

    private static CultureInfo GetCulture(string cultureName)
    {
        if (string.IsNullOrWhiteSpace(cultureName))
        {
            throw new ArgumentException(nameof(cultureName));
        }

        if (CultureCache.TryGetValue(cultureName, out var culture))
        {
            return culture;
        }

        culture = CultureInfo.GetCultureInfo(cultureName);
        CultureCache.Add(cultureName, culture);
        return culture;
    }

    public static CultureInfo CurrentCulture()
    {
        var culture = CultureInfo.DefaultThreadCurrentUICulture;
        if (culture != null)
        {
            if (SupportedCultures.Any(x => string.Equals(x, culture.Name)))
            {
                return culture;
            }

            var matchingCulture = SupportedCultures.FirstOrDefault(x => culture.Name.StartsWith(x));
            if (matchingCulture != null)
            {
                return GetCulture(matchingCulture);
            }
        }
        // fallback to default culture
        return GetCulture(DefaultCulture);
    }

    public static List<CultureInfo> GetCultures()
    {
        var cultures = new List<CultureInfo>();
        foreach (var culture in SupportedCultures)
        {
            cultures.Add(GetCulture(culture));
        }
        return cultures;
    }

    public static void ApplyCulture() =>
        ApplyCulture(DefaultCulture);

    public static void ApplyCulture(string cultureName)
    {
        if (string.IsNullOrWhiteSpace(cultureName))
        {
            throw new ArgumentException(nameof(cultureName));
        }

        // apply culture to the current thread
        var culture = GetCulture(cultureName);
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }
}