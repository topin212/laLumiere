using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_Lumière.Model;
using La_Lumière.Util;


namespace La_Lumière.ViewModels
{
    class CassierViewModel : BaseViewModel
    {
        public List<Tuple<int, int>> hallRows { get; set; }

        #region commands
        public RelayCommand generateCommand { get; set; }
        #endregion

        Hall hall;

        public CassierViewModel()
        {
            hallRows = Hall.getHall("testHall.txt");
        }

    }
}
