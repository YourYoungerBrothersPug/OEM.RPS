using System.Reflection;

namespace OEM.RPS.Extensions;

public static class EnumExtensions
{
	public static bool HasAttribute<T>(this Enum e) where T : Attribute
		=> e.GetType().GetMember(e.ToString()).FirstOrDefault()?.GetCustomAttribute<T>() is not null;
}