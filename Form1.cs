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
        Dictionary<string, double> actual_measure;
        Dictionary<string, double> russian_measure;
        Dictionary<string, double> imperial_measure;
        Dictionary<string, double> japanese_measure;

        public Dictionary<string, double> Actual_measure { get => actual_measure; set => actual_measure = value; }
        public Dictionary<string, double> Russian_measure { get => russian_measure; set => russian_measure = value; }
        public Dictionary<string, double> Imperial_measure { get => imperial_measure; set => imperial_measure = value; }
        public Dictionary<string, double> Japanese_measure { get => japanese_measure; set => japanese_measure = value; }

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
        const double stone = ounce * 224;
        const double ton = kgram * 1000;
        const double american_ton = pound * 2000;
        const double british_ton = pound * 2240;

        //  современные меры объёма
        const double mliter = unit;
        const double cubInch = mliter * 16.3871;
        const double liter = mliter * 1000;
        const double gallon_american = cubInch * 231;
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
        const double league = furlong * 24;
        const double nautical_mile_british = cable_british * 10;
        const double cable_british = meter * 185.3182;
        const double cable_american = meter * 185.3249;
        const double statute_mile = furlong * 8;
        const double furlong = chain * 10;
        const double chain = rod * 4;
        const double rod = yard * 5.5;
        const double hand = inch * 4;
        const double barleycorn = inch / 3;
        const double line = point * 6;
        const double point = inch / 72;
        const double mil = inch / 1000;

        //  имперские меры массы (американские)
        const double quintal = pound * 100;
        const double hundredweight = quintal;
        const double cental = quintal;
        const double slag = kgram * 14.6;
        const double quarter = pound * 25;

        //  имперские меры массы(британские)
        const double long_ton = pound * 2240;
        const double short_ton = pound * 2000;
        const double kile = cheldron * 8;
        const double cheldron = pound * 5936;
        const double long_hundredweight = pound * 112;
        const double short_hundredweight = pound * 100;
        const double tod = pound * 28;
        const double clove = pound * 7;
        const double quartern = stone / 4;
        const double dram = ounce / 16;
        const double grain = mgram * 64.79891;

        //  имперские меры объёма жидких тел (американские)
        const double barrel_american = gallon_american * 31;
        const double barrelOfCrudOil = gallon_american * 42.2;
        const double pint_american = gallon_american / 8;
        const double gill = pint_american / 4;
        const double liqOunce_american = gallon_american / 128;
        const double drink = liqOunce_american * 2;
        const double drahm = liqOunce_american / 8;
        const double spoon_tea_american = mliter * 4.9;
        const double spoon_table_american = spoon_tea_american * 3;
        const double drop = spoon_tea_american / 60;
        const double spoon_coffee_american = spoon_tea_american / 2;
        const double spoon_spice_american = spoon_tea_american / 4;
        const double minim_british = mliter * 0.05919;

        //  имперские меры объёма жидких тел (британские)
        const double winebottle = mliter * 750;
        const double wineglass = liqDram * 16;
        const double liqOunce = scrupul * 24;
        const double liqDram = minim_british * 60;
        const double scrupul = minim_british * 20;
        const double spoon_tea_british = liqDram * 4;
        const double spoon_table_british = spoon_tea_british * 3;
        const double breakfastCup = liqOunce * 10;
        const double gill_british = liqOunce * 5;
        const double liqPint_british = liqOunce * 20;
        const double filet = mliter * 375;
        const double bucket = gallon_british * 5;
        const double liqQuarta = liqPint_british * 2;
        const double pottle = liqQuarta * 2;
        const double liqGallon = liqOunce * 160;
        const double firkin = liqQuarta * 36;
        const double kilderkin = firkin * 2;
        const double liqBarrel = liqGallon * 36;
        const double hogshead = liqGallon * 52.5;
        const double pipe = liqGallon * 105;
        const double but = liqGallon * 108; 

        //  имперские меры объёма сыпучих тел (американские)
        const double ounce_american = gram * 28.35;
        const double quarter_american = liter * 282;
        const double coum_american = quarter_american / 2;
        const double bushel_american = liter * 35.2393;
        const double pek_american = liter * 8.81;
        const double gallon = liter * 4.405;
        const double quarta_american = liter * 1.101;
        const double pint_american_dry = gallon / 8;

        //  имперские меры объёма сыпучих тел (британские)
        const double pint_british = liter * 0.568261;
        const double quart_british = pint_british * 2;
        const double quartern_british = quart_british * 2;
        const double gallon_british = pint_british * 8;
        const double pek = gallon_british * 2;
        const double bushel = pint_british * 64;
        const double strike = bushel * 2;
        const double sack = bushel * 3;
        const double barrel_british = gallon_british * 40;
        const double coum_british = gallon_british * 32;
        const double quarter_british = bushel * 8;
        const double chelder = bushel * 36;

        //  имперские меры площади
        const double rood = sqRod * 40;
        const double sqRod = sqYard * 30.25;

        #endregion

        #region японские меры

        //  японские меры длины
        const double bu = mmeter * 3.03;
        const double sun = bu * 10;
        const double syaku = sun * 10;
        const double ken = syaku * 6;
        const double hiro = ken;
        const double dze = syaku * 10;
        const double te = ken * 60;
        const double ri = te * 36;

        //  японские меры массы
        const double fun = mgram * 375;
        const double momme = fun * 10;
        const double kin = momme * 160;
        const double kan = momme * 1000;

        //  японские меры объёма
        const double go = liter * 0.18039;
        const double se = go * 10;
        const double to = se * 10;
        const double koku = to * 10;

        //  японские меры площади
        const double sqKen = sqMeter * 3.3058;
        const double tsubo = sqKen;
        const double sqGo = tsubo / 10;
        const double sqDze = tsubo / 2;
        const double une = tsubo * 30;
        const double tan = une * 10;
        const double sqTe = tan * 10;

        #endregion


        public MainForm()
        {
            InitializeComponent();

            Actual_measure = new Dictionary<string, double>();
            Russian_measure = new Dictionary<string, double>();
            Imperial_measure = new Dictionary<string, double>();
            Japanese_measure = new Dictionary<string, double>();

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

            //  Начальная инициализация мер:
            #region современных

            Actual_measure.Add("микрометр", mkmeter);
            Actual_measure.Add("миллиметр", mmeter);
            Actual_measure.Add("сантиметр", cmeter);
            Actual_measure.Add("дюйм", inch);
            Actual_measure.Add("дециметр", dmeter);
            Actual_measure.Add("фут", foot);
            Actual_measure.Add("ярд", yard);
            Actual_measure.Add("метр", meter);
            Actual_measure.Add("километр", kmeter);
            Actual_measure.Add("миля", mile);
            Actual_measure.Add("морская миля", nautical_mile);

            #endregion

            #region старорусских

            Russian_measure.Add("миллиметр", mmeter);
            Russian_measure.Add("метр", meter);
            Russian_measure.Add("линия", linia);
            Russian_measure.Add("дюйм", duim);
            Russian_measure.Add("вершок", vershok);
            Russian_measure.Add("ладонь", ladon);
            Russian_measure.Add("четверть", chetvert);
            Russian_measure.Add("аршин", arshin);
            Russian_measure.Add("пядь", pyad);
            Russian_measure.Add("фут", fut);
            Russian_measure.Add("локоть", lokot);
            Russian_measure.Add("шаг", shag);
            Russian_measure.Add("сажень маховая", mahovaya_sagen);
            Russian_measure.Add("сажень косая", kosaya_sagen);
            Russian_measure.Add("сажень казённая", kazennaya_sagen);
            Russian_measure.Add("шест", shest);
            Russian_measure.Add("цепь", cep);
            Russian_measure.Add("верста", versta);
            Russian_measure.Add("русская миля", rus_mile);
            Russian_measure.Add("поприще", poprische);

            #endregion

            #region имперских

            Imperial_measure.Add("миллиметр", mmeter);
            Imperial_measure.Add("метр", meter);

            #endregion

            #region японских

            Japanese_measure.Add("миллиметр", mmeter);
            Japanese_measure.Add("метр", meter);

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
                m1 = Actual_measure[cbActualFrom.Text];
                m2 = Actual_measure[cbActualTo.Text];
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
                    Actual_measure.Clear();
                    Actual_measure.Add("наносекунда", nsec);
                    Actual_measure.Add("микросекунда", mksec);
                    Actual_measure.Add("миллисекунда", msec);
                    Actual_measure.Add("секунда", sec);
                    Actual_measure.Add("минута", min);
                    Actual_measure.Add("час", hour);
                    Actual_measure.Add("сутки", day);
                    Actual_measure.Add("неделя", week);
                    Actual_measure.Add("месяц", month);
                    Actual_measure.Add("год", year);
                    Actual_measure.Add("век", century);

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
                    Actual_measure.Clear();
                    Actual_measure.Add("Паскаль", pascal);
                    Actual_measure.Add("бар", bar);
                    Actual_measure.Add("атмосфера", atm);
                    Actual_measure.Add("торр", torr);
                    Actual_measure.Add("фунт-сила на квадратный дюйм", poundStrengthOnSqInch);

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
                    Actual_measure.Clear();
                    Actual_measure.Add("микрометр", mkmeter);
                    Actual_measure.Add("миллиметр", mmeter);
                    Actual_measure.Add("сантиметр", cmeter);
                    Actual_measure.Add("дюйм", inch);
                    Actual_measure.Add("дециметр", dmeter);
                    Actual_measure.Add("фут", foot);
                    Actual_measure.Add("ярд", yard);
                    Actual_measure.Add("метр", meter);
                    Actual_measure.Add("километр", kmeter);
                    Actual_measure.Add("миля", mile);
                    Actual_measure.Add("морская миля", nautical_mile);

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
                    Actual_measure.Clear();
                    Actual_measure.Add("бит", bit);
                    Actual_measure.Add("байт", @byte);
                    Actual_measure.Add("килобит", kbit);
                    Actual_measure.Add("кибибит", kibibit);
                    Actual_measure.Add("килобайт", kbyte);
                    Actual_measure.Add("кибибайт", kibibyte);
                    Actual_measure.Add("мегабит", mbit);
                    Actual_measure.Add("мебибит", mebibit);
                    Actual_measure.Add("мегабайт", mbyte);
                    Actual_measure.Add("мебибайт", mebibyte);
                    Actual_measure.Add("гигабит", gbit);
                    Actual_measure.Add("гибибит", gibibit);
                    Actual_measure.Add("гигабайт", gbyte);
                    Actual_measure.Add("гибибайт", gibibyte);
                    Actual_measure.Add("терабит", tbit);
                    Actual_measure.Add("тебибит", tebibit);
                    Actual_measure.Add("терабайт", tbyte);
                    Actual_measure.Add("тебибайт", tebibyte);

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
                    Actual_measure.Clear();
                    Actual_measure.Add("микрограмм", mkgram);
                    Actual_measure.Add("миллиграмм", mgram);
                    Actual_measure.Add("грамм", gram);
                    Actual_measure.Add("унция", ounce);
                    Actual_measure.Add("фунт", pound);
                    Actual_measure.Add("килограмм", kgram);
                    Actual_measure.Add("стон", stone);
                    Actual_measure.Add("тонна", ton);
                    Actual_measure.Add("американская тонна", american_ton);
                    Actual_measure.Add("английская тонна", british_ton);

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
                    Actual_measure.Clear();
                    Actual_measure.Add("миллилитр", mliter);
                    Actual_measure.Add("кубический дюйм", cubInch);
                    Actual_measure.Add("литр", liter);
                    Actual_measure.Add("галлон (американский)", gallon_american);
                    Actual_measure.Add("кубический фут", cubFoot);
                    Actual_measure.Add("кубический метр", cubMeter);

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
                    Actual_measure.Clear();
                    Actual_measure.Add("квадратный дюйм", sqInch);
                    Actual_measure.Add("квадратный фут", sqFoot);
                    Actual_measure.Add("квадратный ярд", sqYard);
                    Actual_measure.Add("квадратный метр", sqMeter);
                    Actual_measure.Add("ар", ar);
                    Actual_measure.Add("акр", akr);
                    Actual_measure.Add("гектар", gectar);
                    Actual_measure.Add("квадратный километр", sqKmeter);
                    Actual_measure.Add("квадратная миля", sqMile);

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
                    Actual_measure.Clear();
                    Actual_measure.Add("метр в секунду", meterPerSecond);
                    Actual_measure.Add("фут в секунду", footPerSecond);
                    Actual_measure.Add("километр в час", kmeterPerHour);
                    Actual_measure.Add("миля в час", milePerHour);
                    Actual_measure.Add("узел", knot);

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
                    Actual_measure.Clear();
                    Actual_measure.Add("градус Цельсия", celsius);
                    Actual_measure.Add("градус Фаренгейта", farenheit);
                    Actual_measure.Add("градус Кельвина", kelvin);

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
                    Actual_measure.Clear();
                    Actual_measure.Add("Джоуль", joule);
                    Actual_measure.Add("грамм-калория", gram_calorie);
                    Actual_measure.Add("килокалория", kcalorie);
                    Actual_measure.Add("килоджоуль", kjoule);
                    Actual_measure.Add("Ватт-час", watt_hour);
                    Actual_measure.Add("киловатт-час", kWatt_hour);

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
            m1 = Russian_measure[cbRussianFrom.Text];
            m2 = Russian_measure[cbRussianTo.Text];
            try
            {
                n = Convert.ToDouble(tbRussianFrom.Text);
            }
            catch
            {
                n = 1;
                tbRussianFrom.Text = n.ToString();
            }
            tbRussianTo.Text = (n * m1 / m2).ToString();
        }
        /// <summary>
        /// Метод кнопки замены.
        /// Меняет местами старорусские меры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRussianSwap_Click(object sender, EventArgs e)
        {
            string temp = cbRussianFrom.Text;
            cbRussianFrom.Text = cbRussianTo.Text;
            cbRussianTo.Text = temp;
        }
        /// <summary>
        /// Метод работает со списком старорусских мер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbRussianMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbRussianMeasure.Text)
            {
                #region Длина

                case "Длина":
                    Russian_measure.Clear();
                    Russian_measure.Add("миллиметр", mmeter);
                    Russian_measure.Add("метр", meter);
                    Russian_measure.Add("линия", linia);
                    Russian_measure.Add("дюйм", duim);
                    Russian_measure.Add("вершок", vershok);
                    Russian_measure.Add("ладонь", ladon);
                    Russian_measure.Add("четверть", chetvert);
                    Russian_measure.Add("аршин", arshin);
                    Russian_measure.Add("пядь", pyad);
                    Russian_measure.Add("фут", fut);
                    Russian_measure.Add("локоть", lokot);
                    Russian_measure.Add("шаг", shag);
                    Russian_measure.Add("сажень маховая", mahovaya_sagen);
                    Russian_measure.Add("сажень косая", kosaya_sagen);
                    Russian_measure.Add("сажень казённая", kazennaya_sagen);
                    Russian_measure.Add("шест", shest);
                    Russian_measure.Add("цепь", cep);
                    Russian_measure.Add("верста", versta);
                    Russian_measure.Add("русская миля", rus_mile);
                    Russian_measure.Add("поприще", poprische);

                    cbRussianFrom.Items.Clear();
                    cbRussianFrom.Items.Add("миллиметр");
                    cbRussianFrom.Items.Add("метр");
                    cbRussianFrom.Items.Add("линия");
                    cbRussianFrom.Items.Add("дюйм");
                    cbRussianFrom.Items.Add("вершок");
                    cbRussianFrom.Items.Add("ладонь");
                    cbRussianFrom.Items.Add("четверть");
                    cbRussianFrom.Items.Add("аршин");
                    cbRussianFrom.Items.Add("пядь");
                    cbRussianFrom.Items.Add("фут");
                    cbRussianFrom.Items.Add("локоть");
                    cbRussianFrom.Items.Add("шаг");
                    cbRussianFrom.Items.Add("сажень маховая");
                    cbRussianFrom.Items.Add("сажень косая");
                    cbRussianFrom.Items.Add("сажень казённая");
                    cbRussianFrom.Items.Add("шест");
                    cbRussianFrom.Items.Add("цепь");
                    cbRussianFrom.Items.Add("верста");
                    cbRussianFrom.Items.Add("русская миля");
                    cbRussianFrom.Items.Add("поприще");

                    cbRussianTo.Items.Clear();
                    cbRussianTo.Items.Add("миллиметр");
                    cbRussianTo.Items.Add("метр");
                    cbRussianTo.Items.Add("линия");
                    cbRussianTo.Items.Add("дюйм");
                    cbRussianTo.Items.Add("вершок");
                    cbRussianTo.Items.Add("ладонь");
                    cbRussianTo.Items.Add("четверть");
                    cbRussianTo.Items.Add("аршин");
                    cbRussianTo.Items.Add("пядь");
                    cbRussianTo.Items.Add("фут");
                    cbRussianTo.Items.Add("локоть");
                    cbRussianTo.Items.Add("шаг");
                    cbRussianTo.Items.Add("сажень маховая");
                    cbRussianTo.Items.Add("сажень косая");
                    cbRussianTo.Items.Add("сажень казённая");
                    cbRussianTo.Items.Add("шест");
                    cbRussianTo.Items.Add("цепь");
                    cbRussianTo.Items.Add("верста");
                    cbRussianTo.Items.Add("русская миля");
                    cbRussianTo.Items.Add("поприще");

                    cbRussianFrom.Text = "метр";
                    cbRussianTo.Text = "миллиметр";
                    break;

                #endregion

                #region Масса

                case "Масса":
                    Russian_measure.Clear();
                    Russian_measure.Add("грамм", gram);
                    Russian_measure.Add("килограмм", kgram);
                    Russian_measure.Add("доля", dolya);
                    Russian_measure.Add("золотник", zolotnik);
                    Russian_measure.Add("лот", lot);
                    Russian_measure.Add("гривенка", grivenka);
                    Russian_measure.Add("фунт", funt);
                    Russian_measure.Add("гривна", grivna);
                    Russian_measure.Add("батман", batman);
                    Russian_measure.Add("пуд", pud);
                    Russian_measure.Add("полпуда", polpuda);
                    Russian_measure.Add("кантар", kantar);
                    Russian_measure.Add("берковец", berkovec);
                    Russian_measure.Add("четверть вощаная", chetvert_voschanaya);
                    Russian_measure.Add("ласт", last);

                    cbRussianFrom.Items.Clear();
                    cbRussianFrom.Items.Add("грамм");
                    cbRussianFrom.Items.Add("килограмм");
                    cbRussianFrom.Items.Add("доля");
                    cbRussianFrom.Items.Add("золотник");
                    cbRussianFrom.Items.Add("лот");
                    cbRussianFrom.Items.Add("гривенка");
                    cbRussianFrom.Items.Add("фунт");
                    cbRussianFrom.Items.Add("гривна");
                    cbRussianFrom.Items.Add("батман");
                    cbRussianFrom.Items.Add("пуд");
                    cbRussianFrom.Items.Add("полпуда");
                    cbRussianFrom.Items.Add("кантар");
                    cbRussianFrom.Items.Add("берковец");
                    cbRussianFrom.Items.Add("четверть вощаная");
                    cbRussianFrom.Items.Add("ласт");

                    cbRussianTo.Items.Clear();
                    cbRussianTo.Items.Add("грамм");
                    cbRussianTo.Items.Add("килограмм");
                    cbRussianTo.Items.Add("доля");
                    cbRussianTo.Items.Add("золотник");
                    cbRussianTo.Items.Add("лот");
                    cbRussianTo.Items.Add("гривенка");
                    cbRussianTo.Items.Add("фунт");
                    cbRussianTo.Items.Add("гривна");
                    cbRussianTo.Items.Add("батман");
                    cbRussianTo.Items.Add("пуд");
                    cbRussianTo.Items.Add("полпуда");
                    cbRussianTo.Items.Add("кантар");
                    cbRussianTo.Items.Add("берковец");
                    cbRussianTo.Items.Add("четверть вощаная");
                    cbRussianTo.Items.Add("ласт");

                    cbRussianFrom.Text = "килограмм";
                    cbRussianTo.Text = "грамм";
                    break;

                #endregion

                #region Объём

                case "Объём":
                    Russian_measure.Clear();
                    Russian_measure.Add("кубическая сажень", cubSagen);
                    Russian_measure.Add("кубический аршин", cubArshin);
                    Russian_measure.Add("кубический вершок", cubVershok);
                    Russian_measure.Add("кубический фут", cubFut);
                    Russian_measure.Add("кубический дюйм", cubDuim);
                    Russian_measure.Add("кубическая линия", cubLinia);
                    Russian_measure.Add("кубический метр", cubMmeter);
                    Russian_measure.Add("литр", liter);
                    Russian_measure.Add("миллилитр", mliter);

                    cbRussianFrom.Items.Clear();
                    cbRussianFrom.Items.Add("кубическая сажень");
                    cbRussianFrom.Items.Add("кубический аршин");
                    cbRussianFrom.Items.Add("кубический вершок");
                    cbRussianFrom.Items.Add("кубический фут");
                    cbRussianFrom.Items.Add("кубический дюйм");
                    cbRussianFrom.Items.Add("кубическая линия");
                    cbRussianFrom.Items.Add("кубический метр");
                    cbRussianFrom.Items.Add("литр");
                    cbRussianFrom.Items.Add("миллилитр");

                    cbRussianTo.Items.Clear();
                    cbRussianTo.Items.Add("кубическая сажень");
                    cbRussianTo.Items.Add("кубический аршин");
                    cbRussianTo.Items.Add("кубический вершок");
                    cbRussianTo.Items.Add("кубический фут");
                    cbRussianTo.Items.Add("кубический дюйм");
                    cbRussianTo.Items.Add("кубическая линия");
                    cbRussianTo.Items.Add("кубический метр");
                    cbRussianTo.Items.Add("литр");
                    cbRussianTo.Items.Add("миллилитр");

                    cbRussianFrom.Text = "литр";
                    cbRussianTo.Text = "миллилитр";
                    break;

                #endregion

                #region Объём жидких тел

                case "Объём жидких тел (винные меры)":
                    Russian_measure.Clear();
                    Russian_measure.Add("шкалик", shkalik);
                    Russian_measure.Add("чарка", charka);
                    Russian_measure.Add("четушка", chetushka);
                    Russian_measure.Add("стакан", stakan);
                    Russian_measure.Add("косушка", kosushka);
                    Russian_measure.Add("бутылка водки", butilka_vodki);
                    Russian_measure.Add("бутылка вина", butilka_vina);
                    Russian_measure.Add("штоф", shtof);
                    Russian_measure.Add("гарнец", garnec);
                    Russian_measure.Add("четверть ведра", chetvert_vedra);
                    Russian_measure.Add("ведро", vedro);
                    Russian_measure.Add("корчага", korchaga);
                    Russian_measure.Add("бочка", bochka);
                    Russian_measure.Add("литр", liter);
                    Russian_measure.Add("миллилитр", mliter);

                    cbRussianFrom.Items.Clear();
                    cbRussianFrom.Items.Add("шкалик");
                    cbRussianFrom.Items.Add("чарка");
                    cbRussianFrom.Items.Add("четушка");
                    cbRussianFrom.Items.Add("стакан");
                    cbRussianFrom.Items.Add("косушка");
                    cbRussianFrom.Items.Add("бутылка водки");
                    cbRussianFrom.Items.Add("бутылка вина");
                    cbRussianFrom.Items.Add("штоф");
                    cbRussianFrom.Items.Add("гарнец");
                    cbRussianFrom.Items.Add("четверть ведра");
                    cbRussianFrom.Items.Add("ведро");
                    cbRussianFrom.Items.Add("корчага");
                    cbRussianFrom.Items.Add("бочка");
                    cbRussianFrom.Items.Add("литр");
                    cbRussianFrom.Items.Add("миллилитр");

                    cbRussianTo.Items.Clear();
                    cbRussianTo.Items.Add("шкалик");
                    cbRussianTo.Items.Add("чарка");
                    cbRussianTo.Items.Add("четушка");
                    cbRussianTo.Items.Add("стакан");
                    cbRussianTo.Items.Add("косушка");
                    cbRussianTo.Items.Add("бутылка водки");
                    cbRussianTo.Items.Add("бутылка вина");
                    cbRussianTo.Items.Add("штоф");
                    cbRussianTo.Items.Add("гарнец");
                    cbRussianTo.Items.Add("четверть ведра");
                    cbRussianTo.Items.Add("ведро");
                    cbRussianTo.Items.Add("корчага");
                    cbRussianTo.Items.Add("бочка");
                    cbRussianTo.Items.Add("литр");
                    cbRussianTo.Items.Add("миллилитр");

                    cbRussianFrom.Text = "литр";
                    cbRussianTo.Text = "миллилитр";
                    break;

                #endregion

                #region Объём сыпучих тел

                case "Объём сыпучих тел (хлебные меры)":
                    Russian_measure.Clear();
                    Russian_measure.Add("полугарнец", polugarnec);
                    Russian_measure.Add("четверка", chetverka);
                    Russian_measure.Add("получетверик", poluchetverik);
                    Russian_measure.Add("четверик", chetverik);
                    Russian_measure.Add("мера", mera);
                    Russian_measure.Add("полосьмины", polosminy);
                    Russian_measure.Add("осьмина", osmina);
                    Russian_measure.Add("четь сыпучая", chet_sip);
                    Russian_measure.Add("половник", polovnik);
                    Russian_measure.Add("кадка", kadka);
                    Russian_measure.Add("литр", liter);
                    Russian_measure.Add("миллилитр", mliter);

                    cbRussianFrom.Items.Clear();
                    cbRussianFrom.Items.Add("полугарнец");
                    cbRussianFrom.Items.Add("четверка");
                    cbRussianFrom.Items.Add("получетверик");
                    cbRussianFrom.Items.Add("четверик");
                    cbRussianFrom.Items.Add("мера");
                    cbRussianFrom.Items.Add("полосьмины");
                    cbRussianFrom.Items.Add("осьмина");
                    cbRussianFrom.Items.Add("четь сыпучая");
                    cbRussianFrom.Items.Add("половник");
                    cbRussianFrom.Items.Add("кадка");
                    cbRussianFrom.Items.Add("литр");
                    cbRussianFrom.Items.Add("миллилитр");

                    cbRussianTo.Items.Clear();
                    cbRussianTo.Items.Add("полугарнец");
                    cbRussianTo.Items.Add("четверка");
                    cbRussianTo.Items.Add("получетверик");
                    cbRussianTo.Items.Add("четверик");
                    cbRussianTo.Items.Add("мера");
                    cbRussianTo.Items.Add("полосьмины");
                    cbRussianTo.Items.Add("осьмина");
                    cbRussianTo.Items.Add("четь сыпучая");
                    cbRussianTo.Items.Add("половник");
                    cbRussianTo.Items.Add("кадка");
                    cbRussianTo.Items.Add("литр");
                    cbRussianTo.Items.Add("миллилитр");

                    cbRussianFrom.Text = "литр";
                    cbRussianTo.Text = "миллилитр";
                    break;

                #endregion

                #region Площадь

                case "Площадь":
                    Russian_measure.Clear();
                    Russian_measure.Add("квадратный сантиметр", sqCmeter);
                    Russian_measure.Add("квадратный вершок", sqVershok);
                    Russian_measure.Add("квадратный аршин", sqArshin);
                    Russian_measure.Add("квадратная сажень", sqSagen);
                    Russian_measure.Add("квадратный осьминник", osminnik);
                    Russian_measure.Add("квадратная четь", chet);
                    Russian_measure.Add("квадратная десятина", desyatina);
                    Russian_measure.Add("квадратная верста", sqVersta);
                    Russian_measure.Add("квадратный метр", sqMeter);

                    cbRussianFrom.Items.Clear();
                    cbRussianFrom.Items.Add("квадратный сантиметр");
                    cbRussianFrom.Items.Add("квадратный вершок");
                    cbRussianFrom.Items.Add("квадратный аршин");
                    cbRussianFrom.Items.Add("квадратная сажень");
                    cbRussianFrom.Items.Add("квадратный осьминник");
                    cbRussianFrom.Items.Add("квадратная четь");
                    cbRussianFrom.Items.Add("квадратная десятина");
                    cbRussianFrom.Items.Add("квадратная верста");
                    cbRussianFrom.Items.Add("квадратный метр");

                    cbRussianTo.Items.Clear();
                    cbRussianTo.Items.Add("квадратный сантиметр");
                    cbRussianTo.Items.Add("квадратный вершок");
                    cbRussianTo.Items.Add("квадратный аршин");
                    cbRussianTo.Items.Add("квадратная сажень");
                    cbRussianTo.Items.Add("квадратный осьминник");
                    cbRussianTo.Items.Add("квадратная четь");
                    cbRussianTo.Items.Add("квадратная десятина");
                    cbRussianTo.Items.Add("квадратная верста");
                    cbRussianTo.Items.Add("квадратный метр");

                    cbRussianFrom.Text = "квадратный метр";
                    cbRussianTo.Text = "квадратный сантиметр";
                    break;

                    #endregion
            }
        }


        /// <summary>
        /// Метод кнопки конвертации.
        /// Конвертирует имперские меры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImperialConvert_Click(object sender, EventArgs e)
        {
            m1 = Imperial_measure[cbImperialFrom.Text];
            m2 = Imperial_measure[cbImperialTo.Text];
            try
            {
                n = Convert.ToDouble(tbImperialFrom.Text);
            }
            catch
            {
                n = 1;
                tbImperialFrom.Text = n.ToString();
            }
            tbImperialTo.Text = (n * m1 / m2).ToString();
        }
        /// <summary>
        /// Метод кнопки замены.
        /// Меняет местами имперские меры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImperialSwap_Click(object sender, EventArgs e)
        {
            string temp = cbImperialFrom.Text;
            cbImperialFrom.Text = cbImperialTo.Text;
            cbImperialTo.Text = temp;
        }
        /// <summary>
        /// Метод работает со списком имперских мер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbImperialMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Длина
            //Масса(американские)
            //Масса(британские)
            //Объём жидких тел(американские)
            //Объём жидких тел(британские)
            //Объём сыпучих тел(американские)
            //Объём сыпучих тел(британские)
            //Площадь
        }


        /// <summary>
        /// Метод конвертации.
        /// Конвертирует японские меры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJapaneseConvert_Click(object sender, EventArgs e)
        {
            m1 = Japanese_measure[cbJapaneseFrom.Text];
            m2 = Japanese_measure[cbJapaneseTo.Text];
            try
            {
                n = Convert.ToDouble(tbJapaneseFrom.Text);
            }
            catch
            {
                n = 1;
                tbJapaneseFrom.Text = n.ToString();
            }
            tbJapaneseTo.Text = (n * m1 / m2).ToString();
        }
        /// <summary>
        /// Метод кнопки замены.
        /// Меняет местами японские меры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJapaneseSwap_Click(object sender, EventArgs e)
        {
            string temp = cbJapaneseFrom.Text;
            cbJapaneseFrom.Text = cbJapaneseTo.Text;
            cbJapaneseTo.Text = temp;
        }
        /// <summary>
        /// Метод работает со списком японских мер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbJapaneseMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbJapaneseMeasure.Text)
            {
                #region Длина

                case "Длина":
                    Japanese_measure.Clear();
                    Japanese_measure.Add("бу", bu);
                    Japanese_measure.Add("сун", sun);
                    Japanese_measure.Add("сяку", syaku);
                    Japanese_measure.Add("кэн", ken);
                    Japanese_measure.Add("хиро", hiro);
                    Japanese_measure.Add("дзё", dze);
                    Japanese_measure.Add("те", te);
                    Japanese_measure.Add("ри", ri);
                    Japanese_measure.Add("метр", meter);
                    Japanese_measure.Add("миллиметр", mmeter);

                    cbJapaneseFrom.Items.Clear();
                    cbJapaneseFrom.Items.Add("бу");
                    cbJapaneseFrom.Items.Add("сун");
                    cbJapaneseFrom.Items.Add("сяку");
                    cbJapaneseFrom.Items.Add("кэн");
                    cbJapaneseFrom.Items.Add("хиро");
                    cbJapaneseFrom.Items.Add("дзё");
                    cbJapaneseFrom.Items.Add("те");
                    cbJapaneseFrom.Items.Add("ри");
                    cbJapaneseFrom.Items.Add("метр");
                    cbJapaneseFrom.Items.Add("миллиметр");

                    cbJapaneseTo.Items.Clear();
                    cbJapaneseTo.Items.Add("бу");
                    cbJapaneseTo.Items.Add("сун");
                    cbJapaneseTo.Items.Add("сяку");
                    cbJapaneseTo.Items.Add("кэн");
                    cbJapaneseTo.Items.Add("хиро");
                    cbJapaneseTo.Items.Add("дзё");
                    cbJapaneseTo.Items.Add("те");
                    cbJapaneseTo.Items.Add("ри");
                    cbJapaneseTo.Items.Add("метр");
                    cbJapaneseTo.Items.Add("миллиметр");

                    cbJapaneseFrom.Text = "метр";
                    cbJapaneseTo.Text = "миллиметр";
                    break;

                #endregion

                #region Масса

                case "Масса":
                    Japanese_measure.Clear();
                    Japanese_measure.Add("бу", bu);
                    Japanese_measure.Add("сун", sun);
                    Japanese_measure.Add("сяку", syaku);
                    Japanese_measure.Add("кэн", ken);
                    Japanese_measure.Add("хиро", hiro);
                    Japanese_measure.Add("дзё", dze);
                    Japanese_measure.Add("те", te);
                    Japanese_measure.Add("ри", ri);
                    Japanese_measure.Add("метр", meter);
                    Japanese_measure.Add("миллиметр", mmeter);

                    cbJapaneseFrom.Items.Clear();
                    cbJapaneseFrom.Items.Add("бу");
                    cbJapaneseFrom.Items.Add("сун");
                    cbJapaneseFrom.Items.Add("сяку");
                    cbJapaneseFrom.Items.Add("кэн");
                    cbJapaneseFrom.Items.Add("хиро");
                    cbJapaneseFrom.Items.Add("дзё");
                    cbJapaneseFrom.Items.Add("те");
                    cbJapaneseFrom.Items.Add("ри");
                    cbJapaneseFrom.Items.Add("метр");
                    cbJapaneseFrom.Items.Add("миллиметр");

                    cbJapaneseTo.Items.Clear();
                    cbJapaneseTo.Items.Add("бу");
                    cbJapaneseTo.Items.Add("сун");
                    cbJapaneseTo.Items.Add("сяку");
                    cbJapaneseTo.Items.Add("кэн");
                    cbJapaneseTo.Items.Add("хиро");
                    cbJapaneseTo.Items.Add("дзё");
                    cbJapaneseTo.Items.Add("те");
                    cbJapaneseTo.Items.Add("ри");
                    cbJapaneseTo.Items.Add("метр");
                    cbJapaneseTo.Items.Add("миллиметр");

                    cbJapaneseFrom.Text = "метр";
                    cbJapaneseTo.Text = "миллиметр";
                    break;

                    #endregion
            }

            //Длина
            //Масса
            //Объём
            //Площадь
        }
    }
}
