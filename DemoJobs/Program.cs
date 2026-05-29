using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DemoJobs
{
	internal class Program
	{
		const int SIZE = 10;
		static void Main(string[] args)
		{
			Job[] jobList=new Job[SIZE];
			int nrEl = 0;

			string wantedCust;
			Console.Write("How many jobs do you need to record: ");
			int numJob=int.Parse(Console.ReadLine());

			for(int x=0;x<numJob;x++)
			{
				AddJob(jobList,ref nrEl);
			}

			UpdateHours(jobList,nrEl,out wantedCust);

			DisplayJob(jobList,nrEl);

			Console.ReadLine();
		}
		static void AddJob(Job[] jobList, ref int nrEl)
		{
			Console.Write("Customer name: ");
			string name = Console.ReadLine();

			Console.Write("Job description: ");
			string description = Console.ReadLine();

			Console.Write("Time to complete: ");
			double hours = double.Parse(Console.ReadLine());

			Console.Write("Hourly rate: ");
			double rate = double.Parse(Console.ReadLine());

			jobList[nrEl]=new Job(name, description, hours, rate);
			nrEl++;
		}
		static void UpdateHours(Job[] jobList,int nrEl,out string wantedCust)
		{
			Console.Write("Enter the name of the customer for whom the hours needs to be updated: ");
			wantedCust=Console.ReadLine();

			int pos=Find(jobList,nrEl, wantedCust);
			if(pos>=0)
			{
				Console.Write("Enter the updated hours: ");
				double hours =double.Parse(Console.ReadLine());
				jobList[pos].SetHours(hours);
			}
			else
			{
				Console.WriteLine("The customer does not exist.");
			}
		}
		static int Find(Job[] jobList,int nrEl,string wantedCust)
		{
			int pos = -1;
			bool found = false;
			int counter = 0;
			
			while(found==false&&counter<nrEl)
			{
				if (jobList[counter].GetCustomer()==wantedCust)
				{
					pos = counter;
					found = true;
				}
				counter++;
			}
			return pos;
		}
		static void DisplayJob(Job[] jobList,int nrEl)
		{
			for (int x = 0; x < nrEl; x++)
			{
				jobList[x].DisplayJob();
			}

		}
	}
}
