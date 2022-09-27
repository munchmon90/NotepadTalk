namespace memo_1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.friend_list = new System.Windows.Forms.ListBox();
            this.add_friend = new System.Windows.Forms.TextBox();
            this.add_btn = new System.Windows.Forms.Button();
            this.rm_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(17, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 114);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(17, 524);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(541, 114);
            this.panel2.TabIndex = 1;
            // 
            // friend_list
            // 
            this.friend_list.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.friend_list.FormattingEnabled = true;
            this.friend_list.ItemHeight = 32;
            this.friend_list.Location = new System.Drawing.Point(17, 194);
            this.friend_list.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.friend_list.Name = "friend_list";
            this.friend_list.Size = new System.Drawing.Size(393, 292);
            this.friend_list.TabIndex = 2;
            // 
            // add_friend
            // 
            this.add_friend.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.add_friend.Location = new System.Drawing.Point(17, 141);
            this.add_friend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.add_friend.Name = "add_friend";
            this.add_friend.Size = new System.Drawing.Size(393, 39);
            this.add_friend.TabIndex = 3;
            this.add_friend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.add_friend_KeyDown);
            // 
            // add_btn
            // 
            this.add_btn.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.add_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_btn.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.add_btn.Location = new System.Drawing.Point(421, 141);
            this.add_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(137, 42);
            this.add_btn.TabIndex = 4;
            this.add_btn.Text = "추가";
            this.add_btn.UseVisualStyleBackColor = false;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // rm_btn
            // 
            this.rm_btn.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.rm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rm_btn.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.rm_btn.Location = new System.Drawing.Point(421, 194);
            this.rm_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rm_btn.Name = "rm_btn";
            this.rm_btn.Size = new System.Drawing.Size(137, 42);
            this.rm_btn.TabIndex = 4;
            this.rm_btn.Text = "삭제";
            this.rm_btn.UseVisualStyleBackColor = false;
            this.rm_btn.Click += new System.EventHandler(this.rm_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.save_btn.Location = new System.Drawing.Point(420, 244);
            this.save_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(137, 42);
            this.save_btn.TabIndex = 4;
            this.save_btn.Text = "저장";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(576, 650);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.rm_btn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.add_friend);
            this.Controls.Add(this.friend_list);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox friend_list;
        private System.Windows.Forms.TextBox add_friend;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button rm_btn;
        private System.Windows.Forms.Button save_btn;
    }
}