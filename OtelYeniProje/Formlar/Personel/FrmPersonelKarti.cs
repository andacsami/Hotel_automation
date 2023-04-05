using DevExpress.XtraEditors;
using OtelYeniProje.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelYeniProje.Formlar.Personel
{
    public partial class FrmPersonelKarti : Form
    {
        public FrmPersonelKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        public int id;
        Repositories.Repository<TblPersonel> repo = new Repositories.Repository<TblPersonel>();

        private void labelControl2_Click(object sender, EventArgs e)
        {
            

        }

        private void FrmPersonelKarti_Load(object sender, EventArgs e)
        {
            this.Text = id.ToString();
            if (id != 0)
            { 
                var personel = repo.Find(x => x.PersonelID == id);
                TxtAdSoyad.Text = personel.AdSoyad;
                TxtTc.Text = personel.TC;
                TxtAdres.Text = personel.Adres;
                TxtTelefon.Text = personel.Telefon;
                TxtEposta.Text = personel.Mail;
                dateEditGiris.Text = personel.İseGirisTarih.ToString();
                dateEditCikis.Text = personel.İstenCikisTarih.ToString();
                TxtAciklama.Text = personel.Aciklama;
                TxtSifre.Text = personel.Sifre;
                pictureEditKimlikOn.Image = Image.FromFile(personel.KimlikOn);
                pictureEditKimlikArka.Image = Image.FromFile(personel.KimlikArka);
                labelControl15.Text = personel.KimlikOn;
                labelControl16.Text = personel.KimlikArka;
                lookUpEditDepartman.EditValue = personel.Departman;
                lookUpEditGorev.EditValue = personel.Gorev;
            }

            lookUpEditDepartman.Properties.DataSource = (from x in db.TblDepartman select new { x.DepartmanID, x.DepartmanAd }).ToList();
            lookUpEditGorev.Properties.DataSource = (from x in db.TblGorev select new { x.GorevID, x.GorevAd }).ToList();

        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Repositories.Repository<TblPersonel> repo = new Repositories.Repository<TblPersonel>();
            TblPersonel t = new TblPersonel();
            t.AdSoyad = TxtAdSoyad.Text;
            t.TC = TxtTc.Text;
            t.Adres = TxtAdres.Text;
            t.Telefon = TxtTelefon.Text;
            t.İseGirisTarih =DateTime.Parse(dateEditGiris.Text);
            t.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
            t.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
            t.Aciklama = TxtAciklama.Text;
            t.KimlikOn = pictureEditKimlikOn.GetLoadedImageLocation();
            t.KimlikArka = pictureEditKimlikArka.GetLoadedImageLocation();
            t.Sifre = TxtSifre.Text;
            t.Mail = TxtEposta.Text;
            t.Durum = 1;
            repo.TAdd(t);
            XtraMessageBox.Show("Personel başarılı bir şekilde sisteme kaydedildi.");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.PersonelID == id);
            deger.AdSoyad = TxtAdSoyad.Text;
            deger.TC = TxtTc.Text;
            deger.Adres = TxtAdres.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.İseGirisTarih = DateTime.Parse(dateEditGiris.Text);
            deger.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
            deger.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
            deger.Aciklama = TxtAciklama.Text;
            deger.KimlikOn = labelControl15.Text;
            deger.KimlikArka = labelControl16.Text;
            deger.Sifre = TxtSifre.Text;
            deger.Mail = TxtEposta.Text;
            repo.TUpdate(deger);
            XtraMessageBox.Show("personel kartı bilgileri başarıyla güncellendi.", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pictureEditKimlikOn_EditValueChanged(object sender, EventArgs e)
        {
            labelControl15.Text = pictureEditKimlikOn.GetLoadedImageLocation().ToString();
        }

        private void pictureEditKimlikArka_EditValueChanged(object sender, EventArgs e)
        {
            labelControl16.Text = pictureEditKimlikArka.GetLoadedImageLocation().ToString();
        }
    }
}
