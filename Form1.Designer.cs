namespace Impresora_Comprobantes
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
            this.btnGenerarPDF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tmpTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGenerarPDF
            // 
            this.btnGenerarPDF.Location = new System.Drawing.Point(257, 426);
            this.btnGenerarPDF.Name = "btnGenerarPDF";
            this.btnGenerarPDF.Size = new System.Drawing.Size(115, 23);
            this.btnGenerarPDF.TabIndex = 1;
            this.btnGenerarPDF.Text = "GENERAR PDF";
            this.btnGenerarPDF.UseVisualStyleBackColor = true;
            this.btnGenerarPDF.Click += new System.EventHandler(this.btnGenerarPDF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "CTRL + V Para obtener texto de imagen recortada";
            // 
            // tmpTxt
            // 
            this.tmpTxt.AcceptsTab = true;
            this.tmpTxt.Font = new System.Drawing.Font("Consolas", 10F);
            this.tmpTxt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tmpTxt.Location = new System.Drawing.Point(15, 25);
            this.tmpTxt.Multiline = true;
            this.tmpTxt.Name = "tmpTxt";
            this.tmpTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tmpTxt.Size = new System.Drawing.Size(357, 353);
            this.tmpTxt.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.tmpTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerarPDF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresora de Comprobantes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenerarPDF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tmpTxt;
    }
}

