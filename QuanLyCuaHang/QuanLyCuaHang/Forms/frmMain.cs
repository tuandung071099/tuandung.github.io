using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHang.FormQuanLy
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormLoai.frmLoai f = new Forms.FormLoai.frmLoai();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmNCC f = new Forms.frmNCC();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmKH f = new Forms.frmKH();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmNV f = new Forms.frmNV();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmSP f = new Forms.frmSP();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }
    }
}
