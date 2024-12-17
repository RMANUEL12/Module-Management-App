using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        //-------------------------------- Method used take the password and return a hashed version of it --------------------------------------//

        public string HashPass(string pass)
        {
            var hasher = SHA256.Create();
            var passAsbyte = Encoding.Default.GetBytes(pass);
            var hashed = hasher.ComputeHash(passAsbyte);  
            return Convert.ToBase64String(hashed);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//



        //-------------------------------- Code that control the functions of the button "Register" ---------------------------------------------//

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string c = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|StudentDB.mdf;Integrated Security=True";
            //Code used to Check if any of the fields is empty.
            if (StudenNBOx.Text == "" || STNumberBox.Text == "" || PassBox.Password=="" || ConfirmPass.Password=="") { MessageBox.Show("None of the fields can be empty!"); } else { 
                string student_name = StudenNBOx.Text;
                string student_number = STNumberBox.Text;
                string st_password = PassBox.Password;
                string conf_password = ConfirmPass.Password;

                //Code used to check if the two passwords enterd match.
                if (st_password.Equals(conf_password))
                {

                    try
                    {
                        //Code used to insert the information of the new user in the database.
                        SqlConnection connection = new SqlConnection(@"Insert the connection string here!");
                        connection.Open();
                        SqlCommand command = new SqlCommand("Insert into StudentTB values ('" + student_name + "', '" + student_number + "', '" + HashPass(st_password.Trim()) + "')", connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("You have been registered, " + student_name + "!");
                        Semester_Info info = new Semester_Info(student_number);
                        info.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("It was not possible to register you. The student number already exists!");
                        MessageBox.Show("The actual error: " + ex);


                    }

                } else {MessageBox.Show("The passwords do not match. Please try again!");}
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//



        //-------------------------------- Hyperlink that redirects the user to the "Login" Page -------------------------------------------------//


        public void Hyperclick(object sender, RoutedEventArgs e)
        {

            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//


    }
}
