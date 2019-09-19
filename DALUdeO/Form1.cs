using DALUdeO.DataClass;
using DALUdeO.Reader;
using Modelos.Persona;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DALUdeO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection Conexion = new MySqlConnection("server=localhost; database=odeodal;Uid=root;");
        DataSet ds;

        persona2 P;

        private void Button1_Click(object sender, EventArgs e)
        {
            PersonaModel personaModel = new PersonaModel();
            //personaModel.IdPersona = 1;
            personaModel.Apellido = "Shark";
            personaModel.Nombre = "Quintuss";
            personaModel.Direccion = "Zona 1";
            //personaModel.FecNac = DateTime.Now;
            PersonaReader reader = new PersonaReader(QuerysRepo.TipoQuery.AddRow, personaModel);
            Collection<PersonaModel> people = reader.Execute();

            foreach (PersonaModel p in people)
                MessageBox.Show(string.Format("{0}, {1}: {2}", p.Nombre, p.Apellido, p.Direccion));


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.actulizar();
        }

        public void actulizar()
        {
            Conexion.Open();
            MySqlCommand mostrar = new MySqlCommand("SELECT * FROM persona", Conexion);

            MySqlDataAdapter m_datos = new MySqlDataAdapter(mostrar);
            ds = new DataSet();
            m_datos.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            Conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.actulizar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            P = new persona2();

            if (P.Insertar())
            {
                if (P.Leer())
                {
                    dataGridView2.DataSource = P.Tabla;
                }
                
                 
            }
            else
            {
                MessageBox.Show("no llego");
            }
         
        }
    }
}
