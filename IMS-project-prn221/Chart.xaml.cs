using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace IMS_project_prn221
{
    public partial class Chart : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<DateTime> _dates;
        public List<DateTime> Dates
        {
            get { return _dates; }
            set
            {
                _dates = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dates)));
            }
        }

        private List<double> _values;
        public List<double> Values
        {
            get { return _values; }
            set
            {
                _values = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Values)));
            }
        }

            public Chart()
            {
                InitializeComponent();
                var random = new Random();
               var Dates = new List<DateTime>();
               var Values = new List<double>();

                var currentDate = DateTime.Today;
                for (int i = 1; i <= 30; i++) // Giả định 30 ngày trong tháng
                {
                    Dates.Add(currentDate.AddDays(i));
                    Values.Add(random.Next(1, 100)); // Giá trị ngẫu nhiên
                }
            
            DataContext = this;
            }
            }
    }