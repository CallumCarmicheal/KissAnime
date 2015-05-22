namespace KissAnime {
    partial class Search {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.autoCompleteTextbox1 = new KissAnime.AutoCompleteTextbox();
            this.SuspendLayout();
            // 
            // autoCompleteTextbox1
            // 
            this.autoCompleteTextbox1.AutoCompleteList = ((System.Collections.Generic.List<string>)(resources.GetObject("autoCompleteTextbox1.AutoCompleteList")));
            this.autoCompleteTextbox1.CaseSensitive = false;
            this.autoCompleteTextbox1.Location = new System.Drawing.Point(12, 12);
            this.autoCompleteTextbox1.MinTypedCharacters = 2;
            this.autoCompleteTextbox1.Name = "autoCompleteTextbox1";
            this.autoCompleteTextbox1.SelectedIndex = -1;
            this.autoCompleteTextbox1.Size = new System.Drawing.Size(517, 20);
            this.autoCompleteTextbox1.TabIndex = 0;
            this.autoCompleteTextbox1.TextChanged += new System.EventHandler(this.autoCompleteTextbox1_TextChanged);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 440);
            this.Controls.Add(this.autoCompleteTextbox1);
            this.Name = "Search";
            this.Text = "Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AutoCompleteTextbox autoCompleteTextbox1;
    }
}