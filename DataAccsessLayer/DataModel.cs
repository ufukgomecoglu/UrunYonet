using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DataAccsessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionString.ConStr);
            cmd = con.CreateCommand();
        }
        #region Validasyonlar

        #endregion
        #region Giriş Metodu
        public Kullanicilar Giris(string KullaniciAdi, string Sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi=@KullaniciAdi AND Sifre=@Sifre AND IsDeleted=0";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@KullaniciAdi", KullaniciAdi);
                cmd.Parameters.AddWithValue("@Sifre", Sifre);
                con.Open();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT KullaniciID,KullaniciAdi,Sifre FROM Kullanicilar WHERE KullaniciAdi=@KullaniciAdi ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@KullaniciAdi", KullaniciAdi);
                con.Open();
                if (number > 0)
                {
                    Kullanicilar kullanicilar = new Kullanicilar();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        kullanicilar.KullaniciID = reader.GetInt32(0);
                        kullanicilar.KullaniciAdi = reader.GetString(1);
                        kullanicilar.Sifre = reader.GetString(2);
                    }
                    return kullanicilar;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Kullanicilar SifremiUnuttum(string KullaniciAdi, string eposta)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi=@KullaniciAdi AND Eposta=@Eposta AND IsDeleted=0";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@KullaniciAdi", KullaniciAdi);
                cmd.Parameters.AddWithValue("@Eposta", eposta);
                con.Open();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT KullaniciID,KullaniciAdi,Eposta FROM Kullanicilar WHERE KullaniciAdi=@KullaniciAdi ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@KullaniciAdi", KullaniciAdi);
                con.Open();
                if (number > 0)
                {
                    Kullanicilar kullanicilar = new Kullanicilar();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        kullanicilar.KullaniciID = reader.GetInt32(0);
                        kullanicilar.KullaniciAdi = reader.GetString(1);
                        kullanicilar.Eposta = reader.GetString(2);
                    }
                    return kullanicilar;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Mail işlemleri
        public bool MailGönder(string eposta, string otp)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("sifre.gonder@hotmail.com");
                mailMessage.To.Add(eposta);
                mailMessage.Subject = "E Posta Şifre | UrunYonet";
                mailMessage.Body = $"Tek kullanımlık şifreniz {otp}";
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Credentials = new NetworkCredential("sifre.gonder@hotmail.com", "sifregonder1234");
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.Host = "smtp-mail.outlook.com";
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion
        #region Update İşlemleri
        public void KullaniciSifreGuncelle(int kullaniciID, string otp)
        {
            try
            {
                cmd.CommandText = "UPDATE Kullanicilar SET Sifre=@Sifre WHERE KullaniciID=@KullaniciID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Sifre", otp);
                cmd.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public void BeniHatirlaUpdate(bool hatirla)
        {
            if (hatirla==false)
            {
                cmd.CommandText = "UPDATE BeniHatirla Set Hatirla=0";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                cmd.CommandText = "UPDATE BeniHatirla Set Hatirla=1";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public bool KategoriGuncelle(int kategoriID, string kategoriAdi)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET KategoriAdi= @KategoriAdi Where KategoriID=@KategoriID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@KategoriAdi", kategoriAdi);
                cmd.Parameters.AddWithValue("@KategoriID", kategoriID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool KategoriGuncelle(int kategoriID)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET IsDeleted= 1 Where KategoriID=@KategoriID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@KategoriID", kategoriID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool KategoriGuncelleGeriAl(int kategoriID)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET IsDeleted= 0 Where KategoriID=@KategoriID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@KategoriID", kategoriID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AltKategoriGuncelle(int altKategoriID, string altKategoriAdi)
        {
            try
            {
                cmd.CommandText = "UPDATE AltKategoriler SET AltKategoriAdi= @AltKategoriAdi Where AltKategoriID=@AltKategoriID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AltKategoriAdi", altKategoriAdi);
                cmd.Parameters.AddWithValue("@AltKategoriID", altKategoriID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AltKategoriGuncelle(int altKategoriID)
        {
            try
            {
                cmd.CommandText = "UPDATE AltKategoriler SET IsDeleted= 1 Where AltKategoriID=@AltKategoriID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AltKategoriID", altKategoriID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AltKategoriGuncelleGeriAl(int altKategoriID)
        {
            try
            {
                cmd.CommandText = "UPDATE AltKategoriler SET IsDeleted= 0 Where AltKategoriID=@AltKategoriID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AltKategoriID", altKategoriID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool TedarikciGuncelle(int tedariciID,string adi,string tel,string eposta, string yetkiliAdi )
        {
            try
            {
                cmd.CommandText = "UPDATE Tedarikciler SET Adi=@Adi,Tel=@Tel,Eposta=@Eposta,YetkiliAdi=@YetkiliAdi WHERE TedarikciID=@TedarikciID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Adi", adi);
                cmd.Parameters.AddWithValue("@Tel", tel);
                cmd.Parameters.AddWithValue("Eposta", eposta);
                cmd.Parameters.AddWithValue("@YetkiliAdi", yetkiliAdi);
                cmd.Parameters.AddWithValue("@TedarikciID", tedariciID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool TedarikciGuncelle(int tedariciID)
        {
            try
            {
                cmd.CommandText = "UPDATE Tedarikciler SET IsDeleted=1 WHERE TedarikciID=@TedarikciID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TedarikciID", tedariciID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Listele İşlemleri
        public bool BeniHatirlaList()
        {
            cmd.CommandText = "SELECT * FROM BeniHatirla";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            BeniHatirla beniHatirla = new BeniHatirla();
            while (reader.Read())
            {
                
                beniHatirla.Hetirla = reader.GetBoolean(0);
            }
            con.Close();
            if (beniHatirla.Hetirla==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Kategori> KategoriListele()
        {
            try
            {
                List<Kategori> kategoris = new List<Kategori>();
                cmd.CommandText = "SELECT * FROM Kategoriler WHERE IsDeleted=0";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kategori = new Kategori();
                    kategori.KategoriID = reader.GetInt32(0);
                    kategori.KategoriAdi = reader.GetString(1);
                    kategori.IsDeleted = reader.GetBoolean(2);
                    kategoris.Add(kategori);
                }
                return kategoris;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Kategori> TumKategoriListele()
        {
            try
            {
                List<Kategori> kategoris = new List<Kategori>();
                cmd.CommandText = "SELECT * FROM Kategoriler ";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kategori = new Kategori();
                    kategori.KategoriID = reader.GetInt32(0);
                    kategori.KategoriAdi = reader.GetString(1);
                    kategori.IsDeleted = reader.GetBoolean(2);
                    kategoris.Add(kategori);
                }
                return kategoris;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<AltKategori> KategoriyeGöreAltkategoriListele(int kategoriID)
        {
            try
            {
                List<AltKategori> altKategoris = new List<AltKategori>();
                cmd.CommandText = "SELECT * FROM AltKategoriler WHERE IsDeleted=0 AND KategoriID = @KategoriID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@KategoriID", kategoriID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AltKategori altKategori = new AltKategori();
                    altKategori.AltKategoriID = reader.GetInt32(0);
                    altKategori.KategoriID = reader.GetInt32(1);
                    altKategori.AltKategoriAdi = reader.GetString(2);
                    altKategori.IsDeleted = reader.GetBoolean(3);
                    altKategoris.Add(altKategori);
                }
                return altKategoris;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<AltKategori> AltkategoriListele()
        {
            try
            {
                List<AltKategori> altKategoris = new List<AltKategori>();
                cmd.CommandText = "SELECT * FROM AltKategoriler ";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AltKategori altKategori = new AltKategori();
                    altKategori.AltKategoriID = reader.GetInt32(0);
                    altKategori.KategoriID = reader.GetInt32(1);
                    altKategori.AltKategoriAdi = reader.GetString(2);
                    altKategori.IsDeleted = reader.GetBoolean(3);
                    altKategoris.Add(altKategori);
                }
                return altKategoris;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Tedarikci> TedarikciListele()
        {
            try
            {
                List<Tedarikci> tedarikcis = new List<Tedarikci>();
                cmd.CommandText = "SELECT * FROM Tedarikciler WHERE IsDeleted=0";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tedarikci tedarikci = new Tedarikci();
                    tedarikci.TedarikciID = reader.GetInt32(0);
                    tedarikci.Adi = reader.GetString(1);
                    tedarikci.Tel = reader.GetString(2);
                    tedarikci.Eposta = reader.GetString(3);
                    tedarikci.YetkiliAdi = reader.GetString(4);
                    tedarikci.IsDeleted = reader.GetBoolean(5);
                    tedarikcis.Add(tedarikci);
                }
                return tedarikcis;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Tedarikci> TedarikciListele(int tedarikciID)
        {
            try
            {
                List<Tedarikci> tedarikcis = new List<Tedarikci>();
                cmd.CommandText = "SELECT * FROM Tedarikciler WHERE IsDeleted=0 AND TedarikciID = @TedarikciID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TedarikciID", tedarikciID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tedarikci tedarikci = new Tedarikci();
                    tedarikci.TedarikciID = reader.GetInt32(0);
                    tedarikci.Adi = reader.GetString(1);
                    tedarikci.Tel = reader.GetString(2);
                    tedarikci.Eposta = reader.GetString(3);
                    tedarikci.YetkiliAdi = reader.GetString(4);
                    tedarikci.IsDeleted = reader.GetBoolean(5);
                    tedarikcis.Add(tedarikci);
                }
                return tedarikcis;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Ekle İşlemleri
        public void KategoriEkle(string KategoriAdi)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(KategoriAdi,Isdeleted) VALUES(@KategoriAdi,0)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@KategoriAdi", KategoriAdi);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public void AltKategoriEkle(int kategoriID,string altKategoriAdi)
        {
            try
            {
                cmd.CommandText = "INSERT INTO AltKategoriler(KategoriID,AltKategoriAdi,IsDeleted) VALUES(@KategoriID,@AltKategoriAdi,0)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@KategoriID",kategoriID);
                cmd.Parameters.AddWithValue("@AltKategoriAdi", altKategoriAdi);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public void KategoriYapilanIslemEkle(int kullaniciID,int kategoriID,string aciklama)
        {
            try
            {
                cmd.CommandText = "INSERT INTO YapilanIslemler(Tarih,KullaniciID,KategoriID,Aciklama) VALUES(@Tarih,@KullaniciID,@KategoriID,@Aciklama)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Tarih", DateTime.Now);
                cmd.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                cmd.Parameters.AddWithValue("@KategoriID", kategoriID);
                cmd.Parameters.AddWithValue("@Aciklama", aciklama);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public void AltkategoriYapilanIslemEkle(int kullaniciID, int altKategoriID, string aciklama)
        {
            try
            {
                cmd.CommandText = "INSERT INTO YapilanIslemler(Tarih,KullaniciID,AltKategoriID,Aciklama) VALUES(@Tarih,@KullaniciID,@AltKategoriID,@Aciklama)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Tarih", DateTime.Now);
                cmd.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                cmd.Parameters.AddWithValue("@AltKategoriID", altKategoriID);
                cmd.Parameters.AddWithValue("@Aciklama", aciklama);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public void TedarikciEkle(string adi, string telefon , string eposta, string yetkiliAdi )
        {
            try
            {
                cmd.CommandText = "INSERT INTO Tedarikciler(Adi,Tel,Eposta,YetkiliAdi,IsDeleted) VALUES(@Adi,@Tel,@Eposta,@YetkiliAdi,0)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Adi", adi);
                cmd.Parameters.AddWithValue("@Tel", telefon);
                cmd.Parameters.AddWithValue("@Eposta", eposta);
                cmd.Parameters.AddWithValue("@YetkiliAdi", yetkiliAdi);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            finally
            {
                con.Close();
            }
        }
        public void TedarikciYapilanIslemEkle(int kullaniciID, int tedarikciID, string aciklama)
        {
            try
            {
                cmd.CommandText = "INSERT INTO YapilanIslemler(Tarih,KullaniciID,TedarikciID,Aciklama) VALUES(@Tarih,@KullaniciID,@TedarikciID,@Aciklama)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Tarih", DateTime.Now);
                cmd.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                cmd.Parameters.AddWithValue("@TedarikciID", tedarikciID);
                cmd.Parameters.AddWithValue("@Aciklama", aciklama);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
    }
}
