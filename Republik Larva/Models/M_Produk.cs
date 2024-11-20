using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Republik_Larva.Models
{
    public class M_Produk
    {
        [Key]
        public int produk_id { get; set; }
        [Required]
        public string nama_produk { get; set; }
        [Required]
        public string harga { get; set; }
        [Required]
        public string stok { get; set; }
    }
}