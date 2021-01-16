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

		public IActionResult Index()
		{
			var students = _context.Students.ToList();
			return View(students);
		}
	}
}
