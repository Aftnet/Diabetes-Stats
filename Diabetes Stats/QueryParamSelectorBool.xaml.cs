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
    /// Interaction logic for QueryParamSelectorBool.xaml
    /// </summary>
    public partial class QueryParamSelectorBool : UserControl
    {
        public string ParameterName { get; set; }
        public bool IsActive { get; set; }
        public bool Value { get; set; }

        public QueryParamSelectorBool()
        {
            InitializeComponent();

            ParameterName = "Nome parametro";
            IsActive = false;
            Value = false;
            this.DataContext = this;
        }
    }
}
