using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlashLib;
namespace FlashTest
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the FLASH CARD quiz");
			FlashCard quiz = new FlashCard();
			Console.Write("Please select an operation (+, -, * or /)? ");
			quiz.Op = Console.ReadLine();
			Console.WriteLine("To exit the quiz enter a blank answer.");
			bool playing = true;
			while (playing)
			{
				string equation = quiz.BuildEquation();
				Console.Write(equation);
				string temp = Console.ReadLine();
				if (temp.Length == 0) playing = false;
				else
				{
					int answer = int.Parse(temp);
					if (quiz.CheckAnswer(answer) == true)
						Console.WriteLine("CORRECT");
					else
						Console.WriteLine("INCORRECT");
				}
			}
		}
	}
}
