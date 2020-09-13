namespace ProcurarTextoNoArquivo
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAbrirPasta = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonPesquisarArquivos = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxParametro = new System.Windows.Forms.TextBox();
            this.txtCaminhoPasta = new System.Windows.Forms.TextBox();
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.checkBoxData = new System.Windows.Forms.CheckBox();
            this.buttonCopiar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTotalEncontrados = new System.Windows.Forms.Label();
            this.checkBoxRegex = new System.Windows.Forms.CheckBox();
            this.checkBoxNovoFormato = new System.Windows.Forms.CheckBox();
            this.checkBoxAntigoFormato = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Arquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataUtc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caminho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pasta:";
            // 
            // buttonAbrirPasta
            // 
            this.buttonAbrirPasta.Location = new System.Drawing.Point(52, 21);
            this.buttonAbrirPasta.Name = "buttonAbrirPasta";
            this.buttonAbrirPasta.Size = new System.Drawing.Size(75, 23);
            this.buttonAbrirPasta.TabIndex = 1;
            this.buttonAbrirPasta.Text = "Abrir...";
            this.buttonAbrirPasta.UseVisualStyleBackColor = true;
            this.buttonAbrirPasta.Click += new System.EventHandler(this.buttonAbrirPasta_Click);
            // 
            // buttonPesquisarArquivos
            // 
            this.buttonPesquisarArquivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPesquisarArquivos.Location = new System.Drawing.Point(396, 151);
            this.buttonPesquisarArquivos.Name = "buttonPesquisarArquivos";
            this.buttonPesquisarArquivos.Size = new System.Drawing.Size(75, 23);
            this.buttonPesquisarArquivos.TabIndex = 4;
            this.buttonPesquisarArquivos.Text = "Pesquisar";
            this.buttonPesquisarArquivos.UseVisualStyleBackColor = true;
            this.buttonPesquisarArquivos.Click += new System.EventHandler(this.buttonPesquisarArquivos_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(89, 415);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Parâmetro:";
            // 
            // textBoxParametro
            // 
            this.textBoxParametro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxParametro.Location = new System.Drawing.Point(73, 97);
            this.textBoxParametro.Name = "textBoxParametro";
            this.textBoxParametro.Size = new System.Drawing.Size(160, 20);
            this.textBoxParametro.TabIndex = 7;
            this.textBoxParametro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxParametro_KeyPress);
            // 
            // txtCaminhoPasta
            // 
            this.txtCaminhoPasta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaminhoPasta.Location = new System.Drawing.Point(12, 48);
            this.txtCaminhoPasta.Multiline = true;
            this.txtCaminhoPasta.Name = "txtCaminhoPasta";
            this.txtCaminhoPasta.Size = new System.Drawing.Size(459, 44);
            this.txtCaminhoPasta.TabIndex = 8;
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
            this.Arquivo,
            this.Data,
            this.DataUtc,
            this.Caminho});
            this.dataGridViewLista.Location = new System.Drawing.Point(10, 177);
            this.dataGridViewLista.MultiSelect = false;
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(461, 200);
            this.dataGridViewLista.TabIndex = 9;
            this.dataGridViewLista.DoubleClick += new System.EventHandler(this.dataGridViewLista_DoubleClick);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Processados:";
            // 
            // dtpDataInicial
            // 
            this.dtpDataInicial.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpDataInicial.Enabled = false;
            this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataInicial.Location = new System.Drawing.Point(88, 150);
            this.dtpDataInicial.Name = "dtpDataInicial";
            this.dtpDataInicial.Size = new System.Drawing.Size(145, 20);
            this.dtpDataInicial.TabIndex = 13;
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpDataFinal.Enabled = false;
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataFinal.Location = new System.Drawing.Point(242, 150);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(145, 20);
            this.dtpDataFinal.TabIndex = 14;
            // 
            // checkBoxData
            // 
            this.checkBoxData.AutoSize = true;
            this.checkBoxData.Location = new System.Drawing.Point(10, 151);
            this.checkBoxData.Name = "checkBoxData";
            this.checkBoxData.Size = new System.Drawing.Size(77, 17);
            this.checkBoxData.TabIndex = 15;
            this.checkBoxData.Text = "Filtro Data:";
            this.checkBoxData.UseVisualStyleBackColor = true;
            this.checkBoxData.CheckedChanged += new System.EventHandler(this.checkBoxData_CheckedChanged);
            // 
            // buttonCopiar
            // 
            this.buttonCopiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopiar.Location = new System.Drawing.Point(396, 383);
            this.buttonCopiar.Name = "buttonCopiar";
            this.buttonCopiar.Size = new System.Drawing.Size(75, 23);
            this.buttonCopiar.TabIndex = 16;
            this.buttonCopiar.Text = "Copiar";
            this.buttonCopiar.UseVisualStyleBackColor = true;
            this.buttonCopiar.Click += new System.EventHandler(this.buttonCopiar_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Encontrados:";
            // 
            // labelTotalEncontrados
            // 
            this.labelTotalEncontrados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotalEncontrados.AutoSize = true;
            this.labelTotalEncontrados.Location = new System.Drawing.Point(89, 393);
            this.labelTotalEncontrados.Name = "labelTotalEncontrados";
            this.labelTotalEncontrados.Size = new System.Drawing.Size(0, 13);
            this.labelTotalEncontrados.TabIndex = 17;
            // 
            // checkBoxRegex
            // 
            this.checkBoxRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxRegex.AutoSize = true;
            this.checkBoxRegex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRegex.Location = new System.Drawing.Point(248, 99);
            this.checkBoxRegex.Name = "checkBoxRegex";
            this.checkBoxRegex.Size = new System.Drawing.Size(68, 17);
            this.checkBoxRegex.TabIndex = 19;
            this.checkBoxRegex.Text = "REGEX";
            this.checkBoxRegex.UseVisualStyleBackColor = true;
            this.checkBoxRegex.CheckedChanged += new System.EventHandler(this.checkBoxRegex_CheckedChanged);
            // 
            // checkBoxNovoFormato
            // 
            this.checkBoxNovoFormato.AutoSize = true;
            this.checkBoxNovoFormato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNovoFormato.Location = new System.Drawing.Point(73, 125);
            this.checkBoxNovoFormato.Name = "checkBoxNovoFormato";
            this.checkBoxNovoFormato.Size = new System.Drawing.Size(56, 17);
            this.checkBoxNovoFormato.TabIndex = 20;
            this.checkBoxNovoFormato.Text = "Novo";
            this.checkBoxNovoFormato.UseVisualStyleBackColor = true;
            // 
            // checkBoxAntigoFormato
            // 
            this.checkBoxAntigoFormato.AutoSize = true;
            this.checkBoxAntigoFormato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAntigoFormato.Location = new System.Drawing.Point(134, 125);
            this.checkBoxAntigoFormato.Name = "checkBoxAntigoFormato";
            this.checkBoxAntigoFormato.Size = new System.Drawing.Size(62, 17);
            this.checkBoxAntigoFormato.TabIndex = 21;
            this.checkBoxAntigoFormato.Text = "Antigo";
            this.checkBoxAntigoFormato.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Formato:";
            // 
            // Arquivo
            // 
            this.Arquivo.HeaderText = "Arquivo";
            this.Arquivo.Name = "Arquivo";
            this.Arquivo.ReadOnly = true;
            this.Arquivo.Width = 68;
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Width = 55;
            // 
            // DataUtc
            // 
            this.DataUtc.HeaderText = "Data Utc";
            this.DataUtc.Name = "DataUtc";
            this.DataUtc.ReadOnly = true;
            this.DataUtc.Width = 75;
            // 
            // Caminho
            // 
            this.Caminho.HeaderText = "Caminho";
            this.Caminho.Name = "Caminho";
            this.Caminho.ReadOnly = true;
            this.Caminho.Width = 73;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 435);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxAntigoFormato);
            this.Controls.Add(this.checkBoxNovoFormato);
            this.Controls.Add(this.checkBoxRegex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelTotalEncontrados);
            this.Controls.Add(this.buttonCopiar);
            this.Controls.Add(this.checkBoxData);
            this.Controls.Add(this.dtpDataFinal);
            this.Controls.Add(this.dtpDataInicial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewLista);
            this.Controls.Add(this.txtCaminhoPasta);
            this.Controls.Add(this.textBoxParametro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonPesquisarArquivos);
            this.Controls.Add(this.buttonAbrirPasta);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procurar texto em arquivos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAbrirPasta;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonPesquisarArquivos;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxParametro;
        private System.Windows.Forms.TextBox txtCaminhoPasta;
        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDataInicial;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.CheckBox checkBoxData;
        private System.Windows.Forms.Button buttonCopiar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTotalEncontrados;
        private System.Windows.Forms.CheckBox checkBoxRegex;
        private System.Windows.Forms.CheckBox checkBoxNovoFormato;
        private System.Windows.Forms.CheckBox checkBoxAntigoFormato;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arquivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataUtc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caminho;
    }
}

