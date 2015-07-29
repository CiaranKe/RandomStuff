namespace Life
{
    partial class GameOfLife
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
            this.OurWorld = new System.Windows.Forms.PictureBox();
            this.Start = new System.Windows.Forms.Button();
            this.Suspend = new System.Windows.Forms.Button();
            this.Resume = new System.Windows.Forms.Button();
            this.Abort = new System.Windows.Forms.Button();
            this.GenerationCounter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.OurWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // OurWorld
            // 
            this.OurWorld.BackColor = System.Drawing.Color.Blue;
            this.OurWorld.Location = new System.Drawing.Point(12, 12);
            this.OurWorld.Name = "OurWorld";
            this.OurWorld.Size = new System.Drawing.Size(400, 400);
            this.OurWorld.TabIndex = 0;
            this.OurWorld.TabStop = false;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(418, 12);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Suspend
            // 
            this.Suspend.Location = new System.Drawing.Point(418, 41);
            this.Suspend.Name = "Suspend";
            this.Suspend.Size = new System.Drawing.Size(75, 23);
            this.Suspend.TabIndex = 2;
            this.Suspend.Text = "Suspend";
            this.Suspend.UseVisualStyleBackColor = true;
            this.Suspend.Click += new System.EventHandler(this.Suspend_Click);
            // 
            // Resume
            // 
            this.Resume.Location = new System.Drawing.Point(418, 70);
            this.Resume.Name = "Resume";
            this.Resume.Size = new System.Drawing.Size(75, 23);
            this.Resume.TabIndex = 3;
            this.Resume.Text = "Resume";
            this.Resume.UseVisualStyleBackColor = true;
            this.Resume.Click += new System.EventHandler(this.Resume_Click);
            // 
            // Abort
            // 
            this.Abort.Location = new System.Drawing.Point(418, 99);
            this.Abort.Name = "Abort";
            this.Abort.Size = new System.Drawing.Size(75, 23);
            this.Abort.TabIndex = 4;
            this.Abort.Text = "Abort";
            this.Abort.UseVisualStyleBackColor = true;
            this.Abort.Click += new System.EventHandler(this.Abort_Click);
            // 
            // GenerationCounter
            // 
            this.GenerationCounter.Location = new System.Drawing.Point(418, 128);
            this.GenerationCounter.Name = "GenerationCounter";
            this.GenerationCounter.Size = new System.Drawing.Size(75, 20);
            this.GenerationCounter.TabIndex = 5;
            // 
            // GameOfLife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 425);
            this.Controls.Add(this.GenerationCounter);
            this.Controls.Add(this.Abort);
            this.Controls.Add(this.Resume);
            this.Controls.Add(this.Suspend);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.OurWorld);
            this.Name = "GameOfLife";
            this.Text = "Game of life";
            this.Load += new System.EventHandler(this.GameOfLife_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OurWorld)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OurWorld;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Suspend;
        private System.Windows.Forms.Button Resume;
        private System.Windows.Forms.Button Abort;
        private System.Windows.Forms.TextBox GenerationCounter;
    }
}

