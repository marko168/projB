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
    public class HotelViewModel:BaseViewModel
    {
        private string naziv;
        private string adresa;
        private string kategorija;
        private string br_Rac;
        private string telefon;

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged(nameof(Naziv));
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

        public string Kategorija
        {
            get { return kategorija; }
            set
            {
                kategorija = value;
                OnPropertyChanged(nameof(Kategorija));
            }
        }

        public string Br_Rac
        {
            get { return br_Rac; }
            set
            {
                br_Rac = value;
                OnPropertyChanged(nameof(Br_Rac));
            }
        }

        public string Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                OnPropertyChanged(nameof(Telefon));
            }
        }



        private Service service = new Service();
        private Visibility visible;
        private Visibility showAdd;
        private Visibility showEdit;
        private bool isEnabled;
        private ObservableCollection<Hotel> hoteli;
        private Hotel selectedHotel;

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

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
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

        public Hotel SelectedHotel
        {
            get { return selectedHotel; }
            set
            {
                selectedHotel = value;
                Visible = Visibility.Collapsed;
                Cleanup();
                IsEnabled = true;           
                OnPropertyChanged(nameof(SelectedHotel));
            }
        }

        public void Refresh()
        {
            Hoteli = new ObservableCollection<Hotel>(service.ReceivesAllHotels());
        }

        public void Cleanup()
        {
            Naziv = "";
            Adresa = "";
            Br_Rac = "";
            Kategorija = "";
            Telefon = "";
            IsEnabled = false;
        }


        public MyICommand ShowAddFields_ { get; set; }
        public MyICommand ShowEditFields_ { get; set; }
        public MyICommand Add_ { get; set; }
        public MyICommand Edit_ { get; set; }
        public MyICommand Delete_ { get; set; }


        public HotelViewModel()
        {
            ShowAddFields_ = new MyICommand(ShowAddFields);
            ShowEditFields_ = new MyICommand(ShowEditFields);
            Add_ = new MyICommand(Add);
            Edit_ = new MyICommand(Edit);
            Delete_ = new MyICommand(Delete);
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
                Naziv = SelectedHotel.Naziv;
                Adresa = SelectedHotel.Adresa;
                Kategorija = SelectedHotel.Kategorija;
                Br_Rac = SelectedHotel.Br_Racuna;
                Telefon = SelectedHotel.Telefon;
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

        public void Add()
        {
            if (Validate())
            {
                Hotel h = new Hotel
                {
                    Naziv = Naziv,
                    Adresa = Adresa,
                    Kategorija = Kategorija,
                    Br_Racuna = Br_Rac,
                    Telefon = Telefon
                };
                service.AddHotel(h);
                Refresh();
                Cleanup();
                Visible = Visibility.Collapsed;
            }else
            {
                MessageBox.Show("Nisi popunio sva polja.");
            }
            
        }

        public void Edit()
        {
            if (Validate())
            {
                Hotel h = new Hotel
                {
                    Naziv = Naziv,
                    Adresa = Adresa,
                    Kategorija = Kategorija,
                    Br_Racuna = Br_Rac,
                    Telefon = Telefon
                };
                service.EditHotel(selectedHotel.Id_Hot, h);
                Refresh();
                Cleanup();
                Visible = Visibility.Collapsed;
            } else
            {
                MessageBox.Show("Nisi popunio sva polja.",null,MessageBoxButton.OK);
            }  
        }

        public void Delete()
        {
            service.DeleteHotel(SelectedHotel.Id_Hot);
            Refresh();
            Cleanup();
            Visible = Visibility.Collapsed;
        }

        public bool Validate()
        {
            if (Naziv == null || Naziv == "")
                return false;
            if (Adresa == null || Adresa == "")
                return false;
            if (Kategorija == null || Kategorija == "")
                return false;
            if (Br_Rac == null || Br_Rac == "")
                return false;
            if (Telefon == null || Telefon == "")
                return false;
            return true;
        }
    }
}
