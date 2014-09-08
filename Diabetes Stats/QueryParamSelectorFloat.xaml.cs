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
    /// Interaction logic for QueryParamSelectorFloat.xaml
    /// </summary>
    public partial class QueryParamSelectorFloat : UserControl
    {
        public string ParameterName { get; set; }
        public bool IsActive { get; set; }
        public float MinValue { get; set; }
        public float MaxValue { get; set; }

        public QueryParamSelectorFloat()
        {
            InitializeComponent();

            ParameterName = "Nome parametro";
            IsActive = false;
            MinValue = MaxValue = 0.0f;
            this.DataContext = this;
        }
    }
}
