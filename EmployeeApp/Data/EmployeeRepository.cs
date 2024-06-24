
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace EmployeeApp.Data
    
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }


        //POST API
        public async Task AddEmployee(Employee employee)
        {
            await _appDbContext.Set<Employee>().AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
        }

        //GET all employees
        public async Task<List<Employee>> GetAllEmployee()
        {
            return await _appDbContext.Employees.ToListAsync();

        }
        //get employee By Id 

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _appDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("no employee Found");
            }
            return employee;
        }

        //delete employee by id 
        public async Task DeleteEmployee(int id)
        {
            var employee = await _appDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("no employee Found");
            }
            _appDbContext.Employees.Remove(employee);
            await _appDbContext.SaveChangesAsync();

        }
        //Edit employee By Id 

        public async Task UpdateEmployee(int id , Employee emp)
        {
            var employee = await _appDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("no employee Found");
            }

            employee.Name = emp.Name;
           // employee.Email = emp.Email;
            employee.Salary = emp.Salary;
            employee.Phone = emp.Phone;
           employee.Age = emp.Age;

          //  _appDbContext.Employees.Remove(employee);
            await _appDbContext.SaveChangesAsync();

        }


    }
}
