using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace DellyShopApp.CommonData
{
    static public class HelperClass
    {
        static public byte[] GetBytesRecord(string url, string token)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            try
            {
                using (var client = new HttpClient())
                {
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        //var t = JsonConvert.DeserializeObject<Token>(token);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Global.token);
                        client.DefaultRequestHeaders.Add("Host", Global.Host);
                        //client.DefaultRequestHeaders.Add("Host", "noesis-web1");

                    }
                    //var response1 = client
                    var response = client.GetAsync(url).Result;
                    var content = response.Content.ReadAsByteArrayAsync().Result;
                    //byte[] ActualData = Decompress(content);
                    //File.WriteAllBytes("script.sql", ActualData);
                    return content;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        static public string GetStringRecord(string url)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrWhiteSpace(Global.token))
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Global.token);
                    client.DefaultRequestHeaders.Add("Host", Global.Host);
                }
                var response = client.GetAsync(url).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
        static public string DeleteRecord(string url)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                using (var client = new HttpClient())
                {
                    if (!string.IsNullOrWhiteSpace(Global.token))
                    {
                        //var t = JsonConvert.DeserializeObject<Token>(Token);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Global.token);
                        client.DefaultRequestHeaders.Add("Host", Global.Host);

                    }

                    var response = client.DeleteAsync(url).Result;
                    response.EnsureSuccessStatusCode();
                    return response.Content.ReadAsStringAsync().Result;
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        static public string PostRecord(string url, List<KeyValuePair<string, string>> pairs)
        {
            var content = new FormUrlEncodedContent(pairs);
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            try
            {
                using (var client = new HttpClient())
                {
                    if (!string.IsNullOrWhiteSpace(Global.token))
                    {
                        //var t = JsonConvert.DeserializeObject<Token>(Token);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Global.token);
                        client.DefaultRequestHeaders.Add("Host", Global.Host);
                        // client.DefaultRequestHeaders.Add("Host", "noesis-web1");

                    }
                    client.Timeout = new TimeSpan(1, 0, 0);
                    var response = client.PostAsync(url, content).Result;
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        static public string PutRecord(string url, List<KeyValuePair<string, string>> pairs)
        {
            try
            {
                var content = new FormUrlEncodedContent(pairs);
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                using (var client = new HttpClient())
                {
                    if (!string.IsNullOrWhiteSpace(Global.token))
                    {
                        //var t = JsonConvert.DeserializeObject<Token>(Token);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Global.token);
                        client.DefaultRequestHeaders.Add("Host", Global.Host);
                        //client.DefaultRequestHeaders.Add("Host", "noesis-web1");

                    }

                    var response = client.PutAsync(url, content).Result;
                    var SuccessStatusCode = response.EnsureSuccessStatusCode();
                    return response.Content.ReadAsStringAsync().Result;
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        static public string DoFormat(double myNumber)
        {
            var s = string.Format("{0:0.0}", myNumber);

            if (s.EndsWith("0"))
            {
                return ((int)myNumber).ToString();
            }
            else
            {
                return s;
            }
        }

    }

}
