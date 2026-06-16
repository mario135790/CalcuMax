namespace TrabCalc
{
    partial class FormMenuSimuladores
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerEntrada = new System.Windows.Forms.Timer(this.components);
            this.timerSalida = new System.Windows.Forms.Timer(this.components);
            this.pnlPrincipal = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnVolver = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnBombaAgua = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnMovimiento = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lblIntegrales = new System.Windows.Forms.Label();
            this.lblDerivadas = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pictureBoxBurbujas = new System.Windows.Forms.PictureBox();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBurbujas)).BeginInit();
            this.SuspendLayout();
            // 
            // timerEntrada
            // 
            this.timerEntrada.Interval = 20;
            this.timerEntrada.Tick += new System.EventHandler(this.timerEntrada_Tick);
            // 
            // timerSalida
            // 
            this.timerSalida.Interval = 20;
            this.timerSalida.Tick += new System.EventHandler(this.timerSalida_Tick);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BorderColor = System.Drawing.Color.MidnightBlue;
            this.pnlPrincipal.BorderRadius = 40;
            this.pnlPrincipal.BorderThickness = 3;
            this.pnlPrincipal.Controls.Add(this.guna2PictureBox2);
            this.pnlPrincipal.Controls.Add(this.guna2PictureBox3);
            this.pnlPrincipal.Controls.Add(this.btnVolver);
            this.pnlPrincipal.Controls.Add(this.btnBombaAgua);
            this.pnlPrincipal.Controls.Add(this.btnMovimiento);
            this.pnlPrincipal.Controls.Add(this.lblIntegrales);
            this.pnlPrincipal.Controls.Add(this.lblDerivadas);
            this.pnlPrincipal.Controls.Add(this.lblTitulo);
            this.pnlPrincipal.Controls.Add(this.pictureBoxBurbujas);
            this.pnlPrincipal.FillColor2 = System.Drawing.Color.CornflowerBlue;
            this.pnlPrincipal.FillColor3 = System.Drawing.Color.DarkCyan;
            this.pnlPrincipal.FillColor4 = System.Drawing.Color.DarkSlateGray;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.ShadowDecoration.Parent = this.pnlPrincipal;
            this.pnlPrincipal.Size = new System.Drawing.Size(800, 450);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = global::TrabCalc.Properties.Resources.tec3;
            this.guna2PictureBox2.Location = new System.Drawing.Point(23, 25);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.ShadowDecoration.Parent = this.guna2PictureBox2;
            this.guna2PictureBox2.Size = new System.Drawing.Size(76, 78);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 68;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox3.Image = global::TrabCalc.Properties.Resources.tec1;
            this.guna2PictureBox3.Location = new System.Drawing.Point(94, 25);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.ShadowDecoration.Parent = this.guna2PictureBox3;
            this.guna2PictureBox3.Size = new System.Drawing.Size(76, 78);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox3.TabIndex = 67;
            this.guna2PictureBox3.TabStop = false;
            // 
            // btnVolver
            // 
            this.btnVolver.AutoRoundedCorners = true;
            this.btnVolver.BackColor = System.Drawing.Color.Transparent;
            this.btnVolver.BorderColor = System.Drawing.Color.Firebrick;
            this.btnVolver.BorderRadius = 23;
            this.btnVolver.BorderThickness = 3;
            this.btnVolver.CheckedState.Parent = this.btnVolver;
            this.btnVolver.CustomImages.Parent = this.btnVolver;
            this.btnVolver.FillColor = System.Drawing.Color.LightGray;
            this.btnVolver.FillColor2 = System.Drawing.Color.LightCoral;
            this.btnVolver.Font = new System.Drawing.Font("Arial", 18F);
            this.btnVolver.ForeColor = System.Drawing.Color.Black;
            this.btnVolver.HoverState.BorderColor = System.Drawing.Color.Firebrick;
            this.btnVolver.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnVolver.HoverState.FillColor2 = System.Drawing.Color.IndianRed;
            this.btnVolver.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnVolver.HoverState.Parent = this.btnVolver;
            this.btnVolver.Location = new System.Drawing.Point(286, 354);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.ShadowDecoration.Parent = this.btnVolver;
            this.btnVolver.Size = new System.Drawing.Size(220, 49);
            this.btnVolver.TabIndex = 66;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            this.btnVolver.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // btnBombaAgua
            // 
            this.btnBombaAgua.BackColor = System.Drawing.Color.Transparent;
            this.btnBombaAgua.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnBombaAgua.BorderRadius = 27;
            this.btnBombaAgua.BorderThickness = 3;
            this.btnBombaAgua.CheckedState.Parent = this.btnBombaAgua;
            this.btnBombaAgua.CustomImages.Parent = this.btnBombaAgua;
            this.btnBombaAgua.FillColor = System.Drawing.Color.LightGray;
            this.btnBombaAgua.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnBombaAgua.Font = new System.Drawing.Font("Arial", 17F);
            this.btnBombaAgua.ForeColor = System.Drawing.Color.Black;
            this.btnBombaAgua.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnBombaAgua.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnBombaAgua.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnBombaAgua.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnBombaAgua.HoverState.Parent = this.btnBombaAgua;
            this.btnBombaAgua.Location = new System.Drawing.Point(82, 171);
            this.btnBombaAgua.Name = "btnBombaAgua";
            this.btnBombaAgua.ShadowDecoration.Parent = this.btnBombaAgua;
            this.btnBombaAgua.Size = new System.Drawing.Size(300, 66);
            this.btnBombaAgua.TabIndex = 65;
            this.btnBombaAgua.Text = "Bomba de Agua";
            this.btnBombaAgua.Click += new System.EventHandler(this.btnBombaAgua_Click);
            this.btnBombaAgua.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // btnMovimiento
            // 
            this.btnMovimiento.BackColor = System.Drawing.Color.Transparent;
            this.btnMovimiento.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnMovimiento.BorderRadius = 27;
            this.btnMovimiento.BorderThickness = 3;
            this.btnMovimiento.CheckedState.Parent = this.btnMovimiento;
            this.btnMovimiento.CustomImages.Parent = this.btnMovimiento;
            this.btnMovimiento.FillColor = System.Drawing.Color.LightGray;
            this.btnMovimiento.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnMovimiento.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMovimiento.ForeColor = System.Drawing.Color.Black;
            this.btnMovimiento.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnMovimiento.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnMovimiento.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnMovimiento.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnMovimiento.HoverState.Parent = this.btnMovimiento;
            this.btnMovimiento.Location = new System.Drawing.Point(391, 171);
            this.btnMovimiento.Name = "btnMovimiento";
            this.btnMovimiento.ShadowDecoration.Parent = this.btnMovimiento;
            this.btnMovimiento.Size = new System.Drawing.Size(327, 66);
            this.btnMovimiento.TabIndex = 64;
            this.btnMovimiento.Text = "Movimiento Uniformemente Acelerado";
            this.btnMovimiento.Click += new System.EventHandler(this.btnMovimiento_Click);
            this.btnMovimiento.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // lblIntegrales
            // 
            this.lblIntegrales.BackColor = System.Drawing.Color.Transparent;
            this.lblIntegrales.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblIntegrales.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblIntegrales.Location = new System.Drawing.Point(462, 113);
            this.lblIntegrales.Name = "lblIntegrales";
            this.lblIntegrales.Size = new System.Drawing.Size(185, 55);
            this.lblIntegrales.TabIndex = 63;
            this.lblIntegrales.Text = "Integrales";
            this.lblIntegrales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDerivadas
            // 
            this.lblDerivadas.BackColor = System.Drawing.Color.Transparent;
            this.lblDerivadas.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblDerivadas.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDerivadas.Location = new System.Drawing.Point(141, 113);
            this.lblDerivadas.Name = "lblDerivadas";
            this.lblDerivadas.Size = new System.Drawing.Size(182, 55);
            this.lblDerivadas.TabIndex = 62;
            this.lblDerivadas.Text = "Derivadas";
            this.lblDerivadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 34F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitulo.Location = new System.Drawing.Point(195, 43);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(410, 70);
            this.lblTitulo.TabIndex = 61;
            this.lblTitulo.Text = "Simuladores";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxBurbujas
            // 
            this.pictureBoxBurbujas.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBurbujas.Image = global::TrabCalc.Properties.Resources.Burbujas;
            this.pictureBoxBurbujas.Location = new System.Drawing.Point(5, 5);
            this.pictureBoxBurbujas.Name = "pictureBoxBurbujas";
            this.pictureBoxBurbujas.Size = new System.Drawing.Size(790, 440);
            this.pictureBoxBurbujas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBurbujas.TabIndex = 60;
            this.pictureBoxBurbujas.TabStop = false;
            // 
            // FormMenuSimuladores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMenuSimuladores";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú de simuladores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMenuSimuladores_FormClosing);
            this.Load += new System.EventHandler(this.FormMenuSimuladores_Load);
            this.pnlPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBurbujas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerEntrada;
        private System.Windows.Forms.Timer timerSalida;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlPrincipal;
        private System.Windows.Forms.PictureBox pictureBoxBurbujas;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIntegrales;
        private System.Windows.Forms.Label lblDerivadas;
        private Guna.UI2.WinForms.Guna2GradientButton btnMovimiento;
        private Guna.UI2.WinForms.Guna2GradientButton btnBombaAgua;
        private Guna.UI2.WinForms.Guna2GradientButton btnVolver;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
    }
}
