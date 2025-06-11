namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_skill_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserImage = c.String(maxLength: 1000),
                        UserNameSurname = c.String(maxLength: 500),
                        Title = c.String(maxLength: 100),
                        SkillName1 = c.String(maxLength: 100),
                        SkillValue1 = c.String(),
                        SkillName2 = c.String(maxLength: 100),
                        SkillValue2 = c.String(),
                        SkillName3 = c.String(maxLength: 100),
                        SkillValue3 = c.String(),
                        SkillName4 = c.String(maxLength: 100),
                        SkillValue4 = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skills");
        }
    }
}
