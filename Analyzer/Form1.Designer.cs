namespace Analyzer
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
            this.CBProviderAnalyze = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CBProviderReport = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBDatabases = new System.Windows.Forms.ComboBox();
            this.CBTablesSave = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonAnalyze = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.CBProcedures = new System.Windows.Forms.CheckBox();
            this.CBDateCreated = new System.Windows.Forms.CheckBox();
            this.CBDateCurrent = new System.Windows.Forms.CheckBox();
            this.DGVMain = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMain)).BeginInit();
            this.SuspendLayout();
            // 
            // CBProviderAnalyze
            // 
            this.CBProviderAnalyze.FormattingEnabled = true;
            this.CBProviderAnalyze.Location = new System.Drawing.Point(12, 34);
            this.CBProviderAnalyze.Name = "CBProviderAnalyze";
            this.CBProviderAnalyze.Size = new System.Drawing.Size(151, 28);
            this.CBProviderAnalyze.TabIndex = 0;
            this.CBProviderAnalyze.SelectedIndexChanged += new System.EventHandler(this.CBProviderAnalyze_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Analyze from";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CBProviderReport
            // 
            this.CBProviderReport.FormattingEnabled = true;
            this.CBProviderReport.Location = new System.Drawing.Point(12, 97);
            this.CBProviderReport.Name = "CBProviderReport";
            this.CBProviderReport.Size = new System.Drawing.Size(151, 28);
            this.CBProviderReport.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(14, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Save report to";
            // 
            // CBDatabases
            // 
            this.CBDatabases.FormattingEnabled = true;
            this.CBDatabases.Location = new System.Drawing.Point(201, 34);
            this.CBDatabases.Name = "CBDatabases";
            this.CBDatabases.Size = new System.Drawing.Size(151, 28);
            this.CBDatabases.TabIndex = 3;
            this.CBDatabases.SelectedIndexChanged += new System.EventHandler(this.CBDatabases_SelectedIndexChanged);
            // 
            // CBTablesSave
            // 
            this.CBTablesSave.FormattingEnabled = true;
            this.CBTablesSave.Location = new System.Drawing.Point(201, 97);
            this.CBTablesSave.Name = "CBTablesSave";
            this.CBTablesSave.Size = new System.Drawing.Size(151, 28);
            this.CBTablesSave.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(201, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Table";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(201, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "DataBase";
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // ButtonAnalyze
            // 
            this.ButtonAnalyze.Location = new System.Drawing.Point(388, 33);
            this.ButtonAnalyze.Name = "ButtonAnalyze";
            this.ButtonAnalyze.Size = new System.Drawing.Size(94, 29);
            this.ButtonAnalyze.TabIndex = 5;
            this.ButtonAnalyze.Text = "Analyze";
            this.ButtonAnalyze.UseVisualStyleBackColor = true;
            this.ButtonAnalyze.Click += new System.EventHandler(this.ButtonAnalyze_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(388, 97);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(94, 29);
            this.ButtonSave.TabIndex = 7;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // CBProcedures
            // 
            this.CBProcedures.AutoSize = true;
            this.CBProcedures.Location = new System.Drawing.Point(12, 144);
            this.CBProcedures.Name = "CBProcedures";
            this.CBProcedures.Size = new System.Drawing.Size(104, 24);
            this.CBProcedures.TabIndex = 8;
            this.CBProcedures.Text = "Procedures";
            this.CBProcedures.UseVisualStyleBackColor = true;
            // 
            // CBDateCreated
            // 
            this.CBDateCreated.AutoSize = true;
            this.CBDateCreated.Location = new System.Drawing.Point(150, 144);
            this.CBDateCreated.Name = "CBDateCreated";
            this.CBDateCreated.Size = new System.Drawing.Size(98, 24);
            this.CBDateCreated.TabIndex = 8;
            this.CBDateCreated.Text = "CreatedAt";
            this.CBDateCreated.UseVisualStyleBackColor = true;
            // 
            // CBDateCurrent
            // 
            this.CBDateCurrent.AutoSize = true;
            this.CBDateCurrent.Location = new System.Drawing.Point(287, 144);
            this.CBDateCurrent.Name = "CBDateCurrent";
            this.CBDateCurrent.Size = new System.Drawing.Size(108, 24);
            this.CBDateCurrent.TabIndex = 8;
            this.CBDateCurrent.Text = "ReportDate";
            this.CBDateCurrent.UseVisualStyleBackColor = true;
            // 
            // DGVMain
            // 
            this.DGVMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMain.Location = new System.Drawing.Point(3, 460);
            this.DGVMain.Name = "DGVMain";
            this.DGVMain.ReadOnly = true;
            this.DGVMain.RowHeadersWidth = 51;
            this.DGVMain.RowTemplate.Height = 29;
            this.DGVMain.Size = new System.Drawing.Size(94, 10);
            this.DGVMain.TabIndex = 6;
            this.DGVMain.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 279);
            this.Controls.Add(this.CBDateCurrent);
            this.Controls.Add(this.CBDateCreated);
            this.Controls.Add(this.CBProcedures);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.DGVMain);
            this.Controls.Add(this.ButtonAnalyze);
            this.Controls.Add(this.CBTablesSave);
            this.Controls.Add(this.CBDatabases);
            this.Controls.Add(this.CBProviderReport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBProviderAnalyze);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox CBProviderAnalyze;
        private Label label1;
        private ComboBox CBProviderReport;
        private Label label2;
        private ComboBox CBDatabases;
        private ComboBox CBTablesSave;
        private Label label3;
        private Label label4;
        private Button ButtonAnalyze;
        private Button ButtonSave;
        private CheckBox CBProcedures;
        private CheckBox CBDateCreated;
        private CheckBox CBDateCurrent;
        private DataGridView DGVMain;
    }
}