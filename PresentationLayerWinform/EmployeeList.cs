using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using Shared.Entities;



namespace PresentationLayerWinform
{
    public partial class EmployeeList : Form
    {
        public EmployeeList()
        {
            InitializeComponent();
            /*-------------------NO DESCOMENTAR, frutas!!
            BLEmployees empbl = new BLEmployees(dal) //no entiendo esta poronga tampoco;
            empbl.GetAllEmployees();
            Employee emp = new PartTimeEmployee();
            List<Employee> listEmp = new List<Employee>();
            listEmp = BLEmployees.GetAllEmpl..; //tendria que poder llamar al metodo getallemployees (no me doy cuenta 
            //Que estoy haciendo mal), para luego pasarlos a la lista con un foreach o while, pero como comente, soy una poronga y no encaro para traer las cosas de la
            //base con los metodos de las clases chagar estas..
            String ide = emp.Id.ToString();
            lstEmp.Items.Add(ide);
            ---------------------- */

            //Esto de aca abajo seria para crear el empleado, ya sea full o part time, y luego agregarlos a la listview que se va a mostrar en la pantalla inicial.
            //SUPONGO que habra que traer los datos de la bd y meterlos en los ftEmp con un if, dependiendo si son full o part, ya esta hecha la parte de la insercion
            //Faltaria traer los putos datos. Besos Rosita.

            Shared.Entities.FullTimeEmployee ftEmp = new Shared.Entities.FullTimeEmployee();
            Shared.Entities.PartTimeEmployee ptEmp = new Shared.Entities.PartTimeEmployee();
            lstEmp.Items.Add(new ListViewItem(new string[] { Convert.ToString(ftEmp.Id), Convert.ToString(ftEmp.Name), Convert.ToString(ftEmp.StartDate), "1" }));
            lstEmp.Items.Add(new ListViewItem(new string[] { Convert.ToString(ftEmp.Id), Convert.ToString(ftEmp.Name), Convert.ToString(ftEmp.StartDate), "2" }));

            //En lugar de los datos hardcodeados de aca abajo tengo que levantarlos de la bd y luego agregarlos a la lista (como intente hacer mas arriba x.x
            lstEmp.Items.Add(new ListViewItem(new string[] { "1", "nombre", "fecha", "tipo" }));
            lstEmp.Items.Add(new ListViewItem(new string[] { "2", "lalala", "tuvieja", "prueba" }));
            lstEmp.Items.Add(new ListViewItem(new string[] { "3", "tuhermana", "tuvieja", "tutia" }));
        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstEmp.SelectedItems.Count > 0)
                lstEmp.Items.RemoveAt(lstEmp.SelectedIndices[0]);
        }

        private void lstEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EmployeeAddEdit form2 = new EmployeeAddEdit();
            if (lstEmp.SelectedItems.Count > 0)
            {
                form2.txtId.Text = lstEmp.SelectedItems[0].Text;
                form2.txtId.Enabled = false;
                this.Hide();
                form2.ShowDialog();
            }                  
        }
    }
}
