using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class Service
    {
        public Model1Container Baza { get; set; } = new Model1Container();

        public List<Hotel> ReceivesAllHotels()
        {
            return Baza.Hotels.ToList();
        }

        public void AddHotel(Hotel h)
        {
            Baza.Hotels.Add(h);
            Baza.SaveChanges();
        }

        public void EditHotel(int id,Hotel h)
        {
            Baza.Hotels.FirstOrDefault(t => t.Id_Hot == id).Naziv = h.Naziv;
            Baza.Hotels.FirstOrDefault(t => t.Id_Hot == id).Kategorija = h.Kategorija;
            Baza.Hotels.FirstOrDefault(t => t.Id_Hot == id).Adresa = h.Adresa;
            Baza.Hotels.FirstOrDefault(t => t.Id_Hot == id).Br_Racuna = h.Br_Racuna;
            Baza.Hotels.FirstOrDefault(t => t.Id_Hot == id).Telefon = h.Telefon;
            Baza.SaveChanges();
        }

        public void DeleteHotel(int id)
        {
            Baza.Hotels.Remove(Baza.Hotels.FirstOrDefault(t => t.Id_Hot == id));
            Baza.SaveChanges();
        }

        public List<Smjena> ReceivesAllSmjenas()
        {
            return Baza.Smjenas.ToList();
        }

        public void AddSmjena(Smjena s)
        {
            Baza.Smjenas.Add(s);
            Baza.SaveChanges();
        }

        public void EditSmjena(int id, Smjena s)
        {
            Baza.Smjenas.FirstOrDefault(t => t.Id_Smjene == id).Naz_Smjene = s.Naz_Smjene;
            Baza.Smjenas.FirstOrDefault(t => t.Id_Smjene == id).Nap_Smjene = s.Nap_Smjene;
            Baza.Smjenas.FirstOrDefault(t => t.Id_Smjene == id).Vrijeme_Od = s.Vrijeme_Od;
            Baza.Smjenas.FirstOrDefault(t => t.Id_Smjene == id).Vrijeme_Do = s.Vrijeme_Do;
            Baza.SaveChanges();
        }

        public void DeleteSmjena(int id)
        {
            Baza.Smjenas.Remove(Baza.Smjenas.FirstOrDefault(t => t.Id_Smjene == id));
            Baza.SaveChanges();
        }

        public List<Radnik> ReceivesAllRadniks()
        {
            return Baza.Radniks.ToList();
        }

        public List<Recepcioner> ReceivesAllRecepcioners()
        {
            List<Recepcioner> recepcioneri = new List<Recepcioner>();
            List<Radnik> radnici = ReceivesAllRadniks();
            foreach(Radnik r in radnici)
            {
                if(r is Recepcioner)
                {
                    recepcioneri.Add(r as Recepcioner);
                }
            }
            return recepcioneri;
        }

        public List<Cuvar> ReceivesAllCuvars()
        {
            List<Cuvar> cuvari = new List<Cuvar>();
            List<Radnik> radnici = ReceivesAllRadniks();
            foreach (Radnik r in radnici)
            {
                if (r is Cuvar)
                {
                    cuvari.Add(r as Cuvar);
                }
            }
            return cuvari;
        }

        public List<Konobar> ReceivesAllKonobars()
        {
            List<Konobar> konobari = new List<Konobar>();
            List<Radnik> radnici = ReceivesAllRadniks();
            foreach (Radnik r in radnici)
            {
                if (r is Konobar)
                {
                    konobari.Add(r as Konobar);
                }
            }
            return konobari;
        }
        public void AddRadnik(Radnik r)
        {
            Baza.Radniks.Add(r);
            Baza.SaveChanges();
        }

        public void AddRecepcioner(Recepcioner r)
        {
            Baza.Radniks.Add(r);
            Baza.SaveChanges();
        }

        public void AddCuvar(Cuvar c)
        {
            Baza.Radniks.Add(c);
            Baza.SaveChanges();
        }

        public void AddKonobar(Konobar k)
        {
            Baza.Radniks.Add(k);
            Baza.SaveChanges();
        }
        public void EditRadnik(int jmbg, Radnik r)
        {
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Ime = r.Ime;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Prezime = r.Prezime;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Adresa = r.Adresa;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).RadnikJMBG = r.RadnikJMBG;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Hotel = r.Hotel;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Br_Tel = r.Br_Tel;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Nadredjeni = r.Nadredjeni;
            Baza.SaveChanges();
        }

        public void EditRecepcioner(int jmbg, Recepcioner r)
        {
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Ime = r.Ime;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Prezime = r.Prezime;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Adresa = r.Adresa;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).RadnikJMBG = r.RadnikJMBG;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Hotel = r.Hotel;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Br_Tel = r.Br_Tel;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Nadredjeni = r.Nadredjeni;
            (Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg) as Recepcioner).Smjena = r.Smjena;
            Baza.SaveChanges();
        }

        public void EditCuvar(int jmbg, Cuvar r)
        {
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Ime = r.Ime;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Prezime = r.Prezime;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Adresa = r.Adresa;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).RadnikJMBG = r.RadnikJMBG;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Hotel = r.Hotel;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Nadredjeni = r.Nadredjeni;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Br_Tel = r.Br_Tel;
            Baza.SaveChanges();
        }

        public void EditKonobar(int jmbg, Konobar r)
        {
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Ime = r.Ime;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Prezime = r.Prezime;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Adresa = r.Adresa;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).RadnikJMBG = r.RadnikJMBG;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Hotel = r.Hotel;
            Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg).Br_Tel = r.Br_Tel;
            Baza.SaveChanges();
        }

        public void DeleteRadnik(int jmbg)
        {
            Baza.Radniks.Remove(Baza.Radniks.FirstOrDefault(t => t.JMBG == jmbg));
            Baza.SaveChanges();
        }

        public void DeleteRecepcija (int br_Rec)
        {
            Baza.Recepcijas.Remove(Baza.Recepcijas.FirstOrDefault(t => t.Br_Rec == br_Rec));
            Baza.SaveChanges();
        }

        public List<Recepcija> ReceivesAllRecepcijas()
        {
            return Baza.Recepcijas.ToList();
        }

        public void AddRecepcija(Recepcija r)
        {
            Baza.Recepcijas.Add(r);
            Baza.SaveChanges();
        }

        public void EditRecepcija(int id, Recepcija r)
        {
            Baza.Recepcijas.FirstOrDefault(t => t.Br_Rec == id).Lokal = r.Lokal;
            Baza.Recepcijas.FirstOrDefault(t => t.Br_Rec == id).Mjesto_Rec = r.Mjesto_Rec;
            Baza.Recepcijas.FirstOrDefault(t => t.Br_Rec == id).Recepcioner = r.Recepcioner;
            Baza.SaveChanges();
        }

        public void DeleteSoba(int br_Sobe)
        {
            Baza.Sobas.Remove(Baza.Sobas.FirstOrDefault(t => t.Br_Sobe == br_Sobe));
            Baza.SaveChanges();
        }

        public List<Soba> ReceivesAllSobas()
        {
            return Baza.Sobas.ToList();
        }

        public void AddSoba(Soba s)
        {
            Baza.Sobas.Add(s);
            Baza.SaveChanges();
        }

        public void EditSoba(int br_Sobe, Soba s)
        {
            Baza.Sobas.FirstOrDefault(t => t.Br_Sobe == br_Sobe).Tip = s.Tip;
            Baza.Sobas.FirstOrDefault(t => t.Br_Sobe == br_Sobe).Opis = s.Opis;
            Baza.Sobas.FirstOrDefault(t => t.Br_Sobe == br_Sobe).Napomena = s.Napomena;
            Baza.SaveChanges();
        }


        public void DeleteGost(int MBR)
        {
            Baza.Gosts.Remove(Baza.Gosts.FirstOrDefault(t => t.MBR == MBR));
            Baza.SaveChanges();
        }

        public List<Gost> ReceivesAllGosts()
        {
            return Baza.Gosts.ToList();
        }

        public void AddGost(Gost g)
        {
            Baza.Gosts.Add(g);
            Baza.SaveChanges();
        }

        public void EditGost(int MBR, Gost g)
        {
            Baza.Gosts.FirstOrDefault(t => t.MBR == MBR).Kontakt = g.Kontakt;
            Baza.Gosts.FirstOrDefault(t => t.MBR == MBR).Adresa = g.Adresa;
            Baza.Gosts.FirstOrDefault(t => t.MBR == MBR).Datum_P = g.Datum_P;
            Baza.Gosts.FirstOrDefault(t => t.MBR == MBR).Vrijeme_P = g.Vrijeme_P;
            Baza.Gosts.FirstOrDefault(t => t.MBR == MBR).Recepcija = g.Recepcija;
            Baza.SaveChanges();
        }

        public void DeleteSmjestaj(int id_Smjestaj)
        {
            Baza.Smjestajs.Remove(Baza.Smjestajs.FirstOrDefault(t => t.Id_Smjestaj == id_Smjestaj));
            Baza.SaveChanges();
        }

        public List<Smjestaj> ReceivesAllSmjestajs()
        {
            return Baza.Smjestajs.ToList();
        }

        public void AddSmjestaj(Smjestaj s)
        {
            Baza.Smjestajs.Add(s);
            Baza.SaveChanges();
        }

        public void EditSmjestaj(int id_Smjestaj, Smjestaj s)
        {
            Baza.Smjestajs.FirstOrDefault(t => t.Id_Smjestaj == id_Smjestaj).Soba = s.Soba;
            Baza.Smjestajs.FirstOrDefault(t => t.Id_Smjestaj == id_Smjestaj).Gost = s.Gost;
            Baza.SaveChanges();
        }

    }
}
