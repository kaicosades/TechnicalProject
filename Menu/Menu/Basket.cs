﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class Basket : Form
    {
        //string connectionString;
        //SqlConnection connection;
        //DataTable table;
        //SqlDataReader reader;
        public Basket()
        {
            InitializeComponent();

            //connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            //connection = new SqlConnection(connectionString);
        }
        public void SelectBasket(DataTable table)
        {
           

        }

    }
}
