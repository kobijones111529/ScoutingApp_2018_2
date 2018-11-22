using System;
using System.ComponentModel;
using System.Reflection;

namespace MVVM {
	public static class Enum {
		public static string GetDescription<T>(this T enumValue) where T : struct {
			Type type = enumValue.GetType();
			if(!type.IsEnum) {
				throw new ArgumentException("Enumeration value must be of type enum", "enumValue");
			}
			MemberInfo[] memberInfo = type.GetMember(enumValue.ToString());
			if(memberInfo != null && memberInfo.Length > 0) {
				object[] attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
				if(attribs != null && attribs.Length > 0) {
					return ((DescriptionAttribute)attribs[0]).Description;
				}
			}
			return enumValue.ToString();
		}
	}
}
