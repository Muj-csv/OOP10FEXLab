namespace OOP10FEXLab.UI
{
    partial class KioskForm
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
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.welcomeLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblWelcomeStore = new System.Windows.Forms.Label();
            this.lblHello = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.choicesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDineIn = new System.Windows.Forms.Button();
            this.btnTakeOut = new System.Windows.Forms.Button();
            this.mealPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.orderBox = new System.Windows.Forms.Panel();
            this.orderPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMyOrder = new System.Windows.Forms.Label();
            this.categoryPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.footerStripe = new System.Windows.Forms.Panel();
            this.footer = new System.Windows.Forms.Panel();
            this.totalLabel = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.payButton = new System.Windows.Forms.Button();
            this.headerStripe = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.Panel();
            this.diningLabel = new System.Windows.Forms.Label();
            this.lblStore = new System.Windows.Forms.Label();
            this.welcomePanel.SuspendLayout();
            this.welcomeLayout.SuspendLayout();
            this.choicesPanel.SuspendLayout();
            this.orderBox.SuspendLayout();
            this.footer.SuspendLayout();
            this.header.SuspendLayout();
            this.SuspendLayout();
            //
            // welcomePanel
            //
            this.welcomePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.welcomePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.welcomePanel.Controls.Add(this.welcomeLayout);
            this.welcomePanel.Location = new System.Drawing.Point(0, 0);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(1264, 761);
            this.welcomePanel.TabIndex = 0;
            //
            // welcomeLayout
            //
            this.welcomeLayout.ColumnCount = 1;
            this.welcomeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.welcomeLayout.Controls.Add(this.lblWelcomeStore, 0, 0);
            this.welcomeLayout.Controls.Add(this.lblHello, 0, 1);
            this.welcomeLayout.Controls.Add(this.lblPrompt, 0, 2);
            this.welcomeLayout.Controls.Add(this.choicesPanel, 0, 3);
            this.welcomeLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomeLayout.Location = new System.Drawing.Point(0, 0);
            this.welcomeLayout.Name = "welcomeLayout";
            this.welcomeLayout.RowCount = 4;
            this.welcomeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.welcomeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.welcomeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.welcomeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.welcomeLayout.Size = new System.Drawing.Size(1264, 761);
            this.welcomeLayout.TabIndex = 0;
            //
            // lblWelcomeStore
            //
            this.lblWelcomeStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcomeStore.Font = new System.Drawing.Font("Segoe UI Black", 60F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(37)))));
            this.lblWelcomeStore.Location = new System.Drawing.Point(3, 0);
            this.lblWelcomeStore.Name = "lblWelcomeStore";
            this.lblWelcomeStore.Size = new System.Drawing.Size(1258, 256);
            this.lblWelcomeStore.TabIndex = 0;
            this.lblWelcomeStore.Text = "AnDokiDoks";
            this.lblWelcomeStore.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblWelcomeStore.UseMnemonic = false;
            //
            // lblHello
            //
            this.lblHello.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHello.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHello.ForeColor = System.Drawing.Color.White;
            this.lblHello.Location = new System.Drawing.Point(3, 256);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(1258, 60);
            this.lblHello.TabIndex = 1;
            this.lblHello.Text = "Hello! What would you like to order?";
            this.lblHello.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblPrompt
            //
            this.lblPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrompt.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(179)))));
            this.lblPrompt.Location = new System.Drawing.Point(3, 316);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(1258, 60);
            this.lblPrompt.TabIndex = 2;
            this.lblPrompt.Text = "Where will you be eating today?";
            this.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // choicesPanel
            //
            this.choicesPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.choicesPanel.AutoSize = true;
            this.choicesPanel.Controls.Add(this.btnDineIn);
            this.choicesPanel.Controls.Add(this.btnTakeOut);
            this.choicesPanel.Location = new System.Drawing.Point(312, 396);
            this.choicesPanel.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.choicesPanel.Name = "choicesPanel";
            this.choicesPanel.Size = new System.Drawing.Size(640, 130);
            this.choicesPanel.TabIndex = 3;
            this.choicesPanel.WrapContents = false;
            //
            // btnDineIn
            //
            this.btnDineIn.BackColor = System.Drawing.Color.White;
            this.btnDineIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDineIn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDineIn.FlatAppearance.BorderSize = 2;
            this.btnDineIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.btnDineIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.btnDineIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDineIn.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDineIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.btnDineIn.Location = new System.Drawing.Point(20, 0);
            this.btnDineIn.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnDineIn.Name = "btnDineIn";
            this.btnDineIn.Size = new System.Drawing.Size(280, 130);
            this.btnDineIn.TabIndex = 0;
            this.btnDineIn.Text = "DINE IN";
            this.btnDineIn.UseMnemonic = false;
            this.btnDineIn.UseVisualStyleBackColor = false;
            this.btnDineIn.Click += new System.EventHandler(this.btnDineIn_Click);
            //
            // btnTakeOut
            //
            this.btnTakeOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(37)))));
            this.btnTakeOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTakeOut.FlatAppearance.BorderSize = 0;
            this.btnTakeOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(158)))), ((int)(((byte)(29)))));
            this.btnTakeOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(176)))), ((int)(((byte)(33)))));
            this.btnTakeOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeOut.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakeOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.btnTakeOut.Location = new System.Drawing.Point(340, 0);
            this.btnTakeOut.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnTakeOut.Name = "btnTakeOut";
            this.btnTakeOut.Size = new System.Drawing.Size(280, 130);
            this.btnTakeOut.TabIndex = 1;
            this.btnTakeOut.Text = "TAKE OUT";
            this.btnTakeOut.UseMnemonic = false;
            this.btnTakeOut.UseVisualStyleBackColor = false;
            this.btnTakeOut.Click += new System.EventHandler(this.btnTakeOut_Click);
            //
            // mealPanel
            //
            this.mealPanel.AutoScroll = true;
            this.mealPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(235)))));
            this.mealPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mealPanel.Location = new System.Drawing.Point(190, 82);
            this.mealPanel.Name = "mealPanel";
            this.mealPanel.Padding = new System.Windows.Forms.Padding(12);
            this.mealPanel.Size = new System.Drawing.Size(744, 597);
            this.mealPanel.TabIndex = 1;
            //
            // orderBox
            //
            this.orderBox.BackColor = System.Drawing.Color.White;
            this.orderBox.Controls.Add(this.orderPanel);
            this.orderBox.Controls.Add(this.lblMyOrder);
            this.orderBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.orderBox.Location = new System.Drawing.Point(934, 82);
            this.orderBox.Name = "orderBox";
            this.orderBox.Padding = new System.Windows.Forms.Padding(14);
            this.orderBox.Size = new System.Drawing.Size(330, 597);
            this.orderBox.TabIndex = 2;
            //
            // orderPanel
            //
            this.orderPanel.AutoScroll = true;
            this.orderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.orderPanel.Location = new System.Drawing.Point(14, 54);
            this.orderPanel.Name = "orderPanel";
            this.orderPanel.Size = new System.Drawing.Size(302, 529);
            this.orderPanel.TabIndex = 1;
            this.orderPanel.WrapContents = false;
            //
            // lblMyOrder
            //
            this.lblMyOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMyOrder.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.lblMyOrder.Location = new System.Drawing.Point(14, 14);
            this.lblMyOrder.Name = "lblMyOrder";
            this.lblMyOrder.Size = new System.Drawing.Size(302, 40);
            this.lblMyOrder.TabIndex = 0;
            this.lblMyOrder.Text = "MY ORDER";
            //
            // categoryPanel
            //
            this.categoryPanel.BackColor = System.Drawing.Color.White;
            this.categoryPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.categoryPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.categoryPanel.Location = new System.Drawing.Point(0, 82);
            this.categoryPanel.Name = "categoryPanel";
            this.categoryPanel.Padding = new System.Windows.Forms.Padding(12);
            this.categoryPanel.Size = new System.Drawing.Size(190, 597);
            this.categoryPanel.TabIndex = 3;
            this.categoryPanel.WrapContents = false;
            //
            // footerStripe
            //
            this.footerStripe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(37)))));
            this.footerStripe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerStripe.Location = new System.Drawing.Point(0, 679);
            this.footerStripe.Name = "footerStripe";
            this.footerStripe.Size = new System.Drawing.Size(1264, 4);
            this.footerStripe.TabIndex = 4;
            //
            // footer
            //
            this.footer.BackColor = System.Drawing.Color.White;
            this.footer.Controls.Add(this.totalLabel);
            this.footer.Controls.Add(this.btnCancel);
            this.footer.Controls.Add(this.payButton);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 683);
            this.footer.Name = "footer";
            this.footer.Padding = new System.Windows.Forms.Padding(14, 12, 14, 12);
            this.footer.Size = new System.Drawing.Size(1264, 78);
            this.footer.TabIndex = 5;
            //
            // totalLabel
            //
            this.totalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalLabel.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(35)))), ((int)(((byte)(30)))));
            this.totalLabel.Location = new System.Drawing.Point(204, 12);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Padding = new System.Windows.Forms.Padding(0, 0, 22, 0);
            this.totalLabel.Size = new System.Drawing.Size(786, 54);
            this.totalLabel.TabIndex = 1;
            this.totalLabel.Text = "Order Total:  ₱0.00";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.btnCancel.Location = new System.Drawing.Point(14, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(190, 54);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "CANCEL ORDER";
            this.btnCancel.UseMnemonic = false;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // payButton
            //
            this.payButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.payButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.payButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.payButton.FlatAppearance.BorderSize = 0;
            this.payButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(12)))), ((int)(((byte)(36)))));
            this.payButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(14)))), ((int)(((byte)(41)))));
            this.payButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.payButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payButton.ForeColor = System.Drawing.Color.White;
            this.payButton.Location = new System.Drawing.Point(990, 12);
            this.payButton.Name = "payButton";
            this.payButton.Size = new System.Drawing.Size(260, 54);
            this.payButton.TabIndex = 2;
            this.payButton.Text = "REVIEW & PAY  ›";
            this.payButton.UseMnemonic = false;
            this.payButton.UseVisualStyleBackColor = false;
            this.payButton.Click += new System.EventHandler(this.payButton_Click);
            //
            // headerStripe
            //
            this.headerStripe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(37)))));
            this.headerStripe.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerStripe.Location = new System.Drawing.Point(0, 76);
            this.headerStripe.Name = "headerStripe";
            this.headerStripe.Size = new System.Drawing.Size(1264, 6);
            this.headerStripe.TabIndex = 6;
            //
            // header
            //
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.header.Controls.Add(this.diningLabel);
            this.header.Controls.Add(this.lblStore);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1264, 76);
            this.header.TabIndex = 7;
            //
            // diningLabel
            //
            this.diningLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.diningLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diningLabel.ForeColor = System.Drawing.Color.White;
            this.diningLabel.Location = new System.Drawing.Point(1044, 0);
            this.diningLabel.Name = "diningLabel";
            this.diningLabel.Size = new System.Drawing.Size(220, 76);
            this.diningLabel.TabIndex = 1;
            this.diningLabel.Text = "DINE IN";
            this.diningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblStore
            //
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Segoe UI Black", 26F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(37)))));
            this.lblStore.Location = new System.Drawing.Point(22, 12);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(230, 47);
            this.lblStore.TabIndex = 0;
            this.lblStore.Text = "AnDokiDoks";
            this.lblStore.UseMnemonic = false;
            //
            // KioskForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.welcomePanel);
            this.Controls.Add(this.mealPanel);
            this.Controls.Add(this.orderBox);
            this.Controls.Add(this.categoryPanel);
            this.Controls.Add(this.footerStripe);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.headerStripe);
            this.Controls.Add(this.header);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(35)))), ((int)(((byte)(30)))));
            this.Name = "KioskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiosk - AnDokiDoks";
            this.Load += new System.EventHandler(this.KioskForm_Load);
            this.welcomePanel.ResumeLayout(false);
            this.welcomeLayout.ResumeLayout(false);
            this.welcomeLayout.PerformLayout();
            this.choicesPanel.ResumeLayout(false);
            this.orderBox.ResumeLayout(false);
            this.footer.ResumeLayout(false);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel welcomePanel;
        private System.Windows.Forms.TableLayoutPanel welcomeLayout;
        private System.Windows.Forms.Label lblWelcomeStore;
        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.FlowLayoutPanel choicesPanel;
        private System.Windows.Forms.Button btnDineIn;
        private System.Windows.Forms.Button btnTakeOut;
        private System.Windows.Forms.FlowLayoutPanel mealPanel;
        private System.Windows.Forms.Panel orderBox;
        private System.Windows.Forms.FlowLayoutPanel orderPanel;
        private System.Windows.Forms.Label lblMyOrder;
        private System.Windows.Forms.FlowLayoutPanel categoryPanel;
        private System.Windows.Forms.Panel footerStripe;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button payButton;
        private System.Windows.Forms.Panel headerStripe;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label diningLabel;
        private System.Windows.Forms.Label lblStore;
    }
}
