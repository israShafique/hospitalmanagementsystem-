namespace UserInterface.UI
{
    partial class staffDetail
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
            this.readings = new System.Windows.Forms.FlowLayoutPanel();
            this.moduleNames = new System.Windows.Forms.FlowLayoutPanel();
            this.patientNames = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // readings
            // 
            this.readings.AutoScroll = true;
            this.readings.AutoSize = true;
            this.readings.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.readings.Location = new System.Drawing.Point(550, 50);
            this.readings.Name = "readings";
            this.readings.Size = new System.Drawing.Size(168, 365);
            this.readings.TabIndex = 20;
            this.readings.Paint += new System.Windows.Forms.PaintEventHandler(this.readings_Paint);
            // 
            // moduleNames
            // 
            this.moduleNames.AutoScroll = true;
            this.moduleNames.AutoSize = true;
            this.moduleNames.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.moduleNames.Location = new System.Drawing.Point(357, 50);
            this.moduleNames.Name = "moduleNames";
            this.moduleNames.Size = new System.Drawing.Size(149, 365);
            this.moduleNames.TabIndex = 19;
            this.moduleNames.Paint += new System.Windows.Forms.PaintEventHandler(this.moduleNames_Paint);
            // 
            // patientNames
            // 
            this.patientNames.AutoScroll = true;
            this.patientNames.AutoSize = true;
            this.patientNames.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.patientNames.Location = new System.Drawing.Point(165, 50);
            this.patientNames.Name = "patientNames";
            this.patientNames.Size = new System.Drawing.Size(169, 365);
            this.patientNames.TabIndex = 18;
            this.patientNames.Paint += new System.Windows.Forms.PaintEventHandler(this.patientNames_Paint);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.Location = new System.Drawing.Point(1, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 28);
            this.button2.TabIndex = 17;
            this.button2.Text = "<--";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(546, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Staff Names";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(353, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "checked";
            // 
            // staffDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(760, 433);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.readings);
            this.Controls.Add(this.moduleNames);
            this.Controls.Add(this.patientNames);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "staffDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "staffDetail";
            this.Load += new System.EventHandler(this.staffDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel readings;
        private System.Windows.Forms.FlowLayoutPanel moduleNames;
        private System.Windows.Forms.FlowLayoutPanel patientNames;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}