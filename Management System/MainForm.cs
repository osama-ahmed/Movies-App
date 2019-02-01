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
    public partial class MainForm : Form
    {
        List<Movie> movies;

        public MainForm()
        {
            InitializeComponent();

            movies = Movie.getMovies();

            //dataGridView1.DataSource = movies;

            dataGridView1.Columns.Add("name","Name");
            dataGridView1.Columns.Add("year", "Year");
            dataGridView1.Columns.Add("type", "Type");
            dataGridView1.Columns.Add("watched", "Watched?");
            dataGridView1.Columns.Add("update", "Update");
            dataGridView1.Columns.Add("delete", "Delete");

            foreach (Movie movie in movies)
            {
                dataGridView1.Rows.Add(movie.name,movie.year,movie.type,movie.watched?"Yes":"No");
            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMovie addMovie = new AddMovie();
            addMovie.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
