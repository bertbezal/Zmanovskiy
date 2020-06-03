using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace datagridView
{
    public partial class Form1 : Form

    {
        public string CmdText = "SELECT*FROM [table]";
        public string ConnString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\BertBezal\\Desktop\\Учеба\\Гостиничный комплекс.mdb";
        public Form1()
        {
            InitializeComponent();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(CmdText, ConnString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "[table]");
            dataGridView.DataSource = ds.Tables[0].DefaultView;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
