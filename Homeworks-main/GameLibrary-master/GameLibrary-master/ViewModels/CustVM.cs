using GameLibrary.Commands;
using GameLibrary.Entities;
using GameLibrary.Models;
using GameLibrary.Services;
using GameLibrary.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace GameLibrary.ViewModels
{
    public class CustVM : BaseViewModel
    {
        private GameCharacteristics model;
        private readonly CRUDOperations crudOperations;
        private readonly Game gameEntity;
        private ICommand addCommand;
        public ICommand NavigateHomeCommand { get; }

        public CustVM(NavigationStore navigationStore)
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
            if (GameId <= 0 || Description == null || Manufacturer == null || Publisher == null
                || Developer == null || Tags == null || Int32.Parse(Raiting) < 0 || Int32.Parse(Raiting) > 100)
            {
                MessageBox.Show("Incorrect data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                crudOperations.AddingCharsForGames(model);
                MessageBox.Show("Data was added!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                GameId = 0;
                Description = string.Empty;
                Manufacturer = string.Empty;
                Publisher = string.Empty;
                Developer = string.Empty;
                Raiting = string.Empty;
                Comments = string.Empty;
                Tags = string.Empty;
            }
        }

        //public string GameTitle
        //{
        //    get => model.GameTitle;
        //    set
        //    {
        //        model.GameTitle = value;
        //        OnPropertyChanged("GameTitle");
        //    }
        //}

        public int GameId
        {
            get => model.GameId;
            set
            {
                model.GameId = value;
                OnPropertyChanged("GameId");
            }
        }

        public string Developer
        {
            get => model.Developer;
            set
            {
                model.Developer = value;
                OnPropertyChanged("Developer");
            }
        }

        public string Description
        {
            get => model.Description;
            set
            {
                model.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public string Manufacturer
        {
            get => model.Manufacturer;
            set
            {
                model.Manufacturer = value;
                OnPropertyChanged("Manufacturer");
            }
        }

        public string Raiting
        {
            get => model.Raiting;
            set
            {
                model.Raiting = value;
                OnPropertyChanged("Raiting");
            }
        }

        public string Publisher
        {
            get => model.Publisher;
            set
            {
                model.Publisher = value;
                OnPropertyChanged("Publisher");
            }
        }

        public string Tags
        {
            get => model.Tags;
            set
            {
                model.Tags = value;
                OnPropertyChanged("Tags");
            }
        }

        public string Comments
        {
            get => model.Comments;
            set
            {
                model.Comments = value;
                OnPropertyChanged("Comments");
            }
        }

        public DateTime IssueDate
        {
            get => model.IssueDate;
            set
            {
                model.IssueDate = value;
                OnPropertyChanged("IssueDate");
            }
        }
    }
}
