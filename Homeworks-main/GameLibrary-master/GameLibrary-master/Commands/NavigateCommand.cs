using GameLibrary.Stores;
using GameLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _store;
        private readonly Func<TViewModel> _createVM;

        public NavigateCommand(NavigationStore store, Func<TViewModel> createVM)
        {
            _store = store; 
            _createVM = createVM;
        }

        public override void Execute(object parameter)
        {
            _store.CurrentViewModel = _createVM();
        }
    }
}
