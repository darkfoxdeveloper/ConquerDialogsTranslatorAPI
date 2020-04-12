namespace UsingAPIExample
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.sourceLang = new System.Windows.Forms.ComboBox();
            this.targetLang = new System.Windows.Forms.ComboBox();
            this.clearCache = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(7, 12);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(360, 368);
            this.txtSource.TabIndex = 0;
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(373, 12);
            this.txtTarget.Multiline = true;
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(360, 368);
            this.txtTarget.TabIndex = 1;
            // 
            // btnTranslate
            // 
            this.btnTranslate.Location = new System.Drawing.Point(285, 400);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(160, 39);
            this.btnTranslate.TabIndex = 2;
            this.btnTranslate.Text = "Translate";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.BtnTranslate_Click);
            // 
            // sourceLang
            // 
            this.sourceLang.FormattingEnabled = true;
            this.sourceLang.Location = new System.Drawing.Point(187, 406);
            this.sourceLang.Name = "sourceLang";
            this.sourceLang.Size = new System.Drawing.Size(80, 28);
            this.sourceLang.TabIndex = 3;
            // 
            // targetLang
            // 
            this.targetLang.FormattingEnabled = true;
            this.targetLang.Location = new System.Drawing.Point(460, 406);
            this.targetLang.Name = "targetLang";
            this.targetLang.Size = new System.Drawing.Size(80, 28);
            this.targetLang.TabIndex = 4;
            // 
            // clearCache
            // 
            this.clearCache.Location = new System.Drawing.Point(613, 400);
            this.clearCache.Name = "clearCache";
            this.clearCache.Size = new System.Drawing.Size(110, 39);
            this.clearCache.TabIndex = 5;
            this.clearCache.Text = "Clear Cache";
            this.clearCache.UseVisualStyleBackColor = true;
            this.clearCache.Click += new System.EventHandler(this.ClearCache_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 450);
            this.Controls.Add(this.clearCache);
            this.Controls.Add(this.targetLang);
            this.Controls.Add(this.sourceLang);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.txtSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Using the API - Example";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.ComboBox sourceLang;
        private System.Windows.Forms.ComboBox targetLang;
        private System.Windows.Forms.Button clearCache;
    }
}

