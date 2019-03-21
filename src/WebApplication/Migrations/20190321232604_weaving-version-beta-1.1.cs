﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DanLiris.Admin.Web.Migrations
{
    public partial class weavingversionbeta11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weaving_MachineTypeDocuments",
                columns: table => new
                {
                    Identity = table.Column<Guid>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 32, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 32, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 32, nullable: true),
                    TypeName = table.Column<string>(maxLength: 255, nullable: true),
                    Speed = table.Column<int>(nullable: false),
                    MachineUnit = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weaving_MachineTypeDocuments", x => x.Identity);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weaving_MachineTypeDocuments");
        }
    }
}
