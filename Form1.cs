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

        //  современные меры времени
        const double sec = 1;
        const double min = sec * 60;
        const double hour = min * 60;
        const double day = hour * 24;
        const double week = day * 7;
        const double year = hour * 8760;
        const double month = year / 12;
        const double century = year * 100;
        const double msec = sec / 1000;
        const double mksec = msec / 1000;
        const double nsec = mksec / 1000;

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
        const double ton = kgram * 1000;
        const double american_ton = pound * 2000;
        const double british_ton = pound * 2240;

        
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
                case "Время":
                    measure.Clear();
                    measure.Add("наносекунда", nsec);
                    measure.Add("микросекунда", mksec);
                    measure.Add("миллисекунда", msec);
                    measure.Add("секунда", sec);
                    measure.Add("минута", min);
                    measure.Add("час", hour);
                    measure.Add("сутки", day);
                    measure.Add("неделя", week);
                    measure.Add("месяц", month);
                    measure.Add("год", year);
                    measure.Add("век", century);
                    cbActualFrom.Items.Clear();
                    cbActualFrom.Items.Add("наносекунда");
                    cbActualFrom.Items.Add("микросекунда");
                    cbActualFrom.Items.Add("миллисекунда");
                    cbActualFrom.Items.Add("секунда");
                    cbActualFrom.Items.Add("минута");
                    cbActualFrom.Items.Add("час");
                    cbActualFrom.Items.Add("сутки");
                    cbActualFrom.Items.Add("неделя");
                    cbActualFrom.Items.Add("месяц");
                    cbActualFrom.Items.Add("год");
                    cbActualFrom.Items.Add("век");
                    cbActualTo.Items.Clear();
                    cbActualTo.Items.Add("наносекунда");
                    cbActualTo.Items.Add("микросекунда");
                    cbActualTo.Items.Add("миллисекунда");
                    cbActualTo.Items.Add("секунда");
                    cbActualTo.Items.Add("минута");
                    cbActualTo.Items.Add("час");
                    cbActualTo.Items.Add("сутки");
                    cbActualTo.Items.Add("неделя");
                    cbActualTo.Items.Add("месяц");
                    cbActualTo.Items.Add("год");
                    cbActualTo.Items.Add("век");
                    cbActualFrom.Text = "час";
                    cbActualTo.Text = "секунда";
                    break;

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
                    measure.Add("тонна", ton);
                    measure.Add("американская тонна", american_ton);
                    measure.Add("английская тонна", british_ton);
                    cbActualFrom.Items.Clear();
                    cbActualFrom.Items.Add("микрограмм");
                    cbActualFrom.Items.Add("миллиграмм");
                    cbActualFrom.Items.Add("грамм");
                    cbActualFrom.Items.Add("унция");
                    cbActualFrom.Items.Add("фунт");
                    cbActualFrom.Items.Add("килограмм");
                    cbActualFrom.Items.Add("стон");
                    cbActualFrom.Items.Add("тонна");
                    cbActualFrom.Items.Add("американская тонна");
                    cbActualFrom.Items.Add("английская тонна");
                    cbActualTo.Items.Clear();
                    cbActualTo.Items.Add("микрограмм");
                    cbActualTo.Items.Add("миллиграмм");
                    cbActualTo.Items.Add("грамм");
                    cbActualTo.Items.Add("унция");
                    cbActualTo.Items.Add("фунт");
                    cbActualTo.Items.Add("килограмм");
                    cbActualTo.Items.Add("стон");
                    cbActualTo.Items.Add("тонна");
                    cbActualTo.Items.Add("американская тонна");
                    cbActualTo.Items.Add("английская тонна");
                    cbActualFrom.Text = "килограмм";
                    cbActualTo.Text = "грамм";
                    break;

                default:
                    break;
            }
        }
    }
}
