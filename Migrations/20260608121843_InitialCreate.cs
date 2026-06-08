using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungMoHinh.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaiNguyens3D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DefaultDiemGan = table.Column<int>(type: "int", nullable: false),
                    DuongDanFile = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AnhDaiDienUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    KetCauUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MauSacMacDinh = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    SupportsPartAdjustment = table.Column<bool>(type: "bit", nullable: false),
                    IsUserGenerated = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiNguyens3D", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MauNhanVats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Kind = table.Column<int>(type: "int", nullable: false),
                    Style = table.Column<int>(type: "int", nullable: false),
                    ModelUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AnhDaiDienUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauNhanVats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThamSoTuyChinhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    TenHienThi = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    TargetMeshNodeName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    GiaTriNhoNhat = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    GiaTriLonNhat = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    GiaTriMacDinh = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThamSoTuyChinhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoSoNguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TenHienThi = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoNguoiDungs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiemChinhPhuKiens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiNguyen3DId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    MeshNodeName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    GiaTriNhoNhat = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    GiaTriLonNhat = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    GiaTriMacDinh = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemChinhPhuKiens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiemChinhPhuKiens_TaiNguyens3D_TaiNguyen3DId",
                        column: x => x.TaiNguyen3DId,
                        principalTable: "TaiNguyens3D",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoiMauThietLaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Kind = table.Column<int>(type: "int", nullable: false),
                    Style = table.Column<int>(type: "int", nullable: false),
                    MauNhanVatId = table.Column<int>(type: "int", nullable: true),
                    AnhDaiDienUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DefaultSettingsJson = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoiMauThietLaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoiMauThietLaps_MauNhanVats_MauNhanVatId",
                        column: x => x.MauNhanVatId,
                        principalTable: "MauNhanVats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NhanVats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    HoSoNguoiDungId = table.Column<int>(type: "int", nullable: true),
                    MauNhanVatId = table.Column<int>(type: "int", nullable: true),
                    Kind = table.Column<int>(type: "int", nullable: false),
                    Style = table.Column<int>(type: "int", nullable: false),
                    CheDoHienThi = table.Column<int>(type: "int", nullable: false),
                    AnhDaiDienUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AnhXemTruocUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanVats_MauNhanVats_MauNhanVatId",
                        column: x => x.MauNhanVatId,
                        principalTable: "MauNhanVats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhanVats_HoSoNguoiDungs_HoSoNguoiDungId",
                        column: x => x.HoSoNguoiDungId,
                        principalTable: "HoSoNguoiDungs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaiNguyenNhanVats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVatId = table.Column<int>(type: "int", nullable: false),
                    TaiNguyen3DId = table.Column<int>(type: "int", nullable: false),
                    DiemGan = table.Column<int>(type: "int", nullable: false),
                    TenDiemGanTuyChinh = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ViTriX = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ViTriY = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ViTriZ = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    XoayX = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    XoayY = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    XoayZ = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    TiLeX = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    TiLeY = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    TiLeZ = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    MauSac = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    DoKimLoai = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    DoNham = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiNguyenNhanVats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiNguyenNhanVats_TaiNguyens3D_TaiNguyen3DId",
                        column: x => x.TaiNguyen3DId,
                        principalTable: "TaiNguyens3D",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaiNguyenNhanVats_NhanVats_NhanVatId",
                        column: x => x.NhanVatId,
                        principalTable: "NhanVats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CauHinhCoTheNhanVat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVatId = table.Column<int>(type: "int", nullable: false),
                    OverallHeight = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    DauScale = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    CoScale = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ShoulderWidth = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    NgucScale = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    EoScale = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    HipScale = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ArmLength = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ArmWidth = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    HandScale = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    LegLength = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    LegWidth = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    FootScale = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    CoTheMass = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHinhCoTheNhanVat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CauHinhCoTheNhanVat_NhanVats_NhanVatId",
                        column: x => x.NhanVatId,
                        principalTable: "NhanVats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiaTriTuyChinhNhanVats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVatId = table.Column<int>(type: "int", nullable: false),
                    ThamSoTuyChinhId = table.Column<int>(type: "int", nullable: false),
                    GiaTri = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaTriTuyChinhNhanVats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaTriTuyChinhNhanVats_NhanVats_NhanVatId",
                        column: x => x.NhanVatId,
                        principalTable: "NhanVats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiaTriTuyChinhNhanVats_ThamSoTuyChinhs_ThamSoTuyChinhId",
                        column: x => x.ThamSoTuyChinhId,
                        principalTable: "ThamSoTuyChinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XuatNhanVats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVatId = table.Column<int>(type: "int", nullable: false),
                    Format = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DuongDanFile = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TenFile = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    KichThuocFile = table.Column<long>(type: "bigint", nullable: false),
                    ThongBaoLoi = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XuatNhanVats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XuatNhanVats_NhanVats_NhanVatId",
                        column: x => x.NhanVatId,
                        principalTable: "NhanVats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CauHinhKhuonMatNhanVat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVatId = table.Column<int>(type: "int", nullable: false),
                    KhuonMatWidth = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    KhuonMatLength = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    EyeSize = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    EyeDistance = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    EyeAngle = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    NoseHeight = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    NoseWidth = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    MouthWidth = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    LipThickness = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    EarScale = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ChinScale = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    CheekScale = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    EyebrowAngle = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    MauDa = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    MauMat = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    MauToc = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHinhKhuonMatNhanVat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CauHinhKhuonMatNhanVat_NhanVats_NhanVatId",
                        column: x => x.NhanVatId,
                        principalTable: "NhanVats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnhTaiLens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    HoSoNguoiDungId = table.Column<int>(type: "int", nullable: true),
                    NhanVatId = table.Column<int>(type: "int", nullable: true),
                    LoaiTaiLen = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DuongDanAnhGoc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DuongDanAnhDaXuLy = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AnhDaiDienUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TenFile = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    LoaiNoiDung = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    KichThuocFile = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnhTaiLens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnhTaiLens_NhanVats_NhanVatId",
                        column: x => x.NhanVatId,
                        principalTable: "NhanVats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AnhTaiLens_HoSoNguoiDungs_HoSoNguoiDungId",
                        column: x => x.HoSoNguoiDungId,
                        principalTable: "HoSoNguoiDungs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GiaTriPhanPhuKienNhanVats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiNguyenNhanVatId = table.Column<int>(type: "int", nullable: false),
                    DiemChinhPhuKienId = table.Column<int>(type: "int", nullable: false),
                    GiaTri = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaTriPhanPhuKienNhanVats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaTriPhanPhuKienNhanVats_DiemChinhPhuKiens_DiemChinhPhuKienId",
                        column: x => x.DiemChinhPhuKienId,
                        principalTable: "DiemChinhPhuKiens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiaTriPhanPhuKienNhanVats_TaiNguyenNhanVats_TaiNguyenNhanVatId",
                        column: x => x.TaiNguyenNhanVatId,
                        principalTable: "TaiNguyenNhanVats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KetQuaPhanTichAnhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnhTaiLenId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SuggestedKind = table.Column<int>(type: "int", nullable: true),
                    SuggestedStyle = table.Column<int>(type: "int", nullable: true),
                    SuggestedMauDa = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    SuggestedMauToc = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    SuggestedMauMat = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    SuggestedTocStyleKey = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    SuggestedTrangPhucStyleKey = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    KhuonMatWidthScore = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    KhuonMatLengthScore = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    CoTheHeightScore = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    CoTheMassScore = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Confidence = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    KetQuaThoJson = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ThongBaoLoi = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuaPhanTichAnhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KetQuaPhanTichAnhs_AnhTaiLens_AnhTaiLenId",
                        column: x => x.AnhTaiLenId,
                        principalTable: "AnhTaiLens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiemChinhPhuKiens_TaiNguyen3DId",
                table: "DiemChinhPhuKiens",
                column: "TaiNguyen3DId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaTriPhanPhuKienNhanVats_DiemChinhPhuKienId",
                table: "GiaTriPhanPhuKienNhanVats",
                column: "DiemChinhPhuKienId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaTriPhanPhuKienNhanVats_TaiNguyenNhanVatId_DiemChinhPhuKienId",
                table: "GiaTriPhanPhuKienNhanVats",
                columns: new[] { "TaiNguyenNhanVatId", "DiemChinhPhuKienId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaiNguyenNhanVats_TaiNguyen3DId",
                table: "TaiNguyenNhanVats",
                column: "TaiNguyen3DId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiNguyenNhanVats_NhanVatId",
                table: "TaiNguyenNhanVats",
                column: "NhanVatId");

            migrationBuilder.CreateIndex(
                name: "IX_CauHinhCoTheNhanVat_NhanVatId",
                table: "CauHinhCoTheNhanVat",
                column: "NhanVatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiaTriTuyChinhNhanVats_NhanVatId_ThamSoTuyChinhId",
                table: "GiaTriTuyChinhNhanVats",
                columns: new[] { "NhanVatId", "ThamSoTuyChinhId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiaTriTuyChinhNhanVats_ThamSoTuyChinhId",
                table: "GiaTriTuyChinhNhanVats",
                column: "ThamSoTuyChinhId");

            migrationBuilder.CreateIndex(
                name: "IX_XuatNhanVats_NhanVatId",
                table: "XuatNhanVats",
                column: "NhanVatId");

            migrationBuilder.CreateIndex(
                name: "IX_CauHinhKhuonMatNhanVat_NhanVatId",
                table: "CauHinhKhuonMatNhanVat",
                column: "NhanVatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhanVats_MauNhanVatId",
                table: "NhanVats",
                column: "MauNhanVatId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVats_HoSoNguoiDungId",
                table: "NhanVats",
                column: "HoSoNguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_ThamSoTuyChinhs_Key",
                table: "ThamSoTuyChinhs",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaPhanTichAnhs_AnhTaiLenId",
                table: "KetQuaPhanTichAnhs",
                column: "AnhTaiLenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoiMauThietLaps_MauNhanVatId",
                table: "GoiMauThietLaps",
                column: "MauNhanVatId");

            migrationBuilder.CreateIndex(
                name: "IX_AnhTaiLens_NhanVatId",
                table: "AnhTaiLens",
                column: "NhanVatId");

            migrationBuilder.CreateIndex(
                name: "IX_AnhTaiLens_HoSoNguoiDungId",
                table: "AnhTaiLens",
                column: "HoSoNguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoNguoiDungs_UserId",
                table: "HoSoNguoiDungs",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiaTriPhanPhuKienNhanVats");

            migrationBuilder.DropTable(
                name: "CauHinhCoTheNhanVat");

            migrationBuilder.DropTable(
                name: "GiaTriTuyChinhNhanVats");

            migrationBuilder.DropTable(
                name: "XuatNhanVats");

            migrationBuilder.DropTable(
                name: "CauHinhKhuonMatNhanVat");

            migrationBuilder.DropTable(
                name: "KetQuaPhanTichAnhs");

            migrationBuilder.DropTable(
                name: "GoiMauThietLaps");

            migrationBuilder.DropTable(
                name: "DiemChinhPhuKiens");

            migrationBuilder.DropTable(
                name: "TaiNguyenNhanVats");

            migrationBuilder.DropTable(
                name: "ThamSoTuyChinhs");

            migrationBuilder.DropTable(
                name: "AnhTaiLens");

            migrationBuilder.DropTable(
                name: "TaiNguyens3D");

            migrationBuilder.DropTable(
                name: "NhanVats");

            migrationBuilder.DropTable(
                name: "MauNhanVats");

            migrationBuilder.DropTable(
                name: "HoSoNguoiDungs");
        }
    }
}


