using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIExercise.Migrations
{
    public partial class TestRelacionesDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if(ActiveProvider == "Microsoft.EntityFrameworkCore.Sqlite"){
                
                migrationBuilder.DropTable(name: "Comments");

                migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Autor = table.Column<string>(maxLength: 10, nullable: false),
                    Body = table.Column<string>(maxLength: 30, nullable: true),
                    PostId = table.Column<long>(nullable: false,defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    
                    /* 
                    table.CreateIndex(
                        "IX_Comments_PostId",
                        table: "Comments",
                        column: "PostId"
                    );
                    */
                   
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        //column: "PostId",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                });


            }else{
                migrationBuilder.AddColumn<long>(
                    name: "PostId",
                    table: "Comments",
                    nullable: false,
                    defaultValue: 0L);

                migrationBuilder.CreateIndex(
                    name: "IX_Comments_PostId",
                    table: "Comments",
                    column: "PostId");

                migrationBuilder.AddForeignKey(
                    name: "FK_Comments_Posts_PostId",
                    table: "Comments",
                    column: "PostId",
                    principalTable: "Posts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            }
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Comments");
        }
    }
}
