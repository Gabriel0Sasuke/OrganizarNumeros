namespace OrganizarNumeros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnFacil_Click(object sender, EventArgs e)
        {
            this.Hide();
            var FacilForm = new Facil();
            FacilForm.FormClosed += (s, args) => this.Show();
            FacilForm.Show();
        }
    }
}
