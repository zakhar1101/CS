using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace inferometer
{
    public partial class map1 : Form
    {
        public map1()
        {
            InitializeComponent();
            Width = 520;
            Height = 550;
            int size_map = 500;

            dataGridView1.Dock = DockStyle.Fill;

            //dataGridView1.Width = size_map;
            //dataGridView1.Height = size_map;


            int count_cells = 10;
            int size_cells = size_map / count_cells;

            dataGridView1.RowCount = count_cells;
            dataGridView1.ColumnCount = count_cells;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.AllowUserToResizeRows = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.AllowUserToResizeColumns = false;

            dataGridView1.ScrollBars = ScrollBars.None;
            //dataGridView1.HorizontalScrollingOffset = dataGridView1.HorizontalScrollingOffset;
            //dataGridView1.VerticalScrollingOffset = dataGridView1.VerticalScrollingOffset;
            for (int i = 0; i < count_cells; i++)
            {
                dataGridView1.Rows[i].Height = size_cells;
                dataGridView1.Columns[i].Width = size_cells;
            }
        }
    }
}
