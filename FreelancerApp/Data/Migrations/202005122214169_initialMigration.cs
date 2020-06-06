namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPost", "EmployerId", c => c.Int(nullable: false));
            AddColumn("dbo.JobPost", "FreelancerId", c => c.Int(nullable: false));
            AddColumn("dbo.Message", "EmployerId", c => c.Int(nullable: false));
            AddColumn("dbo.Message", "FreelancerId", c => c.Int(nullable: false));
            CreateIndex("dbo.JobPost", "EmployerId");
            CreateIndex("dbo.JobPost", "FreelancerId");
            CreateIndex("dbo.Message", "EmployerId");
            CreateIndex("dbo.Message", "FreelancerId");
            AddForeignKey("dbo.JobPost", "EmployerId", "dbo.Employer", "EmployerId", cascadeDelete: true);
            AddForeignKey("dbo.JobPost", "FreelancerId", "dbo.Freelancer", "FreelancerId", cascadeDelete: true);
            AddForeignKey("dbo.Message", "EmployerId", "dbo.Employer", "EmployerId", cascadeDelete: true);
            AddForeignKey("dbo.Message", "FreelancerId", "dbo.Freelancer", "FreelancerId", cascadeDelete: true);
            DropColumn("dbo.JobPost", "OwnerId");
            DropColumn("dbo.JobPost", "FreelancerIdAwarded");
            DropColumn("dbo.Message", "Sender");
            DropColumn("dbo.Message", "Recipient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "Recipient", c => c.Int(nullable: false));
            AddColumn("dbo.Message", "Sender", c => c.String());
            AddColumn("dbo.JobPost", "FreelancerIdAwarded", c => c.Int(nullable: false));
            AddColumn("dbo.JobPost", "OwnerId", c => c.String());
            DropForeignKey("dbo.Message", "FreelancerId", "dbo.Freelancer");
            DropForeignKey("dbo.Message", "EmployerId", "dbo.Employer");
            DropForeignKey("dbo.JobPost", "FreelancerId", "dbo.Freelancer");
            DropForeignKey("dbo.JobPost", "EmployerId", "dbo.Employer");
            DropIndex("dbo.Message", new[] { "FreelancerId" });
            DropIndex("dbo.Message", new[] { "EmployerId" });
            DropIndex("dbo.JobPost", new[] { "FreelancerId" });
            DropIndex("dbo.JobPost", new[] { "EmployerId" });
            DropColumn("dbo.Message", "FreelancerId");
            DropColumn("dbo.Message", "EmployerId");
            DropColumn("dbo.JobPost", "FreelancerId");
            DropColumn("dbo.JobPost", "EmployerId");
        }
    }
}
