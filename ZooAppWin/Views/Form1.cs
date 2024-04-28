using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooAppWin.Controllers;
using ZooAppWin.Models;

namespace ZooAppWin
{
    public partial class Form1 : Form
    {
        private AnimalController controller;
        private List<Animal> animals;
        public Form1()
        {
            InitializeComponent();
            animals = new List<Animal>(); 
            controller = new AnimalController();
        }
        private async void GetAnimals()
        {
            animals =await controller.All();
            if (animals != null)
            {
                foreach (var animal in animals)
                {
                    DataGridViewRow row= new DataGridViewRow();
                    row.CreateCells(dgvAnimals);
                    row.Cells[0].Value = animal.animalID;
                    row.Cells[1].Value = animal.nombre;
                    row.Cells[2].Value = animal.especie;
                    row.Cells[3].Value = animal.edad;
                    row.Cells[4].Value = animal.genero;
                    dgvAnimals.Rows.Add(row);
                }
            }else
            {
                MessageBox.Show("No se pudo obtener la peticion","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetAnimals();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
