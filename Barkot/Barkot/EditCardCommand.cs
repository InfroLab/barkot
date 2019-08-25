using System;
using System.Windows.Input;

namespace Barkot
{
    public class EditCardCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        CardViewModel viewModel;
        public EditCardCommand(CardViewModel vm)
        {
            viewModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return viewModel != null;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                viewModel.EditCard();
        }
    }
}