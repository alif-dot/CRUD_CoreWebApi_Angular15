using CRUDinCoreAngular.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDinCoreAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Context _context;
        public StudentController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetStudent")]
        [EnableCors("http://localhost:4200")]
        public async Task<IEnumerable<Student>> GetStudent()
        {
            return await _context.Student.ToListAsync();
        }

        [HttpPost]
        [Route("AddStudent")]
        [EnableCors("http://localhost:4200")]
        public async Task<Student> AddStudent(Student std)
        {
            _context.Student.Add(std);
            await _context.SaveChangesAsync();
            return std;
        }

        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        [EnableCors("http://localhost:4200")]
        public async Task<Student> UpdateStudent(Student std)
        {
            _context.Entry(std).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return std;
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        [EnableCors("http://localhost:4200")]
        public bool DeleteStudent(int id)
        {
            bool a = false;
            var student = _context.Student.Find(id);
            if (student != null)
            {
                a = true;
                _context.Entry(student).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;
        }

    }
}
