using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kitware.VTK;
using LibEditSpatial.Model;

namespace VTKViewer.Model
{
  public class UnstructuredModel
  {
    private List<PointData> _Data;
    private DimensionDescription _Desc;
    bool IsResolved { get; set; }

    public DimensionDescription Dimensions
    {
      get { return _Desc; }
    }
    public double Time { get; set; }
    public string FileName { get; set; }

    public string[] Variables
    {
      get
      {
        if (_Data == null || _Data.Count == 0)
          Resolve();
        return _Data.Select(pd => pd.Name).ToArray(); 
      }
    }

    public int SelectedIndex { get; set; }

    public string SelectedVariable
    {
      get { return Variables[SelectedIndex]; }
      set {
        var values = Variables;
        for (int i = 0; i < values.Length; i++)
        {
          if (values[i] == value)
            SelectedIndex = i;
        }        
      }
    }

    public double Min
    {
      get { return _Data[SelectedIndex].Min; }
    }

    public double Max
    {
      get { return _Data[SelectedIndex].Max; }
    }

    public List<double> GetValuesAt(PointF point)
    {
      Resolve();

      List<double> result = new List<double>();

      var index = _Desc.GetIndexFor(point);
      if (index == -1) return result;

      var x = _Desc.Coordinates[index, 0];
      var y = _Desc.Coordinates[index, 1];

      foreach (var item in _Data)
        result.Add(item.Data[index]);

      return result;
    }
    public DmpModel ToDmp()
    {
      Resolve();

      int numCoords = _Desc.Coordinates.GetLength(0)-1;
      int numRows = (int)_Desc.Coordinates[numCoords, 2] + 1;
      int numCols = (int)_Desc.Coordinates[numCoords, 3] + 1;

      var result = new DmpModel(numRows, numCols) 
      { 
        Min = Min, 
        Max = Max, 
        MinX = _Desc.MinX,
        MaxX = _Desc.MaxX,
        MinY = _Desc.MinY,
        MaxY = _Desc.MaxY,          
      };

      var current = _Data[SelectedIndex];

      for (int i = 0; i < current.Data.Length; i++)
      {
        double x = _Desc.Coordinates[i, 2];
        double y = _Desc.Coordinates[i, 3];

        result[(int)x, (int)y] = current.Data[i];
      }
        
      return result;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="UnstructuredModel"/> class.
    /// </summary>
    public UnstructuredModel()
    {
      _Data = new List<PointData>();
      _Desc = new DimensionDescription();
      Time = 0d;
      FileName = String.Empty;
    }

    public void Resolve()
    {
      if (IsResolved) return;

        if (FileName.ToLowerInvariant().EndsWith(".pvtu"))
        {
          var reader = vtkXMLPUnstructuredGridReader.New();
          reader.SetFileName(FileName);
          reader.Update();
          var model = FromReader(reader);
          _Data = model._Data;
          _Desc = model._Desc;
        }
        else if (FileName.ToLowerInvariant().EndsWith(".vtu"))
        {
          var reader = vtkXMLUnstructuredGridReader.New();
          reader.SetFileName(FileName);
          reader.Update();

          var output = reader.GetOutput();
          var model = FromGrid(output, reader.GetNumberOfPointArrays());
          _Data = model._Data;
          _Desc = model._Desc;
        }
    
      IsResolved = true;

    }

    public static UnstructuredModel FromFile(string filename, double time = 0d, bool resolve = false)
    {
      var result = new UnstructuredModel { FileName = filename, Time = time };

      if (!resolve)
        return result;

      result.Resolve();

      return result;
    }

    public static UnstructuredModel FromGrid(vtkUnstructuredGrid output, int numArrays)
    {
      var result = new UnstructuredModel
      { 
        _Desc = DimensionDescription.FromPoints(output.GetPoints()), 
        _Data = new List<PointData>() 
      };

      for (var i = 0; i < numArrays; ++i)
      {
        var pdata = PointData.FromArray((vtkFloatArray)output.GetPointData().GetArray(i));
        pdata.DimensionDescription = result._Desc;
        result._Data.Add(pdata);
      }

      return result;
    }

    public static UnstructuredModel FromReader(vtkXMLPUnstructuredGridReader reader)
    {
      return FromGrid(reader.GetOutput(0), reader.GetNumberOfPointArrays());
    }

  }
}
