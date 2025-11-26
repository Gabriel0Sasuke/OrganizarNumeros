namespace OrganizarNumeros
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            BtnFacil = new Button();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            BtnMedio = new Button();
            BtnDificil = new Button();
            BtnSair = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // BtnFacil
            // 
            BtnFacil.BackColor = Color.FromArgb(168, 230, 207);
            BtnFacil.Cursor = Cursors.Hand;
            BtnFacil.FlatAppearance.BorderSize = 0;
            BtnFacil.FlatStyle = FlatStyle.Flat;
            BtnFacil.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BtnFacil.ForeColor = Color.Black;
            BtnFacil.Location = new Point(196, 136);
            BtnFacil.Name = "BtnFacil";
            BtnFacil.Size = new Size(398, 54);
            BtnFacil.TabIndex = 0;
            BtnFacil.Text = "Fácil";
            BtnFacil.UseVisualStyleBackColor = false;
            BtnFacil.Click += BtnFacil_Click;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 70);
            label1.TabIndex = 1;
            label1.Text = "Jogo de Ordenar Numeros";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ActiveCaptionText;
            flowLayoutPanel1.Location = new Point(149, 57);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(500, 5);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(260, 83);
            label2.Name = "label2";
            label2.Size = new Size(264, 32);
            label2.TabIndex = 3;
            label2.Text = "Escolha sua Dificuldade";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnMedio
            // 
            BtnMedio.BackColor = Color.FromArgb(255, 226, 154);
            BtnMedio.Cursor = Cursors.Hand;
            BtnMedio.FlatAppearance.BorderSize = 0;
            BtnMedio.FlatStyle = FlatStyle.Flat;
            BtnMedio.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BtnMedio.ForeColor = Color.Black;
            BtnMedio.Location = new Point(196, 198);
            BtnMedio.Name = "BtnMedio";
            BtnMedio.Size = new Size(398, 54);
            BtnMedio.TabIndex = 4;
            BtnMedio.Text = "Medio";
            BtnMedio.UseVisualStyleBackColor = false;
            BtnMedio.Click += BtnMedio_Click;
            // 
            // BtnDificil
            // 
            BtnDificil.BackColor = Color.FromArgb(255, 173, 173);
            BtnDificil.Cursor = Cursors.Hand;
            BtnDificil.FlatAppearance.BorderSize = 0;
            BtnDificil.FlatStyle = FlatStyle.Flat;
            BtnDificil.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BtnDificil.ForeColor = Color.Black;
            BtnDificil.Location = new Point(196, 258);
            BtnDificil.Name = "BtnDificil";
            BtnDificil.Size = new Size(398, 54);
            BtnDificil.TabIndex = 5;
            BtnDificil.Text = "Dificil";
            BtnDificil.UseVisualStyleBackColor = false;
            BtnDificil.Click += BtnDificil_Click;
            // 
            // BtnSair
            // 
            BtnSair.Font = new Font("Segoe UI", 12F);
            BtnSair.Location = new Point(196, 329);
            BtnSair.Name = "BtnSair";
            BtnSair.Size = new Size(398, 54);
            BtnSair.TabIndex = 6;
            BtnSair.Text = "Sair";
            BtnSair.UseVisualStyleBackColor = true;
            BtnSair.Click += BtnSair_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = SystemColors.ActiveCaptionText;
            flowLayoutPanel2.Location = new Point(149, 318);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(500, 5);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(BtnSair);
            Controls.Add(BtnDificil);
            Controls.Add(BtnMedio);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(BtnFacil);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Jogo - Organizar Numeros";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnFacil;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private Button BtnMedio;
        private Button BtnDificil;
        private Button BtnSair;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}
