namespace TrabCalc
{
    partial class FormDialogoApp
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
            this.btnCancelar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnAceptar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.Transparent;
            this.pnlContenedor.BorderColor = System.Drawing.Color.MidnightBlue;
            this.pnlContenedor.BorderRadius = 28;
            this.pnlContenedor.BorderThickness = 3;
            this.pnlContenedor.Controls.Add(this.btnCancelar);
            this.pnlContenedor.Controls.Add(this.btnAceptar);
            this.pnlContenedor.Controls.Add(this.lblMensaje);
            this.pnlContenedor.Controls.Add(this.lblTitulo);
            this.pnlContenedor.FillColor = System.Drawing.Color.LightCyan;
            this.pnlContenedor.FillColor2 = System.Drawing.Color.LightSteelBlue;
            this.pnlContenedor.FillColor3 = System.Drawing.Color.CornflowerBlue;
            this.pnlContenedor.FillColor4 = System.Drawing.Color.DarkSlateGray;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 0);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.ShadowDecoration.Parent = this.pnlContenedor;
            this.pnlContenedor.Size = new System.Drawing.Size(520, 230);
            this.pnlContenedor.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoRoundedCorners = true;
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BorderColor = System.Drawing.Color.Firebrick;
            this.btnCancelar.BorderRadius = 21;
            this.btnCancelar.BorderThickness = 3;
            this.btnCancelar.CheckedState.Parent = this.btnCancelar;
            this.btnCancelar.CustomImages.Parent = this.btnCancelar;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FillColor = System.Drawing.Color.LightGray;
            this.btnCancelar.FillColor2 = System.Drawing.Color.LightCoral;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.HoverState.BorderColor = System.Drawing.Color.Firebrick;
            this.btnCancelar.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnCancelar.HoverState.FillColor2 = System.Drawing.Color.IndianRed;
            this.btnCancelar.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.HoverState.Parent = this.btnCancelar;
            this.btnCancelar.Location = new System.Drawing.Point(198, 167);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.ShadowDecoration.Parent = this.btnCancelar;
            this.btnCancelar.Size = new System.Drawing.Size(123, 45);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Volver";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoRoundedCorners = true;
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAceptar.BorderRadius = 21;
            this.btnAceptar.BorderThickness = 3;
            this.btnAceptar.CheckedState.Parent = this.btnAceptar;
            this.btnAceptar.CustomImages.Parent = this.btnAceptar;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.FillColor = System.Drawing.Color.LightGray;
            this.btnAceptar.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnAceptar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAceptar.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnAceptar.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnAceptar.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.HoverState.Parent = this.btnAceptar;
            this.btnAceptar.Location = new System.Drawing.Point(336, 167);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.ShadowDecoration.Parent = this.btnAceptar;
            this.btnAceptar.Size = new System.Drawing.Size(151, 45);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.BackColor = System.Drawing.Color.Transparent;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMensaje.ForeColor = System.Drawing.Color.Black;
            this.lblMensaje.Location = new System.Drawing.Point(31, 67);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(456, 86);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "Mensaje";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitulo.Location = new System.Drawing.Point(30, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(77, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título";
            // 
            // FormDialogoApp
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(520, 230);
            this.Controls.Add(this.pnlContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormDialogoApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dialogo";
            this.TransparencyKey = System.Drawing.Color.DarkBlue;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormDialogoApp_KeyDown);
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlContenedor;
        private Guna.UI2.WinForms.Guna2GradientButton btnCancelar;
        private Guna.UI2.WinForms.Guna2GradientButton btnAceptar;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblTitulo;
    }
}
