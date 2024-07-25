using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ZenXKanCore.Configurations;

public class ConfigurationHelper
{
    public static ValueConverter<Ulid, string> UlidValueConverter()
    {
        return new ValueConverter<Ulid, string>(
            model => model.ToString(), value => Ulid.Parse(value));
    }
}