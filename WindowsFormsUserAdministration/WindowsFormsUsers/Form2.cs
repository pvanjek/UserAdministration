using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseService;

namespace WindowsFormsUsers
{
    public partial class FormEditUser : System.Windows.Forms.Form
    {
        private readonly Form1 FormUserList; // tako da bi kasnije onbutton click spremi,imali taj objekt
        public FormEditUser(Form1 FormUsers)
        {
            FormUserList = FormUsers;
            InitializeComponent();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            User oUser = new User(); //novi objekt
            oUser.nUserID = Int32.Parse(lblEditUserID.Text);// pretvaramo  string to int (citanje labelice)
            oUser.sUserFirstName = inptEditName.Text;// controla za dohvacanje inputa
            oUser.sUserLastName = inptEditSurname.Text;
            oUser.sUserPassword = inptEditPassword.Text;
            oUser.sUserName = lblEditUserName.Text;
            Crud Crud = new Crud(); //objekt klase crud, nad kojom pozivam klasu User
            Crud.UpdateUsers(oUser);//poziv funkcije

            this.FormUserList.dataGridViewUsers.DataSource = Crud.GetUsers();
            this.Hide();

        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
