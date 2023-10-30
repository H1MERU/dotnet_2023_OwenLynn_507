using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace dotnet_06
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            await WhenForm2Loaded();
        }


        public async Task WhenForm2Loaded()
        {
            await Task.Yield(); 
        }


        private void AddOK(object sender, EventArgs e)
        {
            int id = int.Parse(ID.Text);
            string name = s_name.Text;
            int c_id = int.Parse(Class.Text);

           
            if (!ID.ReadOnly)
            { 
                string q = SQLHelper.QueryInsertStudentGenerate(id, name, c_id);
                SQLHelper.InsertQuery(q);
            }
            else
            {
                string q = SQLHelper.QueryAlterGenerate(id, name, c_id);
                SQLHelper.AlterQuery(q);
            }

            Close();
        }

        public void Set(int id, string name, int cid)
        {
            ID.Text = id.ToString();
            ID.ReadOnly = true;
            s_name.Text = name;
            Class.Text = cid.ToString();
        }

        private void DontAdd(object sender, EventArgs e)
        {
            Close();
        }
    }
}
