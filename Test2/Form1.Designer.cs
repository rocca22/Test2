namespace Test2
{
    partial class Form1
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCouta = new System.Windows.Forms.Button();
            this.btnReunion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(146, 159);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(124, 57);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "AGREGAR SOCIO";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCouta
            // 
            this.btnCouta.Location = new System.Drawing.Point(330, 159);
            this.btnCouta.Name = "btnCouta";
            this.btnCouta.Size = new System.Drawing.Size(124, 57);
            this.btnCouta.TabIndex = 1;
            this.btnCouta.Text = "GENERAR COUTA";
            this.btnCouta.UseVisualStyleBackColor = true;
            // 
            // btnReunion
            // 
            this.btnReunion.Location = new System.Drawing.Point(528, 159);
            this.btnReunion.Name = "btnReunion";
            this.btnReunion.Size = new System.Drawing.Size(124, 57);
            this.btnReunion.TabIndex = 2;
            this.btnReunion.Text = "REUNION";
            this.btnReunion.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReunion);
            this.Controls.Add(this.btnCouta);
            this.Controls.Add(this.btnAgregar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCouta;
        private System.Windows.Forms.Button btnReunion;
    }
}

