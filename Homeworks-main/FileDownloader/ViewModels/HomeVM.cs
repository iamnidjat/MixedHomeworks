using Downloader;//
using FileDownloader.Commands;
using FileDownloader.Models;
using FileDownloader.Stores;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FileDownloader.ViewModels
{
    public class HomeVM : BaseViewModel
    {
        private readonly MainModel model;
        public ObservableCollection<int> ThreadCounts { get; }
        public ICommand NavigateCustCommand { get; }
        public ICommand downloadCommand;
        public ICommand fileDialogCommand;
        public ICommand pauseCommand;
        public ICommand resumeCommand;
        public ICommand cancelCommand;
        private bool flag = true;
        private readonly DownloadConfiguration downloadOpt;
        private readonly DownloadService downloader;

        public HomeVM(NavigationStore navigationStore)
        {
            model = new MainModel();

            ThreadCounts = model.threadCounts;

            NavigateCustCommand = new NavigateCommand<CustomizingWindowViewModel>(navigationStore, () => new CustomizingWindowViewModel(navigationStore));

            downloadOpt = new DownloadConfiguration()
            {
                BufferBlockSize = 10240,
                ChunkCount = SelectedValue,
                MaximumBytesPerSecond = 1024 * 1024,
                MaxTryAgainOnFailover = int.MaxValue,
                ParallelDownload = true,
                Timeout = 1000,
                RequestConfiguration =
                    {
                        Accept = "*/*",
                        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                        CookieContainer = new CookieContainer(),
                        Headers = new WebHeaderCollection(),
                        KeepAlive = false,
                        ProtocolVersion = HttpVersion.Version11,
                        UseDefaultCredentials = false,
                        UserAgent = $"DownloaderSample/{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}"
                    }
            };

            downloader = new DownloadService(downloadOpt);
        }

        public ICommand FileDialogCommand
        {
            get
            {
                fileDialogCommand ??= new RelayCommand(param => OpenFile(), null);

                return fileDialogCommand;
            }
        }

        public ICommand DownloadCommand
        {
            get
            {
                downloadCommand ??= new RelayCommand(param => DownloadFile(), null);

                return downloadCommand;
            }
        }

        public ICommand ResumeCommand
        {
            get
            {
                resumeCommand ??= new RelayCommand(param => Resume(), null);

                return resumeCommand;
            }
        }

        public ICommand PauseCommand
        {
            get
            {
                pauseCommand ??= new RelayCommand(param => Pause(), null);

                return pauseCommand;
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                cancelCommand ??= new RelayCommand(param => Cancel(), null);

                return cancelCommand;
            }
        }

        public async Task DownloadFile()
        {
            if (FilePath != string.Empty)
            {
                PauseButtonEnabled = true;
                CancelButtonEnabled = true;

                Thread myThread = new(async () =>
                {
                    LoadingInfo = "Loading file...";

                    await downloader.DownloadFileTaskAsync(FilePath, DestinationPath);

                    if (flag)
                    {
                        MessageBox.Show("File was downloaded", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        LoadingInfo = string.Empty;
                        FilePath = string.Empty;
                        DestinationPath = string.Empty;
                        SelectedValue = 2;
                    }
                    else
                    {
                        flag = true;
                    }
                });

                myThread.Start();
            }
        }
        
        public void Resume()
        {
            ResumeButtonEnabled = false;
            PauseButtonEnabled = true;

            LoadingInfo = "Loading file...";
            downloader.Resume();        
        }

        public void Pause()
        {
            ResumeButtonEnabled = true;
            PauseButtonEnabled = false;
            
            LoadingInfo = "Pause...";
            downloader.Pause();
        }

        public void Cancel()
        {
            ResumeButtonEnabled = false;
            PauseButtonEnabled = false;
            CancelButtonEnabled = false;
            flag = false;

            downloader.CancelAsync();
            MessageBox.Show("Downloading was canceled", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            LoadingInfo = string.Empty;
            FilePath = string.Empty;
            DestinationPath = string.Empty;
            SelectedValue = 2;
        }

        public void OpenFile()
        {
            var dialog = new SaveFileDialog()
            {
                RestoreDirectory = true,
                Filter = "PNG files|*.png|\r\nJPEG files|*.jpg|\r\nPicture files|*.bmp;*.jpg;*.gif;*.png;*.tif|\r\nCS files|*.cs|\r\nProject files|*.csproj|\r\nProgram files|*.cs;*.csproj;*.sln;* | All files(*.*) | *.*"
            };

            if (dialog.ShowDialog() == true)
            {
                DestinationPath = dialog.FileName;
            }
        }

        public int SelectedValue
        {
            get => model.SelectedValue;
            set
            {
                model.SelectedValue = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public string LoadingInfo
        {
            get => model.LoadingInfo;
            set
            {
                model.LoadingInfo = value;
                OnPropertyChanged("LoadingInfo");
            }
        }


        public string FilePath
        {
            get => model.FilePath;
            set
            {
                model.FilePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        public string DestinationPath
        {
            get => model.DestinationPath;
            set
            {
                model.DestinationPath = value;
                OnPropertyChanged("DestinationPath");
            }
        }

        public bool PauseButtonEnabled
        {
            get => model.pauseButtonEnabled;
            set
            {
                model.pauseButtonEnabled = value;
                OnPropertyChanged("PauseButtonEnabled");
            }
        }

        public bool ResumeButtonEnabled
        {
            get => model.resumeButtonEnabled;
            set
            {
                model.resumeButtonEnabled = value;
                OnPropertyChanged("ResumeButtonEnabled");
            }
        }

        public bool CancelButtonEnabled
        {
            get => model.cancelButtonEnabled;
            set
            {
                model.cancelButtonEnabled = value;
                OnPropertyChanged("CancelButtonEnabled");
            }
        }
    }
}
