# Tong quan Models

Thu muc nay chua cac lop du lieu nen tang cho website tao va tuy chinh nhan vat 3D.

## Nhom nhan vat

- `NhanVat`: nhan vat do nguoi dung tao va luu lai.
- `MauNhanVat`: mau 3D co so, vi du nam, nu, chibi nam, chibi nu.
- `CauHinhCoTheNhanVat`: cac thong so chinh co the nhu chieu cao, dau, vai, eo, tay, chan.
- `CauHinhKhuonMatNhanVat`: cac thong so khuon mat va mau sac nhu mat, mui, mieng, da, toc.
- `ThamSoTuyChinh`: dinh nghia slider tuy chinh dong de sau nay mo rong them thong so moi.
- `GiaTriTuyChinhNhanVat`: gia tri cua mot slider tuy chinh gan voi mot nhan vat.

## Nhom tai nguyen va phu kien

- `TaiNguyen3D`: tai nguyen 3D dung lai duoc, gom toc, trang phuc, phu kien, chat lieu, ket cau, tu the va hoat anh.
- `TaiNguyenNhanVat`: tai nguyen da duoc gan vao mot nhan vat, kem vi tri, goc xoay, ti le, mau sac va vat lieu.
- `DiemChinhPhuKien`: diem co the chinh rieng tren phu kien, vi du do rong gong kinh hoac kich thuoc vanh mu.
- `GiaTriPhanPhuKienNhanVat`: gia tri tuy chinh cua mot phan phu kien tren nhan vat.

## Nhom anh va phan tich anh

- `AnhTaiLen`: anh nguoi dung tai len, anh tham chieu phu kien, ket cau hoac anh xem truoc.
- `KetQuaPhanTichAnh`: ket qua AI/xu ly anh dung de goi y loai nhan vat, mau sac va ti le.

## Nhom luu va xuat ket qua

- `XuatNhanVat`: thong tin file xuat ra nhu PNG, JPG, GLB, GLTF, FBX, OBJ hoac video.
- `GoiMauThietLap`: goi thiet lap san giup tao nhanh nhan vat.
- `HoSoNguoiDung`: ho so nguoi dung noi bo, lien ket voi ma tai khoan dang nhap.

## Quan he chinh

- Mot `HoSoNguoiDung` co nhieu `NhanVat` va nhieu `AnhTaiLen`.
- Mot `MauNhanVat` co the duoc dung boi nhieu `NhanVat`.
- Mot `NhanVat` co mot `CauHinhCoTheNhanVat` va mot `CauHinhKhuonMatNhanVat`.
- Mot `NhanVat` co nhieu `TaiNguyenNhanVat`, `AnhTaiLen`, `XuatNhanVat` va `GiaTriTuyChinhNhanVat`.
- Mot `TaiNguyen3D` co the xuat hien trong nhieu `TaiNguyenNhanVat`.
- Mot `TaiNguyen3D` co the co nhieu `DiemChinhPhuKien`.
- Mot `TaiNguyenNhanVat` co the co nhieu `GiaTriPhanPhuKienNhanVat`.

## Buoc phat trien tiep theo

Sau khi co giao dien 3D, co the bo sung service xu ly Three.js, service xuat file 3D va module AI phan tich anh that.
