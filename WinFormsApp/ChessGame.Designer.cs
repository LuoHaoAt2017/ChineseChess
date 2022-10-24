using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp
{
    // partial 关键字用于拆分一个类、一个结构、一个接口或一个方法的定义到两个或更多的文件中。
    partial class ChessGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(this.ClientW, this.ClientH);
            this.Name = "ChessBoard";
            this.Text = "ChessBoard";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}