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
    public class SmjestajViewModel:BaseViewModel
    {

        private Service service = new Service();
        private Visibility visible;
        private Visibility showAdd;
        private Visibility showEdit;
        private bool isEnabled;
        private ObservableCollection<Smjestaj> smjestaji;
        private ObservableCollection<Gost> gosti;
        private ObservableCollection<Soba> sobe;
        private Smjestaj selectedSmjestaj;
        private Gost selectedGost;
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

        public ObservableCollection<Smjestaj> Smjestaji
        {
            get { return smjestaji; }
            set
            {
                smjestaji = value;
                OnPropertyChanged(nameof(Smjestaji));
            }
        }

        public Smjestaj SelectedSmjestaj
        {
            get { return selectedSmjestaj; }
            set
            {
                selectedSmjestaj = value;
                Visible = Visibility.Collapsed;
                Cleanup();
                IsEnabled = true;
                OnPropertyChanged(nameof(SelectedSmjestaj));
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
                OnPropertyChanged(nameof(SelectedGost));
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
                OnPropertyChanged(nameof(SelectedSoba));
            }
        }

        public void Refresh()
        {
            Smjestaji = new ObservableCollection<Smjestaj>(service.ReceivesAllSmjestajs());
            Gosti = new ObservableCollection<Gost>(service.ReceivesAllGosts());
            Sobe = new ObservableCollection<Soba>(service.ReceivesAllSobas());
        }

        public void Cleanup()
        {
            SelectedGost = null;
            SelectedSoba = null;
            IsEnabled = false;
        }


        public MyICommand ShowAddFields_ { get; set; }
        public MyICommand ShowEditFields_ { get; set; }
        public MyICommand Add_ { get; set; }
        public MyICommand Edit_ { get; set; }
        public MyICommand Delete_ { get; set; }


        public SmjestajViewModel()
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
                SelectedGost = SelectedSmjestaj.Gost;
                SelectedSoba = SelectedSmjestaj.Soba;
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
                Smjestaj s = new Smjestaj
                {
                    Gost = SelectedGost,
                    Soba = SelectedSoba
                };
                service.AddSmjestaj(s);
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
                Smjestaj s = new Smjestaj
                {
                    Gost = SelectedGost,
                    Soba = SelectedSoba
                };
                service.EditSmjestaj(SelectedSmjestaj.Id_Smjestaj, s);
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
            service.DeleteSmjestaj(SelectedSmjestaj.Id_Smjestaj);
            Refresh();
            Cleanup();
            Visible = Visibility.Collapsed;
        }

        public bool Validate()
        {
            if (SelectedGost == null)
                return false;
            if (SelectedSoba == null)
                return false;
            return true;
        }
    }
}
