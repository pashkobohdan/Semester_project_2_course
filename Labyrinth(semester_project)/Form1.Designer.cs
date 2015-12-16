namespace Labyrinth_semester_project_
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.лабиринтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прочитатьСВидеофайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прочитатьСФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьОтчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.путьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поШагамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очистиьтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сброситьКоординатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритмФлойдаУоршеллаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инструкцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.началоПутиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.конецПутиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.очиститьВсёToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.лабиринтToolStripMenuItem,
            this.путьToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(670, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // лабиринтToolStripMenuItem
            // 
            this.лабиринтToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прочитатьСВидеофайлаToolStripMenuItem,
            this.прочитатьСФайлаToolStripMenuItem,
            this.сохранитьВФайлToolStripMenuItem,
            this.сохранитьОтчётToolStripMenuItem,
            this.выйтиToolStripMenuItem});
            this.лабиринтToolStripMenuItem.Name = "лабиринтToolStripMenuItem";
            this.лабиринтToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.лабиринтToolStripMenuItem.Text = "Файл";
            // 
            // прочитатьСВидеофайлаToolStripMenuItem
            // 
            this.прочитатьСВидеофайлаToolStripMenuItem.Name = "прочитатьСВидеофайлаToolStripMenuItem";
            this.прочитатьСВидеофайлаToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.прочитатьСВидеофайлаToolStripMenuItem.Text = "Открыть видеофайл";
            this.прочитатьСВидеофайлаToolStripMenuItem.Click += new System.EventHandler(this.прочитатьСВидеофайлаToolStripMenuItem_Click);
            // 
            // прочитатьСФайлаToolStripMenuItem
            // 
            this.прочитатьСФайлаToolStripMenuItem.Name = "прочитатьСФайлаToolStripMenuItem";
            this.прочитатьСФайлаToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.прочитатьСФайлаToolStripMenuItem.Text = "Открыть XML файл";
            this.прочитатьСФайлаToolStripMenuItem.Click += new System.EventHandler(this.прочитатьСФайлаToolStripMenuItem_Click);
            // 
            // сохранитьВФайлToolStripMenuItem
            // 
            this.сохранитьВФайлToolStripMenuItem.Name = "сохранитьВФайлToolStripMenuItem";
            this.сохранитьВФайлToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.сохранитьВФайлToolStripMenuItem.Text = "Сохранить";
            this.сохранитьВФайлToolStripMenuItem.Click += new System.EventHandler(this.сохранитьВФайлToolStripMenuItem_Click);
            // 
            // сохранитьОтчётToolStripMenuItem
            // 
            this.сохранитьОтчётToolStripMenuItem.Name = "сохранитьОтчётToolStripMenuItem";
            this.сохранитьОтчётToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.сохранитьОтчётToolStripMenuItem.Text = "Сохранить отчёт";
            this.сохранитьОтчётToolStripMenuItem.Click += new System.EventHandler(this.сохранитьОтчётToolStripMenuItem_Click);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // путьToolStripMenuItem
            // 
            this.путьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.построитьToolStripMenuItem,
            this.поШагамToolStripMenuItem,
            this.очистиьтToolStripMenuItem,
            this.сброситьКоординатыToolStripMenuItem,
            this.очиститьВсёToolStripMenuItem});
            this.путьToolStripMenuItem.Name = "путьToolStripMenuItem";
            this.путьToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.путьToolStripMenuItem.Text = "Путь";
            // 
            // построитьToolStripMenuItem
            // 
            this.построитьToolStripMenuItem.Name = "построитьToolStripMenuItem";
            this.построитьToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.построитьToolStripMenuItem.Text = "Построить";
            this.построитьToolStripMenuItem.Click += new System.EventHandler(this.построитьToolStripMenuItem_Click);
            // 
            // поШагамToolStripMenuItem
            // 
            this.поШагамToolStripMenuItem.Name = "поШагамToolStripMenuItem";
            this.поШагамToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.поШагамToolStripMenuItem.Text = "По шагам";
            this.поШагамToolStripMenuItem.Click += new System.EventHandler(this.поШагамToolStripMenuItem_Click);
            // 
            // очистиьтToolStripMenuItem
            // 
            this.очистиьтToolStripMenuItem.Name = "очистиьтToolStripMenuItem";
            this.очистиьтToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.очистиьтToolStripMenuItem.Text = "Очистить путь";
            this.очистиьтToolStripMenuItem.Click += new System.EventHandler(this.очистиьтToolStripMenuItem_Click);
            // 
            // сброситьКоординатыToolStripMenuItem
            // 
            this.сброситьКоординатыToolStripMenuItem.Name = "сброситьКоординатыToolStripMenuItem";
            this.сброситьКоординатыToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.сброситьКоординатыToolStripMenuItem.Text = "Сбросить координаты";
            this.сброситьКоординатыToolStripMenuItem.Click += new System.EventHandler(this.сброситьКоординатыToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.алгоритмФлойдаУоршеллаToolStripMenuItem,
            this.инструкцияToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // алгоритмФлойдаУоршеллаToolStripMenuItem
            // 
            this.алгоритмФлойдаУоршеллаToolStripMenuItem.Name = "алгоритмФлойдаУоршеллаToolStripMenuItem";
            this.алгоритмФлойдаУоршеллаToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.алгоритмФлойдаУоршеллаToolStripMenuItem.Text = "Алгоритм Флойда-Уоршелла";
            this.алгоритмФлойдаУоршеллаToolStripMenuItem.Click += new System.EventHandler(this.алгоритмФлойдаУоршеллаToolStripMenuItem_Click);
            // 
            // инструкцияToolStripMenuItem
            // 
            this.инструкцияToolStripMenuItem.Name = "инструкцияToolStripMenuItem";
            this.инструкцияToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.инструкцияToolStripMenuItem.Text = "Инструкция";
            this.инструкцияToolStripMenuItem.Click += new System.EventHandler(this.инструкцияToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(670, 382);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.началоПутиToolStripMenuItem,
            this.конецПутиToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 48);
            // 
            // началоПутиToolStripMenuItem
            // 
            this.началоПутиToolStripMenuItem.Name = "началоПутиToolStripMenuItem";
            this.началоПутиToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.началоПутиToolStripMenuItem.Text = "Начало пути";
            this.началоПутиToolStripMenuItem.Click += new System.EventHandler(this.началоПутиToolStripMenuItem_Click);
            // 
            // конецПутиToolStripMenuItem
            // 
            this.конецПутиToolStripMenuItem.Name = "конецПутиToolStripMenuItem";
            this.конецПутиToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.конецПутиToolStripMenuItem.Text = "Конец пути";
            this.конецПутиToolStripMenuItem.Click += new System.EventHandler(this.конецПутиToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // очиститьВсёToolStripMenuItem
            // 
            this.очиститьВсёToolStripMenuItem.Name = "очиститьВсёToolStripMenuItem";
            this.очиститьВсёToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.очиститьВсёToolStripMenuItem.Text = "Очистить область рисования";
            this.очиститьВсёToolStripMenuItem.Click += new System.EventHandler(this.очиститьВсёToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 409);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Лабиринт";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem лабиринтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прочитатьСВидеофайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прочитатьСФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem началоПутиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem конецПутиToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem путьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem построитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поШагамToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem очистиьтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритмФлойдаУоршеллаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инструкцияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сброситьКоординатыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьОтчётToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьВсёToolStripMenuItem;
    }
}

