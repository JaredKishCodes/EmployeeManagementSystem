using EmployeeManagements.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.API.Data.Config
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.HasKey(x => x.DepartmentId);
            builder.Property(x => x.DepartmentId).UseIdentityColumn();

            builder.Property(x => x.DepartmentName).IsRequired();

            builder.HasData(new List<Department>
            {
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "IT",
                },
                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "HR",
                },
                new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "Payroll",
                },
                new Department
                {
                    DepartmentId = 4,
                    DepartmentName = "Admin",
                },
            });
        }
    }
}