namespace TrabCalc
{
    partial class MenuPrincipal
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnCreditos = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSalir = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSimulador = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pbVersion = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BorderColor = System.Drawing.Color.MidnightBlue;
            this.guna2CustomGradientPanel1.BorderRadius = 40;
            this.guna2CustomGradientPanel1.BorderThickness = 3;
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2PictureBox3);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2PictureBox2);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2Button1);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnCreditos);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnSalir);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnSimulador);
            this.guna2CustomGradientPanel1.Controls.Add(this.pbVersion);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2PictureBox1);
            this.guna2CustomGradientPanel1.Controls.Add(this.pictureBox1);
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.CornflowerBlue;
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.DarkCyan;
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.DarkSlateGray;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.ShadowDecoration.Parent = this.guna2CustomGradientPanel1;
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(800, 450);
            this.guna2CustomGradientPanel1.TabIndex = 1;
            // guna2Button1
            // 
            this.guna2Button1.AutoRoundedCorners = true;
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.guna2Button1.BorderRadius = 34;
            this.guna2Button1.BorderThickness = 3;
            this.guna2Button1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.guna2Button1.Checked = true;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.CheckedImage = global::TrabCalc.Properties.Resources.unmute;
            this.guna2Button1.CustomImages.Image = global::TrabCalc.Properties.Resources.mute;
            this.guna2Button1.CustomImages.ImageSize = new System.Drawing.Size(48, 32);
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.guna2Button1.Font = new System.Drawing.Font("Arial", 18F);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.guna2Button1.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(716, 368);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(72, 70);
            this.guna2Button1.TabIndex = 38;
            this.guna2Button1.CheckedChanged += new System.EventHandler(this.guna2Button1_CheckedChanged);
            this.guna2Button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // btnCreditos
            // 
            this.btnCreditos.AutoRoundedCorners = true;
            this.btnCreditos.BackColor = System.Drawing.Color.Transparent;
            this.btnCreditos.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCreditos.BorderRadius = 23;
            this.btnCreditos.BorderThickness = 3;
            this.btnCreditos.CheckedState.Parent = this.btnCreditos;
            this.btnCreditos.CustomImages.Parent = this.btnCreditos;
            this.btnCreditos.FillColor = System.Drawing.Color.LightGray;
            this.btnCreditos.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnCreditos.Font = new System.Drawing.Font("Arial", 18F);
            this.btnCreditos.ForeColor = System.Drawing.Color.Black;
            this.btnCreditos.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCreditos.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnCreditos.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnCreditos.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCreditos.HoverState.Parent = this.btnCreditos;
            this.btnCreditos.Location = new System.Drawing.Point(268, 286);
            this.btnCreditos.Name = "btnCreditos";
            this.btnCreditos.ShadowDecoration.Parent = this.btnCreditos;
            this.btnCreditos.Size = new System.Drawing.Size(245, 49);
            this.btnCreditos.TabIndex = 36;
            this.btnCreditos.Text = "Créditos";
            this.btnCreditos.Click += new System.EventHandler(this.btnCreditos_Click);
            this.btnCreditos.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
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
            this.btnSalir.Location = new System.Drawing.Point(268, 341);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.ShadowDecoration.Parent = this.btnSalir;
            this.btnSalir.Size = new System.Drawing.Size(245, 49);
            this.btnSalir.TabIndex = 35;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // btnSimulador
            // 
            this.btnSimulador.AutoRoundedCorners = true;
            this.btnSimulador.BackColor = System.Drawing.Color.Transparent;
            this.btnSimulador.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSimulador.BorderRadius = 23;
            this.btnSimulador.BorderThickness = 3;
            this.btnSimulador.CheckedState.Parent = this.btnSimulador;
            this.btnSimulador.CustomImages.Parent = this.btnSimulador;
            this.btnSimulador.FillColor = System.Drawing.Color.LightGray;
            this.btnSimulador.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnSimulador.Font = new System.Drawing.Font("Arial", 18F);
            this.btnSimulador.ForeColor = System.Drawing.Color.Black;
            this.btnSimulador.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSimulador.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnSimulador.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnSimulador.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSimulador.HoverState.Parent = this.btnSimulador;
            this.btnSimulador.Location = new System.Drawing.Point(268, 231);
            this.btnSimulador.Name = "btnSimulador";
            this.btnSimulador.ShadowDecoration.Parent = this.btnSimulador;
            this.btnSimulador.Size = new System.Drawing.Size(245, 49);
            this.btnSimulador.TabIndex = 34;
            this.btnSimulador.Text = "Simuladores";
            this.btnSimulador.Click += new System.EventHandler(this.btnSimulador_Click);
            this.btnSimulador.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox3.Image = global::TrabCalc.Properties.Resources.tec1;
            this.guna2PictureBox3.Location = new System.Drawing.Point(91, 351);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.ShadowDecoration.Parent = this.guna2PictureBox3;
            this.guna2PictureBox3.Size = new System.Drawing.Size(84, 87);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox3.TabIndex = 57;
            this.guna2PictureBox3.TabStop = false;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = global::TrabCalc.Properties.Resources.tec3;
            this.guna2PictureBox2.Location = new System.Drawing.Point(20, 351);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.ShadowDecoration.Parent = this.guna2PictureBox2;
            this.guna2PictureBox2.Size = new System.Drawing.Size(84, 87);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 58;
            this.guna2PictureBox2.TabStop = false;
            // 
            // pbVersion
            // 
            this.pbVersion.BackColor = System.Drawing.Color.Transparent;
            this.pbVersion.Image = global::TrabCalc.Properties.Resources.wordartNew;
            this.pbVersion.Location = new System.Drawing.Point(595, 165);
            this.pbVersion.Name = "pbVersion";
            this.pbVersion.ShadowDecoration.Parent = this.pbVersion;
            this.pbVersion.Size = new System.Drawing.Size(106, 57);
            this.pbVersion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVersion.TabIndex = 1;
            this.pbVersion.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::TrabCalc.Properties.Resources.wordart__1_;
            this.guna2PictureBox1.Location = new System.Drawing.Point(91, 42);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(585, 156);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::TrabCalc.Properties.Resources.Burbujas;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(790, 440);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuPrincipal";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2PictureBox pbVersion;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2GradientButton btnSimulador;
        private Guna.UI2.WinForms.Guna2GradientButton btnCreditos;
        private Guna.UI2.WinForms.Guna2GradientButton btnSalir;
        private System.Windows.Forms.Timer timer2;
        private Guna.UI2.WinForms.Guna2GradientButton guna2Button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
    }
}
