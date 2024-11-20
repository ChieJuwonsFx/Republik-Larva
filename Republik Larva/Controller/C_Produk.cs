using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Data;
using Npgsql;
using Republik_Larva.Controller;
using Republik_Larva.Models;
using Republik_Larva.Views;

namespace Republik_Larva.Controller;
internal class C_Produk : DatabaseWrapper
{
    private static string table = "produk";

    public static DataTable All()
    {
        string query = @"
        SELECT produk_id, nama_produk, harga, stok
        FROM produk";

        DataTable dataMahasiswa = queryExecutor(query);
        return dataMahasiswa;
    }

    public static DataTable getProdukById(int id)
    {
        string query = @"
                SELECT * 
                FROM produk
                WHERE produk_id = @id";

        NpgsqlParameter[] parameters =
        {
                new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = id }
            };

        DataTable dataProduk = queryExecutor(query, parameters);
        return dataProduk;
    }


    public static void AddMahasiswa(M_Produk produkBaru)
    {
        string query = $"INSERT INTO {table} (nama_produk, harga, stok) VALUES(@nama, @harga, @stok)";

        NpgsqlParameter[] parameters =
        {
                    new NpgsqlParameter("@nama", produkBaru.nama_produk),
                    new NpgsqlParameter("@harga", produkBaru.harga),
                    new NpgsqlParameter("@stok", produkBaru.stok)
                };

        commandExecutor(query, parameters);
    }

    public static void UpdateProduk(M_Produk produk)
    {
        string query = $"UPDATE {table} SET nama_produk = @nama, harga = @harga, stok = @stok WHERE produk_id = @id";

        NpgsqlParameter[] parameters =
        {
        new NpgsqlParameter("@nama", produk.nama_produk),
        new NpgsqlParameter("@harga", produk.harga),
        new NpgsqlParameter("@stok", produk.stok),
        new NpgsqlParameter("@id", produk.produk_id)
    };

        commandExecutor(query, parameters);
    }

    public static void DeleteProduk(int id)
    {
        string query = $"DELETE FROM {table} WHERE produk_id = @id";

        NpgsqlParameter[] parameters =
        {
        new NpgsqlParameter("@id", id)
    };

        commandExecutor(query, parameters);
    }

}
