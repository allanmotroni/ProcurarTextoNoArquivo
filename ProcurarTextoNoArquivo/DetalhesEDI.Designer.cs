namespace ProcurarTextoNoArquivo
{
    partial class DetalhesEDI
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
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.Booking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetalhesBooking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Erros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PossuiErros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.buttonVerErros = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.SuspendLayout();
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
            this.Booking,
            this.DetalhesBooking,
            this.Erros,
            this.PossuiErros});
            this.dataGridViewLista.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewLista.MultiSelect = false;
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(501, 285);
            this.dataGridViewLista.TabIndex = 10;
            this.dataGridViewLista.DoubleClick += new System.EventHandler(this.dataGridViewLista_DoubleClick);
            // 
            // Booking
            // 
            this.Booking.DataPropertyName = "Descricao";
            this.Booking.HeaderText = "Booking";
            this.Booking.Name = "Booking";
            this.Booking.ReadOnly = true;
            this.Booking.Width = 71;
            // 
            // DetalhesBooking
            // 
            this.DetalhesBooking.DataPropertyName = "detalhesBooking";
            this.DetalhesBooking.HeaderText = "DetalhesBooking";
            this.DetalhesBooking.Name = "DetalhesBooking";
            this.DetalhesBooking.ReadOnly = true;
            this.DetalhesBooking.Visible = false;
            this.DetalhesBooking.Width = 113;
            // 
            // Erros
            // 
            this.Erros.DataPropertyName = "erros";
            this.Erros.HeaderText = "Erros";
            this.Erros.Name = "Erros";
            this.Erros.ReadOnly = true;
            this.Erros.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Erros.Visible = false;
            this.Erros.Width = 56;
            // 
            // PossuiErros
            // 
            this.PossuiErros.DataPropertyName = "PossuiErros";
            this.PossuiErros.HeaderText = "Erros?";
            this.PossuiErros.Name = "PossuiErros";
            this.PossuiErros.ReadOnly = true;
            this.PossuiErros.Width = 62;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Total:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(44, 309);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(0, 13);
            this.labelTotal.TabIndex = 12;
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonVerErros
            // 
            this.buttonVerErros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVerErros.Location = new System.Drawing.Point(438, 304);
            this.buttonVerErros.Name = "buttonVerErros";
            this.buttonVerErros.Size = new System.Drawing.Size(75, 23);
            this.buttonVerErros.TabIndex = 13;
            this.buttonVerErros.Text = "Ver Erros";
            this.buttonVerErros.UseVisualStyleBackColor = true;
            this.buttonVerErros.Click += new System.EventHandler(this.buttonVerErros_Click);
            // 
            // DetalhesEDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 331);
            this.Controls.Add(this.buttonVerErros);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewLista);
            this.Name = "DetalhesEDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EDI - Detalhes";
            this.Load += new System.EventHandler(this.DetalhesEDI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Booking;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetalhesBooking;
        private System.Windows.Forms.DataGridViewTextBoxColumn Erros;
        private System.Windows.Forms.DataGridViewTextBoxColumn PossuiErros;
        private System.Windows.Forms.Button buttonVerErros;
    }
}