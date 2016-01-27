namespace Formatter
{
    partial class SqlFormatter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlFormatter));
            this.txtUnformatted = new System.Windows.Forms.TextBox();
            this.btnFormat = new System.Windows.Forms.Button();
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.cmdQueryType = new System.Windows.Forms.ComboBox();
            this.lblQueryType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUnformatted
            // 
            this.txtUnformatted.BackColor = System.Drawing.SystemColors.WindowText;
            this.txtUnformatted.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnformatted.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.txtUnformatted.Location = new System.Drawing.Point(0, 29);
            this.txtUnformatted.Multiline = true;
            this.txtUnformatted.Name = "txtUnformatted";
            this.txtUnformatted.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUnformatted.Size = new System.Drawing.Size(881, 205);
            this.txtUnformatted.TabIndex = 0;
            // 
            // btnFormat
            // 
            this.btnFormat.BackColor = System.Drawing.Color.SlateGray;
            this.btnFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormat.ForeColor = System.Drawing.Color.Yellow;
            this.btnFormat.Location = new System.Drawing.Point(324, 266);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(98, 37);
            this.btnFormat.TabIndex = 1;
            this.btnFormat.Text = "Format";
            this.btnFormat.UseVisualStyleBackColor = false;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // txtFormat
            // 
            this.txtFormat.BackColor = System.Drawing.SystemColors.WindowText;
            this.txtFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormat.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.txtFormat.Location = new System.Drawing.Point(0, 324);
            this.txtFormat.Multiline = true;
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFormat.Size = new System.Drawing.Size(881, 289);
            this.txtFormat.TabIndex = 2;
            // 
            // cmdQueryType
            // 
            this.cmdQueryType.BackColor = System.Drawing.Color.Silver;
            this.cmdQueryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdQueryType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmdQueryType.FormattingEnabled = true;
            this.cmdQueryType.Items.AddRange(new object[] {
            "SELECT",
            "INSERT",
            "UPDATE",
            "DELETE"});
            this.cmdQueryType.Location = new System.Drawing.Point(168, 273);
            this.cmdQueryType.Name = "cmdQueryType";
            this.cmdQueryType.Size = new System.Drawing.Size(134, 24);
            this.cmdQueryType.TabIndex = 3;
            this.cmdQueryType.Text = "SELECT";
            // 
            // lblQueryType
            // 
            this.lblQueryType.AutoSize = true;
            this.lblQueryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueryType.Location = new System.Drawing.Point(9, 273);
            this.lblQueryType.Name = "lblQueryType";
            this.lblQueryType.Size = new System.Drawing.Size(153, 17);
            this.lblQueryType.TabIndex = 4;
            this.lblQueryType.Text = "Select Query Type :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(890, 627);
            this.Controls.Add(this.lblQueryType);
            this.Controls.Add(this.cmdQueryType);
            this.Controls.Add(this.txtFormat);
            this.Controls.Add(this.btnFormat);
            this.Controls.Add(this.txtUnformatted);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Sql Formatter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUnformatted;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.TextBox txtFormat;
        private System.Windows.Forms.ComboBox cmdQueryType;
        private System.Windows.Forms.Label lblQueryType;

    }
}

