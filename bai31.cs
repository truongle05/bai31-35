using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class SinhVien
{
    public string MSSV { get; set; }
    public string HoTen { get; set; }
    public double DiemToan { get; set; }
    public double DiemLy { get; set; }
    public double DiemHoa { get; set; }

    public double DiemTrungBinh
    {
        get { return (DiemToan + DiemLy + DiemHoa) / 3; }
    }
}

class Program
{
    static List<SinhVien> danhSachSinhVien = new List<SinhVien>();

    static void Main(string[] args)
    {
        try
        {
            NhapSoLuongSinhVien();
            NhapThongTinSinhVien();
            HienThiThongTinSinhVien();
            HienThiSinhVienDiemCao();
            DemSinhVienDiemTren5();
            SapXepTheoDiemTrungBinh();
            SapXepTheoHoTen();
            GhiThongTinSinhVienVaoFile();
            DocThongTinSinhVienTuFile();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }
    }

    static void NhapSoLuongSinhVien()
    {
        Console.Write("Nhập số lượng sinh viên: ");
        int soLuongSinhVien = int.Parse(Console.ReadLine());
    }

    static void NhapThongTinSinhVien()
    {
        Console.Write("Nhập số lượng sinh viên: ");
        int soLuongSinhVien = int.Parse(Console.ReadLine());

        for (int i = 0; i < soLuongSinhVien; i++)
        {
            SinhVien sv = new SinhVien();
            Console.Write("Nhập mã số sinh viên: ");
            sv.MSSV = Console.ReadLine();
            Console.Write("Nhập họ tên sinh viên: ");
            sv.HoTen = Console.ReadLine();
            Console.Write("Nhập điểm Toán: ");
            sv.DiemToan = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm Lý: ");
            sv.DiemLy = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm Hóa: ");
            sv.DiemHoa = double.Parse(Console.ReadLine());

            danhSachSinhVien.Add(sv);
        }
    }

    static void HienThiThongTinSinhVien()
    {
        foreach (var sv in danhSachSinhVien)
        {
            Console.WriteLine($"MSSV: {sv.MSSV}, Họ tên: {sv.HoTen}, Điểm trung bình: {sv.DiemTrungBinh:F2}");
        }
    }

    static void HienThiSinhVienDiemCao()
    {
        foreach (var sv in danhSachSinhVien)
        {
            if (sv.DiemTrungBinh > 9.5)
            {
                Console.WriteLine($"Sinh viên đầu tiên có điểm trung bình > 9.5: MSSV: {sv.MSSV}, Họ tên: {sv.HoTen}, Điểm trung bình: {sv.DiemTrungBinh:F2}");
                break;
            }
        }
    }

    static void DemSinhVienDiemTren5()
    {
        int count = 0;
        foreach (var sv in danhSachSinhVien)
        {
            if (sv.DiemTrungBinh > 5.0)
            {
                count++;
            }
        }
        Console.WriteLine($"Số sinh viên có điểm trung bình > 5.0: {count}");
    }

    static void SapXepTheoDiemTrungBinh()
    {
        var sortedList = danhSachSinhVien.OrderBy(sv => sv.DiemTrungBinh).ToList();
        Console.WriteLine("Danh sách sinh viên theo thứ tự điểm trung bình từ thấp đến cao:");
        foreach (var sv in sortedList)
        {
            Console.WriteLine($"MSSV: {sv.MSSV}, Họ tên: {sv.HoTen}, Điểm trung bình: {sv.DiemTrungBinh:F2}");
        }
    }

    static void SapXepTheoHoTen()
    {
        var sortedList = danhSachSinhVien.OrderBy(sv => sv.HoTen).ToList();
        Console.WriteLine("Danh sách sinh viên theo thứ tự alphabet của họ tên:");
        foreach (var sv in sortedList)
        {
            Console.WriteLine($"MSSV: {sv.MSSV}, Họ tên: {sv.HoTen}, Điểm trung bình: {sv.DiemTrungBinh:F2}");
        }
    }

    static void GhiThongTinSinhVienVaoFile()
    {
        Console.Write("Nhập tên file để ghi thông tin sinh viên: ");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var sv in danhSachSinhVien)
            {
                writer.WriteLine($"{sv.MSSV},{sv.HoTen},{sv.DiemToan},{sv.DiemLy},{sv.DiemHoa},{sv.DiemTrungBinh:F2}");
            }
        }

        Console.WriteLine("Đã ghi thông tin sinh viên vào file thành công.");
    }

    static void DocThongTinSinhVienTuFile()
    {
        Console.Write("Nhập tên file để đọc thông tin sinh viên: ");
        string fileName = Console.ReadLine();

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                SinhVien sv = new SinhVien
                {
                    MSSV = parts[0],
                    HoTen = parts[1],
                    DiemToan = double.Parse(parts[2]),
                    DiemLy = double.Parse(parts[3]),
                    DiemHoa = double.Parse(parts[4])
                };

                danhSachSinhVien.Add(sv);
            }
        }

        Console.WriteLine("Đã đọc thông tin sinh viên từ file thành công.");
    }
}

