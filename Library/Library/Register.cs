using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Model;

namespace Library
{
    public partial class Register : Form
    {
        private const int NumberOfBooksPerUser = 0;
        LibraryEntities db = new LibraryEntities();
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string name = txtName.Text;
            string password = txtPassword.Text;
            string conPassword = txtConPassword.Text;
            string age = txtAge.Text;

            if(Extensions.checkAllValues(new string[] { name, username, password,
            conPassword,age}, String.Empty))
            {
                int count = db.Users.Where(us => us.Username == username).Count();
                if (count == 0)
                {
                    if(password.Length >=8 && password == conPassword)
                    {
                        string hashResult = Extensions.getHashCode(password);
                        int AgeI = Convert.ToInt32(age);

                        db.Users.Add(new User()
                        {
                            Name = name,
                            Username = username,
                            Password = hashResult,
                            Age = AgeI,
                            Rent_count = NumberOfBooksPerUser
                        });
                        db.SaveChanges();
                        MessageBox.Show(String.Format("Dear {0}, you were successfully added to library.", name));
                        this.Close();
                    }
                    else
                    {
                        ShowMessage("Password should be at least 8 charachters long and should be same with confirm. ");
                    }
                }
                else
                {
                    ShowMessage("This username was already used.");
                }
            }
            else
            {
                ShowMessage("Please, fill all the fields.");
            }
        }

        private void ShowMessage(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

         
    }
}
