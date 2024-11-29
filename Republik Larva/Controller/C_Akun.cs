using System;
using Republik_Larva.Models;
using Republik_Larva.Views;
using Republik_Larva.Views.Akun;

namespace Republik_Larva.Controller
{
    public class C_Akun : C_MessageBox
    {
        private C_MainForm C_MainForm;
        private V_Akun view_akun;
        private DataAkun akun;
        private V_TambahAdmin view_tambah;

        public C_Akun(C_MainForm controller, int id_admin)
        {
            C_MainForm = controller;

            M_Akun mAkun = new M_Akun();
            akun = mAkun.GetDataById(id_admin);

            if (akun != null)
            {
                Console.WriteLine($"Data Admin: {akun.nama_admin}, Username: {akun.username}");
            }
            else
            {
                Console.WriteLine("Data akun tidak ditemukan.");
            }

            view_akun = new V_Akun(this, akun);
            C_MainForm.moveView(view_akun);
        }

        public void tambahAdminView()
        {
            view_tambah = new V_TambahAdmin(this);
            C_MainForm.moveView(view_tambah);
        }

        public bool tambahAdmin(string namaAdmin, string username, string password, string konfirmPassword)
        {
            if (string.IsNullOrEmpty(namaAdmin) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(konfirmPassword))
            {
                show_message_box("Semua kolom harus diisi.");
                return false;
            }

            if (password != konfirmPassword)
            {
                show_message_box("Konfirmasi password tidak cocok.");
                return false;
            }

            M_Akun model = new M_Akun();
            bool isSuccess = model.TambahAdmin(namaAdmin, username, password);
            view_akun = new V_Akun(this, akun);
            C_MainForm.moveView(view_akun);
            return isSuccess;

        }

        public void logout()
        {
            if (show_confirm_message_box("Apakah Anda Yakin?"))
            {
                new V_Login().Show();
            }
        }
    }
}
