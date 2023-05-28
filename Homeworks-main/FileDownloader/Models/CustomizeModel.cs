using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDownloader.Models
{
    public class CustomizeModel
    {
        public string FileTitleForDeleting { get; set; } = "";

        public string FileTitleForMoving { get; set; } = "";

        public string FileTitleForRenaming { get; set; } = "";
    }
}
