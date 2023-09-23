namespace NwindMVC.Models
{
    public class RepositoryEmployee
    {
        private NorthWindContext _context; //iniatiated is very importent
        public RepositoryEmployee(NorthWindContext context)
        {
            _context = context;
        }
        public  List<Employee> AllEmployees()
        {
           return _context.Employees.ToList(); 
        }
    }
}
