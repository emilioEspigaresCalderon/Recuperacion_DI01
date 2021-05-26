
namespace Recuperacion_Tarea_DI01
{
    partial class Details
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelSizes = new System.Windows.Forms.Label();
            this.labelColors = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelProductID = new System.Windows.Forms.Label();
            this.textBoxProductID = new System.Windows.Forms.TextBox();
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveChangesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(43, 21);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(45, 17);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(9, 53);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(79, 17);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Text = "Description";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(94, 18);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(694, 22);
            this.textBoxName.TabIndex = 3;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(94, 53);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(694, 22);
            this.textBoxDescription.TabIndex = 4;
            // 
            // labelSizes
            // 
            this.labelSizes.AutoSize = true;
            this.labelSizes.Location = new System.Drawing.Point(46, 130);
            this.labelSizes.Name = "labelSizes";
            this.labelSizes.Size = new System.Drawing.Size(42, 17);
            this.labelSizes.TabIndex = 5;
            this.labelSizes.Text = "Sizes";
            // 
            // labelColors
            // 
            this.labelColors.AutoSize = true;
            this.labelColors.Location = new System.Drawing.Point(40, 179);
            this.labelColors.Name = "labelColors";
            this.labelColors.Size = new System.Drawing.Size(48, 17);
            this.labelColors.TabIndex = 6;
            this.labelColors.Text = "Colors";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(48, 93);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(40, 17);
            this.labelPrice.TabIndex = 7;
            this.labelPrice.Text = "Price";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(94, 93);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(141, 22);
            this.textBoxPrice.TabIndex = 8;
            // 
            // labelProductID
            // 
            this.labelProductID.AutoSize = true;
            this.labelProductID.Location = new System.Drawing.Point(300, 93);
            this.labelProductID.Name = "labelProductID";
            this.labelProductID.Size = new System.Drawing.Size(74, 17);
            this.labelProductID.TabIndex = 9;
            this.labelProductID.Text = "Product ID";
            // 
            // textBoxProductID
            // 
            this.textBoxProductID.Location = new System.Drawing.Point(380, 93);
            this.textBoxProductID.Name = "textBoxProductID";
            this.textBoxProductID.Size = new System.Drawing.Size(101, 22);
            this.textBoxProductID.TabIndex = 10;
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.Location = new System.Drawing.Point(94, 233);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(292, 205);
            this.imagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePictureBox.TabIndex = 11;
            this.imagePictureBox.TabStop = false;
            this.imagePictureBox.Click += new System.EventHandler(this.imagePictureBox_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "File";
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Location = new System.Drawing.Point(672, 410);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(116, 28);
            this.saveChangesButton.TabIndex = 12;
            this.saveChangesButton.Text = "Save Changes";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.imagePictureBox);
            this.Controls.Add(this.textBoxProductID);
            this.Controls.Add(this.labelProductID);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelColors);
            this.Controls.Add(this.labelSizes);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelName);
            this.Name = "Details";
            this.Text = "Details";
            this.Load += new System.EventHandler(this.Details_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelSizes;
        private System.Windows.Forms.Label labelColors;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelProductID;
        private System.Windows.Forms.TextBox textBoxProductID;
        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button saveChangesButton;
    }
}