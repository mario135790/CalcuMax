namespace TrabCalc
{
    partial class FormSimuladorRecipientes
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pb2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.lblSimulacionCompletada = new System.Windows.Forms.Label();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTiempoTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblVelocidadNivel = new System.Windows.Forms.Label();
            this.lblEtiquetaNivel = new System.Windows.Forms.Label();
            this.lblAlturaLiquido = new System.Windows.Forms.Label();
            this.lblEtiquetaAltura = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblOcupado = new System.Windows.Forms.Label();
            this.lblRestante = new System.Windows.Forms.Label();
            this.guna2GradientButton3 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtRazon = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.trackBarVelocidad = new Guna.UI2.WinForms.Guna2TrackBar();
            this.labelZoom = new System.Windows.Forms.Label();
            this.trackBarZoom = new Guna.UI2.WinForms.Guna2TrackBar();
            this.cmbModoVista = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnPausa = new Guna.UI2.WinForms.Guna2GradientButton();
            this.labelVelocidad = new System.Windows.Forms.Label();
            this.button1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnMostrarProcedimiento = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnExportarResultados = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnCopiarResultados = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnHistorial = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSalir = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbQueHace = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pb2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
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
            // pb2
            // 
            this.pb2.BorderColor = System.Drawing.Color.MidnightBlue;
            this.pb2.BorderRadius = 40;
            this.pb2.BorderThickness = 3;
            this.pb2.Controls.Add(this.lblSimulacionCompletada);
            this.pb2.Controls.Add(this.guna2PictureBox3);
            this.pb2.Controls.Add(this.guna2PictureBox1);
            this.pb2.Controls.Add(this.groupBox2);
            this.pb2.Controls.Add(this.groupBox1);
            this.pb2.Controls.Add(this.guna2GradientButton3);
            this.pb2.Controls.Add(this.txtRazon);
            this.pb2.Controls.Add(this.guna2CustomGradientPanel1);
            this.pb2.Controls.Add(this.guna2GradientButton1);
            this.pb2.Controls.Add(this.trackBarVelocidad);
            this.pb2.Controls.Add(this.labelZoom);
            this.pb2.Controls.Add(this.trackBarZoom);
            this.pb2.Controls.Add(this.cmbModoVista);
            this.pb2.Controls.Add(this.btnPausa);
            this.pb2.Controls.Add(this.labelVelocidad);
            this.pb2.Controls.Add(this.button1);
            this.pb2.Controls.Add(this.btnMostrarProcedimiento);
            this.pb2.Controls.Add(this.btnExportarResultados);
            this.pb2.Controls.Add(this.btnCopiarResultados);
            this.pb2.Controls.Add(this.btnHistorial);
            this.pb2.Controls.Add(this.btnSalir);
            this.pb2.Controls.Add(this.label9);
            this.pb2.Controls.Add(this.cmbQueHace);
            this.pb2.Controls.Add(this.label1);
            this.pb2.Controls.Add(this.label2);
            this.pb2.Controls.Add(this.label3);
            this.pb2.FillColor2 = System.Drawing.Color.CornflowerBlue;
            this.pb2.FillColor3 = System.Drawing.Color.DarkCyan;
            this.pb2.FillColor4 = System.Drawing.Color.DarkSlateGray;
            this.pb2.Location = new System.Drawing.Point(0, 0);
            this.pb2.Name = "pb2";
            this.pb2.ShadowDecoration.Parent = this.pb2;
            this.pb2.Size = new System.Drawing.Size(949, 757);
            this.pb2.TabIndex = 44;
            // 
            // lblSimulacionCompletada
            // 
            this.lblSimulacionCompletada.AutoSize = true;
            this.lblSimulacionCompletada.BackColor = System.Drawing.Color.Transparent;
            this.lblSimulacionCompletada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSimulacionCompletada.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSimulacionCompletada.Location = new System.Drawing.Point(31, 248);
            this.lblSimulacionCompletada.Name = "lblSimulacionCompletada";
            this.lblSimulacionCompletada.Size = new System.Drawing.Size(138, 15);
            this.lblSimulacionCompletada.TabIndex = 39;
            this.lblSimulacionCompletada.Text = "Simulación completada:";
            this.lblSimulacionCompletada.Visible = false;
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox3.Image = global::TrabCalc.Properties.Resources.tec1;
            this.guna2PictureBox3.Location = new System.Drawing.Point(83, 19);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.ShadowDecoration.Parent = this.guna2PictureBox3;
            this.guna2PictureBox3.Size = new System.Drawing.Size(84, 87);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox3.TabIndex = 55;
            this.guna2PictureBox3.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::TrabCalc.Properties.Resources.tec3;
            this.guna2PictureBox1.Location = new System.Drawing.Point(12, 19);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(84, 87);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 56;
            this.guna2PictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblTiempoTotal);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.groupBox2.Location = new System.Drawing.Point(29, 428);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 68);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiempo Restante y Total";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.label12.Location = new System.Drawing.Point(5, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 30);
            this.label12.TabIndex = 37;
            this.label12.Text = "00:00:00";
            // 
            // lblTiempoTotal
            // 
            this.lblTiempoTotal.AutoSize = true;
            this.lblTiempoTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTiempoTotal.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.lblTiempoTotal.Location = new System.Drawing.Point(144, 29);
            this.lblTiempoTotal.Name = "lblTiempoTotal";
            this.lblTiempoTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTiempoTotal.Size = new System.Drawing.Size(89, 30);
            this.lblTiempoTotal.TabIndex = 48;
            this.lblTiempoTotal.Text = "00:00:00";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblVelocidadNivel);
            this.groupBox1.Controls.Add(this.lblEtiquetaNivel);
            this.groupBox1.Controls.Add(this.lblAlturaLiquido);
            this.groupBox1.Controls.Add(this.lblEtiquetaAltura);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblOcupado);
            this.groupBox1.Controls.Add(this.lblRestante);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.groupBox1.Location = new System.Drawing.Point(29, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 158);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Volumen";
            // 
            // lblVelocidadNivel
            // 
            this.lblVelocidadNivel.AutoSize = true;
            this.lblVelocidadNivel.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblVelocidadNivel.Location = new System.Drawing.Point(95, 130);
            this.lblVelocidadNivel.Name = "lblVelocidadNivel";
            this.lblVelocidadNivel.Size = new System.Drawing.Size(22, 21);
            this.lblVelocidadNivel.TabIndex = 42;
            this.lblVelocidadNivel.Text = "--";
            // 
            // lblEtiquetaNivel
            // 
            this.lblEtiquetaNivel.AutoSize = true;
            this.lblEtiquetaNivel.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.lblEtiquetaNivel.Location = new System.Drawing.Point(8, 130);
            this.lblEtiquetaNivel.Name = "lblEtiquetaNivel";
            this.lblEtiquetaNivel.Size = new System.Drawing.Size(48, 21);
            this.lblEtiquetaNivel.TabIndex = 41;
            this.lblEtiquetaNivel.Text = "dh/dt";
            // 
            // lblAlturaLiquido
            // 
            this.lblAlturaLiquido.AutoSize = true;
            this.lblAlturaLiquido.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblAlturaLiquido.Location = new System.Drawing.Point(95, 105);
            this.lblAlturaLiquido.Name = "lblAlturaLiquido";
            this.lblAlturaLiquido.Size = new System.Drawing.Size(60, 21);
            this.lblAlturaLiquido.TabIndex = 40;
            this.lblAlturaLiquido.Text = "0.00 m";
            // 
            // lblEtiquetaAltura
            // 
            this.lblEtiquetaAltura.AutoSize = true;
            this.lblEtiquetaAltura.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.lblEtiquetaAltura.Location = new System.Drawing.Point(8, 105);
            this.lblEtiquetaAltura.Name = "lblEtiquetaAltura";
            this.lblEtiquetaAltura.Size = new System.Drawing.Size(52, 21);
            this.lblEtiquetaAltura.TabIndex = 39;
            this.lblEtiquetaAltura.Text = "Altura";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 25);
            this.label5.TabIndex = 38;
            this.label5.Text = "Aire";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 37;
            this.label4.Text = "Agua";
            // 
            // lblOcupado
            // 
            this.lblOcupado.AutoSize = true;
            this.lblOcupado.BackColor = System.Drawing.Color.Transparent;
            this.lblOcupado.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.lblOcupado.Location = new System.Drawing.Point(6, 29);
            this.lblOcupado.Name = "lblOcupado";
            this.lblOcupado.Size = new System.Drawing.Size(24, 30);
            this.lblOcupado.TabIndex = 35;
            this.lblOcupado.Text = "0";
            // 
            // lblRestante
            // 
            this.lblRestante.AutoSize = true;
            this.lblRestante.BackColor = System.Drawing.Color.Transparent;
            this.lblRestante.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.lblRestante.Location = new System.Drawing.Point(6, 69);
            this.lblRestante.Name = "lblRestante";
            this.lblRestante.Size = new System.Drawing.Size(24, 30);
            this.lblRestante.TabIndex = 36;
            this.lblRestante.Text = "0";
            // 
            // guna2GradientButton3
            // 
            this.guna2GradientButton3.AutoRoundedCorners = true;
            this.guna2GradientButton3.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton3.BorderColor = System.Drawing.Color.RoyalBlue;
            this.guna2GradientButton3.BorderRadius = 17;
            this.guna2GradientButton3.BorderThickness = 2;
            this.guna2GradientButton3.CheckedState.Parent = this.guna2GradientButton3;
            this.guna2GradientButton3.CustomImages.Parent = this.guna2GradientButton3;
            this.guna2GradientButton3.FillColor = System.Drawing.Color.LightGray;
            this.guna2GradientButton3.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.guna2GradientButton3.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.guna2GradientButton3.ForeColor = System.Drawing.Color.Black;
            this.guna2GradientButton3.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.guna2GradientButton3.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.guna2GradientButton3.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.guna2GradientButton3.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton3.HoverState.Parent = this.guna2GradientButton3;
            this.guna2GradientButton3.Location = new System.Drawing.Point(183, 52);
            this.guna2GradientButton3.Name = "guna2GradientButton3";
            this.guna2GradientButton3.ShadowDecoration.Parent = this.guna2GradientButton3;
            this.guna2GradientButton3.Size = new System.Drawing.Size(139, 36);
            this.guna2GradientButton3.TabIndex = 52;
            this.guna2GradientButton3.Text = "Elegir";
            this.guna2GradientButton3.Click += new System.EventHandler(this.cmbForma_SelectedIndexChanged);
            this.guna2GradientButton3.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // txtRazon
            // 
            this.txtRazon.BackColor = System.Drawing.Color.Transparent;
            this.txtRazon.BorderColor = System.Drawing.Color.Black;
            this.txtRazon.BorderRadius = 16;
            this.txtRazon.BorderThickness = 2;
            this.txtRazon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRazon.DefaultText = "";
            this.txtRazon.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRazon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRazon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRazon.DisabledState.Parent = this.txtRazon;
            this.txtRazon.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRazon.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtRazon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRazon.FocusedState.Parent = this.txtRazon;
            this.txtRazon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRazon.ForeColor = System.Drawing.Color.Black;
            this.txtRazon.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRazon.HoverState.Parent = this.txtRazon;
            this.txtRazon.Location = new System.Drawing.Point(183, 142);
            this.txtRazon.Margin = new System.Windows.Forms.Padding(5);
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.PasswordChar = '\0';
            this.txtRazon.PlaceholderText = "";
            this.txtRazon.SelectedText = "";
            this.txtRazon.ShadowDecoration.Parent = this.txtRazon;
            this.txtRazon.Size = new System.Drawing.Size(144, 36);
            this.txtRazon.TabIndex = 50;
            this.txtRazon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.BorderColor = System.Drawing.Color.MidnightBlue;
            this.guna2CustomGradientPanel1.BorderRadius = 40;
            this.guna2CustomGradientPanel1.BorderThickness = 3;
            this.guna2CustomGradientPanel1.Controls.Add(this.panel1);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(377, 19);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.ShadowDecoration.Parent = this.guna2CustomGradientPanel1;
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(545, 716);
            this.guna2CustomGradientPanel1.TabIndex = 49;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(16, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 681);
            this.panel1.TabIndex = 31;
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.AutoRoundedCorners = true;
            this.guna2GradientButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.guna2GradientButton1.BorderRadius = 25;
            this.guna2GradientButton1.BorderThickness = 2;
            this.guna2GradientButton1.CheckedState.Parent = this.guna2GradientButton1;
            this.guna2GradientButton1.CustomImages.CheckedImage = global::TrabCalc.Properties.Resources.reset;
            this.guna2GradientButton1.CustomImages.HoveredImage = global::TrabCalc.Properties.Resources.reset2;
            this.guna2GradientButton1.CustomImages.Image = global::TrabCalc.Properties.Resources.reset;
            this.guna2GradientButton1.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2GradientButton1.CustomImages.ImageOffset = new System.Drawing.Point(0, -5);
            this.guna2GradientButton1.CustomImages.ImageSize = new System.Drawing.Size(32, 32);
            this.guna2GradientButton1.CustomImages.Parent = this.guna2GradientButton1;
            this.guna2GradientButton1.FillColor = System.Drawing.Color.LightGray;
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.guna2GradientButton1.Font = new System.Drawing.Font("Arial", 18F);
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.Black;
            this.guna2GradientButton1.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.guna2GradientButton1.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.guna2GradientButton1.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.guna2GradientButton1.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.HoverState.Parent = this.guna2GradientButton1;
            this.guna2GradientButton1.Location = new System.Drawing.Point(260, 572);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.ShadowDecoration.Parent = this.guna2GradientButton1;
            this.guna2GradientButton1.Size = new System.Drawing.Size(60, 53);
            this.guna2GradientButton1.TabIndex = 46;
            this.guna2GradientButton1.Click += new System.EventHandler(this.btnResetView_Click);
            this.guna2GradientButton1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // trackBarVelocidad
            // 
            this.trackBarVelocidad.BackColor = System.Drawing.Color.Transparent;
            this.trackBarVelocidad.FillColor = System.Drawing.Color.DarkGray;
            this.trackBarVelocidad.HoverState.Parent = this.trackBarVelocidad;
            this.trackBarVelocidad.Location = new System.Drawing.Point(29, 539);
            this.trackBarVelocidad.Name = "trackBarVelocidad";
            this.trackBarVelocidad.Size = new System.Drawing.Size(150, 23);
            this.trackBarVelocidad.TabIndex = 45;
            this.trackBarVelocidad.ThumbColor = System.Drawing.Color.MidnightBlue;
            this.trackBarVelocidad.Scroll += new System.Windows.Forms.ScrollEventHandler(this.trackBarVelocidad_Scroll);
            // 
            // labelZoom
            // 
            this.labelZoom.AutoSize = true;
            this.labelZoom.BackColor = System.Drawing.Color.Transparent;
            this.labelZoom.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.labelZoom.Location = new System.Drawing.Point(199, 506);
            this.labelZoom.Name = "labelZoom";
            this.labelZoom.Size = new System.Drawing.Size(67, 30);
            this.labelZoom.TabIndex = 39;
            this.labelZoom.Text = "Zoom";
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.BackColor = System.Drawing.Color.Transparent;
            this.trackBarZoom.FillColor = System.Drawing.Color.DarkGray;
            this.trackBarZoom.HoverState.Parent = this.trackBarZoom;
            this.trackBarZoom.Location = new System.Drawing.Point(199, 539);
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(136, 23);
            this.trackBarZoom.Style = Guna.UI2.WinForms.Enums.TrackBarStyle.Metro;
            this.trackBarZoom.TabIndex = 44;
            this.trackBarZoom.ThumbColor = System.Drawing.Color.MidnightBlue;
            this.trackBarZoom.Scroll += new System.Windows.Forms.ScrollEventHandler(this.trackBarZoom_Scroll);
            // 
            // cmbModoVista
            // 
            this.cmbModoVista.BackColor = System.Drawing.Color.Transparent;
            this.cmbModoVista.BorderColor = System.Drawing.Color.Black;
            this.cmbModoVista.BorderRadius = 17;
            this.cmbModoVista.BorderThickness = 2;
            this.cmbModoVista.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbModoVista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModoVista.FocusedColor = System.Drawing.Color.Empty;
            this.cmbModoVista.FocusedState.Parent = this.cmbModoVista;
            this.cmbModoVista.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cmbModoVista.ForeColor = System.Drawing.Color.Black;
            this.cmbModoVista.FormattingEnabled = true;
            this.cmbModoVista.HoverState.Parent = this.cmbModoVista;
            this.cmbModoVista.ItemHeight = 30;
            this.cmbModoVista.ItemsAppearance.Parent = this.cmbModoVista;
            this.cmbModoVista.Location = new System.Drawing.Point(31, 589);
            this.cmbModoVista.Name = "cmbModoVista";
            this.cmbModoVista.ShadowDecoration.Parent = this.cmbModoVista;
            this.cmbModoVista.Size = new System.Drawing.Size(140, 36);
            this.cmbModoVista.TabIndex = 41;
            this.cmbModoVista.SelectedIndexChanged += new System.EventHandler(this.cmbModoVista_SelectedIndexChanged);
            this.cmbModoVista.Click += new System.EventHandler(this.cmbForma_Click);
            // 
            // btnPausa
            // 
            this.btnPausa.AutoRoundedCorners = true;
            this.btnPausa.BackColor = System.Drawing.Color.Transparent;
            this.btnPausa.BorderColor = System.Drawing.Color.Firebrick;
            this.btnPausa.BorderRadius = 23;
            this.btnPausa.BorderThickness = 3;
            this.btnPausa.CheckedState.Parent = this.btnPausa;
            this.btnPausa.CustomImages.Parent = this.btnPausa;
            this.btnPausa.FillColor = System.Drawing.Color.LightGray;
            this.btnPausa.FillColor2 = System.Drawing.Color.LightCoral;
            this.btnPausa.Font = new System.Drawing.Font("Arial", 18F);
            this.btnPausa.ForeColor = System.Drawing.Color.Black;
            this.btnPausa.HoverState.BorderColor = System.Drawing.Color.Firebrick;
            this.btnPausa.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnPausa.HoverState.FillColor2 = System.Drawing.Color.IndianRed;
            this.btnPausa.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnPausa.HoverState.Parent = this.btnPausa;
            this.btnPausa.Location = new System.Drawing.Point(183, 196);
            this.btnPausa.Name = "btnPausa";
            this.btnPausa.ShadowDecoration.Parent = this.btnPausa;
            this.btnPausa.Size = new System.Drawing.Size(148, 49);
            this.btnPausa.TabIndex = 43;
            this.btnPausa.Text = "Pausar";
            this.btnPausa.Click += new System.EventHandler(this.btnPausa_Click);
            this.btnPausa.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // labelVelocidad
            // 
            this.labelVelocidad.AutoSize = true;
            this.labelVelocidad.BackColor = System.Drawing.Color.Transparent;
            this.labelVelocidad.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.labelVelocidad.Location = new System.Drawing.Point(29, 506);
            this.labelVelocidad.Name = "labelVelocidad";
            this.labelVelocidad.Size = new System.Drawing.Size(103, 30);
            this.labelVelocidad.TabIndex = 38;
            this.labelVelocidad.Text = "Velocidad";
            // 
            // button1
            // 
            this.button1.AutoRoundedCorners = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button1.BorderRadius = 23;
            this.button1.BorderThickness = 3;
            this.button1.CheckedState.Parent = this.button1;
            this.button1.CustomImages.Parent = this.button1;
            this.button1.FillColor = System.Drawing.Color.LightGray;
            this.button1.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.button1.Font = new System.Drawing.Font("Arial", 18F);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button1.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.button1.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.button1.HoverState.ForeColor = System.Drawing.Color.White;
            this.button1.HoverState.Parent = this.button1;
            this.button1.Location = new System.Drawing.Point(29, 196);
            this.button1.Name = "button1";
            this.button1.ShadowDecoration.Parent = this.button1;
            this.button1.Size = new System.Drawing.Size(152, 49);
            this.button1.TabIndex = 42;
            this.button1.Text = "Simular";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // btnMostrarProcedimiento
            // 
            this.btnMostrarProcedimiento.AutoRoundedCorners = true;
            this.btnMostrarProcedimiento.BackColor = System.Drawing.Color.Transparent;
            this.btnMostrarProcedimiento.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnMostrarProcedimiento.BorderRadius = 23;
            this.btnMostrarProcedimiento.BorderThickness = 3;
            this.btnMostrarProcedimiento.CheckedState.Parent = this.btnMostrarProcedimiento;
            this.btnMostrarProcedimiento.CustomImages.Parent = this.btnMostrarProcedimiento;
            this.btnMostrarProcedimiento.FillColor = System.Drawing.Color.LightGray;
            this.btnMostrarProcedimiento.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnMostrarProcedimiento.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarProcedimiento.ForeColor = System.Drawing.Color.Black;
            this.btnMostrarProcedimiento.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnMostrarProcedimiento.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnMostrarProcedimiento.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnMostrarProcedimiento.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnMostrarProcedimiento.HoverState.Parent = this.btnMostrarProcedimiento;
            this.btnMostrarProcedimiento.Location = new System.Drawing.Point(29, 631);
            this.btnMostrarProcedimiento.Name = "btnMostrarProcedimiento";
            this.btnMostrarProcedimiento.ShadowDecoration.Parent = this.btnMostrarProcedimiento;
            this.btnMostrarProcedimiento.Size = new System.Drawing.Size(281, 49);
            this.btnMostrarProcedimiento.TabIndex = 57;
            this.btnMostrarProcedimiento.Text = "Mostrar procedimiento";
            this.btnMostrarProcedimiento.Visible = false;
            this.btnMostrarProcedimiento.Click += new System.EventHandler(this.btnMostrarProcedimiento_Click);
            this.btnMostrarProcedimiento.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // btnExportarResultados
            // 
            this.btnExportarResultados.AutoRoundedCorners = true;
            this.btnExportarResultados.BackColor = System.Drawing.Color.Transparent;
            this.btnExportarResultados.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportarResultados.BorderRadius = 23;
            this.btnExportarResultados.BorderThickness = 2;
            this.btnExportarResultados.CheckedState.Parent = this.btnExportarResultados;
            this.btnExportarResultados.CustomImages.Parent = this.btnExportarResultados;
            this.btnExportarResultados.Enabled = false;
            this.btnExportarResultados.FillColor = System.Drawing.Color.LightGray;
            this.btnExportarResultados.FillColor2 = System.Drawing.Color.MediumSeaGreen;
            this.btnExportarResultados.Font = new System.Drawing.Font("Arial", 16F);
            this.btnExportarResultados.ForeColor = System.Drawing.Color.Black;
            this.btnExportarResultados.HoverState.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportarResultados.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnExportarResultados.HoverState.FillColor2 = System.Drawing.Color.MediumSeaGreen;
            this.btnExportarResultados.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnExportarResultados.HoverState.Parent = this.btnExportarResultados;
            this.btnExportarResultados.Location = new System.Drawing.Point(185, 686);
            this.btnExportarResultados.Name = "btnExportarResultados";
            this.btnExportarResultados.ShadowDecoration.Parent = this.btnExportarResultados;
            this.btnExportarResultados.Size = new System.Drawing.Size(116, 49);
            this.btnExportarResultados.TabIndex = 60;
            this.btnExportarResultados.Text = "Exportar";
            this.btnExportarResultados.Visible = false;
            this.btnExportarResultados.Click += new System.EventHandler(this.btnExportarResultados_Click);
            this.btnExportarResultados.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // btnCopiarResultados
            // 
            this.btnCopiarResultados.AutoRoundedCorners = true;
            this.btnCopiarResultados.BackColor = System.Drawing.Color.Transparent;
            this.btnCopiarResultados.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnCopiarResultados.BorderRadius = 23;
            this.btnCopiarResultados.BorderThickness = 2;
            this.btnCopiarResultados.CheckedState.Parent = this.btnCopiarResultados;
            this.btnCopiarResultados.CustomImages.Parent = this.btnCopiarResultados;
            this.btnCopiarResultados.Enabled = false;
            this.btnCopiarResultados.FillColor = System.Drawing.Color.LightGray;
            this.btnCopiarResultados.FillColor2 = System.Drawing.Color.MediumSeaGreen;
            this.btnCopiarResultados.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiarResultados.ForeColor = System.Drawing.Color.Black;
            this.btnCopiarResultados.HoverState.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnCopiarResultados.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnCopiarResultados.HoverState.FillColor2 = System.Drawing.Color.MediumSeaGreen;
            this.btnCopiarResultados.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCopiarResultados.HoverState.Parent = this.btnCopiarResultados;
            this.btnCopiarResultados.Location = new System.Drawing.Point(185, 686);
            this.btnCopiarResultados.Name = "btnCopiarResultados";
            this.btnCopiarResultados.ShadowDecoration.Parent = this.btnCopiarResultados;
            this.btnCopiarResultados.Size = new System.Drawing.Size(100, 49);
            this.btnCopiarResultados.TabIndex = 58;
            this.btnCopiarResultados.Text = "Copiar";
            this.btnCopiarResultados.Visible = false;
            this.btnCopiarResultados.Click += new System.EventHandler(this.btnCopiarResultados_Click);
            this.btnCopiarResultados.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackColor = System.Drawing.Color.Transparent;
            this.btnHistorial.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnHistorial.BorderRadius = 20;
            this.btnHistorial.BorderThickness = 3;
            this.btnHistorial.CheckedState.Parent = this.btnHistorial;
            this.btnHistorial.CustomImages.Parent = this.btnHistorial;
            this.btnHistorial.FillColor = System.Drawing.Color.AliceBlue;
            this.btnHistorial.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnHistorial.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.btnHistorial.ForeColor = System.Drawing.Color.Black;
            this.btnHistorial.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnHistorial.HoverState.FillColor = System.Drawing.Color.White;
            this.btnHistorial.HoverState.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnHistorial.HoverState.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnHistorial.HoverState.Parent = this.btnHistorial;
            this.btnHistorial.Image = global::TrabCalc.Properties.Resources.historial;
            this.btnHistorial.ImageSize = new System.Drawing.Size(48, 48);
            this.btnHistorial.Location = new System.Drawing.Point(298, 293);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.ShadowDecoration.Parent = this.btnHistorial;
            this.btnHistorial.Size = new System.Drawing.Size(62, 62);
            this.btnHistorial.TabIndex = 59;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            this.btnHistorial.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
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
            this.btnSalir.Location = new System.Drawing.Point(31, 686);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.ShadowDecoration.Parent = this.btnSalir;
            this.btnSalir.Size = new System.Drawing.Size(150, 49);
            this.btnSalir.TabIndex = 35;
            this.btnSalir.Text = "Volver";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.label9.Location = new System.Drawing.Point(31, 556);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(223, 30);
            this.label9.TabIndex = 40;
            this.label9.Text = "Modo de Visualización";
            // 
            // cmbQueHace
            // 
            this.cmbQueHace.AutoRoundedCorners = true;
            this.cmbQueHace.BackColor = System.Drawing.Color.Transparent;
            this.cmbQueHace.BorderColor = System.Drawing.Color.Black;
            this.cmbQueHace.BorderRadius = 17;
            this.cmbQueHace.BorderThickness = 2;
            this.cmbQueHace.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbQueHace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueHace.FocusedColor = System.Drawing.Color.Empty;
            this.cmbQueHace.FocusedState.Parent = this.cmbQueHace;
            this.cmbQueHace.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbQueHace.ForeColor = System.Drawing.Color.Black;
            this.cmbQueHace.FormattingEnabled = true;
            this.cmbQueHace.HoverState.Parent = this.cmbQueHace;
            this.cmbQueHace.ItemHeight = 30;
            this.cmbQueHace.Items.AddRange(new object[] {
            "Drenar",
            "Llenar"});
            this.cmbQueHace.ItemsAppearance.Parent = this.cmbQueHace;
            this.cmbQueHace.Location = new System.Drawing.Point(29, 142);
            this.cmbQueHace.Name = "cmbQueHace";
            this.cmbQueHace.ShadowDecoration.Parent = this.cmbQueHace;
            this.cmbQueHace.Size = new System.Drawing.Size(140, 36);
            this.cmbQueHace.TabIndex = 5;
            this.cmbQueHace.SelectedIndexChanged += new System.EventHandler(this.cmbRazon_SelectedIndexChanged);
            this.cmbQueHace.Click += new System.EventHandler(this.cmbForma_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recipiente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.label2.Location = new System.Drawing.Point(178, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Caudal (m³/min)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.label3.Location = new System.Drawing.Point(51, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Inserción";
            // 
            // FormSimuladorRecipientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(951, 759);
            this.Controls.Add(this.pb2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSimuladorRecipientes";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador de recipientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSimuladorRecipientes_FormClosing);
            this.pb2.ResumeLayout(false);
            this.pb2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pb2;
        private Guna.UI2.WinForms.Guna2TextBox txtRazon;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTiempoTotal;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private Guna.UI2.WinForms.Guna2TrackBar trackBarVelocidad;
        private System.Windows.Forms.Label labelZoom;
        private Guna.UI2.WinForms.Guna2TrackBar trackBarZoom;
        private Guna.UI2.WinForms.Guna2ComboBox cmbModoVista;
        private Guna.UI2.WinForms.Guna2GradientButton btnPausa;
        private System.Windows.Forms.Label labelVelocidad;
        private Guna.UI2.WinForms.Guna2GradientButton button1;
        private Guna.UI2.WinForms.Guna2GradientButton btnMostrarProcedimiento;
        private Guna.UI2.WinForms.Guna2GradientButton btnExportarResultados;
        private Guna.UI2.WinForms.Guna2GradientButton btnCopiarResultados;
        private Guna.UI2.WinForms.Guna2GradientButton btnHistorial;
        private Guna.UI2.WinForms.Guna2GradientButton btnSalir;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2ComboBox cmbQueHace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSimulacionCompletada;
        private System.Windows.Forms.Label lblOcupado;
        private System.Windows.Forms.Label lblRestante;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label lblEtiquetaAltura;
        private System.Windows.Forms.Label lblAlturaLiquido;
        private System.Windows.Forms.Label lblEtiquetaNivel;
        private System.Windows.Forms.Label lblVelocidadNivel;
    }
}

