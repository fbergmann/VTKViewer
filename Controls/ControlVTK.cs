using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitware.VTK;
using VTKViewer.Interfaces;
using VTKViewer.Model;

namespace VTKViewer.Controls
{
  [DesignTimeVisible(false)]
  public partial class ControlVTK : UserControl, ISingleRenderer
  {

    public UnstructuredModel Model { get; set; }
    
    public void DisplayModel(UnstructuredModel model)
    {
      Model = model;

      if (IsParallel(model.FileName))
      {
        UpdateParallelRenderer(model.FileName);
      }
      else
      {
        UpdateRenderer(model.FileName);
      }

    }

    private static bool IsParallel(string lower)
    {
      return lower.EndsWith("pvtu") || lower.EndsWith("pvd");
    }


    public void CleanUp()
    {
      ClearActors();
    }


    public ControlVTK()
    {
      InitializeComponent();
    }       

    private void UpdateRenderer(string fileName)
    {
      ClearOnly();

      var reader = vtkXMLUnstructuredGridReader.New();
      reader.SetFileName(fileName);
      reader.UpdateInformation();

      var selection = reader.GetPointDataArraySelection();
      for (int i = 0; i < selection.GetNumberOfArrays(); ++i)
      {
        reader.SetPointArrayStatus(
          selection.GetArrayName(i), selection.GetArrayName(i) == Model.SelectedVariable ? 1 : 0);
      }
      reader.Update();
      
      var mapper = vtkDataSetMapper.New();
      mapper.SetInputConnection(reader.GetOutputPort());
      mapper.SetScalarRange(Model.Min, Model.Max);

      var actor = vtkActor.New();
      actor.SetMapper(mapper);

      var ren1 = renderWindowControl1.RenderWindow.
      GetRenderers().GetFirstRenderer();
      ren1.SetBackground(1, 1, 1);
      var renWin = renderWindowControl1.RenderWindow;

      ren1.AddViewProp(actor);

      renWin.Render();
      ren1.ResetCamera();
      renderWindowControl1.Invalidate();
    }

    private void UpdateParallelRenderer(string fileName)
    {
      ClearOnly();

      var reader = vtkXMLPUnstructuredGridReader.New();
      reader.SetFileName(fileName);
      reader.UpdateInformation();

      var selection = reader.GetPointDataArraySelection();
      for (int i = 0; i < selection.GetNumberOfArrays(); ++i)
      {
        string current = selection.GetArrayName(i);
        reader.SetPointArrayStatus(
          current, current == Model.SelectedVariable ? 1 : 0);
        //Debug.WriteLine(reader.GetPointArrayStatus(current));
      }
      reader.Update();

      var output = reader.GetOutput(0);
      output.GetPipelineInformation();
      output.Update();

      var mapper = vtkDataSetMapper.New();
      mapper.SetInput(output);
      mapper.SetScalarRange(Model.Min, Model.Max);

      var actor = vtkActor.New();
      actor.SetMapper(mapper);

      var ren1 = renderWindowControl1.RenderWindow.
      GetRenderers().GetFirstRenderer();
      ren1.SetBackground(1, 1, 1);
      var renWin = renderWindowControl1.RenderWindow;

      ren1.AddViewProp(actor);

      renWin.Render();
      ren1.ResetCamera();

      renderWindowControl1.Invalidate();
    }


    private vtkRenderer ClearOnly()
    {
      if (renderWindowControl1 == null || renderWindowControl1.RenderWindow == null)
        return null;
      var ren1 = renderWindowControl1.RenderWindow.
                  GetRenderers().GetFirstRenderer();

      var actors = ren1.GetActors();
      for (int i = actors.GetNumberOfItems() - 1; i >= 0; i--)
      {
        ren1.RemoveActor(actors.GetItemAsObject(i) as vtkProp);
      }
      ren1.Clear();
      return ren1;
    }

    private void ClearActors()
    {     
      vtkRenderer ren1 = ClearOnly();
      if (ren1 == null) return;
      var renWin = renderWindowControl1.RenderWindow;
      renWin.Render();
      ren1.ResetCamera();
      renderWindowControl1.Invalidate();
    }

    protected override void OnHandleCreated(EventArgs e)
    {
      try
      {
        base.OnHandleCreated(e);
      }
      catch (Exception exception)
      {
        
      }
    }

  }
}
