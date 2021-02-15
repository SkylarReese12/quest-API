using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using questAPI.DataLogic;

namespace questAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {

        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentsRepo _studentsRepo;

        public StudentsController(ILogger<StudentsController> logger, IStudentsRepo studentsRepo)
        {
            _logger = logger;
            _studentsRepo = studentsRepo;

        }

        // GET ALL STUDENTS
        [HttpGet]
        public IEnumerable<Model.Student> GetAllStudents()
        {
            return _studentsRepo.GetAllStudents();
        }
    }
}
