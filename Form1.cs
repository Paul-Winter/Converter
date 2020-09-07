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
        public Dictionary<string, double> Measure { get => measure; set => measure = value; }
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

        #region старорусские меры

        //  старорусские меры длины
        const double linia = mmeter * 2.54;
        const double duim = linia * 10;
        const double vershok = duim * 1.75;
        const double ladon = cmeter * 7.5;
        const double chetvert = vershok * 4;
        const double arshin = vershok * 16;
        const double pyad = cmeter * 17.78;
        const double fut = duim * 12;
        const double lokot = ladon * 6;
        const double shag = cmeter * 71;
        const double mahovaya_sagen = vershok * 40;
        const double kosaya_sagen = meter * 2.48;
        const double kazennaya_sagen = duim * 84;
        const double shest = kazennaya_sagen * 10;
        const double cep = kazennaya_sagen * 50;
        const double versta = mahovaya_sagen * 500;
        const double rus_mile = versta * 7;
        const double poprische = versta;

        //  старорусские меры массы
        const double dolya = mgram * 44.43494;
        const double zolotnik = dolya * 96;
        const double lot = zolotnik * 3;
        const double grivenka = zolotnik * 48;
        const double funt = lot * 32;
        const double grivna = funt;
        const double batman = funt * 10;
        const double pud = lot * 1280;
        const double polpuda = pud / 2;
        const double kantar = kgram * 40.95;
        const double berkovec = pud * 10;
        const double chetvert_voschanaya = pud * 12;
        const double last = pud * 72;

        //  старорусские меры объёма
        const double cubSagen = cubArshin * 27;
        const double cubArshin = cubVershok * 4096;
        const double cubVershok = cubDuim * 5.3594;
        const double cubFut = cubDuim * 1728;
        const double cubDuim = cubLinia * 1000;
        const double cubLinia = cubMmeter * 16.3871;
        const double cubMmeter = mliter / 1000;

        //  старорусские меры объёма жидких тел (винные меры)
        const double shkalik = mliter * 61.5;
        const double charka = shkalik * 2;
        const double chetushka = charka * 2;
        const double stakan = liter * 0.273;
        const double kosushka = shkalik * 5;
        const double butilka_vodki = charka * 5;
        const double butilka_vina = stakan * 3;
        const double shtof = shkalik * 20;
        const double garnec = stakan * 12;
        const double chetvert_vedra = garnec;
        const double vedro = garnec * 4;
        const double korchaga = vedro * 2;
        const double bochka = vedro * 40;

        //  старорусские меры объёма сыпучих тел (хлебные меры)
        const double polugarnec = stakan * 6;
        const double chetverka = liter * 6.56;
        const double poluchetverik = liter * 13.12;
        const double chetverik = garnec * 8;
        const double mera = chetverik;
        const double polosminy = liter * 52.48;
        const double osmina = chetverik * 4;
        const double chet_sip = garnec * 64;
        const double polovnik = liter * 419.84;
        const double kadka = osmina * 8;

        //  старорусские меры площади
        const double sqCmeter = sqMeter / 10000;
        const double sqVershok = sqCmeter * 19.758;
        const double sqArshin = sqVershok * 256;
        const double sqSagen = sqArshin * 9;
        const double osminnik = sqSagen * 300;
        const double chet = sqSagen * 1200;
        const double desyatina = sqSagen * 2400;
        const double sqVersta = sqSagen * 250000;

        #endregion

        #region имперские меры

        //  имперские меры длины


        //  имперские меры массы (американские)


        //  имперские меры массы(британские)


        //  имперские меры объёма жидких тел(американские)


        //  имперские меры объёма сыпучих тел(британские)


        //  имперские меры объёма сыпучих тел(американские)


        //  имперские меры объёма сыпучих тел(британские)


        //  имперские меры площади


        #endregion

        #region японские меры

        //  японские меры длины


        //  японские меры массы


        //  японские меры объёма


        //  японские меры площади


        #endregion


        public MainForm()
        {
            InitializeComponent();

            Measure = new Dictionary<string, double>();

            #region начальная инициализация мер

            Measure.Add("микрометр", mkmeter);
            Measure.Add("миллиметр", mmeter);
            Measure.Add("сантиметр", cmeter);
            Measure.Add("дюйм", inch);
            Measure.Add("дециметр", dmeter);
            Measure.Add("фут", foot);
            Measure.Add("ярд", yard);
            Measure.Add("метр", meter);
            Measure.Add("километр", kmeter);
            Measure.Add("миля", mile);
            Measure.Add("морская миля", nautical_mile);

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
            //  конвертация всех мер, кроме температуры
            if (cbActualMeasure.Text != "Температура")
            {
                m1 = Measure[cbActualFrom.Text];
                m2 = Measure[cbActualTo.Text];
                try
                {
                    n = Convert.ToDouble(tbActualFrom.Text);
                }
                catch
                {
                    n = 1;
                    tbActualFrom.Text = n.ToString();
                }
                tbActualTo.Text = (n * m1 / m2).ToString();
            }
            //  конвертация мер температуры 
            else
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
        }
        /// <summary>
        /// Метод кнопки замены.
        /// Меняет местами современные меры
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
                    Measure.Clear();
                    Measure.Add("наносекунда", nsec);
                    Measure.Add("микросекунда", mksec);
                    Measure.Add("миллисекунда", msec);
                    Measure.Add("секунда", sec);
                    Measure.Add("минута", min);
                    Measure.Add("час", hour);
                    Measure.Add("сутки", day);
                    Measure.Add("неделя", week);
                    Measure.Add("месяц", month);
                    Measure.Add("год", year);
                    Measure.Add("век", century);

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
                    Measure.Clear();
                    Measure.Add("Паскаль", pascal);
                    Measure.Add("бар", bar);
                    Measure.Add("атмосфера", atm);
                    Measure.Add("торр", torr);
                    Measure.Add("фунт-сила на квадратный дюйм", poundStrengthOnSqInch);

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
                    Measure.Clear();
                    Measure.Add("микрометр", mkmeter);
                    Measure.Add("миллиметр", mmeter);
                    Measure.Add("сантиметр", cmeter);
                    Measure.Add("дюйм", inch);
                    Measure.Add("дециметр", dmeter);
                    Measure.Add("фут", foot);
                    Measure.Add("ярд", yard);
                    Measure.Add("метр", meter);
                    Measure.Add("километр", kmeter);
                    Measure.Add("миля", mile);
                    Measure.Add("морская миля", nautical_mile);

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
                    Measure.Clear();
                    Measure.Add("бит", bit);
                    Measure.Add("байт", @byte);
                    Measure.Add("килобит", kbit);
                    Measure.Add("кибибит", kibibit);
                    Measure.Add("килобайт", kbyte);
                    Measure.Add("кибибайт", kibibyte);
                    Measure.Add("мегабит", mbit);
                    Measure.Add("мебибит", mebibit);
                    Measure.Add("мегабайт", mbyte);
                    Measure.Add("мебибайт", mebibyte);
                    Measure.Add("гигабит", gbit);
                    Measure.Add("гибибит", gibibit);
                    Measure.Add("гигабайт", gbyte);
                    Measure.Add("гибибайт", gibibyte);
                    Measure.Add("терабит", tbit);
                    Measure.Add("тебибит", tebibit);
                    Measure.Add("терабайт", tbyte);
                    Measure.Add("тебибайт", tebibyte);

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
                    Measure.Clear();
                    Measure.Add("микрограмм", mkgram);
                    Measure.Add("миллиграмм", mgram);
                    Measure.Add("грамм", gram);
                    Measure.Add("унция", ounce);
                    Measure.Add("фунт", pound);
                    Measure.Add("килограмм", kgram);
                    Measure.Add("стон", ston);
                    Measure.Add("тонна", ton);
                    Measure.Add("американская тонна", american_ton);
                    Measure.Add("английская тонна", british_ton);

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
                    Measure.Clear();
                    Measure.Add("миллилитр", mliter);
                    Measure.Add("кубический дюйм", cubInch);
                    Measure.Add("литр", liter);
                    Measure.Add("галлон (американский)", american_gallon);
                    Measure.Add("кубический фут", cubFoot);
                    Measure.Add("кубический метр", cubMeter);

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

                    cbActualFrom.Text = "галлон (американский)";
                    cbActualTo.Text = "литр";
                    break;

                #endregion

                #region Площадь

                case "Площадь":
                    Measure.Clear();
                    Measure.Add("квадратный дюйм", sqInch);
                    Measure.Add("квадратный фут", sqFoot);
                    Measure.Add("квадратный ярд", sqYard);
                    Measure.Add("квадратный метр", sqMeter);
                    Measure.Add("ар", ar);
                    Measure.Add("акр", akr);
                    Measure.Add("гектар", gectar);
                    Measure.Add("квадратный километр", sqKmeter);
                    Measure.Add("квадратная миля", sqMile);

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
                    Measure.Clear();
                    Measure.Add("метр в секунду", meterPerSecond);
                    Measure.Add("фут в секунду", footPerSecond);
                    Measure.Add("километр в час", kmeterPerHour);
                    Measure.Add("миля в час", milePerHour);
                    Measure.Add("узел", knot);

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
                    Measure.Clear();
                    Measure.Add("градус Цельсия", celsius);
                    Measure.Add("градус Фаренгейта", farenheit);
                    Measure.Add("градус Кельвина", kelvin);

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

                #region Энергия

                case "Энергия":
                    Measure.Clear();
                    Measure.Add("Джоуль", joule);
                    Measure.Add("грамм-калория", gram_calorie);
                    Measure.Add("килокалория", kcalorie);
                    Measure.Add("килоджоуль", kjoule);
                    Measure.Add("Ватт-час", watt_hour);
                    Measure.Add("киловатт-час", kWatt_hour);

                    cbActualFrom.Items.Clear();
                    cbActualFrom.Items.Add("Джоуль");
                    cbActualFrom.Items.Add("грамм-калория");
                    cbActualFrom.Items.Add("килокалория");
                    cbActualFrom.Items.Add("килоджоуль");
                    cbActualFrom.Items.Add("Ватт-час");
                    cbActualFrom.Items.Add("киловатт-час");

                    cbActualTo.Items.Clear();
                    cbActualTo.Items.Add("Джоуль");
                    cbActualTo.Items.Add("грамм-калория");
                    cbActualTo.Items.Add("килокалория");
                    cbActualTo.Items.Add("килоджоуль");
                    cbActualTo.Items.Add("Ватт-час");
                    cbActualTo.Items.Add("киловатт-час");

                    cbActualFrom.Text = "килокалория";
                    cbActualTo.Text = "Джоуль";
                    break;

                #endregion
            }
        }


        /// <summary>
        /// Метод кнопки конвертации.
        /// Конвертирует старорусские меры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRussianConvert_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Метод кнопки замены.
        /// Меняет местами старорусские меры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRussianSwap_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Метод работает со списком старорусских мер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbRussianMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Метод кнопки конвертации.
        /// Конвертирует имперские меры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImperialConvert_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Метод кнопки замены.
        /// Меняет местами имперские меры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImperialSwap_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Метод работает со списком имперских мер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbImperialMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Метод конвертации.
        /// Конвертирует японские меры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJapaneseConvert_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Метод кнопки замены.
        /// Меняет местами японские меры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJapaneseSwap_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Метод работает со списком японских мер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbJapaneseMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
