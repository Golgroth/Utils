namespace Modcomposer
{
    partial class ModComposer
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFolderBrowse = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pathValidatorText = new System.Windows.Forms.Label();
            this.modList = new System.Windows.Forms.ListView();
            this.modName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modDirectory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isModEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEnSel = new System.Windows.Forms.Button();
            this.btnEnAll = new System.Windows.Forms.Button();
            this.btnDiSel = new System.Windows.Forms.Button();
            this.btnDiAll = new System.Windows.Forms.Button();
            this.mdCntTxt = new System.Windows.Forms.Label();
            this.mdsCntNmb = new System.Windows.Forms.Label();
            this.mdsSelTxt = new System.Windows.Forms.Label();
            this.mdsSelCnt = new System.Windows.Forms.Label();
            this.btnCfgSave = new System.Windows.Forms.Button();
            this.btnSaveParamsCb = new System.Windows.Forms.Button();
            this.configSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnCfgLoad = new System.Windows.Forms.Button();
            this.configLoadDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnSaveParamsFile = new System.Windows.Forms.Button();
            this.paramSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.loadCfgFromHtml = new System.Windows.Forms.Button();
            this.htmlDialog = new System.Windows.Forms.OpenFileDialog();
            this.serverBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pathBox
            // 
            this.pathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathBox.Location = new System.Drawing.Point(15, 12);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(759, 20);
            this.pathBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mod directory";
            // 
            // folderDialog
            // 
            // 
            // btnFolderBrowse
            // 
            this.btnFolderBrowse.Location = new System.Drawing.Point(607, 34);
            this.btnFolderBrowse.Name = "btnFolderBrowse";
            this.btnFolderBrowse.Size = new System.Drawing.Size(75, 21);
            this.btnFolderBrowse.TabIndex = 2;
            this.btnFolderBrowse.Text = "Browse";
            this.btnFolderBrowse.UseVisualStyleBackColor = true;
            this.btnFolderBrowse.Click += new System.EventHandler(this.btnFolderBrowse_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(688, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 21);
            this.button1.TabIndex = 3;
            this.button1.Text = "Scan for mods";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pathValidatorText
            // 
            this.pathValidatorText.AutoSize = true;
            this.pathValidatorText.Location = new System.Drawing.Point(230, 38);
            this.pathValidatorText.Name = "pathValidatorText";
            this.pathValidatorText.Size = new System.Drawing.Size(0, 13);
            this.pathValidatorText.TabIndex = 5;
            // 
            // modList
            // 
            this.modList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.modName,
            this.modDirectory,
            this.isModEnabled});
            this.modList.HideSelection = false;
            this.modList.Location = new System.Drawing.Point(13, 101);
            this.modList.Name = "modList";
            this.modList.Size = new System.Drawing.Size(775, 288);
            this.modList.TabIndex = 6;
            this.modList.UseCompatibleStateImageBehavior = false;
            this.modList.View = System.Windows.Forms.View.Details;
            this.modList.DoubleClick += new System.EventHandler(this.modList_DoubleClick);
            this.modList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.modList_KeyDown);
            // 
            // modName
            // 
            this.modName.Text = "Mod Name";
            this.modName.Width = 146;
            // 
            // modDirectory
            // 
            this.modDirectory.Text = "Mod Path";
            this.modDirectory.Width = 476;
            // 
            // isModEnabled
            // 
            this.isModEnabled.Text = "Enabled?";
            this.isModEnabled.Width = 69;
            // 
            // btnEnSel
            // 
            this.btnEnSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnSel.Location = new System.Drawing.Point(15, 395);
            this.btnEnSel.Name = "btnEnSel";
            this.btnEnSel.Size = new System.Drawing.Size(91, 23);
            this.btnEnSel.TabIndex = 7;
            this.btnEnSel.Text = "Enable selected";
            this.btnEnSel.UseVisualStyleBackColor = true;
            this.btnEnSel.Click += new System.EventHandler(this.btnEnSel_Click);
            // 
            // btnEnAll
            // 
            this.btnEnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnAll.Location = new System.Drawing.Point(15, 424);
            this.btnEnAll.Name = "btnEnAll";
            this.btnEnAll.Size = new System.Drawing.Size(75, 23);
            this.btnEnAll.TabIndex = 8;
            this.btnEnAll.Text = "Enable all";
            this.btnEnAll.UseVisualStyleBackColor = true;
            this.btnEnAll.Click += new System.EventHandler(this.btnEnAll_Click);
            // 
            // btnDiSel
            // 
            this.btnDiSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDiSel.Location = new System.Drawing.Point(112, 395);
            this.btnDiSel.Name = "btnDiSel";
            this.btnDiSel.Size = new System.Drawing.Size(100, 23);
            this.btnDiSel.TabIndex = 9;
            this.btnDiSel.Text = "Disable selected";
            this.btnDiSel.UseVisualStyleBackColor = true;
            this.btnDiSel.Click += new System.EventHandler(this.btnDiSel_Click);
            // 
            // btnDiAll
            // 
            this.btnDiAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDiAll.Location = new System.Drawing.Point(96, 424);
            this.btnDiAll.Name = "btnDiAll";
            this.btnDiAll.Size = new System.Drawing.Size(75, 23);
            this.btnDiAll.TabIndex = 10;
            this.btnDiAll.Text = "Disable all";
            this.btnDiAll.UseVisualStyleBackColor = true;
            this.btnDiAll.Click += new System.EventHandler(this.btnDiAll_Click);
            // 
            // mdCntTxt
            // 
            this.mdCntTxt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mdCntTxt.AutoSize = true;
            this.mdCntTxt.Location = new System.Drawing.Point(168, 85);
            this.mdCntTxt.Name = "mdCntTxt";
            this.mdCntTxt.Size = new System.Drawing.Size(66, 13);
            this.mdCntTxt.TabIndex = 11;
            this.mdCntTxt.Text = "Mods found:";
            // 
            // mdsCntNmb
            // 
            this.mdsCntNmb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mdsCntNmb.AutoSize = true;
            this.mdsCntNmb.Location = new System.Drawing.Point(230, 85);
            this.mdsCntNmb.Name = "mdsCntNmb";
            this.mdsCntNmb.Size = new System.Drawing.Size(13, 13);
            this.mdsCntNmb.TabIndex = 12;
            this.mdsCntNmb.Text = "0";
            // 
            // mdsSelTxt
            // 
            this.mdsSelTxt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mdsSelTxt.AutoSize = true;
            this.mdsSelTxt.Location = new System.Drawing.Point(509, 85);
            this.mdsSelTxt.Name = "mdsSelTxt";
            this.mdsSelTxt.Size = new System.Drawing.Size(77, 13);
            this.mdsSelTxt.TabIndex = 11;
            this.mdsSelTxt.Text = "Mods enabled:";
            // 
            // mdsSelCnt
            // 
            this.mdsSelCnt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mdsSelCnt.AutoSize = true;
            this.mdsSelCnt.Location = new System.Drawing.Point(582, 85);
            this.mdsSelCnt.Name = "mdsSelCnt";
            this.mdsSelCnt.Size = new System.Drawing.Size(13, 13);
            this.mdsSelCnt.TabIndex = 12;
            this.mdsSelCnt.Text = "0";
            // 
            // btnCfgSave
            // 
            this.btnCfgSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCfgSave.Location = new System.Drawing.Point(713, 395);
            this.btnCfgSave.Name = "btnCfgSave";
            this.btnCfgSave.Size = new System.Drawing.Size(75, 23);
            this.btnCfgSave.TabIndex = 13;
            this.btnCfgSave.Text = "Save config";
            this.btnCfgSave.UseVisualStyleBackColor = true;
            this.btnCfgSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveParamsCb
            // 
            this.btnSaveParamsCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveParamsCb.Location = new System.Drawing.Point(601, 395);
            this.btnSaveParamsCb.Name = "btnSaveParamsCb";
            this.btnSaveParamsCb.Size = new System.Drawing.Size(106, 23);
            this.btnSaveParamsCb.TabIndex = 14;
            this.btnSaveParamsCb.Text = "Params (clipboard)";
            this.btnSaveParamsCb.UseVisualStyleBackColor = true;
            this.btnSaveParamsCb.Click += new System.EventHandler(this.btnSaveParamsCb_Click);
            // 
            // configSaveDialog
            // 
            this.configSaveDialog.DefaultExt = "a3ml";
            this.configSaveDialog.Title = "Save config";
            // 
            // btnCfgLoad
            // 
            this.btnCfgLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCfgLoad.Location = new System.Drawing.Point(713, 424);
            this.btnCfgLoad.Name = "btnCfgLoad";
            this.btnCfgLoad.Size = new System.Drawing.Size(75, 23);
            this.btnCfgLoad.TabIndex = 15;
            this.btnCfgLoad.Text = "Load config";
            this.btnCfgLoad.UseVisualStyleBackColor = true;
            this.btnCfgLoad.Click += new System.EventHandler(this.btnCfgLoad_Click);
            // 
            // configLoadDialog
            // 
            this.configLoadDialog.DefaultExt = "a3ml";
            this.configLoadDialog.Title = "Load config";
            // 
            // btnSaveParamsFile
            // 
            this.btnSaveParamsFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveParamsFile.Location = new System.Drawing.Point(489, 395);
            this.btnSaveParamsFile.Name = "btnSaveParamsFile";
            this.btnSaveParamsFile.Size = new System.Drawing.Size(106, 23);
            this.btnSaveParamsFile.TabIndex = 16;
            this.btnSaveParamsFile.Text = "Params (file)";
            this.btnSaveParamsFile.UseVisualStyleBackColor = true;
            this.btnSaveParamsFile.Click += new System.EventHandler(this.btnSaveParamsFile_Click);
            // 
            // paramSaveDialog
            // 
            this.paramSaveDialog.DefaultExt = "txt";
            this.paramSaveDialog.Title = "Save params";
            // 
            // loadCfgFromHtml
            // 
            this.loadCfgFromHtml.Location = new System.Drawing.Point(602, 424);
            this.loadCfgFromHtml.Name = "loadCfgFromHtml";
            this.loadCfgFromHtml.Size = new System.Drawing.Size(105, 23);
            this.loadCfgFromHtml.TabIndex = 17;
            this.loadCfgFromHtml.Text = "Load HTML Config";
            this.loadCfgFromHtml.UseVisualStyleBackColor = true;
            this.loadCfgFromHtml.Click += new System.EventHandler(this.loadCfgFromHtml_Click);
            // 
            // htmlDialog
            // 
            this.htmlDialog.DefaultExt = "html";
            this.htmlDialog.Title = "Load HTML config";
            // 
            // serverBox
            // 
            this.serverBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverBox.Location = new System.Drawing.Point(15, 55);
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(759, 20);
            this.serverBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server directory";
            // 
            // ModComposer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loadCfgFromHtml);
            this.Controls.Add(this.btnSaveParamsFile);
            this.Controls.Add(this.btnCfgLoad);
            this.Controls.Add(this.btnSaveParamsCb);
            this.Controls.Add(this.btnCfgSave);
            this.Controls.Add(this.mdsSelCnt);
            this.Controls.Add(this.mdsCntNmb);
            this.Controls.Add(this.mdsSelTxt);
            this.Controls.Add(this.mdCntTxt);
            this.Controls.Add(this.btnDiAll);
            this.Controls.Add(this.btnDiSel);
            this.Controls.Add(this.btnEnAll);
            this.Controls.Add(this.btnEnSel);
            this.Controls.Add(this.modList);
            this.Controls.Add(this.pathValidatorText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFolderBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverBox);
            this.Controls.Add(this.pathBox);
            this.Name = "ModComposer";
            this.Text = "Mod utils";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModComposer_FormClosing);
            this.Load += new System.EventHandler(this.ModComposer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.Button btnFolderBrowse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label pathValidatorText;
        private System.Windows.Forms.ListView modList;
        private System.Windows.Forms.ColumnHeader modName;
        private System.Windows.Forms.ColumnHeader modDirectory;
        private System.Windows.Forms.ColumnHeader isModEnabled;
        private System.Windows.Forms.Button btnEnSel;
        private System.Windows.Forms.Button btnEnAll;
        private System.Windows.Forms.Button btnDiSel;
        private System.Windows.Forms.Button btnDiAll;
        private System.Windows.Forms.Label mdCntTxt;
        private System.Windows.Forms.Label mdsCntNmb;
        private System.Windows.Forms.Label mdsSelTxt;
        private System.Windows.Forms.Label mdsSelCnt;
        private System.Windows.Forms.Button btnCfgSave;
        private System.Windows.Forms.Button btnSaveParamsCb;
        private System.Windows.Forms.SaveFileDialog configSaveDialog;
        private System.Windows.Forms.Button btnCfgLoad;
        private System.Windows.Forms.OpenFileDialog configLoadDialog;
        private System.Windows.Forms.Button btnSaveParamsFile;
        private System.Windows.Forms.SaveFileDialog paramSaveDialog;
        private System.Windows.Forms.Button loadCfgFromHtml;
        private System.Windows.Forms.OpenFileDialog htmlDialog;
        private System.Windows.Forms.TextBox serverBox;
        private System.Windows.Forms.Label label2;
    }
}

