using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotteryFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lotteryBindingSource.AddNew();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "loteryDataSet.Lottery". При необходимости она может быть перемещена или удалена.
            this.lotteryTableAdapter.Fill(this.loteryDataSet.Lottery);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lotteryBindingSource.MovePrevious();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lotteryBindingSource.MoveNext();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lotteryBindingSource.EndEdit();
            lotteryTableAdapter.Update(loteryDataSet.Lottery);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lotteryBindingSource.RemoveCurrent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
