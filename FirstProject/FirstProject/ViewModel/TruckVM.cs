using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.ViewModel
{
    public class TruckVM
    {

        private string source;
        private int duration;
        ObservableCollection<LoadVM> truckload = new ObservableCollection<LoadVM>();

        public TruckVM(string source, int duration)
        {
            this.source = source;
            this.duration = duration;
        }

        public string Source
        {
            get
            {
                return source;
            }

            set
            {
                source = value;
            }
        }

        public int Duration
        {
            get
            {
                return duration;
            }

            set
            {
                duration = value;
            }
        }

        public ObservableCollection<LoadVM> Truckload
        {
            get
            {
                return truckload;
            }

            set
            {
                truckload = value;
            }
        }

        

        public override string ToString()
        {
            return source +  " " + duration;
        }


    }
}
