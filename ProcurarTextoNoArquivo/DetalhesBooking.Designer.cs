namespace ProcurarTextoNoArquivo
{
    partial class DetalhesBooking
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
            this.labelTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.Isocode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoEDI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoConteiner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxAgrupar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(35, 360);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(0, 13);
            this.labelTotal.TabIndex = 15;
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Total:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToDeleteRows = false;
            this.dataGridViewLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Isocode,
            this.TipoEDI,
            this.Quantidade,
            this.TipoConteiner});
            this.dataGridViewLista.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewLista.MultiSelect = false;
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(644, 354);
            this.dataGridViewLista.TabIndex = 13;
            // 
            // Isocode
            // 
            this.Isocode.DataPropertyName = "Isocode";
            this.Isocode.HeaderText = "ISOCODE";
            this.Isocode.Name = "Isocode";
            this.Isocode.ReadOnly = true;
            this.Isocode.Width = 80;
            // 
            // TipoEDI
            // 
            this.TipoEDI.DataPropertyName = "TipoEDI";
            this.TipoEDI.HeaderText = "Tipo EDI";
            this.TipoEDI.Name = "TipoEDI";
            this.TipoEDI.ReadOnly = true;
            this.TipoEDI.Width = 74;
            // 
            // Quantidade
            // 
            this.Quantidade.DataPropertyName = "Quantidade";
            this.Quantidade.HeaderText = "Qtd";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            this.Quantidade.Width = 49;
            // 
            // TipoConteiner
            // 
            this.TipoConteiner.DataPropertyName = "TipoConteiner";
            this.TipoConteiner.HeaderText = "Tipo Cntr";
            this.TipoConteiner.Name = "TipoConteiner";
            this.TipoConteiner.ReadOnly = true;
            this.TipoConteiner.Width = 75;
            // 
            // checkBoxAgrupar
            // 
            this.checkBoxAgrupar.AutoSize = true;
            this.checkBoxAgrupar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAgrupar.Location = new System.Drawing.Point(549, 359);
            this.checkBoxAgrupar.Name = "checkBoxAgrupar";
            this.checkBoxAgrupar.Size = new System.Drawing.Size(98, 17);
            this.checkBoxAgrupar.TabIndex = 16;
            this.checkBoxAgrupar.Text = "Agrupar Qtd.";
            this.checkBoxAgrupar.UseVisualStyleBackColor = true;
            this.checkBoxAgrupar.CheckedChanged += new System.EventHandler(this.checkBoxAgrupar_CheckedChanged);
            // 
            // DetalhesBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 381);
            this.Controls.Add(this.checkBoxAgrupar);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewLista);
            this.Name = "DetalhesBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking - Detalhes";
            this.Load += new System.EventHandler(this.DetalhesBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Isocode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoEDI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoConteiner;
        private System.Windows.Forms.CheckBox checkBoxAgrupar;
    }
}