using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VTKViewer.Interfaces;
using VTKViewer.Model;

namespace VTKViewer.Controls
{
  public partial class ControlGraph : UserControl, IParallelRenderer
  {
    public ControlGraph()
    {
      InitializeComponent();
    }
    
    public ParallelUnstructuredModel Model { get; set; }

    public PointF Point { get; set; }

    public void InitializeFrom(ParallelUnstructuredModel model)
    {
      InitializeFrom(model, model.Dimensions.Bounds.Location);
    }

    public void InitializeFrom(ParallelUnstructuredModel model, PointF location)
    {
      Model = model;

      if (backgroundWorker1.IsBusy) return;
      progressBar1.Visible = true;
      backgroundWorker1.RunWorkerAsync(location);      
    }
    

    public void  DisplayPoint(PointF point)
    {
      
      Point = point;
      txtX.Text = point.X.ToString();
      txtY.Text = point.Y.ToString();

      singleResult1.CSVResult = Model.GetCsvFor(point);

    }

    public void CleanUp()
    {
      
    }

    private void OnUpdateClick(object sender, EventArgs e)
    {
      float x, y;
      if (float.TryParse(txtX.Text, out x) && float.TryParse(txtY.Text, out y))
        DisplayPoint(new PointF(x, y));
    }

    private void OnDoWork(object sender, DoWorkEventArgs e)
    {
      var location = (PointF) e.Argument;
      for (int i = 0; i < Model.Files.Count; i++)
      {
        Model.Files[i].Resolve();
        backgroundWorker1.ReportProgress((int)(((double)i / (double)Model.Files.Count)*100f));
      }
      e.Result = location;
    }

    private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressBar1.Value = e.ProgressPercentage;
    }

    private void OnWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      progressBar1.Visible = false;
      DisplayPoint((PointF)e.Result);
    }
  }
}
