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
    public partial class FRM_MAIN : Form
    {
        DB_HMSEntities db = new DB_HMSEntities();  
        TBL_ADDROOM tbl_room = new TBL_ADDROOM(); 
        TBL_REGISTER tbl_reg = new TBL_REGISTER();
        TBL_CHECKOUT tbl_check = new TBL_CHECKOUT();
        TBL_EMPLOYEE tbl_employee = new TBL_EMPLOYEE();
        bool flag =false ;
        string rowroomnumber;
        int emploId;
        int idcellClick; 
        public FRM_MAIN()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_addRom_Click(object sender, EventArgs e)
        {

        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dB_HMSDataSet2.TBL_EMPLOYEE' table. You can move, or remove it, as needed.
            this.tBL_EMPLOYEETableAdapter.Fill(this.dB_HMSDataSet2.TBL_EMPLOYEE);
            // TODO: This line of code loads data into the 'dB_HMSDataSet1.TBL_REGISTER' table. You can move, or remove it, as needed.
            this.tBL_REGISTERTableAdapter1.Fill(this.dB_HMSDataSet1.TBL_REGISTER);
            // TODO: This line of code loads data into the 'dB_HMSDataSet.TBL_REGISTER' table. You can move, or remove it, as needed.
            this.tBL_REGISTERTableAdapter.Fill(this.dB_HMSDataSet.TBL_REGISTER);
            PN_ADDROOM.Visible = true;
            PN_REG.Visible = false;
            PN_CHECKOUT.Visible = false;
            PN_CUSTOMER.Visible = false;
            PN_EMPLOYEE.Visible = false;
            DGVROOM.DataSource = db.TBL_ADDROOM.ToList();
            DGVCHEKOUT.DataSource = db.TBL_REGISTER.Where(x=> x.cuscheckout==null).ToList();
            
            btn_room.IdleFillColor = Color.White;
            btn_room.IdleForecolor = Color.Black;

            //DGVCHECK();

            //txt_regprice.Text = tbl_room.room_price;
            ////PN_CUSTOMER.Visible = true;
            //PN_ALLCUSTOMER.Visible = false;
            //PN_OUTCUSTOMER.Visible = false;
            //PN_INCUSTOMER.Visible = false;


        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {

                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void tbn_roadd_Click(object sender, EventArgs e)
        {
            if (txt_ronu.Text == "" || cbo_robed.Text == "" || cbo_rotype.Text == "" || txt_roprice.Text == "")
            {
                MessageBox.Show("Fill All Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                tbl_room.room_number =txt_ronu.Text;
                tbl_room.room_type = cbo_rotype.Text;
                tbl_room.room_bed = cbo_robed.Text;
                tbl_room.room_price = txt_roprice.Text;
                tbl_room.room_book = "NO";
                db.TBL_ADDROOM.Add(tbl_room);
                db.SaveChanges();
                MessageBox.Show("A Room  added successfully");

                txt_ronu.Text = string.Empty;
                cbo_rotype.SelectedIndex = -1;
                cbo_robed.SelectedIndex = -1;
                txt_roprice.Text = string.Empty;

            }
        }

        private void FRM_MAIN_Activated(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'dB_HMSDataSet1.TBL_REGISTER' table. You can move, or remove it, as needed.
            this.tBL_REGISTERTableAdapter1.Fill(this.dB_HMSDataSet1.TBL_REGISTER);
            // TODO: This line of code loads data into the 'dB_HMSDataSet.TBL_REGISTER' table. You can move, or remove it, as needed.
            this.tBL_REGISTERTableAdapter.Fill(this.dB_HMSDataSet.TBL_REGISTER);

            DGVROOM.DataSource = db.TBL_ADDROOM.ToList();
            db.SaveChanges();
            DGVCHEKOUT.DataSource = db.TBL_REGISTER.Where(x => x.cuscheckout == null).ToList();
            DGVDELETEEMPLOYEE.DataSource = db.TBL_EMPLOYEE.ToList();
            DGVSHOWEMPLOYEE.DataSource = db.TBL_EMPLOYEE.ToList();
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            PN_REG.Visible = true;
            PN_ADDROOM.Visible = false;
            PN_CHECKOUT.Visible = false;
            PN_CUSTOMER.Visible = false;
            PN_EMPLOYEE.Visible = false;
            btn_room.IdleFillColor = Color.CadetBlue;
            btn_check.IdleFillColor = Color.CadetBlue;
            btn_cus.IdleFillColor = Color.CadetBlue;
            btn_employee.IdleFillColor = Color.CadetBlue;
            btn_reg.IdleFillColor = Color.White;
            

        }

        private void btn_room_Click(object sender, EventArgs e)
        {
            PN_REG.Visible = false;
            PN_ADDROOM.Visible = true;
            PN_CHECKOUT.Visible = false;
            PN_CUSTOMER.Visible = false;
            PN_EMPLOYEE.Visible = false;
            btn_room.IdleFillColor = Color.White;
            btn_check.IdleFillColor = Color.CadetBlue;
            btn_cus.IdleFillColor = Color.CadetBlue;
            btn_employee.IdleFillColor = Color.CadetBlue;
            btn_reg.IdleFillColor = Color.CadetBlue;

        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            PN_ADDROOM.Visible = false;
            PN_REG.Visible = false;
            PN_CHECKOUT.Visible = true;
            PN_CUSTOMER.Visible = false;
            PN_EMPLOYEE.Visible = false;
            btn_room.IdleFillColor = Color.CadetBlue;
            btn_check.IdleFillColor = Color.White;
            btn_cus.IdleFillColor = Color.CadetBlue;
            btn_employee.IdleFillColor = Color.CadetBlue;
            btn_reg.IdleFillColor = Color.CadetBlue;
        }

        private void btn_cus_Click(object sender, EventArgs e)
        {
            btn_room.IdleFillColor = Color.CadetBlue;
            btn_check.IdleFillColor = Color.CadetBlue;
            btn_cus.IdleFillColor = Color.White;
            btn_employee.IdleFillColor = Color.CadetBlue;
            btn_reg.IdleFillColor = Color.CadetBlue;

            PN_ADDROOM.Visible = false;
            PN_REG.Visible = false;
            PN_CHECKOUT.Visible = false;
            PN_CUSTOMER.Visible = true;
            PN_EMPLOYEE.Visible = false;

            PN_ALLCUSTOMER.Visible = false;
            PN_OUTCUSTOMER.Visible = false;
            PN_INCUSTOMER.Visible = false;
            CBO_SEARCHBYDGV.SelectedIndex = -1;
        }

        private void btn_employee_Click(object sender, EventArgs e)
        {
            PN_ADDROOM.Visible = false;
            PN_REG.Visible = false;
            PN_CHECKOUT.Visible = false;
            PN_CUSTOMER.Visible = false;
            PN_EMPLOYEE.Visible = true;
            btn_room.IdleFillColor = Color.CadetBlue;
            btn_check.IdleFillColor = Color.CadetBlue;
            btn_cus.IdleFillColor = Color.CadetBlue;
            btn_employee.IdleFillColor = Color.White;
            btn_reg.IdleFillColor = Color.CadetBlue;

            /////

            emploId = db.TBL_EMPLOYEE.Count();
            emploId++;
            int neemid = emploId;
            var cc = db.TBL_EMPLOYEE.Where(x => x.emid == neemid);

            if (cc != null)
            {
                neemid++;
                lbl_emid.Text = (neemid).ToString();
            }
            else {
                lbl_emid.Text = (emploId).ToString();
            }
        }

        private void PN_ADDROOM_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_AlloteRoom_Click(object sender, EventArgs e)
        {
            if (txt_cusname.Text == "" && txt_cusphone.Text == "" && txt_cusNationality.Text == "" && cbo_gender.Text == "" && txt_idproof.Text == "" && txt_address.Text == "" && cbo_regbed.Text == "" && cbo_roomnumber.Text == "" && cbo_regroomtype.Text == "" && txt_regprice.Text == "")
            {
                MessageBox.Show("Fill All Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else {
                tbl_reg.cusname = txt_cusname.Text;
                tbl_reg.cusphone = txt_cusphone.Text;
                tbl_reg.cusnational = txt_cusNationality.Text;
                tbl_reg.cusgender = cbo_gender.Text;
                tbl_reg.cusdatebirth = txt_DOB.Value;
                tbl_reg.idProof = txt_idproof.Text;
                tbl_reg.cusaddress = txt_address.Text;
                tbl_reg.cuscheckin = txt_DCI.Value;
                tbl_reg.cuscheckout = null;
                tbl_reg.roomnumber = cbo_roomnumber.Text;
                tbl_reg.roombed = cbo_regbed.Text;
                tbl_reg.roomtype = cbo_regroomtype.Text;
                tbl_reg.roomprice = txt_regprice.Text;
                tbl_room.room_book = "Yes";
                db.TBL_REGISTER.Add(tbl_reg);
                db.SaveChanges();
                
                MessageBox.Show(" Added successfully");
                txt_cusname.Text = string.Empty;
                txt_cusphone.Text= string.Empty;
                txt_cusNationality.Text= string.Empty;
                cbo_gender.SelectedIndex = -1;
                txt_DOB.Value = DateTime.Now;
                txt_idproof.Text = string.Empty;
                txt_address.Text = string.Empty;
                txt_DCI.Value = DateTime.Now;
                cbo_roomnumber.Text = string.Empty;
                cbo_regbed.SelectedIndex = -1;
                cbo_regroomtype.SelectedIndex = -1;
                txt_regprice.Text = string.Empty;

            }
        }

        private void cbo_regbed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbo_regroomtype_SelectedIndexChanged(object sender, EventArgs e)
        {



            var query = db.TBL_ADDROOM.Where(t => t.room_bed == cbo_regbed.Text && t.room_type == cbo_regroomtype.Text && t.room_book=="NO").Select(t => new
            {
                t.room_number
            }).ToList();

            flag = false;
            cbo_roomnumber.DataSource = query;
            cbo_roomnumber.DisplayMember = "room_number";
            cbo_roomnumber.SelectedIndex = -1;
            flag = true;


            
        }

        private void cbo_roomnumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag==true)
            {
                tbl_room = db.TBL_ADDROOM.Where(x =>x.room_number==cbo_roomnumber.Text  ).FirstOrDefault();

                txt_regprice.Text = tbl_room.room_price;
            }
                      

        }


         

        private void txt_regprice_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void cbo_roomnumber_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //int roomumber =  cbo_roomnumber.SelectedIndex;
            //MessageBox.Show(cbo_roomnumber.SelectedText.Trim());
            //tbl_room = db.TBL_ROOM.Where(x => x.room_number == Convert.ToInt32( cbo_roomnumber.SelectedText)).FirstOrDefault();
            //txt_regprice.Text = tbl_room.room_price;
            //tbl_room = db.TBL_NEROOM.Where(x => x.room_type== cbo_regroomtype.SelectedText && x.room_bed== cbo_regbed.SelectedText).FirstOrDefault();

            //txt_regprice.Text = tbl_room.room_price;
        }

        private void cbo_roomnumber_SelectedValueChanged(object sender, EventArgs e)
        {
            //tbl_room = db.TBL_ROOM.Where(x => x.room_number == Convert.ToInt32(cbo_roomnumber.Text)).FirstOrDefault();
            //txt_regprice.Text = tbl_room.room_price;
        }

        private void cbo_roomnumber_TextChanged(object sender, EventArgs e)
        {
           // tbl_room = db.TBL_NEROOM.Where(x => x.room_number == cbo_roomnumber.SelectedText).FirstOrDefault();

            //txt_regprice.Text = tbl_room.room_price;
        }

        private void cbo_regroomtype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //var query = db.TBL_ROOM.Where(t => t.room_bed == cbo_regbed.Text && t.room_type == cbo_regroomtype.Text).Select(t => new
            //{
            //    t.room_number
            //}).ToList();

            //cbo_roomnumber.DataSource = query;
            //cbo_roomnumber.DisplayMember = "room_number";
            //cbo_roomnumber.SelectedIndex = -1;
        }

        private void cbo_roomnumber_TabIndexChanged(object sender, EventArgs e)
        {
            tbl_room = db.TBL_ADDROOM.Where(x => x.room_number == cbo_roomnumber.SelectedText).FirstOrDefault();

            txt_regprice.Text = tbl_room.room_price;
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            var search = txt_search.Text;
            DGVCHEKOUT.DataSource = db.TBL_REGISTER.Where(x => x.cusname.Contains(search) && x.cuscheckout == null).ToList();

            //DGVCHEKOUT.DataSource = db.TBL_REGISTER.Where(x => x.cuscheckout == null ).ToList();
        }

        private void DGVCHEKOUT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idcellClick = Convert.ToInt32(DGVCHEKOUT.CurrentRow.Cells[0].Value);
            tbl_reg = db.TBL_REGISTER.Where(x => x.id == idcellClick).FirstOrDefault();

            txt_ChName.Text = tbl_reg.cusname;
            txt_ChRoomN.Text = tbl_reg.roomnumber;
        }

        private void btn_checkout_Click(object sender, EventArgs e)
        {
           
            string datecheck =  DGVCHEKOUT.CurrentRow.Cells[9].ToString();
            var filteredRows = db.TBL_REGISTER.Where(x => x.cusname == txt_ChName.Text && x.roomnumber == txt_ChRoomN.Text ).ToList();
            if (filteredRows.Count > 0)
            {
                foreach (var row in filteredRows)
                {
                    string cusname = $" {row.cusname}";
                    string rowphone = $" {row.cusphone}";
                    string cusnational = $" {row.cusnational}";
                    string rowgender = $" {row.cusgender}";
                    DateTime rowdatebirth = Convert.ToDateTime($" {  row.cusdatebirth}");
                    string idprrof = $" {row.idProof}";
                    string rowaddress = $" {row.cusaddress}";
                    DateTime rowcheckin =  Convert.ToDateTime( $" {row.cuscheckin}");
                    //DateTime rowcheckout = Convert.ToDateTime($" {row.cuscheckout}");
                    //DateTime rowcheckout = Convert.ToDateTime( txt_datcheckout);
                     rowroomnumber = $" {row.roomnumber}";
                    string rowroombed = $" {row.roombed}";
                    string rowrootype = $" {row.roomtype}";
                    string rowroomprice = $" {row.roomprice}";

                    

                    tbl_reg.cusname = cusname;
                    tbl_reg.cusphone = rowphone;
                    tbl_reg.cusnational = cusnational;
                    tbl_reg.cusgender = rowgender;
                    tbl_reg.cusdatebirth = rowdatebirth;
                    tbl_reg.idProof = idprrof ;
                    tbl_reg.cusaddress = rowaddress;
                    tbl_reg.cuscheckin = rowcheckin;
                    tbl_reg.cuscheckout = txt_datcheckout.Value;
                    tbl_reg.roomnumber = rowroomnumber;
                    tbl_reg.roombed = rowroombed;
                    tbl_reg.roomtype = rowrootype;
                    tbl_reg.roomprice = rowroomprice;


                    db.TBL_REGISTER.Add(tbl_reg);
                    db.SaveChanges();
                  
                    MessageBox.Show(" CheckOut successfully");
                    DGVCHECK();
                    DGVCHEKOUT.DataSource = db.TBL_REGISTER.Where(x => x.cuscheckout == null).ToList();

                }

                tbl_room = db.TBL_ADDROOM.Where(x => x.room_number == txt_ChRoomN.Text).FirstOrDefault();
                tbl_room.room_book = "NO";
                
                db.Entry(tbl_room).State= System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                DGVROOM.DataSource = db.TBL_ADDROOM.ToList();
            }


            txt_ChName.Text = "";
            txt_ChRoomN.Text = "";
            txt_datcheckout.Value = DateTime.Now ;
            //var ff = db.TBL_REGISTER.Where(x => x.id == idcellClick).ToList();
            //if (ff.Count > 0)
            //{
            //    db.Entry(tbl_reg).State = System.Data.Entity.EntityState.Deleted;
            //    db.SaveChanges();
            //}

        }


        public void DGVCHECK( )
        {

             tbl_reg = db.TBL_REGISTER.Where(x => x.id == idcellClick).FirstOrDefault();
           
                db.Entry(tbl_reg).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            {
          
            }

             if (CBO_SEARCHBYDGV.Text == "In Hotel Customer")
            {

                PN_ALLCUSTOMER.Visible = false;
                PN_OUTCUSTOMER.Visible = false;
                PN_INCUSTOMER.Visible = true;
                DGVINCUSTOMER.DataSource = db.TBL_REGISTER.Where(x => x.cuscheckout == null).ToList();

            }
           else   if (CBO_SEARCHBYDGV.Text == "All Customer Details")
            {
                PN_ALLCUSTOMER.Visible = true;
                PN_OUTCUSTOMER.Visible = false;
                PN_INCUSTOMER.Visible = false;
                DGVALLCUSTOMER.DataSource = db.TBL_REGISTER.ToList();

            }

            
           else  if (CBO_SEARCHBYDGV.Text == "Checkout Customer")
            {
                PN_ALLCUSTOMER.Visible = false;
                PN_OUTCUSTOMER.Visible = true;
                PN_INCUSTOMER.Visible = false;
                DGVOUTCUSTOMER.DataSource = db.TBL_REGISTER.Where(x => x.cuscheckout != null).ToList();
            }


            else if(CBO_SEARCHBYDGV.SelectedIndex == -1)
            {
                PN_CUSTOMER.Visible = true;
                PN_ALLCUSTOMER.Visible = false;
                PN_OUTCUSTOMER.Visible = false;
                PN_INCUSTOMER.Visible = false;
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

            //emploId = db.TBL_EMPLOYEE.Count();
            //emploId++;
            //int neemid = emploId;
            //var cc = db.TBL_EMPLOYEE.Where(x => x.emid == neemid);

            //if (cc != null)
            //{
            //    neemid++;
            //    lbl_emid.Text = (neemid).ToString();
            //}
            //else {
            //    lbl_emid.Text = (emploId).ToString();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_emname.Text == string.Empty && txt_emphone.Text == string.Empty && cbo_emgender.Text == string.Empty && txt_ememail.Text == string.Empty && txt_emuser.Text == string.Empty && txt_empassword.Text == string.Empty)
            {
                MessageBox.Show("Fill All Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                tbl_employee.emid = Convert.ToInt32(lbl_emid.Text);
                tbl_employee.emname = txt_emname.Text;
                tbl_employee.emphone = txt_emphone.Text;
                tbl_employee.emgender = cbo_emgender.Text;
                tbl_employee.ememail = txt_ememail.Text;
                tbl_employee.emuser = txt_emuser.Text;
                tbl_employee.empassword = txt_empassword.Text;
                db.TBL_EMPLOYEE.Add(tbl_employee);
                db.SaveChanges();
                MessageBox.Show("Employee  added successfully");
                txt_emname.Text = string.Empty;
                txt_emphone.Text = string.Empty;
                cbo_emgender.Text = string.Empty;
                txt_ememail.Text = string.Empty;
                txt_emuser.Text = string.Empty;
                txt_empassword.Text = string.Empty;

            }
        }

        private void btn_emDelete_Click(object sender, EventArgs e)
        {
            if (txt_emsearchid.Text == "")
            {
                MessageBox.Show("Enter ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                var id = Convert.ToInt32(txt_emsearchid.Text);
                tbl_employee = db.TBL_EMPLOYEE.Where(x => x.emid == id).FirstOrDefault();
                db.Entry(tbl_employee).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                MessageBox.Show("Deleted !!");
                
            }
        }
    }
}
