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
    /// Interaction logic for PatientsView.xaml
    /// </summary>
    public partial class PatientsView : UserControl
    {
        protected Models.Database Database;

        public PatientsView()
        {
            InitializeComponent();

            Database = App.Current.Properties["Database"] as Models.Database;
            RefreshPatientsList();
        }

        private void NewPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            PatientDetails DetailsWindow = new PatientDetails();
            DetailsWindow.Title = "Nuovo paziente";
            DetailsWindow.Owner = App.Current.MainWindow;
            Models.Patient NewPatient = new Models.Patient();
            DetailsWindow.Patient = NewPatient;
            DetailsWindow.ShowDialog();

            if (DetailsWindow.Result == true)
            {
                NewPatient.SSN = NewPatient.SSN.ToUpper();
                Database.Patients.Add(NewPatient);
                Database.SaveChanges();
                RefreshPatientsList();
            }
        }

        private void EditPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PatientsListBox.SelectedItem == null)
            {
                return;
            }

            Models.Patient SelectedPatient = PatientsListBox.SelectedItem as Models.Patient;
            Models.Patient PatientCopy = new Models.Patient();
            PatientCopy.SetTo(SelectedPatient);

            PatientDetails DetailsWindow = new PatientDetails();
            DetailsWindow.Title = "Modifica paziente";
            DetailsWindow.Owner = App.Current.MainWindow;
            DetailsWindow.Patient = PatientCopy;
            DetailsWindow.ShowDialog();

            if (DetailsWindow.Result == true)
            {
                PatientCopy.SSN = PatientCopy.SSN.ToUpper();
                SelectedPatient.SetTo(PatientCopy);
                Database.SaveChanges();
                RefreshPatientsList();
            }
        }

        private void DeletePatientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PatientsListBox.SelectedItem == null)
            {
                return;
            }

            Models.Patient SelectedPatient = PatientsListBox.SelectedItem as Models.Patient;
            MessageBoxResult Result = MessageBox.Show("Eliminare il paziente selezionato?", "Conferma eliminazione", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                Database.Patients.Remove(SelectedPatient);
                Database.SaveChanges();
                RefreshPatientsList();
            }
        }

        private void RefreshPatientsList()
        {
            if (Database == null) { return; }
            var List = (from d in Database.Patients orderby d.LastName, d.FirstName ascending select d).ToList();
            PatientsListBox.DataContext = List;
        }

        private void PatientsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PatientsListBox.SelectedItem == null)
            {
                ExamsDataGrid.DataContext = new List<Models.ExamRecord>();
                return;
            }

            Models.Patient SelectedPatient = PatientsListBox.SelectedItem as Models.Patient;
            RefreshRecordsList(SelectedPatient);
        }

        private void NewExamBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PatientsListBox.SelectedItem == null)
            {
                return;
            }

            Models.Patient SelectedPatient = PatientsListBox.SelectedItem as Models.Patient;
            ExamRecordDetails DetailsWindow = new ExamRecordDetails();
            DetailsWindow.Title = "Nuovo esame";
            DetailsWindow.Owner = App.Current.MainWindow;
            Models.ExamRecord NewRecord = new Models.ExamRecord();
            NewRecord.PatientId = SelectedPatient.Id;
            NewRecord.Date = DateTime.Now.Date;
            DetailsWindow.Record = NewRecord;
            DetailsWindow.ShowDialog();

            if (DetailsWindow.Result == true)
            {
                Database.ExamRecords.Add(NewRecord);
                Database.SaveChanges();
                RefreshRecordsList(SelectedPatient);
            }
        }

        private void EditExamBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ExamsDataGrid.SelectedItem == null)
            {
                return;
            }

            Models.ExamRecord SelectedRecord = ExamsDataGrid.SelectedItem as Models.ExamRecord;
            Models.ExamRecord RecordCopy = new Models.ExamRecord();
            RecordCopy.SetTo(SelectedRecord);

            ExamRecordDetails DetailsWindow = new ExamRecordDetails();
            DetailsWindow.Title = "Modifica esame";
            DetailsWindow.Owner = App.Current.MainWindow;
            DetailsWindow.Record = RecordCopy;
            DetailsWindow.ShowDialog();

            if (DetailsWindow.Result == true)
            {
                SelectedRecord.SetTo(RecordCopy);
                Database.SaveChanges();
                RefreshRecordsList(PatientsListBox.SelectedItem as Models.Patient);
            }
        }

        private void DeleteExamBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ExamsDataGrid.SelectedItem == null)
            {
                return;
            }

            Models.ExamRecord SelectedRecord = ExamsDataGrid.SelectedItem as Models.ExamRecord;
            MessageBoxResult Result = MessageBox.Show("Eliminare l'esame selezionato?", "Conferma eliminazione", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                Database.ExamRecords.Remove(SelectedRecord);
                Database.SaveChanges();
                RefreshRecordsList(PatientsListBox.SelectedItem as Models.Patient);
            }
        }

        private void RefreshRecordsList(Models.Patient SelectedPatient)
        {
            List<Models.ExamRecord> List;
            if (SelectedPatient == null || SelectedPatient.ExamRecords == null)
            {
                List = new List<Models.ExamRecord>();
            }
            else
            {
                List = (from d in SelectedPatient.ExamRecords orderby d.Date descending select d).ToList();
            }
            ExamsDataGrid.DataContext = List;
        }
    }
}
