using Republik_Larva.Controller;
using Republik_Larva.Models;
using Republik_Larva.Views.Akun;
using Republik_Larva.Views;

public class C_Akun : C_MessageBox
{
    private C_MainForm C_MainForm;
    private V_Akun view_akun;
    private C_MessageBox c_MessageBox;
    private V_MainForm v_MainForm;
    private DataAkun akun;
    private V_TambahAdmin view_tambah;
    private V_EditAdmin view_edit;

    private int idAdmin;  
    public C_Akun(C_MainForm controller, int id_admin)
    {
        C_MainForm = controller;
        M_Akun mAkun = new M_Akun();
        akun = mAkun.GetDataById(id_admin);

        c_MessageBox = new C_MessageBox();

        this.idAdmin = id_admin;

        view_akun = new V_Akun(this, akun);
        C_MainForm.moveView(view_akun);
    }
    public void balikAkun()
    {
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

    public void editAdminView()
    {
        Console.WriteLine("ID yang diterima di editAdminView: " + idAdmin);

        if (idAdmin <= 0)
        {
            show_message_box($"ID Admin tidak valid.");
            return;
        }

        M_Akun mAkun = new M_Akun();
        DataAkun adminData = mAkun.GetDataById(idAdmin);

        if (adminData == null)
        {
            show_message_box("Admin tidak ditemukan.");
        }
        else
        {
            view_edit = new V_EditAdmin(this, adminData);
            C_MainForm.moveView(view_edit);
        }
    }

    public bool editAdmin(int id, string namaAdmin, string password, string konfirmPassword)
    {
        if (string.IsNullOrEmpty(namaAdmin))
        {
            show_message_box("Nama Admin tidak boleh kosong.");
            return false;
        }

        if (!string.IsNullOrEmpty(password) && password != konfirmPassword)
        {
            show_message_box("Konfirmasi password tidak cocok.");
            return false;
        }

        M_Akun mAkun = new M_Akun();
        bool isUpdated = mAkun.UpdateAdmin(id, namaAdmin, password);
        return isUpdated;
    }



    public void logout()
    {
        if (show_confirm_message_box("Apakah Anda Yakin?"))
        {
            new V_Login().Show();
        }
    }
}
