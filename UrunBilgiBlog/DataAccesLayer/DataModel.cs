using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DataAccesLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }


        #region Yönetici Metotları
        public Yonetici YoneticiGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE EMail=@m AND Sifre = @s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT ID,YoneticiTurID,Isim,Soyad,EMail,Sifre,Durum FROM Yoneticiler WHERE EMail=@m AND Sifre = @s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yonetici y = null;
                    while (reader.Read())
                    {
                        y = new Yonetici();
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTurID = reader.GetInt32(1);
                        y.Isim = reader.GetString(2);
                        y.Soyad = reader.GetString(3);
                        y.Email = reader.GetString(4);
                        y.Sifre = reader.GetString(5);
                        y.Durum = reader.GetBoolean(6);
                    }
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Kategori Metotları

        public bool KategoriEkle(Kategori k)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim) VALUES(@i)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", k.Isim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriListele()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();

                cmd.CommandText = "SELECT ID, Isim FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori k = new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    kategoriler.Add(k);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public Kategori KategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim FROM Kategoriler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Kategori k = new Kategori();

                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                }
                return k;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriGuncelle(Kategori k)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim = @i WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", k.Isim);
                cmd.Parameters.AddWithValue("@id", k.ID);
                con.Open();

                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Urun Metotları

        public bool UrunEkle(Urun u)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Urunler(KategoriID, YazarID, Isim, Marka, Fiyat, Icerik, KapakResim, GoruntulenmeSayısı," +
                    " EklemeTarihi, Durum) VALUES(@kategoriID, @yazarID, @Isim, @marka, @fiyat, @Icerik, @kapakResim, @goruntulenmeSayısı, @eklemeTarihi, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriID", u.KategoriID);
                cmd.Parameters.AddWithValue("@yazarID", u.YazarID);
                cmd.Parameters.AddWithValue("@Isim", u.Isim);
                cmd.Parameters.AddWithValue("@marka", u.Marka);
                cmd.Parameters.AddWithValue("@fiyat", u.Fiyat);
                cmd.Parameters.AddWithValue("@Icerik", u.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", u.KapakResim);
                cmd.Parameters.AddWithValue("@goruntulenmeSayısı", u.GoruntulenmeSayısı);
                cmd.Parameters.AddWithValue("@eklemeTarihi", u.EklemeTarihi);
                cmd.Parameters.AddWithValue("@durum", u.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Urun> Urunlistele()
        {
            try
            {
                List<Urun>Urunler = new List<Urun>();
                cmd.CommandText = "SELECT U.ID,U.KategoriID,K.Isim,U.YazarID,Y.Isim + ' ' + Y.Soyad,U.Isim,U.Marka,U.Fiyat,U.Icerik,U.KapakResim,U.GoruntulenmeSayısı,U.EklemeTarihi,U.Durum FROM Urunler AS U JOIN Kategoriler AS K ON K.ID = U.KategoriID JOIN Yoneticiler AS Y ON Y.ID = U.YazarID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Urun u = new Urun();
                    u.ID = reader.GetInt32(0);
                    u.KategoriID = reader.GetInt32(1);
                    u.Kategori = reader.GetString(2);
                    u.YazarID = reader.GetInt32(3);
                    u.Yazar = reader.GetString(4);
                    u.Isim = reader.GetString(5);
                    u.Marka = reader.GetString(6);
                    u.Fiyat = reader.GetString(7);
                    u.Icerik = reader.GetString(8);
                    u.KapakResim = reader.GetString(9);
                    u.GoruntulenmeSayısı = reader.GetInt32(10);
                    u.EklemeTarihi = reader.GetDateTime(11);
                    u.Durum = reader.GetBoolean(12);
                    Urunler.Add(u);
                }
                return Urunler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Urun> Urunlistele(int katid)
        {
            try
            {
                List<Urun> Urunler = new List<Urun>();
                cmd.CommandText = "SELECT U.ID,U.KategoriID,K.Isim,U.YazarID,Y.Isim + ' ' + Y.Soyad,U.Isim,U.Marka,U.Fiyat,U.Icerik,U.KapakResim,U.GoruntulenmeSayısı,U.EklemeTarihi,U.Durum FROM Urunler AS U JOIN Kategoriler AS K ON K.ID = U.KategoriID JOIN Yoneticiler AS Y ON Y.ID = U.YazarID WHERE U.KategoriID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", katid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Urun u = new Urun();
                    u.ID = reader.GetInt32(0);
                    u.KategoriID = reader.GetInt32(1);
                    u.Kategori = reader.GetString(2);
                    u.YazarID = reader.GetInt32(3);
                    u.Yazar = reader.GetString(4);
                    u.Isim = reader.GetString(5);
                    u.Marka = reader.GetString(6);
                    u.Fiyat = reader.GetString(7);
                    u.Icerik = reader.GetString(8);
                    u.KapakResim = reader.GetString(9);
                    u.GoruntulenmeSayısı = reader.GetInt32(10);
                    u.EklemeTarihi = reader.GetDateTime(11);
                    u.Durum = reader.GetBoolean(12);
                    Urunler.Add(u);
                }
                return Urunler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Urun  UrunGetir(int id)
        {
            try
            {
               
                cmd.CommandText = "SELECT U.ID,U.KategoriID,K.Isim,U.YazarID,Y.Isim + ' ' + Y.Soyad,U.Isim,U.Marka,U.Fiyat,U.Icerik,U.KapakResim,U.GoruntulenmeSayısı,U.EklemeTarihi,U.Durum FROM Urunler AS U JOIN Kategoriler AS K ON K.ID = U.KategoriID JOIN Yoneticiler AS Y ON Y.ID = U.YazarID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Urun u = new Urun();
                while (reader.Read())
                {
                  
                    u.ID = reader.GetInt32(0);
                    u.KategoriID = reader.GetInt32(1);
                    u.Kategori = reader.GetString(2);
                    u.YazarID = reader.GetInt32(3);
                    u.Yazar = reader.GetString(4);
                    u.Isim = reader.GetString(5);
                    u.Marka = reader.GetString(6);
                    u.Fiyat = reader.GetString(7);
                    u.Icerik = reader.GetString(8);
                    u.KapakResim = reader.GetString(9);
                    u.GoruntulenmeSayısı = reader.GetInt32(10);
                    u.EklemeTarihi = reader.GetDateTime(11);
                    u.Durum = reader.GetBoolean(12);
                    
                }
                return u;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UrunGuncelle(Urun u)
            
        {
            try
            {
                cmd.CommandText = "UPDATE Urunler SET KategoriID=@KategoriID, Isim=@Isim, Marka=@Marka, Fiyat=@Fiyat,Icerik=@Icerik, KapakResim=@KapakResim, Durum=@Durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", u.ID);
                cmd.Parameters.AddWithValue("@KategoriID", u.KategoriID);
                cmd.Parameters.AddWithValue("@Isim",u.Isim);
                cmd.Parameters.AddWithValue("@Marka",u.Marka);
                cmd.Parameters.AddWithValue("@Fiyat", u.Fiyat);
                cmd.Parameters.AddWithValue("@Icerik", u.Icerik);
                cmd.Parameters.AddWithValue("@KapakResim",u.KapakResim);
                cmd.Parameters.AddWithValue("@Durum",u.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }


        public bool UrunSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Urunler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
       

        public bool UrunDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Urunler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = (bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Urunler SET Durum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("d", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region  Yorum Metotları

       
        public bool YorumEkle(Yorum y)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Yorumlar(UyeID, UrunID, Icerik, YorumTarihi, OnayDurum) VALUES(@uyeID, @urunID, @icerik, @yorumTarihi, @onayDurum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@uyeID", y.UyeID);
                cmd.Parameters.AddWithValue("@urunID", y.UrunID);
                cmd.Parameters.AddWithValue("@icerik", y.Icerik);
                cmd.Parameters.AddWithValue("@yorumTarihi", y.Tarih);
                cmd.Parameters.AddWithValue("@onayDurum", y.OnayDurum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorum> YorumListele()
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.KullaniciAdı, Y.UrunID, UR.Isim, Y.Icerik, Y.YorumTarihi, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Urunler AS UR ON UR.ID=Y.UrunID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.UrunID = reader.GetInt32(3);
                    y.Isim = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.OnayDurum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Yorum> YorumListele(int Mid)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.KullaniciAdı, Y.UrunID, UR.Isim, Y.Icerik, Y.YorumTarihi, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Urunler AS UR ON UR.ID=Y.UrunID WHERE Y.UrunID = @id AND Y.OnayDurum = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", Mid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.UrunID = reader.GetInt32(3);
                    y.Isim = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.OnayDurum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
   
        #region Üye Metotları
        public Uye UyeGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Email=@m AND Sifre=@s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());

                if (sayi == 1)
                {
                    cmd.CommandText = "SELECT ID, Isim, Soyad, KullaniciAdı, Email, Sifre, UyelikTarihi, Durum FROM Uyeler WHERE Email=@m AND Sifre=@s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Uye u = new Uye();
                    while (reader.Read())
                    {
                        u.ID = reader.GetInt32(0);
                        u.Isim = reader.GetString(1);
                        u.Soyad = reader.GetString(2);
                        u.KullaniciAdı = reader.GetString(3);
                        u.Email = reader.GetString(4);
                        u.Sifre = reader.GetString(5);
                        u.UyelikTarihi = reader.GetDateTime(6);
                        u.Durum = reader.GetBoolean(7);
                    }
                    return u;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }


        public bool UyeOL(Uye u)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Uyeler(Isim, Soyad, KullaniciAdı, Email, Sifre, UyelikTarihi, Durum) VALUES (@Isim, @soyad, @kullaniciAdı, @Email, @Sifre, @UyelikTarihi, @Durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Isim", u.Isim);
                cmd.Parameters.AddWithValue("@soyad", u.Soyad);
                cmd.Parameters.AddWithValue("@kullaniciAdı", u.KullaniciAdı);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Sifre", u.Sifre);
                cmd.Parameters.AddWithValue("@UyelikTarihi", u.UyelikTarihi);
                cmd.Parameters.AddWithValue("@Durum", u.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }


        public bool UyeSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Uyeler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }


        public bool UyeDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Uyeler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = (bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Uyeler SET Durum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("d", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Uye>UyeLisetle()
        {
            try
            {
                List<Uye> Uyeler = new List<Uye>();
                cmd.CommandText = "SELECT ID, Isim,Soyad,KullaniciAdı,Email,Sifre,UyelikTarihi,Durum FROM Uyeler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Uye u = new Uye();
                    u.ID = reader.GetInt32(0);                  
                    u.Isim = reader.GetString(1);
                    u.Soyad = reader.GetString(2);
                    u.KullaniciAdı = reader.GetString(3);
                    u.Email = reader.GetString(4);
                    u.Sifre = reader.GetString(5);
                    u.UyelikTarihi = reader.GetDateTime(6);
                    u.Durum = reader.GetBoolean(7);

                    Uyeler.Add(u);
                }
                return Uyeler;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }


        public bool UyeGuncelle(Uye u)

        {
            try
            {
                cmd.CommandText = "UPDATE ID@ID,Uyeler SET  Isim=@Isim, Soyad=@Soyad, KullaniciAdı=@KullaniciAdı,Email=@Email, Sifre=@Sifre,WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue(@"ID", u.ID);
                cmd.Parameters.AddWithValue("@Isim", u.Isim);
                cmd.Parameters.AddWithValue("@Soyad", u.Soyad);
                cmd.Parameters.AddWithValue("@KullaniciAdi",u.KullaniciAdı);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Sifre", u.Sifre);          
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }







        #endregion






    }
}
