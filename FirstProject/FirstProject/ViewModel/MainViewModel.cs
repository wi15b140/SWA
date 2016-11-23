using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Windows.Threading;

namespace FirstProject.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {

        private ObservableCollection<TruckVM> waitingTrucks = new ObservableCollection<TruckVM>();
        private ObservableCollection<TruckVM> readyTrucks = new ObservableCollection<TruckVM>();
        private ObservableCollection<LoadVM> load = new ObservableCollection<LoadVM>();
        private DispatcherTimer timer = new DispatcherTimer();

        private TruckVM selectedWaitingTruck;
        private TruckVM selectedReadyTruck;
        private RelayCommand deleteBtnClicked;
        private RelayCommand startGenBtnClicked;
        private RelayCommand stopGenBtnClicked;
        private RelayCommand shiftTrucktoReady;

        #region PROPERTIES

        public RelayCommand DeleteBtnClicked
        {
            get { return deleteBtnClicked; }
            set { deleteBtnClicked = value; }
        }

        public RelayCommand StartGenBtnClicked
        {
            get { return startGenBtnClicked; }
            set { startGenBtnClicked = value; }
        }


        public RelayCommand StopGenBtnClicked
        {
            get { return stopGenBtnClicked; }
            set { stopGenBtnClicked = value; }
        }

        public RelayCommand ShiftTrucktoReady
        {
            get { return shiftTrucktoReady; }
            set { shiftTrucktoReady = value; }
        }

        public ObservableCollection<TruckVM> WaitingTrucks
        {
            get { return waitingTrucks; }

            set { waitingTrucks = value; }
        }

        public ObservableCollection<TruckVM> ReadyTrucks
        {
            get
            {
                return readyTrucks;
            }

            set
            {
                readyTrucks = value;
            }
        }

        public DispatcherTimer Timer
        {
            get
            {
                return timer;
            }

            set
            {
                timer = value;
            }
        }

        public TruckVM SelectedWaitingTruck
        {
            get
            {
                return selectedWaitingTruck;
            }

            set
            {
                selectedWaitingTruck = value;
            }
        }

        public TruckVM SelectedReadyTruck
        {
            get
            {
                return selectedReadyTruck;
            }

            set
            {
                selectedReadyTruck = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        public MainViewModel()
        {
            

            DeleteBtnClicked = new RelayCommand(ClearAllEntries);
            StartGenBtnClicked = new RelayCommand(StartGeneratingLoadItems);
            StopGenBtnClicked = new RelayCommand(StopGeneratingLoadItems);
            ShiftTrucktoReady = new RelayCommand(ShiftTrucks);

        }

        private void ClearAllEntries()
        {
            readyTrucks.Clear();
            waitingTrucks.Clear();
        }

        private void StopGeneratingLoadItems()
        {
            timer.Stop();
        }

        private void StartGeneratingLoadItems()
        {
            waitingTrucks.Add(new TruckVM("Vienna", 300));
            waitingTrucks[0].Truckload.Add(new LoadVM("Notebook", 2, 10));
        }

        private void ShiftTrucks()
        {
            readyTrucks.Add(selectedWaitingTruck);
        }
 
    }
}