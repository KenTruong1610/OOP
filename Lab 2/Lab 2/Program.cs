using ConsoleApp5;
using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        List<int> tuSoList = new List<int> { 1, 2, 5, 1, 9 };
        List<int> mauSoList = new List<int> { 3, 6, 10, 2, 3 };

        List<PhanSo> listPhanSo = new List<PhanSo>();

        for (int i = 0; i < tuSoList.Count; i++)
        {
            listPhanSo.Add(new PhanSo(tuSoList[i], mauSoList[i]));
        }

        Console.WriteLine("Danh sách phân số:");
        foreach (var ps in listPhanSo)
        {
            Console.WriteLine(ps);
        }

        PhanSo kqCong = listPhanSo[0].Cong(listPhanSo[1]);
        Console.WriteLine($"\nKết quả cộng: {listPhanSo[0]} + {listPhanSo[1]} = {kqCong}");

        PhanSo kqTru = listPhanSo[0].Tru(listPhanSo[1]);
        Console.WriteLine($"\nKết quả trừ: {listPhanSo[0]} - {listPhanSo[1]} = {kqTru}");

        PhanSo kqNhan = listPhanSo[0].Nhan(listPhanSo[1]);
        Console.WriteLine($"\nKết quả nhân: {listPhanSo[0]} * {listPhanSo[1]} = {kqNhan}");

        PhanSo kqChia = listPhanSo[0].Chia(listPhanSo[1]);
        Console.WriteLine($"\nKết quả chia: {listPhanSo[0]} / {listPhanSo[1]} = {kqChia}");

        SoSanhPhanSo soSanh = new SoSanhPhanSo();
        Console.WriteLine("\nKiểm tra các cặp phân số có bằng nhau không:");
        bool foundEqualPair = false;

        for (int i = 0; i < listPhanSo.Count; i++)
        {
            for (int j = i + 1; j < listPhanSo.Count; j++)
            {
                if (soSanh.BangNhau(listPhanSo[i], listPhanSo[j]))
                {
                    Console.WriteLine($"{listPhanSo[i]} và {listPhanSo[j]} là hai phân số bằng nhau.");
                    foundEqualPair = true;
                }
            }
        }

        if (!foundEqualPair)
        {
            Console.WriteLine("Không có cặp phân số nào bằng nhau.");
        }
        Console.ReadKey();

    }

}
