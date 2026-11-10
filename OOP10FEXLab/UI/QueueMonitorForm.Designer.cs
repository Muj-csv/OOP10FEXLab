namespace OOP10FEXLab.UI
{
    partial class QueueMonitorForm
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
            this.screen = new System.Windows.Forms.TableLayoutPanel();
            this.servingCard = new OOP10FEXLab.UI.RoundedPanel();
            this.servingPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.servingTitle = new OOP10FEXLab.UI.RoundedPanel();
            this.lblServing = new System.Windows.Forms.Label();
            this.preparingCard = new OOP10FEXLab.UI.RoundedPanel();
            this.preparingPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.preparingTitle = new OOP10FEXLab.UI.RoundedPanel();
            this.lblPreparing = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblThanks = new System.Windows.Forms.Label();
            this.headerStripe = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.Panel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.screen.SuspendLayout();
            this.servingCard.SuspendLayout();
            this.servingTitle.SuspendLayout();
            this.preparingCard.SuspendLayout();
            this.preparingTitle.SuspendLayout();
            this.header.SuspendLayout();
            this.SuspendLayout();
            //
            // screen
            //
            this.screen.ColumnCount = 2;
            this.screen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.screen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.screen.Controls.Add(this.servingCard, 0, 0);
            this.screen.Controls.Add(this.preparingCard, 1, 0);
            this.screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screen.Location = new System.Drawing.Point(0, 108);
            this.screen.Name = "screen";
            this.screen.Padding = new System.Windows.Forms.Padding(14);
            this.screen.RowCount = 1;
            this.screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.screen.Size = new System.Drawing.Size(1184, 449);
            this.screen.TabIndex = 0;
            //
            // servingCard
            //
            this.servingCard.BackColor = System.Drawing.Color.White;
            this.servingCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(214)))), ((int)(((byte)(190)))));
            this.servingCard.Controls.Add(this.servingPanel);
            this.servingCard.Controls.Add(this.servingTitle);
            this.servingCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.servingCard.Location = new System.Drawing.Point(24, 24);
            this.servingCard.Margin = new System.Windows.Forms.Padding(10);
            this.servingCard.Name = "servingCard";
            this.servingCard.Padding = new System.Windows.Forms.Padding(8);
            this.servingCard.Radius = 18;
            this.servingCard.Size = new System.Drawing.Size(500, 401);
            this.servingCard.TabIndex = 0;
            //
            // servingPanel
            //
            this.servingPanel.AutoScroll = true;
            this.servingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.servingPanel.Location = new System.Drawing.Point(8, 72);
            this.servingPanel.Name = "servingPanel";
            this.servingPanel.Padding = new System.Windows.Forms.Padding(8);
            this.servingPanel.Size = new System.Drawing.Size(484, 321);
            this.servingPanel.TabIndex = 1;
            //
            // servingTitle
            //
            this.servingTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.servingTitle.Controls.Add(this.lblServing);
            this.servingTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.servingTitle.Location = new System.Drawing.Point(8, 8);
            this.servingTitle.Name = "servingTitle";
            this.servingTitle.Padding = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.servingTitle.Size = new System.Drawing.Size(484, 64);
            this.servingTitle.TabIndex = 0;
            //
            // lblServing
            //
            this.lblServing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServing.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServing.ForeColor = System.Drawing.Color.White;
            this.lblServing.Location = new System.Drawing.Point(14, 0);
            this.lblServing.Name = "lblServing";
            this.lblServing.Size = new System.Drawing.Size(456, 64);
            this.lblServing.TabIndex = 0;
            this.lblServing.Text = "NOW SERVING";
            this.lblServing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // preparingCard
            //
            this.preparingCard.BackColor = System.Drawing.Color.White;
            this.preparingCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(214)))), ((int)(((byte)(190)))));
            this.preparingCard.Controls.Add(this.preparingPanel);
            this.preparingCard.Controls.Add(this.preparingTitle);
            this.preparingCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preparingCard.Location = new System.Drawing.Point(544, 24);
            this.preparingCard.Margin = new System.Windows.Forms.Padding(10);
            this.preparingCard.Name = "preparingCard";
            this.preparingCard.Padding = new System.Windows.Forms.Padding(8);
            this.preparingCard.Radius = 18;
            this.preparingCard.Size = new System.Drawing.Size(616, 401);
            this.preparingCard.TabIndex = 1;
            //
            // preparingPanel
            //
            this.preparingPanel.AutoScroll = true;
            this.preparingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preparingPanel.Location = new System.Drawing.Point(8, 72);
            this.preparingPanel.Name = "preparingPanel";
            this.preparingPanel.Padding = new System.Windows.Forms.Padding(8);
            this.preparingPanel.Size = new System.Drawing.Size(600, 321);
            this.preparingPanel.TabIndex = 1;
            //
            // preparingTitle
            //
            this.preparingTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.preparingTitle.Controls.Add(this.lblPreparing);
            this.preparingTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.preparingTitle.Location = new System.Drawing.Point(8, 8);
            this.preparingTitle.Name = "preparingTitle";
            this.preparingTitle.Padding = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.preparingTitle.Size = new System.Drawing.Size(600, 64);
            this.preparingTitle.TabIndex = 0;
            //
            // lblPreparing
            //
            this.lblPreparing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPreparing.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreparing.ForeColor = System.Drawing.Color.White;
            this.lblPreparing.Location = new System.Drawing.Point(14, 0);
            this.lblPreparing.Name = "lblPreparing";
            this.lblPreparing.Size = new System.Drawing.Size(572, 64);
            this.lblPreparing.TabIndex = 0;
            this.lblPreparing.Text = "PREPARING";
            this.lblPreparing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHint
            //
            this.lblHint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(14)))), ((int)(((byte)(41)))));
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(179)))));
            this.lblHint.Location = new System.Drawing.Point(0, 557);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(1184, 28);
            this.lblHint.TabIndex = 1;
            this.lblHint.Text = "Crew: click a number to move it to the next step  (Preparing → Now Serving → Claimed)";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblThanks
            //
            this.lblThanks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.lblThanks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblThanks.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanks.ForeColor = System.Drawing.Color.White;
            this.lblThanks.Location = new System.Drawing.Point(0, 585);
            this.lblThanks.Name = "lblThanks";
            this.lblThanks.Size = new System.Drawing.Size(1184, 56);
            this.lblThanks.TabIndex = 2;
            this.lblThanks.Text = "Thank you for choosing AnDokiDoks!";
            this.lblThanks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblThanks.UseMnemonic = false;
            //
            // headerStripe
            //
            this.headerStripe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(37)))));
            this.headerStripe.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerStripe.Location = new System.Drawing.Point(0, 100);
            this.headerStripe.Name = "headerStripe";
            this.headerStripe.Size = new System.Drawing.Size(1184, 8);
            this.headerStripe.TabIndex = 3;
            //
            // header
            //
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(179)))));
            this.header.Controls.Add(this.lblBrand);
            this.header.Controls.Add(this.lblClock);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Padding = new System.Windows.Forms.Padding(24, 0, 24, 0);
            this.header.Size = new System.Drawing.Size(1184, 100);
            this.header.TabIndex = 4;
            //
            // lblBrand
            //
            this.lblBrand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI Black", 40F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.lblBrand.Location = new System.Drawing.Point(24, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(916, 100);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "AnDokiDoks";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBrand.UseMnemonic = false;
            //
            // lblClock
            //
            this.lblClock.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(46)))));
            this.lblClock.Location = new System.Drawing.Point(940, 0);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(220, 100);
            this.lblClock.TabIndex = 1;
            this.lblClock.Text = "12:00 PM";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // refreshTimer
            //
            this.refreshTimer.Interval = 2000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            //
            // QueueMonitorForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1184, 641);
            this.Controls.Add(this.screen);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lblThanks);
            this.Controls.Add(this.headerStripe);
            this.Controls.Add(this.header);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(35)))), ((int)(((byte)(30)))));
            this.Location = new System.Drawing.Point(20, 20);
            this.Name = "QueueMonitorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Queue Monitor - AnDokiDoks";
            this.Load += new System.EventHandler(this.QueueMonitorForm_Load);
            this.screen.ResumeLayout(false);
            this.servingCard.ResumeLayout(false);
            this.servingTitle.ResumeLayout(false);
            this.preparingCard.ResumeLayout(false);
            this.preparingTitle.ResumeLayout(false);
            this.header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel screen;
        private OOP10FEXLab.UI.RoundedPanel servingCard;
        private System.Windows.Forms.FlowLayoutPanel servingPanel;
        private OOP10FEXLab.UI.RoundedPanel servingTitle;
        private System.Windows.Forms.Label lblServing;
        private OOP10FEXLab.UI.RoundedPanel preparingCard;
        private System.Windows.Forms.FlowLayoutPanel preparingPanel;
        private OOP10FEXLab.UI.RoundedPanel preparingTitle;
        private System.Windows.Forms.Label lblPreparing;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label lblThanks;
        private System.Windows.Forms.Panel headerStripe;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Timer refreshTimer;
    }
}
