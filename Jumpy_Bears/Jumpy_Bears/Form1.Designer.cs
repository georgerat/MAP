﻿namespace Jumpy_Bears
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.platform1 = new System.Windows.Forms.PictureBox();
            this.platform2 = new System.Windows.Forms.PictureBox();
            this.platform3 = new System.Windows.Forms.PictureBox();
            this.platform4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Crimson;
            this.pictureBox1.Location = new System.Drawing.Point(256, 631);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // platform1
            // 
            this.platform1.BackColor = System.Drawing.Color.SaddleBrown;
            this.platform1.Location = new System.Drawing.Point(206, 711);
            this.platform1.Name = "platform1";
            this.platform1.Size = new System.Drawing.Size(180, 30);
            this.platform1.TabIndex = 1;
            this.platform1.TabStop = false;
            this.platform1.Tag = "platform";
            // 
            // platform2
            // 
            this.platform2.BackColor = System.Drawing.Color.SaddleBrown;
            this.platform2.Location = new System.Drawing.Point(503, 511);
            this.platform2.Name = "platform2";
            this.platform2.Size = new System.Drawing.Size(180, 30);
            this.platform2.TabIndex = 2;
            this.platform2.TabStop = false;
            this.platform2.Tag = "platform";
            // 
            // platform3
            // 
            this.platform3.BackColor = System.Drawing.Color.SaddleBrown;
            this.platform3.Location = new System.Drawing.Point(-1, 311);
            this.platform3.Name = "platform3";
            this.platform3.Size = new System.Drawing.Size(180, 30);
            this.platform3.TabIndex = 3;
            this.platform3.TabStop = false;
            this.platform3.Tag = "platform";
            // 
            // platform4
            // 
            this.platform4.BackColor = System.Drawing.Color.SaddleBrown;
            this.platform4.Location = new System.Drawing.Point(503, 111);
            this.platform4.Name = "platform4";
            this.platform4.Size = new System.Drawing.Size(180, 30);
            this.platform4.TabIndex = 4;
            this.platform4.TabStop = false;
            this.platform4.Tag = "platform";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 753);
            this.Controls.Add(this.platform4);
            this.Controls.Add(this.platform3);
            this.Controls.Add(this.platform2);
            this.Controls.Add(this.platform1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Jumpy Bears";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox platform1;
        private System.Windows.Forms.PictureBox platform2;
        private System.Windows.Forms.PictureBox platform3;
        private System.Windows.Forms.PictureBox platform4;
    }
}

