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
        //1 лига(league, Великобритания и США) = 3 милям = 24 фурлонгам = 4828,032 метра.
        //1 морская миля(nautical mile, Великобритания) = 10 кабельтовым = 1,853257 км
        //1 морская миля(nautical mile, США, с 1 июля 1954) = 1,852 км
        //1 кабельтов(cable, Великобритания) = 185,3182 м
        //1 кабельтов(cable, США) = 185,3249 м
        //1 уставная миля(statute mile) = 8 фурлонгам = 5 280 футам = 1609,344 м
        //1 фурлонг(или фарлонг) (furlong) = 10 чейнам = 201,168 м
        //1 чейн(chain) = 4 родам = 100 линкам = 20,1168 м
        //1 род(rod, pole, perch, поль, перч) = 5,5 ярдам = 5,0292 м
        //1 ярд(yard) = 3 футам = 0,9144 м
        //1 фут(foot) = 3 хэндам = 12 дюймам = 0,3048 м
        //1 хэнд(hand) = 4 дюймам = 10,16 см
        //1 барликорн(barleycorn) = 1/3 дюйма = 8,4667 мм
        //1 дюйм(inch) = 12 линиям = 72 точкам = 1000 милам = 2,54 см
        //1 линия(line) = 6 точкам = 2,1167 мм
        //1 точка(point) = 0,353 мм
        //1 мил(mil) = 0,0254 мм

        //  имперские меры массы (американские)
        //1 квинтал = 1 хандредвейт = 100 фунтов = 1 центал = 45,36 кг
        //1 слаг = 14,6 кг
        //1 квартер = 1/4 хандредвейта = 25 фунтов = 11,34 кг
        //1 стоун = 14 фунтов = 6,35 кг

        //  имперские меры массы(британские)
        //1 тонна большая(длинная) (long ton) = 20 хандредвейтам(квинталам) = 2240 фунтов = 1016,05 кг
        //1 тонна малая(короткая) (short ton, США, Канада и др.) = 20 хандредвейтам малым(центалам) = 2000 фунтов = 32000 унций = 907,185 кг
        //1 тонна метрическая(metric ton) = 2204,6 фунта = 0,984 большой тонны = 1000 кг
        //1 киль = 8 челдронам =424 хандредвейтам =47488 фунтов =21540,16 кг
        //1 челдрон для угля(chaldron) = 1/8 киля = 53 хандредвейтам = 5936 фунтов = 2692,52 кг
        //1 вей = 2—3 хандредвейтам = 101,6—152,4 кг
        //1 квинтал(quintal) = 1 большой хандредвейт(long hundredweight) = 112 фунтам = 50,802 кг
        //1 центал(центнер) = 1 малый хандредвейт(short hundredweight) = 100 фунтам = 45,36 кг
        //1 слаг = 14,6 кг
        //1 тод(tod, «груз») = 1 квартеру длинному = 1 / 4 хандредвейта большого = 28 фунтам = 2 стоунам = 12,7 кг
        //1 квартер короткий(short quarter, «четверть») = 1/4 хандредвейта малого = 25 фунтам = 11,34 кг
        //1 Стоун(stone, «камень») = 1/2 квартера большого = 1 / 8 хандредвейта большого = 14 фунтам = 6,350293 кг
        //1 клов(уст.) = 1/2 стоуна = 1/16 хандредвейта = 7 фунтов = 3,175 кг(ранее величина клова составляла 6,25—8 фунтов = 2,834—3,629 кг)
        //1 квартерн = 1/4 стоуна = 3,5 фунта = 1,588 кг
        //1 фунт(pound, лат.pondus, сокр.lb) = 16 унциям = 7000 гранов = 453,59237 г
        //1 унция(ounce, oz) = 16 драхмам = 437,5 гранам = 28,349523125 г
        //1 драхма(dram)= 1/16 унции = 27,34375 гран = 1,7718451953125 г
        //1 гран(grain, лат.granum, сокр.gr) (до 1985 года) = 64,79891 мг

        //  имперские меры объёма жидких тел(американские)
        //1 баррель = 31—42 галлонов = 140,6—190,9 литров
        //1 баррель для жидкости = 31,5 галлонов[источник не указан 2501 день] = 119,2 л(дм³)
        //1 баррель для сырой нефти = 42,2 галлонов = 158,97 л(дм³)
        //1 галлон амер. = 0,833 галлона англ. = 3,784 л (дм³)
        //1 кварта амер. = 0,833 кварты англ. = 0,946 л (дм³)
        //1 пинта жидкая амер. = 1/8 амер.галлона = 0,473 л(дм³)
        //1 джилл(гилл) = 1/4 пинты амер. = 0,118 л (дм³)
        //1 унция жидкая(fl oz) = 1/128 галлона = 1,041 унции англ. = 2 ст.ложки = 1 / 8 стакана = 29,56 мл (см³)
        //1 рюмка = 16 жидк.драхмам = 2 унции = 1/4 стакана = 59,12 мл
        //1 драхма жидкая = 1 / 8 жидкой унции = 3,6966 мл
        //1 столовая ложка(ст.л.) = 3 чайных ложки(ч.л.) = 4 жидк.драхмы = 1/2 жидк.унции = 14,8 мл
        //1 чайная ложка(ч.л.) = 1/3 столовой ложки(ст.л.) = 1 1/3 жидк.драхмы = 4,9 мл
        //1 чайная ложка = 60 капель(0,08 мл)
        //1 кофейная ложка = 1 / 2 ч.л. = 2,45 мл
        //1 ложечка для приправ = 1/4 ч.л. = 1,225 мл
        //1 миним = 1/60 жидк.драхмы = 0,06 мл

        //  имперские меры объёма жидких тел(британские)
        //1 бат(«торец») = 108—140 галлонам = 490,97—636,44 л(дм³, около 2 хогзхедов)
        //1 бат пива = 108 галлонов = 17,339 фут³ = 490,97 л
        //1 пайп = 105 галлонам = 2 хогзхеда = 477,34 л(дм³)
        //1 хогсхед(большая бочка, «кабанья голова») = 52,5 имперских галлона = 238,67 л(дм³)
        //1 баррель = 31—42 галлонам = 140,9—190,9 л(дм³)
        //1 баррель для жидкости(пива) (Баррель (единица объёма)) = 36 имперским галлонам = 163,65 л(дм³)
        //1 баррель для сырой нефти = 34,97 галлонам = 158,988 л(дм³)
        //1 килдеркин = 1/2 барреля = 2 феркинам = 16—18 галлонам = 72,7—81,8 л(дм³)
        //1 феркин(fir; «маленький бочонок») = 1/6 хогсхеда = 1/4 барреля = 1/2 килдеркина = 8—9 галлонам = 36 квартам = 36,3—40,9 л(дм³)
        //1 имперский галлон = 4 квартам = 8 пинтам = 32 джилла = 160 жидк.унциям = 4,546 л(дм³)
        //1 потл = 1/2 импер.галлона = 2 квартам = 2,27 л(дм³)
        //1 кварта = 1/4 импер.галлона = 2 пинтам = 1,1365 л(дм³)
        //1 бутылка молока = 1 кварте = 946,36 мл
        //1 бутылка виски = 1 пятой = 757,1 мл
        //1 бутылка шампанского = 2 / 3 кварты = 630,91 мл(французское шампанское, 750 мл)
        //1 бутылка вина = 750 мл = 25,3605 жидких унций
        //1 бакет(«ковш») неофициальная единица = 5 импер.галлонам = 18,927 л
        //1 филет = 1/2 бутылки шампанского = 375 мл
        //1 пинта = 1/8 импер.галлона = 1/2 кварты = 4 джиллам(гиллам) = 20 унциям жидким = 34,678 дюймам³ = 0,568 261 л(дм³)
        //1 джилл(гилл) = 1/4 пинты = 5 жидк.унциям = 8,670 дюймов³ = 0,142 л(дм³)
        //1 чашка для завтрака = 1/2 пинты = 10 жидк.унциям = 17,339 дюймам³ = 1,2 ам.чашке = 284 мл
        //1 столовая ложка = 3 чайным ложкам = 4 жидк.драхмы = 1/2 жидкой унции = 14,2 мл
        //1 чайная ложка = 1 / 3 столовой ложки = 1 1/3 жидк.драхмы = 4,7 мл(из другого источника: = 1/8 жидк.унции = 3,55 мл (традиц.), мед.и кухня = 5 мл)
        //1 винная рюмка, бокал = 16 жидк.драхмам = 2 жидк.унциям = 56,8 мл; по другим данным равна 2,5 жидк.унциям = 5 столовых ложек = 1 / 2 джилла = 71 мл
        //1 унция жидкая(fl oz) = 1/20 пинты = 1/5 джилла = 8 жидк.драхмам = 24 жидк.скрупулам = 1,733 871 дюймам³ = 28,413063 мл(см³)
        //1 драхма жидкая(1878 — 1 февраля 1971 года) = 3 жидк.скрупулам = 1/8 жидк.унции = 60 минимам = 0,96 ам.жидк.драхмам = 0,216734 дюйма³ = 3,551633 мл
        //1 жидк.скрупул аптек. (1878 — 1 февраля 1971 года) = 1/3 жидк.драхмы = 1/24 жидк.унции = 20 минимам = 19,2 ам.минима = 1,18388 мл
        //1 миним аптек. (1878 — 1 февраля 1971 года) = 1/60 жидк.драхмы = 1/20 жидк.скрупула = 0,96 ам.минима = 0,05919 мл

        //  имперские меры объёма сыпучих тел(американские)
        //1 квартер = 2 коума = 64 галлона = 8 бушелей = 282 л
        //1 коум = 4 бушеля = 32 галлона = 141 л
        //1 баррель для сыпучих тел = 117,3—158,98 л
        //1 бушель = 0,9689 англ.бушеля = 35,2393 л; по другим данным равен 35,23907017 л = 9,309177489 американских галлонов
        //1 пек амер. = 0,9689 пека англ. = 8,81 л
        //1 галлон = 4,405 л
        //1 кварта амер. = 1,101 л
        //1 пинта сухая амер. = 1 / 64 бушеля = 1 / 8 галлона = 0,551 литра
        //1 унция (uncia, oz) = 16 драхмам = 437,5 грана = 28,35 г

        //  имперские меры объёма сыпучих тел(британские)
        //1 челдрон(челдер; chd; «котел, большой чайник») = 32—36 бушелям = 1268—1309 л(дм³)
        //1 квартер = 2 коумам = 64 галлонам = 8 бушелям = 290,93 л(дм³)
        //1 коум = 4 бушелям = 32 галлонам = 145,475 л(дм³)
        //1 баррель для сыпучих тел = 36—40 галлонам = 163,6—181,7 л(дм³)
        //1 сак(«мешок») = 3 бушелям = 109,05 л(дм³)
        //1 страйк = 2 бушелям = 72,73 л(дм³)
        //1 бушель = 4 пекам = 8 галлонам = 32 сух.квартам = 64 сух.пинтам = 1,032 ам.бушеля = 2219,36 дюймов³ = 36,36872 л(дм³)
        //1 пек = 2 галлонам = 1,032 пека ам. = 9,092 л (дм³)
        //1 галлон = 4 квартам = 8 пинтам = 4,546 л(дм³)
        //1 кварта = 2 пинтам = 1,032 кварты ам. = 1,136 л (дм³)
        //1 квартерн сух. (четверть) = 1/4 пека = 2 кварты = 2,2731 л
        //1 пинта = 0,568261 л(дм³)

        //  имперские меры площади
        //1 миля² (square mile) = 640 акрам = 2,59 км²
        //1 акр(acre) = 4 рудам = 4046,86 м²
        //1 руд(rood) = 40 род² = 1011,71 м²
        //1 род² (square rod) (поль², перч²) = 30,25 ярд² = 25,293 м²
        //1 ярд² (square yard) = 9 фут² = 0,83613 м²
        //1 фут² (square foot) = 144 дюйм² = 929,03 см²
        //1 дюйм² (square inch) = 6,4516 см²

        #endregion

        #region японские меры

        //  японские меры длины
        //бу 分		            1∕330	3,03 мм U+5206
        //сун 寸	10 бу	        1∕33	3,03 см U+5BF8
        //сяку    尺	10 сун	    10∕33	30,3 см U+5C3A
        //кэн 間	6 сяку	        20∕11	1,81 м U+9593
        //хиро 尋	6 сяку	    20/11	1,81 м U+5C0B
        //дзё 丈	10 сяку	        100∕33	3,03 м U+4E08
        //тё 町	36 дзё = 60 кэн	1200∕11	109 м U+753A
        //ри  里	36 тё	        43200∕11	3927 м U+91CC

        //  японские меры массы
        //1 фун(分)         = 375 мг
        //1 моммэ(匁)       = 10 фунам	= 3,75 г
        //1 кин(斤)         = 160 моммэ	= 600 г
        //1 кан(貫, 貫目)   = 1000 моммэ	= 3,75 кг

        //  японские меры объёма
        //го 合		        ≈ 0,18039	U+5408
        //сё 升	10 го	    ≈ 1,8039	U+5347
        //то 斗	10 сё	    ≈ 18,039	U+6597
        //коку 石	10 то	≈ 180,39	U+77F3

        //  японские меры площади
        //1 го 合       = 1 / 10 цубо	= 33,058 дм²
        //1 дзё 畳	    ≈ 1/2 цубо	≈ 1,65 м²
        //1 цубо 坪     = 10 го = 1 кэн²	= 3,3058 м² (400/121 м²)
        //1 унэ 畝      = 30 цубо	= 99,174 м²
        //1 тан 段, 反  = 10 унэ	= 991,736 м² ≈ 9,92 а
        //1 тё 町       = 10 танам	= 9917,36 м² ≈ 0,992 га

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

        }
    }
}
