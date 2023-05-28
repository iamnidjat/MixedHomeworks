using FileDownloader.Commands;
using FileDownloader.Models;
using FileDownloader.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FileDownloader.ViewModels
{
    public class CustomizingWindowViewModel : BaseViewModel
    {
        private readonly CustomizeModel _model;
        public ICommand NavigateHomeCommand { get; }
        public ICommand doCommand;

        public CustomizingWindowViewModel(NavigationStore navigationStore)
        {
            _model = new CustomizeModel();

            NavigateHomeCommand = new NavigateCommand<HomeVM>(navigationStore, () => new HomeVM(navigationStore));
        }

        public ICommand DoCommand
        {
            get
            {
                doCommand ??= new RelayCommand(param => DoAction(), null);

                return doCommand;
            }
        }


        public void DoAction()
        {
            if (FileTitleForDeleting != string.Empty && FileTitleForMoving == string.Empty && FileTitleForRenaming == string.Empty)
            {
                if (File.Exists(FileTitleForDeleting))
                {
                    try
                    {
                        File.Delete(FileTitleForDeleting);

                        MessageBox.Show("File was deleted succesfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        FileTitleForDeleting = "";
                    }
                    catch (Exception e) when (e is ArgumentException or ArgumentNullException)
                    {
                        MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("This file doesn't exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else if (FileTitleForDeleting == string.Empty && FileTitleForMoving != string.Empty && FileTitleForRenaming == string.Empty)
            {
                if (File.Exists(FileTitleForMoving.Split(", ")[0]))
                {
                    try
                    {
                        if (File.Exists(FileTitleForMoving.Split(", ")[1]))
                        {
                            File.Delete(FileTitleForMoving.Split(", ")[1]);
                        }

                        File.Move(FileTitleForMoving.Split(", ")[0], FileTitleForMoving.Split(", ")[1]);

                        MessageBox.Show("File was moved succesfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        FileTitleForMoving = "";
                    }
                    catch (Exception e) when (e is ArgumentException or ArgumentNullException)
                    {
                        MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("This file doesn't exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            

            else if (FileTitleForDeleting == string.Empty && FileTitleForMoving == string.Empty && FileTitleForRenaming != string.Empty)
            {
                if (File.Exists(FileTitleForRenaming.Split(", ")[0]))
                {
                    try
                    {
                        if (File.Exists(FileTitleForRenaming.Split(", ")[1]))
                        {
                            File.Delete(FileTitleForRenaming.Split(", ")[1]);
                        }

                        File.Move(FileTitleForRenaming.Split(", ")[0], FileTitleForRenaming.Split(", ")[1]);

                        MessageBox.Show("File was renamed succesfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        FileTitleForRenaming = "";
                    }
                    catch (Exception e) when (e is ArgumentException or ArgumentNullException)
                    {
                        MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("This file doesn't exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public string FileTitleForDeleting
        {
            get => _model.FileTitleForDeleting;

            set
            {
                _model.FileTitleForDeleting = value;
                OnPropertyChanged("FileTitleForDeleting");
            }
        }

        public string FileTitleForRenaming
        {
            get => _model.FileTitleForRenaming;
            set
            {
                _model.FileTitleForRenaming = value;
                OnPropertyChanged("FileTitleForRenaming");
            }
        }

        public string FileTitleForMoving
        {
            get => _model.FileTitleForMoving;
            set
            {
                _model.FileTitleForMoving = value;
                OnPropertyChanged("FileTitleForMoving");
            }
        }
    }
}

