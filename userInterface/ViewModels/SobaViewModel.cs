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
    public class SobaViewModel:BaseViewModel
    {
        private string tip;
        private string opis;
        private string napomena;

        public string Tip
        {
            get { return tip; }
            set
            {
                tip = value;
                OnPropertyChanged(nameof(Tip));
            }
        }

        public string Opis
        {
            get { return opis; }
            set
            {
                opis = value;
                OnPropertyChanged(nameof(Opis));
            }
        }

        public string Napomena
        {
            get { return napomena; }
            set
            {
                napomena = value;
                OnPropertyChanged(nameof(Napomena));
            }
        }




        private Service service = new Service();
        private Visibility visible;
        private Visibility showAdd;
        private Visibility showEdit;
        private bool isEnabled;
        private ObservableCollection<Hotel> hoteli;
        private ObservableCollection<Soba> sobe;
        private Hotel selectedHotel;
        private Soba selectedSoba;

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
                OnPropertyChanged(nameof(SelectedHotel));
            }
        }

        public ObservableCollection<Soba> Sobe
        {
            get { return sobe; }
            set
            {
                sobe = value;
                OnPropertyChanged(nameof(Sobe));
            }
        }

        public Soba SelectedSoba
        {
            get { return selectedSoba; }
            set
            {
                selectedSoba = value;
                Visible = Visibility.Collapsed;
                Cleanup();
                IsEnabled = true;
                OnPropertyChanged(nameof(SelectedSoba));
            }
        }
        public void Refresh()
        {
            Sobe = new ObservableCollection<Soba>(service.ReceivesAllSobas());
            Hoteli = new ObservableCollection<Hotel>(service.ReceivesAllHotels());
        }

        public void Cleanup()
        {
            Tip = "";
            Opis = "";
            Napomena = "";
            SelectedHotel = null;
            IsEnabled = false;
        }


        public MyICommand ShowAddFields_ { get; set; }
        public MyICommand ShowEditFields_ { get; set; }
        public MyICommand Add_ { get; set; }
        public MyICommand Edit_ { get; set; }
        public MyICommand Delete_ { get; set; }


        public SobaViewModel()
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
                Tip = SelectedSoba.Tip;
                Opis = SelectedSoba.Opis;
                Napomena = SelectedSoba.Napomena;
                SelectedHotel = SelectedSoba.Hotel;
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
                Soba s = new Soba
                {
                    Tip = Tip,
                    Opis = Opis,
                    Napomena = Napomena,
                    Hotel = SelectedHotel,
                };
                service.AddSoba(s);
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
                Soba s = new Soba
                {
                    Tip = Tip,
                    Opis = Opis,
                    Napomena = Napomena,
                };
                service.EditSoba(SelectedSoba.Br_Sobe, s);
                Refresh();
                Cleanup();
                Visible = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Nisi popunio sva polja.", null, MessageBoxButton.OK);
            }
        }

        public void Delete()
        {
            service.DeleteSoba(SelectedSoba.Br_Sobe);
            Refresh();
            Cleanup();
            Visible = Visibility.Collapsed;
        }

        public bool Validate()
        {
            if (Tip == null || Tip == "")
                return false;
            if (Opis == null || Opis == "")
                return false;
            if (Napomena == null || Napomena == "")
                return false;
            if (SelectedHotel == null)
                return false;
            return true;
        }
    }
}
