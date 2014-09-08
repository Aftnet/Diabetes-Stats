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
using System.Windows.Shapes;

namespace DiabetesStats
{
    /// <summary>
    /// Interaction logic for ExamRecordDetails.xaml
    /// </summary>
    public partial class ExamRecordDetails : Window
    {
        protected Models.ExamRecord record;
        public Models.ExamRecord Record
        {
            get { return record; }
            set
            {
                record = value;
                DataContext = record;
            }
        }

        public bool Result { get; set; }

        public ExamRecordDetails()
        {
            InitializeComponent();
            Result = false;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Result = true;
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Result = false;
            Close();
        }
    }
}
