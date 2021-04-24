using System;
using System.Collections.Generic;

namespace DependencyInjection
{
    public class EmployeeBL
    {
        internal EmployeeDAL employeeDataObject;
        private IEmployeeDAL employeeDAL;
        public IEmployeeDAL EmployeeDataObject
        {
            set
            {
                //In Property Dependency Injection, we need to supply the dependency object through
                //a public property of the client class. 
                this.employeeDAL = value;
            }
            get
            {
                if (EmployeeDataObject == null)
                {
                    throw new Exception("Employee is not initialized");
                }
                else
                {
                    return employeeDAL;
                }
            }
        }
        public List<Employee> GetAllEmployees()
        {
            return employeeDAL.SelectAllEmployees();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeBL employeeBL = new EmployeeBL();
            //inject the object through a property
            employeeBL.employeeDataObject = new EmployeeDAL();

            List<Employee> ListEmployee = employeeBL.GetAllEmployees();
            foreach (Employee emp in ListEmployee)
            {
                Console.WriteLine("ID = {0}, Name = {1}, Department = {2}", emp.ID, emp.Name, emp.Department);
            }
            Console.ReadKey();
        }

    }
}
