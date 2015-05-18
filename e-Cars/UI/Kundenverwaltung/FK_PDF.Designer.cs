namespace e_Cars.UI.Kundenverwaltung
{
    partial class FK_PDF
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                axFoxitCtl1.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FK_PDF));
            this.axFoxitCtl1 = new AxFOXITREADERLib.AxFoxitCtl();
            ((System.ComponentModel.ISupportInitialize)(this.axFoxitCtl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axFoxitCtl1
            // 
            this.axFoxitCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axFoxitCtl1.Enabled = true;
            this.axFoxitCtl1.Location = new System.Drawing.Point(0, 0);
            this.axFoxitCtl1.Name = "axFoxitCtl1";
            this.axFoxitCtl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFoxitCtl1.OcxState")));
            this.axFoxitCtl1.Size = new System.Drawing.Size(301, 293);
            this.axFoxitCtl1.TabIndex = 0;
            // 
            // FK_PDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axFoxitCtl1);
            this.Name = "FK_PDF";
            this.Size = new System.Drawing.Size(301, 293);
            ((System.ComponentModel.ISupportInitialize)(this.axFoxitCtl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxFOXITREADERLib.AxFoxitCtl axFoxitCtl1;

    }
}
