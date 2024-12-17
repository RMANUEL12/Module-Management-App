using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Display_modules.xaml
    /// </summary>
    public partial class Display_modules : Window
    {
        public string student_number;


        //---------------------- Construtor that takes student number of a new student or of a student already in the system  --------------------//

        public Display_modules(string stnumber)
        {
            InitializeComponent();
            student_number = stnumber;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//



        //------------------------------------------- Method used to go to the "Add modules" window  ---------------------------------------------//

        private void AddModules(object sender, RoutedEventArgs e)
        {
            
            Module_info module = new Module_info(student_number);
            module.Show();
            this.Hide();
            
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//



        //------------------------------------------- Method used to go to the "Remaining" window -----------------------------------------------//

        private void Remaining(object sender, RoutedEventArgs e)
        {
            
            Remainig_Hours hours = new Remainig_Hours(student_number);
            hours.Show();
            this.Hide();
            
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//



        //--------------------------------------- Method used to select the module information a display it --------------------------------------//

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Insert the connection string here!");
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand("Select module_name, module_code, module_selfst from module_information where student_number = '"+ student_number + "' ", connection);
            sqlcommand.ExecuteNonQuery();
            SqlDataAdapter sqldata = new SqlDataAdapter(sqlcommand);
            DataTable data = new DataTable("module_information");
            sqldata.Fill(data);
            Grid.ItemsSource = data.DefaultView;
            sqldata.Update(data);
            connection.Close();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------//

    }
}
