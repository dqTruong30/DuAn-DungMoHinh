#nullable enable

using System.ComponentModel.DataAnnotations;

namespace DungMoHinh.Models;

public enum LoaiNhanVat
{
    [Display(Name = "Nam")]
    Nam = 1,

    [Display(Name = "Nữ")]
    Nu = 2,

    [Display(Name = "Chibi nam")]
    ChibiNam = 3,

    [Display(Name = "Chibi nữ")]
    ChibiNu = 4,

    [Display(Name = "Trung tính")]
    TrungTinh = 5,

    [Display(Name = "Tùy chỉnh")]
    TuyChinh = 6
}

public enum PhongCachNhanVat
{
    [Display(Name = "Bình thường")]
    BinhThuong = 1,

    [Display(Name = "Chibi")]
    Chibi = 2,

    [Display(Name = "Anime")]
    Anime = 3,

    [Display(Name = "Chân thực")]
    ChanThuc = 4,

    [Display(Name = "Giả tưởng")]
    GiaTuong = 5,

    [Display(Name = "Robot")]
    Robot = 6
}

public enum LoaiTaiNguyen
{
    KhungCoSo = 1,
    Toc = 2,
    TrangPhuc = 3,
    PhuKien = 4,
    ChatLieu = 5,
    TuThe = 6,
    HoatAnh = 7,
    KetCau = 8,
    HoaTiet = 9
}

public enum DiemGan
{
    [Display(Name = "Đầu")]
    Dau = 1,

    [Display(Name = "Tóc")]
    Toc = 2,

    [Display(Name = "Khuôn mặt")]
    KhuonMat = 3,

    [Display(Name = "Sống mũi")]
    SongMui = 4,

    [Display(Name = "Tai trái")]
    TaiTrai = 5,

    [Display(Name = "Tai phải")]
    TaiPhai = 6,

    [Display(Name = "Cổ")]
    Co = 7,

    [Display(Name = "Ngực")]
    Nguc = 8,

    [Display(Name = "Lưng")]
    Lung = 9,

    [Display(Name = "Eo")]
    Eo = 10,

    [Display(Name = "Tay trái")]
    TayTrai = 11,

    [Display(Name = "Tay phải")]
    TayPhai = 12,

    [Display(Name = "Chân trái")]
    ChanTrai = 13,

    [Display(Name = "Chân phải")]
    ChanPhai = 14,

    [Display(Name = "Tùy chỉnh")]
    TuyChinh = 99
}

public enum LoaiTaiLen
{
    AnhThamChieuNhanVat = 1,
    AnhThamChieuPhuKien = 2,
    KetCau = 3,
    Lungground = 4,
    AnhXemTruocDaTao = 5
}

public enum TrangThaiXuLy
{
    ChoXuLy = 1,
    DangXuLy = 2,
    HoanTat = 3,
    ThatBai = 4
}

public enum CheDoHienThi
{
    [Display(Name = "Riêng tư")]
    RiengTu = 1,

    [Display(Name = "Không công khai")]
    KhongCongKhai = 2,

    [Display(Name = "Công khai")]
    CongKhai = 3
}

public enum DinhDangXuat
{
    Png = 1,
    Jpg = 2,
    Glb = 3,
    Gltf = 4,
    Fbx = 5,
    Obj = 6,
    Mp4 = 7
}

public enum KhuVucTuyChinh
{
    CoThe = 1,
    KhuonMat = 2,
    Toc = 3,
    TrangPhuc = 4,
    PhuKien = 5,
    ChatLieu = 6
}


