namespace ThirdSemesterProject.WinForm
{
    partial class ProductView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            panel10 = new Panel();
            lblPlacement = new Label();
            txtPlacement = new TextBox();
            panel9 = new Panel();
            lblCurrStock = new Label();
            txtCurrStock = new TextBox();
            panel8 = new Panel();
            lblMaxStock = new Label();
            txtMaxStock = new TextBox();
            panel7 = new Panel();
            lblMinStock = new Label();
            txtMinStock = new TextBox();
            panel6 = new Panel();
            lblPrice = new Label();
            txtPrice = new TextBox();
            panel5 = new Panel();
            lblSize = new Label();
            txtSize = new TextBox();
            panel4 = new Panel();
            lblWeight = new Label();
            txtWeight = new TextBox();
            panel3 = new Panel();
            lblDescription = new Label();
            txtDescription = new TextBox();
            panel2 = new Panel();
            lblName = new Label();
            txtName = new TextBox();
            panel11 = new Panel();
            panel12 = new Panel();
            btnCancel = new Button();
            btnConfirm = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel11, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 598);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel10);
            panel1.Controls.Add(panel9);
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(514, 592);
            panel1.TabIndex = 0;
            // 
            // panel10
            // 
            panel10.Controls.Add(lblPlacement);
            panel10.Controls.Add(txtPlacement);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 535);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(5);
            panel10.Size = new Size(514, 60);
            panel10.TabIndex = 9;
            // 
            // lblPlacement
            // 
            lblPlacement.AutoSize = true;
            lblPlacement.Dock = DockStyle.Top;
            lblPlacement.Location = new Point(5, 5);
            lblPlacement.Name = "lblPlacement";
            lblPlacement.Size = new Size(81, 20);
            lblPlacement.TabIndex = 1;
            lblPlacement.Text = "Placement:";
            // 
            // txtPlacement
            // 
            txtPlacement.Dock = DockStyle.Bottom;
            txtPlacement.Location = new Point(5, 28);
            txtPlacement.Name = "txtPlacement";
            txtPlacement.Size = new Size(504, 27);
            txtPlacement.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Controls.Add(lblCurrStock);
            panel9.Controls.Add(txtCurrStock);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 475);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(5);
            panel9.Size = new Size(514, 60);
            panel9.TabIndex = 8;
            // 
            // lblCurrStock
            // 
            lblCurrStock.AutoSize = true;
            lblCurrStock.Dock = DockStyle.Top;
            lblCurrStock.Location = new Point(5, 5);
            lblCurrStock.Name = "lblCurrStock";
            lblCurrStock.Size = new Size(100, 20);
            lblCurrStock.TabIndex = 1;
            lblCurrStock.Text = "Current Stock:";
            // 
            // txtCurrStock
            // 
            txtCurrStock.Dock = DockStyle.Bottom;
            txtCurrStock.Location = new Point(5, 28);
            txtCurrStock.Name = "txtCurrStock";
            txtCurrStock.Size = new Size(504, 27);
            txtCurrStock.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Controls.Add(lblMaxStock);
            panel8.Controls.Add(txtMaxStock);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 415);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(5);
            panel8.Size = new Size(514, 60);
            panel8.TabIndex = 7;
            // 
            // lblMaxStock
            // 
            lblMaxStock.AutoSize = true;
            lblMaxStock.Dock = DockStyle.Top;
            lblMaxStock.Location = new Point(5, 5);
            lblMaxStock.Name = "lblMaxStock";
            lblMaxStock.Size = new Size(118, 20);
            lblMaxStock.TabIndex = 1;
            lblMaxStock.Text = "Maximum Stock:";
            // 
            // txtMaxStock
            // 
            txtMaxStock.Dock = DockStyle.Bottom;
            txtMaxStock.Location = new Point(5, 28);
            txtMaxStock.Name = "txtMaxStock";
            txtMaxStock.Size = new Size(504, 27);
            txtMaxStock.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(lblMinStock);
            panel7.Controls.Add(txtMinStock);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 355);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(5);
            panel7.Size = new Size(514, 60);
            panel7.TabIndex = 6;
            // 
            // lblMinStock
            // 
            lblMinStock.AutoSize = true;
            lblMinStock.Dock = DockStyle.Top;
            lblMinStock.Location = new Point(5, 5);
            lblMinStock.Name = "lblMinStock";
            lblMinStock.Size = new Size(115, 20);
            lblMinStock.TabIndex = 1;
            lblMinStock.Text = "Minimum Stock:";
            // 
            // txtMinStock
            // 
            txtMinStock.Dock = DockStyle.Bottom;
            txtMinStock.Location = new Point(5, 28);
            txtMinStock.Name = "txtMinStock";
            txtMinStock.Size = new Size(504, 27);
            txtMinStock.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(lblPrice);
            panel6.Controls.Add(txtPrice);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 295);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(5);
            panel6.Size = new Size(514, 60);
            panel6.TabIndex = 5;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Dock = DockStyle.Top;
            lblPrice.Location = new Point(5, 5);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(44, 20);
            lblPrice.TabIndex = 1;
            lblPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            txtPrice.Dock = DockStyle.Bottom;
            txtPrice.Location = new Point(5, 28);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(504, 27);
            txtPrice.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(lblSize);
            panel5.Controls.Add(txtSize);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 235);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(5);
            panel5.Size = new Size(514, 60);
            panel5.TabIndex = 4;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Dock = DockStyle.Top;
            lblSize.Location = new Point(5, 5);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(39, 20);
            lblSize.TabIndex = 1;
            lblSize.Text = "Size:";
            // 
            // txtSize
            // 
            txtSize.Dock = DockStyle.Bottom;
            txtSize.Location = new Point(5, 28);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(504, 27);
            txtSize.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblWeight);
            panel4.Controls.Add(txtWeight);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 175);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5);
            panel4.Size = new Size(514, 60);
            panel4.TabIndex = 3;
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Dock = DockStyle.Top;
            lblWeight.Location = new Point(5, 5);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(59, 20);
            lblWeight.TabIndex = 1;
            lblWeight.Text = "Weight:";
            // 
            // txtWeight
            // 
            txtWeight.Dock = DockStyle.Bottom;
            txtWeight.Location = new Point(5, 28);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(504, 27);
            txtWeight.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblDescription);
            panel3.Controls.Add(txtDescription);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 60);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(5);
            panel3.Size = new Size(514, 115);
            panel3.TabIndex = 2;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Dock = DockStyle.Top;
            lblDescription.Location = new Point(5, 5);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(88, 20);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Dock = DockStyle.Bottom;
            txtDescription.Location = new Point(5, 29);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(504, 81);
            txtDescription.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblName);
            panel2.Controls.Add(txtName);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(514, 60);
            panel2.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Dock = DockStyle.Top;
            lblName.Location = new Point(5, 5);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Dock = DockStyle.Bottom;
            txtName.Location = new Point(5, 28);
            txtName.Name = "txtName";
            txtName.Size = new Size(504, 27);
            txtName.TabIndex = 0;
            // 
            // panel11
            // 
            panel11.Controls.Add(panel12);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(523, 3);
            panel11.Name = "panel11";
            panel11.Size = new Size(274, 592);
            panel11.TabIndex = 1;
            // 
            // panel12
            // 
            panel12.Controls.Add(btnCancel);
            panel12.Controls.Add(btnConfirm);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 542);
            panel12.Name = "panel12";
            panel12.Padding = new Padding(5);
            panel12.Size = new Size(274, 50);
            panel12.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Left;
            btnCancel.Location = new Point(5, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Dock = DockStyle.Right;
            btnConfirm.Location = new Point(149, 5);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(120, 40);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // ProductView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 598);
            Controls.Add(tableLayoutPanel1);
            Name = "ProductView";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel11.ResumeLayout(false);
            panel12.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel3;
        private Label lblDescription;
        private TextBox txtDescription;
        private Panel panel2;
        private Label lblName;
        private TextBox txtName;
        private Panel panel10;
        private Label lblPlacement;
        private TextBox txtPlacement;
        private Panel panel9;
        private Label lblCurrStock;
        private TextBox txtCurrStock;
        private Panel panel8;
        private Label lblMaxStock;
        private TextBox txtMaxStock;
        private Panel panel7;
        private Label lblMinStock;
        private TextBox txtMinStock;
        private Panel panel6;
        private Label lblPrice;
        private TextBox txtPrice;
        private Panel panel5;
        private Label lblSize;
        private TextBox txtSize;
        private Panel panel4;
        private Label lblWeight;
        private TextBox txtWeight;
        private Panel panel11;
        private Panel panel12;
        private Button btnCancel;
        private Button btnConfirm;
    }
}
