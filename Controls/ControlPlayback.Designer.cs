namespace VTKViewer.Controls
{
  partial class ControlPlayback
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.cmdFirst = new System.Windows.Forms.Button();
      this.cmdPrev = new System.Windows.Forms.Button();
      this.cmdPlayPause = new System.Windows.Forms.Button();
      this.cmdNext = new System.Windows.Forms.Button();
      this.cmdLast = new System.Windows.Forms.Button();
      this.txtCurr = new System.Windows.Forms.TextBox();
      this.trackBar1 = new System.Windows.Forms.TrackBar();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 6;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.tableLayoutPanel1.Controls.Add(this.cmdLast, 4, 0);
      this.tableLayoutPanel1.Controls.Add(this.cmdNext, 3, 0);
      this.tableLayoutPanel1.Controls.Add(this.cmdPlayPause, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.cmdPrev, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.cmdFirst, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.txtCurr, 5, 0);
      this.tableLayoutPanel1.Controls.Add(this.trackBar1, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(677, 65);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // cmdFirst
      // 
      this.cmdFirst.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cmdFirst.Location = new System.Drawing.Point(3, 3);
      this.cmdFirst.Name = "cmdFirst";
      this.cmdFirst.Size = new System.Drawing.Size(106, 39);
      this.cmdFirst.TabIndex = 0;
      this.cmdFirst.Text = "|<<";
      this.cmdFirst.UseVisualStyleBackColor = true;
      this.cmdFirst.Click += new System.EventHandler(this.cmdFirst_Click);
      // 
      // cmdPrev
      // 
      this.cmdPrev.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cmdPrev.Location = new System.Drawing.Point(115, 3);
      this.cmdPrev.Name = "cmdPrev";
      this.cmdPrev.Size = new System.Drawing.Size(106, 39);
      this.cmdPrev.TabIndex = 1;
      this.cmdPrev.Text = "<<";
      this.cmdPrev.UseVisualStyleBackColor = true;
      this.cmdPrev.Click += new System.EventHandler(this.cmdPrev_Click);
      // 
      // cmdPlayPause
      // 
      this.cmdPlayPause.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cmdPlayPause.Location = new System.Drawing.Point(227, 3);
      this.cmdPlayPause.Name = "cmdPlayPause";
      this.cmdPlayPause.Size = new System.Drawing.Size(106, 39);
      this.cmdPlayPause.TabIndex = 2;
      this.cmdPlayPause.Text = "|>";
      this.cmdPlayPause.UseVisualStyleBackColor = true;
      this.cmdPlayPause.Click += new System.EventHandler(this.cmdPlayPause_Click);
      // 
      // cmdNext
      // 
      this.cmdNext.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cmdNext.Location = new System.Drawing.Point(339, 3);
      this.cmdNext.Name = "cmdNext";
      this.cmdNext.Size = new System.Drawing.Size(106, 39);
      this.cmdNext.TabIndex = 3;
      this.cmdNext.Text = ">>";
      this.cmdNext.UseVisualStyleBackColor = true;
      this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
      // 
      // cmdLast
      // 
      this.cmdLast.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cmdLast.Location = new System.Drawing.Point(451, 3);
      this.cmdLast.Name = "cmdLast";
      this.cmdLast.Size = new System.Drawing.Size(106, 39);
      this.cmdLast.TabIndex = 4;
      this.cmdLast.Text = ">>|";
      this.cmdLast.UseVisualStyleBackColor = true;
      this.cmdLast.Click += new System.EventHandler(this.cmdLast_Click);
      // 
      // txtCurr
      // 
      this.txtCurr.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtCurr.Location = new System.Drawing.Point(563, 3);
      this.txtCurr.Multiline = true;
      this.txtCurr.Name = "txtCurr";
      this.txtCurr.Size = new System.Drawing.Size(111, 39);
      this.txtCurr.TabIndex = 5;
      this.txtCurr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // trackBar1
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.trackBar1, 6);
      this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.trackBar1.Location = new System.Drawing.Point(3, 48);
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new System.Drawing.Size(671, 14);
      this.trackBar1.TabIndex = 6;
      this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
      // 
      // ControlPlayback
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "ControlPlayback";
      this.Size = new System.Drawing.Size(677, 65);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button cmdLast;
    private System.Windows.Forms.Button cmdNext;
    private System.Windows.Forms.Button cmdPlayPause;
    private System.Windows.Forms.Button cmdPrev;
    private System.Windows.Forms.Button cmdFirst;
    private System.Windows.Forms.TextBox txtCurr;
    private System.Windows.Forms.TrackBar trackBar1;
  }
}
