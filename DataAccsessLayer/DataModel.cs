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
        public void KullanıcıSifreGüncelle(int kullaniciID, string otp)
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
        #endregion
    }
}
