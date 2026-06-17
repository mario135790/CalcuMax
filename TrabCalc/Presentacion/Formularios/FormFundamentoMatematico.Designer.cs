namespace TrabCalc
{
    partial class FormFundamentoMatematico
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
            this.pnlContenedor = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnCerrar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnIntegrales = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnDerivadas = new Guna.UI2.WinForms.Guna2GradientButton();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.Transparent;
            this.pnlContenedor.BorderColor = System.Drawing.Color.MidnightBlue;
            this.pnlContenedor.BorderRadius = 34;
            this.pnlContenedor.BorderThickness = 3;
            this.pnlContenedor.Controls.Add(this.btnCerrar);
            this.pnlContenedor.Controls.Add(this.btnIntegrales);
            this.pnlContenedor.Controls.Add(this.btnDerivadas);
            this.pnlContenedor.Controls.Add(this.panelContenido);
            this.pnlContenedor.Controls.Add(this.lblSubtitulo);
            this.pnlContenedor.Controls.Add(this.lblTitulo);
            this.pnlContenedor.FillColor = System.Drawing.Color.LightCyan;
            this.pnlContenedor.FillColor2 = System.Drawing.Color.LightSteelBlue;
            this.pnlContenedor.FillColor3 = System.Drawing.Color.CornflowerBlue;
            this.pnlContenedor.FillColor4 = System.Drawing.Color.DarkSlateGray;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 0);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.ShadowDecoration.Parent = this.pnlContenedor;
            this.pnlContenedor.Size = new System.Drawing.Size(900, 650);
            this.pnlContenedor.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.AutoRoundedCorners = true;
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BorderColor = System.Drawing.Color.Firebrick;
            this.btnCerrar.BorderRadius = 21;
            this.btnCerrar.BorderThickness = 3;
            this.btnCerrar.CheckedState.Parent = this.btnCerrar;
            this.btnCerrar.CustomImages.Parent = this.btnCerrar;
            this.btnCerrar.FillColor = System.Drawing.Color.LightGray;
            this.btnCerrar.FillColor2 = System.Drawing.Color.LightCoral;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.Black;
            this.btnCerrar.HoverState.BorderColor = System.Drawing.Color.Firebrick;
            this.btnCerrar.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnCerrar.HoverState.FillColor2 = System.Drawing.Color.IndianRed;
            this.btnCerrar.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.HoverState.Parent = this.btnCerrar;
            this.btnCerrar.Location = new System.Drawing.Point(374, 585);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.ShadowDecoration.Parent = this.btnCerrar;
            this.btnCerrar.Size = new System.Drawing.Size(152, 45);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Volver";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnIntegrales
            // 
            this.btnIntegrales.AutoRoundedCorners = true;
            this.btnIntegrales.BackColor = System.Drawing.Color.Transparent;
            this.btnIntegrales.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnIntegrales.BorderRadius = 19;
            this.btnIntegrales.BorderThickness = 3;
            this.btnIntegrales.CheckedState.Parent = this.btnIntegrales;
            this.btnIntegrales.CustomImages.Parent = this.btnIntegrales;
            this.btnIntegrales.FillColor = System.Drawing.Color.LightGray;
            this.btnIntegrales.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnIntegrales.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnIntegrales.ForeColor = System.Drawing.Color.Black;
            this.btnIntegrales.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnIntegrales.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnIntegrales.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnIntegrales.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnIntegrales.HoverState.Parent = this.btnIntegrales;
            this.btnIntegrales.Location = new System.Drawing.Point(462, 111);
            this.btnIntegrales.Name = "btnIntegrales";
            this.btnIntegrales.ShadowDecoration.Parent = this.btnIntegrales;
            this.btnIntegrales.Size = new System.Drawing.Size(170, 41);
            this.btnIntegrales.TabIndex = 4;
            this.btnIntegrales.Text = "Integrales";
            this.btnIntegrales.Click += new System.EventHandler(this.btnIntegrales_Click);
            // 
            // btnDerivadas
            // 
            this.btnDerivadas.AutoRoundedCorners = true;
            this.btnDerivadas.BackColor = System.Drawing.Color.Transparent;
            this.btnDerivadas.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnDerivadas.BorderRadius = 19;
            this.btnDerivadas.BorderThickness = 3;
            this.btnDerivadas.CheckedState.Parent = this.btnDerivadas;
            this.btnDerivadas.CustomImages.Parent = this.btnDerivadas;
            this.btnDerivadas.FillColor = System.Drawing.Color.LightGray;
            this.btnDerivadas.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnDerivadas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnDerivadas.ForeColor = System.Drawing.Color.Black;
            this.btnDerivadas.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnDerivadas.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnDerivadas.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnDerivadas.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnDerivadas.HoverState.Parent = this.btnDerivadas;
            this.btnDerivadas.Location = new System.Drawing.Point(268, 111);
            this.btnDerivadas.Name = "btnDerivadas";
            this.btnDerivadas.ShadowDecoration.Parent = this.btnDerivadas;
            this.btnDerivadas.Size = new System.Drawing.Size(170, 41);
            this.btnDerivadas.TabIndex = 3;
            this.btnDerivadas.Text = "Derivadas";
            this.btnDerivadas.Click += new System.EventHandler(this.btnDerivadas_Click);
            // 
            // panelContenido
            // 
            this.panelContenido.AutoScroll = true;
            this.panelContenido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContenido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContenido.Location = new System.Drawing.Point(42, 169);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(816, 395);
            this.panelContenido.TabIndex = 2;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSubtitulo.Location = new System.Drawing.Point(80, 67);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(740, 32);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Para que existe cada simulador, que calcula y como interpreta CalcuMax los resultados.";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitulo.Location = new System.Drawing.Point(80, 23);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(740, 38);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Fundamento matematico";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormFundamentoMatematico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.pnlContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormFundamentoMatematico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fundamento matematico";
            this.TransparencyKey = System.Drawing.Color.DarkBlue;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormFundamentoMatematico_KeyDown);
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlContenedor;
        private Guna.UI2.WinForms.Guna2GradientButton btnCerrar;
        private Guna.UI2.WinForms.Guna2GradientButton btnIntegrales;
        private Guna.UI2.WinForms.Guna2GradientButton btnDerivadas;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
    }
}
