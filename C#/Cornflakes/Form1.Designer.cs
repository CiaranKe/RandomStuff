namespace Cornflakes
{
    partial class DemoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TheNumber = new System.Windows.Forms.TextBox();
            this.TheName = new System.Windows.Forms.TextBox();
            this.TheSalary = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Serialised = new System.Windows.Forms.TextBox();
            this.Serialise = new System.Windows.Forms.Button();
            this.Deserialise = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.TheValueLabel = new System.Windows.Forms.Label();
            this.TheValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Salary:";
            // 
            // TheNumber
            // 
            this.TheNumber.Location = new System.Drawing.Point(81, 26);
            this.TheNumber.Name = "TheNumber";
            this.TheNumber.Size = new System.Drawing.Size(43, 20);
            this.TheNumber.TabIndex = 3;
            // 
            // TheName
            // 
            this.TheName.Location = new System.Drawing.Point(81, 53);
            this.TheName.Name = "TheName";
            this.TheName.Size = new System.Drawing.Size(165, 20);
            this.TheName.TabIndex = 4;
            // 
            // TheSalary
            // 
            this.TheSalary.Location = new System.Drawing.Point(81, 82);
            this.TheSalary.Name = "TheSalary";
            this.TheSalary.Size = new System.Drawing.Size(72, 20);
            this.TheSalary.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Serialised:";
            // 
            // Serialised
            // 
            this.Serialised.Location = new System.Drawing.Point(31, 166);
            this.Serialised.Multiline = true;
            this.Serialised.Name = "Serialised";
            this.Serialised.Size = new System.Drawing.Size(320, 313);
            this.Serialised.TabIndex = 7;
            // 
            // Serialise
            // 
            this.Serialise.Location = new System.Drawing.Point(276, 24);
            this.Serialise.Name = "Serialise";
            this.Serialise.Size = new System.Drawing.Size(75, 23);
            this.Serialise.TabIndex = 8;
            this.Serialise.Text = "Serialise";
            this.Serialise.UseVisualStyleBackColor = true;
            this.Serialise.Click += new System.EventHandler(this.Serialise_Click);
            // 
            // Deserialise
            // 
            this.Deserialise.Location = new System.Drawing.Point(276, 53);
            this.Deserialise.Name = "Deserialise";
            this.Deserialise.Size = new System.Drawing.Size(75, 23);
            this.Deserialise.TabIndex = 9;
            this.Deserialise.Text = "Deserialise";
            this.Deserialise.UseVisualStyleBackColor = true;
            this.Deserialise.Click += new System.EventHandler(this.Deserialise_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(276, 95);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 10;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // TheValueLabel
            // 
            this.TheValueLabel.AutoSize = true;
            this.TheValueLabel.Location = new System.Drawing.Point(6, 116);
            this.TheValueLabel.Name = "TheValueLabel";
            this.TheValueLabel.Size = new System.Drawing.Size(61, 13);
            this.TheValueLabel.TabIndex = 11;
            this.TheValueLabel.Text = "SomeValue";
            // 
            // TheValue
            // 
            this.TheValue.Location = new System.Drawing.Point(81, 109);
            this.TheValue.Name = "TheValue";
            this.TheValue.Size = new System.Drawing.Size(72, 20);
            this.TheValue.TabIndex = 6;
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 491);
            this.Controls.Add(this.TheValue);
            this.Controls.Add(this.TheValueLabel);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Deserialise);
            this.Controls.Add(this.Serialise);
            this.Controls.Add(this.Serialised);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TheSalary);
            this.Controls.Add(this.TheName);
            this.Controls.Add(this.TheNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DemoForm";
            this.Text = "Serialisation and Deserialisation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TheNumber;
        private System.Windows.Forms.TextBox TheName;
        private System.Windows.Forms.TextBox TheSalary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Serialised;
        private System.Windows.Forms.Button Serialise;
        private System.Windows.Forms.Button Deserialise;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label TheValueLabel;
        private System.Windows.Forms.TextBox TheValue;
    }
}

