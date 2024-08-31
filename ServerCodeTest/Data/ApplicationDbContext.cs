using Microsoft.EntityFrameworkCore;
using ServerCodeTest.Models;

namespace ServerCodeTest.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<_dbo_technicians> technicians { get; set; }
    public DbSet<_dbo_workorders> workorders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<_dbo_technicians>().HasData(
            new _dbo_technicians
            {
                technicianid = 5,
                technicianname = "Dwight Schrute",
                technicianemail = "dschrute@dundermifflin.com"
            },
            new _dbo_technicians
            {
                technicianid = 6,
                technicianname = "Michael Scott",
                technicianemail = "mscott@dundermifflin.com"
            },
            new _dbo_technicians
            {
                technicianid = 8,
                technicianname = "Creed",
                technicianemail = "creed@dundermifflin.com"
            }
        );

        modelBuilder.Entity<_dbo_workorders>().HasData(
            new _dbo_workorders
            {
                wonum = 2,
                email = "oscar@lakecountyfl.gov",
                status = "Closed",
                datereceived = new System.DateTime(2014, 09, 10, 00, 00, 00),
                dateassigned = new System.DateTime(2014, 09, 11, 00, 00, 00),
                datecomplete = new System.DateTime(2014, 09, 13, 00, 00, 00),
                contactname = "Oscar",
                techniciancomments = "Fax has been disconnected. Uses too much power.",
                contactnumber = "555-456-0003",
                technicianid = 5,
                problem = "Fax not working."
            },
            new _dbo_workorders
            {
                wonum = 3,
                email = "jharper@dundermifflin.com",
                status = "Closed",
                datereceived = new System.DateTime(2014, 09, 04, 00, 00, 00),
                dateassigned = new System.DateTime(2014, 09, 05, 00, 00, 00),
                datecomplete = new System.DateTime(2014, 09, 08, 00, 00, 00),
                contactname = "Jim Harper",
                techniciancomments = "Problem solved.",
                contactnumber = "555-456-0002",
                technicianid = 5,
                problem = "Unable to call Pam"
            },
            new _dbo_workorders
            {
                wonum = 4,
                email = "pharper@dundermifflin.com",
                status = "Assigned",
                datereceived = new System.DateTime(2014, 09, 02, 00, 00, 00),
                dateassigned = new System.DateTime(2014, 09, 02, 00, 00, 00),
                contactname = "Pam Harper",
                contactnumber = "555-456-0001",
                technicianid = 6,
                problem = "Unable to call Jim"
            },
            new _dbo_workorders
            {
                wonum = 5,
                email = "pharper@dundermifflin.com",
                status = "Assigned",
                datereceived = new System.DateTime(2014, 09, 03, 00, 00, 00),
                dateassigned = new System.DateTime(2014, 09, 03, 00, 00, 00),
                contactname = "Pam Harper",
                contactnumber = "555-456-0001",
                technicianid = 7,
                problem = "Phone is turning off."
            },
            new _dbo_workorders
            {
                wonum = 6,
                email = "creed@lakecountyfl.gov",
                status = "Assigned",
                datereceived = new System.DateTime(2014, 09, 02, 00, 00, 00),
                contactname = "Creed",
                contactnumber = "555-456-0004",
                technicianid = 7,
                problem = "Voicemail message is me. Need to change to me."
            },
            new _dbo_workorders
            {
                wonum = 7,
                email = "oscar@dundermifflin.com",
                status = "Assigned",
                datereceived = new System.DateTime(2014, 09, 01, 00, 00, 00),
            }
        );
    }
}