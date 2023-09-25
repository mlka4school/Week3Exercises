using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<double> itemPrice = new List<double>();
			List<int> itemAmount = new List<int>();

			MainMenu: Console.Clear();
			Console.WriteLine("What would you like to do?");
			Console.WriteLine("1. Add a new item");
			Console.WriteLine("2. View the cart & total");
			Console.WriteLine("3. Exit the program");

			var input = 0;
			if (int.TryParse(Console.ReadLine(),out input)){
				switch (input){
					case 1: // add new item
						Console.Clear();
						RetryPrice: Console.WriteLine("Price of new item?");
						var price = 0.0D;
						if (!double.TryParse(Console.ReadLine(),out price)) goto RetryPrice;
						if (price <= 0) goto RetryPrice;
						RetryAmount: Console.WriteLine("Amount of new item?");
						var amt = 0;
						if (!int.TryParse(Console.ReadLine(),out amt)) goto RetryAmount;
						if (amt <= 0) goto RetryAmount;
						// both of those passed? great! add them to the arrays
						itemPrice.Add(price);
						itemAmount.Add(amt);
						Console.WriteLine("Added "+amt.ToString()+"x of item(s) worth $"+price.ToString());
						Console.WriteLine("Press any key to continue...");
						Console.ReadKey();
					goto MainMenu;
					case 2: // combining these two won't be an issue i'm sure
						Console.Clear();
						if (itemAmount.Count == 0){
							Console.WriteLine("You have no items.");
						}else{
							var formatString = "";
							var totalAmt = 0.0D;
							for (var i = 0; i < itemPrice.Count; ++i){
								// am i really doing the nice line thing again? yes.....
								formatString = itemAmount[i].ToString()+"x $"+itemPrice[i].ToString()+" worth item";
								while (formatString.Length < 48){
									formatString += " ";
								}
								formatString += "$"+(itemPrice[i]*itemAmount[i]).ToString();
								totalAmt += itemPrice[i]*itemAmount[i];
								Console.WriteLine(formatString);
							}
							// total
							formatString = "Total";
							while (formatString.Length < 48){
								formatString += " ";
							}
							formatString += "$"+(totalAmt).ToString();
							Console.WriteLine(formatString);
						}
						Console.WriteLine("");
						Console.WriteLine("Press any key to continue...");
						Console.ReadKey();
					goto MainMenu;
					case 3: // This kills the program.
					return;
					default: // unk
					goto MainMenu;
				}
			}else{
				goto MainMenu;
			}
		}
	}
}
