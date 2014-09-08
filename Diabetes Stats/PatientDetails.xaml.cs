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
    /// Interaction logic for PatientDetails.xaml
    /// </summary>
    public partial class PatientDetails : Window
    {
        protected Models.Patient patient;
        public Models.Patient Patient
        {
            get { return patient; }
            set
            {
                patient = value;
                DataContext = patient;
            }
        }

        public bool Result { get; set; }

        public PatientDetails()
        {
            InitializeComponent();
            Result = false;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrEmpty(patient.FirstName) == false) && (string.IsNullOrEmpty(patient.LastName) == false) && (string.IsNullOrEmpty(patient.SSN) == false))
            {
                Result = true;
                Close();
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Result = false;
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Validation.GetHasError(FirstNameTextBox) == true || Validation.GetHasError(LastNameTextBox) == true || Validation.GetHasError(SSNTextBox) == true)
            {
                OkBtn.IsEnabled = false;
                return;
            }

            if (string.IsNullOrEmpty(FirstNameTextBox.Text) == true || string.IsNullOrEmpty(LastNameTextBox.Text) == true || string.IsNullOrEmpty(SSNTextBox.Text) == true)
            {
                OkBtn.IsEnabled = false;
                return;
            }

            OkBtn.IsEnabled = true;
        }
    }
}
