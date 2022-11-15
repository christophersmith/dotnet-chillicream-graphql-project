using System.Diagnostics.CodeAnalysis;
using HotChocolate.Utilities;

namespace ProductMicroservice.Utils;

public class GuidChangeTypeProvider : IChangeTypeProvider
{
    bool IChangeTypeProvider.TryCreateConverter(Type source, Type target, ChangeTypeProvider root, [NotNullWhen(true)] out ChangeType? converter)
    {
        if (source == typeof(Guid) && target == typeof(string))
        {
            converter = Format;
            return true;
        }
        converter = null;
        return false;
    }

    private static object? Format(object? input)
        => input is Guid g && input is not null
            ? g.ToString()
            : default(string);
}
