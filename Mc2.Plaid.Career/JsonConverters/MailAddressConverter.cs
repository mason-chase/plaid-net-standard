using Newtonsoft.Json;
using System;
using System.Net.Mail;

namespace Mc2.Plaid.Career.JsonConverters
{
    public class MailAddressConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(!(value is MailAddress mailAddress) ? string.Empty : mailAddress.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var text = reader.Value as string;

            return IsValidMailAddress(text, out MailAddress mailAddress) ? mailAddress : null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MailAddress);
        }

        private static bool IsValidMailAddress(string text, out MailAddress value)
        {
            try
            {
                value = new MailAddress(text);
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }
    }
}
