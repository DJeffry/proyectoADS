using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Alimentos
{
    public partial class splashScreen : Form
    {

        Timer t = new Timer();
        int i = 0;

        public splashScreen()
        {
            InitializeComponent();
        }

        private void splashScreen_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;

            t.Tick += new EventHandler(this.t_Tick);

            t.Start();
        }


        private void t_Tick(Object sender, EventArgs e)
        {
            i++;
            if (i >= 5)
            {
                Login lg = new Login();
                lg.Show();
                this.Hide();
                t.Stop();
            }
        }

    }
}
