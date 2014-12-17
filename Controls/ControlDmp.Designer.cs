namespace VTKViewer.Controls
{
  partial class ControlDmp
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
      this.dmpRenderControl1 = new LibEditSpatial.Controls.DmpRenderControl();
      this.SuspendLayout();
      // 
      // dmpRenderControl1
      // 
      this.dmpRenderControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.dmpRenderControl1.CurrentValue = 10D;
      this.dmpRenderControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dmpRenderControl1.Location = new System.Drawing.Point(0, 0);
      this.dmpRenderControl1.Model = null;
      this.dmpRenderControl1.Name = "dmpRenderControl1";
      this.dmpRenderControl1.Padding = new System.Windows.Forms.Padding(5);
      this.dmpRenderControl1.PencilSize = 1;
      this.dmpRenderControl1.Size = new System.Drawing.Size(150, 150);
      this.dmpRenderControl1.TabIndex = 0;
      // 
      // ControlDmp
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.dmpRenderControl1);
      this.Name = "ControlDmp";
      this.ResumeLayout(false);

    }

    #endregion

    private LibEditSpatial.Controls.DmpRenderControl dmpRenderControl1;
  }
}
