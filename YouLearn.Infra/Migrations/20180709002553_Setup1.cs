using Microsoft.EntityFrameworkCore.Migrations;

namespace YouLearn.Infra.Migrations
{
    public partial class Setup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playList_Usuario_IdUsuario",
                table: "playList");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_playList_IdPlayList",
                table: "Video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_playList",
                table: "playList");

            migrationBuilder.RenameTable(
                name: "playList",
                newName: "PlayList");

            migrationBuilder.RenameIndex(
                name: "IX_playList_IdUsuario",
                table: "PlayList",
                newName: "IX_PlayList_IdUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayList",
                table: "PlayList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayList_Usuario_IdUsuario",
                table: "PlayList",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_PlayList_IdPlayList",
                table: "Video",
                column: "IdPlayList",
                principalTable: "PlayList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayList_Usuario_IdUsuario",
                table: "PlayList");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_PlayList_IdPlayList",
                table: "Video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayList",
                table: "PlayList");

            migrationBuilder.RenameTable(
                name: "PlayList",
                newName: "playList");

            migrationBuilder.RenameIndex(
                name: "IX_PlayList_IdUsuario",
                table: "playList",
                newName: "IX_playList_IdUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_playList",
                table: "playList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_playList_Usuario_IdUsuario",
                table: "playList",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_playList_IdPlayList",
                table: "Video",
                column: "IdPlayList",
                principalTable: "playList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
