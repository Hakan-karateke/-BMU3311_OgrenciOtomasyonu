namespace BMÜ3311_OgrenciOtomasyonu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            OgrenciList = new DataGridView();
            No = new DataGridViewTextBoxColumn();
            İsim = new DataGridViewTextBoxColumn();
            Soyad = new DataGridViewTextBoxColumn();
            Gano = new DataGridViewTextBoxColumn();
            BolumSira = new DataGridViewTextBoxColumn();
            SınıfSıra = new DataGridViewTextBoxColumn();
            Sınıf = new DataGridViewTextBoxColumn();
            Cinsiyet = new DataGridViewTextBoxColumn();
            btnOlustur = new Button();
            btnSırala = new Button();
            btnList = new Button();
            txtAra = new TextBox();
            btnAra = new Button();
            comboBoxSırala = new ComboBox();
            btnRaporOlustur = new Button();
            ((System.ComponentModel.ISupportInitialize)OgrenciList).BeginInit();
            SuspendLayout();
            // 
            // OgrenciList
            // 
            OgrenciList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OgrenciList.Columns.AddRange(new DataGridViewColumn[] { No, İsim, Soyad, Gano, BolumSira, SınıfSıra, Sınıf, Cinsiyet });
            OgrenciList.Location = new Point(28, 139);
            OgrenciList.Name = "OgrenciList";
            OgrenciList.ReadOnly = true;
            OgrenciList.RowTemplate.Height = 25;
            OgrenciList.Size = new Size(819, 241);
            OgrenciList.TabIndex = 0;
            // 
            // No
            // 
            No.HeaderText = "Öğrenci No";
            No.Name = "No";
            No.ReadOnly = true;
            // 
            // İsim
            // 
            İsim.HeaderText = "İsim";
            İsim.Name = "İsim";
            İsim.ReadOnly = true;
            // 
            // Soyad
            // 
            Soyad.HeaderText = "Soyad";
            Soyad.Name = "Soyad";
            Soyad.ReadOnly = true;
            // 
            // Gano
            // 
            Gano.HeaderText = "Gano";
            Gano.Name = "Gano";
            Gano.ReadOnly = true;
            // 
            // BolumSira
            // 
            BolumSira.HeaderText = "BölümSira";
            BolumSira.Name = "BolumSira";
            BolumSira.ReadOnly = true;
            // 
            // SınıfSıra
            // 
            SınıfSıra.HeaderText = "Sınıf Sıra";
            SınıfSıra.Name = "SınıfSıra";
            SınıfSıra.ReadOnly = true;
            // 
            // Sınıf
            // 
            Sınıf.HeaderText = "Sınıf";
            Sınıf.Name = "Sınıf";
            Sınıf.ReadOnly = true;
            // 
            // Cinsiyet
            // 
            Cinsiyet.HeaderText = "Cinsiyet";
            Cinsiyet.Name = "Cinsiyet";
            Cinsiyet.ReadOnly = true;
            // 
            // btnOlustur
            // 
            btnOlustur.Location = new Point(55, 25);
            btnOlustur.Name = "btnOlustur";
            btnOlustur.Size = new Size(109, 38);
            btnOlustur.TabIndex = 1;
            btnOlustur.Text = "Öğrencileri Oluştur";
            btnOlustur.UseVisualStyleBackColor = true;
            btnOlustur.Click += btnOlustur_Click;
            // 
            // btnSırala
            // 
            btnSırala.Enabled = false;
            btnSırala.Location = new Point(384, 63);
            btnSırala.Name = "btnSırala";
            btnSırala.Size = new Size(109, 23);
            btnSırala.TabIndex = 2;
            btnSırala.Text = "Sırala";
            btnSırala.UseVisualStyleBackColor = true;
            btnSırala.Click += btnSırala_Click;
            // 
            // btnList
            // 
            btnList.Enabled = false;
            btnList.Location = new Point(738, 386);
            btnList.Name = "btnList";
            btnList.Size = new Size(109, 38);
            btnList.TabIndex = 4;
            btnList.Text = "Dosya Oluştur";
            btnList.UseVisualStyleBackColor = true;
            btnList.Click += btnList_Click;
            // 
            // txtAra
            // 
            txtAra.Location = new Point(654, 34);
            txtAra.Name = "txtAra";
            txtAra.Size = new Size(153, 23);
            txtAra.TabIndex = 6;
            // 
            // btnAra
            // 
            btnAra.Enabled = false;
            btnAra.Location = new Point(698, 63);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(109, 23);
            btnAra.TabIndex = 7;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // comboBoxSırala
            // 
            comboBoxSırala.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSırala.FormattingEnabled = true;
            comboBoxSırala.Items.AddRange(new object[] { "Öğrenci Noya göre", "Bölüm Sırasına göre", "Sınıf Sırasına göre", "Gano Sırasına göre", "Sadece Erkekleri", "Sadece Kızları", "1. Sınıf", "2. Sınıf", "3. Sınıf", "4. Sınıf" });
            comboBoxSırala.Location = new Point(344, 34);
            comboBoxSırala.Name = "comboBoxSırala";
            comboBoxSırala.Size = new Size(149, 23);
            comboBoxSırala.TabIndex = 8;
            // 
            // btnRaporOlustur
            // 
            btnRaporOlustur.Enabled = false;
            btnRaporOlustur.Location = new Point(600, 386);
            btnRaporOlustur.Name = "btnRaporOlustur";
            btnRaporOlustur.Size = new Size(112, 38);
            btnRaporOlustur.TabIndex = 9;
            btnRaporOlustur.Text = "Rapor Oluştur";
            btnRaporOlustur.UseVisualStyleBackColor = true;
            btnRaporOlustur.Click += btnRaporOlustur_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 450);
            Controls.Add(btnRaporOlustur);
            Controls.Add(comboBoxSırala);
            Controls.Add(btnAra);
            Controls.Add(txtAra);
            Controls.Add(btnList);
            Controls.Add(btnSırala);
            Controls.Add(btnOlustur);
            Controls.Add(OgrenciList);
            Name = "Form1";
            Text = "Ogrenci Otomasyonu";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)OgrenciList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView OgrenciList;
        private DataGridViewTextBoxColumn No;
        private DataGridViewTextBoxColumn İsim;
        private DataGridViewTextBoxColumn Soyad;
        private DataGridViewTextBoxColumn Gano;
        private DataGridViewTextBoxColumn BolumSira;
        private DataGridViewTextBoxColumn SınıfSıra;
        private DataGridViewTextBoxColumn Sınıf;
        private DataGridViewTextBoxColumn Cinsiyet;
        private Button btnOlustur;
        private Button btnSırala;
        private Button btnList;
        private TextBox txtAra;
        private Button btnAra;
        private ComboBox comboBoxSırala;
        private Button btnRaporOlustur;
    }
}