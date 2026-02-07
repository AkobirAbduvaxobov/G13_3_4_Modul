using SocialMedia.Api.Dtos;

namespace SocialMedia.Api.Services;

public class EmployeeService
{
    private readonly List<EmployeeDto> EmployeeDtos;
    public EmployeeService()
    {
        EmployeeDtos = GetEmployees();
    }


    public List<EmployeeDto> GetEmployyesWhoHasMoreSalaryThen(decimal salary)
    {
        return EmployeeDtos.Where(e => e.Salary > salary).ToList(); 
    }

    public int GetCountEmployyesWhoHasMoreSalaryThen(decimal salary)
    {
        return EmployeeDtos.Count(e => e.Salary > salary);
    }

    public decimal GetTotalSalary()
    {
        return EmployeeDtos.Sum(e => e.Salary);
    }

    public decimal GetMinSalary()
    {
        return EmployeeDtos.Min(e => e.Salary);
    }

    public decimal GetMaxSalary()
    {
        return EmployeeDtos.Max(e => e.Salary);
    }

    public decimal GetAverageSalary()
    {
        return EmployeeDtos.Average(e => e.Salary);
    }



    private List<EmployeeDto> GetEmployees()
    {
        return new List<EmployeeDto>
    {
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 3500m,
            Age = 24,
            Job = "Junior Software Developer"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 5200m,
            Age = 28,
            Job = "Software Engineer"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 7800m,
            Age = 34,
            Job = "Senior Developer"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 9000m,
            Age = 38,
            Job = "Tech Lead"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 11000m,
            Age = 42,
            Job = "IT Manager"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 4000m,
            Age = 25,
            Job = "QA Engineer"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 4500m,
            Age = 27,
            Job = "Business Analyst"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 6000m,
            Age = 31,
            Job = "DevOps Engineer"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 4800m,
            Age = 26,
            Job = "UI/UX Designer"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 5000m,
            Age = 29,
            Job = "Mobile App Developer"
        },

        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 7200m,
            Age = 33,
            Job = "Backend Developer"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 6800m,
            Age = 32,
            Job = "Frontend Developer"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 8500m,
            Age = 36,
            Job = "System Architect"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 9500m,
            Age = 40,
            Job = "Project Manager"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 4200m,
            Age = 24,
            Job = "Technical Support"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 3900m,
            Age = 23,
            Job = "Intern Developer"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 5600m,
            Age = 30,
            Job = "Data Analyst"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 8300m,
            Age = 35,
            Job = "Security Engineer"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 6100m,
            Age = 31,
            Job = "Database Administrator"
        },
        new EmployeeDto
        {
            EmployeeId = Guid.NewGuid(),
            Salary = 4700m,
            Age = 27,
            Job = "HR Specialist"
        }
    };
    }

}
