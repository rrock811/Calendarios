using System;
using System.ComponentModel.DataAnnotations;

namespace Slaves.Web.Models
{
	public class Student
	{
		public Student()
		{

		}

		public string Id { get; set; }

		[Display(Name = "Фамилия")]
		public string LastName { get; set; }

		[Display(Name = "Имя")]
		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public DateTime DateBirth { get; set; }

		public string FullName
		{
			get
			{
				return $"{LastName} {FirstName} {MiddleName}";
			}
		}

		public string GetFullName()
		{
			return FullName;
		}
	}
}
