using Management_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_System
{
    public partial class AddMovie : Form
    {
        public AddMovie()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie();
            movie.name = txtName.Text;
            movie.year = Int32.Parse(txtYear.Text);
            movie.type = txtType.Text;
            Movie.addMovie(movie);

            MessageBox.Show("Movie Added");

            txtName.Text = null;
            txtYear.Text = null;
            txtType.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Visible = true;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
