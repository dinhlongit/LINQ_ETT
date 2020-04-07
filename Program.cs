using System;
using System.Linq;
using _102160149_NguyenDinhLong.Models;
namespace _102160149_NguyenDinhLong {
    class Program {
        static void Main (string[] args) {

            QLSV ql = new QLSV ();

            // --------- show list sinh vien-----------
            Console.WriteLine ("List SINH VIEN : \n");
            ql.showListSinhVien ();

            // ----------add sinh vien----------
            Sinhvien sv = new Sinhvien ();
            sv.Mssv = 102155555;
            sv.NameSv = "Nguyen An";
            sv.Gender = true;
            DateTime date = new DateTime (1998, 11, 12);
            sv.Birthday = date;
            sv.Dtb = 9;
            sv.NameLop = "16T1";
            ql.addSinhVien (sv);
            Console.WriteLine ("\n\nSau khi them 1 Sinh Vien: \n");
            ql.showListSinhVien ();

            ///------update 1 sinh vien------      
            ql.editSinhVien (102155555);
            Console.WriteLine ("\n\nSau khi sua 1 Sinh Vien: \n");
            ql.showListSinhVien ();

            //-------delete sinh vien--------      
            ql.deleteSinhVienByID (102155555);
            Console.WriteLine ("\n\nSau khi xoa 1 Sinh Vien: \n");
            ql.showListSinhVien ();

        }
    }
}