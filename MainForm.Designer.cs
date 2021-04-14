
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
            this.listViewResults = new System.Windows.Forms.ListView();
            this.comboBoxCategoria = new System.Windows.Forms.ComboBox();
            this.comboBoxSubcategoria = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.englishButton = new System.Windows.Forms.Button();
            this.frenchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewResults
            // 
            this.listViewResults.HideSelection = false;
            this.listViewResults.Location = new System.Drawing.Point(12, 119);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(794, 384);
            this.listViewResults.TabIndex = 0;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.Location = new System.Drawing.Point(424, 12);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(257, 24);
            this.comboBoxCategoria.TabIndex = 1;
            // 
            // comboBoxSubcategoria
            // 
            this.comboBoxSubcategoria.FormattingEnabled = true;
            this.comboBoxSubcategoria.Location = new System.Drawing.Point(424, 42);
            this.comboBoxSubcategoria.Name = "comboBoxSubcategoria";
            this.comboBoxSubcategoria.Size = new System.Drawing.Size(257, 24);
            this.comboBoxSubcategoria.TabIndex = 2;
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
            // englishButton
            // 
            this.englishButton.Location = new System.Drawing.Point(709, 12);
            this.englishButton.Name = "englishButton";
            this.englishButton.Size = new System.Drawing.Size(75, 35);
            this.englishButton.TabIndex = 5;
            this.englishButton.Text = "English";
            this.englishButton.UseVisualStyleBackColor = true;
            // 
            // frenchButton
            // 
            this.frenchButton.Location = new System.Drawing.Point(709, 64);
            this.frenchButton.Name = "frenchButton";
            this.frenchButton.Size = new System.Drawing.Size(75, 35);
            this.frenchButton.TabIndex = 6;
            this.frenchButton.Text = "French";
            this.frenchButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 515);
            this.Controls.Add(this.frenchButton);
            this.Controls.Add(this.englishButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.comboBoxSubcategoria);
            this.Controls.Add(this.comboBoxCategoria);
            this.Controls.Add(this.listViewResults);
            this.Name = "MainForm";
            this.Text = "Recuperacion Tarea DI01";
            this.Load += new System.EventHandler(this.Recuperacion_Tarea_DI01_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Recuperacion_Tarea_DI01_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.ComboBox comboBoxSubcategoria;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button englishButton;
        private System.Windows.Forms.Button frenchButton;
    }
}

