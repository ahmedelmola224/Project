
namespace project
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
            this.username_txtb = new System.Windows.Forms.TextBox();
            this.password_txtb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.login_btn = new System.Windows.Forms.Button();
            this.browse_btn = new System.Windows.Forms.Button();
            this.league_dbDataSet = new project.league_dbDataSet();
            this.adminsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.adminsTableAdapter = new project.league_dbDataSetTableAdapters.adminsTableAdapter();
            this.adminsTableAdapter1 = new project.league_dbDataSetTableAdapters.adminsTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.league_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // username_txtb
            // 
            this.username_txtb.Location = new System.Drawing.Point(117, 36);
            this.username_txtb.Name = "username_txtb";
            this.username_txtb.Size = new System.Drawing.Size(155, 22);
            this.username_txtb.TabIndex = 0;
            // 
            // password_txtb
            // 
            this.password_txtb.Location = new System.Drawing.Point(117, 83);
            this.password_txtb.Name = "password_txtb";
            this.password_txtb.Size = new System.Drawing.Size(155, 22);
            this.password_txtb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(88, 143);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(132, 36);
            this.login_btn.TabIndex = 4;
            this.login_btn.Text = "Log In";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // browse_btn
            // 
            this.browse_btn.Location = new System.Drawing.Point(88, 202);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(132, 34);
            this.browse_btn.TabIndex = 5;
            this.browse_btn.Text = "Browse";
            this.browse_btn.UseVisualStyleBackColor = true;
            this.browse_btn.Click += new System.EventHandler(this.browse_btn_Click);
            // 
            // league_dbDataSet
            // 
            this.league_dbDataSet.DataSetName = "league_dbDataSet";
            this.league_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adminsBindingSource
            // 
            this.adminsBindingSource.DataMember = "admins";
            this.adminsBindingSource.DataSource = this.league_dbDataSet;
            // 
            // adminsTableAdapter
            // 
            this.adminsTableAdapter.ClearBeforeFill = true;
            // 
            // adminsTableAdapter1
            // 
            this.adminsTableAdapter1.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "-OR-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 272);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.browse_btn);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password_txtb);
            this.Controls.Add(this.username_txtb);
            this.Name = "Form1";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.league_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox username_txtb;
        private System.Windows.Forms.TextBox password_txtb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Button browse_btn;
        private league_dbDataSet league_dbDataSet;
        private System.Windows.Forms.BindingSource adminsBindingSource;
        private league_dbDataSetTableAdapters.adminsTableAdapter adminsTableAdapter;
        private league_dbDataSetTableAdapters.adminsTableAdapter adminsTableAdapter1;
        private System.Windows.Forms.Label label3;
    }
}

