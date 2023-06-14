using Newtonsoft.Json.Linq;

namespace CSharpSelFramework.Utilities
{
    public class JsonReader
    {
        public string extractData(string tokenName)
        {
            string myJsonString = File.ReadAllText("utilities/testData.json");

            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();

        }

        public string[] extractDataArray(string tokenName)
        {
            string myJsonString = File.ReadAllText("utilities/testData.json");

            var jsonObject = JToken.Parse(myJsonString);
            List<string> productsList = jsonObject.SelectTokens(tokenName).Values<string>().ToList();
            return productsList.ToArray();

        }
    }
}
