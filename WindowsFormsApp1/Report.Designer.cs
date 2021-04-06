namespace WindowsFormsApp1
{
    partial class Report
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
            this.customerReviewGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.adminPanel = new System.Windows.Forms.Button();
            this.SortUpBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerReviewGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // customerReviewGrid
            // 
            this.customerReviewGrid.AllowUserToAddRows = false;
            this.customerReviewGrid.AllowUserToDeleteRows = false;
            this.customerReviewGrid.AllowUserToResizeColumns = false;
            this.customerReviewGrid.AllowUserToResizeRows = false;
            this.customerReviewGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customerReviewGrid.ColumnHeadersHeight = 29;
            this.customerReviewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.customerReviewGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.customerReviewGrid.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.customerReviewGrid.Location = new System.Drawing.Point(212, 55);
            this.customerReviewGrid.MultiSelect = false;
            this.customerReviewGrid.Name = "customerReviewGrid";
            this.customerReviewGrid.ReadOnly = true;
            this.customerReviewGrid.RowHeadersWidth = 51;
            this.customerReviewGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.customerReviewGrid.Size = new System.Drawing.Size(1005, 360);
            this.customerReviewGrid.TabIndex = 0;
            this.customerReviewGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerReviewGrid_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Handwriting", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Details";
            // 
            // adminPanel
            // 
            this.adminPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.adminPanel.BackColor = System.Drawing.SystemColors.Window;
            this.adminPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.adminPanel.Location = new System.Drawing.Point(1193, 397);
            this.adminPanel.Name = "adminPanel";
            this.adminPanel.Size = new System.Drawing.Size(75, 29);
            this.adminPanel.TabIndex = 10;
            this.adminPanel.Text = "ADMIN";
            this.adminPanel.UseVisualStyleBackColor = false;
            this.adminPanel.Click += new System.EventHandler(this.adminPanel_Click);
            // 
            // SortUpBtn
            // 
            this.SortUpBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.SortUpBtn.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortUpBtn.Location = new System.Drawing.Point(45, 145);
            this.SortUpBtn.Name = "SortUpBtn";
            this.SortUpBtn.Size = new System.Drawing.Size(135, 37);
            this.SortUpBtn.TabIndex = 11;
            this.SortUpBtn.Text = "SORT";
            this.SortUpBtn.UseVisualStyleBackColor = false;
            this.SortUpBtn.Click += new System.EventHandler(this.SortUpBtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(45, 268);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 37);
            this.button1.TabIndex = 14;
            this.button1.Text = "Chart";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(45, 206);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 37);
            this.button2.TabIndex = 15;
            this.button2.Text = "Add Criteria";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(11, 390);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 37);
            this.button3.TabIndex = 16;
            this.button3.Text = "Sign Out";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1140, 438);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SortUpBtn);
            this.Controls.Add(this.adminPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerReviewGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerReviewGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerReviewGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button adminPanel;
        private System.Windows.Forms.Button SortUpBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}