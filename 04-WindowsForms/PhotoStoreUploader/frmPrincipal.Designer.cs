namespace PhotoStoreUploader
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.panel1 = new System.Windows.Forms.Panel();
			this.grpControles = new System.Windows.Forms.GroupBox();
			this.btnRemover = new System.Windows.Forms.Button();
			this.btnEviarTodas = new System.Windows.Forms.Button();
			this.btnEnviar = new System.Windows.Forms.Button();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNome = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnProxima = new System.Windows.Forms.Button();
			this.btnAnterior = new System.Windows.Forms.Button();
			this.lblArquivo = new System.Windows.Forms.Label();
			this.btnAbrirPasta = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.grpControles.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.grpControles);
			this.panel1.Controls.Add(this.btnProxima);
			this.panel1.Controls.Add(this.btnAnterior);
			this.panel1.Controls.Add(this.lblArquivo);
			this.panel1.Controls.Add(this.btnAbrirPasta);
			this.panel1.Location = new System.Drawing.Point(740, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(299, 582);
			this.panel1.TabIndex = 0;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// grpControles
			// 
			this.grpControles.Controls.Add(this.btnRemover);
			this.grpControles.Controls.Add(this.btnEviarTodas);
			this.grpControles.Controls.Add(this.btnEnviar);
			this.grpControles.Controls.Add(this.txtNumero);
			this.grpControles.Controls.Add(this.label2);
			this.grpControles.Controls.Add(this.txtNome);
			this.grpControles.Controls.Add(this.label1);
			this.grpControles.Location = new System.Drawing.Point(3, 84);
			this.grpControles.Name = "grpControles";
			this.grpControles.Size = new System.Drawing.Size(293, 131);
			this.grpControles.TabIndex = 4;
			this.grpControles.TabStop = false;
			this.grpControles.Text = "Informações";
			// 
			// btnRemover
			// 
			this.btnRemover.Location = new System.Drawing.Point(212, 102);
			this.btnRemover.Name = "btnRemover";
			this.btnRemover.Size = new System.Drawing.Size(75, 23);
			this.btnRemover.TabIndex = 6;
			this.btnRemover.Text = "Remover";
			this.btnRemover.UseVisualStyleBackColor = true;
			// 
			// btnEviarTodas
			// 
			this.btnEviarTodas.Location = new System.Drawing.Point(90, 102);
			this.btnEviarTodas.Name = "btnEviarTodas";
			this.btnEviarTodas.Size = new System.Drawing.Size(100, 23);
			this.btnEviarTodas.TabIndex = 5;
			this.btnEviarTodas.Text = "Enviar Todas";
			this.btnEviarTodas.UseVisualStyleBackColor = true;
			// 
			// btnEnviar
			// 
			this.btnEnviar.Location = new System.Drawing.Point(9, 102);
			this.btnEnviar.Name = "btnEnviar";
			this.btnEnviar.Size = new System.Drawing.Size(75, 23);
			this.btnEnviar.TabIndex = 4;
			this.btnEnviar.Text = "Enviar";
			this.btnEnviar.UseVisualStyleBackColor = true;
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(60, 51);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(227, 20);
			this.txtNumero.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Número";
			// 
			// txtNome
			// 
			this.txtNome.Location = new System.Drawing.Point(60, 25);
			this.txtNome.Name = "txtNome";
			this.txtNome.Size = new System.Drawing.Size(227, 20);
			this.txtNome.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nome";
			// 
			// btnProxima
			// 
			this.btnProxima.Location = new System.Drawing.Point(221, 43);
			this.btnProxima.Name = "btnProxima";
			this.btnProxima.Size = new System.Drawing.Size(75, 23);
			this.btnProxima.TabIndex = 3;
			this.btnProxima.Text = "Próxima ->";
			this.btnProxima.UseVisualStyleBackColor = true;
			// 
			// btnAnterior
			// 
			this.btnAnterior.Location = new System.Drawing.Point(3, 43);
			this.btnAnterior.Name = "btnAnterior";
			this.btnAnterior.Size = new System.Drawing.Size(75, 23);
			this.btnAnterior.TabIndex = 2;
			this.btnAnterior.Text = "<- Anterior";
			this.btnAnterior.UseVisualStyleBackColor = true;
			// 
			// lblArquivo
			// 
			this.lblArquivo.AutoSize = true;
			this.lblArquivo.Location = new System.Drawing.Point(85, 12);
			this.lblArquivo.Name = "lblArquivo";
			this.lblArquivo.Size = new System.Drawing.Size(89, 13);
			this.lblArquivo.TabIndex = 1;
			this.lblArquivo.Text = "Arquivo: Nenhum";
			// 
			// btnAbrirPasta
			// 
			this.btnAbrirPasta.Location = new System.Drawing.Point(3, 3);
			this.btnAbrirPasta.Name = "btnAbrirPasta";
			this.btnAbrirPasta.Size = new System.Drawing.Size(75, 23);
			this.btnAbrirPasta.TabIndex = 0;
			this.btnAbrirPasta.Text = "Abrir Pasta";
			this.btnAbrirPasta.UseVisualStyleBackColor = true;
			// 
			// frmPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1051, 606);
			this.Controls.Add(this.panel1);
			this.Name = "frmPrincipal";
			this.Text = "PhotoStore Uploader";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.grpControles.ResumeLayout(false);
			this.grpControles.PerformLayout();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnProxima;
		private System.Windows.Forms.Button btnAnterior;
		private System.Windows.Forms.Label lblArquivo;
		private System.Windows.Forms.Button btnAbrirPasta;
		private System.Windows.Forms.GroupBox grpControles;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNome;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnRemover;
		private System.Windows.Forms.Button btnEviarTodas;
		private System.Windows.Forms.Button btnEnviar;
	}
}

