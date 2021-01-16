using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Slaves.Web.Data;
using Slaves.Web.Models;

namespace Slaves.Web.Controllers
{
	[Authorize]
	public class StudentsController : Controller
	{
		private readonly ILogger<StudentsController> _logger;
		private readonly ApplicationDbContext _context;

		public StudentsController(ILogger<StudentsController> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var students = _context.Students.ToList();
			return View(students);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View(new Student());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Student student)
		{
			if (ModelState.IsValid)
			{
				try
				{
					if (student.LastName.Length < 2)
						throw new Exception("Фамилия не может соджержать менее 2 символов");

					_context.Students.Add(student);
					_context.SaveChanges();

					return RedirectToAction("Index");
				}
				catch (Exception e)
				{
					ModelState.AddModelError("", e.Message);
				}
			}

			return View(student);
		}

		[HttpGet]
		public IActionResult Update(string id)
		{
			var student = _context.Students.Single(s => s.Id == id);
			return View(student);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(Student student)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var existStudent = _context.Students.FirstOrDefault(s => s.Id == student.Id);
					if (existStudent == null)
						throw new Exception("Студент для редактирования не найден");

					if (student.LastName.Length < 2)
						throw new Exception("Фамилия не может соджержать менее 2 символов");

					_context.Entry(existStudent).CurrentValues.SetValues(student);
					_context.SaveChanges();

					return RedirectToAction("Index");
				}
				catch (Exception e)
				{
					ModelState.AddModelError("", e.Message);
				}
			}

			return View(student);
		}

		[HttpGet]
		public IActionResult Delete(string id)
		{
			var student = _context.Students.Single(s => s.Id == id);
			return View(student);
		}

		[HttpPost]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(string id)
		{
			var existStudent = _context.Students.FirstOrDefault(s => s.Id == id);
			_context.Students.Remove(existStudent);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}
