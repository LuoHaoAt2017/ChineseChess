using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp
{
    // partial 关键字用于拆分一个类、一个结构、一个接口或一个方法的定义到两个或更多的文件中。
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private IContainer components = null;
        private Button primaryBtn;
        private Button defaultBtn;
        private int width = 400;
        private int height = 400;

        private void onClick(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }

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
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        #endregion
    }
}