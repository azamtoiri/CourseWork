using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        public string getSearchValue()
        {
            AdminForm admin = (AdminForm)this.Owner;
            string val = admin.GetSearchValue();
            return val;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            AdminForm form = (AdminForm)this.Owner;

            string searchValue = getSearchValue();

            DataTable dt = form.GetALL();

            if (string.IsNullOrEmpty(searchValue))
            {
                // Показываем все строки, если поисковая строка пустая
                dataGridView1.DataSource = dt;
            }

            else
            {
                DataView dataView = new DataView(dt);

                dataView.RowFilter = $"[name] LIKE '%{searchValue}%' OR [surname] LIKE '%{searchValue}%' OR [groupST] LIKE '%{searchValue}%' OR [CourseName] LIKE '%{searchValue}%'";
                dataGridView1.DataSource = dataView;
                

            }
        }
    }
}
