using Microsoft.AspNetCore.Mvc;

namespace mvcapi.Controllers
{
    public class Apicontroller : Controller
    {
        private readonly RecordStoreContext recordStoreContext;
        public Apicontroller(RecordStoreContext newRecordStoreContext)
        {
            recordStoreContext = newRecordStoreContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public Employee GetEmployee()
        {
            var newEmployee = new Employee();
            newEmployee.FirstName = "Supreme Leader";
            newEmployee.LastName = "Dominion Burch";
            newEmployee.ID = 15;
            return newEmployee; 
        }

        public int GetNoEmployee()
        {
            return recordStoreContext.Employee.Count();
        }

        public Employee[] GetAllEmployees()
        {
            return recordStoreContext.Employee.ToArray();
        }

        public string ExampleString()
        {
            return "This is a raw string returned from a controller method";
        }

        [HttpPost]
        public void ChangeLastName(int targetId, string newLastName)
        {
            Employee targetEmployee = null;
            foreach (var currEmployeeRecord in recordStoreContext.Employee)
            {
                if (currEmployeeRecord.ID == targetId)
                {
                    targetEmployee = currEmployeeRecord;
                    break;
                }
            }

            if (targetEmployee != null)
            {
                targetEmployee.LastName = newLastName;
                recordStoreContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Could not find an employee with ID {targetId}");
            }
        }
    }
}
