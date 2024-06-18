using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sala7ly.Core.Helpers
{
	public class Enums
	{
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public enum UserType
		{
			Admin,
			Client,
			Worker
		}
	}
}
