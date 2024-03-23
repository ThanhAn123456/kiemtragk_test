namespace kiemtragk
{
    class PHONGBAN
    {
        public int phongBanID { get; set; }
        public string phongBanName { get; set; }

    }
    class CHUCVU
    {
        public int chucVuID { get; set; }
        public string chucVuName {  get; set; }    
    }

    class NHANVIEN
    {
        public int nhanVienID { get; set; }
        public string nhanVienName { get; set; }
        public int tuoi { get; set; }
        public float luong { get; set; }
        public string moTa {  get; set; }
        public int phongBanID { get; set; }
        public int chucVuID { get; set; }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<NHANVIEN> danhSachNhanVien = new List<NHANVIEN>
            {
                new NHANVIEN { nhanVienID = 1, nhanVienName = "NhanVien3", tuoi = 20, luong = 22000000, moTa = "Dep trai, nang dong", phongBanID = 1, chucVuID = 1 },
                new NHANVIEN { nhanVienID = 2, nhanVienName = "NhanVien2", tuoi = 22, luong = 23000000, moTa = "Dep gai, nang dong", phongBanID = 2, chucVuID = 1 },
                new NHANVIEN { nhanVienID = 3, nhanVienName = "NhanVien1", tuoi = 21, luong = 22000000, moTa = "Dep trai, hoat bat", phongBanID = 1, chucVuID = 2 },
                new NHANVIEN { nhanVienID = 4, nhanVienName = "NhanVien4", tuoi = 23, luong = 21000000, moTa = "Xau trai, hoat bat", phongBanID = 2, chucVuID = 2 },
                new NHANVIEN { nhanVienID = 5, nhanVienName = "NhanVien5", tuoi = 20, luong = 22000000, moTa = "Dep gai, nang dong", phongBanID = 1, chucVuID = 3 },
                new NHANVIEN { nhanVienID = 6, nhanVienName = "NhanVien6", tuoi = 21, luong = 19000000, moTa = "Xau trai, nang dong", phongBanID = 2, chucVuID = 3 }
            };

            List<PHONGBAN> danhSachPhongBan = new List<PHONGBAN>
            {
                new PHONGBAN { phongBanID = 1, phongBanName = "Ke Toan" },
                new PHONGBAN { phongBanID = 2, phongBanName = "Nhan Su" }
            };

            List<CHUCVU> danhSachChucVu = new List<CHUCVU>
            {
                new CHUCVU { chucVuID = 1, chucVuName = "Truong phong" },
                new CHUCVU { chucVuID = 2, chucVuName = "Pho truong phong" },
                new CHUCVU { chucVuID = 3, chucVuName = "Nhan vien" }
            };

            // all list
            var nhanVienVaPhongBan = from nv in danhSachNhanVien
                                     join pb in danhSachPhongBan on nv.phongBanID equals pb.phongBanID
                                     join cv in danhSachChucVu on nv.chucVuID equals cv.chucVuID
                                     select new
                                     {
                                         nv.nhanVienID,
                                         nv.nhanVienName,
                                         nv.tuoi,
                                         nv.luong,
                                         nv.moTa,
                                         cv.chucVuName,
                                         pb.phongBanName
                                     };
            Console.WriteLine("Danh sach nhan vien:");
            foreach(var item in nhanVienVaPhongBan)
            {
                Console.WriteLine($"  ID: {item.nhanVienID}, Ten: {item.nhanVienName}, Tuoi: {item.tuoi}, luong: {item.luong}, Chuc vu: {item.chucVuName}, Phong ban: {item.phongBanName}");
            }

            // Tim kiem
            Console.Write("Tim kiem: ");
            string tk = Console.ReadLine();
            var danhSachTimKiem = nhanVienVaPhongBan;
            if (!tk.Equals(""))
            {
                danhSachTimKiem = nhanVienVaPhongBan.Where(nv => nv.nhanVienName.Contains(tk) | nv.moTa.Contains(tk) | nv.phongBanName.Contains(tk) | nv.chucVuName.Contains(tk));
            }

            // Tuoi
            Console.Write("Nhap do tuoi tu: ");
            string check = Console.ReadLine();
            int tuoi1=0;
            int tuoi2=0;
            var nhanVienTheoTuoi = nhanVienVaPhongBan;
            if (!check.Equals("all"))
            {
                tuoi1 = int.Parse(check);
                Console.Write("den: ");
                tuoi2 = int.Parse(Console.ReadLine());
                nhanVienTheoTuoi = nhanVienVaPhongBan.Where(nv => nv.tuoi >= tuoi1 && nv.tuoi <= tuoi2);
            }

            // Chuc vu
            Console.Write("Nhap chuc vu: ");
            string cV = Console.ReadLine();
            var nhanVienTheoCV = nhanVienVaPhongBan;
            if (!cV.Equals("all"))
            {
                nhanVienTheoCV = nhanVienVaPhongBan.Where(nv => nv.chucVuName == cV);
            }

            // Phong ban
            Console.Write("Nhap phong ban: ");
            string pB = Console.ReadLine();
            var nhanVienTheoPB = nhanVienVaPhongBan;
            if (!pB.Equals("all"))
            {
                nhanVienTheoCV = nhanVienVaPhongBan.Where(nv => nv.phongBanName == pB);
            }

            //foreach (var item in danhSachTimKiem)
            //{
            //    Console.WriteLine($"1  ID: {item.nhanVienID}");
            //}
            //foreach (var item in nhanVienTheoTuoi)
            //{
            //    Console.WriteLine($"2  ID: {item.nhanVienID}");
            //}
            //foreach (var item in nhanVienTheoCV)
            //{
            //    Console.WriteLine($"3  ID: {item.nhanVienID}");
            //}
            //foreach (var item in nhanVienTheoPB)
            //{
            //    Console.WriteLine($"4  ID: {item.nhanVienID}");
            //}

            var danhSachLoc = from dstk in danhSachTimKiem
                              join nvt in nhanVienTheoTuoi on dstk.nhanVienID equals nvt.nhanVienID
                              join nvcv in nhanVienTheoCV on dstk.nhanVienID equals nvcv.nhanVienID
                              join nvpb in nhanVienTheoPB on dstk.nhanVienID equals nvpb.nhanVienID
                              select new
                              {
                                  dstk.nhanVienID,
                                  dstk.nhanVienName,
                                  dstk.tuoi,
                                  dstk.luong,
                                  dstk.moTa,
                                  dstk.chucVuName,
                                  dstk.phongBanName
                              };
            Console.WriteLine("Danh sach tim kiem:");
            if (danhSachLoc.Any())
            {
                foreach (var item in danhSachLoc)
                {
                    Console.WriteLine($"  ID: {item.nhanVienID}, Ten: {item.nhanVienName}, Tuoi: {item.tuoi}, luong: {item.luong}, Mo ta: {item.moTa}, Chuc vu: {item.chucVuName}, Phong ban: {item.phongBanName}");
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay!");
            }
            Console.ReadKey();
        }
    }
}
