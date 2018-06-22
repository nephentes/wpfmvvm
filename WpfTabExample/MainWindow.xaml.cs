using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{

    public class TabModel
    {
        static Random rnd = new Random();

        public string Name { get; set; }

        public List<string> Values { get; set; }

        public TabModel()
        {
            Values = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                Values.Add(string.Format("Item {0}", rnd.Next()));
            }
        }

        public TabModel(string name) : this()
        {
            Name = name;
        }

    }


    public class MainModel
    {

        public ObservableCollection<TabModel> tabs { get; set; }

        public MainModel()
        {
            tabs = new ObservableCollection<TabModel>();
        }


        private RelayCommand _refreshCommand;

        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand
                  ?? (_refreshCommand = new RelayCommand(
                    async () =>
                    {
                        tabs.Add(new TabModel(string.Format("Tab {0}", tabs.Count + 1)));
                    }));
            }
        }

    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MainModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainModel();

            viewModel.tabs.Add(new TabModel("Tab 1"));
            viewModel.tabs.Add(new TabModel("Tab 2"));
            DataContext = viewModel;
        }
    }
}
