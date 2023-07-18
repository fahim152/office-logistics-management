using mlbd_logistic_management.Data;
using mlbd_logistics_management.Models;
using mlbd_logistics_management.Services.Interfaces;

namespace mlbd_logistics_management.Services;

public class DepartmentService: IDepartmentService
{
    private readonly MlbdLogisticManagementContext _dbContext;

    public DepartmentService(MlbdLogisticManagementContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _dbContext.Departments.ToList();
    }

    public Department GetDepartmentById(int id)
    {
        return _dbContext.Departments.FirstOrDefault(d => d.Id == id);
    }

    public void CreateDepartment(Department department)
    {
        if (department == null)
        {
            throw new ArgumentNullException(nameof(department));
        }

        _dbContext.Departments.Add(department);
        _dbContext.SaveChanges();
    }

    public void UpdateDepartment(Department department)
    {
        if (department == null)
        {
            throw new ArgumentNullException(nameof(department));
        }

        var existingDepartment = _dbContext.Departments.FirstOrDefault(d => d.Id == department.Id);
        if (existingDepartment == null)
        {
            throw new ArgumentException("Department not found.");
        }

        // Update the properties of the existingDepartment with the values from the input department
        existingDepartment.Name = department.Name;
        existingDepartment.OfficeName = department.OfficeName;

        _dbContext.SaveChanges();
    }

    public void DeleteDepartment(int id)
    {
        var departmentToDelete = _dbContext.Departments.FirstOrDefault(d => d.Id == id);
        if (departmentToDelete != null)
        {
            _dbContext.Departments.Remove(departmentToDelete);
            _dbContext.SaveChanges();
        }
    }
}