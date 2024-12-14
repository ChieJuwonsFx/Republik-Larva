using Republik_Larva.Controller;
using Republik_Larva.Models;
using Republik_Larva.Views.Akun;
using Republik_Larva.Views;
using System.Data;

public class C_Akun : C_MessageBox
{
    private C_MainForm C_MainForm;
    private V_Akun view_akun;
    private C_MessageBox c_MessageBox;
    private V_MainForm v_MainForm;
    private M_Akun m_Akun;
    private V_TambahAdmin view_tambah;
    private V_EditAdmin view_edit;
    private V_AllAdmin view_all;

    private int idAdmin;  
    public C_Akun(C_MainForm controller, int id_admin)
    {
        C_MainForm = controller;
        M_Akun mAkun = new M_Akun();
        m_Akun = mAkun.GetAdminById(id_admin);

        c_MessageBox = new C_MessageBox();

        this.idAdmin = id_admin;

        view_akun = new V_Akun(this, m_Akun);
        C_MainForm.moveView(view_akun);
    }
    public void balikAkun()
    {
        view_akun = new V_Akun(this, m_Akun);
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
        view_akun = new V_Akun(this, m_Akun);
        C_MainForm.moveView(view_akun);
        return isSuccess;
    }

    public void editAdminView()
    {
        if (idAdmin <= 0)
        {
            show_message_box($"ID Admin tidak valid.");
            return;
        }

        M_Akun mAkun = new M_Akun();
        M_Akun adminData = mAkun.GetAdminById(idAdmin);

        if (adminData == null)
        {
            show_message_box("Admin tidak ditemukan.");
        }
        else
        {
            view_edit = new V_EditAdmin(this, idAdmin);
            C_MainForm.moveView(view_edit);
        }
    }
    public M_Akun GetAdminById(int adminId)
    {
        return m_Akun.GetAdminById(adminId);
    }

    public void EditAdmin(int adminId, string namaAdmin, string password, string konfirmPassword)
    {
        if (string.IsNullOrWhiteSpace(namaAdmin) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(konfirmPassword))
        {
            show_message_box("Semua field harus diisi.");
            return;
        }

        if (password != konfirmPassword)
        {
            show_message_box("Password dan konfirmasi password tidak cocok.");
            return;
        }

        bool berhasil = m_Akun.UpdateAdmin(adminId, namaAdmin, password);
        if (berhasil)
        {
            show_message_box("Admin berhasil diperbarui.");
        }
        else
        {
            show_message_box("Gagal memperbarui admin.");
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
    public void AllAdminView()
    {
        view_all = new V_AllAdmin(this);
        C_MainForm.moveView(view_all);
    }
    public DataTable GetAkunList()
    {
        M_Akun model = new M_Akun();
        return M_Akun.All(); 
    }
    public void HapusAdmin(M_Akun akun, cardAdmin kartu)
    {
        bool result = show_confirm_message_box($"Anda yakin ingin menghapus admin {akun.nama_admin}?");

        if (result)
        {
            bool berhasilDihapus = m_Akun.HapusAdmin(akun.admin_id);

            if (berhasilDihapus)
            {
                view_all.pnAdmin.Controls.Remove(kartu);
                kartu.Dispose();

                show_message_box("Admin berhasil dihapus.");
            }
            else
            {
                show_message_box("Gagal menghapus admin. Karena admin pernah melayani transaksi");
            }
        }
    }
    public void logout()
    {
        if (show_confirm_message_box("Apakah Anda Yakin?"))
        {
            new V_Login().Show();
        }
    }
}
