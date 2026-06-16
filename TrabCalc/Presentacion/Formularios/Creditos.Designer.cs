using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;


namespace TrabCalc
{
    partial class Creditos
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
            this.pb2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox3 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnSalir = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Trabajadores = new System.Windows.Forms.GroupBox();
            this.pb1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lb1 = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pb2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).BeginInit();
            this.Trabajadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pb2
            // 
            this.pb2.BorderColor = System.Drawing.Color.MidnightBlue;
            this.pb2.BorderRadius = 40;
            this.pb2.BorderThickness = 3;
            this.pb2.Controls.Add(this.guna2PictureBox3);
            this.pb2.Controls.Add(this.guna2PictureBox2);
            this.pb2.Controls.Add(this.groupBox2);
            this.pb2.Controls.Add(this.btnSalir);
            this.pb2.Controls.Add(this.Trabajadores);
            this.pb2.FillColor2 = System.Drawing.Color.CornflowerBlue;
            this.pb2.FillColor3 = System.Drawing.Color.DarkCyan;
            this.pb2.FillColor4 = System.Drawing.Color.DarkSlateGray;
            this.pb2.Location = new System.Drawing.Point(0, 0);
            this.pb2.Name = "pb2";
            this.pb2.ShadowDecoration.Parent = this.pb2;
            this.pb2.Size = new System.Drawing.Size(800, 593);
            this.pb2.TabIndex = 2;
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox3.Image = global::TrabCalc.Properties.Resources.tec1;
            this.guna2PictureBox3.Location = new System.Drawing.Point(588, 343);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.ShadowDecoration.Parent = this.guna2PictureBox3;
            this.guna2PictureBox3.Size = new System.Drawing.Size(173, 190);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox3.TabIndex = 60;
            this.guna2PictureBox3.TabStop = false;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = global::TrabCalc.Properties.Resources.tec3;
            this.guna2PictureBox2.Location = new System.Drawing.Point(12, 343);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.ShadowDecoration.Parent = this.guna2PictureBox2;
            this.guna2PictureBox2.Size = new System.Drawing.Size(184, 181);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 59;
            this.guna2PictureBox2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.guna2CirclePictureBox3);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(202, 334);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 168);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "El Angel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 17.25F);
            this.label2.Location = new System.Drawing.Point(19, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 52);
            this.label2.TabIndex = 47;
            this.label2.Text = "Angel Manuel Nuñez Romero\r\n22310713 - Programación Extra";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2CirclePictureBox3
            // 
            this.guna2CirclePictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox3.Image = global::TrabCalc.Properties.Resources.Angel;
            this.guna2CirclePictureBox3.Location = new System.Drawing.Point(172, 75);
            this.guna2CirclePictureBox3.Name = "guna2CirclePictureBox3";
            this.guna2CirclePictureBox3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox3.ShadowDecoration.Parent = this.guna2CirclePictureBox3;
            this.guna2CirclePictureBox3.Size = new System.Drawing.Size(35, 29);
            this.guna2CirclePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox3.TabIndex = 46;
            this.guna2CirclePictureBox3.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.AutoRoundedCorners = true;
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSalir.BorderRadius = 23;
            this.btnSalir.BorderThickness = 3;
            this.btnSalir.CheckedState.Parent = this.btnSalir;
            this.btnSalir.CustomImages.Parent = this.btnSalir;
            this.btnSalir.FillColor = System.Drawing.Color.LightGray;
            this.btnSalir.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnSalir.Font = new System.Drawing.Font("Arial", 18F);
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSalir.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnSalir.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnSalir.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSalir.HoverState.Parent = this.btnSalir;
            this.btnSalir.Location = new System.Drawing.Point(275, 508);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.ShadowDecoration.Parent = this.btnSalir;
            this.btnSalir.Size = new System.Drawing.Size(245, 49);
            this.btnSalir.TabIndex = 35;
            this.btnSalir.Text = "Volver";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // Trabajadores
            // 
            this.Trabajadores.BackColor = System.Drawing.Color.Transparent;
            this.Trabajadores.Controls.Add(this.pb1);
            this.Trabajadores.Controls.Add(this.lb1);
            this.Trabajadores.Controls.Add(this.lb2);
            this.Trabajadores.Controls.Add(this.guna2CirclePictureBox1);
            this.Trabajadores.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Trabajadores.Location = new System.Drawing.Point(12, 38);
            this.Trabajadores.Name = "Trabajadores";
            this.Trabajadores.Size = new System.Drawing.Size(778, 267);
            this.Trabajadores.TabIndex = 44;
            this.Trabajadores.TabStop = false;
            this.Trabajadores.Text = "Equipo";
            // 
            // pb1
            // 
            this.pb1.BackColor = System.Drawing.Color.Transparent;
            this.pb1.Image = global::TrabCalc.Properties.Resources.Daniel;
            this.pb1.Location = new System.Drawing.Point(116, 38);
            this.pb1.Name = "pb1";
            this.pb1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pb1.ShadowDecoration.Parent = this.pb1;
            this.pb1.Size = new System.Drawing.Size(161, 148);
            this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb1.TabIndex = 36;
            this.pb1.TabStop = false;
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.BackColor = System.Drawing.Color.Transparent;
            this.lb1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.Location = new System.Drawing.Point(12, 189);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(368, 64);
            this.lb1.TabIndex = 37;
            this.lb1.Text = "Daniel Emilio Arechiga Gibert\r\n22310626 - Diseño";
            this.lb1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.BackColor = System.Drawing.Color.Transparent;
            this.lb2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb2.Location = new System.Drawing.Point(400, 189);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(373, 64);
            this.lb2.TabIndex = 38;
            this.lb2.Text = "Marco Antonio Abaroa Portillo\r\n22310591 - Programación\r\n";
            this.lb2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = global::TrabCalc.Properties.Resources.Marco;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(524, 38);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.ShadowDecoration.Parent = this.guna2CirclePictureBox1;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(124, 148);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 39;
            this.guna2CirclePictureBox1.TabStop = false;
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
            // Creditos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(800, 593);
            this.Controls.Add(this.pb2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Creditos";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creditos";
            this.Load += new System.EventHandler(this.Creditos_Load);
            this.pb2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).EndInit();
            this.Trabajadores.ResumeLayout(false);
            this.Trabajadores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel pb2;
        private Guna.UI2.WinForms.Guna2GradientButton btnSalir;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pb1;
        private System.Windows.Forms.Label lb1;
        private Label lb2;
        private BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private GroupBox Trabajadores;
        private GroupBox groupBox2;
        private Label label2;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
    }
}