﻿namespace Converter
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpActual = new System.Windows.Forms.TabPage();
            this.cbActualMeasure = new System.Windows.Forms.ComboBox();
            this.tbActualTo = new System.Windows.Forms.TextBox();
            this.tbActualFrom = new System.Windows.Forms.TextBox();
            this.cbActualTo = new System.Windows.Forms.ComboBox();
            this.cbActualFrom = new System.Windows.Forms.ComboBox();
            this.btnActualSwap = new System.Windows.Forms.Button();
            this.btnActualConvert = new System.Windows.Forms.Button();
            this.tpRussian = new System.Windows.Forms.TabPage();
            this.cbRussianMeasure = new System.Windows.Forms.ComboBox();
            this.tbRussianTo = new System.Windows.Forms.TextBox();
            this.tbRussianFrom = new System.Windows.Forms.TextBox();
            this.cbRussianTo = new System.Windows.Forms.ComboBox();
            this.cbRussianFrom = new System.Windows.Forms.ComboBox();
            this.btnRussianSwap = new System.Windows.Forms.Button();
            this.btnRussianConvert = new System.Windows.Forms.Button();
            this.tpImperial = new System.Windows.Forms.TabPage();
            this.cbImperialMeasure = new System.Windows.Forms.ComboBox();
            this.tbImperialTo = new System.Windows.Forms.TextBox();
            this.tbImperialFrom = new System.Windows.Forms.TextBox();
            this.cbImperialTo = new System.Windows.Forms.ComboBox();
            this.cbImperialFrom = new System.Windows.Forms.ComboBox();
            this.btnImperialSwap = new System.Windows.Forms.Button();
            this.btnImperialConvert = new System.Windows.Forms.Button();
            this.tpJapanese = new System.Windows.Forms.TabPage();
            this.cbJapaneseMeasure = new System.Windows.Forms.ComboBox();
            this.tbJapaneseTo = new System.Windows.Forms.TextBox();
            this.tbJapaneseFrom = new System.Windows.Forms.TextBox();
            this.cbJapaneseTo = new System.Windows.Forms.ComboBox();
            this.cbJapaneseFrom = new System.Windows.Forms.ComboBox();
            this.btnJapaneseSwap = new System.Windows.Forms.Button();
            this.btnJapaneseConvert = new System.Windows.Forms.Button();
            this.tpAboutProgram = new System.Windows.Forms.TabPage();
            this.tbAboutProgram = new System.Windows.Forms.TextBox();
            this.tbPrefix = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tpActual.SuspendLayout();
            this.tpRussian.SuspendLayout();
            this.tpImperial.SuspendLayout();
            this.tpJapanese.SuspendLayout();
            this.tpAboutProgram.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpActual);
            this.tabControl.Controls.Add(this.tpRussian);
            this.tabControl.Controls.Add(this.tpImperial);
            this.tabControl.Controls.Add(this.tpJapanese);
            this.tabControl.Controls.Add(this.tpAboutProgram);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(384, 362);
            this.tabControl.TabIndex = 7;
            // 
            // tpActual
            // 
            this.tpActual.Controls.Add(this.cbActualMeasure);
            this.tpActual.Controls.Add(this.tbActualTo);
            this.tpActual.Controls.Add(this.tbActualFrom);
            this.tpActual.Controls.Add(this.cbActualTo);
            this.tpActual.Controls.Add(this.cbActualFrom);
            this.tpActual.Controls.Add(this.btnActualSwap);
            this.tpActual.Controls.Add(this.btnActualConvert);
            this.tpActual.Location = new System.Drawing.Point(4, 22);
            this.tpActual.Name = "tpActual";
            this.tpActual.Padding = new System.Windows.Forms.Padding(3);
            this.tpActual.Size = new System.Drawing.Size(376, 336);
            this.tpActual.TabIndex = 0;
            this.tpActual.Text = "Современные";
            this.tpActual.UseVisualStyleBackColor = true;
            // 
            // cbActualMeasure
            // 
            this.cbActualMeasure.FormattingEnabled = true;
            this.cbActualMeasure.Items.AddRange(new object[] {
            "Время",
            "Давление",
            "Длина",
            "Информация",
            "Масса",
            "Объём",
            "Площадь",
            "Скорость",
            "Температура",
            "Энергия"});
            this.cbActualMeasure.Location = new System.Drawing.Point(125, 73);
            this.cbActualMeasure.MaxDropDownItems = 12;
            this.cbActualMeasure.Name = "cbActualMeasure";
            this.cbActualMeasure.Size = new System.Drawing.Size(121, 21);
            this.cbActualMeasure.TabIndex = 6;
            this.cbActualMeasure.Text = "Длина";
            this.cbActualMeasure.SelectedIndexChanged += new System.EventHandler(this.cbActualMeasure_SelectedIndexChanged);
            // 
            // tbActualTo
            // 
            this.tbActualTo.Location = new System.Drawing.Point(248, 200);
            this.tbActualTo.Name = "tbActualTo";
            this.tbActualTo.ReadOnly = true;
            this.tbActualTo.ShortcutsEnabled = false;
            this.tbActualTo.Size = new System.Drawing.Size(100, 20);
            this.tbActualTo.TabIndex = 5;
            this.tbActualTo.TabStop = false;
            // 
            // tbActualFrom
            // 
            this.tbActualFrom.Location = new System.Drawing.Point(28, 203);
            this.tbActualFrom.Name = "tbActualFrom";
            this.tbActualFrom.Size = new System.Drawing.Size(100, 20);
            this.tbActualFrom.TabIndex = 4;
            this.tbActualFrom.Text = "1";
            this.tbActualFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbActualTo
            // 
            this.cbActualTo.FormattingEnabled = true;
            this.cbActualTo.Items.AddRange(new object[] {
            "микрометр",
            "миллиметр",
            "сантиметр",
            "дюйм",
            "фут",
            "ярд",
            "метр",
            "километр",
            "миля",
            "морская миля"});
            this.cbActualTo.Location = new System.Drawing.Point(248, 130);
            this.cbActualTo.MaxDropDownItems = 12;
            this.cbActualTo.Name = "cbActualTo";
            this.cbActualTo.Size = new System.Drawing.Size(121, 21);
            this.cbActualTo.TabIndex = 3;
            this.cbActualTo.Text = "миллиметр";
            // 
            // cbActualFrom
            // 
            this.cbActualFrom.FormattingEnabled = true;
            this.cbActualFrom.Items.AddRange(new object[] {
            "микрометр",
            "миллиметр",
            "сантиметр",
            "дюйм",
            "дециметр",
            "фут",
            "ярд",
            "метр",
            "километр",
            "миля",
            "морская миля"});
            this.cbActualFrom.Location = new System.Drawing.Point(7, 130);
            this.cbActualFrom.MaxDropDownItems = 12;
            this.cbActualFrom.Name = "cbActualFrom";
            this.cbActualFrom.Size = new System.Drawing.Size(121, 21);
            this.cbActualFrom.TabIndex = 2;
            this.cbActualFrom.Text = "метр";
            // 
            // btnActualSwap
            // 
            this.btnActualSwap.Location = new System.Drawing.Point(150, 130);
            this.btnActualSwap.Name = "btnActualSwap";
            this.btnActualSwap.Size = new System.Drawing.Size(75, 23);
            this.btnActualSwap.TabIndex = 1;
            this.btnActualSwap.Text = "swap";
            this.btnActualSwap.UseVisualStyleBackColor = true;
            this.btnActualSwap.Click += new System.EventHandler(this.btnActualSwap_Click);
            // 
            // btnActualConvert
            // 
            this.btnActualConvert.Location = new System.Drawing.Point(150, 200);
            this.btnActualConvert.Name = "btnActualConvert";
            this.btnActualConvert.Size = new System.Drawing.Size(75, 23);
            this.btnActualConvert.TabIndex = 0;
            this.btnActualConvert.Text = "convert";
            this.btnActualConvert.UseVisualStyleBackColor = true;
            this.btnActualConvert.Click += new System.EventHandler(this.btnActualConvert_Click);
            // 
            // tpRussian
            // 
            this.tpRussian.Controls.Add(this.cbRussianMeasure);
            this.tpRussian.Controls.Add(this.tbRussianTo);
            this.tpRussian.Controls.Add(this.tbRussianFrom);
            this.tpRussian.Controls.Add(this.cbRussianTo);
            this.tpRussian.Controls.Add(this.cbRussianFrom);
            this.tpRussian.Controls.Add(this.btnRussianSwap);
            this.tpRussian.Controls.Add(this.btnRussianConvert);
            this.tpRussian.Location = new System.Drawing.Point(4, 22);
            this.tpRussian.Name = "tpRussian";
            this.tpRussian.Padding = new System.Windows.Forms.Padding(3);
            this.tpRussian.Size = new System.Drawing.Size(376, 336);
            this.tpRussian.TabIndex = 1;
            this.tpRussian.Text = "Старорусские";
            this.tpRussian.UseVisualStyleBackColor = true;
            // 
            // cbRussianMeasure
            // 
            this.cbRussianMeasure.FormattingEnabled = true;
            this.cbRussianMeasure.Items.AddRange(new object[] {
            "Длина",
            "Масса",
            "Объём",
            "Объём жидких тел (винные меры)",
            "Объём сыпучих тел (хлебные меры)",
            "Площадь"});
            this.cbRussianMeasure.Location = new System.Drawing.Point(93, 54);
            this.cbRussianMeasure.Name = "cbRussianMeasure";
            this.cbRussianMeasure.Size = new System.Drawing.Size(197, 21);
            this.cbRussianMeasure.TabIndex = 13;
            this.cbRussianMeasure.Text = "Длина";
            this.cbRussianMeasure.SelectedIndexChanged += new System.EventHandler(this.cbRussianMeasure_SelectedIndexChanged);
            // 
            // tbRussianTo
            // 
            this.tbRussianTo.Location = new System.Drawing.Point(268, 203);
            this.tbRussianTo.Name = "tbRussianTo";
            this.tbRussianTo.ReadOnly = true;
            this.tbRussianTo.ShortcutsEnabled = false;
            this.tbRussianTo.Size = new System.Drawing.Size(100, 20);
            this.tbRussianTo.TabIndex = 12;
            this.tbRussianTo.TabStop = false;
            // 
            // tbRussianFrom
            // 
            this.tbRussianFrom.Location = new System.Drawing.Point(6, 203);
            this.tbRussianFrom.Name = "tbRussianFrom";
            this.tbRussianFrom.Size = new System.Drawing.Size(100, 20);
            this.tbRussianFrom.TabIndex = 11;
            this.tbRussianFrom.Text = "1";
            this.tbRussianFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbRussianTo
            // 
            this.cbRussianTo.FormattingEnabled = true;
            this.cbRussianTo.Items.AddRange(new object[] {
            "миллиметр",
            "метр",
            "линия",
            "дюйм",
            "вершок",
            "ладонь",
            "четверть",
            "аршин",
            "пядь",
            "фут",
            "локоть",
            "шаг",
            "сажень маховая",
            "сажень косая",
            "сажень казённая",
            "шест",
            "цепь",
            "верста",
            "русская миля",
            "поприще"});
            this.cbRussianTo.Location = new System.Drawing.Point(247, 130);
            this.cbRussianTo.Name = "cbRussianTo";
            this.cbRussianTo.Size = new System.Drawing.Size(121, 21);
            this.cbRussianTo.TabIndex = 10;
            this.cbRussianTo.Text = "миллиметр";
            // 
            // cbRussianFrom
            // 
            this.cbRussianFrom.FormattingEnabled = true;
            this.cbRussianFrom.Items.AddRange(new object[] {
            "миллиметр",
            "метр",
            "линия",
            "дюйм",
            "вершок",
            "ладонь",
            "четверть",
            "аршин",
            "пядь",
            "фут",
            "локоть",
            "шаг",
            "сажень маховая",
            "сажень косая",
            "сажень казённая",
            "шест",
            "цепь",
            "верста",
            "русская миля",
            "поприще"});
            this.cbRussianFrom.Location = new System.Drawing.Point(6, 130);
            this.cbRussianFrom.Name = "cbRussianFrom";
            this.cbRussianFrom.Size = new System.Drawing.Size(121, 21);
            this.cbRussianFrom.TabIndex = 9;
            this.cbRussianFrom.Text = "метр";
            // 
            // btnRussianSwap
            // 
            this.btnRussianSwap.Location = new System.Drawing.Point(149, 130);
            this.btnRussianSwap.Name = "btnRussianSwap";
            this.btnRussianSwap.Size = new System.Drawing.Size(75, 23);
            this.btnRussianSwap.TabIndex = 8;
            this.btnRussianSwap.Text = "swap";
            this.btnRussianSwap.UseVisualStyleBackColor = true;
            this.btnRussianSwap.Click += new System.EventHandler(this.btnRussianSwap_Click);
            // 
            // btnRussianConvert
            // 
            this.btnRussianConvert.Location = new System.Drawing.Point(149, 200);
            this.btnRussianConvert.Name = "btnRussianConvert";
            this.btnRussianConvert.Size = new System.Drawing.Size(75, 23);
            this.btnRussianConvert.TabIndex = 7;
            this.btnRussianConvert.Text = "convert";
            this.btnRussianConvert.UseVisualStyleBackColor = true;
            this.btnRussianConvert.Click += new System.EventHandler(this.btnRussianConvert_Click);
            // 
            // tpImperial
            // 
            this.tpImperial.Controls.Add(this.cbImperialMeasure);
            this.tpImperial.Controls.Add(this.tbImperialTo);
            this.tpImperial.Controls.Add(this.tbImperialFrom);
            this.tpImperial.Controls.Add(this.cbImperialTo);
            this.tpImperial.Controls.Add(this.cbImperialFrom);
            this.tpImperial.Controls.Add(this.btnImperialSwap);
            this.tpImperial.Controls.Add(this.btnImperialConvert);
            this.tpImperial.Location = new System.Drawing.Point(4, 22);
            this.tpImperial.Name = "tpImperial";
            this.tpImperial.Size = new System.Drawing.Size(376, 336);
            this.tpImperial.TabIndex = 2;
            this.tpImperial.Text = "Имперские";
            this.tpImperial.UseVisualStyleBackColor = true;
            // 
            // cbImperialMeasure
            // 
            this.cbImperialMeasure.FormattingEnabled = true;
            this.cbImperialMeasure.Items.AddRange(new object[] {
            "Длина",
            "Масса (американские)",
            "Масса (британские)",
            "Объём жидких тел (американские)",
            "Объём жидких тел (британские)",
            "Объём сыпучих тел (американские)",
            "Объём сыпучих тел (британские)",
            "Площадь"});
            this.cbImperialMeasure.Location = new System.Drawing.Point(96, 63);
            this.cbImperialMeasure.Name = "cbImperialMeasure";
            this.cbImperialMeasure.Size = new System.Drawing.Size(182, 21);
            this.cbImperialMeasure.TabIndex = 13;
            this.cbImperialMeasure.Text = "Длина";
            this.cbImperialMeasure.SelectedIndexChanged += new System.EventHandler(this.cbImperialMeasure_SelectedIndexChanged);
            // 
            // tbImperialTo
            // 
            this.tbImperialTo.Location = new System.Drawing.Point(268, 202);
            this.tbImperialTo.Name = "tbImperialTo";
            this.tbImperialTo.ReadOnly = true;
            this.tbImperialTo.ShortcutsEnabled = false;
            this.tbImperialTo.Size = new System.Drawing.Size(100, 20);
            this.tbImperialTo.TabIndex = 12;
            this.tbImperialTo.TabStop = false;
            // 
            // tbImperialFrom
            // 
            this.tbImperialFrom.Location = new System.Drawing.Point(6, 202);
            this.tbImperialFrom.Name = "tbImperialFrom";
            this.tbImperialFrom.Size = new System.Drawing.Size(100, 20);
            this.tbImperialFrom.TabIndex = 11;
            this.tbImperialFrom.Text = "1";
            this.tbImperialFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbImperialTo
            // 
            this.cbImperialTo.FormattingEnabled = true;
            this.cbImperialTo.Items.AddRange(new object[] {
            "лига",
            "морская миля",
            "кабельтов британский",
            "кабельтов американский",
            "статутная миля",
            "фурлонг",
            "чейн",
            "род",
            "хэнд",
            "барлейкорн",
            "линия",
            "точка",
            "мил",
            "дюйм",
            "фут",
            "ярд",
            "миля",
            "метр",
            "километр"});
            this.cbImperialTo.Location = new System.Drawing.Point(247, 129);
            this.cbImperialTo.Name = "cbImperialTo";
            this.cbImperialTo.Size = new System.Drawing.Size(121, 21);
            this.cbImperialTo.TabIndex = 10;
            this.cbImperialTo.Text = "дюйм";
            // 
            // cbImperialFrom
            // 
            this.cbImperialFrom.FormattingEnabled = true;
            this.cbImperialFrom.Items.AddRange(new object[] {
            "лига",
            "морская миля",
            "кабельтов британский",
            "кабельтов американский",
            "статутная миля",
            "фурлонг",
            "чейн",
            "род",
            "хэнд",
            "барлейкорн",
            "линия",
            "точка",
            "мил",
            "дюйм",
            "фут",
            "ярд",
            "миля",
            "метр",
            "километр"});
            this.cbImperialFrom.Location = new System.Drawing.Point(6, 129);
            this.cbImperialFrom.Name = "cbImperialFrom";
            this.cbImperialFrom.Size = new System.Drawing.Size(121, 21);
            this.cbImperialFrom.TabIndex = 9;
            this.cbImperialFrom.Text = "ярд";
            // 
            // btnImperialSwap
            // 
            this.btnImperialSwap.Location = new System.Drawing.Point(149, 129);
            this.btnImperialSwap.Name = "btnImperialSwap";
            this.btnImperialSwap.Size = new System.Drawing.Size(75, 23);
            this.btnImperialSwap.TabIndex = 8;
            this.btnImperialSwap.Text = "swap";
            this.btnImperialSwap.UseVisualStyleBackColor = true;
            this.btnImperialSwap.Click += new System.EventHandler(this.btnImperialSwap_Click);
            // 
            // btnImperialConvert
            // 
            this.btnImperialConvert.Location = new System.Drawing.Point(149, 199);
            this.btnImperialConvert.Name = "btnImperialConvert";
            this.btnImperialConvert.Size = new System.Drawing.Size(75, 23);
            this.btnImperialConvert.TabIndex = 7;
            this.btnImperialConvert.Text = "convert";
            this.btnImperialConvert.UseVisualStyleBackColor = true;
            this.btnImperialConvert.Click += new System.EventHandler(this.btnImperialConvert_Click);
            // 
            // tpJapanese
            // 
            this.tpJapanese.Controls.Add(this.cbJapaneseMeasure);
            this.tpJapanese.Controls.Add(this.tbJapaneseTo);
            this.tpJapanese.Controls.Add(this.tbJapaneseFrom);
            this.tpJapanese.Controls.Add(this.cbJapaneseTo);
            this.tpJapanese.Controls.Add(this.cbJapaneseFrom);
            this.tpJapanese.Controls.Add(this.btnJapaneseSwap);
            this.tpJapanese.Controls.Add(this.btnJapaneseConvert);
            this.tpJapanese.Location = new System.Drawing.Point(4, 22);
            this.tpJapanese.Name = "tpJapanese";
            this.tpJapanese.Size = new System.Drawing.Size(376, 336);
            this.tpJapanese.TabIndex = 3;
            this.tpJapanese.Text = "Японские";
            this.tpJapanese.UseVisualStyleBackColor = true;
            // 
            // cbJapaneseMeasure
            // 
            this.cbJapaneseMeasure.FormattingEnabled = true;
            this.cbJapaneseMeasure.Items.AddRange(new object[] {
            "Длина",
            "Масса",
            "Объём",
            "Площадь"});
            this.cbJapaneseMeasure.Location = new System.Drawing.Point(125, 72);
            this.cbJapaneseMeasure.Name = "cbJapaneseMeasure";
            this.cbJapaneseMeasure.Size = new System.Drawing.Size(121, 21);
            this.cbJapaneseMeasure.TabIndex = 13;
            this.cbJapaneseMeasure.Text = "Длина";
            this.cbJapaneseMeasure.SelectedIndexChanged += new System.EventHandler(this.cbJapaneseMeasure_SelectedIndexChanged);
            // 
            // tbJapaneseTo
            // 
            this.tbJapaneseTo.Location = new System.Drawing.Point(269, 202);
            this.tbJapaneseTo.Name = "tbJapaneseTo";
            this.tbJapaneseTo.ReadOnly = true;
            this.tbJapaneseTo.ShortcutsEnabled = false;
            this.tbJapaneseTo.Size = new System.Drawing.Size(100, 20);
            this.tbJapaneseTo.TabIndex = 12;
            this.tbJapaneseTo.TabStop = false;
            // 
            // tbJapaneseFrom
            // 
            this.tbJapaneseFrom.Location = new System.Drawing.Point(7, 202);
            this.tbJapaneseFrom.Name = "tbJapaneseFrom";
            this.tbJapaneseFrom.Size = new System.Drawing.Size(100, 20);
            this.tbJapaneseFrom.TabIndex = 11;
            this.tbJapaneseFrom.Text = "1";
            this.tbJapaneseFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbJapaneseTo
            // 
            this.cbJapaneseTo.FormattingEnabled = true;
            this.cbJapaneseTo.Items.AddRange(new object[] {
            "бу",
            "сун",
            "сяку",
            "кэн",
            "хиро",
            "дзё",
            "те",
            "ри",
            "метр",
            "миллиметр"});
            this.cbJapaneseTo.Location = new System.Drawing.Point(248, 129);
            this.cbJapaneseTo.Name = "cbJapaneseTo";
            this.cbJapaneseTo.Size = new System.Drawing.Size(121, 21);
            this.cbJapaneseTo.TabIndex = 10;
            this.cbJapaneseTo.Text = "миллиметр";
            // 
            // cbJapaneseFrom
            // 
            this.cbJapaneseFrom.FormattingEnabled = true;
            this.cbJapaneseFrom.Items.AddRange(new object[] {
            "бу",
            "сун",
            "сяку",
            "кэн",
            "хиро",
            "дзё",
            "те",
            "ри",
            "метр",
            "миллиметр"});
            this.cbJapaneseFrom.Location = new System.Drawing.Point(7, 129);
            this.cbJapaneseFrom.Name = "cbJapaneseFrom";
            this.cbJapaneseFrom.Size = new System.Drawing.Size(121, 21);
            this.cbJapaneseFrom.TabIndex = 9;
            this.cbJapaneseFrom.Text = "метр";
            // 
            // btnJapaneseSwap
            // 
            this.btnJapaneseSwap.Location = new System.Drawing.Point(150, 129);
            this.btnJapaneseSwap.Name = "btnJapaneseSwap";
            this.btnJapaneseSwap.Size = new System.Drawing.Size(75, 23);
            this.btnJapaneseSwap.TabIndex = 8;
            this.btnJapaneseSwap.Text = "swap";
            this.btnJapaneseSwap.UseVisualStyleBackColor = true;
            this.btnJapaneseSwap.Click += new System.EventHandler(this.btnJapaneseSwap_Click);
            // 
            // btnJapaneseConvert
            // 
            this.btnJapaneseConvert.Location = new System.Drawing.Point(150, 199);
            this.btnJapaneseConvert.Name = "btnJapaneseConvert";
            this.btnJapaneseConvert.Size = new System.Drawing.Size(75, 23);
            this.btnJapaneseConvert.TabIndex = 7;
            this.btnJapaneseConvert.Text = "convert";
            this.btnJapaneseConvert.UseVisualStyleBackColor = true;
            this.btnJapaneseConvert.Click += new System.EventHandler(this.btnJapaneseConvert_Click);
            // 
            // tpAboutProgram
            // 
            this.tpAboutProgram.Controls.Add(this.tbAboutProgram);
            this.tpAboutProgram.Controls.Add(this.tbPrefix);
            this.tpAboutProgram.Location = new System.Drawing.Point(4, 22);
            this.tpAboutProgram.Name = "tpAboutProgram";
            this.tpAboutProgram.Size = new System.Drawing.Size(376, 336);
            this.tpAboutProgram.TabIndex = 4;
            this.tpAboutProgram.Text = "О программе";
            this.tpAboutProgram.UseVisualStyleBackColor = true;
            // 
            // tbAboutProgram
            // 
            this.tbAboutProgram.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbAboutProgram.Location = new System.Drawing.Point(268, 287);
            this.tbAboutProgram.Multiline = true;
            this.tbAboutProgram.Name = "tbAboutProgram";
            this.tbAboutProgram.ReadOnly = true;
            this.tbAboutProgram.ShortcutsEnabled = false;
            this.tbAboutProgram.Size = new System.Drawing.Size(108, 49);
            this.tbAboutProgram.TabIndex = 1;
            this.tbAboutProgram.TabStop = false;
            this.tbAboutProgram.Text = "Program \"Converter\"\r\nversion 1.0\r\nauthor Paul Winter";
            this.tbAboutProgram.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbPrefix
            // 
            this.tbPrefix.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbPrefix.Location = new System.Drawing.Point(0, 0);
            this.tbPrefix.Multiline = true;
            this.tbPrefix.Name = "tbPrefix";
            this.tbPrefix.ReadOnly = true;
            this.tbPrefix.ShortcutsEnabled = false;
            this.tbPrefix.Size = new System.Drawing.Size(268, 336);
            this.tbPrefix.TabIndex = 0;
            this.tbPrefix.TabStop = false;
            this.tbPrefix.Text = resources.GetString("tbPrefix.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "MainForm";
            this.Text = "Конвертер";
            this.tabControl.ResumeLayout(false);
            this.tpActual.ResumeLayout(false);
            this.tpActual.PerformLayout();
            this.tpRussian.ResumeLayout(false);
            this.tpRussian.PerformLayout();
            this.tpImperial.ResumeLayout(false);
            this.tpImperial.PerformLayout();
            this.tpJapanese.ResumeLayout(false);
            this.tpJapanese.PerformLayout();
            this.tpAboutProgram.ResumeLayout(false);
            this.tpAboutProgram.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpActual;
        private System.Windows.Forms.TabPage tpRussian;
        private System.Windows.Forms.TabPage tpImperial;
        private System.Windows.Forms.TabPage tpJapanese;
        private System.Windows.Forms.TabPage tpAboutProgram;
        private System.Windows.Forms.TextBox tbActualTo;
        private System.Windows.Forms.TextBox tbActualFrom;
        private System.Windows.Forms.ComboBox cbActualTo;
        private System.Windows.Forms.ComboBox cbActualFrom;
        private System.Windows.Forms.Button btnActualSwap;
        private System.Windows.Forms.Button btnActualConvert;
        private System.Windows.Forms.ComboBox cbRussianMeasure;
        private System.Windows.Forms.TextBox tbRussianTo;
        private System.Windows.Forms.TextBox tbRussianFrom;
        private System.Windows.Forms.ComboBox cbRussianTo;
        private System.Windows.Forms.ComboBox cbRussianFrom;
        private System.Windows.Forms.Button btnRussianSwap;
        private System.Windows.Forms.Button btnRussianConvert;
        private System.Windows.Forms.ComboBox cbImperialMeasure;
        private System.Windows.Forms.TextBox tbImperialTo;
        private System.Windows.Forms.TextBox tbImperialFrom;
        private System.Windows.Forms.ComboBox cbImperialTo;
        private System.Windows.Forms.ComboBox cbImperialFrom;
        private System.Windows.Forms.Button btnImperialSwap;
        private System.Windows.Forms.Button btnImperialConvert;
        private System.Windows.Forms.ComboBox cbJapaneseMeasure;
        private System.Windows.Forms.TextBox tbJapaneseTo;
        private System.Windows.Forms.TextBox tbJapaneseFrom;
        private System.Windows.Forms.ComboBox cbJapaneseTo;
        private System.Windows.Forms.ComboBox cbJapaneseFrom;
        private System.Windows.Forms.Button btnJapaneseSwap;
        private System.Windows.Forms.Button btnJapaneseConvert;
        private System.Windows.Forms.TextBox tbPrefix;
        private System.Windows.Forms.TextBox tbAboutProgram;
        internal System.Windows.Forms.ComboBox cbActualMeasure;
    }
}

