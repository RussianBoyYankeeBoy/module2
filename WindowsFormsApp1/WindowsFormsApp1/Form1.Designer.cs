
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.accessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mysqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компанииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.интервьюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.companiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moreinformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accessToolStripMenuItem,
            this.mysqlToolStripMenuItem,
            this.sqlServerToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // accessToolStripMenuItem
            // 
            this.accessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сотрудникиToolStripMenuItem,
            this.компанииToolStripMenuItem,
            this.интервьюToolStripMenuItem});
            this.accessToolStripMenuItem.Name = "accessToolStripMenuItem";
            this.accessToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.accessToolStripMenuItem.Text = "Access";
            // 
            // mysqlToolStripMenuItem
            // 
            this.mysqlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeesToolStripMenuItem,
            this.companiesToolStripMenuItem,
            this.contactsToolStripMenuItem});
            this.mysqlToolStripMenuItem.Name = "mysqlToolStripMenuItem";
            this.mysqlToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.mysqlToolStripMenuItem.Text = "Mysql";
            // 
            // sqlServerToolStripMenuItem
            // 
            this.sqlServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeesToolStripMenuItem1,
            this.moreinformationToolStripMenuItem,
            this.departmentsToolStripMenuItem});
            this.sqlServerToolStripMenuItem.Name = "sqlServerToolStripMenuItem";
            this.sqlServerToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.sqlServerToolStripMenuItem.Text = "Sql server";
            // 
            // сотрудникиToolStripMenuItem
            // 
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            this.сотрудникиToolStripMenuItem.Click += new System.EventHandler(this.сотрудникиToolStripMenuItem_Click);
            // 
            // компанииToolStripMenuItem
            // 
            this.компанииToolStripMenuItem.Name = "компанииToolStripMenuItem";
            this.компанииToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.компанииToolStripMenuItem.Text = "Компании";
            this.компанииToolStripMenuItem.Click += new System.EventHandler(this.компанииToolStripMenuItem_Click);
            // 
            // интервьюToolStripMenuItem
            // 
            this.интервьюToolStripMenuItem.Name = "интервьюToolStripMenuItem";
            this.интервьюToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.интервьюToolStripMenuItem.Text = "Интервью";
            this.интервьюToolStripMenuItem.Click += new System.EventHandler(this.интервьюToolStripMenuItem_Click);
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.employeesToolStripMenuItem.Text = "employees";
            this.employeesToolStripMenuItem.Click += new System.EventHandler(this.employeesToolStripMenuItem_Click);
            // 
            // employeesToolStripMenuItem1
            // 
            this.employeesToolStripMenuItem1.Name = "employeesToolStripMenuItem1";
            this.employeesToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.employeesToolStripMenuItem1.Text = "employees";
            this.employeesToolStripMenuItem1.Click += new System.EventHandler(this.employeesToolStripMenuItem1_Click);
            // 
            // companiesToolStripMenuItem
            // 
            this.companiesToolStripMenuItem.Name = "companiesToolStripMenuItem";
            this.companiesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.companiesToolStripMenuItem.Text = "departments";
            this.companiesToolStripMenuItem.Click += new System.EventHandler(this.companiesToolStripMenuItem_Click);
            // 
            // contactsToolStripMenuItem
            // 
            this.contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
            this.contactsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.contactsToolStripMenuItem.Text = "contacts";
            this.contactsToolStripMenuItem.Click += new System.EventHandler(this.contactsToolStripMenuItem_Click);
            // 
            // moreinformationToolStripMenuItem
            // 
            this.moreinformationToolStripMenuItem.Name = "moreinformationToolStripMenuItem";
            this.moreinformationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.moreinformationToolStripMenuItem.Text = "more_information";
            this.moreinformationToolStripMenuItem.Click += new System.EventHandler(this.moreinformationToolStripMenuItem_Click);
            // 
            // departmentsToolStripMenuItem
            // 
            this.departmentsToolStripMenuItem.Name = "departmentsToolStripMenuItem";
            this.departmentsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.departmentsToolStripMenuItem.Text = "departments";
            this.departmentsToolStripMenuItem.Click += new System.EventHandler(this.departmentsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem accessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компанииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem интервьюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mysqlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqlServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem companiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moreinformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentsToolStripMenuItem;
    }
}

