namespace MyDrawingForm
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridViewShapes = new System.Windows.Forms.DataGridView();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxShape = new System.Windows.Forms.ComboBox();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.YLabel = new System.Windows.Forms.Label();
            this.XLabel = new System.Windows.Forms.Label();
            this.TextLabel = new System.Windows.Forms.Label();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButtonStart = new System.Windows.Forms.ToolStripButton();
            this.ButtonTerminator = new System.Windows.Forms.ToolStripButton();
            this.ButtonProcess = new System.Windows.Forms.ToolStripButton();
            this.ButtonDecision = new System.Windows.Forms.ToolStripButton();
            this.ButtonLine = new System.Windows.Forms.ToolStripButton();
            this.ButtonSelect = new System.Windows.Forms.ToolStripButton();
            this.ButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.ButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.drawPanel = new System.Windows.Forms.Panel();
            this.ButtonSave = new System.Windows.Forms.ToolStripButton();
            this.ButtonLoad = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShapes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewShapes
            // 
            this.dataGridViewShapes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewShapes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShapes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDelete,
            this.ColumnID,
            this.ColumnShape,
            this.ColumnText,
            this.ColumnX,
            this.ColumnY,
            this.ColumnHeight,
            this.ColumnWidth});
            this.dataGridViewShapes.Location = new System.Drawing.Point(6, 86);
            this.dataGridViewShapes.Name = "dataGridViewShapes";
            this.dataGridViewShapes.RowHeadersVisible = false;
            this.dataGridViewShapes.RowTemplate.Height = 24;
            this.dataGridViewShapes.Size = new System.Drawing.Size(427, 495);
            this.dataGridViewShapes.TabIndex = 0;
            this.dataGridViewShapes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewShapes_CellClick);
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.HeaderText = "刪除";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.ReadOnly = true;
            this.ColumnDelete.Text = "";
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            // 
            // ColumnShape
            // 
            this.ColumnShape.HeaderText = "形狀";
            this.ColumnShape.Name = "ColumnShape";
            this.ColumnShape.ReadOnly = true;
            // 
            // ColumnText
            // 
            this.ColumnText.HeaderText = "文字";
            this.ColumnText.Name = "ColumnText";
            this.ColumnText.ReadOnly = true;
            // 
            // ColumnX
            // 
            this.ColumnX.HeaderText = "X";
            this.ColumnX.Name = "ColumnX";
            this.ColumnX.ReadOnly = true;
            // 
            // ColumnY
            // 
            this.ColumnY.HeaderText = "Y";
            this.ColumnY.Name = "ColumnY";
            this.ColumnY.ReadOnly = true;
            // 
            // ColumnHeight
            // 
            this.ColumnHeight.HeaderText = "H";
            this.ColumnHeight.Name = "ColumnHeight";
            this.ColumnHeight.ReadOnly = true;
            // 
            // ColumnWidth
            // 
            this.ColumnWidth.HeaderText = "W";
            this.ColumnWidth.Name = "ColumnWidth";
            this.ColumnWidth.ReadOnly = true;
            // 
            // comboBoxShape
            // 
            this.comboBoxShape.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxShape.FormattingEnabled = true;
            this.comboBoxShape.Items.AddRange(new object[] {
            "Start",
            "Terminator",
            "Process",
            "Decision"});
            this.comboBoxShape.Location = new System.Drawing.Point(98, 58);
            this.comboBoxShape.Name = "comboBoxShape";
            this.comboBoxShape.Size = new System.Drawing.Size(56, 20);
            this.comboBoxShape.TabIndex = 1;
            this.comboBoxShape.Text = "形狀";
            this.comboBoxShape.SelectedIndexChanged += new System.EventHandler(this.ComboBoxShape_SelectedIndexChanged);
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(160, 58);
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(86, 22);
            this.textBoxText.TabIndex = 2;
            this.textBoxText.Tag = "";
            this.textBoxText.TextChanged += new System.EventHandler(this.TextBoxText_Changed);
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(252, 58);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(37, 22);
            this.textBoxX.TabIndex = 2;
            this.textBoxX.TextChanged += new System.EventHandler(this.TextBoxX_Changed);
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(295, 58);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(37, 22);
            this.textBoxY.TabIndex = 2;
            this.textBoxY.TextChanged += new System.EventHandler(this.TextBoxY_Changed);
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(338, 58);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(37, 22);
            this.textBoxHeight.TabIndex = 2;
            this.textBoxHeight.TextChanged += new System.EventHandler(this.TextBoxHeight_Changed);
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(381, 58);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(37, 22);
            this.textBoxWidth.TabIndex = 2;
            this.textBoxWidth.TextChanged += new System.EventHandler(this.TextBoxWidth_Changed);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WidthLabel);
            this.groupBox1.Controls.Add(this.HeightLabel);
            this.groupBox1.Controls.Add(this.YLabel);
            this.groupBox1.Controls.Add(this.XLabel);
            this.groupBox1.Controls.Add(this.TextLabel);
            this.groupBox1.Controls.Add(this.ButtonAdd);
            this.groupBox1.Controls.Add(this.textBoxWidth);
            this.groupBox1.Controls.Add(this.dataGridViewShapes);
            this.groupBox1.Controls.Add(this.textBoxHeight);
            this.groupBox1.Controls.Add(this.comboBoxShape);
            this.groupBox1.Controls.Add(this.textBoxY);
            this.groupBox1.Controls.Add(this.textBoxText);
            this.groupBox1.Controls.Add(this.textBoxX);
            this.groupBox1.Location = new System.Drawing.Point(862, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 585);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "資料顯示";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.WidthLabel.ForeColor = System.Drawing.Color.Red;
            this.WidthLabel.Location = new System.Drawing.Point(392, 39);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(19, 13);
            this.WidthLabel.TabIndex = 3;
            this.WidthLabel.Text = "W";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HeightLabel.ForeColor = System.Drawing.Color.Red;
            this.HeightLabel.Location = new System.Drawing.Point(350, 39);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(16, 13);
            this.HeightLabel.TabIndex = 3;
            this.HeightLabel.Text = "H";
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.YLabel.ForeColor = System.Drawing.Color.Red;
            this.YLabel.Location = new System.Drawing.Point(305, 39);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(16, 13);
            this.YLabel.TabIndex = 3;
            this.YLabel.Text = "Y";
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.XLabel.ForeColor = System.Drawing.Color.Red;
            this.XLabel.Location = new System.Drawing.Point(262, 39);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(16, 13);
            this.XLabel.TabIndex = 3;
            this.XLabel.Text = "X";
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TextLabel.ForeColor = System.Drawing.Color.Red;
            this.TextLabel.Location = new System.Drawing.Point(184, 39);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(33, 13);
            this.TextLabel.TabIndex = 3;
            this.TextLabel.Text = "文字";
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(6, 39);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(69, 41);
            this.ButtonAdd.TabIndex = 1;
            this.ButtonAdd.Text = "新增";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 90);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 183);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 90);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1310, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonStart,
            this.ButtonTerminator,
            this.ButtonProcess,
            this.ButtonDecision,
            this.ButtonLine,
            this.ButtonSelect,
            this.ButtonUndo,
            this.ButtonRedo,
            this.ButtonSave,
            this.ButtonLoad});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1310, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ButtonStart
            // 
            this.ButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("ButtonStart.Image")));
            this.ButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(23, 22);
            this.ButtonStart.Text = "toolStripButton1";
            this.ButtonStart.ToolTipText = "Start";
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ButtonTerminator
            // 
            this.ButtonTerminator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonTerminator.Image = ((System.Drawing.Image)(resources.GetObject("ButtonTerminator.Image")));
            this.ButtonTerminator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonTerminator.Name = "ButtonTerminator";
            this.ButtonTerminator.Size = new System.Drawing.Size(23, 22);
            this.ButtonTerminator.Text = "toolStripButton2";
            this.ButtonTerminator.ToolTipText = "Terminator";
            this.ButtonTerminator.Click += new System.EventHandler(this.ButtonTerminator_Click);
            // 
            // ButtonProcess
            // 
            this.ButtonProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonProcess.Image = ((System.Drawing.Image)(resources.GetObject("ButtonProcess.Image")));
            this.ButtonProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonProcess.Name = "ButtonProcess";
            this.ButtonProcess.Size = new System.Drawing.Size(23, 22);
            this.ButtonProcess.Text = "toolStripButton3";
            this.ButtonProcess.ToolTipText = "Process";
            this.ButtonProcess.Click += new System.EventHandler(this.ButtonProcess_Click);
            // 
            // ButtonDecision
            // 
            this.ButtonDecision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonDecision.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDecision.Image")));
            this.ButtonDecision.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonDecision.Name = "ButtonDecision";
            this.ButtonDecision.Size = new System.Drawing.Size(23, 22);
            this.ButtonDecision.Text = "toolStripButton4";
            this.ButtonDecision.ToolTipText = "Decision";
            this.ButtonDecision.Click += new System.EventHandler(this.ButtonDecision_Click);
            // 
            // ButtonLine
            // 
            this.ButtonLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonLine.Image = ((System.Drawing.Image)(resources.GetObject("ButtonLine.Image")));
            this.ButtonLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonLine.Name = "ButtonLine";
            this.ButtonLine.Size = new System.Drawing.Size(23, 22);
            this.ButtonLine.Text = "Line";
            this.ButtonLine.ToolTipText = "Line";
            this.ButtonLine.Click += new System.EventHandler(this.ButtonLine_Click);
            // 
            // ButtonSelect
            // 
            this.ButtonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonSelect.Image = ((System.Drawing.Image)(resources.GetObject("ButtonSelect.Image")));
            this.ButtonSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSelect.Name = "ButtonSelect";
            this.ButtonSelect.Size = new System.Drawing.Size(23, 22);
            this.ButtonSelect.Text = "Select";
            this.ButtonSelect.ToolTipText = "Select";
            this.ButtonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // ButtonUndo
            // 
            this.ButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonUndo.Enabled = false;
            this.ButtonUndo.Image = ((System.Drawing.Image)(resources.GetObject("ButtonUndo.Image")));
            this.ButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonUndo.Name = "ButtonUndo";
            this.ButtonUndo.Size = new System.Drawing.Size(23, 22);
            this.ButtonUndo.Text = "Undo";
            this.ButtonUndo.ToolTipText = "Undo";
            this.ButtonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
            // 
            // ButtonRedo
            // 
            this.ButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonRedo.Enabled = false;
            this.ButtonRedo.Image = ((System.Drawing.Image)(resources.GetObject("ButtonRedo.Image")));
            this.ButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonRedo.Name = "ButtonRedo";
            this.ButtonRedo.Size = new System.Drawing.Size(23, 22);
            this.ButtonRedo.Text = "Redo";
            this.ButtonRedo.ToolTipText = "Redo";
            this.ButtonRedo.Click += new System.EventHandler(this.ButtonRedo_Click);
            // 
            // drawPanel
            // 
            this.drawPanel.Location = new System.Drawing.Point(178, 52);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(678, 564);
            this.drawPanel.TabIndex = 8;
            // 
            // ButtonSave
            // 
            this.ButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("ButtonSave.Image")));
            this.ButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(23, 22);
            this.ButtonSave.Text = "Save";
            this.ButtonSave.ToolTipText = "Save";
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonLoad.Image = ((System.Drawing.Image)(resources.GetObject("ButtonLoad.Image")));
            this.ButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size(23, 22);
            this.ButtonLoad.Text = "Load";
            this.ButtonLoad.ToolTipText = "Load";
            this.ButtonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 663);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MyDrawing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShapes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxShape;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewShapes;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShape;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWidth;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ButtonStart;
        private System.Windows.Forms.ToolStripButton ButtonTerminator;
        private System.Windows.Forms.ToolStripButton ButtonProcess;
        private System.Windows.Forms.ToolStripButton ButtonDecision;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.ToolStripButton ButtonSelect;
        private System.Windows.Forms.ToolStripButton ButtonLine;
        private System.Windows.Forms.ToolStripButton ButtonUndo;
        private System.Windows.Forms.ToolStripButton ButtonRedo;
        private System.Windows.Forms.ToolStripButton ButtonSave;
        private System.Windows.Forms.ToolStripButton ButtonLoad;
    }
}

