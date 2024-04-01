using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms.VisualStyles;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Drawing.Imaging;


namespace Menu
{
    public partial class Form1 : Form
    {
        string connectionString;
        SqlConnection connection;
        DataTable table;
        SqlDataReader reader;
        //private readonly string _connectionString;
        public Form1()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);

            LoadCategoriesToComboBox(cbСategory);
            SelectDishes();
            //SelectBasket("");


        }

        public void LoadCategoriesToComboBox(System.Windows.Forms.ComboBox comboBox)
        {
            string commandLine = @"SELECT type_name FROM TypeDishes";
            SqlCommand cmd = new SqlCommand(commandLine, connection);
            connection.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox.Items.Add(reader[0]);
            }
            reader.Close();
            connection.Close();
        }

        void SelectDishes(string type_dishes = "")
        {
            string commandLine = $@"
            SELECT image, name_dishes, price, structure ,presence, size 
            FROM Dishes 
            JOIN TypeDishes ON Dishes.type_dishes=TypeDishes.id_type
            ";
            //WHERE TypeDishes.type_name = {type_dishes}
            //if (type_dishes.Length != 0) commandLine += $" WHERE type_dishes = '{type_dishes}'";
            SqlCommand cmd = new SqlCommand(commandLine, connection);
            connection.Open();
            reader = cmd.ExecuteReader();
            table = new DataTable();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                table.Columns.Add(reader.GetName(i)); //шапка
            }
            while (reader.Read())
            {
                DataRow row = table.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {

                    row[i] = reader[i];
                }
                table.Rows.Add(row); // Заполнение таблицы 
            }
            dgvMenu.DataSource = table;
            reader.Close();

            connection.Close();

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void basket_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Basket basket = new Basket();
            basket.Show(); // показывает окно
        }

        private void cbСategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            dgvMenu.DataSource = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $@"
            SELECT image, name_dishes, price, structure ,presence, size 
            FROM Dishes 
            JOIN TypeDishes ON Dishes.type_dishes=TypeDishes.id_type
            WHERE TypeDishes.type_name='{cbСategory.SelectedItem.ToString()}'
            ";


            connection.Open();
            reader = cmd.ExecuteReader();
            table = new DataTable();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                table.Columns.Add(reader.GetName(i));
            }
            while (reader.Read())
            {
                DataRow row = table.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (i == 0)
                    {
                        
                    }
                    row[i] = reader[i];
                }
                table.Rows.Add(row);
            }
            dgvMenu.DataSource = table;
            if (cbСategory.SelectedItem != null) cmd.CommandText += //Проверка нужна для того, чтобы запрос запустился еще раз при смене галочки
            @" WHERE TypeDishes.type_name=Dishes.tyme_dishes
            ";
            reader.Close();
            connection.Close();

        }


        private void dgvMenu_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("С Вас 100 долларов", "Info", MessageBoxButtons.OK);
            if (dgvMenu.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null )
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();
                table = new DataTable();
                //for (int i = 0; i < reader.FieldCount; i++)
                //{
                //    table.Columns.Add(reader.GetName(i));
                //}
                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (i == 0)
                        {

                        }
                        row[i] = reader[i];
                    }
                    table.Rows.Add(row);
                }
                reader.Close();
                connection.Close();

                Basket basket = new Basket();
                basket.SelectBasket(table);
            }
//            SqlCommand cmd = new SqlCommand();
//            cmd.Connection = connection;
//            //cmd.Parameters.Add("@[order]", );
//            //cmd.Parameters.Add("@dishes", );
            
//            cmd.CommandText = @"
//IF NOT EXISTS (SELECT [order] FROM OrderDishes WHERE dishes = @sender)
//BEGIN
//INSERT INTO
//OrderDishes (dishes, quantity)
//VALUES (@sender[0], @1 )
//END
//";
//            connection.Open();
//            cmd.ExecuteNonQuery();
//            connection.Close();
            
        }

    }
}
