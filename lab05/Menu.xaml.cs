using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;

namespace lab05
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu  
    {
        //string connectionString = "Data Source= LAPTOP-PUU85PCD\\SQLEXPRESS;Initial Catalog=NeptunoDB; User ID=USER02; Password=12345;";
        string connectionString = "Data Source= LAPTOP-PUU85PCD\\SQLEXPRESS;Initial Catalog=NeptunoDB; User ID=USER02; Password=12345;";
        public List<Empleado> ListaEmpleado { get; set; }


        public Menu()
        {
            InitializeComponent();
            ListaEmpleado = new List<Empleado>();
            dataEmpleados.ItemsSource = ListaEmpleado;
        }

        private void Button_Insertar(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Listar(object sender, RoutedEventArgs e)
        {
            List<Empleado> empleados = new List<Empleado>();
          

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Listar_Empleado",  connection);
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idEmpleado = reader.GetInt32(reader.GetOrdinal("idEmpleado"));
                            string apellidos = reader.GetString(reader.GetOrdinal("Apellidos"));
                            string nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                            string cargo = reader.GetString(reader.GetOrdinal("Cargo"));
                            string tratamiento = reader.GetString(reader.GetOrdinal("Tratamiento"));
                            DateTime fechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento"));
                            DateTime fechaContratacion = reader.GetDateTime(reader.GetOrdinal("FechaContratacion"));
                            string direccion = reader.GetString(reader.GetOrdinal("Direccion"));
                            string ciudad = reader.GetString(reader.GetOrdinal("Ciudad"));
                            string region = reader.GetString(reader.GetOrdinal("Region"));
                            string codPostal = reader.GetString(reader.GetOrdinal("CodPostal"));
                            string pais = reader.GetString(reader.GetOrdinal("Pais"));
                            string telDomicilio = reader.GetString(reader.GetOrdinal("TelDomicilio"));
                            string extension = reader.GetString(reader.GetOrdinal("Extension"));
                            string notas = reader.GetString(reader.GetOrdinal("Notas"));
                            int jefe = reader.GetInt32(reader.GetOrdinal("Jefe"));
                            decimal sueldoBasico = reader.GetDecimal(reader.GetOrdinal("SueldoBasico"));

                            empleados.Add(new Empleado(idEmpleado, apellidos, nombre, cargo, tratamiento,
                                fechaNacimiento, fechaContratacion, direccion, ciudad,
                                region, codPostal, pais, telDomicilio, extension,
                                notas, jefe, sueldoBasico));
                        }
                    }
                }

                dataEmpleados.ItemsSource = empleados; 
                dataEmpleados.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}




