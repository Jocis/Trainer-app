using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkaitmeninisTreneris
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoginForm pridetiForma = new LoginForm();
            pridetiForma.KeistiLanga += KeistiForma;
            pridetiForma.TopLevel = false;
            MainFormP.Controls.Add(pridetiForma);
            pridetiForma.Show();
        }

        public void KeistiForma(Form form)
        {
            form.TopLevel = false;
            MainFormP.Controls.Clear();
            MainFormP.Controls.Add(form);
            form.Show();
        }
    }
}
