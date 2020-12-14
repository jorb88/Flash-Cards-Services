using System;
using System.Net;
using System.Text;
using System.IO;

namespace FlashLib
{
	public class FlashCard
	{
		public string OpSymbol { get; set; }
		public string Operation { get; set; }
		public double Num1 { get; set; }
		public double Num2 { get; set; }
		public string BuildEquation()
		{
			Random rnd = new Random();
			Num1 = rnd.Next(2, 100);
			Num2 = rnd.Next(2, 100);
			return string.Format("{0} {1} {2} = ", Num1, OpSymbol, Num2);
		}

		public bool CheckAnswer(double answer)
		{
			return (answer == CallService(Operation));
		}

		public double CallService(string service)
		{
			WebRequest request = WebRequest.Create("http://localhost:7071/api/" + service);
			UTF8Encoding encoding = new UTF8Encoding(false);
			string json = "{\"num1\":" + Num1 + ", \"num2\": " + Num2 + "}";
			byte[] data = encoding.GetBytes(json.ToCharArray());
			request.Method = "POST";
			request.ContentType = "application/json";
			request.ContentLength = data.Length;
			using (Stream output = request.GetRequestStream())
			{
				output.Write(data, 0, data.Length);
			}
			WebResponse response = request.GetResponse();
			StreamReader input = new StreamReader(response.GetResponseStream());
			string result = input.ReadToEnd();
			return double.Parse(result);
		}
	}
}
