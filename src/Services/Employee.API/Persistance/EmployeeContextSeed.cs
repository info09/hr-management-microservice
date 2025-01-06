using Employee.API.Entities;
using ILogger = Serilog.ILogger;

namespace Employee.API.Persistance
{
    public class EmployeeContextSeed
    {
        public static async Task SeedEmployeeAsync(EmployeeContext employeeContext, ILogger logger)
        {
            if (!employeeContext.Departments.Any())
            {
                employeeContext.AddRange(getDepartments());
                await employeeContext.SaveChangesAsync();
                logger.Information("Seeded data for Department associated with context {DbContextName}",
                    nameof(EmployeeContext));
            }

            if (!employeeContext.Positions.Any())
            {
                employeeContext.AddRange(getPositions());
                await employeeContext.SaveChangesAsync();
                logger.Information("Seeded data for Position associated with context {DbContextName}",
                    nameof(EmployeeContext));
            }
        }

        private static IEnumerable<Departments> getDepartments()
        {
            return new List<Departments>
        {
            new()
            {
                DepartmentName = "IT"
            }
        };
        }

        private static IEnumerable<Positions> getPositions()
        {
            return new List<Positions>
        {
            new()
            {
                PositionName = "Dev"
            },
            new()
            {
                PositionName = "Test"
            }
        };
        }
    }
}
