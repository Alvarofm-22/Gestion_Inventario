namespace Proyecto_GUI
{
    partial class MDIGestionInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIGestionInventario));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mantenimientoDeEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoDeProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoDeEmpleadosToolStripMenuItem,
            this.mantenimientoDeProveedoresToolStripMenuItem,
            this.mantenimientoDeProductosToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(827, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mantenimientoDeEmpleadosToolStripMenuItem
            // 
            this.mantenimientoDeEmpleadosToolStripMenuItem.Name = "mantenimientoDeEmpleadosToolStripMenuItem";
            this.mantenimientoDeEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(178, 20);
            this.mantenimientoDeEmpleadosToolStripMenuItem.Text = "Mantenimiento de Empleados";
            this.mantenimientoDeEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoDeEmpleadosToolStripMenuItem_Click);
            // 
            // mantenimientoDeProveedoresToolStripMenuItem
            // 
            this.mantenimientoDeProveedoresToolStripMenuItem.Name = "mantenimientoDeProveedoresToolStripMenuItem";
            this.mantenimientoDeProveedoresToolStripMenuItem.Size = new System.Drawing.Size(185, 20);
            this.mantenimientoDeProveedoresToolStripMenuItem.Text = "Mantenimiento de Proveedores";
            this.mantenimientoDeProveedoresToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoDeProveedoresToolStripMenuItem_Click);
            // 
            // mantenimientoDeProductosToolStripMenuItem
            // 
            this.mantenimientoDeProductosToolStripMenuItem.Name = "mantenimientoDeProductosToolStripMenuItem";
            this.mantenimientoDeProductosToolStripMenuItem.Size = new System.Drawing.Size(174, 20);
            this.mantenimientoDeProductosToolStripMenuItem.Text = "Mantenimiento de Productos";
            this.mantenimientoDeProductosToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoDeProductosToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // MDIGestionInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(827, 389);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "MDIGestionInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Inventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIGestionInventario_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MDIGestionInventario_FormClosed);
            this.Load += new System.EventHandler(this.MDIGestionInventario_Load);
            this.Resize += new System.EventHandler(this.MDIGestionInventario_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoDeEmpleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoDeProveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}