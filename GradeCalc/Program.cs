using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalc
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int studentCount;
			List<int> currGrades = new List<int>();
			List<int> classAvg = new List<int>();
			
			NewClass: Console.WriteLine("How many students are in this class?");
			var getAmt = Console.ReadLine();
			if (int.TryParse(getAmt,out studentCount)){
				if (studentCount <= 0){
					Console.Clear();
					Console.WriteLine("A classroom can't be empty (or less than empty)");
					goto NewClass;
				}else{
					var count = 0;
					currGrades.Clear();
					while (studentCount > count){
						NewGrade: Console.WriteLine("Enter student #"+(count+1).ToString()+"'s grade (0~100)");
						getAmt = Console.ReadLine();
						var finalGrade = 0;
						if (!int.TryParse(getAmt,out finalGrade)) goto NewGrade;
						// continue otherwise.
						if (finalGrade > 100) finalGrade = 100;
						if (finalGrade < 0) finalGrade = 0;
						// after making sure it's in range, add it to the list and continue..
						currGrades.Add(finalGrade);
						++count;
					}
					// tally them all up, clear the list, and then add them to the classAvg list for totals.
					var finalAvg = 0;
					for (var i = 0; i < currGrades.Count; ++i){
						finalAvg += currGrades[i];
					}
					finalAvg /= currGrades.Count;
					classAvg.Add(finalAvg);
					Console.WriteLine("Out of "+currGrades.Count+" students, the average grade is "+classAvg.Last<int>().ToString());
					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
				}
			}else{
				Console.Clear();
				Console.WriteLine("Not a number");
				goto NewClass;
			}

			// list all the classes.
			Console.Clear();

			for (var i = 0; i < classAvg.Count; ++i){
				// let's format this really nicely. because i think that would be cool... why am i doing this????
				var formatSetup = "Class #"+(i+1).ToString();
				while (formatSetup.Length < 14){
					formatSetup += " ";
				}
				// percentage
				formatSetup += classAvg[i]+"%";
				while (formatSetup.Length < 24){
					formatSetup += " ";
				}
				// grade
				formatSetup += LetterGrade(classAvg[i]);

				Console.WriteLine(formatSetup);
			}
			// give choice to add a new class
			Console.WriteLine("");

			Console.WriteLine("Add a new class? Y/N");
			if (Console.ReadLine().ToLower() == "y"){
				goto NewClass;
			}
		}

		static string LetterGrade(int gradeNum){
			if (gradeNum > 89){
				return "A";
			}else if (gradeNum > 80){
				return "B";
			}else if (gradeNum > 70){
				return "C";
			}else if (gradeNum > 60){
				return "D";
			}else{
				return "F";
			}
		}
	}
}
