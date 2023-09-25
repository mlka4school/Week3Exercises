using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Fibonacci
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int totalIteration;
			int currIteration = 0;
			List<int> sequence = new List<int>();
			Retry: Console.WriteLine("How many generations do you want?");
			var insert = Console.ReadLine();

			try{ // conversion...
				var convert = Convert.ToInt32(insert);
				totalIteration = convert;
			}catch{
				Console.Clear();
				Console.WriteLine("A number was not entered!");
				goto Retry;
			}

			if (totalIteration <= 0){ // checks for a number greater than 0
				Console.Clear();
				Console.WriteLine("Needs to be a positive integer!");
				goto Retry;
			}else{
				Console.WriteLine("Generating sequence of length "+totalIteration.ToString()+"...");
			}

			// clean up if needed
			currIteration = 0;
			sequence.Clear();
			// generation time
			while (totalIteration > currIteration){
				switch (currIteration){
					case 0:
						// generate a 0.
						sequence.Add(0);
					break;
					case 1:
						// generate a 1.
						sequence.Add(1);
					break;
					default:
						// generate as normal.
						// get the last two values
						var add1 = sequence[sequence.Count-1];
						var add2 = sequence[sequence.Count-2];
						// add them up
						var sum = add1+add2;
						// add them to the array
						sequence.Add(sum);
					break;
				}
				++currIteration;
			}
			// print the full array
			var finalArray = "[ 0";
			/* something a little hacky we are going to do is remove the first value so the end result looks cleaner.
			there are many better ways to do this, but i think this will be fine. plus, we already know what value 0 is */
			sequence.RemoveAt(0);
			foreach (int value in sequence){
				finalArray = finalArray+", "+value.ToString();
			}
			finalArray = finalArray+" ]";
			Console.WriteLine(finalArray);

			Console.WriteLine("Continue? Y/N");
			if (Console.ReadLine().ToLower() == "y"){
				Console.Clear();
				goto Retry;
			}
			// any other response will exit the program
		}
	}
}
