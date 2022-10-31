namespace Login_Fb
{
    partial class Form1
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
            this.rdDataImport = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnImport = new System.Windows.Forms.Button();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginEmailPassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginEmailPass2FAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdDataImport
            // 
            this.rdDataImport.Location = new System.Drawing.Point(13, 13);
            this.rdDataImport.Name = "rdDataImport";
            this.rdDataImport.Size = new System.Drawing.Size(416, 145);
            this.rdDataImport.TabIndex = 0;
            this.rdDataImport.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.email,
            this.pass,
            this.fa,
            this.proxy,
            this.note});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(13, 186);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(775, 241);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(435, 68);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // stt
            // 
            this.stt.HeaderText = "STT";
            this.stt.Name = "stt";
            // 
            // email
            // 
            this.email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            // 
            // pass
            // 
            this.pass.HeaderText = "PassWord";
            this.pass.Name = "pass";
            // 
            // fa
            // 
            this.fa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fa.HeaderText = "2FA";
            this.fa.Name = "fa";
            // 
            // proxy
            // 
            this.proxy.HeaderText = "Proxy";
            this.proxy.Name = "proxy";
            // 
            // note
            // 
            this.note.HeaderText = "Ghi Chú";
            this.note.Name = "note";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginEmailPassToolStripMenuItem,
            this.loginEmailPass2FAToolStripMenuItem});
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loginToolStripMenuItem.Text = "Login";
            // 
            // loginEmailPassToolStripMenuItem
            // 
            this.loginEmailPassToolStripMenuItem.Name = "loginEmailPassToolStripMenuItem";
            this.loginEmailPassToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.loginEmailPassToolStripMenuItem.Text = "Login Email|Pass";
            this.loginEmailPassToolStripMenuItem.Click += new System.EventHandler(this.loginEmailPassToolStripMenuItem_Click);
            // 
            // loginEmailPass2FAToolStripMenuItem
            // 
            this.loginEmailPass2FAToolStripMenuItem.Name = "loginEmailPass2FAToolStripMenuItem";
            this.loginEmailPass2FAToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.loginEmailPass2FAToolStripMenuItem.Text = "Login Email|Pass|2FA";
            this.loginEmailPass2FAToolStripMenuItem.Click += new System.EventHandler(this.loginEmailPass2FAToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 450);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rdDataImport);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rdDataImport;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn fa;
        private System.Windows.Forms.DataGridViewTextBoxColumn proxy;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginEmailPassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginEmailPass2FAToolStripMenuItem;
    }
}

