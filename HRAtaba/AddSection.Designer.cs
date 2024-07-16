namespace HRAtaba
{
    partial class AddSection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSection));
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.NameTxt = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTxt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(37, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 49);
            this.label2.TabIndex = 11017;
            this.label2.Text = "اسم القسم : ";
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Appearance.BackColor = System.Drawing.Color.PapayaWhip;
            this.BtnSave.Appearance.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.BtnSave.Appearance.ForeColor = System.Drawing.Color.Black;
            this.BtnSave.Appearance.Options.UseBackColor = true;
            this.BtnSave.Appearance.Options.UseFont = true;
            this.BtnSave.Appearance.Options.UseForeColor = true;
            this.BtnSave.AppearanceDisabled.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BtnSave.AppearanceDisabled.ForeColor = System.Drawing.Color.Silver;
            this.BtnSave.AppearanceDisabled.Options.UseBackColor = true;
            this.BtnSave.AppearanceDisabled.Options.UseForeColor = true;
            this.BtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.BtnSave.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.BtnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnSave.ImageOptions.SvgImage")));
            this.BtnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.BtnSave.Location = new System.Drawing.Point(246, 173);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(851, 84);
            this.BtnSave.TabIndex = 11020;
            this.BtnSave.Text = "حـفظ";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // NameTxt
            // 
            this.NameTxt.Location = new System.Drawing.Point(246, 94);
            this.NameTxt.Margin = new System.Windows.Forms.Padding(4);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.NameTxt.Properties.Appearance.Options.UseFont = true;
            this.NameTxt.Size = new System.Drawing.Size(851, 56);
            this.NameTxt.TabIndex = 11016;
            // 
            // AddSection
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 360);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameTxt);
            this.IconOptions.Image = global::HRAtaba.Properties.Resources.logotrust;
            this.Name = "AddSection";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "اضافة قسم";
            ((System.ComponentModel.ISupportInitialize)(this.NameTxt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit NameTxt;
        public DevExpress.XtraEditors.SimpleButton BtnSave;
    }
}