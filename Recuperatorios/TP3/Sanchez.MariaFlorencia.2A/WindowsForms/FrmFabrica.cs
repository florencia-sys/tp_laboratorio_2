using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using Entidades;

namespace WindowsForms
{
    public partial class FrmFabrica : Form
    {
        private SqlConnection cn;
        private SqlDataAdapter da;
        private DataTable dt;

        private Deposito<Golosina> miDeposito;
        public FrmFabrica()
        {
            InitializeComponent();

            this.miDeposito = new Deposito<Golosina>(100);
        }

        /// <summary>
        /// Agrega un nuevo caramelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCaramelos_Click(object sender, EventArgs e)
        {
            this.AgregarGolosina(sender, e);
        }

        /// <summary>
        /// Agrega un nuevo chocolate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChocolates_Click(object sender, EventArgs e)
        {
            this.AgregarGolosina(sender, e);
        }

        /// <summary>
        /// Agrega una nueva golosina a la fabrica segun lo que se solicite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AgregarGolosina(object sender, EventArgs e)
        {
            try
            {
                FrmGolosina frm = null;
                Button btn = (Button)sender;

                if (btn.Name == "btnCaramelos")
                {
                    frm = new FrmCaramelos();
                }
                if (btn.Name == "btnChocolates")
                {
                    frm = new FrmChocolates();
                }

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.miDeposito += frm.NuevaGolosina;

                    this.ListarPedidos();
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Ingresa los pedidos en el listbox
        /// </summary>
        public void ListarPedidos()
        {
            try
            {
                this.lstPedidos.Items.Clear();

                foreach (Golosina item in this.miDeposito.Lista)
                {
                    this.lstPedidos.Items.Add(item);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Pasa los productos de pedidos a fabricados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFabricar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstPedidos.SelectedItems != null)
                {
                    if (this.FabricacionGolosina())
                    {
                        List<Golosina> itemsRemover = new List<Golosina>();

                        foreach (Golosina item in this.lstPedidos.SelectedItems)
                        {
                            this.lstFabricados.Items.Add(item);
                            itemsRemover.Add(item);
                        }

                        foreach (Golosina item in itemsRemover)
                        {
                            this.lstPedidos.Items.Remove(item);
                        }
                    }
                    this.lstPedidos.Refresh();
                    this.lstFabricados.Refresh();
                }
                else
                {
                    MessageBox.Show("Seleccione un producto para fabricar", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Fabrica la golosina seleccionada si el deposito no esta lleno
        /// </summary>
        private bool FabricacionGolosina()
        {
            bool rta = false;
            try
            {
                Golosina golosina = (Golosina)this.lstPedidos.SelectedItem;
                int cantidadDeposito = miDeposito.TotalProductosFabricados();

                if (cantidadDeposito + golosina.Cantidad < miDeposito.Capacidad)
                {
                    MessageBox.Show("El producto ha sido fabricado con exito", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rta = true;
                }
                else
                {
                    throw new DepositoLlenoException();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return rta;
        }

        /// <summary>
        /// Elimina los item seleccionados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    int i = this.lstPedidos.SelectedIndex;

                    if (i > -1)
                    {
                        Deposito<Golosina> dep = this.miDeposito - this.miDeposito.Lista[i];

                        this.ListarPedidos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Abre el archivo txt y lo lee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Stream lector = this.openFileDialog1.OpenFile();
                    StreamReader sr = new StreamReader(lector);
                    while (sr.Peek() >= 0)
                    {
                        this.lstFabricados.Items.Add(Convert.ToString(sr.ReadLine()));
                    }
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Guarda el archivo txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string txt = this.saveFileDialog1.FileName;
                    StreamWriter sw = File.CreateText(txt);
                    foreach (Object item in this.lstFabricados.Items)
                    {
                        sw.WriteLine(item.ToString());
                    }
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ConectarConLaBase()
        {
            try
            {
                this.cn = new SqlConnection(@"Server= localhost\SQLEXPRESS; Database=master; Integrated Security=True");

                this.dt = new DataTable("Golosinas");

                this.dt.Columns.Add("id", typeof(int));
                this.dt.Columns.Add("nombre", typeof(string));
                this.dt.Columns.Add("sabor", typeof(string));
                this.dt.Columns.Add("cantidad", typeof(int));
                this.dt.Columns.Add("peso", typeof(double));

                this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

                this.dt.Columns["id"].AutoIncrement = true;
                this.dt.Columns["id"].AutoIncrementSeed = 1;
                this.dt.Columns["id"].AutoIncrementStep = 1;


                this.da = new SqlDataAdapter();
                this.da.SelectCommand = new SqlCommand("SELECT id, nombre, sabor, cantidad, peso FROM [tp4-productos].[dbo].[golosinas]", cn);

                this.da.Fill(this.dt);
                this.dgvBD.DataSource = this.dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmFabrica_Load(object sender, EventArgs e)
        {
            this.ConectarConLaBase();
        }
    }
}
