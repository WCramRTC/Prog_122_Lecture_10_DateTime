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

namespace Prog_122_Lecture_10_DateTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int ageToDrive = 16;
        const int ageToVote = 18;
        const int ageToDrink = 21;

        public MainWindow()
        {
            InitializeComponent();

            BlogPost bp = new BlogPost("Header 1", "Body 1");

            runDisplay.Text = bp.ToString();


         

        }

        public void ExampleCode()
        {
            DateTime date = new DateTime(2023, 2, 15);
            DateTime now = DateTime.Now;

            string shortTime = now.ToShortTimeString();
            string longTime = now.ToLongTimeString();

            string formatString = $"" +
                $"Short Time: {shortTime}\n" +
                $"Long Time: {longTime}\n" +
                $"Short Day: {now.ToShortDateString()}\n" +
                $"Long Date: {now.ToLongDateString()}\n" +
                $"Year: {now.Year}\n" +
                $"Day of the Week: {now.DayOfWeek}";


            DateTime nowPlus7Months = now.AddMonths(70);

            TimeSpan differenceInDaysFor7Months = nowPlus7Months - now;

            // A timespan object

            runDisplay.Text = (differenceInDaysFor7Months.Days / 365.25).ToString();
        }

        private void btnDisplayTime_Click(object sender, RoutedEventArgs e)
        {
            DateTime bday = BirthdayObject();



            runDisplay.Text = $"Your birthday is {bday}";
        }

        public DateTime BirthdayObject()
        {
            int day = int.Parse(txtDay.Text);
            int month = int.Parse(txtMonth.Text);
            int year = int.Parse(txtYear.Text);


            return new DateTime(year, month, day);

        }

        private void btnCheckAgeForLicense_Click(object sender, RoutedEventArgs e)
        {
            DateTime bday = BirthdayObject();
            DateTime now = DateTime.Now;

            TimeSpan ageInDays = now - bday;
            int age = (int)(ageInDays.Days / 365.25);

            runDisplay.Text = $"You are {age.ToString()} old\n";

            if (age >= ageToDrive)
            {
                runDisplay.Text += "You are old enough to drive";
            }


            if (age >= ageToVote)
            {
                runDisplay.Text += "You are old enough to vote";
            }


            if (age >= ageToDrink)
            {
                runDisplay.Text += "You are old enough to drink";
            }


        }

        private void btnResults_Click(object sender, RoutedEventArgs e)
        {
            bool calanderDateSelected = calDate.SelectedDate.HasValue;
            DateTime timeSelected = DateTime.Now;

            // If a time is selected, replace timeNow with selected time
            if(calanderDateSelected)
            {
                timeSelected = calDate.SelectedDate.Value;
            }

            runDisplay.Text = timeSelected.ToString();

            //runDisplay.Text = selectedDate.ToString();
        }
    }
}
