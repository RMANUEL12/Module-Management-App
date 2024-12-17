using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Reflection;
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
using ClassLibrary1;

namespace PROG_PART_02
{
    /// <summary>
    /// Interaction logic for Module_info.xaml
    /// </summary>
    public partial class Module_info : Window
    {
        public string student_number;
        public int credits;
        public double HPWeek;


        //-------------------------------- List of Objects created to store module code, name and study hours ------------------------------------//


        public List<CollectionCollect> Modules = new List<CollectionCollect>();

        public class CollectionCollect
        {

            public string Ccode { get; set; }
            public string Cname { get; set; }
            public double CselfStudy { get; set; }

            public CollectionCollect(string code1, string name1, double selfstudy)
            {

                this.Ccode = code1;
                this.Cname = name1;
                this.CselfStudy = selfstudy;
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//



        //----------------- Construtor that takes student number of a new student or of a student already in the system --------------------------//

        public Module_info(string stnumber)
        {
            InitializeComponent();
            student_number = stnumber;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//



        //--------------------------------- Button that control the actions of the "Add" button --------------------------------------------------//

        public void bot_Click(object sender, RoutedEventArgs e)
        {
            //If statement used to check if the fields are empty or the input is incorrect.
            if (CodeBox.Text == "" || NameBox.Text == "" || CreditBox.Text == "" || HoursBox.Text == "") { MessageBox.Show("None of the fields can be empty!"); } 
            else if (!int.TryParse(CreditBox.Text, out credits) ||! double.TryParse(HoursBox.Text, out HPWeek)) { MessageBox.Show("The variables in credits and Hours per week fields must be numbers!"); } else {


                //Class library called to help with calculations.
                Class1 SelfHours = new Class1();

                string code1 = CodeBox.Text;
                string name = NameBox.Text;
                credits = int.Parse(CreditBox.Text);
                HPWeek = double.Parse(HoursBox.Text);
                try
                {
                    //Code used to get the number of weeks in the semester that the user as already entered.
                    SqlConnection connection = new SqlConnection(@"Insert the connection string here!");
                    connection.Open();
                    SqlCommand command = new SqlCommand("Select numberOfWeeks from semester_info Where student_number = '" + student_number + "'", connection);
                    double weeks = Convert.ToDouble(command.ExecuteScalar());

                    // Self-study hours beig calculated using the class library.
                    double studyHours = SelfHours.Self(credits, weeks, HPWeek);

                     //Code used to insert the infomation of the module in the database.
                    SqlCommand command2 = new SqlCommand(
                        "INSERT INTO module_information (student_number, module_name, module_code, module_selfst) " +
                        "VALUES (@student_number, @name, @code1, @studyHours)", connection);

                    command2.Parameters.AddWithValue("@student_number", student_number);
                    command2.Parameters.AddWithValue("@name", name);
                    command2.Parameters.AddWithValue("@code1", code1);
                    command2.Parameters.AddWithValue("@studyHours", studyHours); 
                    command2.ExecuteNonQuery();
                    connection.Close();


                    //Adding the varables to the list using the click.
                    Modules.Add(new CollectionCollect(code1, name, studyHours));
                }
                catch (Exception error) { MessageBox.Show("An error happened while adding the module"); MessageBox.Show("An error: " + error); }
                MessageBox.Show("Your module has been added!");
                //Code used to clear the boxes afte clicking the button.
                CodeBox.Clear();
                NameBox.Clear();
                CreditBox.Clear();
                HoursBox.Clear();
            }

        }


        //----------------------------------------------------------------------------------------------------------------------------------------//



        //--------------------------------- Method that redirects the user to the "display" window -----------------------------------------------//

        private void DisplayModules(object sender, RoutedEventArgs e)
        {
            Display_modules display = new Display_modules(student_number);
            display.Show();
            this.Hide();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//



        //--------------------------------- Method that redirects the user to the "Remaining" window ---------------------------------------------//

        private void Remaining(object sender, RoutedEventArgs e)
        {
            Remainig_Hours hours = new Remainig_Hours(student_number);
            hours.Show();
            this.Hide();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//



    }
}
