using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG_PART_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //-------------------------------- Method used to redirect the Hyperlink to the "Register" window ---------------------------------------//

        public void Hyperclick2(object sender, RoutedEventArgs e)
        {

            Register register = new Register();
            register.Show();
            this.Hide();
        }
         
        //----------------------------------------------------------------------------------------------------------------------------------------//


        //-------------------------------- Method used take the password and return a hashed version of it --------------------------------------//

        public string HashPass(string pass)
        {
            var hasher = SHA256.Create();
            var passAsbyte = Encoding.Default.GetBytes(pass);
            var hashed = hasher.ComputeHash(passAsbyte);
            return Convert.ToBase64String(hashed);
        }

        //---------------------------------------------------------------------------------------------------------------------------------------//



        //-------------------------------- Method used to control the actions of the button "Login" --------------------------------------------//

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //If statement used to prevent the user from inputing blank fields.
            if (STnumberBox.Text == "" || PassBox.Password == "") { MessageBox.Show("None of the fields can be empty!"); }
            else
            {
                string student_number = STnumberBox.Text;
                string student_password = PassBox.Password;
                SqlConnection connection = new SqlConnection(@"Insert the connection string here!");

                try
                {
                    //Code used to check if the user exists in the database.
                    if (connection.State == ConnectionState.Closed) connection.Open();
                    SqlCommand command = new SqlCommand("Select count(1) from StudentTB Where student_number=@number And student_password=@password", connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@number", student_number);
                    command.Parameters.AddWithValue("@password", HashPass(student_password.Trim()));
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    //Code used to search for the name of the user and welcome him warmly.
                    SqlCommand command2 = new SqlCommand("Select student_name from StudentTB Where student_number= '" + student_number + "'", connection);
                    
                    if (count == 1)
                    {
                        var name = command2.ExecuteScalar().ToString();
                        MessageBox.Show("Welcome Back, " + name + "!");
                        Module_info module = new Module_info(student_number);
                        module.Show();
                        this.Close();
                        
                    }
                    else { MessageBox.Show("The username or Password entered is incorrect!"); }
                }
                catch (Exception) { MessageBox.Show("An error occurred when checking your information!"); }

                finally { connection.Close(); }
            }
 
        }


        //---------------------------------------------------------------------------------------------------------------------------------------//

    }
}
