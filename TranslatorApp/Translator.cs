using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace TranslatorApp
{
    class Translator
    {
        private const string API_KEY = "trnsl.1.1.20180812T155734Z.058fc9d5448d7c98.0f3f72f5c3483194b497c4a35f5ce65adcde01d0";

        public async Task<string> Translate(string text, string language)
        {
            string url = "https://translate.yandex.net/api/v1.5/tr.json/translate";
            url += "?key=" + API_KEY;
            url += "&text=" + text;
            url += "&lang=" + language;
            return await MakeRequestAsync(url);
        }

        private async Task<string> MakeRequestAsync(string url)
        {
            string responseText = "";
            try
            {
                responseText = await Task.Run(() =>
                {
                    string result = "";                    
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    WebResponse response = request.GetResponse();
                    Stream responseStream = response.GetResponseStream();

                    using (StreamReader stream = new StreamReader(responseStream))
                    {
                        string line;
                        if ((line = stream.ReadLine()) != null)
                        {
                            JSON_Response jsonResponse = JsonConvert.DeserializeObject<JSON_Response>(line);
                            string code = jsonResponse.Code;
                            foreach (string str in jsonResponse.Text)
                            {
                                result += str;
                            }
                        }
                    }
                    return result;                    
                });
                return responseText;
            }
            catch (WebException ex)
            {
                MessageBox.Show("Ошибка запроса: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return responseText;
        }
    }
}