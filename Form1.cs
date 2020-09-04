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
            double dm = mm * 100;
            double foot = inch * 12;
            double yard = inch * 36;
            double m = mm * 1000;
            double km = m * 1000;
            double mile = yard * 1760;
            double nautical_mile = m * 1852;

            //  современные меры массы

            measure.Add("микрометр", mkm);
            measure.Add("миллиметр", mm);
            measure.Add("сантиметр", cm);
            measure.Add("дюйм", inch);
            measure.Add("дециметр", dm);
            measure.Add("фут", foot);
            measure.Add("ярд", yard);
            measure.Add("метр", m);
            measure.Add("километр", km);
            measure.Add("миля", mile);
            measure.Add("морская миля", nautical_mile);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnActualConvert_Click(object sender, EventArgs e)
        {
            double m1 = measure[cbActualFrom.Text];
            double m2 = measure[cbActualTo.Text];
            double n = Convert.ToDouble(tbActualFrom.Text);
            tbActualTo.Text = (n * m1 / m2).ToString();
        }
    }
}
