namespace WinFormApp.Forms.System_Management
{
    partial class FrmSeguridadRestaurar
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
            this.lblBasedeDatos = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRespaldo = new System.Windows.Forms.Button();
            this.lblBasedeDatos2 = new System.Windows.Forms.Label();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblUbicacion2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblBasedeDatos
            // 
            this.lblBasedeDatos.AutoSize = true;
            this.lblBasedeDatos.Location = new System.Drawing.Point(13, 54);
            this.lblBasedeDatos.Name = "lblBasedeDatos";
            this.lblBasedeDatos.Size = new System.Drawing.Size(158, 16);
            this.lblBasedeDatos.TabIndex = 0;
            this.lblBasedeDatos.Text = "Respaldo Base de datos";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(142, 113);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(435, 22);
            this.textBox1.TabIndex = 1;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new System.Drawing.Point(13, 118);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(68, 16);
            this.lblUbicacion.TabIndex = 2;
            this.lblUbicacion.Text = "Ubicación";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(642, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRespaldo
            // 
            this.btnRespaldo.Location = new System.Drawing.Point(642, 158);
            this.btnRespaldo.Name = "btnRespaldo";
            this.btnRespaldo.Size = new System.Drawing.Size(84, 23);
            this.btnRespaldo.TabIndex = 4;
            this.btnRespaldo.Text = "Respaldo";
            this.btnRespaldo.UseVisualStyleBackColor = true;
            this.btnRespaldo.Click += new System.EventHandler(this.btnRespaldo_Click);
            // 
            // lblBasedeDatos2
            // 
            this.lblBasedeDatos2.AutoSize = true;
            this.lblBasedeDatos2.Location = new System.Drawing.Point(13, 233);
            this.lblBasedeDatos2.Name = "lblBasedeDatos2";
            this.lblBasedeDatos2.Size = new System.Drawing.Size(157, 16);
            this.lblBasedeDatos2.TabIndex = 5;
            this.lblBasedeDatos2.Text = "Restaurar Base de datos";
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Location = new System.Drawing.Point(642, 316);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(84, 23);
            this.btnRestaurar.TabIndex = 9;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(642, 271);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Browse";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblUbicacion2
            // 
            this.lblUbicacion2.AutoSize = true;
            this.lblUbicacion2.Location = new System.Drawing.Point(13, 276);
            this.lblUbicacion2.Name = "lblUbicacion2";
            this.lblUbicacion2.Size = new System.Drawing.Size(68, 16);
            this.lblUbicacion2.TabIndex = 7;
            this.lblUbicacion2.Text = "Ubicación";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(142, 271);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(435, 22);
            this.textBox2.TabIndex = 6;
            // 
            // FrmSeguridadRestaurar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lblUbicacion2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblBasedeDatos2);
            this.Controls.Add(this.btnRespaldo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblUbicacion);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblBasedeDatos);
            this.Name = "FrmSeguridadRestaurar";
            this.Text = "Respaldo y Restaurar de BD";
            this.Load += new System.EventHandler(this.FrmSeguridadRestaurar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBasedeDatos;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRespaldo;
        private System.Windows.Forms.Label lblBasedeDatos2;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblUbicacion2;
        private System.Windows.Forms.TextBox textBox2;
    }
}