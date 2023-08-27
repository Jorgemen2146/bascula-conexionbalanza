namespace bascula
{
    partial class bascula
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
            this.label1 = new System.Windows.Forms.Label();
            this.spBalanza = new System.IO.Ports.SerialPort(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblestado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblultimahora = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblultimopesaje = new System.Windows.Forms.Label();
            this.lblerror = new System.Windows.Forms.Label();
            this.timerconexion = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estado";
            // 
            // lblestado
            // 
            this.lblestado.AutoSize = true;
            this.lblestado.Location = new System.Drawing.Point(212, 42);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(63, 16);
            this.lblestado.TabIndex = 2;
            this.lblestado.Text = "lblestado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ultima Hora Pesaje";
            // 
            // lblultimahora
            // 
            this.lblultimahora.AutoSize = true;
            this.lblultimahora.Location = new System.Drawing.Point(215, 79);
            this.lblultimahora.Name = "lblultimahora";
            this.lblultimahora.Size = new System.Drawing.Size(0, 16);
            this.lblultimahora.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ultimo Pesaje";
            // 
            // lblultimopesaje
            // 
            this.lblultimopesaje.AutoSize = true;
            this.lblultimopesaje.Location = new System.Drawing.Point(215, 127);
            this.lblultimopesaje.Name = "lblultimopesaje";
            this.lblultimopesaje.Size = new System.Drawing.Size(0, 16);
            this.lblultimopesaje.TabIndex = 6;
            // 
            // lblerror
            // 
            this.lblerror.AutoSize = true;
            this.lblerror.Location = new System.Drawing.Point(57, 273);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(0, 16);
            this.lblerror.TabIndex = 7;
            // 
            // timerconexion
            // 
            this.timerconexion.Enabled = true;
            this.timerconexion.Interval = 30000;
            this.timerconexion.Tick += new System.EventHandler(this.timerconexion_Tick);
            // 
            // bascula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 344);
            this.Controls.Add(this.lblerror);
            this.Controls.Add(this.lblultimopesaje);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblultimahora);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblestado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "bascula";
            this.Text = "bascula";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.bascula_FormClosing);
            this.Load += new System.EventHandler(this.bascula_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort spBalanza;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblultimahora;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblultimopesaje;
        private System.Windows.Forms.Label lblerror;
        private System.Windows.Forms.Timer timerconexion;
    }
}

