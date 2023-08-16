using System.Runtime.CompilerServices;
using Microsoft.Extensions.Localization;

namespace Localization;

public abstract class LocalizerBase
{
    private const string ResourceName = "Localizations";

    private IStringLocalizerFactory Factory { get; }
    public IStringLocalizer Localizer { get; }
    private string? GroupName { get; }

    protected LocalizerBase(IStringLocalizerFactory factory, string? groupName = null)
    {
        Factory = factory ?? throw new ArgumentNullException(nameof(factory));

        // localization group: <GroupName>.<LocalizationKey>
        if (string.IsNullOrWhiteSpace(groupName))
        {
            groupName = GetType().Name;
            if (groupName.EndsWith(nameof(Localizer)))
            {
                groupName = groupName.Substring(0, groupName.Length - nameof(Localizer).Length);
            }
        }
        GroupName = groupName;

        // string localizer
        var assemblyName = GetType().Assembly.FullName;
        if (string.IsNullOrWhiteSpace(assemblyName))
        {
            throw new ArgumentException(nameof(assemblyName));
        }
        Localizer = Factory.Create(ResourceName, assemblyName);
    }

    /// <summary>
    /// Retrieve translation from group and key
    /// Translation example: MyGroup.MyKey
    /// </summary>
    /// <param name="group">The localization group</param>
    /// <param name="key">The localization key</param>
    private string Key(string? group, string? key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException(nameof(key));
        }
        return group == null ? Localizer[key] : Localizer[$"{group}.{key}"];
    }

    /// <summary>
    /// Retrieve translation from current group and key
    /// Resource name: {InternalGroupName}.MyText
    /// </summary>
    /// <param name="key">The localization key</param>
    private string Key(string? key) =>
        Key(GroupName, key);

    /// <summary>
    /// Retrieve translation value from property key
    /// Resource name: MyProperty.MyText
    /// </summary>
    /// <param name="caller">The caller method name</param>
    protected string PropertyValue([CallerMemberName] string? caller = null) =>
        Key(caller);

    /// <summary>
    /// Format translation value with one parameter
    /// </summary>
    /// <param name="format">The value to format</param>
    /// <param name="parameterName">The parameter name</param>
    /// <param name="parameterValue">The parameter value</param>
    protected string ApplyParameter(string format, string parameterName, object parameterValue) =>
        format.Replace($"{{{parameterName}}}", parameterValue.ToString());

    /// <summary>
    /// Format translation value with two parameter
    /// </summary>
    /// <param name="format">The value to format</param>
    /// <param name="parameters">The parameters</param>
    protected string ApplyParameters(string format, params Parameter[] parameters)
    {
        foreach (var parameter in parameters)
        {
            format = ApplyParameter(format, parameter.Name, parameter.Value);
        }
        return format;
    }

    /// <summary>
    /// Retrieve translation from enum value
    /// Resource name: Enum.{EnumTypeName}.MyEnumValue
    /// </summary>
    /// <param name="value">The enum value</param>
    public string Enum<T>(T value)
    {
        var type = typeof(T);

        // nullable enum
        var nullableType = Nullable.GetUnderlyingType(type);
        if (nullableType != null)
        {
            type = nullableType;
        }

        var group = $"{nameof(System.Enum)}.{type.Name}";
        var translation = Key(group, $"{value}");
        // missing translation: return the enum value
        if (string.IsNullOrEmpty(translation) || translation.StartsWith(group))
        {
            if (value == null)
            {
                return translation;
            }
            var stringValue = value.ToString();
            if (!string.IsNullOrWhiteSpace(stringValue))
            {
                return stringValue;
            }
        }
        return translation;
    }

}