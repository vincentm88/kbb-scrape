using System;

namespace KBBWebView
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.label1 = new System.Windows.Forms.Label();
            this.getYrsBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.loadVehicleBtn = new System.Windows.Forms.Button();
            this.exportBodysBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(784, 761);
            this.webBrowser1.TabIndex = 0;
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView.Location = new System.Drawing.Point(0, 0);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(784, 761);
            this.webView.Source = new System.Uri("https://www.thecardonegroup.com/", System.UriKind.Absolute);
            this.webView.TabIndex = 1;
            this.webView.ZoomFactor = 1D;
            this.webView.SourceChanged += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs>(this.webViewSourceChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // getYrsBtn
            // 
            this.getYrsBtn.Location = new System.Drawing.Point(207, 9);
            this.getYrsBtn.Name = "getYrsBtn";
            this.getYrsBtn.Size = new System.Drawing.Size(75, 23);
            this.getYrsBtn.TabIndex = 3;
            this.getYrsBtn.Text = "Add To List";
            this.getYrsBtn.UseVisualStyleBackColor = true;
            this.getYrsBtn.Click += new System.EventHandler(this.getYrsBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(288, 9);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(75, 23);
            this.exportBtn.TabIndex = 4;
            this.exportBtn.Text = "Export List";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(369, 9);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(75, 23);
            this.loadBtn.TabIndex = 5;
            this.loadBtn.Text = "Load List";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // loadVehicleBtn
            // 
            this.loadVehicleBtn.Location = new System.Drawing.Point(450, 9);
            this.loadVehicleBtn.Name = "loadVehicleBtn";
            this.loadVehicleBtn.Size = new System.Drawing.Size(90, 23);
            this.loadVehicleBtn.TabIndex = 7;
            this.loadVehicleBtn.Text = "Get Bodys List";
            this.loadVehicleBtn.UseVisualStyleBackColor = true;
            this.loadVehicleBtn.Click += new System.EventHandler(this.loadVehicleBtn_Click);
            // 
            // exportBodysBtn
            // 
            this.exportBodysBtn.Location = new System.Drawing.Point(546, 9);
            this.exportBodysBtn.Name = "exportBodysBtn";
            this.exportBodysBtn.Size = new System.Drawing.Size(116, 23);
            this.exportBodysBtn.TabIndex = 8;
            this.exportBodysBtn.Text = "Export Bodys List";
            this.exportBodysBtn.UseVisualStyleBackColor = true;
            this.exportBodysBtn.Click += new System.EventHandler(this.exportBodysBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.exportBodysBtn);
            this.Controls.Add(this.loadVehicleBtn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.getYrsBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button getYrsBtn;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button loadVehicleBtn;
        private System.Windows.Forms.Button exportBodysBtn;
    }
}

