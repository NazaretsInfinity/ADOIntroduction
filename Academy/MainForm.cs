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

namespace Academy
{
    public partial class MainForm : Form
    {
        string connectionString;
        SqlConnection connection;
        Dictionary<string, int> d_groups_directions;

        public MainForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Academy"].ConnectionString;
            //MessageBox.Show(this, connectionString, "Connection string", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection = new SqlConnection(connectionString);

           LoadStudents();
           LoadGroups();
           LoadTeachers();
           LoadDirections();
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
            dataGridViewGroups.DataSource = Connector.LoadData("[ID]=group_id, [Group]=group_name, [Direction] = direction_name", 
                                                                "Groups,Directions" , "direction = direction_id");
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

        void LoadDirections()
        {
            if (cbGroupsDirection.SelectedIndex == 0) LoadGroups();
            else
            {
                d_groups_directions = Connector.LoadPair("direction_name", "direction_id", "Directions");
                cbGroupsDirection.Items.AddRange(d_groups_directions.Keys.ToArray());
                cbGroupsDirection.Items.Insert(0, "All");
                cbGroupsDirection.SelectedIndex = 0;
            }
        }

        void LoadTeachers()
        {
            dataGridViewTeachers.DataSource = Connector.LoadData(
                  "[Last name] = last_name, [First name] = first_name, [Middle name] = ISNULL(middle_name, N''), [Day of Birth] = birth_date," +
                  "[Age] = DATEDIFF(DAY, birth_date, GETDATE())/365, " +
                  "[Work since] = works_since",
                  "Teachers"
             );
        }

        private void cbGroupsDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbGroupsDirection.SelectedIndex == 0)LoadGroups();
            else 
            dataGridViewGroups.DataSource = Connector.LoadData
            (
                "group_id, group_name, direction_name",
                "Groups, Directions",
                $"direction = direction_id AND direction = {d_groups_directions[cbGroupsDirection.SelectedItem.ToString()]}"
            );
            tslGroupCount.Text = $"Amount of Groups: {(dataGridViewGroups.RowCount == 0 ? 0 : dataGridViewGroups.RowCount-1)}";
        }
    }
}
