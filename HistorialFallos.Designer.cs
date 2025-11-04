namespace SistemaInventarioColchones
{
    partial class HistorialFallos
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
            this.dgvHistorialFallos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialFallos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorialFallos
            // 
            this.dgvHistorialFallos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialFallos.Location = new System.Drawing.Point(146, 133);
            this.dgvHistorialFallos.Name = "dgvHistorialFallos";
            this.dgvHistorialFallos.RowHeadersWidth = 62;
            this.dgvHistorialFallos.RowTemplate.Height = 28;
            this.dgvHistorialFallos.Size = new System.Drawing.Size(942, 537);
            this.dgvHistorialFallos.TabIndex = 0;
            this.dgvHistorialFallos.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvHistorialFallos_UserDeletingRow);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(486, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ususarios Bloqueados";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // HistorialFallos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 1011);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHistorialFallos);
            this.Name = "HistorialFallos";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.HistorialFallos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialFallos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorialFallos;
        private System.Windows.Forms.Label label1;
    }
}