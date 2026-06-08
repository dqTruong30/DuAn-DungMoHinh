# Tong quan Controllers

Tang controller duoc chia theo luong chuc nang cua website:

- `NhanVatsController`: tao, liet ke, mo trinh chinh sua, cap nhat co the, cap nhat khuon mat, luu thong so tuy chinh, nhan ban va xoa nhan vat.
- `MauNhanVatsController`: hien thi cac mau nhan vat co so nhu nam, nu, chibi va binh thuong.
- `TaiNguyensController`: hien thi va tao tai nguyen 3D dung lai duoc nhu toc, trang phuc, phu kien, tu the, hoat anh, ket cau va chat lieu.
- `TaiNguyenNhanVatsController`: gan tai nguyen vao nhan vat, cap nhat vi tri/goc xoay/ti le, chinh tung phan phu kien va go bo.
- `AnhTaiLensController`: tai len anh tham chieu, anh phu kien, ket cau hoac anh xem truoc.
- `PhanTichAnhsController`: luong mau cho viec phan tich anh va ap dung goi y vao nhan vat.
- `XuatNhanVatsController`: tao yeu cau xuat file va luu thong tin file da xuat.
- `GoiMausController`: hien thi cac goi thiet lap san.
- `HoSoController`: hien thi va cap nhat ho so nguoi dung hien tai.
- `QuanTriController`: bang dieu khien va cac man hinh quan ly nhanh.

Controller dang dung `IDonViCongViec` thay vi goi truc tiep `ApplicationDbContext`, giup viec sua logic truy van va luu du lieu sau nay gon hon.
