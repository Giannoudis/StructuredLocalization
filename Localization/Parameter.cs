
namespace Localization
{
    public class Parameter
    {
        public string Name { get; }
        public object Value { get; }

        public Parameter(string name, object value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }
            Name = name;
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
