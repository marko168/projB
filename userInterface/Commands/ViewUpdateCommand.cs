using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using userInterface.ViewModels;

namespace userInterface.Commands
{
    public class ViewUpdateCommand :ICommand
    {
        private MainViewModel viewModel;

        public ViewUpdateCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter.ToString() == "Hotel")
            {
                viewModel.SelectedViewModel = new HotelViewModel();
            }
            if (parameter.ToString() == "Radnici")
            {
                viewModel.SelectedViewModel = new RadnikViewModel();
            }
            if (parameter.ToString() == "Smjene")
            {
                viewModel.SelectedViewModel = new SmjenaViewModel();
            }
            if (parameter.ToString() == "Recepcije")
            {
                viewModel.SelectedViewModel = new RecepcijaViewModel();
            }
            if (parameter.ToString() == "Sobe")
            {
                viewModel.SelectedViewModel = new SobaViewModel();
            }
            if (parameter.ToString() == "Gosti")
            {
                viewModel.SelectedViewModel = new GostViewModel();
            }
            if (parameter.ToString() == "Smjestaji")
            {
                viewModel.SelectedViewModel = new SmjestajViewModel();
            }

        }
    }
}
