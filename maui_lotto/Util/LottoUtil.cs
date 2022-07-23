using maui_lotto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace maui_lotto.Util
{
    public static class LottoUtil
    {              
        public static List<LottoResult> GetAllLottoResult()
        {
            List<LottoResult> list = new List<LottoResult>();

            string FileName = "LottoResult.json";
            string text = FileUtil.Load(FileName);
            if (string.IsNullOrEmpty(text) == false)
            {
                list = JsonConvert.DeserializeObject<List<LottoResult>>(text);                
            }

            int start = list.Count();
            if (start < 1)
                start = 1;

            for (int i = start; i < 9999; i++)
            {
                if (list.Where(x => x.drwNo == i).Count() > 0)
                    continue;

                string json = GetWebRequest($"https://www.dhlottery.co.kr/common.do?method=getLottoNumber&drwNo={i}");
                if (string.IsNullOrEmpty(json))
                    continue;

                try
                {
                    var obj = JsonConvert.DeserializeObject<LottoResult>(json);
                    if (obj.returnValue == "fail")
                    {
                        break;
                    }

                    list.Add(obj);
                }
                catch (Exception ex)
                {
                }
            }

            var jsonText = JsonConvert.SerializeObject(list);
            FileUtil.Write(FileName, jsonText);

            return list;
        }
    


        static string GetWebRequest(string url)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    return result;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }






    }
}
