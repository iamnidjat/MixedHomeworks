using GameLibrary.Commands;
using GameLibrary.Entities;
using GameLibrary.Models;
using GameLibrary.Services;
using GameLibrary.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GameLibrary.ViewModels
{
    public class UpdateVM : BaseViewModel
    {
        private GameCharacteristics model;
        private readonly CRUDOperations crudOperations;
        private readonly Game gameEntity;
        private ICommand updateCommand;
        public ICommand NavigateHomeCommand { get; }

        public UpdateVM(NavigationStore navigationStore)
        {
            crudOperations = new();

            gameEntity = new();

            model = new();

            NavigateHomeCommand = new NavigateCommand<HomeVM>(navigationStore, () => new HomeVM(navigationStore));
        }

        public ICommand UpdateCommand
        {
            get
            {
                updateCommand ??= new RelayCommand(param => UpdateData(), null);

                return updateCommand;
            }
        }

        public void UpdateData()
        {
            if (oldTitle == null || Title == null || Category == null || Price <= 0 || Price.ToString().Any(char.IsLetter))
            {
                MessageBox.Show("Incorrect data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                crudOperations.UpdateGame(oldTitle, gameEntity);
                MessageBox.Show("Data was updated!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                oldTitle = string.Empty;
                Title = string.Empty;
                Category = string.Empty;
                Price = 0;
            }
        }

        private string _oldTitle;

        public string oldTitle
        {
            get => _oldTitle;
            set
            {
                _oldTitle = value;
                OnPropertyChanged("oldTitle");
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

        public string Category
        {
            get => gameEntity.Category;
            set
            {
                gameEntity.Category = value;
                OnPropertyChanged("Category");
            }
        }

        public int Price
        {
            get => gameEntity.Price;
            set
            {
                gameEntity.Price = value;
                OnPropertyChanged("Price");
            }
        }
    }
}