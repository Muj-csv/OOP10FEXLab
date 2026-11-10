namespace OOP10FEXLab.UI
{
    partial class CheckoutForm
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
            this.listOrder = new System.Windows.Forms.ListView();
            this.colMeal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubtotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTotal = new System.Windows.Forms.Label();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.titleStripe = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            //
            // listOrder
            //
            this.listOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMeal,
            this.colQty,
            this.colPrice,
            this.colSubtotal});
            this.listOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(35)))), ((int)(((byte)(30)))));
            this.listOrder.FullRowSelect = true;
            this.listOrder.HideSelection = false;
            this.listOrder.Location = new System.Drawing.Point(0, 57);
            this.listOrder.Name = "listOrder";
            this.listOrder.Size = new System.Drawing.Size(544, 312);
            this.listOrder.TabIndex = 0;
            this.listOrder.UseCompatibleStateImageBehavior = false;
            this.listOrder.View = System.Windows.Forms.View.Details;
            //
            // colMeal
            //
            this.colMeal.Text = "Meal";
            this.colMeal.Width = 260;
            //
            // colQty
            //
            this.colQty.Text = "Qty";
            this.colQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colQty.Width = 50;
            //
            // colPrice
            //
            this.colPrice.Text = "Price";
            this.colPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colPrice.Width = 90;
            //
            // colSubtotal
            //
            this.colSubtotal.Text = "Subtotal";
            this.colSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSubtotal.Width = 100;
            //
            // lblTotal
            //
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(235)))));
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.lblTotal.Location = new System.Drawing.Point(0, 369);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblTotal.Size = new System.Drawing.Size(544, 48);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "TOTAL:  ₱0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // buttonsPanel
            //
            this.buttonsPanel.Controls.Add(this.btnBack);
            this.buttonsPanel.Controls.Add(this.btnPlaceOrder);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 417);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Padding = new System.Windows.Forms.Padding(16, 8, 16, 12);
            this.buttonsPanel.Size = new System.Drawing.Size(544, 64);
            this.buttonsPanel.TabIndex = 2;
            //
            // btnBack
            //
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.btnBack.FlatAppearance.BorderSize = 2;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.btnBack.Location = new System.Drawing.Point(16, 8);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(160, 44);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "BACK";
            this.btnBack.UseMnemonic = false;
            this.btnBack.UseVisualStyleBackColor = false;
            //
            // btnPlaceOrder
            //
            this.btnPlaceOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.btnPlaceOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlaceOrder.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPlaceOrder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPlaceOrder.FlatAppearance.BorderSize = 0;
            this.btnPlaceOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(12)))), ((int)(((byte)(36)))));
            this.btnPlaceOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(14)))), ((int)(((byte)(41)))));
            this.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaceOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaceOrder.ForeColor = System.Drawing.Color.White;
            this.btnPlaceOrder.Location = new System.Drawing.Point(308, 8);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(220, 44);
            this.btnPlaceOrder.TabIndex = 1;
            this.btnPlaceOrder.Text = "PLACE ORDER  ›";
            this.btnPlaceOrder.UseMnemonic = false;
            this.btnPlaceOrder.UseVisualStyleBackColor = false;
            //
            // titleStripe
            //
            this.titleStripe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(37)))));
            this.titleStripe.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleStripe.Location = new System.Drawing.Point(0, 52);
            this.titleStripe.Name = "titleStripe";
            this.titleStripe.Size = new System.Drawing.Size(544, 5);
            this.titleStripe.TabIndex = 3;
            //
            // lblTitle
            //
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(544, 52);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "REVIEW YOUR ORDER";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // CheckoutForm
            //
            this.AcceptButton = this.btnPlaceOrder;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnBack;
            this.ClientSize = new System.Drawing.Size(544, 481);
            this.Controls.Add(this.listOrder);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.titleStripe);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckoutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Review Your Order";
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listOrder;
        private System.Windows.Forms.ColumnHeader colMeal;
        private System.Windows.Forms.ColumnHeader colQty;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.ColumnHeader colSubtotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Panel titleStripe;
        private System.Windows.Forms.Label lblTitle;
    }
}
