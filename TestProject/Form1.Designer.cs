namespace CascadeDesktop
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            propertyGrid1 = new PropertyGrid();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(propertyGrid1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(2, 3, 2, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1381, 878);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(2, 3);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1377, 872);
            panel1.TabIndex = 0;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // propertyGrid1
            // 
            propertyGrid1.Dock = DockStyle.Fill;
            propertyGrid1.HelpVisible = false;
            propertyGrid1.Location = new Point(1383, 3);
            propertyGrid1.Margin = new Padding(2, 3, 2, 3);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(1, 872);
            propertyGrid1.TabIndex = 1;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 20;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1381, 878);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "test project";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Timer timer1;
    }
}

