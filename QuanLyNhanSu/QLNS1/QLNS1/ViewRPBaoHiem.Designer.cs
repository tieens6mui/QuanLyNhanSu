﻿
namespace QLNS1
{
    partial class ViewRPBaoHiem
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
            this.DSBaoHiemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet = new QLNS1.DataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DSBaoHiemTableAdapter = new QLNS1.DataSetTableAdapters.DSBaoHiemTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DSBaoHiemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // DSBaoHiemBindingSource
            // 
            this.DSBaoHiemBindingSource.DataMember = "DSBaoHiem";
            this.DSBaoHiemBindingSource.DataSource = this.DataSet;
            // 
            // DataSet
            // 
            this.DataSet.DataSetName = "DataSet";
            this.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetBaoHiem";
            reportDataSource1.Value = this.DSBaoHiemBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLNS1.RPBaoHiem.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1109, 540);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // DSBaoHiemTableAdapter
            // 
            this.DSBaoHiemTableAdapter.ClearBeforeFill = true;
            // 
            // ReportBaoHiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 540);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportBaoHiem";
            this.Text = "ReportBaoHiem";
            this.Load += new System.EventHandler(this.ReportBaoHiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DSBaoHiemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DSBaoHiemBindingSource;
        private DataSet DataSet;
        private DataSetTableAdapters.DSBaoHiemTableAdapter DSBaoHiemTableAdapter;
    }
}