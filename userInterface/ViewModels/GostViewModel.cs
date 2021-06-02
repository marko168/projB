using repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace userInterface.ViewModels
{
    public class GostViewModel : BaseViewModel
    {
        private string adresa;
        private string kontakt;
        private DateTime datum_P;
        private string vrijeme_P;
        

        public string Kontakt
        {
            get { return kontakt; }
            set
            {
                kontakt = value;
                OnPropertyChanged(nameof(Kontakt));
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

        public DateTime Datum_P
        {
            get { return datum_P; }
            set
            {
                datum_P = value;
                OnPropertyChanged(nameof(Datum_P));
            }
        }

        public string Vrijeme_P
        {
            get { return vrijeme_P; }
            set
            {
                vrijeme_P = value;
                OnPropertyChanged(nameof(Vrijeme_P));
            }
        }



        private Service service = new Service();
        private Visibility visible;
        private Visibility showAdd;
        private Visibility showEdit;
        private bool isEnabled;
        private ObservableCollection<Gost> gosti;
        private ObservableCollection<Recepcija> recepcije;
        private Gost selectedGost;
        private Recepcija selectedRecepcija;

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
        public ObservableCollection<Gost> Gosti
        {
            get { return gosti; }
            set
            {
                gosti = value;
                OnPropertyChanged(nameof(Gosti));
            }
        }

        public Gost SelectedGost
        {
            get { return selectedGost; }
            set
            {
                selectedGost = value;
                Visible = Visibility.Collapsed;
                Cleanup();
                IsEnabled = true;
                OnPropertyChanged(nameof(SelectedGost));
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

        public Recepcija SelectedRecepcija
        {
            get { return selectedRecepcija; }
            set
            {
                selectedRecepcija = value;
                OnPropertyChanged(nameof(SelectedRecepcija));
            }
        }

        public void Refresh()
        {
            Gosti = new ObservableCollection<Gost>(service.ReceivesAllGosts());
            Recepcije = new ObservableCollection<Recepcija>(service.ReceivesAllRecepcijas());
        }

        public void Cleanup()
        {
            Kontakt = "";
            Adresa = "";
            IsEnabled = false;
        }


        public MyICommand ShowAddFields_ { get; set; }
        public MyICommand ShowEditFields_ { get; set; }
        public MyICommand Add_ { get; set; }
        public MyICommand Edit_ { get; set; }
        public MyICommand Delete_ { get; set; }


        public GostViewModel()
        {
            ShowAddFields_ = new MyICommand(ShowAddFields);
            ShowEditFields_ = new MyICommand(ShowEditFields);
            Add_ = new MyICommand(Add);
            Edit_ = new MyICommand(Edit);
            Delete_ = new MyICommand(Delete);
            Datum_P = DateTime.Now;
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
                Adresa = SelectedGost.Adresa;
                Kontakt = SelectedGost.Kontakt;
                Datum_P = SelectedGost.Datum_P;
                Vrijeme_P = SelectedGost.Vrijeme_P;
                SelectedRecepcija = SelectedGost.Recepcija;
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
                Gost g = new Gost
                {
                    Kontakt = Kontakt,
                    Adresa = Adresa,
                    Datum_P = Datum_P.Date,
                    Vrijeme_P = Vrijeme_P,
                    Recepcija = SelectedRecepcija
                };
                service.AddGost(g);
                Refresh();
                Cleanup();
                Visible = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Nisi popunio sva polja. Ili vrijeme nije u formatu hh:mm:ss.");
            }

        }

        public void Edit()
        {
            if (Validate())
            {
                Gost g = new Gost
                {
                    Kontakt = Kontakt,
                    Adresa = Adresa,
                    Datum_P = Datum_P.Date,
                    Vrijeme_P = Vrijeme_P,
                    Recepcija = SelectedRecepcija
                };
                service.EditGost(SelectedGost.MBR, g);
                Refresh();
                Cleanup();
                Visible = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Nisi popunio sva polja. Ili vrijeme nije u formatu hh:mm:ss.", null, MessageBoxButton.OK);
            }
        }

        public void Delete()
        {
            service.DeleteGost(SelectedGost.MBR);
            Refresh();
            Cleanup();
            Visible = Visibility.Collapsed;
        }

        public bool Validate()
        {
            if (Kontakt == null || Kontakt == "")
                return false;
            if (Adresa == null || Adresa == "")
                return false;
            if (Datum_P == null)
                return false;
            if (Vrijeme_P == null || !Regex.IsMatch(Vrijeme_P, "([0-1]?[0-9]?|2[0-3]):([0-5]?[0-9]?):([0-5]?[0-9]?)"))
                return false;
            if (SelectedRecepcija == null)
                return false;
            return true;
        }
    }
}
