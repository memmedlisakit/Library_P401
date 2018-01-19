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
    public partial class LibraryHomePage : Form
    {
        LibraryEntities db = new LibraryEntities();
        User selectedUser;
        int rentCout = 5;
        public LibraryHomePage(User usr)
        {
            selectedUser = usr;
            InitializeComponent();
            fillComboCategory();
            fillComboAuthor();
            fillGridLibrary();
        }

        private void fillComboCategory()
        {
            cmbCategory.Items.Add("All");
            string[] categories = db.Categories.Where(ct => ct.Status == 1).Select(ct => ct.Name).ToArray();
            cmbCategory.Items.AddRange(categories);
            cmbCategory.SelectedIndex = 0;
        }

        private void fillComboAuthor()
        {
            cmbAuthor.Items.Add("All");
            string[] authors = db.Authors.Where(au => au.Status == 1).Select(au => au.Name).ToArray();
            cmbAuthor.Items.AddRange(authors);
            cmbAuthor.SelectedIndex = 0;
        }

        private void fillGridLibrary()
        {
            dgwLibrary.DataSource = db.Books.Where(bk => bk.Available_count > 0).
                Select(bk => new
                {
                    Id = bk.ID,
                    Name = bk.Name,
                    Author = bk.Author.Name,
                    Category = bk.Category.Name,
                    Count = bk.Available_count
                }).ToList();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string category = this.cmbCategory.Text;
            string author = this.cmbAuthor.Text;
            string bookName = this.txtBookName.Text;

        
            if (category == "All" && author == "All" && bookName == "")
            {
                this.fillGridLibrary();
            }
            else
            {
                if (bookName != "")
                {
                    this.dgwLibrary.DataSource = db.Books.Where(bk => bk.Name.Contains(bookName)).Select(bk => new
                    {
                        Id = bk.ID,
                        Name = bk.Name,
                        Author = bk.Author.Name,
                        Category = bk.Category.Name,
                        Count = bk.Available_count
                    }).ToList();
                    this.clearText();

                }
                else if (category != "All" && author != "All")
                {
                    this.dgwLibrary.DataSource = db.Books.Where(bk => bk.Category.Name.Contains(category)&&bk.Author.Name.Contains(author)).Select(bk => new
                    {
                        Id = bk.ID,
                        Name = bk.Name,
                        Author = bk.Author.Name,
                        Category = bk.Category.Name,
                        Count = bk.Available_count,
                    }).ToList();
                    this.clearText();
                }

                if (category != "All")
                {
                    this.dgwLibrary.DataSource = db.Books.Where(bk => bk.Category.Name.Contains(category)).Select(bk => new
                    {
                        Id = bk.ID,
                        Name = bk.Name,
                        Author = bk.Author.Name,
                        Category = bk.Category.Name,
                        Count = bk.Available_count,
                    }).ToList();
                    this.clearText();
                }
                if (author != "All")
                {
                    this.dgwLibrary.DataSource = db.Books.Where(bk => bk.Author.Name.Contains(author)).Select(bk => new
                    {
                        Id = bk.ID,
                        Name = bk.Name,
                        Author = bk.Author.Name,
                        Category = bk.Category.Name,
                        Count = bk.Available_count
                    }).ToList();
                    this.clearText();
                }

            }
           
        }

        private void clearText()
        {
            this.cmbAuthor.Text = "All";
            this.cmbCategory.Text = "All";
            this.txtBookName.Clear();
        }

        private void dgwLibrary_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id =Convert.ToInt32(this.dgwLibrary.Rows[e.RowIndex].Cells[0].Value);
            Book bk = db.Books.Find(id);
            User usr = db.Users.FirstOrDefault(us => us.Username == this.selectedUser.Username);
            if (bk.Available_count > 0)
            {
                if (usr.Rent_count < rentCout)
                {

                    usr.Rent_count += 1;
                    bk.Available_count--;
                    Book_To_Users book_To_Users = new Book_To_Users();
                    book_To_Users.User_id = this.selectedUser.ID;
                    book_To_Users.Book_id = bk.ID;
                    book_To_Users.Get_date = DateTime.Now;
                    db.Book_To_Users.Add(book_To_Users);
                    db.SaveChanges();
                    MessageBox.Show(bk.Name + " kitabini aldiniz");
                    this.fillGridLibrary();
                }
                else
                {
                    this.lblErrors.Text = this.selectedUser.Name + " limitiniz bitmishdir";
                }
            }
            else
            {
                this.lblErrors.Text = "Kitab stockda qalamyib";
            }
            
        }

        

        private void btnBasket_Click(object sender, EventArgs e)
        {
            Users_rent_Books usrRentBook = new Users_rent_Books(this.selectedUser);
            usrRentBook.ShowDialog();
        }
    }
    

   

}
