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
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        protected Models.Database Database;

        public SearchView()
        {
            InitializeComponent();

            Database = App.Current.Properties["Database"] as Models.Database;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            IQueryable<Models.ExamRecord> ExamRecordsFound = Database.ExamRecords;

            if (DateSelector.IsActive == true)
            {
                ExamRecordsFound = (from d in ExamRecordsFound where d.Date.CompareTo(DateSelector.MinValue) >= 0 select d);
                ExamRecordsFound = (from d in ExamRecordsFound where d.Date.CompareTo(DateSelector.MaxValue) <= 0 select d);
            }

            if (WeightSelector.IsActive == true)
            {
                ExamRecordsFound = (from d in ExamRecordsFound where d.Weight >= WeightSelector.MinValue select d);
                ExamRecordsFound = (from d in ExamRecordsFound where d.Weight <= WeightSelector.MaxValue select d);
            }

            if (BMISelector.IsActive == true)
            {
                ExamRecordsFound = (from d in ExamRecordsFound where d.BMI >= BMISelector.MinValue select d);
                ExamRecordsFound = (from d in ExamRecordsFound where d.BMI <= BMISelector.MaxValue select d);
            }

            if (AbdCircSelector.IsActive == true)
            {
                ExamRecordsFound = (from d in ExamRecordsFound where d.AbdominalCircumference >= AbdCircSelector.MinValue select d);
                ExamRecordsFound = (from d in ExamRecordsFound where d.AbdominalCircumference <= AbdCircSelector.MaxValue select d);
            }

            if (GlycemiaSelector.IsActive == true)
            {
                ExamRecordsFound = (from d in ExamRecordsFound where d.GI >= GlycemiaSelector.MinValue select d);
                ExamRecordsFound = (from d in ExamRecordsFound where d.GI <= GlycemiaSelector.MaxValue select d);
            }

            if (GlycHaemSelector.IsActive == true)
            {
                ExamRecordsFound = (from d in ExamRecordsFound where d.GH >= GlycHaemSelector.MinValue select d);
                ExamRecordsFound = (from d in ExamRecordsFound where d.GH <= GlycHaemSelector.MaxValue select d);
            }

            if (TrygSelector.IsActive == true)
            {
                ExamRecordsFound = (from d in ExamRecordsFound where d.TG >= TrygSelector.MinValue select d);
                ExamRecordsFound = (from d in ExamRecordsFound where d.TG <= TrygSelector.MaxValue select d);
            }

            if (CholSelector.IsActive == true)
            {
                ExamRecordsFound = (from d in ExamRecordsFound where d.Cholesterol >= CholSelector.MinValue select d);
                ExamRecordsFound = (from d in ExamRecordsFound where d.Cholesterol <= CholSelector.MaxValue select d);
            }

            if (HDLSelector.IsActive == true)
            {
                ExamRecordsFound = (from d in ExamRecordsFound where d.HDL >= HDLSelector.MinValue select d);
                ExamRecordsFound = (from d in ExamRecordsFound where d.HDL <= HDLSelector.MaxValue select d);
            }

            if (LDLSelector.IsActive == true)
            {
                ExamRecordsFound = (from d in ExamRecordsFound where d.LDL >= LDLSelector.MinValue select d);
                ExamRecordsFound = (from d in ExamRecordsFound where d.LDL <= LDLSelector.MaxValue select d);
            }

            if (MaxBPSelector.IsActive == true)
            {
                ExamRecordsFound = (from d in ExamRecordsFound where d.MaxBloodPressure >= MaxBPSelector.MinValue select d);
                ExamRecordsFound = (from d in ExamRecordsFound where d.MaxBloodPressure <= MaxBPSelector.MaxValue select d);
            }

            if (MinBPSelector.IsActive == true)
            {
                ExamRecordsFound = (from d in ExamRecordsFound where d.MinBloodPressure >= MinBPSelector.MinValue select d);
                ExamRecordsFound = (from d in ExamRecordsFound where d.MinBloodPressure <= MinBPSelector.MaxValue select d);
            }

            if (SmokerSelector.IsActive == true)
            {
                ExamRecordsFound = (from d in ExamRecordsFound where d.Smoker == SmokerSelector.Value select d);
            }

            if (MetSynSelector.IsActive == true)
            {
                ExamRecordsFound = (from d in ExamRecordsFound where d.MetabolicSyndrome == MetSynSelector.Value select d);
            }

            var GroupedExams = (from d in ExamRecordsFound group d by d.Patient);

            List<Models.Patient> PatientsFound = new List<Models.Patient>();
            foreach (var i in GroupedExams)
            {
                PatientsFound.Add(i.Key);
            }
            int NumPatients = PatientsFound.Count;

            if (NumPatients == 1)
            {
                SearchResultLabel.Content = "1 paziente";
            }
            else
            {
                SearchResultLabel.Content = string.Format("{0} pazienti", NumPatients);
            }
            PatientsDataGrid.DataContext = PatientsFound;
        }
    }
}
