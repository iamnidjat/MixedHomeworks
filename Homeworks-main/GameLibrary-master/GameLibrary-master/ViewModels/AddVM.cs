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
using System.Windows.Ink;
using System.Windows.Input;

namespace GameLibrary.ViewModels
{
    public class AddVM : BaseViewModel
    {
        private GameCharacteristics model;
        private readonly CRUDOperations crudOperations;
        private readonly Game gameEntity;
        private ICommand addCommand;
        public ICommand NavigateHomeCommand { get; }

        public AddVM(NavigationStore navigationStore)
        {
            crudOperations = new();
            gameEntity = new();
            model = new();

            NavigateHomeCommand = new NavigateCommand<HomeVM>(navigationStore, () => new HomeVM(navigationStore));
        }

        public ICommand AddCommand
        {
            get
            {
                addCommand ??= new RelayCommand(param => AddData(), null);

                return addCommand;
            }
        }

        public void AddData()
        {
            if (Title == null || Category == null || Price <= 0 || Price.ToString().Any(char.IsLetter))
            {
                MessageBox.Show("Incorrect data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                crudOperations.AddGame(gameEntity);
                MessageBox.Show("Data was added!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                Title = string.Empty;
                Category = string.Empty;
                Price = 0;
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
