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
        public List<Tuple<int, int, int>> hallRows { get; set; }

        public event EventHandler<NotificationEventArgs> generateFieldEvent;
        
        #region commands
        public RelayCommand generateCommand { get; set; }
        #endregion

        public CassierViewModel()
        {
            hallRows = Hall.getHall("testHall.txt");
            generateCommand = new RelayCommand(generateButtons);
        }
		
        void generateButtons(object kek=null){
        	generateFieldEvent.Invoke(null, new NotificationEventArgs(hallRows));
        }
    }
}
