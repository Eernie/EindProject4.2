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
            this.productList = new System.Windows.Forms.ListBox();
            this.priceList = new System.Windows.Forms.ListBox();
            this.importNotification = new Microsoft.WindowsCE.Forms.Notification();
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
            this.totaalPrijs.Location = new System.Drawing.Point(186, 265);
            this.totaalPrijs.Name = "totaalPrijs";
            this.totaalPrijs.Size = new System.Drawing.Size(48, 25);
            this.totaalPrijs.Text = "€0,00";
            // 
            // totaalText
            // 
            this.totaalText.Location = new System.Drawing.Point(134, 265);
            this.totaalText.Name = "totaalText";
            this.totaalText.Size = new System.Drawing.Size(46, 20);
            this.totaalText.Text = "Totaal:";
            // 
            // productList
            // 
            this.productList.Location = new System.Drawing.Point(0, 0);
            this.productList.Name = "productList";
            this.productList.Size = new System.Drawing.Size(180, 240);
            this.productList.TabIndex = 8;
            // 
            // priceList
            // 
            this.priceList.Location = new System.Drawing.Point(180, 0);
            this.priceList.Name = "priceList";
            this.priceList.Size = new System.Drawing.Size(60, 240);
            this.priceList.TabIndex = 11;
            // 
            // importNotification
            // 
            this.importNotification.Caption = "Importeer boodschappenlijst";
            this.importNotification.Text = "";
            this.importNotification.ResponseSubmitted += new Microsoft.WindowsCE.Forms.ResponseSubmittedEventHandler(this.importNotification_ResponseSubmitted);
            // 
            // ShoppingCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.priceList);
            this.Controls.Add(this.productList);
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
        private System.Windows.Forms.ListBox productList;
        private System.Windows.Forms.MenuItem import;
        private System.Windows.Forms.MenuItem clear;
        private System.Windows.Forms.ListBox priceList;
        private Microsoft.WindowsCE.Forms.Notification importNotification;

    }
}

