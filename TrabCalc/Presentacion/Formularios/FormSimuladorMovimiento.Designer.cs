namespace TrabCalc
{
    partial class FormSimuladorMovimiento
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
            this.btnHistorial = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnMostrarProcedimiento = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cmbMovimiento = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.panelTrabajo = new System.Windows.Forms.Panel();
            this.panelAceleracion = new System.Windows.Forms.Panel();
            this.panelVelocidad = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBarVelocidad = new Guna.UI2.WinForms.Guna2TrackBar();
            this.btnPausa = new Guna.UI2.WinForms.Guna2GradientButton();
            this.labelVelocidad = new System.Windows.Forms.Label();
            this.button1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnExportarResultados = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnCopiarResultados = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSalir = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lblSimulacionCompletada = new System.Windows.Forms.Label();
            this.lblTrabajoR = new System.Windows.Forms.Label();
            this.lblVelFinal = new System.Windows.Forms.Label();
            this.lblDistancia = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pb2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
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
            this.pb2.Controls.Add(this.btnHistorial);
            this.pb2.Controls.Add(this.guna2PictureBox3);
            this.pb2.Controls.Add(this.guna2PictureBox1);
            this.pb2.Controls.Add(this.btnMostrarProcedimiento);
            this.pb2.Controls.Add(this.cmbMovimiento);
            this.pb2.Controls.Add(this.guna2CustomGradientPanel1);
            this.pb2.Controls.Add(this.trackBarVelocidad);
            this.pb2.Controls.Add(this.btnPausa);
            this.pb2.Controls.Add(this.labelVelocidad);
            this.pb2.Controls.Add(this.button1);
            this.pb2.Controls.Add(this.btnExportarResultados);
            this.pb2.Controls.Add(this.btnCopiarResultados);
            this.pb2.Controls.Add(this.btnSalir);
            this.pb2.Controls.Add(this.lblSimulacionCompletada);
            this.pb2.Controls.Add(this.lblTrabajoR);
            this.pb2.Controls.Add(this.lblVelFinal);
            this.pb2.Controls.Add(this.lblDistancia);
            this.pb2.Controls.Add(this.label6);
            this.pb2.Controls.Add(this.label1);
            this.pb2.Controls.Add(this.label5);
            this.pb2.Controls.Add(this.label4);
            this.pb2.FillColor2 = System.Drawing.Color.CornflowerBlue;
            this.pb2.FillColor3 = System.Drawing.Color.DarkCyan;
            this.pb2.FillColor4 = System.Drawing.Color.DarkSlateGray;
            this.pb2.Location = new System.Drawing.Point(0, 0);
            this.pb2.Name = "pb2";
            this.pb2.ShadowDecoration.Parent = this.pb2;
            this.pb2.Size = new System.Drawing.Size(898, 652);
            this.pb2.TabIndex = 44;
            // 
            // btnHistorial
            // 
            this.btnHistorial.AutoRoundedCorners = false;
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
            this.btnHistorial.Location = new System.Drawing.Point(262, 249);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.ShadowDecoration.Parent = this.btnHistorial;
            this.btnHistorial.Size = new System.Drawing.Size(62, 60);
            this.btnHistorial.TabIndex = 60;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox3.Image = global::TrabCalc.Properties.Resources.tec1;
            this.guna2PictureBox3.Location = new System.Drawing.Point(93, 18);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.ShadowDecoration.Parent = this.guna2PictureBox3;
            this.guna2PictureBox3.Size = new System.Drawing.Size(84, 87);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox3.TabIndex = 57;
            this.guna2PictureBox3.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::TrabCalc.Properties.Resources.tec3;
            this.guna2PictureBox1.Location = new System.Drawing.Point(22, 18);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(84, 87);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 58;
            this.guna2PictureBox1.TabStop = false;
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
            this.btnMostrarProcedimiento.Enabled = false;
            this.btnMostrarProcedimiento.FillColor = System.Drawing.Color.LightGray;
            this.btnMostrarProcedimiento.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnMostrarProcedimiento.Font = new System.Drawing.Font("Arial", 18F);
            this.btnMostrarProcedimiento.ForeColor = System.Drawing.Color.Black;
            this.btnMostrarProcedimiento.HoverState.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnMostrarProcedimiento.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnMostrarProcedimiento.HoverState.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.btnMostrarProcedimiento.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnMostrarProcedimiento.HoverState.Parent = this.btnMostrarProcedimiento;
            this.btnMostrarProcedimiento.Location = new System.Drawing.Point(22, 520);
            this.btnMostrarProcedimiento.Name = "btnMostrarProcedimiento";
            this.btnMostrarProcedimiento.ShadowDecoration.Parent = this.btnMostrarProcedimiento;
            this.btnMostrarProcedimiento.Size = new System.Drawing.Size(302, 49);
            this.btnMostrarProcedimiento.TabIndex = 51;
            this.btnMostrarProcedimiento.Text = "Mostrar procedimiento";
            this.btnMostrarProcedimiento.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // cmbMovimiento
            // 
            this.cmbMovimiento.AutoRoundedCorners = true;
            this.cmbMovimiento.BackColor = System.Drawing.Color.Transparent;
            this.cmbMovimiento.BorderColor = System.Drawing.Color.Black;
            this.cmbMovimiento.BorderRadius = 17;
            this.cmbMovimiento.BorderThickness = 2;
            this.cmbMovimiento.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovimiento.FocusedColor = System.Drawing.Color.Empty;
            this.cmbMovimiento.FocusedState.Parent = this.cmbMovimiento;
            this.cmbMovimiento.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cmbMovimiento.ForeColor = System.Drawing.Color.Black;
            this.cmbMovimiento.FormattingEnabled = true;
            this.cmbMovimiento.HoverState.Parent = this.cmbMovimiento;
            this.cmbMovimiento.ItemHeight = 30;
            this.cmbMovimiento.Items.AddRange(new object[] {
            "Aceleración Constante",
            "Aceleración Variable"});
            this.cmbMovimiento.ItemsAppearance.Parent = this.cmbMovimiento;
            this.cmbMovimiento.Location = new System.Drawing.Point(24, 141);
            this.cmbMovimiento.Name = "cmbMovimiento";
            this.cmbMovimiento.ShadowDecoration.Parent = this.cmbMovimiento;
            this.cmbMovimiento.Size = new System.Drawing.Size(265, 36);
            this.cmbMovimiento.TabIndex = 50;
            this.cmbMovimiento.SelectedIndexChanged += new System.EventHandler(this.cmbMovimiento_SelectedIndexChanged);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.BorderColor = System.Drawing.Color.MidnightBlue;
            this.guna2CustomGradientPanel1.BorderRadius = 40;
            this.guna2CustomGradientPanel1.BorderThickness = 3;
            this.guna2CustomGradientPanel1.Controls.Add(this.panelTrabajo);
            this.guna2CustomGradientPanel1.Controls.Add(this.panelAceleracion);
            this.guna2CustomGradientPanel1.Controls.Add(this.panelVelocidad);
            this.guna2CustomGradientPanel1.Controls.Add(this.panel1);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(354, 36);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.ShadowDecoration.Parent = this.guna2CustomGradientPanel1;
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(524, 594);
            this.guna2CustomGradientPanel1.TabIndex = 49;
            // 
            // panelTrabajo
            // 
            this.panelTrabajo.BackColor = System.Drawing.SystemColors.Control;
            this.panelTrabajo.Location = new System.Drawing.Point(352, 347);
            this.panelTrabajo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTrabajo.Name = "panelTrabajo";
            this.panelTrabajo.Size = new System.Drawing.Size(162, 216);
            this.panelTrabajo.TabIndex = 33;
            // 
            // panelAceleracion
            // 
            this.panelAceleracion.BackColor = System.Drawing.SystemColors.Control;
            this.panelAceleracion.Location = new System.Drawing.Point(184, 347);
            this.panelAceleracion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelAceleracion.Name = "panelAceleracion";
            this.panelAceleracion.Size = new System.Drawing.Size(162, 216);
            this.panelAceleracion.TabIndex = 33;
            // 
            // panelVelocidad
            // 
            this.panelVelocidad.BackColor = System.Drawing.SystemColors.Control;
            this.panelVelocidad.Location = new System.Drawing.Point(16, 347);
            this.panelVelocidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelVelocidad.Name = "panelVelocidad";
            this.panelVelocidad.Size = new System.Drawing.Size(162, 216);
            this.panelVelocidad.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(16, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 323);
            this.panel1.TabIndex = 31;
            // 
            // trackBarVelocidad
            // 
            this.trackBarVelocidad.BackColor = System.Drawing.Color.Transparent;
            this.trackBarVelocidad.FillColor = System.Drawing.Color.DarkGray;
            this.trackBarVelocidad.HoverState.Parent = this.trackBarVelocidad;
            this.trackBarVelocidad.Location = new System.Drawing.Point(27, 480);
            this.trackBarVelocidad.Minimum = 1;
            this.trackBarVelocidad.Name = "trackBarVelocidad";
            this.trackBarVelocidad.Size = new System.Drawing.Size(150, 23);
            this.trackBarVelocidad.TabIndex = 45;
            this.trackBarVelocidad.ThumbColor = System.Drawing.Color.MidnightBlue;
            this.trackBarVelocidad.Value = 10;
            this.trackBarVelocidad.Scroll += new System.Windows.Forms.ScrollEventHandler(this.trackBarVelocidad_Scroll);
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
            this.btnPausa.Enabled = false;
            this.btnPausa.FillColor = System.Drawing.Color.LightGray;
            this.btnPausa.FillColor2 = System.Drawing.Color.LightCoral;
            this.btnPausa.Font = new System.Drawing.Font("Arial", 18F);
            this.btnPausa.ForeColor = System.Drawing.Color.Black;
            this.btnPausa.HoverState.BorderColor = System.Drawing.Color.Firebrick;
            this.btnPausa.HoverState.FillColor = System.Drawing.Color.AliceBlue;
            this.btnPausa.HoverState.FillColor2 = System.Drawing.Color.IndianRed;
            this.btnPausa.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnPausa.HoverState.Parent = this.btnPausa;
            this.btnPausa.Location = new System.Drawing.Point(188, 184);
            this.btnPausa.Name = "btnPausa";
            this.btnPausa.ShadowDecoration.Parent = this.btnPausa;
            this.btnPausa.Size = new System.Drawing.Size(116, 49);
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
            this.labelVelocidad.Location = new System.Drawing.Point(27, 448);
            this.labelVelocidad.Name = "labelVelocidad";
            this.labelVelocidad.Size = new System.Drawing.Size(151, 30);
            this.labelVelocidad.TabIndex = 38;
            this.labelVelocidad.Text = "Velocidad: 1.0x";
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
            this.button1.Location = new System.Drawing.Point(27, 184);
            this.button1.Name = "button1";
            this.button1.ShadowDecoration.Parent = this.button1;
            this.button1.Size = new System.Drawing.Size(152, 49);
            this.button1.TabIndex = 42;
            this.button1.Text = "Simular";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // btnExportarResultados
            // 
            this.btnExportarResultados.AutoRoundedCorners = true;
            this.btnExportarResultados.BackColor = System.Drawing.Color.Transparent;
            this.btnExportarResultados.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnExportarResultados.BorderRadius = 23;
            this.btnExportarResultados.BorderThickness = 3;
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
            this.btnExportarResultados.Location = new System.Drawing.Point(180, 581);
            this.btnExportarResultados.Name = "btnExportarResultados";
            this.btnExportarResultados.ShadowDecoration.Parent = this.btnExportarResultados;
            this.btnExportarResultados.Size = new System.Drawing.Size(116, 49);
            this.btnExportarResultados.TabIndex = 62;
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
            this.btnCopiarResultados.BorderThickness = 3;
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
            this.btnCopiarResultados.Location = new System.Drawing.Point(180, 581);
            this.btnCopiarResultados.Name = "btnCopiarResultados";
            this.btnCopiarResultados.ShadowDecoration.Parent = this.btnCopiarResultados;
            this.btnCopiarResultados.Size = new System.Drawing.Size(106, 49);
            this.btnCopiarResultados.TabIndex = 59;
            this.btnCopiarResultados.Text = "Copiar";
            this.btnCopiarResultados.Visible = false;
            this.btnCopiarResultados.Click += new System.EventHandler(this.btnCopiarResultados_Click);
            this.btnCopiarResultados.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
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
            this.btnSalir.Location = new System.Drawing.Point(24, 581);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.ShadowDecoration.Parent = this.btnSalir;
            this.btnSalir.Size = new System.Drawing.Size(150, 49);
            this.btnSalir.TabIndex = 35;
            this.btnSalir.Text = "Volver";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // lblSimulacionCompletada
            // 
            this.lblSimulacionCompletada.AutoSize = true;
            this.lblSimulacionCompletada.BackColor = System.Drawing.Color.Transparent;
            this.lblSimulacionCompletada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSimulacionCompletada.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSimulacionCompletada.Location = new System.Drawing.Point(27, 236);
            this.lblSimulacionCompletada.Name = "lblSimulacionCompletada";
            this.lblSimulacionCompletada.Size = new System.Drawing.Size(138, 15);
            this.lblSimulacionCompletada.TabIndex = 61;
            this.lblSimulacionCompletada.Text = "Simulación completada:";
            this.lblSimulacionCompletada.Visible = false;
            // 
            // lblTrabajoR
            // 
            this.lblTrabajoR.AutoSize = true;
            this.lblTrabajoR.BackColor = System.Drawing.Color.Transparent;
            this.lblTrabajoR.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.lblTrabajoR.Location = new System.Drawing.Point(27, 418);
            this.lblTrabajoR.Name = "lblTrabajoR";
            this.lblTrabajoR.Size = new System.Drawing.Size(48, 30);
            this.lblTrabajoR.TabIndex = 37;
            this.lblTrabajoR.Text = "0 kJ";
            // 
            // lblVelFinal
            // 
            this.lblVelFinal.AutoSize = true;
            this.lblVelFinal.BackColor = System.Drawing.Color.Transparent;
            this.lblVelFinal.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.lblVelFinal.Location = new System.Drawing.Point(27, 349);
            this.lblVelFinal.Name = "lblVelFinal";
            this.lblVelFinal.Size = new System.Drawing.Size(78, 30);
            this.lblVelFinal.TabIndex = 36;
            this.lblVelFinal.Text = "0 km/h";
            // 
            // lblDistancia
            // 
            this.lblDistancia.AutoSize = true;
            this.lblDistancia.BackColor = System.Drawing.Color.Transparent;
            this.lblDistancia.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.lblDistancia.Location = new System.Drawing.Point(27, 279);
            this.lblDistancia.Name = "lblDistancia";
            this.lblDistancia.Size = new System.Drawing.Size(48, 30);
            this.lblDistancia.TabIndex = 35;
            this.lblDistancia.Text = "0 m";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.label6.Location = new System.Drawing.Point(27, 388);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 30);
            this.label6.TabIndex = 34;
            this.label6.Text = "Trabajo Realizado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Movimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.label5.Location = new System.Drawing.Point(27, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 30);
            this.label5.TabIndex = 33;
            this.label5.Text = "Velocidad Final:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.label4.Location = new System.Drawing.Point(27, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 30);
            this.label4.TabIndex = 32;
            this.label4.Text = "Distancia recorrida:";
            // 
            // FormSimuladorMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(898, 652);
            this.Controls.Add(this.pb2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSimuladorMovimiento";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador de movimiento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSimuladorMovimiento_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSimuladorMovimiento_FormClosed);
            this.pb2.ResumeLayout(false);
            this.pb2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pb2;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2TrackBar trackBarVelocidad;
        private Guna.UI2.WinForms.Guna2GradientButton btnPausa;
        private System.Windows.Forms.Label labelVelocidad;
        private Guna.UI2.WinForms.Guna2GradientButton button1;
        private Guna.UI2.WinForms.Guna2GradientButton btnExportarResultados;
        private Guna.UI2.WinForms.Guna2GradientButton btnCopiarResultados;
        private Guna.UI2.WinForms.Guna2GradientButton btnSalir;
        private System.Windows.Forms.Label lblSimulacionCompletada;
        private System.Windows.Forms.Label lblTrabajoR;
        private System.Windows.Forms.Label lblVelFinal;
        private System.Windows.Forms.Label lblDistancia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public Guna.UI2.WinForms.Guna2ComboBox cmbMovimiento;
        private System.Windows.Forms.Panel panelVelocidad;
        private System.Windows.Forms.Panel panelTrabajo;
        private System.Windows.Forms.Panel panelAceleracion;
        private Guna.UI2.WinForms.Guna2GradientButton btnMostrarProcedimiento;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2GradientButton btnHistorial;
    }
}

