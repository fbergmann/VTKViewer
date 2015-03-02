using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compare.DataTypes;
using VTKViewer.Interfaces;
using VTKViewer.Model;

namespace VTKViewer.Controls
{
  public partial class ControlGraph : UserControl, IParallelRenderer
  {
    public ControlGraph()
    {
      _ProgressBar = null;
      InitializeComponent();
    }
    
    public ParallelUnstructuredModel Model { get; set; }

    public PointF Point { get; set; }

    public void InitializeFrom(ParallelUnstructuredModel model)
    {
      InitializeFrom(model, model.Dimensions.Bounds.Location);
    }

    private ToolStripProgressBar _ProgressBar;
    public ToolStripProgressBar ProgressBar
    {
      get
      {
        return _ProgressBar;
      }
      set
      {
        _ProgressBar = value;
      }
    }

    public void InitializeFrom(ParallelUnstructuredModel model, PointF location)
    {
      Model = model;

      if (initializeWorker.IsBusy) return;
      if (_ProgressBar != null) _ProgressBar.Visible = true;
      
      initializeWorker.RunWorkerAsync(location);      
    }
    

    public void  DisplayPoint(PointF point)
    {
      if (initializeWorker.IsBusy) return;
      if (displayWorker.IsBusy) return;

      displayWorker.RunWorkerAsync(point);

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
        initializeWorker.ReportProgress((int)(((double)i / (double)Model.Files.Count)*100f));
      }
      e.Result = location;
    }

    private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      if (_ProgressBar == null || _ProgressBar.IsDisposed) return;

      _ProgressBar.Value = e.ProgressPercentage;
    }

    private void OnWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (_ProgressBar != null)
        _ProgressBar.Visible = false;
      DisplayPoint((PointF)e.Result);
    }

    private void OnResolvePoint(object sender, DoWorkEventArgs e)
    {
      var point = (PointF)e.Argument;
      e.Result = Model.GetCsvFor(point);
      Point = point;
    }

    private void OnResolvePointCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Result == null || Model.Dimensions == null) return;
      var isMultiple = singleResult1.IsExploded;
      singleResult1.CSVResult = (ResultSet) e.Result;
      txtX.Text = Point.X.ToString();
      txtY.Text = Point.Y.ToString();
      var index = Model.Dimensions.GetIndexFor(Point);
      if (index != -1)
      {
        var x = Model.Dimensions.Coordinates[index, 0];
        var y = Model.Dimensions.Coordinates[index, 1];
        singleResult1.Graph.GraphPane.Title.Text = string.Format("Values for Pos: {0},{1}", x, y);
        singleResult1.Graph.GraphPane.Title.IsVisible = true;
      }

      if (singleResult1.IsExploded != isMultiple)
        singleResult1.ToggleExplode();

    }
  }
}
