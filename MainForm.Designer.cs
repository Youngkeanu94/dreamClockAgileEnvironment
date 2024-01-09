namespace dreamClock
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ClockIn = new System.Windows.Forms.Button();
            this.ClockOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(788, 505);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // ClockIn
            // 
            this.ClockIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClockIn.Location = new System.Drawing.Point(12, 555);
            this.ClockIn.Name = "ClockIn";
            this.ClockIn.Size = new System.Drawing.Size(102, 39);
            this.ClockIn.TabIndex = 1;
            this.ClockIn.Text = "Clock in";
            this.ClockIn.UseVisualStyleBackColor = true;
            this.ClockIn.Click += new System.EventHandler(this.ClockIn_Click);
            // 
            // ClockOut
            // 
            this.ClockOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClockOut.Location = new System.Drawing.Point(698, 555);
            this.ClockOut.Name = "ClockOut";
            this.ClockOut.Size = new System.Drawing.Size(102, 39);
            this.ClockOut.TabIndex = 2;
            this.ClockOut.Text = "Clock out";
            this.ClockOut.UseVisualStyleBackColor = true;
            this.ClockOut.Click += new System.EventHandler(this.ClockOut_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 706);
            this.Controls.Add(this.ClockOut);
            this.Controls.Add(this.ClockIn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ClockIn;
        private System.Windows.Forms.Button ClockOut;
    }
}