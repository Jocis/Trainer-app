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
    public partial class LoginForm : Form
    {
        public static LoginForm Current;
        public Action<Form> KeistiLanga;
        public static string userName = "";

        public LoginForm()
        {
            Current = this;
            InitializeComponent();

            PratimuKatalogasLINQDataContext db = new PratimuKatalogasLINQDataContext();

            LoginBt.Click += (s, e) => {
                userName = UsernameTB.Text;
                if (db.Users.Where(u => u.UserName == UsernameTB.Text).Any())
                {
                    if (db.Users.Where(u => u.Password == PasswordTB.Text).Any())
                    {
                        this.Visible = false;
                        KeistiLanga(new Form1(KeistiLanga));
                   }
                }
            };
        }
    }
}
