using System.Drawing;
using System.Windows.Forms;

namespace TrabCalc
{
    partial class FormProcedimiento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.btnSalir = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnCopiarProcedimiento = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnExportarPdf = new Guna.UI2.WinForms.Guna2GradientButton();
            this.pb2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pb2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.AutoScroll = true;
            this.panelContenido.BackColor = System.Drawing.Color.White;
            this.panelContenido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContenido.Location = new System.Drawing.Point(21, 25);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(851, 587);
            this.panelContenido.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.AutoRoundedCorners = true;
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.BorderColor = System.Drawing.Color.Firebrick;
            this.btnSalir.BorderRadius = 23;
            this.btnSalir.BorderThickness = 3;
            this.btnSalir.CheckedState.Parent = this.btnSalir;
            this.btnSalir.CustomImages.Parent = this.btnSalir;
            this.btnSalir.FillColor = System.Drawing.Color.LightGray;
            this.btnSalir.FillColor2 = System.Drawing.Color.LightCoral;
            this.btnSalir.Font = new System.Drawing.Font("Arial", 18F);
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.HoverState.BorderColor = System.Drawing.Color.Firebrick;
            this.btnSalir.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnSalir.HoverState.FillColor2 = System.Drawing.Color.IndianRed;
            this.btnSalir.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSalir.HoverState.Parent = this.btnSalir;
            this.btnSalir.Location = new System.Drawing.Point(10, 617);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.ShadowDecoration.Parent = this.btnSalir;
            this.btnSalir.Size = new System.Drawing.Size(150, 49);
            this.btnSalir.TabIndex = 36;
            this.btnSalir.Text = "Volver";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCopiarProcedimiento
            // 
            this.btnCopiarProcedimiento.AutoRoundedCorners = true;
            this.btnCopiarProcedimiento.BackColor = System.Drawing.Color.Transparent;
            this.btnCopiarProcedimiento.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCopiarProcedimiento.BorderRadius = 23;
            this.btnCopiarProcedimiento.BorderThickness = 3;
            this.btnCopiarProcedimiento.CheckedState.Parent = this.btnCopiarProcedimiento;
            this.btnCopiarProcedimiento.CustomImages.Parent = this.btnCopiarProcedimiento;
            this.btnCopiarProcedimiento.FillColor = System.Drawing.Color.LightGray;
            this.btnCopiarProcedimiento.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnCopiarProcedimiento.Font = new System.Drawing.Font("Arial", 18F);
            this.btnCopiarProcedimiento.ForeColor = System.Drawing.Color.Black;
            this.btnCopiarProcedimiento.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCopiarProcedimiento.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnCopiarProcedimiento.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnCopiarProcedimiento.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCopiarProcedimiento.HoverState.Parent = this.btnCopiarProcedimiento;
            this.btnCopiarProcedimiento.Location = new System.Drawing.Point(170, 617);
            this.btnCopiarProcedimiento.Name = "btnCopiarProcedimiento";
            this.btnCopiarProcedimiento.ShadowDecoration.Parent = this.btnCopiarProcedimiento;
            this.btnCopiarProcedimiento.Size = new System.Drawing.Size(150, 49);
            this.btnCopiarProcedimiento.TabIndex = 37;
            this.btnCopiarProcedimiento.Text = "Copiar";
            this.btnCopiarProcedimiento.Click += new System.EventHandler(this.btnCopiarProcedimiento_Click);
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.AutoRoundedCorners = true;
            this.btnExportarPdf.BackColor = System.Drawing.Color.Transparent;
            this.btnExportarPdf.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportarPdf.BorderRadius = 23;
            this.btnExportarPdf.BorderThickness = 3;
            this.btnExportarPdf.CheckedState.Parent = this.btnExportarPdf;
            this.btnExportarPdf.CustomImages.Parent = this.btnExportarPdf;
            this.btnExportarPdf.FillColor = System.Drawing.Color.LightGray;
            this.btnExportarPdf.FillColor2 = System.Drawing.Color.MediumSeaGreen;
            this.btnExportarPdf.Font = new System.Drawing.Font("Arial", 18F);
            this.btnExportarPdf.ForeColor = System.Drawing.Color.Black;
            this.btnExportarPdf.HoverState.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportarPdf.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnExportarPdf.HoverState.FillColor2 = System.Drawing.Color.MediumSeaGreen;
            this.btnExportarPdf.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnExportarPdf.HoverState.Parent = this.btnExportarPdf;
            this.btnExportarPdf.Location = new System.Drawing.Point(330, 617);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.ShadowDecoration.Parent = this.btnExportarPdf;
            this.btnExportarPdf.Size = new System.Drawing.Size(150, 49);
            this.btnExportarPdf.TabIndex = 38;
            this.btnExportarPdf.Text = "PDF";
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // pb2
            // 
            this.pb2.BorderColor = System.Drawing.Color.MidnightBlue;
            this.pb2.BorderRadius = 40;
            this.pb2.BorderThickness = 3;
            this.pb2.Controls.Add(this.btnExportarPdf);
            this.pb2.Controls.Add(this.btnCopiarProcedimiento);
            this.pb2.Controls.Add(this.btnSalir);
            this.pb2.Controls.Add(this.panelContenido);
            this.pb2.FillColor2 = System.Drawing.Color.CornflowerBlue;
            this.pb2.FillColor3 = System.Drawing.Color.DarkCyan;
            this.pb2.FillColor4 = System.Drawing.Color.DarkSlateGray;
            this.pb2.Location = new System.Drawing.Point(0, 0);
            this.pb2.Name = "pb2";
            this.pb2.ShadowDecoration.Parent = this.pb2;
            this.pb2.Size = new System.Drawing.Size(884, 682);
            this.pb2.TabIndex = 45;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 20;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FormProcedimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(884, 681);
            this.Controls.Add(this.pb2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProcedimiento";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Procedimiento Matemático - Aplicación de Integrales";
            this.Load += new System.EventHandler(this.FormProcedimiento_Load);
            this.pb2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton btnSalir;
        private Guna.UI2.WinForms.Guna2GradientButton btnCopiarProcedimiento;
        private Guna.UI2.WinForms.Guna2GradientButton btnExportarPdf;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pb2;
        private Timer timer1;
        private Timer timer2;
    }
}
