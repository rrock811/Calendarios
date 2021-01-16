using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slaves.Web.Models
{
	public class StudentDiscipline
	{
		public StudentDiscipline()
		{

		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

		public string StudentId { get; set; }
		public Student Student { get; set; }

		public string DisciplineId { get; set; }
		public Discipline Discipline { get; set; }
	}
}
