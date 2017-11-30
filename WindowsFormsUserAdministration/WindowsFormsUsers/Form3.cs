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
using System.Diagnostics;

namespace WindowsFormsUsers
{
    public partial class DeleteUser : Form
    {
        private readonly Form1 FormUserList;
        public string ID;
        public string Name;
        public string Surname;
        public string Password;
        public string Username;
        public DeleteUser(Form1 FormUser)
        {
            FormUserList = FormUser;
            InitializeComponent();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("prvi gumb");
            User oUser = new User();
            oUser.nUserID = Int32.Parse(ID);
            oUser.sUserFirstName = Name;
            oUser.sUserLastName = Surname;
            oUser.sUserPassword = Password;
            oUser.sUserName = Username;
            Crud Crud = new Crud();
            Crud.DeleteUsers(oUser);
            this.FormUserList.dataGridViewUsers.DataSource = Crud.GetUsers();
            this.Hide();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            User oUser = new User();
            oUser.nUserID = Int32.Parse(ID);
            oUser.sUserFirstName = Name;
            oUser.sUserLastName = Surname;
            oUser.sUserPassword = Password;
            oUser.sUserName = Username;
            Crud Crud = new Crud();
            Crud.DeleteUsers(oUser);
            this.FormUserList.dataGridViewUsers.DataSource = Crud.GetUsers();
            this.Hide();
        }
    }
}