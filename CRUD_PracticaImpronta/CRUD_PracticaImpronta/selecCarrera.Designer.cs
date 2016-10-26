namespace CRUD_PracticaImpronta
{
    partial class selecCarrera
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
            this.Carreras = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Carreras
            // 
            this.Carreras.FormattingEnabled = true;
            this.Carreras.Location = new System.Drawing.Point(30, 27);
            this.Carreras.Name = "Carreras";
            this.Carreras.Size = new System.Drawing.Size(229, 21);
            this.Carreras.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // selecCarrera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 100);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Carreras);
            this.Name = "selecCarrera";
            this.Text = "selecCarrera";
            this.Load += new System.EventHandler(this.selecCarrera_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Carreras;
        private System.Windows.Forms.Button button1;
    }
}