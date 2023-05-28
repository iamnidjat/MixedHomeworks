using GameLibrary.Commands;
using GameLibrary.Entities;
using GameLibrary.Services;
using GameLibrary.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using GameLibrary.Models;

namespace GameLibrary.ViewModels
{
    public class DeleteVM : BaseViewModel
    {
        private GameCharacteristics model;
        private readonly CRUDOperations crudOperations;
        private readonly Game gameEntity;
        private ICommand deleteCommand;
        public ICommand NavigateHomeCommand { get; }

        public DeleteVM(NavigationStore navigationStore)
        {
            crudOperations = new();

            gameEntity = new();

            model = new();

            NavigateHomeCommand = new NavigateCommand<HomeVM>(navigationStore, () => new HomeVM(navigationStore));
        }

        public ICommand DeleteCommand
        {
            get
            {
                deleteCommand ??= new RelayCommand(param => DeleteData(), null);

                return deleteCommand;
            }
        }

        public void DeleteData()
        {
            if (MessageBox.Show("Confirm delete of this game?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    crudOperations.DeleteGame(Title);
                    MessageBox.Show("Game successfully deleted!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    Title = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while saving!" + ex.InnerException);
                }
            }
        }

        public string Title
        {
            get => gameEntity.Title;
            set
            {
                gameEntity.Title = value;
                OnPropertyChanged("Title");
            }
        }
    }
}
