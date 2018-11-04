namespace Graph
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
            this.pctrBxGraph = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btDraw = new System.Windows.Forms.Button();
            this.btAddVer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btDelVer = new System.Windows.Forms.Button();
            this.txtbDelVer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radBtAdd = new System.Windows.Forms.RadioButton();
            this.radBtDel = new System.Windows.Forms.RadioButton();
            this.txtbStart = new System.Windows.Forms.TextBox();
            this.txtbFinish = new System.Windows.Forms.TextBox();
            this.btEdge = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btDrawTree = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctrBxGraph)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctrBxGraph
            // 
            this.pctrBxGraph.Location = new System.Drawing.Point(0, 27);
            this.pctrBxGraph.Name = "pctrBxGraph";
            this.pctrBxGraph.Size = new System.Drawing.Size(980, 780);
            this.pctrBxGraph.TabIndex = 0;
            this.pctrBxGraph.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1360, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // btDraw
            // 
            this.btDraw.Location = new System.Drawing.Point(989, 546);
            this.btDraw.Name = "btDraw";
            this.btDraw.Size = new System.Drawing.Size(341, 103);
            this.btDraw.TabIndex = 2;
            this.btDraw.Text = "Нарисовать";
            this.btDraw.UseVisualStyleBackColor = true;
            this.btDraw.Click += new System.EventHandler(this.btDraw_Click);
            // 
            // btAddVer
            // 
            this.btAddVer.Location = new System.Drawing.Point(1033, 290);
            this.btAddVer.Name = "btAddVer";
            this.btAddVer.Size = new System.Drawing.Size(99, 59);
            this.btAddVer.TabIndex = 3;
            this.btAddVer.Text = "Добавить узел";
            this.btAddVer.UseVisualStyleBackColor = true;
            this.btAddVer.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(999, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Операции с узлами";
            // 
            // btDelVer
            // 
            this.btDelVer.Location = new System.Drawing.Point(1033, 361);
            this.btDelVer.Name = "btDelVer";
            this.btDelVer.Size = new System.Drawing.Size(99, 59);
            this.btDelVer.TabIndex = 5;
            this.btDelVer.Text = "Удалить узел";
            this.btDelVer.UseVisualStyleBackColor = true;
            this.btDelVer.Click += new System.EventHandler(this.btDelVer_Click);
            // 
            // txtbDelVer
            // 
            this.txtbDelVer.Location = new System.Drawing.Point(1158, 381);
            this.txtbDelVer.Name = "txtbDelVer";
            this.txtbDelVer.Size = new System.Drawing.Size(100, 20);
            this.txtbDelVer.TabIndex = 6;
            this.txtbDelVer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbDelVer_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1003, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Операции с ребрами";
            // 
            // radBtAdd
            // 
            this.radBtAdd.AutoSize = true;
            this.radBtAdd.Location = new System.Drawing.Point(1033, 84);
            this.radBtAdd.Name = "radBtAdd";
            this.radBtAdd.Size = new System.Drawing.Size(75, 17);
            this.radBtAdd.TabIndex = 8;
            this.radBtAdd.TabStop = true;
            this.radBtAdd.Text = "Добавить";
            this.radBtAdd.UseVisualStyleBackColor = true;
            // 
            // radBtDel
            // 
            this.radBtDel.AutoSize = true;
            this.radBtDel.Location = new System.Drawing.Point(1033, 108);
            this.radBtDel.Name = "radBtDel";
            this.radBtDel.Size = new System.Drawing.Size(68, 17);
            this.radBtDel.TabIndex = 9;
            this.radBtDel.TabStop = true;
            this.radBtDel.Text = "Удалить";
            this.radBtDel.UseVisualStyleBackColor = true;
            // 
            // txtbStart
            // 
            this.txtbStart.Location = new System.Drawing.Point(1127, 95);
            this.txtbStart.Name = "txtbStart";
            this.txtbStart.Size = new System.Drawing.Size(41, 20);
            this.txtbStart.TabIndex = 10;
            this.txtbStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbStart_KeyPress);
            // 
            // txtbFinish
            // 
            this.txtbFinish.Location = new System.Drawing.Point(1188, 95);
            this.txtbFinish.Name = "txtbFinish";
            this.txtbFinish.Size = new System.Drawing.Size(41, 20);
            this.txtbFinish.TabIndex = 11;
            this.txtbFinish.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFinish_KeyPress);
            // 
            // btEdge
            // 
            this.btEdge.Location = new System.Drawing.Point(1255, 81);
            this.btEdge.Name = "btEdge";
            this.btEdge.Size = new System.Drawing.Size(75, 44);
            this.btEdge.TabIndex = 12;
            this.btEdge.Text = "Сделать";
            this.btEdge.UseVisualStyleBackColor = true;
            this.btEdge.Click += new System.EventHandler(this.btEdge_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(1124, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Откуда";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(1185, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Куда";
            // 
            // btDrawTree
            // 
            this.btDrawTree.Location = new System.Drawing.Point(989, 684);
            this.btDrawTree.Name = "btDrawTree";
            this.btDrawTree.Size = new System.Drawing.Size(341, 103);
            this.btDrawTree.TabIndex = 15;
            this.btDrawTree.Text = "Построить дерево";
            this.btDrawTree.UseVisualStyleBackColor = true;
            this.btDrawTree.Click += new System.EventHandler(this.btDrawTree_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 811);
            this.Controls.Add(this.btDrawTree);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btEdge);
            this.Controls.Add(this.txtbFinish);
            this.Controls.Add(this.txtbStart);
            this.Controls.Add(this.radBtDel);
            this.Controls.Add(this.radBtAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbDelVer);
            this.Controls.Add(this.btDelVer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btAddVer);
            this.Controls.Add(this.btDraw);
            this.Controls.Add(this.pctrBxGraph);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctrBxGraph)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctrBxGraph;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.Button btDraw;
        private System.Windows.Forms.Button btAddVer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDelVer;
        private System.Windows.Forms.TextBox txtbDelVer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radBtAdd;
        private System.Windows.Forms.RadioButton radBtDel;
        private System.Windows.Forms.TextBox txtbStart;
        private System.Windows.Forms.TextBox txtbFinish;
        private System.Windows.Forms.Button btEdge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btDrawTree;
    }
}

