using repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace userInterface.ViewModels
{
    public class RadnikViewModel:BaseViewModel
    {
        private string ime;
        private string prezime;
        private string adresa;
        private string br_Tel;
        private Radnik radnik;
        private Hotel hotel;
        


        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged(nameof(Ime));
            }
        }

        public string Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged(nameof(Adresa));
            }
        }

        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged(nameof(Prezime));
            }
        }

        public string Br_Tel
        {
            get { return br_Tel; }
            set
            {
                br_Tel = value;
                OnPropertyChanged(nameof(Br_Tel));
            }
        }

        public Radnik Radnik
        {
            get { return radnik; }
            set
            {
                radnik = value;
                OnPropertyChanged(nameof(Radnik));
            }
        }

        public Hotel Hotel
        {
            get { return hotel; }
            set
            {
                hotel = value;
                OnPropertyChanged(nameof(Hotel));
            }
        }

        private Service service = new Service();
        private Visibility visible;
        private Visibility showAdd;
        private Visibility showEdit;
        private Visibility showRadnik;
        private Visibility showRecepcioner;
        private Visibility showSmjenu;
        private bool isEnabled;
        private ObservableCollection<Radnik> radnici;
        private ObservableCollection<Recepcioner> recepcioneri;
        private ObservableCollection<Radnik> sefovi;
        private ObservableCollection<Hotel> hoteli;
        private ObservableCollection<Smjena> smjene;
        private Radnik selectedRadnik;
        private Radnik selectedSef;
        private Hotel selectedHotel;
        private Smjena selectedSmjena;
        private string selectedUloga;

        public string SelectedUloga
        {
            get { return selectedUloga; }
            set
            {
                selectedUloga = value;
                if(value == "Recepcioneri")
                {
                    ShowSmjenu = Visibility.Visible;
                }else
                {
                    ShowSmjenu = Visibility.Collapsed;
                }
                OnPropertyChanged(nameof(SelectedUloga));
            }
        }

        public Visibility ShowSmjenu
        {
            get { return showSmjenu; }
            set
            {
                showSmjenu = value;
                OnPropertyChanged(nameof(ShowSmjenu));
            }
        }

        public Visibility Visible
        {
            get { return visible; }
            set
            {
                visible = value;
                OnPropertyChanged(nameof(Visible));
            }
        }

        public Visibility ShowAdd
        {
            get { return showAdd; }
            set
            {
                showAdd = value;
                OnPropertyChanged(nameof(ShowAdd));
            }
        }

        public Visibility ShowEdit
        {
            get { return showEdit; }
            set
            {
                showEdit = value;
                OnPropertyChanged(nameof(ShowEdit));
            }
        }

        public Visibility ShowRadnik
        {
            get { return showRadnik; }
            set
            {
                showRadnik = value;
                OnPropertyChanged(nameof(ShowRadnik));
            }
        }

        public Visibility ShowRecepcioner
        {
            get { return showRecepcioner; }
            set
            {
                showRecepcioner = value;
                OnPropertyChanged(nameof(ShowRecepcioner));
            }
        }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public ObservableCollection<Smjena> Smjene
        {
            get { return smjene; }
            set
            {
                smjene = value;
                OnPropertyChanged(nameof(Smjene));
            }
        }
        public ObservableCollection<Radnik> Radnici
        {
            get { return radnici; }
            set
            {
                radnici = value;
                OnPropertyChanged(nameof(Radnici));
            }
        }

        public ObservableCollection<Recepcioner> Recepcioneri
        {
            get { return recepcioneri; }
            set
            {
                recepcioneri = value;
                OnPropertyChanged(nameof(Recepcioneri));
            }
        }

        public ObservableCollection<Radnik> Sefovi
        {
            get { return sefovi; }
            set
            {
                sefovi = value;
                OnPropertyChanged(nameof(Sefovi));
            }
        }

        public ObservableCollection<Hotel> Hoteli
        {
            get { return hoteli; }
            set
            {
                hoteli = value;
                OnPropertyChanged(nameof(Hoteli));
            }
        }


        public Radnik SelectedRadnik
        {
            get { return selectedRadnik; }
            set
            {
                selectedRadnik = value;
                Visible = Visibility.Collapsed;
                Cleanup();
                IsEnabled = true;
                OnPropertyChanged(nameof(SelectedRadnik));
            }
        }

        public Radnik SelectedSef
        {
            get { return selectedSef; }
            set
            {
                selectedSef = value;
                OnPropertyChanged(nameof(SelectedSef));
            }
        }

        public Smjena SelectedSmjena
        {
            get { return selectedSmjena; }
            set
            {
                selectedSmjena = value;
                OnPropertyChanged(nameof(SelectedSmjena));
            }
        }

        public Hotel SelectedHotel
        {
            get { return selectedHotel; }
            set
            {
                selectedHotel = value;
                OnPropertyChanged(nameof(SelectedHotel));
            }
        }

        public void Refresh()
        {
            Radnici = new ObservableCollection<Radnik>(service.ReceivesAllRadniks());
            Sefovi = new ObservableCollection<Radnik>(service.ReceivesAllRadniks());
            ShowRadnik = Visibility.Visible;
            ShowRecepcioner = Visibility.Collapsed;
        }

        public void Cleanup()
        {
            Ime = "";
            Prezime = "";
            Adresa = "";
            Br_Tel = "";
            SelectedHotel = null;
            SelectedUloga = null;
            SelectedSmjena = null;
            SelectedSef = null;
            IsEnabled = false;
        }


        public MyICommand ShowAddFields_ { get; set; }
        public MyICommand ShowEditFields_ { get; set; }
        public MyICommand Add_ { get; set; }
        public MyICommand Edit_ { get; set; }
        public MyICommand Delete_ { get; set; }
        public MyICommand Recepcioneri_ { get; set; }
        public MyICommand Cuvari_ { get; set; }
        public MyICommand Konobari_ { get; set; }

        public List<string> Uloge { get; set; } = new List<string>() { "Recepcioneri", "Cuvari", "Konobari" };
        public RadnikViewModel()
        {
            ShowAddFields_ = new MyICommand(ShowAddFields);
            ShowEditFields_ = new MyICommand(ShowEditFields);
            Add_ = new MyICommand(Add);
            Edit_ = new MyICommand(Edit);
            Delete_ = new MyICommand(Delete);
            Recepcioneri_ = new MyICommand(Recepcionerii);
            Cuvari_ = new MyICommand(Cuvarii);
            Konobari_ = new MyICommand(Konobarii);
            Hoteli = new ObservableCollection<Hotel>(service.ReceivesAllHotels());
            Sefovi = new ObservableCollection<Radnik>(service.ReceivesAllRadniks());
            Smjene = new ObservableCollection<Smjena>(service.ReceivesAllSmjenas());
            ShowSmjenu = Visibility.Collapsed;
            Cleanup();
            Refresh();
            Visible = Visibility.Collapsed;

        }

        public void ShowAddFields()
        {
            if (Visible == Visibility.Collapsed)
            {
                Visible = Visibility.Visible;
                ShowAdd = Visibility.Visible;
                ShowEdit = Visibility.Collapsed;
                Cleanup();
            }
            else if (ShowEdit == Visibility.Visible)
            {
                ShowEdit = Visibility.Collapsed;
                ShowAdd = Visibility.Visible;
                Cleanup();
            }
            else
            {
                Visible = Visibility.Collapsed;
            }
        }

        public void ShowEditFields()
        {
            if (Visible == Visibility.Collapsed)
            {
                Visible = Visibility.Visible;
                ShowAdd = Visibility.Collapsed;
                ShowEdit = Visibility.Visible;
                Ime = SelectedRadnik.Ime;
                Prezime = SelectedRadnik.Prezime;
                Adresa = SelectedRadnik.Adresa;
                Br_Tel = SelectedRadnik.Br_Tel;
                SelectedSef = SelectedRadnik.Nadredjeni;
                SelectedHotel = SelectedRadnik.Hotel;
            }
            else if (ShowAdd == Visibility.Visible)
            {
                ShowAdd = Visibility.Collapsed;
                ShowEdit = Visibility.Visible;
                Cleanup();
            }
            else
            {
                Visible = Visibility.Collapsed;
            }
        }

        public void Recepcionerii()
        {
            ShowRecepcioner = Visibility.Visible;
            ShowRadnik = Visibility.Collapsed;
            Recepcioneri = new ObservableCollection<Recepcioner>(service.ReceivesAllRecepcioners());
        }

        public void Cuvarii()
        {
            ShowRecepcioner = Visibility.Collapsed;
            ShowRadnik = Visibility.Visible;
            Radnici = new ObservableCollection<Radnik>(service.ReceivesAllCuvars());
        }

        public void Konobarii()
        {
            ShowRecepcioner = Visibility.Collapsed;
            ShowRadnik = Visibility.Visible;
            Radnici = new ObservableCollection<Radnik>(service.ReceivesAllKonobars());
        }

        public void Add()
        {
            if (Validate())
            {
                Radnik temp = null;
                if (SelectedSef != null)
                {
                    temp = SelectedSef;
                }
                if (SelectedUloga == "Recepcioneri")
                {
                    Recepcioner r = new Recepcioner()
                    {
                        Ime = Ime,
                        Prezime = Prezime,
                        Adresa = Adresa,
                        Br_Tel = Br_Tel,
                        Hotel = SelectedHotel,
                        Nadredjeni = temp,
                        Smjena = selectedSmjena
                    };
                    service.AddRecepcioner(r);
                } else if(SelectedUloga == "Cuvari")
                {
                    Cuvar r = new Cuvar
                    {
                        Ime = Ime,
                        Prezime = Prezime,
                        Adresa = Adresa,
                        Br_Tel = Br_Tel,
                        Hotel = SelectedHotel,
                        Nadredjeni = temp
                    };
                    service.AddCuvar(r);
                } else if(SelectedUloga == "Konobari")
                {
                    Konobar r = new Konobar
                    {
                        Ime = Ime,
                        Prezime = Prezime,
                        Adresa = Adresa,
                        Br_Tel = Br_Tel,
                        Hotel = SelectedHotel,
                        Nadredjeni = temp
                    };
                    service.AddKonobar(r);
                } else
                {
                    Radnik r = new Radnik
                    {
                        Ime = Ime,
                        Prezime = Prezime,
                        Adresa = Adresa,
                        Br_Tel = Br_Tel,
                        Hotel = SelectedHotel,
                        Nadredjeni = temp
                    };
                    service.AddRadnik(r);
                }
                Refresh();
                Cleanup();
                Visible = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Nisi popunio sva polja.");
            }

        }

        public void Edit()
        {
            if (Validate())
            {
                Radnik temp = null;
                if (SelectedSef != null)
                {
                    temp = SelectedSef;
                }
                if (SelectedUloga == "Recepcioner")
                {
                    Recepcioner r = new Recepcioner()
                    {
                        Ime = Ime,
                        Prezime = Prezime,
                        Adresa = Adresa,
                        Br_Tel = Br_Tel,
                        Hotel = SelectedHotel,
                        Nadredjeni = temp,
                        Smjena = selectedSmjena
                    };
                    service.EditRecepcioner(selectedRadnik.JMBG, r);
                }
                else if (SelectedUloga == "Cuvar")
                {
                    Cuvar r = new Cuvar
                    {
                        Ime = Ime,
                        Prezime = Prezime,
                        Adresa = Adresa,
                        Br_Tel = Br_Tel,
                        Hotel = SelectedHotel,
                        Nadredjeni = temp
                    };
                    service.EditCuvar(selectedRadnik.JMBG, r);
                }
                else if (SelectedUloga == "Konobar")
                {
                    Konobar r = new Konobar
                    {
                        Ime = Ime,
                        Prezime = Prezime,
                        Adresa = Adresa,
                        Br_Tel = Br_Tel,
                        Hotel = SelectedHotel,
                        Nadredjeni = temp
                    };
                    service.EditKonobar(selectedRadnik.JMBG, r);
                }
                else
                {
                    Radnik r = new Radnik
                    {
                        Ime = Ime,
                        Prezime = Prezime,
                        Adresa = Adresa,
                        Br_Tel = Br_Tel,
                        Hotel = SelectedHotel,
                        Nadredjeni = temp
                    };
                    service.EditRadnik(selectedRadnik.JMBG,r);
                }
                Refresh();
                Cleanup();
                Visible = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Nisi popunio sva potrebna polja.", null, MessageBoxButton.OK);
            }
        }

        public void Delete()
        {
            service.DeleteRadnik(SelectedRadnik.JMBG);
            Refresh();
            Cleanup();
            Visible = Visibility.Collapsed;
        }

        public bool Validate()
        {
            if (Ime == null || Ime == "")
                return false;
            if (Prezime == null || Prezime == "")
                return false;
            if (Adresa == null || Adresa == "")
                return false;
            if (Br_Tel == null || Br_Tel == "")
                return false;
            if (SelectedHotel == null)
                return false;
            return true;
        }
    }
}
