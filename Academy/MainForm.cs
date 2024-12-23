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
        Dictionary<string, int> d_directions;
        Dictionary<string, int> d_groups;

        public MainForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Academy"].ConnectionString;
            //MessageBox.Show(this, connectionString, "Connection string", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection = new SqlConnection(connectionString);

            d_directions = Connector.LoadPair("direction_name", "direction_id", "Directions");
            d_groups = Connector.LoadPair("group_name", "group_id", "Groups");
            LoadDictionaryToComboBox(d_groups, cbStudents_group);
            LoadDictionaryToComboBox(d_directions, cbGroupsDirection);
            LoadDictionaryToComboBox(d_directions, cbStudents_direction);

           LoadStudents();
           LoadGroups();
          
        }

        #region Old Loadstudents
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
                    DataRow row = table.NewRow();//NewRow() creates a row which fields are relevant to 'table'
                    for (int i = 0; i < reader.FieldCount; ++i)
                    {
                        row[i] = reader[i];
                    }
                    table.Rows.Add(row); // And this one add the row in GroupTable for real
                                         // (in DataRowCollection that contains DataRow objects)    
                }
                dataGridViewStudents.DataSource = table;
            }
            reader.Close();
            connection.Close();
        } 
        #endregion

        void LoadGroups()
        {
            dataGridViewGroups.DataSource = Connector.LoadData
                (
                " [ID]=group_id," +
                " [Group]=group_name," +
                " [Direction] = direction_name, " +
                " [Amount of students] = COUNT(student_id)",
                                                              
                "Students RIGHT JOIN Groups ON([group] = group_id) " +
                "JOIN Directions ON(direction = direction_id)" ,
                
                "direction = direction_id " +
                "GROUP BY group_id, group_name, direction_name"
                );
            tslGroupCount.Text = $"Amount of Groups: {dataGridViewGroups.RowCount - 1}";
        }

        void LoadStudents()
        {
            dataGridViewStudents.DataSource = Connector.LoadData
           (
                "[Last name] = last_name, [First name] = first_name, [Middle name] = ISNULL(middle_name, N''), [Day of Birth] = birth_date," +
                "[Age] = DATEDIFF(DAY, birth_date, GETDATE())/365, [Group] = group_name",
                "Students,Groups",
                "[group] = group_id"
           );
            tslStudentsLabelCount.Text = $"Amount of Students: {dataGridViewStudents.RowCount-1}";
        }

        void LoadDictionaryToComboBox(Dictionary<string, int> dc, ComboBox bc)
        {
                bc.Items.AddRange(dc.Keys.ToArray());
                bc.Items.Insert(0, "All");
                bc.SelectedIndex = 0;       
        }

        private void cbGroupsDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbGroupsDirection.SelectedIndex == 0)LoadGroups();
            else 
            dataGridViewGroups.DataSource = Connector.LoadData
            (
                "group_id, group_name, direction_name",
                "Groups, Directions",
                $"direction = direction_id AND direction = {d_directions[cbGroupsDirection.SelectedItem.ToString()]}"
            );
            tslGroupCount.Text = $"Amount of Groups: {(dataGridViewGroups.RowCount == 0 ? 0 : dataGridViewGroups.RowCount-1)}";
        }
    }
}
