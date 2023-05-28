using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDownloader.Models
{
    internal class MainModel
    {
        public ObservableCollection<int> threadCounts = new() { 2, 3, 4, 5, 6, 7, 8 };

        public int SelectedValue { get; set; } = 2;

        public string LoadingInfo { get; set; } = "";

        public string FilePath { get; set; } = "";

        public string DestinationPath { get; set; } = "";

        public bool resumeButtonEnabled { get; set; }  = false;

        public bool pauseButtonEnabled { get; set; } = false;

        public bool cancelButtonEnabled { get; set; } = false;
    }
}
