using System;
using System.Net;
using System.Text;
using System.IO;

namespace FlashLib
{
	public class FlashCard
	{
		public string Op { get; set; }
		public string OpName { get; set; }
		public int Num1 { get; set; }
		public int Num2 { get; set; }
		public string BuildEquation()
		{
			Random rnd = new Random();
			Num1 = rnd.Next(1, 15);
			Num2 = rnd.Next(1, 15);
			return string.Format("{0} {1} {2} = ", Num1, Op, Num2);
		}
		public int CalcAnswer()
		{
			switch (Op)
			{
				case "+": return CallService("Addition");
				case "-": return CallService("Subtraction");
				case "*": return CallService("Multiplication");
				default: throw new Exception("Invalid operation requested");
			}
		}
		public bool CheckAnswer(int answer)
		{
			return (answer == CalcAnswer());
		}
		public int CallService(string service)
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
			return int.Parse(result);
		}
	}
}
