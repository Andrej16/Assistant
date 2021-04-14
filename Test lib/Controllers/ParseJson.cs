using Newtonsoft.Json.Linq;
using Assistant.Core;

namespace TestLib
{
    public class ParseJson : ITestLib
    {
        public void DoAction()
        {
            //{
            //    "Messages": [
            //            {
            //                "type": "ProcessValidate",
            //                "field": "System",
            //                "id": "1",
            //                "tid": "1",
            //                "text": "Ошибка аутентификации. Пользователь[Шилін А. А.] не существует"
            //            }
            //        ]
            //}
            string source = "{\"Messages\": [{\"type\": \"ProcessValidate\", \"id\": \"1\", \"text\": \"Ошибка аутентификации. Пользователь[Шилін А. А.] не существует\"}]}";
            JObject jo = JObject.Parse(source);
            string t1 = (string)jo["Messages"][0]["type"];
            string text1 = (string)jo["Messages"][0]["text"];

            JArray messages = (JArray)jo?["Messages"];
            if (messages is null)
                return;

            foreach (var jToken in messages.Children())
            {
                JObject item = (JObject)jToken;
                string text2 = "text: " + (string)item["text"];
                int id1 = (int)item["id"];
                int idex1 = (int)item["idex"];
                string type3 = "type: " + item.GetValue("type").ToString();
            }
        }
    }
}
