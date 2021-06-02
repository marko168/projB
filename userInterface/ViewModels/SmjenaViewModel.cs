using repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace userInterface.ViewModels
{
    public class SmjenaViewModel:BaseViewModel
    {
        private string naz_Smjene;
        private string nap_Smjene;
        private string vrijeme_Od;
        private string vrijeme_Do;

        public string Naz_Smjene
        {
            get { return naz_Smjene; }
            set
            {
                naz_Smjene = value;
                OnPropertyChanged(nameof(Naz_Smjene));
            }
        }

        public string Nap_Smjene
        {
            get { return nap_Smjene; }
            set
            {
                nap_Smjene = value;
                OnPropertyChanged(nameof(Nap_Smjene));
            }
        }

        public string Vrijeme_Od
        {
            get { return vrijeme_Od; }
            set
            {
                vrijeme_Od = value;
                OnPropertyChanged(nameof(Vrijeme_Od));
            }
        }

        public string Vrijeme_Do
        {
            get { return vrijeme_Do; }
            set
            {
                vrijeme_Do = value;
                OnPropertyChanged(nameof(Vrijeme_Do));
            }
        }




        private Service service = new Service();
        private Visibility visible;
        private Visibility showAdd;
        private Visibility showEdit;
        private bool isEnabled;
        private ObservableCollection<Smjena> smjene;
        private Smjena selectedSmjena;

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
        public ObservableCollection<Smjena> Smjene
        {
            get { return smjene; }
            set
            {
                smjene = value;
                OnPropertyChanged(nameof(Smjene));
            }
        }

        public Smjena SelectedSmjena
        {
            get { return selectedSmjena; }
            set
            {
                selectedSmjena = value;
                Visible = Visibility.Collapsed;
                Cleanup();
                IsEnabled = true;
                OnPropertyChanged(nameof(SelectedSmjena));
            }
        }

        public void Refresh()
        {
            Smjene = new ObservableCollection<Smjena>(service.ReceivesAllSmjenas());
        }

        public void Cleanup()
        {
            Nap_Smjene = "";
            Naz_Smjene = "";
            Vrijeme_Do = "";
            Vrijeme_Od = "";
            IsEnabled = false;
        }


        public MyICommand ShowAddFields_ { get; set; }
        public MyICommand ShowEditFields_ { get; set; }
        public MyICommand Add_ { get; set; }
        public MyICommand Edit_ { get; set; }
        public MyICommand Delete_ { get; set; }


        public SmjenaViewModel()
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
                Naz_Smjene = SelectedSmjena.Naz_Smjene;
                Nap_Smjene = SelectedSmjena.Nap_Smjene;
                Vrijeme_Od = SelectedSmjena.Vrijeme_Od;
                Vrijeme_Do = SelectedSmjena.Vrijeme_Do;
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
                Smjena s = new Smjena
                {
                    Naz_Smjene = Naz_Smjene,
                    Nap_Smjene = Nap_Smjene,
                    Vrijeme_Od = Vrijeme_Od,
                    Vrijeme_Do = Vrijeme_Do,
                };
                service.AddSmjena(s);
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
                Smjena s = new Smjena
                {
                    Naz_Smjene = Naz_Smjene,
                    Nap_Smjene = Nap_Smjene,
                    Vrijeme_Od = Vrijeme_Od,
                    Vrijeme_Do = Vrijeme_Do,
                };
                service.EditSmjena(selectedSmjena.Id_Smjene, s);
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
            service.DeleteSmjena(SelectedSmjena.Id_Smjene);
            Refresh();
            Cleanup();
            Visible = Visibility.Collapsed;
        }

        public bool Validate()
        {
            if (Naz_Smjene == null || Naz_Smjene == "")
                return false;
            if (Nap_Smjene == null || Nap_Smjene == "")
                return false;
            if (Vrijeme_Od == null || Vrijeme_Od == "" || !Regex.IsMatch(Vrijeme_Od, "([0-1]?[0-9]?|2[0-3]):([0-5]?[0-9]?):([0-5]?[0-9]?)"))
                return false;
            if (vrijeme_Do == null || vrijeme_Do == "" || !Regex.IsMatch(Vrijeme_Do, "([0-1]?[0-9]?|2[0-3]):([0-5]?[0-9]?):([0-5]?[0-9]?)"))
                return false;
            return true;
        }
    }
}
