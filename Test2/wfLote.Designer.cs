namespace Test2
{
    partial class wfLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wfLote));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumLote = new System.Windows.Forms.TextBox();
            this.txtNumParcela = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtManazana = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGuardaLote = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NÚMERO DE LOTE:";
            // 
            // txtNumLote
            // 
            this.txtNumLote.Location = new System.Drawing.Point(183, 69);
            this.txtNumLote.Name = "txtNumLote";
            this.txtNumLote.Size = new System.Drawing.Size(100, 20);
            this.txtNumLote.TabIndex = 1;
            // 
            // txtNumParcela
            // 
            this.txtNumParcela.Location = new System.Drawing.Point(203, 111);
            this.txtNumParcela.Name = "txtNumParcela";
            this.txtNumParcela.Size = new System.Drawing.Size(100, 20);
            this.txtNumParcela.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "NÚMERO DE PARCELA:";
            // 
            // txtManazana
            // 
            this.txtManazana.Location = new System.Drawing.Point(203, 148);
            this.txtManazana.Name = "txtManazana";
            this.txtManazana.Size = new System.Drawing.Size(100, 20);
            this.txtManazana.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "MANZANA:\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnGuardaLote
            // 
            this.btnGuardaLote.Location = new System.Drawing.Point(112, 200);
            this.btnGuardaLote.Name = "btnGuardaLote";
            this.btnGuardaLote.Size = new System.Drawing.Size(120, 29);
            this.btnGuardaLote.TabIndex = 7;
            this.btnGuardaLote.Text = "GUARDAR LOTE";
            this.btnGuardaLote.UseVisualStyleBackColor = true;
            this.btnGuardaLote.Click += new System.EventHandler(this.btnGuardaLote_Click);
            // 
            // wfLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 241);
            this.ControlBox = false;
            this.Controls.Add(this.btnGuardaLote);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtManazana);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumParcela);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumLote);
            this.Controls.Add(this.label1);
            this.Name = "wfLote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATOS DEL LOTE";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumLote;
        private System.Windows.Forms.TextBox txtNumParcela;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtManazana;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGuardaLote;
    }
}