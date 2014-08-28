using System;
using System.Collections.Generic;
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

namespace DocumentStates_Biller.DocumentControl
{
    /// <summary>
    /// Interaktionslogik für TabContent.xaml
    /// </summary>
    public partial class TabContent : UserControl
    {
        public TabContent()
        {
            InitializeComponent();
        }

        private void Office2013Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ViewModel;
            if (vm.SelectedTag.Date.DayOfYear == DateTime.Today.DayOfYear)
                vm.SelectedTag.Date = DateTime.Now;
            vm.ReceiveData(vm.SelectedTag);
        }
    }
}
