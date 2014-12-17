namespace VTKViewer.Controls
{
  partial class ControlGraph
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.singleResult1 = new ZedCompareData.SingleResult();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.cmdUpdate = new System.Windows.Forms.Button();
      this.txtY = new System.Windows.Forms.TextBox();
      this.txtX = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // singleResult1
      // 
      this.singleResult1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.singleResult1.Location = new System.Drawing.Point(3, 40);
      this.singleResult1.Name = "singleResult1";
      this.singleResult1.Size = new System.Drawing.Size(639, 411);
      this.singleResult1.TabIndex = 0;
      this.singleResult1.YTitel = "Concentration(s)";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.singleResult1, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(645, 454);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.progressBar1);
      this.panel1.Controls.Add(this.cmdUpdate);
      this.panel1.Controls.Add(this.txtY);
      this.panel1.Controls.Add(this.txtX);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(639, 31);
      this.panel1.TabIndex = 1;
      // 
      // cmdUpdate
      // 
      this.cmdUpdate.Location = new System.Drawing.Point(218, 4);
      this.cmdUpdate.Name = "cmdUpdate";
      this.cmdUpdate.Size = new System.Drawing.Size(75, 23);
      this.cmdUpdate.TabIndex = 3;
      this.cmdUpdate.Text = "Update";
      this.cmdUpdate.UseVisualStyleBackColor = true;
      this.cmdUpdate.Click += new System.EventHandler(this.OnUpdateClick);
      // 
      // txtY
      // 
      this.txtY.Location = new System.Drawing.Point(156, 6);
      this.txtY.Name = "txtY";
      this.txtY.Size = new System.Drawing.Size(56, 20);
      this.txtY.TabIndex = 2;
      // 
      // txtX
      // 
      this.txtX.Location = new System.Drawing.Point(91, 6);
      this.txtX.Name = "txtX";
      this.txtX.Size = new System.Drawing.Size(59, 20);
      this.txtX.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(82, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Selected Point: ";
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.WorkerReportsProgress = true;
      this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnDoWork);
      this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OnProgressChanged);
      this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnWorkerCompleted);
      // 
      // progressBar1
      // 
      this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.progressBar1.Location = new System.Drawing.Point(299, 4);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(337, 23);
      this.progressBar1.TabIndex = 4;
      this.progressBar1.Visible = false;
      // 
      // ControlGraph
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "ControlGraph";
      this.Size = new System.Drawing.Size(645, 454);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private ZedCompareData.SingleResult singleResult1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox txtY;
    private System.Windows.Forms.TextBox txtX;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button cmdUpdate;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.ProgressBar progressBar1;

  }
}
