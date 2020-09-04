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
        
        //  современные меры длины
        const double mkmeter = 1;
        const double mmeter = mkmeter * 1000;
        const double cmeter = mmeter * 10;
        const double inch = mmeter * 25.4;
        const double dmeter = mmeter * 100;
        const double foot = inch * 12;
        const double yard = inch * 36;
        const double meter = mmeter * 1000;
        const double kmeter = meter * 1000;
        const double mile = yard * 1760;
        const double nautical_mile = meter * 1852;

        //  современные меры массы
        const double mkgram = 1;
        const double mgram = mkgram * 1000;
        const double gram = mgram * 1000;
        const double ounce = gram * 28.3495;
        const double pound = ounce * 16;
        const double kgram = gram * 1000;
        const double ston = ounce * 224;
        const double tonn = kgram * 1000;
        
        public MainForm()
        {
            InitializeComponent();
            measure = new Dictionary<string, double>();

            //  начальные значения
            measure.Add("микрометр", mkmeter);
            measure.Add("миллиметр", mmeter);
            measure.Add("сантиметр", cmeter);
            measure.Add("дюйм", inch);
            measure.Add("дециметр", dmeter);
            measure.Add("фут", foot);
            measure.Add("ярд", yard);
            measure.Add("метр", meter);
            measure.Add("километр", kmeter);
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

        private void btnActualSwap_Click(object sender, EventArgs e)
        {
            string temp = cbActualFrom.Text;
            cbActualFrom.Text = cbActualTo.Text;
            cbActualTo.Text = temp;
        }

        private void cbActualMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbActualMeasure.Text)
            {
                case "Длина":
                    measure.Clear();
                    measure.Add("микрометр", mkmeter);
                    measure.Add("миллиметр", mmeter);
                    measure.Add("сантиметр", cmeter);
                    measure.Add("дюйм", inch);
                    measure.Add("дециметр", dmeter);
                    measure.Add("фут", foot);
                    measure.Add("ярд", yard);
                    measure.Add("метр", meter);
                    measure.Add("километр", kmeter);
                    measure.Add("миля", mile);
                    measure.Add("морская миля", nautical_mile);
                    cbActualFrom.Items.Clear();
                    cbActualFrom.Items.Add("микрометр");
                    cbActualFrom.Items.Add("миллиметр");
                    cbActualFrom.Items.Add("сантиметр");
                    cbActualFrom.Items.Add("дюйм");
                    cbActualFrom.Items.Add("дециметр");
                    cbActualFrom.Items.Add("фут");
                    cbActualFrom.Items.Add("ярд");
                    cbActualFrom.Items.Add("метр");
                    cbActualFrom.Items.Add("километр");
                    cbActualFrom.Items.Add("миля");
                    cbActualFrom.Items.Add("морская миля");
                    cbActualTo.Items.Clear();
                    cbActualTo.Items.Add("микрометр");
                    cbActualTo.Items.Add("миллиметр");
                    cbActualTo.Items.Add("сантиметр");
                    cbActualTo.Items.Add("дюйм");
                    cbActualTo.Items.Add("дециметр");
                    cbActualTo.Items.Add("фут");
                    cbActualTo.Items.Add("ярд");
                    cbActualTo.Items.Add("метр");
                    cbActualTo.Items.Add("километр");
                    cbActualTo.Items.Add("миля");
                    cbActualTo.Items.Add("морская миля");
                    cbActualFrom.Text = "метр";
                    cbActualTo.Text = "миллиметр";
                    break;

                case "Масса":
                    measure.Clear();
                    measure.Add("микрограмм", mkgram);
                    measure.Add("миллиграмм", mgram);
                    measure.Add("грамм", gram);
                    measure.Add("унция", ounce);
                    measure.Add("фунт", pound);
                    measure.Add("килограмм", kgram);
                    measure.Add("стон", ston);
                    measure.Add("тонна", tonn);
                    cbActualFrom.Items.Clear();
                    cbActualFrom.Items.Add("микрограмм");
                    cbActualFrom.Items.Add("миллиграмм");
                    cbActualFrom.Items.Add("грамм");
                    cbActualFrom.Items.Add("унция");
                    cbActualFrom.Items.Add("фунт");
                    cbActualFrom.Items.Add("килограмм");
                    cbActualFrom.Items.Add("стон");
                    cbActualFrom.Items.Add("тонна");
                    cbActualTo.Items.Clear();
                    cbActualTo.Items.Add("микрограмм");
                    cbActualTo.Items.Add("миллиграмм");
                    cbActualTo.Items.Add("грамм");
                    cbActualTo.Items.Add("унция");
                    cbActualTo.Items.Add("фунт");
                    cbActualTo.Items.Add("килограмм");
                    cbActualTo.Items.Add("стон");
                    cbActualTo.Items.Add("тонна");
                    cbActualFrom.Text = "килограмм";
                    cbActualTo.Text = "грамм";
                    break;

                default:
                    break;
            }
        }
    }
}
