using System;
using WiredBrainCoffee.StorageApp.Repositories;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Data;

namespace WiredBrainCoffee.StorageApp {
    class Programm{
        static void Main(string[] args) {
            
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            employeeRepository.itemAdded += EmployeeRepository_ItemAdded;

            AddEmployees(employeeRepository);
            AddMangers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            var organizationRepo = new ListRepository<Organization>();
            AddOrganizations(organizationRepo);
            WriteAllToConsole(organizationRepo);

            Console.ReadLine();
        }

        private static void EmployeeRepository_ItemAdded(object? sender, Employee e)
        {
            Console.WriteLine($"Employee added => {e.FirstName}");
        }

        private static void AddMangers(IWriteRepository<Manager> manager) {
            var msManager = new Manager { FirstName = "MS" };
            var msManagerCopy = msManager.Copy<Manager>();

            if (msManager is not null){
                msManagerCopy.FirstName += "_Copy";
                manager.Add(msManagerCopy);
                //Lost
            }
            manager.Add(msManager);
            manager.Add(new Manager {FirstName = "Xaba"});
            manager.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository) {
            var items = repository.GetAll();
            foreach(var item in items){
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository) {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository) {
            var employees = new[]{
                new Employee { FirstName = "Mcebo" },
                new Employee { FirstName = "Owethu" },
                new Employee { FirstName = "Samuel" }
            };
            employeeRepository.addBatch(employees);
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepo) {
            var organizations = new[] {
                new Organization { Name = "PluralSight" },
                new Organization { Name = "Global" },
                new Organization { Name = "Safe" }
            };
            organizationRepo.addBatch(organizations);
        }
    }
}
