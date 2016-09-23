namespace Client
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.lstTickets = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnApproval = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(35, 30);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "创建流";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lstTickets
            // 
            this.lstTickets.FormattingEnabled = true;
            this.lstTickets.ItemHeight = 12;
            this.lstTickets.Location = new System.Drawing.Point(35, 68);
            this.lstTickets.Name = "lstTickets";
            this.lstTickets.Size = new System.Drawing.Size(486, 172);
            this.lstTickets.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "审批意见";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(35, 273);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(486, 21);
            this.txtComment.TabIndex = 3;
            // 
            // btnApproval
            // 
            this.btnApproval.Location = new System.Drawing.Point(35, 309);
            this.btnApproval.Name = "btnApproval";
            this.btnApproval.Size = new System.Drawing.Size(75, 23);
            this.btnApproval.TabIndex = 4;
            this.btnApproval.Text = "同意";
            this.btnApproval.UseVisualStyleBackColor = true;
            this.btnApproval.Click += new System.EventHandler(this.btnApproval_Click);
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(125, 309);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 4;
            this.btnReject.Text = "拒绝";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 344);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApproval);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstTickets);
            this.Controls.Add(this.btnCreate);
            this.Name = "Form1";
            this.Text = "WF事件驱动Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ListBox lstTickets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnApproval;
        private System.Windows.Forms.Button btnReject;
    }
}

