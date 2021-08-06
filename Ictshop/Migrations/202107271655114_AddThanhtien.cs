namespace Ictshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThanhtien : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chitietdonhang",
                c => new
                    {
                        Madon = c.Int(nullable: false),
                        Masp = c.Int(nullable: false),
                        Soluong = c.Int(),
                        Dongia = c.Decimal(precision: 18, scale: 0),
                        Thanhtien = c.Double(),
                    })
                .PrimaryKey(t => new { t.Madon, t.Masp })
                .ForeignKey("dbo.Donhang", t => t.Madon)
                .ForeignKey("dbo.Sanpham", t => t.Masp)
                .Index(t => t.Madon)
                .Index(t => t.Masp);
            
            CreateTable(
                "dbo.Donhang",
                c => new
                    {
                        Madon = c.Int(nullable: false, identity: true),
                        Ngaydat = c.DateTime(),
                        Tinhtrang = c.Int(),
                        MaNguoidung = c.Int(),
                    })
                .PrimaryKey(t => t.Madon)
                .ForeignKey("dbo.Nguoidung", t => t.MaNguoidung)
                .Index(t => t.MaNguoidung);
            
            CreateTable(
                "dbo.Nguoidung",
                c => new
                    {
                        MaNguoiDung = c.Int(nullable: false, identity: true),
                        Hoten = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Dienthoai = c.String(maxLength: 10, fixedLength: true),
                        Matkhau = c.String(maxLength: 50, unicode: false),
                        IDQuyen = c.Int(),
                        Diachi = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MaNguoiDung)
                .ForeignKey("dbo.PhanQuyen", t => t.IDQuyen)
                .Index(t => t.IDQuyen);
            
            CreateTable(
                "dbo.PhanQuyen",
                c => new
                    {
                        IDQuyen = c.Int(nullable: false, identity: true),
                        TenQuyen = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IDQuyen);
            
            CreateTable(
                "dbo.Sanpham",
                c => new
                    {
                        Masp = c.Int(nullable: false, identity: true),
                        Tensp = c.String(maxLength: 50),
                        Giatien = c.Decimal(precision: 18, scale: 0),
                        Soluong = c.Int(),
                        Mota = c.String(storeType: "ntext"),
                        Thesim = c.Int(),
                        Bonhotrong = c.Int(),
                        Sanphammoi = c.Boolean(),
                        Ram = c.Int(),
                        Anhbia = c.String(maxLength: 10),
                        Mahang = c.Int(),
                        Mahdh = c.Int(),
                    })
                .PrimaryKey(t => t.Masp)
                .ForeignKey("dbo.Hangsanxuat", t => t.Mahang)
                .ForeignKey("dbo.Hedieuhanh", t => t.Mahdh)
                .Index(t => t.Mahang)
                .Index(t => t.Mahdh);
            
            CreateTable(
                "dbo.Hangsanxuat",
                c => new
                    {
                        Mahang = c.Int(nullable: false, identity: true),
                        Tenhang = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Mahang);
            
            CreateTable(
                "dbo.Hedieuhanh",
                c => new
                    {
                        Mahdh = c.Int(nullable: false, identity: true),
                        Tenhdh = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Mahdh);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sanpham", "Mahdh", "dbo.Hedieuhanh");
            DropForeignKey("dbo.Sanpham", "Mahang", "dbo.Hangsanxuat");
            DropForeignKey("dbo.Chitietdonhang", "Masp", "dbo.Sanpham");
            DropForeignKey("dbo.Nguoidung", "IDQuyen", "dbo.PhanQuyen");
            DropForeignKey("dbo.Donhang", "MaNguoidung", "dbo.Nguoidung");
            DropForeignKey("dbo.Chitietdonhang", "Madon", "dbo.Donhang");
            DropIndex("dbo.Sanpham", new[] { "Mahdh" });
            DropIndex("dbo.Sanpham", new[] { "Mahang" });
            DropIndex("dbo.Nguoidung", new[] { "IDQuyen" });
            DropIndex("dbo.Donhang", new[] { "MaNguoidung" });
            DropIndex("dbo.Chitietdonhang", new[] { "Masp" });
            DropIndex("dbo.Chitietdonhang", new[] { "Madon" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Hedieuhanh");
            DropTable("dbo.Hangsanxuat");
            DropTable("dbo.Sanpham");
            DropTable("dbo.PhanQuyen");
            DropTable("dbo.Nguoidung");
            DropTable("dbo.Donhang");
            DropTable("dbo.Chitietdonhang");
        }
    }
}
