using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingHub2.WinUI.Proizvod
{
    public partial class frmProizvodDodajUredi : Form
    {
        APIService _service = new APIService("Proizvod");
        private int? _id = null;
        public frmProizvodDodajUredi(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }
    }
}
