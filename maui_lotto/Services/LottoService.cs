using maui_lotto.Util;
using Newtonsoft.Json;
using System.Text;

namespace maui_lotto.Services
{
    public class LottoService
    {
        HttpClient httpClient;
        public LottoService()
        {
            this.httpClient = new HttpClient();
        }

        List<LottoResult> lottoList;
        public async Task<List<LottoResult>> GetLottoResult()
        {
            if (lottoList?.Count > 0)
                return lottoList;

            string FileName = "LottoResult.json";
            string text = FileUtil.Load(FileName);
            if (string.IsNullOrEmpty(text) == false)
            {
                lottoList = JsonConvert.DeserializeObject<List<LottoResult>>(text);
            }

            int start = lottoList.Count();
            if (start < 1)
                start = 1;

            for (int i = start; i < 9999; i++)
            {
                if (lottoList.Where(x => x.drwNo == i).Count() > 0)
                    continue;

                // Online
                var response = await httpClient.GetAsync($"https://www.dhlottery.co.kr/common.do?method=getLottoNumber&drwNo={i}");
                if (response.IsSuccessStatusCode)
                {
                    Stream receiveStream = response.Content.ReadAsStream();
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    string json = readStream.ReadToEnd();

                    try
                    {
                        var obj = JsonConvert.DeserializeObject<LottoResult>(json);
                        if (obj.returnValue == "fail")
                        {
                            break;
                        }

                        lottoList.Add(obj);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            var jsonText = JsonConvert.SerializeObject(lottoList);
            FileUtil.Write(FileName, jsonText);
           
            return lottoList;
        }






   


    }
}
