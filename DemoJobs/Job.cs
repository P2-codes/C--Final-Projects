using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJobs
{
	internal class Job
	{
		string customer;
		string description;
		double hour;
		double hourRate;
		double totalFee;

		public Job(string customer,string description,double hour,double hourRate)
		{
			this.customer = customer;
			this.description = description;
			this.hour = hour;
			this.hourRate = hourRate;
			totalFee= hourRate*hour;
		}
		public Job()
		{
			description = "";
			hour = 0;
			hourRate = 0;
			totalFee = 0;
		}
		public string GetCustomer() 
		{
			return customer; 
		}
		public void SetDescription(string description)
		{
			this.description = description;
		}
		public void SetHours(double hour)
		{
			this.hour= hour;
			totalFee= CalcFee(hour, hourRate);
		}
		public void SetHourRate(double hourRate)
		{
			this.hourRate= hourRate;
			totalFee=CalcFee(this.hourRate,hourRate);
		}
		private double CalcFee(double hour, double hourRate)
		{
			double totalFee = hour*hourRate;
			return totalFee;
		}
		public void DisplayJob()
		{
			Console.WriteLine("Job: {0} for {1} hours @ {2:C} per hour, total of {3:C}",description,hour,hourRate,totalFee);
		}
	}
}
