using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingHub2.WinUI.Korisnik
{
    public partial class frmRoleManager : Form
    {
        APIService _service = new APIService("RoleManager");
        public frmRoleManager()
        {
            InitializeComponent();
        }
        private  void frmPrikazKorisnika_Load(object sender, EventArgs e)
        {
            //dgvUloge.DataSource = await _service.
        }
    }
}
