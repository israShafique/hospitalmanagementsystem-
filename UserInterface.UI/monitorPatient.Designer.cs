namespace UserInterface.UI
{
    partial class monitorPatient
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
            this.button2 = new System.Windows.Forms.Button();
            this.patientNames = new System.Windows.Forms.FlowLayoutPanel();
            this.moduleNames = new System.Windows.Forms.FlowLayoutPanel();
            this.readings = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.Location = new System.Drawing.Point(28, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 33);
            this.button2.TabIndex = 13;
            this.button2.Text = "<--";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // patientNames
            // 
            this.patientNames.AutoScroll = true;
            this.patientNames.AutoSize = true;
            this.patientNames.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.patientNames.Location = new System.Drawing.Point(136, 12);
            this.patientNames.Name = "patientNames";
            this.patientNames.Size = new System.Drawing.Size(140, 397);
            this.patientNames.TabIndex = 14;
            // 
            // moduleNames
            // 
            this.moduleNames.AutoScroll = true;
            this.moduleNames.AutoSize = true;
            this.moduleNames.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.moduleNames.Location = new System.Drawing.Point(282, 12);
            this.moduleNames.Name = "moduleNames";
            this.moduleNames.Size = new System.Drawing.Size(211, 397);
            this.moduleNames.TabIndex = 15;
            // 
            // readings
            // 
            this.readings.AutoScroll = true;
            this.readings.AutoSize = true;
            this.readings.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.readings.Location = new System.Drawing.Point(499, 12);
            this.readings.Name = "readings";
            this.readings.Size = new System.Drawing.Size(176, 397);
            this.readings.TabIndex = 16;
            // 
            // monitorPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(760, 433);
            this.Controls.Add(this.readings);
            this.Controls.Add(this.moduleNames);
            this.Controls.Add(this.patientNames);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "monitorPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "monitorPatient";
            this.Load += new System.EventHandler(this.monitorPatient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel patientNames;
        private System.Windows.Forms.FlowLayoutPanel moduleNames;
        private System.Windows.Forms.FlowLayoutPanel readings;
    }
}