using System;
using System.IO.Compression;
using System.Net.Http;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using HtmlAgilityPack;

namespace Angle.Models
{
    public class Crawler
    {
        public static void Login()
        {
            HttpWebRequest http = WebRequest.Create("http://localhost:23868/Account/Login") as HttpWebRequest;
            http.KeepAlive = true;

            http.Method = WebRequestMethods.Http.Post;
            http.ContentType = "application/x-www-form-urlencoded";
            string postData = "Email=" + "hassan" + "&Password=" + "Hassan";
            byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(postData);
            http.ContentLength = dataBytes.Length;
            http.Date = DateTime.Now;
            using (Stream postStream = http.GetRequestStream())
            {
                postStream.Write(dataBytes, 0, dataBytes.Length);
            }
            HttpWebResponse httpResponse = http.GetResponse() as HttpWebResponse;
            http.CookieContainer = new CookieContainer();
            http.CookieContainer.Add(httpResponse.Cookies);
            // Probably want to inspect the http.Headers here first
            http = WebRequest.Create("http://localhost:23868/Attendance") as HttpWebRequest;
            HttpWebResponse httpResponse2 = http.GetResponse() as HttpWebResponse;
        }


        public static void Login1()
        {
            CookieContainer cc = new CookieContainer();

            HttpWebRequest http = WebRequest.Create("http://localhost:23868/Account/Login") as HttpWebRequest;
            http.KeepAlive = true;
            http.Method = "POST";
            http.ContentType = "application/x-www-form-urlencoded";

            http.CookieContainer = cc;

            string postData = "Email=" + "hassan" + "&Password=" + "Hassan";
            byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(postData);
            http.ContentLength = dataBytes.Length;
            using (Stream postStream = http.GetRequestStream())
            {
                postStream.Write(dataBytes, 0, dataBytes.Length);
            }
            HttpWebResponse httpResponse = http.GetResponse() as HttpWebResponse;
            // Probably want to inspect the http.Headers here first
            http = WebRequest.Create("http://localhost:23868/Attendance") as HttpWebRequest;

            http.CookieContainer = cc;

            HttpWebResponse httpResponse2 = http.GetResponse() as HttpWebResponse;
        }

        













        public static string PreparePostData(string userName, string pwd, string url)
        {
            var postData = new StringBuilder();
            postData.Append("log=" + userName);
            postData.Append("&");
            postData.Append("pwd=" + pwd);
            postData.Append("&");
            postData.Append("wp-submit=Log+In");
            postData.Append("&");
            postData.Append("redirect_to=" + url);
            postData.Append("&");
            postData.Append("testcookie=1");

            return postData.ToString();
        }

        public static byte[] GetEncodedData(string postData)
        {
            var encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(postData);
            return data;
        }

        public static string GetCookie(string url, byte[] data)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:10.0.2) Gecko/20100101 Firefox/10.0.2";
            webRequest.AllowAutoRedirect = false;

            Stream requestStream = webRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            var webResponse = (HttpWebResponse)webRequest.GetResponse();

            string cookievalue = string.Empty;
            if (webResponse.Headers != null && webResponse.Headers["Set-Cookie"] != null)
            {
                cookievalue = webResponse.Headers["Set-Cookie"];

                // Modify CookieValue  
                cookievalue = GenerateActualCookieValue(cookievalue);
            }

            return cookievalue;
        }

        public static string GenerateActualCookieValue(string cookievalue)
        {
            var seperators = new char[] { ';', ',' };
            var oldCookieValues = cookievalue.Split(seperators);

            string newCookie = oldCookieValues[2] + ";" + oldCookieValues[0] + ";" + oldCookieValues[8] + ";" + "wp-settings-time-2=1345705901";
            return newCookie;
        }

        public static List<string> GetUserProfile(string profileUrl, string cookieValue)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(profileUrl);

            webRequest.Method = "GET";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:10.0.2) Gecko/20100101 Firefox/10.0.2";
            webRequest.AllowAutoRedirect = false;

            webRequest.Headers.Add("Cookie", cookieValue);

            var responseCsv = (HttpWebResponse)webRequest.GetResponse();
            Stream response = responseCsv.GetResponseStream();

            var htmlDocument = new HtmlDocument();
            htmlDocument.Load(response);

            var responseList = new List<string>();

            // reading all input tags in the page  
            var inputs = htmlDocument.DocumentNode.Descendants("input");

            foreach (var input in inputs)
            {
                if (input.Attributes != null)
                {
                    if (input.Attributes["id"] != null && input.Attributes["value"] != null)
                    {
                        responseList.Add(input.Attributes["id"].Value + " = " + input.Attributes["value"].Value);
                    }
                }
            }

            return responseList;
        }  
    }
}