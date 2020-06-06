namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedFreelancerIDfromPost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobPost", "FreelancerId", "dbo.Freelancer");
            DropIndex("dbo.JobPost", new[] { "FreelancerId" });
            DropColumn("dbo.JobPost", "FreelancerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobPost", "FreelancerId", c => c.Int(nullable: false));
            CreateIndex("dbo.JobPost", "FreelancerId");
            AddForeignKey("dbo.JobPost", "FreelancerId", "dbo.Freelancer", "FreelancerId", cascadeDelete: true);
        }
    }
}
