using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slaves.Web.Models
{
	public class Student
	{
		public Student()
		{
			DateBirth = new DateTime(2000, 1, 1);
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

		[Display(Name = "Фамилия")]
		[Required]
		public string LastName { get; set; }

		[Display(Name = "Имя")]
		[Required]
		public string FirstName { get; set; }

		[Display(Name = "Отчество")]
		public string MiddleName { get; set; }

		[Display(Name = "ДР")]
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
