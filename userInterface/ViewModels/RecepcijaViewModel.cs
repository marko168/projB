using repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace userInterface.ViewModels
{
    public class RecepcijaViewModel:BaseViewModel
    {
        private string lokal;
        private string mjesto_Rec;


        public string Lokal
        {
            get { return lokal; }
            set
            {
                lokal = value;
                OnPropertyChanged(nameof(Lokal));
            }
        }

        public string Mjesto_Rec
        {
            get { return mjesto_Rec; }
            set
            {
                mjesto_Rec = value;
                OnPropertyChanged(nameof(Mjesto_Rec));
            }
        }


        private Service service = new Service();
        private Visibility visible;
        private Visibility showAdd;
        private Visibility showEdit;
        private Visibility showHotel;
        private bool isEnabled;
        private ObservableCollection<Recepcija> recepcije;
        private ObservableCollection<Hotel> hoteli;
        private ObservableCollection<Recepcioner> recepcioneri;
        private Recepcija selectedRecepcija;
        private Hotel selectedHotel;
        private Recepcioner selectedRecepcioner;

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

        public Visibility ShowHotel
        {
            get { return showHotel; }
            set
            {
                showHotel = value;
                OnPropertyChanged(nameof(ShowHotel));
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
        public ObservableCollection<Recepcija> Recepcije
        {
            get { return recepcije; }
            set
            {
                recepcije = value;
                OnPropertyChanged(nameof(Recepcije));
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

        public ObservableCollection<Recepcioner> Recepcioneri
        {
            get { return recepcioneri; }
            set
            {
                recepcioneri = value;
                OnPropertyChanged(nameof(Recepcioneri));
            }
        }

        public Recepcija SelectedRecepcija
        {
            get { return selectedRecepcija; }
            set
            {
                selectedRecepcija = value;
                Visible = Visibility.Collapsed;
                Cleanup();
                IsEnabled = true;
                OnPropertyChanged(nameof(SelectedRecepcija));
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

        public Recepcioner SelectedRecepcioner
        {
            get { return selectedRecepcioner; }
            set
            {
                selectedRecepcioner = value;
                OnPropertyChanged(nameof(SelectedRecepcioner));
            }
        }

        public void Refresh()
        {
            Recepcije = new ObservableCollection<Recepcija>(service.ReceivesAllRecepcijas());

        }

        public void Cleanup()
        {
            Lokal = "";
            Mjesto_Rec = "";
            SelectedHotel = null;
            SelectedRecepcioner = null;
            IsEnabled = false;
        }


        public MyICommand ShowAddFields_ { get; set; }
        public MyICommand ShowEditFields_ { get; set; }
        public MyICommand Add_ { get; set; }
        public MyICommand Edit_ { get; set; }
        public MyICommand Delete_ { get; set; }

        public RecepcijaViewModel()
        {
            ShowAddFields_ = new MyICommand(ShowAddFields);
            ShowEditFields_ = new MyICommand(ShowEditFields);
            Add_ = new MyICommand(Add);
            Edit_ = new MyICommand(Edit);
            Delete_ = new MyICommand(Delete);
            Hoteli = new ObservableCollection<Hotel>(service.ReceivesAllHotels());
            Recepcioneri = new ObservableCollection<Recepcioner>(service.ReceivesAllRecepcioners());
            
            Cleanup();
            Refresh();
            Visible = Visibility.Collapsed;

        }

        public void ShowAddFields()
        {
            ShowHotel = Visibility.Visible;
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
            ShowHotel = Visibility.Collapsed;
            if (Visible == Visibility.Collapsed)
            {
                Visible = Visibility.Visible;
                ShowAdd = Visibility.Collapsed;
                ShowEdit = Visibility.Visible;
                Lokal = SelectedRecepcija.Lokal;
                Mjesto_Rec = SelectedRecepcija.Mjesto_Rec;
                SelectedHotel = SelectedRecepcija.Hotel;
                SelectedRecepcioner = SelectedRecepcija.Recepcioner;
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
                Recepcija r = new Recepcija
                {
                    Lokal = Lokal,
                    Mjesto_Rec = Mjesto_Rec,
                    Hotel = SelectedHotel,
                    Recepcioner = SelectedRecepcioner,
                };
                service.AddRecepcija(r);
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
                Recepcija r = new Recepcija
                {
                    Lokal = Lokal,
                    Mjesto_Rec = Mjesto_Rec,
                    Recepcioner = SelectedRecepcioner,
                };
                service.EditRecepcija(SelectedRecepcija.Br_Rec,r);
                Refresh();
                Cleanup();
                Visible = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Nisi popunio sva polja ili format vremena nije dobar.(HH:MM:00)", null, MessageBoxButton.OK);
            }
        }

        public void Delete()
        {
            service.DeleteRecepcija(SelectedRecepcija.Br_Rec);
            Refresh();
            Cleanup();
            Visible = Visibility.Collapsed;
        }

        public bool Validate()
        {
            if (Lokal == null || Lokal == "")
                return false;
            if (Mjesto_Rec == null || Mjesto_Rec == "")
                return false;
            if (SelectedHotel == null)
                return false;
            if (selectedRecepcioner == null)
                return false;
            return true;
        }

       
    }
}
