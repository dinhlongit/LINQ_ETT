using System;
using System.Collections.Generic;
using System.Linq;
using _102160149_NguyenDinhLong.Models;
namespace _102160149_NguyenDinhLong {
    class QLSV {

        List<Sinhvien> listSinhVien { get; set; } = null;
        quanlysinhvienContext db = new quanlysinhvienContext ();
        public QLSV () {
            listSinhVien = getListSinhVien ();
        }
        public List<Sinhvien> getListSinhVien () {
            return db.Sinhvien.ToList ();
        }

        public void showListSinhVien () {
            foreach (var SinhVien in listSinhVien) {
                string gender;
                gender = (SinhVien.Gender == true) ? "Nam" : "Nu";
                Console.WriteLine (SinhVien.Mssv + " , " + SinhVien.NameSv + " , " + gender + " , " + SinhVien.Birthday + " , " + SinhVien.Dtb + " , " + SinhVien.NameLop);
            }
        }

        public bool addSinhVien (Sinhvien SinhVien) {
            bool check = false;
            try {
                db.Sinhvien.Add (SinhVien);
                db.SaveChanges ();
                check = true;
                listSinhVien = getListSinhVien ();
            } catch (Exception e) {
                Console.WriteLine (e.Message);
            }

            return check;
        }
        public Sinhvien DeleteAtPosition (int i) {
            if (i >= listSinhVien.Count || i < 0) {
                return null;
            }
            return listSinhVien[i];
        }
        public bool deleteSinhVienByID (int id) {
            bool check = false;
            try {
                db.Sinhvien.Remove (getSinhVienByID (id));
                db.SaveChanges ();
                check = true;
                listSinhVien = getListSinhVien ();
            } catch (Exception e) {
                Console.WriteLine (e.Message);
            }

            return check;
        }

        public bool editSinhVien (int id) {
            bool check = false;
            try {
                var sv_up = getSinhVienByID (id);
                sv_up.NameSv = "Nguyen Minh";
                sv_up.Dtb = 8;
                db.SaveChanges ();
                check = true;
                listSinhVien = getListSinhVien ();
            } catch (Exception e) {
                Console.WriteLine (e.Message);
            }

            return check;
        }

        public int IndexOf (Sinhvien s) {
            for (int i = 0; i < listSinhVien.Count; i++) {
                if (listSinhVien[i].Mssv.Equals (s.Mssv)) return i;
            }
            return -1;
        }

        public Sinhvien getSinhVienByID (int id) {
            return db.Sinhvien.Where (p => p.Mssv == id).FirstOrDefault ();
        }

        public void sort () {
            listSinhVien.Sort ((s1, s2) => s1.NameSv.CompareTo (s2.NameSv));
        }

    }
}