namespace Menu
{
    partial class Basket
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
            this.dgvBasket = new System.Windows.Forms.DataGridView();
            this.brnRemove = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBasket
            // 
            this.dgvBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasket.Location = new System.Drawing.Point(13, 13);
            this.dgvBasket.Name = "dgvBasket";
            this.dgvBasket.Size = new System.Drawing.Size(307, 150);
            this.dgvBasket.TabIndex = 0;
            // 
            // brnRemove
            // 
            this.brnRemove.Location = new System.Drawing.Point(13, 170);
            this.brnRemove.Name = "brnRemove";
            this.brnRemove.Size = new System.Drawing.Size(75, 23);
            this.brnRemove.TabIndex = 1;
            this.brnRemove.Text = "Remove";
            this.brnRemove.UseVisualStyleBackColor = true;
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(245, 170);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 23);
            this.btnPay.TabIndex = 2;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            // 
            // Basket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 199);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.brnRemove);
            this.Controls.Add(this.dgvBasket);
            this.Name = "Basket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Basket";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBasket;
        private System.Windows.Forms.Button brnRemove;
        private System.Windows.Forms.Button btnPay;
    }
}