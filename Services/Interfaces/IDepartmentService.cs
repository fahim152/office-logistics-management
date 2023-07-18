using mlbd_logistics_management.Models;

namespace mlbd_logistics_management.Services.Interfaces;

public interface IDepartmentService
{
    IEnumerable<Department> GetAllDepartments();
    Department GetDepartmentById(int id);
    void CreateDepartment(Department department);
    void UpdateDepartment(Department department);
    void DeleteDepartment(int id);
}
