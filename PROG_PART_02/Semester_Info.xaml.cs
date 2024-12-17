using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
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

namespace PROG_PART_02
{
    /// <summary>
    /// Interaction logic for Semester_Info.xaml
    /// </summary>
    public partial class Semester_Info : Window
    {
        public string student_number;
        public double weeks;

        //---------------------- Construtor that takes student number of a new student or of a student already in the system  --------------------//

        public Semester_Info(string stnumber)
        {
            InitializeComponent();
            student_number = stnumber;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//



        //-------------------------------- Button that control the "Submit" button  --------------------------------------------------------------//

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //If statement that checks if the fields are empty or if the input is in a incorrect format.
                if (nWeeksBox.Text == "") { MessageBox.Show("None of the fields can be empty!"); } else if (!double.TryParse(nWeeksBox.Text, out weeks)) { MessageBox.Show("The variable in the first box must be a number"); } else {
                    weeks = double.Parse(nWeeksBox.Text);
                    string startdate = firstDate.Text.ToString();

                    //Code use to enter the semester information in the database.
                   // SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Student_database.mdf;Integrated Security=True");
                    SqlConnection connection = new SqlConnection(@"Insert the connection string here!");
                    connection.Open();
                    SqlCommand command = new SqlCommand("Insert into semester_info values ('" + student_number + "', " + weeks + ", '" + startdate + "')", connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            Module_info module = new Module_info(student_number);
            module.Show();
            this.Hide();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//
    }
}
