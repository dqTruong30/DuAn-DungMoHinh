# Tong quan Repositories

Tang repository tach controller khoi cac truy van Entity Framework Core. Controller chi nen dieu phoi luong xu ly, lay du lieu thong qua repository va goi `IDonViCongViec.SaveChangesAsync()` khi can luu thay doi.

## Cac kho du lieu chinh

- `IKhoNhanVat`: lay danh sach nhan vat cua nguoi dung, kiem tra quyen so huu, nap du lieu cho trinh chinh sua.
- `IKhoMauNhanVat`: lay cac mau nhan vat dang hoat dong.
- `IKhoTaiNguyen`: lay tai nguyen 3D, diem chinh phu kien va khoa mem tai nguyen.
- `IKhoTaiNguyenNhanVat`: quan ly tai nguyen da gan vao nhan vat, cap nhat vi tri, goc xoay, ti le va gia tri tung phan phu kien.
- `IKhoTuyChinh`: quan ly dinh nghia slider dong va gia tri slider tren tung nhan vat.
- `IKhoAnhTaiLen`: quan ly anh tham chieu, anh phu kien, texture va anh xem truoc.
- `IKhoPhanTichAnh`: luu ket qua phan tich anh tu AI hoac module xu ly anh.
- `IKhoXuatNhanVat`: quan ly yeu cau xuat file va thong tin file da xuat.
- `IKhoGoiMau`: lay cac goi thiet lap san.
- `IKhoHoSoNguoiDung`: lay hoac tao ho so nguoi dung.
- `IKhoQuanTri`: thong ke va danh sach nhanh cho trang quan tri.

## Don vi cong viec

Dung `IDonViCongViec` khi mot luong xu ly can thao tac nhieu bang du lieu.

```csharp
public class NhanVatsController : Controller
{
    private readonly IDonViCongViec _unitOfWork;

    public NhanVatsController(IDonViCongViec unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var nhanVats = await _unitOfWork.NhanVats.LayNhanVatTheoNguoiDungAsync(CurrentUserId);
        return View(nhanVats);
    }
}
```

## Dang ky DI

Trong `Program.cs`, dang ky repository layer sau khi dang ky `ApplicationDbContext`:

```csharp
using DungMoHinh.Extensions;

builder.Services.AddRepositoryLayer();
```
