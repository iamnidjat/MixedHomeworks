using GameLibrary.Commands;
using GameLibrary.Entities;
using GameLibrary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GameLibrary.Stores;
using GameLibrary.Models;

namespace GameLibrary.ViewModels
{
    public class HomeVM : BaseViewModel
    {
        private GameCharacteristics model;
        private readonly CRUDOperations crudOperations;
        private Game gameEntity;
        private ICommand searchCommand;
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateUpdateCommand { get; }
        public ICommand NavigateDeleteCommand { get; }
        public ICommand NavigateCustCommand { get; }
        public ICommand doubleClickCommand;

        private bool itemVisibility;

        public bool ItemVisibility
        {
            get => itemVisibility;
            set
            {
                itemVisibility = value;
                OnPropertyChanged("ItemVisibility");
            }
        }      

        public ICommand DoubleClickCommand
        {
            get
            {
                doubleClickCommand ??= new RelayCommand(param =>ShowInfo(), null);

                return doubleClickCommand;
            }
        }

        public void ShowInfo()
        {
            ItemVisibility = true;

            crudOperations.ShowCharsForGames(GamesChars, Id);
        }

        public ICommand SearchCommand
        {
            get
            {
                searchCommand ??= new RelayCommand(param => SearchData(), null);

                return searchCommand;
            }
        }

        public HomeVM(NavigationStore navigationStore)
        {
            crudOperations = new();

            gameEntity = new();

            model = new();

            GetAll();

            NavigateAddCommand = new NavigateCommand<AddVM>(navigationStore, () => new AddVM(navigationStore));
            NavigateUpdateCommand = new NavigateCommand<UpdateVM>(navigationStore, () => new UpdateVM(navigationStore));
            NavigateDeleteCommand = new NavigateCommand<DeleteVM>(navigationStore, () => new DeleteVM(navigationStore));
            NavigateCustCommand = new NavigateCommand<CustVM>(navigationStore, () => new CustVM(navigationStore));
        }

        public void SearchData()
        {
            crudOperations.SearchGame(Title, Games);

            Title = string.Empty;
        }

        public void GetAll()
        {
            crudOperations.ShowGames(Games);
        }

        public int Id
        {
            get => gameEntity.Id;
            set
            {
                gameEntity.Id = value;
                OnPropertyChanged("Id");
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

        public ObservableCollection<Game> Games
        {
            get => gameEntity.Games;
            set
            {
                gameEntity.Games = value;
                OnPropertyChanged("Games");
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

        public ObservableCollection<GameCharacteristics> GamesChars
        {
            get => model.GamesChars;
            set
            {
                model.GamesChars = value;
                OnPropertyChanged("GamesChars");
            }
        }
    }
}
