using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiabetesStats
{
    /// <summary>
    /// Interaction logic for QueryParamSelectorDate.xaml
    /// </summary>
    public partial class QueryParamSelectorDate : UserControl
    {
        public string ParameterName { get; set; }
        public bool IsActive { get; set; }
        public DateTime MinValue { get; set; }
        public DateTime MaxValue { get; set; }

        public QueryParamSelectorDate()
        {
            InitializeComponent();

            ParameterName = "Nome parametro";
            IsActive = false;
            MaxValue = DateTime.Now.Date;
            MinValue = MaxValue.AddMonths(-1);
            this.DataContext = this;
        }

        private void DatePicker_LostFocus(object sender, RoutedEventArgs e)
        {
            if (MinValue.CompareTo(MaxValue) >= 0)
            {
                MinValue = MaxValue.AddDays(-1.0);
                MinValDatePicker.SelectedDate = MinValue;
            }
        }
    }
}
