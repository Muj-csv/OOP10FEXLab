namespace OOP10FEXLab.UI
{
    partial class ReceiptForm
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
            this.txtSlip = new System.Windows.Forms.TextBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.stripe = new System.Windows.Forms.Panel();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // txtSlip
            //
            this.txtSlip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(235)))));
            this.txtSlip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSlip.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(35)))), ((int)(((byte)(30)))));
            this.txtSlip.Location = new System.Drawing.Point(0, 174);
            this.txtSlip.Multiline = true;
            this.txtSlip.Name = "txtSlip";
            this.txtSlip.ReadOnly = true;
            this.txtSlip.Size = new System.Drawing.Size(444, 335);
            this.txtSlip.TabIndex = 0;
            this.txtSlip.TabStop = false;
            //
            // btnDone
            //
            this.btnDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.btnDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDone.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDone.FlatAppearance.BorderSize = 0;
            this.btnDone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(12)))), ((int)(((byte)(36)))));
            this.btnDone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(14)))), ((int)(((byte)(41)))));
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(0, 509);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(444, 52);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "DONE";
            this.btnDone.UseMnemonic = false;
            this.btnDone.UseVisualStyleBackColor = false;
            //
            // stripe
            //
            this.stripe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(37)))));
            this.stripe.Dock = System.Windows.Forms.DockStyle.Top;
            this.stripe.Location = new System.Drawing.Point(0, 168);
            this.stripe.Name = "stripe";
            this.stripe.Size = new System.Drawing.Size(444, 6);
            this.stripe.TabIndex = 2;
            //
            // lblNumber
            //
            this.lblNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.lblNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNumber.Font = new System.Drawing.Font("Segoe UI", 58F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(37)))));
            this.lblNumber.Location = new System.Drawing.Point(0, 48);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(444, 120);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "1001";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblCaption
            //
            this.lblCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.Color.White;
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(444, 48);
            this.lblCaption.TabIndex = 4;
            this.lblCaption.Text = "YOUR ORDER NUMBER";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            //
            // ReceiptForm
            //
            this.AcceptButton = this.btnDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(444, 561);
            this.Controls.Add(this.txtSlip);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.stripe);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblCaption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thank You!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSlip;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Panel stripe;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblCaption;
    }
}
