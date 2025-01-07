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
            //Loading comboboxes
            LoadDictionaryToComboBox(d_groups, cbStudents_group);
            LoadDictionaryToComboBox(d_directions, cbGroupsDirection);
            LoadDictionaryToComboBox(d_directions, cbStudents_direction);

            //loading grids
            LoadStudents();
            LoadGroups();
          
        }

        void LoadGroups()
        {
            dataGridViewGroups.DataSource = Connector.LoadData
                (
                "[ID]=group_id," +
                "[Group]=group_name," +
                "[Direction] = direction_name, " +
                "[Amount of students] = COUNT(student_id)",
                                                              
                "Students RIGHT JOIN Groups ON([group] = group_id) " +
                "JOIN Directions ON(direction = direction_id)" ,
                
                "direction = direction_id " +
                "GROUP BY group_id, group_name, direction_name"
                );
            tslGroupCount.Text = $"Amount of Groups: {dataGridViewGroups.RowCount - 1}";
        }

        void LoadStudents(string constriction = "", string extra_table = "")
        {
            dataGridViewStudents.DataSource = Connector.LoadData
           (
                "[Last name] = last_name, [First name] = first_name, [Middle name] = ISNULL(middle_name, N''), [Day of Birth] = birth_date," +
                "[Age] = DATEDIFF(DAY, birth_date, GETDATE())/365, [Group] = group_name",
                $"Students,Groups{(extra_table != "" ? $",{extra_table}" : "")}",
                $"{(constriction != "" ? $"{constriction} AND " : "")}[group] = group_id"
           );
            tslStudentsLabelCount.Text = $"Amount of Students: {dataGridViewStudents.RowCount - 1}";
        }

        void LoadDictionaryToComboBox(Dictionary<string, int> dc, ComboBox bc)
        {
                bc.Items.Clear();
                bc.Items.AddRange(dc.Keys.ToArray());
               // bc.Items.Insert(0, "All");
               // bc.SelectedIndex = 0;       
        }


        // ---------- EVENTS ----------- //
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

        private void cbStudents_group_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbStudents_group.SelectedIndex == 0) LoadStudents();
            else LoadStudents($"group_id = {d_groups[cbStudents_group.SelectedItem.ToString()]}");    // here
        }

        private void cbStudents_direction_SelectedIndexChanged(object sender, EventArgs e)
        {
            int FilterID = cbStudents_direction == null? 0: d_directions[cbStudents_direction.SelectedItem.ToString()];
            if (FilterID == 0)
            {
                d_groups = Connector.LoadPair("group_name", "group_id", "Groups", $"direction = {FilterID}");
                LoadDictionaryToComboBox(d_groups, cbStudents_group);
                LoadStudents();
            }
            else
            {
                d_groups = Connector.LoadPair("group_name", "group_id", "Groups", $"direction = {FilterID}");
                this.LoadDictionaryToComboBox(d_groups, cbStudents_group);
                LoadStudents($" direction = direction_id AND direction_id = {d_directions[cbStudents_direction.SelectedItem.ToString()]}", "Directions");
            }
            tslStudentsLabelCount.Text = $"Amount of students: {(dataGridViewStudents.RowCount == 0 ? 0 : dataGridViewStudents.RowCount - 1)}";
        }
    }
}
