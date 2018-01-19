namespace Library
{
    partial class Users_rent_Books
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgwRentBook = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwRentBook)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwRentBook
            // 
            this.dgwRentBook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwRentBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwRentBook.Location = new System.Drawing.Point(12, 42);
            this.dgwRentBook.Name = "dgwRentBook";
            this.dgwRentBook.Size = new System.Drawing.Size(617, 307);
            this.dgwRentBook.TabIndex = 0;
            this.dgwRentBook.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwRentBook_RowHeaderMouseDoubleClick);
            // 
            // Users_rent_Books
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 361);
            this.Controls.Add(this.dgwRentBook);
            this.Name = "Users_rent_Books";
            this.Text = "Users_rent_Books";
            ((System.ComponentModel.ISupportInitialize)(this.dgwRentBook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwRentBook;
    }
}