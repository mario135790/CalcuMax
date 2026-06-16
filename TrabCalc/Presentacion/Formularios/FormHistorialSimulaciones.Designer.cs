namespace TrabCalc
{
    partial class FormHistorialSimulaciones
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
            this.btnExportar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnCopiar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.lstRegistros = new System.Windows.Forms.ListBox();
            this.cmbFiltro = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblFiltro = new System.Windows.Forms.Label();
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
            this.pnlContenedor.Controls.Add(this.btnExportar);
            this.pnlContenedor.Controls.Add(this.btnLimpiar);
            this.pnlContenedor.Controls.Add(this.btnCopiar);
            this.pnlContenedor.Controls.Add(this.txtDetalle);
            this.pnlContenedor.Controls.Add(this.lstRegistros);
            this.pnlContenedor.Controls.Add(this.cmbFiltro);
            this.pnlContenedor.Controls.Add(this.lblFiltro);
            this.pnlContenedor.Controls.Add(this.lblTitulo);
            this.pnlContenedor.FillColor = System.Drawing.Color.LightCyan;
            this.pnlContenedor.FillColor2 = System.Drawing.Color.LightSteelBlue;
            this.pnlContenedor.FillColor3 = System.Drawing.Color.CornflowerBlue;
            this.pnlContenedor.FillColor4 = System.Drawing.Color.DarkSlateGray;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 0);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.ShadowDecoration.Parent = this.pnlContenedor;
            this.pnlContenedor.Size = new System.Drawing.Size(760, 430);
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
            this.btnCerrar.Location = new System.Drawing.Point(29, 363);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.ShadowDecoration.Parent = this.btnCerrar;
            this.btnCerrar.Size = new System.Drawing.Size(128, 45);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Volver";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.AutoRoundedCorners = true;
            this.btnExportar.BackColor = System.Drawing.Color.Transparent;
            this.btnExportar.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportar.BorderRadius = 21;
            this.btnExportar.BorderThickness = 3;
            this.btnExportar.CheckedState.Parent = this.btnExportar;
            this.btnExportar.CustomImages.Parent = this.btnExportar;
            this.btnExportar.FillColor = System.Drawing.Color.LightGray;
            this.btnExportar.FillColor2 = System.Drawing.Color.MediumSeaGreen;
            this.btnExportar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.Black;
            this.btnExportar.HoverState.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportar.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnExportar.HoverState.FillColor2 = System.Drawing.Color.MediumSeaGreen;
            this.btnExportar.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnExportar.HoverState.Parent = this.btnExportar;
            this.btnExportar.Location = new System.Drawing.Point(317, 363);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.ShadowDecoration.Parent = this.btnExportar;
            this.btnExportar.Size = new System.Drawing.Size(128, 45);
            this.btnExportar.TabIndex = 8;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AutoRoundedCorners = true;
            this.btnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.BorderColor = System.Drawing.Color.Firebrick;
            this.btnLimpiar.BorderRadius = 21;
            this.btnLimpiar.BorderThickness = 3;
            this.btnLimpiar.CheckedState.Parent = this.btnLimpiar;
            this.btnLimpiar.CustomImages.Parent = this.btnLimpiar;
            this.btnLimpiar.FillColor = System.Drawing.Color.LightGray;
            this.btnLimpiar.FillColor2 = System.Drawing.Color.LightCoral;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar.HoverState.BorderColor = System.Drawing.Color.Firebrick;
            this.btnLimpiar.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnLimpiar.HoverState.FillColor2 = System.Drawing.Color.IndianRed;
            this.btnLimpiar.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.HoverState.Parent = this.btnLimpiar;
            this.btnLimpiar.Location = new System.Drawing.Point(461, 363);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.ShadowDecoration.Parent = this.btnLimpiar;
            this.btnLimpiar.Size = new System.Drawing.Size(128, 45);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCopiar
            // 
            this.btnCopiar.AutoRoundedCorners = true;
            this.btnCopiar.BackColor = System.Drawing.Color.Transparent;
            this.btnCopiar.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCopiar.BorderRadius = 21;
            this.btnCopiar.BorderThickness = 3;
            this.btnCopiar.CheckedState.Parent = this.btnCopiar;
            this.btnCopiar.CustomImages.Parent = this.btnCopiar;
            this.btnCopiar.FillColor = System.Drawing.Color.LightGray;
            this.btnCopiar.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnCopiar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCopiar.ForeColor = System.Drawing.Color.Black;
            this.btnCopiar.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCopiar.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnCopiar.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnCopiar.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCopiar.HoverState.Parent = this.btnCopiar;
            this.btnCopiar.Location = new System.Drawing.Point(604, 363);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.ShadowDecoration.Parent = this.btnCopiar;
            this.btnCopiar.Size = new System.Drawing.Size(128, 45);
            this.btnCopiar.TabIndex = 3;
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // txtDetalle
            // 
            this.txtDetalle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalle.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtDetalle.Location = new System.Drawing.Point(292, 76);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.ReadOnly = true;
            this.txtDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalle.Size = new System.Drawing.Size(440, 268);
            this.txtDetalle.TabIndex = 2;
            // 
            // lstRegistros
            // 
            this.lstRegistros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstRegistros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRegistros.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstRegistros.FormattingEnabled = true;
            this.lstRegistros.ItemHeight = 17;
            this.lstRegistros.Location = new System.Drawing.Point(29, 76);
            this.lstRegistros.Name = "lstRegistros";
            this.lstRegistros.Size = new System.Drawing.Size(244, 274);
            this.lstRegistros.TabIndex = 1;
            this.lstRegistros.SelectedIndexChanged += new System.EventHandler(this.lstRegistros_SelectedIndexChanged);
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.AutoRoundedCorners = true;
            this.cmbFiltro.BackColor = System.Drawing.Color.Transparent;
            this.cmbFiltro.BorderColor = System.Drawing.Color.Black;
            this.cmbFiltro.BorderRadius = 17;
            this.cmbFiltro.BorderThickness = 2;
            this.cmbFiltro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.FocusedColor = System.Drawing.Color.Empty;
            this.cmbFiltro.FocusedState.Parent = this.cmbFiltro;
            this.cmbFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFiltro.ForeColor = System.Drawing.Color.Black;
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.HoverState.Parent = this.cmbFiltro;
            this.cmbFiltro.ItemHeight = 30;
            this.cmbFiltro.Items.AddRange(new object[] {
            "Todos",
            "Derivadas",
            "Integrales"});
            this.cmbFiltro.ItemsAppearance.Parent = this.cmbFiltro;
            this.cmbFiltro.Location = new System.Drawing.Point(580, 24);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.ShadowDecoration.Parent = this.cmbFiltro;
            this.cmbFiltro.Size = new System.Drawing.Size(152, 36);
            this.cmbFiltro.TabIndex = 7;
            this.cmbFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.BackColor = System.Drawing.Color.Transparent;
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFiltro.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblFiltro.Location = new System.Drawing.Point(520, 31);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(54, 21);
            this.lblFiltro.TabIndex = 6;
            this.lblFiltro.Text = "Filtro:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitulo.Location = new System.Drawing.Point(28, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(271, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Historial de simulaciones";
            // 
            // FormHistorialSimulaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(760, 430);
            this.Controls.Add(this.pnlContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormHistorialSimulaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historial de simulaciones";
            this.TransparencyKey = System.Drawing.Color.DarkBlue;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormHistorialSimulaciones_KeyDown);
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlContenedor;
        private Guna.UI2.WinForms.Guna2GradientButton btnCerrar;
        private Guna.UI2.WinForms.Guna2GradientButton btnExportar;
        private Guna.UI2.WinForms.Guna2GradientButton btnLimpiar;
        private Guna.UI2.WinForms.Guna2GradientButton btnCopiar;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.ListBox lstRegistros;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Label lblTitulo;
    }
}
