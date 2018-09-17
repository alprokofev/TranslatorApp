using System;
using System.Xml;

namespace TranslatorApp
{
    //Класс создаёт xml документ
    public static class XmlCreator
    {
        public static void Create(string fileName, string langDirection, string sourceTxt, string translatedTxt,
            DateTime dtTranslated)
        {
            try
            {
                string[] arrLangs = langDirection.Split('-');
                if (arrLangs == null || arrLangs.Length != 2)
                    return;

                var document = new XmlDocument();

                //translate
                var translateElem = document.CreateElement("translate");

                //rawText
                var rawTextElem = document.CreateElement("rawText");
                var codeAttr = document.CreateAttribute("code");
                var valueAttr = document.CreateAttribute("value");
                var codeText = document.CreateTextNode(arrLangs[0]);
                var valueText = document.CreateTextNode(sourceTxt);
                codeAttr.AppendChild(codeText);
                valueAttr.AppendChild(valueText);
                rawTextElem.Attributes.Append(codeAttr);
                rawTextElem.Attributes.Append(valueAttr);
                translateElem.AppendChild(rawTextElem);

                //translateText
                var translatedTextElem = document.CreateElement("translateText");
                codeAttr = document.CreateAttribute("code");
                valueAttr = document.CreateAttribute("value");
                codeText = document.CreateTextNode(arrLangs[1]);
                valueText = document.CreateTextNode(translatedTxt);
                codeAttr.AppendChild(codeText);
                valueAttr.AppendChild(valueText);
                translatedTextElem.Attributes.Append(codeAttr);
                translatedTextElem.Attributes.Append(valueAttr);
                translateElem.AppendChild(translatedTextElem);

                //time
                var timeElem = document.CreateElement("time");
                valueAttr = document.CreateAttribute("value");
                valueText = document.CreateTextNode(dtTranslated.ToString("dd.MM.yyyyTHH:mm"));
                valueAttr.AppendChild(valueText);
                timeElem.Attributes.Append(valueAttr);
                translateElem.AppendChild(timeElem);

                document.AppendChild(translateElem);

                //string fileName = "translate " + DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + ".xml";
                document.Save(fileName);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
