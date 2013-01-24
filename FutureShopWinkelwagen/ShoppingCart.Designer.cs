namespace FutureShopWinkelwagen
{
    partial class ShoppingCart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.import = new System.Windows.Forms.MenuItem();
            this.clear = new System.Windows.Forms.MenuItem();
            this.totaalPrijs = new System.Windows.Forms.Label();
            this.totaalText = new System.Windows.Forms.Label();
            this.importNotification = new Microsoft.WindowsCE.Forms.Notification();
            this.productListView = new System.Windows.Forms.ListView();
            this.productName = new System.Windows.Forms.ColumnHeader();
            this.amount = new System.Windows.Forms.ColumnHeader();
            this.productPrice = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.import);
            this.mainMenu1.MenuItems.Add(this.clear);
            // 
            // import
            // 
            this.import.Text = "Import";
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // clear
            // 
            this.clear.Text = "Clear";
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // totaalPrijs
            // 
            this.totaalPrijs.Location = new System.Drawing.Point(171, 260);
            this.totaalPrijs.Name = "totaalPrijs";
            this.totaalPrijs.Size = new System.Drawing.Size(48, 25);
            this.totaalPrijs.Text = "€0,00";
            // 
            // totaalText
            // 
            this.totaalText.Location = new System.Drawing.Point(119, 260);
            this.totaalText.Name = "totaalText";
            this.totaalText.Size = new System.Drawing.Size(46, 20);
            this.totaalText.Text = "Totaal:";
            // 
            // importNotification
            // 
            this.importNotification.Caption = "Importeer boodschappenlijst";
            this.importNotification.Text = "";
            this.importNotification.ResponseSubmitted += new Microsoft.WindowsCE.Forms.ResponseSubmittedEventHandler(this.importNotification_ResponseSubmitted);
            // 
            // productListView
            // 
            this.productListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.productListView.Columns.Add(this.productName);
            this.productListView.Columns.Add(this.amount);
            this.productListView.Columns.Add(this.productPrice);
            this.productListView.FullRowSelect = true;
            this.productListView.Location = new System.Drawing.Point(0, 0);
            this.productListView.Name = "productListView";
            this.productListView.Size = new System.Drawing.Size(240, 249);
            this.productListView.TabIndex = 14;
            this.productListView.View = System.Windows.Forms.View.Details;
            // 
            // productName
            // 
            this.productName.Text = "Product";
            this.productName.Width = 130;
            // 
            // amount
            // 
            this.amount.Text = "Aantal";
            this.amount.Width = 40;
            // 
            // productPrice
            // 
            this.productPrice.Text = "Prijs";
            this.productPrice.Width = 67;
            // 
            // ShoppingCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.productListView);
            this.Controls.Add(this.totaalText);
            this.Controls.Add(this.totaalPrijs);
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.Name = "ShoppingCart";
            this.Text = "ShopOfTheFuture";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label totaalPrijs;
        private System.Windows.Forms.Label totaalText;
        private System.Windows.Forms.MenuItem import;
        private System.Windows.Forms.MenuItem clear;
        private Microsoft.WindowsCE.Forms.Notification importNotification;
        private System.Windows.Forms.ListView productListView;
        private System.Windows.Forms.ColumnHeader productName;
        private System.Windows.Forms.ColumnHeader productPrice;
        private System.Windows.Forms.ColumnHeader amount;

    }
}

