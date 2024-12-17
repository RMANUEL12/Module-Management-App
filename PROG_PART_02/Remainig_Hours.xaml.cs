using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Remainig_Hours.xaml
    /// </summary>
    public partial class Remainig_Hours : Window
    {

        SqlConnection connection = new SqlConnection(@"Insert the connection string here!");
        public string student_number;
        public double time;
        


        //---- Construtor that takes student number of a new student or of a student already in the system. And a method to populate the box ------//

        public Remainig_Hours(string stnumber)
        {

            InitializeComponent();
            student_number = stnumber;
            populated();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//



        //------------------------------- Method used to populate the combobox with the module code  ---------------------------------------------//

        public void populated()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select module_code from module_information where student_number = '" + student_number + "'",connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ModuleBox.Items.Add(reader.GetString("module_code"));
                //Multhreading to used to enable the modules to be loaded in the combobox.
                Thread.Sleep(25);
            }
            connection.Close();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//



        //------------------------------- Method that controls the actions of the "Calculate" button ---------------------------------------------//

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //If statement to check if the fields are empty and have the correct input.
            if (HourBox.Text == "" || ModuleBox.Text == "") { MessageBox.Show("None of the fields can be empty!"); } else if (!double.TryParse(HourBox.Text, out time)) { MessageBox.Show("The variable in the hours box must be a number!"); } 
            else {
                string moduleName = Convert.ToString(ModuleBox.SelectedItem);
                time = double.Parse(HourBox.Text);
                string moduleDate = secondDate.Text.ToString();

                //Code used to select the self study hours based on the student number and the module code.
                connection.Open();
                SqlCommand command = new SqlCommand("Select module_selfst from module_information where (student_number = '" + student_number + "') And module_code= '" + moduleName + "' ", connection);
                double newHour = Convert.ToDouble(command.ExecuteScalar().ToString()) - time;

                //Code used to update the number of self-study hours in the database. 
                SqlCommand command2 = new SqlCommand("Update module_information Set module_selfst = " + newHour + "  where (student_number = '" + student_number + "') And module_code= '" + moduleName + "' ", connection);
                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("The time has been updated!");
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//



        //------------------------------------- Method used to go to the "add" module window -----------------------------------------------------//

        private void AddModules(object sender, RoutedEventArgs e)
        {
            Module_info module = new Module_info(student_number);
            module.Show();
            this.Hide();
            
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//



        //------------------------------------- Method used to go to the "display" modules window -----------------------------------------------------//

        private void Display(object sender, RoutedEventArgs e)
        {
            
            Display_modules display = new Display_modules(student_number);
            display.Show();
            this.Hide();
            
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//

    }
}
