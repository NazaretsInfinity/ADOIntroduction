﻿using System;
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

namespace Academy
{
    public partial class MainForm : Form
    {
        string connectionString;
        SqlConnection connection;

        public MainForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Academy"].ConnectionString;
            MessageBox.Show(this, connectionString, "Connection string", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection = new SqlConnection(connectionString);

            Loadstudents();
            LoadGroups();
        }

        void Loadstudents()
        {
            string cmd = "SELECT * FROM Students";
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            DataTable table = new DataTable();
            if (reader.HasRows)
            {
                for (int i = 0; i < reader.FieldCount; ++i)
                    table.Columns.Add(reader.GetName(i));

                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    for (int i = 0; i < reader.FieldCount; ++i)
                    {
                        row[i] = reader[i];
                    }
                    table.Rows.Add(row);
                }
                dataGridViewStudents.DataSource = table;
            }
            reader.Close();
            connection.Close();
        }

        void LoadGroups()
        {
            string cmd = "SELECT * FROM Groups";
            SqlCommand command = new SqlCommand(cmd, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            DataTable GroupTable = new DataTable();
            if (reader.HasRows)
            {
                for (int i = 0; i < reader.FieldCount; ++i)
                    GroupTable.Columns.Add(reader.GetName(i));

                while(reader.Read())
                {
                    DataRow row = GroupTable.NewRow();
                    for (int i = 0; i < reader.FieldCount; ++i)
                        row[i] = reader[i];
                    GroupTable.Rows.Add(row);
                    dataGridViewGroups.DataSource = GroupTable;
                }
            }
            reader.Close();
            connection.Close();
        }
    }
}
