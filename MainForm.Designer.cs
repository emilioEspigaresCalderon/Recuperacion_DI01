
using System;

namespace Recuperacion_Tarea_DI01
{
    partial class MainForm
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
            this.comboBoxCategoria = new System.Windows.Forms.ComboBox();
            this.comboBoxSubcategoria = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.buttonFrench = new System.Windows.Forms.Button();
            this.buttonEnglish = new System.Windows.Forms.Button();
            this.checkBoxFilters = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.Location = new System.Drawing.Point(424, 12);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(257, 24);
            this.comboBoxCategoria.TabIndex = 1;
            this.comboBoxCategoria.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategoria_SelectedIndexChanged);
            // 
            // comboBoxSubcategoria
            // 
            this.comboBoxSubcategoria.FormattingEnabled = true;
            this.comboBoxSubcategoria.Location = new System.Drawing.Point(424, 42);
            this.comboBoxSubcategoria.Name = "comboBoxSubcategoria";
            this.comboBoxSubcategoria.Size = new System.Drawing.Size(257, 24);
            this.comboBoxSubcategoria.TabIndex = 2;
            this.comboBoxSubcategoria.SelectedIndexChanged += new System.EventHandler(this.comboBoxSubcategoria_SelectedIndexChanged);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(12, 12);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(366, 22);
            this.textBoxSearch.TabIndex = 3;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(12, 43);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.ItemHeight = 16;
            this.listBoxResults.Location = new System.Drawing.Point(12, 115);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(794, 388);
            this.listBoxResults.TabIndex = 7;
            this.listBoxResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxResults_MouseDoubleClick);
            // 
            // buttonFrench
            // 
            this.buttonFrench.Location = new System.Drawing.Point(687, 67);
            this.buttonFrench.Name = "buttonFrench";
            this.buttonFrench.Size = new System.Drawing.Size(119, 42);
            this.buttonFrench.TabIndex = 9;
            this.buttonFrench.Text = "French";
            this.buttonFrench.UseVisualStyleBackColor = true;
            this.buttonFrench.Click += new System.EventHandler(this.buttonFrench_Click);
            // 
            // buttonEnglish
            // 
            this.buttonEnglish.Location = new System.Drawing.Point(687, 14);
            this.buttonEnglish.Name = "buttonEnglish";
            this.buttonEnglish.Size = new System.Drawing.Size(119, 38);
            this.buttonEnglish.TabIndex = 10;
            this.buttonEnglish.Text = "English";
            this.buttonEnglish.UseVisualStyleBackColor = true;
            this.buttonEnglish.Click += new System.EventHandler(this.buttonEnglish_Click);
            // 
            // checkBoxFilters
            // 
            this.checkBoxFilters.AutoSize = true;
            this.checkBoxFilters.Location = new System.Drawing.Point(424, 73);
            this.checkBoxFilters.Name = "checkBoxFilters";
            this.checkBoxFilters.Size = new System.Drawing.Size(93, 21);
            this.checkBoxFilters.TabIndex = 11;
            this.checkBoxFilters.Text = "Use filters";
            this.checkBoxFilters.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 515);
            this.Controls.Add(this.checkBoxFilters);
            this.Controls.Add(this.buttonEnglish);
            this.Controls.Add(this.buttonFrench);
            this.Controls.Add(this.listBoxResults);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.comboBoxSubcategoria);
            this.Controls.Add(this.comboBoxCategoria);
            this.Name = "MainForm";
            this.Text = "Recuperacion Tarea DI01";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Recuperacion_Tarea_DI01_Load(object sender, EventArgs e)
        {
           
        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.ComboBox comboBoxSubcategoria;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Button buttonFrench;
        private System.Windows.Forms.Button buttonEnglish;
        private System.Windows.Forms.CheckBox checkBoxFilters;
    }
}

