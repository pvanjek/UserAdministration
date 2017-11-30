using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseService;  // Ukljuciti referencu-->add-->reference-->ukljuciti biblioteku sa funkcijama .dll

namespace WindowsFormsUsers
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
            Crud Crud = new Crud();   //Objekt klase crud
            List < User > lUsers= Crud.GetUsers();
            dataGridViewUsers.DataSource = lUsers;

            // Sluzi za dodavanje kolona
            DataGridViewImageColumn oEditButton = new DataGridViewImageColumn();
            oEditButton.Image = Image.FromFile("D:/Petar Vanjek/pencil.png");
            oEditButton.Width = 20;
            oEditButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewUsers.Columns.Add(oEditButton);

            DataGridViewImageColumn oDeleteButton = new DataGridViewImageColumn();
            oDeleteButton.Image = Image.FromFile("D:/Petar Vanjek/trash.png");
            oDeleteButton.Width = 20;
            oDeleteButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewUsers.Columns.Add(oDeleteButton);

            dataGridViewUsers.AutoGenerateColumns = false;
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //  MessageBox.Show("Dot Net"); -- provjera jel radi

            dataGridViewUsers.Rows[e.RowIndex].Selected = true; // redak na koji sam pritisnuo dugmic se selectira cijeli redak.
            if (dataGridViewUsers.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1) // ako mi je moja trenuta celija ( index =5--broj kolone ) i ako index retka nije -1(mora biti index) nesto napravi
            {
                FormEditUser FormEditUser = new FormEditUser(this); //this pokazivac na objekt 1.forme-->prosljedujemo parametar
                FormEditUser.lblEditUserID.Text =dataGridViewUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
                FormEditUser.lblEditUserName.Text = dataGridViewUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
                FormEditUser.inptEditPassword.Text = dataGridViewUsers.Rows[e.RowIndex].Cells[2].Value.ToString();
                FormEditUser.inptEditName.Text = dataGridViewUsers.Rows[e.RowIndex].Cells[3].Value.ToString();
                FormEditUser.inptEditSurname.Text = dataGridViewUsers.Rows[e.RowIndex].Cells[4].Value.ToString();
                FormEditUser.Show();
            }
            if (dataGridViewUsers.CurrentCell.ColumnIndex.Equals(6) && e.RowIndex != -1)
            {
                DeleteUser FormDeleteUser = new DeleteUser(this);
                FormDeleteUser.ID = dataGridViewUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
                FormDeleteUser.Username = dataGridViewUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
                FormDeleteUser.Password = dataGridViewUsers.Rows[e.RowIndex].Cells[2].Value.ToString();
                FormDeleteUser.Name = dataGridViewUsers.Rows[e.RowIndex].Cells[3].Value.ToString();
                FormDeleteUser.Surname = dataGridViewUsers.Rows[e.RowIndex].Cells[4].Value.ToString();
                FormDeleteUser.Show();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUser AddNewUser = new AddUser(this);
            AddNewUser.Show();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            AddUser AddNewUser = new AddUser(this);
            AddNewUser.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
