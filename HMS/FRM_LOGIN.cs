using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS
{
    public partial class FRM_LOGIN : Form
    {
        DB_HMSEntities db = new DB_HMSEntities();
        TBL_EMPLOYEE tbl_employee = new TBL_EMPLOYEE();
        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void FRM_LOGIN_Load(object sender, EventArgs e)
        {
            lbl_mesWrong.Visible = false;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            tbl_employee = db.TBL_EMPLOYEE.Where(x => x.emuser == txt_username.Text && x.empassword == txt_pass.Text).FirstOrDefault();
            if(tbl_employee != null)
            {
                FRM_MAIN frm_main = new FRM_MAIN();
                frm_main.Show();
            }

            else
            {
                lbl_mesWrong.Visible = true;

            }
        }
    }
}
