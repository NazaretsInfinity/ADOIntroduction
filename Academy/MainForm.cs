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
        void LoadTeachers()
        {
            dataGridViewTeachers.DataSource = Connector.LoadData(
                  "[Last name] = last_name, [First name] = first_name, [Middle name] = ISNULL(middle_name, N''), [Day of Birth] = birth_date," +
                  "[Age] = DATEDIFF(DAY, birth_date, GETDATE())/365, " +
                  "[Work since] = works_since",
                  "Teachers"
             );
        }

        void LoadDirections()
        {
                LoadBox(cbGroups_direction, "direction_name", "direction_id", "Directions");
        }


        public static void LoadBox(ComboBox box, string name, string id, string tables)
        {
            Dictionary<string, int> pairs = Connector.LoadPair(name, id, tables);
            box.Items.AddRange(pairs.Keys.ToArray());
            box.Items.Insert(0, "All");
            box.SelectedIndex = 0;
        }

        //EVENTS
        private void cbGroupsDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbGroups_direction.SelectedIndex == 0)LoadGroups();
            else 
            dataGridViewGroups.DataSource = Connector.LoadData
            (
                "group_id, group_name, direction_name",
                "Groups, Directions",
                $"direction = direction_id AND direction_name = '{cbGroups_direction.SelectedItem.ToString()}'"
            );

            tslGroupCount.Text = $"Amount of Groups: {(dataGridViewGroups.RowCount == 0 ? 0 : dataGridViewGroups.RowCount-1)}";
        }

        private void dataGridViewGroups_Click(object sender, EventArgs e)

        { 
            int counter = 0;
            string group = (sender as DataGridView).CurrentRow.Cells[1].Value.ToString();
           /* foreach (datagridviewrow row in datagridviewstudents.rows)  
                if (row.cells[5].value != null & 
                    row.cells[5].value.tostring() == (sender as datagridview).currentrow.cells[1].value.tostring())counter++;
           */

            for (int i = 0;  i < dataGridViewStudents.Rows.Count-1;++i)
            {
                if (dataGridViewStudents.Rows[i].Cells[5].Value.ToString() == group)
                ++counter;
            }
            if(group!="")tslStudentsInGroup.Text = $"Количество студентов в {group} : {counter}";
        }

        private void cbStudents_groups_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
