using EnumsNET;

namespace OEM.RPS.Extensions;

public static class EnumExtensions
{
	public static bool HasAttribute<TEnum, TAttribute>(this TEnum e)
		where TEnum : struct, Enum where TAttribute : Attribute
		=> e.GetAttributes()?.Has<TAttribute>() ?? false;
}