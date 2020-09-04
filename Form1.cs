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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
