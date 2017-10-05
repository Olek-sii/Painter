using Newtonsoft.Json;
using Painter.Model;

namespace Painter
{
	public class Serializer
	{
		public static string ToJson(MTab mTab)
		{
			return JsonConvert.SerializeObject(mTab);
		}

		public static MTab FromJson(string json)
		{
			return JsonConvert.DeserializeObject<MTab>(json);
		}
	}
}