using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    public partial class MainForm : Form
    {
        Dictionary<string, double> measure;
        
        public MainForm()
        {
            InitializeComponent();
            measure = new Dictionary<string, double>();

            //  современные меры длины
            double mkm = 1;
            double mm = mkm * 1000;
            double cm = mm * 10;
            double inch = mm * 25.4;
            double foot = inch * 12;
            double yard = inch * 36;
            double dm = mm * 100;
            double m = mm * 1000;
            double km = m * 1000;
            double mile = yard * 1760;
            double nautical_mile = m * 1852;

            //  современные меры массы


        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
