using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion
        #region Ekle Metotları
        public bool KullainiciEkle(Kullanicilar kullanicilar)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kullanicilar(Adi,Soyadi,KullaniciAdi,Eposta,Sifre,CepTel,UyelikTarihi,DogumTarihi,IsDeleted) VALUES(@Adi,@Soyadi,@KullaniciAdi,@Eposta,@Sifre,@CepTel,@UyelikTarihi,@DogumTarihi,@IsDeleted)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Adi", kullanicilar.Adi);
                cmd.Parameters.AddWithValue("@Soyadi", kullanicilar.Soyadi);
                cmd.Parameters.AddWithValue("@KullaniciAdi", kullanicilar.KullaniciAdi);
                cmd.Parameters.AddWithValue("@Eposta", kullanicilar.Eposta);
                cmd.Parameters.AddWithValue("@Sifre", kullanicilar.Sifre);
                cmd.Parameters.AddWithValue("@CepTel", kullanicilar.CepTel);
                cmd.Parameters.AddWithValue("@UyelikTarihi", kullanicilar.UyelikTarihi);
                cmd.Parameters.AddWithValue("@DogumTarihi", kullanicilar.DogumTarihi);
                cmd.Parameters.AddWithValue("@IsDeleted", kullanicilar.IsDeleted);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Validasyonlar
        public string NullControl(string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                return text;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
