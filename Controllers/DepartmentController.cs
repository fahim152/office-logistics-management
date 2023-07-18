using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using mlbd_logistics_management.Models;
using mlbd_logistics_management.Services;

namespace mlbd_logistics_management.Controllers;

[ApiController]
[Route("api/{controller}")]
public class DepartmentController : ControllerBase
{
    private DepartmentService _departmentService;

    public DepartmentController(DepartmentService departmentService)
    {
        this._departmentService = departmentService;
    }

    // GET: api/Department
    [HttpGet]
    public ActionResult<IEnumerable<Department>> GetDepartments()
    {
        var departments = _departmentService.GetAllDepartments();
        return Ok(departments);
    }

    // GET: api/Department/5
    [HttpGet("{id}")]
    public ActionResult<Department> GetDepartmentById(int id)
    {
        var department = _departmentService.GetDepartmentById(id);
        if (department == null)
        {
            return NotFound();
        }

        return Ok(department);
    }

    // POST: api/Department
    [HttpPost]
    public ActionResult<Department> CreateDepartment(Department department)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _departmentService.CreateDepartment(department);
        return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
    }

    // PUT: api/Department/5
    [HttpPut("{id}")]
    public IActionResult UpdateDepartment(int id, Department department)
    {
        if (id != department.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _departmentService.UpdateDepartment(department);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDepartment(int id)
    {
        try
        {
            _departmentService.DeleteDepartment(id);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }

        return NoContent();
    }
}   