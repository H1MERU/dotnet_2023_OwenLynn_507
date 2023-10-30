using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotnet_06
{
    public partial class Form1 : Form
    {
        public string lastCommited = "SELECT * FROM Students";

        public Form1()
        {
            InitializeComponent();
            StudentsDataGrid.AutoGenerateColumns = true;
        }

        //执行查询
        private void Search_button_click(object sender, EventArgs e)
        {
            string query = "";
            string f = find.Text;
            if (find.Text != "")
            {
                if (id.Checked)
                {
                    query = SQLHelper.QuerySelectByIDGenerate(f);
                }
                if (sname.Checked)
                {
                    query = SQLHelper.QuerySelectByNameGenerate(f);
                }
                if (cid.Checked)
                {
                    query = SQLHelper.QuerySelectByCIDGenerate(f);
                }
            }
            else
            {
                query = SQLHelper.QueryGenerate();
            }
            lastCommited = query;
            List<Students> res = SQLHelper.SelectQuery(query);
            ShowStudents(res);
        }

        private void EditStudentInfo(object sender, DataGridViewCellEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Load += (s, ea) =>
            {
                DataGridViewRow selectedRow = StudentsDataGrid.Rows[e.RowIndex];
                int sid = (int)selectedRow.Cells["StudentID"].Value;
                string sname = (string)selectedRow.Cells["StudentName"].Value;
                int cid = (int)selectedRow.Cells["ClassID"].Value;
                form2.Set(sid, sname, cid);
            };

            form2.ShowDialog();
        }

        private void AddStudents(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

        }

        private void DeleteSelected(object sender, EventArgs e)
        {
            if (StudentsDataGrid.SelectedRows.Count < 1)
                return;
            DataGridViewRow selectedRow = StudentsDataGrid.SelectedRows[0]; // 获取第一行

            // 获取行中的数据
            int studentID = (int)selectedRow.Cells["StudentID"].Value;

            SQLHelper.DeleteQuery(SQLHelper.QueryDeleteGenerate(studentID.ToString()));

            Refresh();

        }

        private void RefreshTable(object sender, EventArgs e)
        {
            Refresh();
        }

        new private void Refresh()
        {
            List<Students> res = SQLHelper.SelectQuery(lastCommited);
            ShowStudents(res);
        }

        private void ShowStudents(List<Students> list)
        {
            BindingList<Students> bindingList = new BindingList<Students>(list);
            StudentsDataGrid.DataSource = bindingList;
            StudentsDataGrid.Columns["StudentID"].DisplayIndex = 0;
            StudentsDataGrid.Columns["StudentName"].DisplayIndex = 1;
            StudentsDataGrid.Columns["ClassID"].DisplayIndex = 2;
        }


    }
}
