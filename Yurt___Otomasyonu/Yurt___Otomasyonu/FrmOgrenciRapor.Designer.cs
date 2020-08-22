namespace Yurt___Otomasyonu
{
    partial class FrmOgrenciRapor
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOgrenciRapor));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.YurtKayıtDataSet7 = new Yurt___Otomasyonu.YurtKayıtDataSet7();
            this.OgrenciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OgrenciTableAdapter = new Yurt___Otomasyonu.YurtKayıtDataSet7TableAdapters.OgrenciTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.YurtKayıtDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OgrenciBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.OgrenciBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Yurt___Otomasyonu.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(877, 414);
            this.reportViewer1.TabIndex = 0;
            // 
            // YurtKayıtDataSet7
            // 
            this.YurtKayıtDataSet7.DataSetName = "YurtKayıtDataSet7";
            this.YurtKayıtDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // OgrenciBindingSource
            // 
            this.OgrenciBindingSource.DataMember = "Ogrenci";
            this.OgrenciBindingSource.DataSource = this.YurtKayıtDataSet7;
            // 
            // OgrenciTableAdapter
            // 
            this.OgrenciTableAdapter.ClearBeforeFill = true;
            // 
            // FrmOgrenciRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 414);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOgrenciRapor";
            this.Text = "Öğrenci Rapor";
            this.Load += new System.EventHandler(this.FrmOgrenciRapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.YurtKayıtDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OgrenciBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource OgrenciBindingSource;
        private YurtKayıtDataSet7 YurtKayıtDataSet7;
        private YurtKayıtDataSet7TableAdapters.OgrenciTableAdapter OgrenciTableAdapter;
    }
}