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
        const double unit = 1;
        static double m1, m2, n;

        #region современные меры

        //  современные меры времени
        const double sec = unit;
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

        //  современные меры давления
        const double pascal = unit;
        const double atm = pascal * 101325;
        const double bar = pascal * 100000;
        const double torr = atm / 760;
        const double poundStrengthOnSqInch = torr * 51.7149;

        //  современные меры длины
        const double mkmeter = unit;
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

        //  современные меры информации
        const double bit = unit;
        const double @byte = bit * 8;
        const double kbit = bit * 1000;
        const double kibibit = bit * 1024;
        const double mbit = kbit * 1000;
        const double mebibit = kibibit * 1024;
        const double gbit = mbit * 1000;
        const double gibibit = mebibit * 1024;
        const double tbit = gbit * 1000;
        const double tebibit = gibibit * 1024;
        const double kbyte = @byte * 1000;
        const double kibibyte = @byte * 1024;
        const double mbyte = kbyte * 1000;
        const double mebibyte = kibibyte * 1024;
        const double gbyte = mbyte * 1000;
        const double gibibyte = mebibyte * 1024;
        const double tbyte = gbyte * 1000;
        const double tebibyte = gibibyte * 1024;

        //  современные меры массы
        const double mkgram = unit;
        const double mgram = mkgram * 1000;
        const double gram = mgram * 1000;
        const double ounce = gram * 28.3495;
        const double pound = ounce * 16;
        const double kgram = gram * 1000;
        const double ston = ounce * 224;
        const double ton = kgram * 1000;
        const double american_ton = pound * 2000;
        const double british_ton = pound * 2240;

        //  современные меры объёма
        const double mliter = unit;
        const double cubInch = mliter * 16.3871;
        const double liter = mliter * 1000;
        const double american_gallon = cubInch * 231;
        const double cubFoot = cubInch * 1728;
        const double cubMeter = liter * 1000;

        //  современные меры площади
        const double sqInch = unit;
        const double sqFoot = sqInch * 144;
        const double sqYard = sqInch * 1296;
        const double sqMeter = sqInch * 1550;
        const double ar = sqMeter * 100;
        const double akr = sqYard * 4840;
        const double gectar = ar * 100;
        const double sqKmeter = gectar * 100;
        const double sqMile = akr * 640;

        //  современные меры скорости
        const double meterPerSecond = unit;
        const double footPerSecond = meterPerSecond / 3.281;
        const double kmeterPerHour = meterPerSecond / 3.6;
        const double milePerHour = footPerSecond * 1.46667;
        const double knot = kmeterPerHour * 1.852;

        //  современные меры температуры
        const double celsius = unit;
        const double farenheit = unit;
        const double kelvin = unit;

        //  современные меры энергии
        const double joule = unit;
        const double gram_calorie = joule * 4.184;
        const double kcalorie = joule * 4184;
        const double kjoule = joule * 1000;
        const double watt_hour = joule * 3600;
        const double kWatt_hour = watt_hour * 1000;

        #endregion

        public MainForm()
        {
            InitializeComponent();

            measure = new Dictionary<string, double>();

            #region начальная инициализация мер

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

            #endregion

            #region установка стилей списков

            //  стили списков современных мер
            cbActualMeasure.DropDownStyle = ComboBoxStyle.DropDownList;
            cbActualFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbActualTo.DropDownStyle = ComboBoxStyle.DropDownList;

            //  стили списков старорусских мер
            cbRussianMeasure.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRussianFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRussianTo.DropDownStyle = ComboBoxStyle.DropDownList;

            //  стили списков имперских мер
            cbImperialMeasure.DropDownStyle = ComboBoxStyle.DropDownList;
            cbImperialFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbImperialTo.DropDownStyle = ComboBoxStyle.DropDownList;

            //  стили списков японских мер
            cbJapaneseMeasure.DropDownStyle = ComboBoxStyle.DropDownList;
            cbJapaneseFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbJapaneseTo.DropDownStyle = ComboBoxStyle.DropDownList;

            #endregion
        }

        /// <summary>
        /// Метод кнопки конвертации.
        /// Конвертирует современные меры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualConvert_Click(object sender, EventArgs e)
        {
            //  конвертация мер температуры
            if (cbActualMeasure.Text == "Температура")
            {
                if (cbActualFrom.Text == "градус Фаренгейта" & cbActualTo.Text == "градус Цельсия")
                {
                    n = Convert.ToDouble(tbActualFrom.Text);
                    tbActualTo.Text = ((n - 32) * 5 / 9).ToString();
                }
                if (cbActualFrom.Text == "градус Кельвина" & cbActualTo.Text == "градус Цельсия")
                {
                    n = Convert.ToDouble(tbActualFrom.Text);
                    tbActualTo.Text = (n - 273.15).ToString();
                }
                if (cbActualFrom.Text == "градус Кельвина" & cbActualTo.Text == "градус Фаренгейта")
                {
                    n = Convert.ToDouble(tbActualFrom.Text);
                    tbActualTo.Text = (((n - 273.15) * 9 / 5) + 32).ToString();
                }
                if (cbActualFrom.Text == "градус Цельсия" & cbActualTo.Text == "градус Фаренгейта")
                {
                    n = Convert.ToDouble(tbActualFrom.Text);
                    tbActualTo.Text = ((n * 9 / 5) + 32).ToString();
                }
                if (cbActualFrom.Text == "градус Цельсия" & cbActualTo.Text == "градус Кельвина")
                {
                    double n = Convert.ToDouble(tbActualFrom.Text);
                    tbActualTo.Text = (n + 273.15).ToString();
                }
                if (cbActualFrom.Text == "градус Фаренгейта" & cbActualTo.Text == "градус Кельвина")
                {
                    double n = Convert.ToDouble(tbActualFrom.Text);
                    tbActualTo.Text = (((n - 32) * 5 / 9) + 273.15).ToString();
                }
            }    
            
            //  конвертация всех остальных мер
            else
            {
                m1 = measure[cbActualFrom.Text];
                m2 = measure[cbActualTo.Text];
                n = Convert.ToDouble(tbActualFrom.Text);
                tbActualTo.Text = (n * m1 / m2).ToString();
            }
        }

        /// <summary>
        /// Метод кнопки замены.
        /// Меняет местами современные меры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualSwap_Click(object sender, EventArgs e)
        {
            string temp = cbActualFrom.Text;
            cbActualFrom.Text = cbActualTo.Text;
            cbActualTo.Text = temp;
        }
        
        /// <summary>
        /// Метод работает со списком современных мер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbActualMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbActualMeasure.Text)
            {
                #region Время

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

                #endregion

                #region Давление

                case "Давление":
                    measure.Clear();
                    measure.Add("Паскаль", pascal);
                    measure.Add("бар", bar);
                    measure.Add("атмосфера", atm);
                    measure.Add("торр", torr);
                    measure.Add("фунт-сила на квадратный дюйм", poundStrengthOnSqInch);

                    cbActualFrom.Items.Clear();
                    cbActualFrom.Items.Add("Паскаль");
                    cbActualFrom.Items.Add("бар");
                    cbActualFrom.Items.Add("атмосфера");
                    cbActualFrom.Items.Add("торр");
                    cbActualFrom.Items.Add("фунт-сила на квадратный дюйм");

                    cbActualTo.Items.Clear();
                    cbActualTo.Items.Add("Паскаль");
                    cbActualTo.Items.Add("бар");
                    cbActualTo.Items.Add("атмосфера");
                    cbActualTo.Items.Add("торр");
                    cbActualTo.Items.Add("фунт-сила на квадратный дюйм");

                    cbActualFrom.Text = "бар";
                    cbActualTo.Text = "Паскаль";
                    break;

                #endregion

                #region Длина

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

                #endregion

                #region Информация

                case "Информация":
                    measure.Clear();
                    measure.Add("бит", bit);
                    measure.Add("байт", @byte);
                    measure.Add("килобит", kbit);
                    measure.Add("кибибит", kibibit);
                    measure.Add("килобайт", kbyte);
                    measure.Add("кибибайт", kibibyte);
                    measure.Add("мегабит", mbit);
                    measure.Add("мебибит", mebibit);
                    measure.Add("мегабайт", mbyte);
                    measure.Add("мебибайт", mebibyte);
                    measure.Add("гигабит", gbit);
                    measure.Add("гибибит", gibibit);
                    measure.Add("гигабайт", gbyte);
                    measure.Add("гибибайт", gibibyte);
                    measure.Add("терабит", tbit);
                    measure.Add("тебибит", tebibit);
                    measure.Add("терабайт", tbyte);
                    measure.Add("тебибайт", tebibyte);

                    cbActualFrom.Items.Clear();
                    cbActualFrom.Items.Add("бит");
                    cbActualFrom.Items.Add("байт");
                    cbActualFrom.Items.Add("килобит");
                    cbActualFrom.Items.Add("кибибит");
                    cbActualFrom.Items.Add("килобайт");
                    cbActualFrom.Items.Add("кибибайт");
                    cbActualFrom.Items.Add("мегабит");
                    cbActualFrom.Items.Add("мебибит");
                    cbActualFrom.Items.Add("мегабайт");
                    cbActualFrom.Items.Add("мебибайт");
                    cbActualFrom.Items.Add("гигабит");
                    cbActualFrom.Items.Add("гибибит");
                    cbActualFrom.Items.Add("гигабайт");
                    cbActualFrom.Items.Add("гибибайт");
                    cbActualFrom.Items.Add("терабит");
                    cbActualFrom.Items.Add("тебибит");
                    cbActualFrom.Items.Add("терабайт");
                    cbActualFrom.Items.Add("тебибайт");

                    cbActualTo.Items.Clear();
                    cbActualTo.Items.Add("бит");
                    cbActualTo.Items.Add("байт");
                    cbActualTo.Items.Add("килобит");
                    cbActualTo.Items.Add("кибибит");
                    cbActualTo.Items.Add("килобайт");
                    cbActualTo.Items.Add("кибибайт");
                    cbActualTo.Items.Add("мегабит");
                    cbActualTo.Items.Add("мебибит");
                    cbActualTo.Items.Add("мегабайт");
                    cbActualTo.Items.Add("мебибайт");
                    cbActualTo.Items.Add("гигабит");
                    cbActualTo.Items.Add("гибибит");
                    cbActualTo.Items.Add("гигабайт");
                    cbActualTo.Items.Add("гибибайт");
                    cbActualTo.Items.Add("терабит");
                    cbActualTo.Items.Add("тебибит");
                    cbActualTo.Items.Add("терабайт");
                    cbActualTo.Items.Add("тебибайт");

                    cbActualFrom.Text = "байт";
                    cbActualTo.Text = "бит";
                    break;

                #endregion

                #region Масса

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

                #endregion

                #region Объём

                case "Объём":
                    measure.Clear();
                    measure.Add("миллилитр", mgram);
                    measure.Add("кубический дюйм", gram);
                    measure.Add("литр", ounce);
                    measure.Add("галлон (американский)", pound);
                    measure.Add("кубический фут", kgram);
                    measure.Add("кубический метр", ston);

                    cbActualFrom.Items.Clear();
                    cbActualFrom.Items.Add("миллилитр");
                    cbActualFrom.Items.Add("кубический дюйм");
                    cbActualFrom.Items.Add("литр");
                    cbActualFrom.Items.Add("галлон (американский)");
                    cbActualFrom.Items.Add("кубический фут");
                    cbActualFrom.Items.Add("кубический метр");

                    cbActualTo.Items.Clear();
                    cbActualTo.Items.Add("миллилитр");
                    cbActualTo.Items.Add("кубический дюйм");
                    cbActualTo.Items.Add("литр");
                    cbActualTo.Items.Add("галлон (американский)");
                    cbActualTo.Items.Add("кубический фут");
                    cbActualTo.Items.Add("кубический метр");

                    cbActualFrom.Text = "килограмм";
                    cbActualTo.Text = "грамм";
                    break;

                #endregion

                #region Площадь

                case "Площадь":
                    measure.Clear();
                    measure.Add("квадратный дюйм", sqInch);
                    measure.Add("квадратный фут", sqFoot);
                    measure.Add("квадратный ярд", sqYard);
                    measure.Add("квадратный метр", sqMeter);
                    measure.Add("ар", ar);
                    measure.Add("акр", akr);
                    measure.Add("гектар", gectar);
                    measure.Add("квадратный километр", sqKmeter);
                    measure.Add("квадратная миля", sqMile);

                    cbActualFrom.Items.Clear();
                    cbActualFrom.Items.Add("квадратный дюйм");
                    cbActualFrom.Items.Add("квадратный фут");
                    cbActualFrom.Items.Add("квадратный ярд");
                    cbActualFrom.Items.Add("квадратный метр"); 
                    cbActualFrom.Items.Add("ар");
                    cbActualFrom.Items.Add("акр");
                    cbActualFrom.Items.Add("гектар");
                    cbActualFrom.Items.Add("квадратный километр");
                    cbActualFrom.Items.Add("квадратная миля");

                    cbActualTo.Items.Clear();
                    cbActualTo.Items.Add("квадратный дюйм");
                    cbActualTo.Items.Add("квадратный фут");
                    cbActualTo.Items.Add("квадратный ярд");
                    cbActualTo.Items.Add("квадратный метр");
                    cbActualTo.Items.Add("ар");
                    cbActualTo.Items.Add("акр");
                    cbActualTo.Items.Add("гектар");
                    cbActualTo.Items.Add("квадратный километр");
                    cbActualTo.Items.Add("квадратная миля");

                    cbActualFrom.Text = "гектар";
                    cbActualTo.Text = "ар";
                    break;

                #endregion

                #region Скорость

                case "Скорость":
                    measure.Clear();
                    measure.Add("метр в секунду", meterPerSecond);
                    measure.Add("фут в секунду", footPerSecond);
                    measure.Add("километр в час", kmeterPerHour);
                    measure.Add("миля в час", milePerHour);
                    measure.Add("узел", knot);

                    cbActualFrom.Items.Clear();
                    cbActualFrom.Items.Add("метр в секунду");
                    cbActualFrom.Items.Add("фут в секунду");
                    cbActualFrom.Items.Add("километр в час");
                    cbActualFrom.Items.Add("миля в час");
                    cbActualFrom.Items.Add("узел");

                    cbActualTo.Items.Clear();
                    cbActualTo.Items.Add("метр в секунду");
                    cbActualTo.Items.Add("фут в секунду");
                    cbActualTo.Items.Add("километр в час");
                    cbActualTo.Items.Add("миля в час");
                    cbActualTo.Items.Add("узел");

                    cbActualFrom.Text = "метр в секунду";
                    cbActualTo.Text = "километр в час";
                    break;

                #endregion

                #region Температура

                case "Температура":
                    measure.Clear();
                    measure.Add("градус Цельсия", celsius);
                    measure.Add("градус Фаренгейта", farenheit);
                    measure.Add("градус Кельвина", kelvin);

                    cbActualFrom.Items.Clear();
                    cbActualFrom.Items.Add("градус Цельсия");
                    cbActualFrom.Items.Add("градус Фаренгейта");
                    cbActualFrom.Items.Add("градус Кельвина");

                    cbActualTo.Items.Clear();
                    cbActualTo.Items.Add("градус Цельсия");
                    cbActualTo.Items.Add("градус Фаренгейта");
                    cbActualTo.Items.Add("градус Кельвина");

                    cbActualFrom.Text = "градус Фаренгейта";
                    cbActualTo.Text = "градус Цельсия";
                    break;

                #endregion


                //Энергия

                default:
                    break;
            }
        }
    }
}
