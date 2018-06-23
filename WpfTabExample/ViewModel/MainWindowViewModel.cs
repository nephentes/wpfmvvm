using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using WpfTabExample.ViewModel;

namespace WpfApp4.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        public ObservableCollection<TabViewModel> tabs { get; set; }

       private RelayCommand _refreshCommand;

        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand
                  ?? (_refreshCommand = new RelayCommand(
                    async () =>
                    {
                        tabs.Add(new TabViewModel(string.Format("Tab {0}", tabs.Count + 1)));
                    }));
            }
        }

        public MainWindowViewModel()
        {
            tabs = new ObservableCollection<TabViewModel>();
            tabs.Add(new TabViewModel("Tab 1"));
            tabs.Add(new TabViewModel("Tab 2"));
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
    }
}