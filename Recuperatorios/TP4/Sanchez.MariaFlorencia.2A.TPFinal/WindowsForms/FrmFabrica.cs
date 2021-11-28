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
        private SqlDataReader dr;
        private SqlDataAdapter da;
        private DataTable dt;

        private Deposito<Golosina> miDeposito;
        private Golosina golosina;
        FrmProductoBD frmProd = new FrmProductoBD();
        string idProducto = null;
        public FrmFabrica()
        {
            InitializeComponent();

            this.miDeposito = new Deposito<Golosina>(100);

            this.dt = new DataTable("golosinas");
            this.dt.Columns.Add("id", typeof(int));
            this.dt.Columns.Add("nombre", typeof(string));
            this.dt.Columns.Add("sabor", typeof(string));
            this.dt.Columns.Add("cantidad", typeof(int));
            this.dt.Columns.Add("peso", typeof(double));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;
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

                if (golosina != null)
                {

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
                else
                {
                    MessageBox.Show("Debe seleccionar un producto de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return rta;
        }

        /// <summary>
        /// Elimina los items seleccionados
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

        /// <summary>
        /// Conecta con la base de datos y carga sus items en el datagridview
        /// </summary>
        private void ConectarConLaBase()
        {
            try
            {
                this.cn = new SqlConnection(@"Server= localhost\SQLEXPRESS; Database=master; Integrated Security=True");

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

        /// <summary>
        /// Configura el datagridview y conecta con la base antes que el formulario sea visible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFabrica_Load(object sender, EventArgs e)
        {
            dgvBD.RowHeadersVisible = false;
            dgvBD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBD.ReadOnly = true;
            dgvBD.AllowUserToAddRows = false;
            this.ConectarConLaBase();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {

        }

        private bool AgregarProducto()
        {
            bool rta = false;
            FrmProductoBD frmProd = new FrmProductoBD();
            frmProd.ShowDialog();
            this.cn = new SqlConnection(@"Server= localhost\SQLEXPRESS; Database=master; Integrated Security=True");

            SqlCommand comando = new SqlCommand();

            comando.Connection = cn;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO [tp4-productos].[dbo].[golosinas] (nombre, sabor, cantidad, peso) VALUES (@nombre, @sabor, @cantidad, @peso)";
            comando.Parameters.Add(new SqlParameter("@nombre", frmProd.txtNombre.Text));
            comando.Parameters.Add(new SqlParameter("@sabor", frmProd.txtSabor.Text));
            comando.Parameters.Add(new SqlParameter("@cantidad", frmProd.txtCantidad.Text));
            comando.Parameters.Add(new SqlParameter("@peso", frmProd.txtPeso.Text));

            try
            {
                cn.Open();
                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Se ha agregado el producto exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rta = true;
                }
                cn.Close();

                this.ConectarConLaBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw ex;
            }
            finally
            {
                if (this.cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return rta;
        }

        private bool ModificarProducto()
        {
            bool rta = false;
            FrmProductoBD frmProd = new FrmProductoBD();
            this.cn = new SqlConnection(@"Server= localhost\SQLEXPRESS; Database=master; Integrated Security=True");

            SqlCommand comando = new SqlCommand();

            if (dgvBD.SelectedRows.Count > 0)
            {
                idProducto = this.dgvBD.CurrentRow.Cells["id"].Value.ToString();
                frmProd.txtNombre.Text = this.dgvBD.CurrentRow.Cells["nombre"].Value.ToString();
                frmProd.txtSabor.Text = this.dgvBD.CurrentRow.Cells["sabor"].Value.ToString();
                frmProd.txtCantidad.Text = this.dgvBD.CurrentRow.Cells["cantidad"].Value.ToString();
                frmProd.txtPeso.Text = this.dgvBD.CurrentRow.Cells["peso"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }

            Golosina golosina = new Golosina();

            comando.Connection = cn;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE [tp4-productos].[dbo].[golosinas] SET nombre=@nombre, sabor=@sabor, cantidad=@cantidad, peso=@peso WHERE id=@id";

            frmProd.ShowDialog();
            comando.Parameters.Clear();
            comando.Parameters.Add(new SqlParameter("@id", idProducto));
            comando.Parameters.Add(new SqlParameter("@nombre", frmProd.txtNombre.Text));
            comando.Parameters.Add(new SqlParameter("@sabor", frmProd.txtSabor.Text));
            comando.Parameters.Add(new SqlParameter("@cantidad", frmProd.txtCantidad.Text));
            comando.Parameters.Add(new SqlParameter("@peso", frmProd.txtPeso.Text));

            try
            {
                cn.Open();
                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Se ha modificado el producto exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rta = true;
                }
                cn.Close();

                this.ConectarConLaBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw ex;
            }
            finally
            {
                if (this.cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return rta;
        }

        private bool EliminarProducto()
        {
            idProducto = null;
            bool rta = false;
            FrmProductoBD frmProd = new FrmProductoBD();
            this.cn = new SqlConnection(@"Server= localhost\SQLEXPRESS; Database=master; Integrated Security=True");

            SqlCommand comando = new SqlCommand();

            idProducto = this.dgvBD.CurrentRow.Cells["id"].Value.ToString();

            comando.Connection = cn;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM [tp4-productos].[dbo].[golosinas] WHERE id=@id";
            comando.Parameters.Clear();
            comando.Parameters.Add(new SqlParameter("@id", idProducto));

            try
            {
                cn.Open();
                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Se ha eliminado el producto exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rta = true;
                }
                cn.Close();
                
                this.ConectarConLaBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw ex;
            }
            finally
            {
                if (this.cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return rta;
        }

        /// <summary>
        /// Agrega un producto al datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarBD_Click(object sender, EventArgs e)
        {
            if(this.AgregarProducto())
            {
                MessageBox.Show("Se agrego el producto a la Base de Datos");
            }
            else
            {
                MessageBox.Show("NO se agrego el producto a la Base de Datos");
            }
        }

        /// <summary>
        /// Modifica un producto del datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarBD_Click(object sender, EventArgs e)
        {
            if (this.ModificarProducto())
            {
                MessageBox.Show("Se modificó el producto de la Base de Datos");
            }
            else
            {
                MessageBox.Show("NO se modificó el producto de la Base de Datos");
            }
        }

        /// <summary>
        /// Elimina un producto del datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarBD_Click(object sender, EventArgs e)
        {
            if (this.EliminarProducto())
            {
                MessageBox.Show("Se eliminó el producto de la Base de Datos");
            }
            else
            {
                MessageBox.Show("NO se eliminó el producto de la Base de Datos");
            }
        }

    }
}
