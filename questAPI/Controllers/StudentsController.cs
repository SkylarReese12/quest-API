using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using questAPI.DataLogic;
using questAPI.Model;

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

        // GET STUDENTS BY SCHOOL ID
        [HttpGet]
        [Route("school/{id}")]
        public IEnumerable<Model.Student> GetStudentsBySchoolID(int ID)
        {
            return _studentsRepo.GetStudentsBySchool(ID);
        }
        // GET STUDENTS WHO SUBMITTED FORM 
        [HttpGet]
        [Route("forms/submitted")]
        public IEnumerable<Model.Student> GetStudentsByForm()
        {
            return _studentsRepo.GetStudentsByForm();
        }

        // GET STUDENTS WHO HAVE NOT SUBMITTED FORM 
        [HttpGet]
        [Route("forms/unsubmitted")]
        public IEnumerable<Model.Student> GetStudentsByNoForm()
        {
            return _studentsRepo.GetStudentsByNoForm();
        }

        // PATCH STUDENT FORM FLAG
        [HttpPatch]
        [Route("{id}")]
        public void UpdateStudentFormFlag(int id, [FromBody]UpdateStudent updater)
        {
            _studentsRepo.UpdateStudentFormFlag(id, updater);
        }

    }
}
