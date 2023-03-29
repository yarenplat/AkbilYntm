using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkbilYntmVeriKatmani
{
    public interface IVeriTabaniIslemleri
    {
        //CRUD: Create Read Update Delete
        string BaglantiCumlesi { get; set; }
        DataTable VeriGetir(string tabloAdi, string kolonlar="*",string? kosullar=null);

        int VeriSil(string tabloAdi, string? kosullar = null);

        int KomutIsle(string eklemeyadaGuncellemeCumlesi); //executenonquery

        string VeriEklemeCumlesiOlustur(string tabloAdi,Dictionary<string,object> kolonlar);

        string VeriGuncellemeCumlesiOlustur(string tabloAdi,Hashtable kolonlar, string? kosullar = null);

        Hashtable VeriOku(string tabloAdi, string[] kolonlar, string? kosullar = null);
        




    }
}
