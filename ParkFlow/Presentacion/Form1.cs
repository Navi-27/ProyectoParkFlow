using ParkFlow.Presentacion;
using ParkFlow.Tools;
namespace ParkFlow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listaResidentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tool.openForm<FrResidente>(this);
        }
    }
}
