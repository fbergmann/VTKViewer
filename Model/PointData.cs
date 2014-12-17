using System;
using System.Collections.Generic;
using Kitware.VTK;

namespace VTKViewer.Model
{
  public class PointData
  {
    public string Name { get; set; }
    public double[] Data { get; set; }

    public double Min { get; set;  }
    public double Max { get; set;  }

    public DimensionDescription DimensionDescription { get; set; }

    public static PointData FromArray(vtkFloatArray array)
    {
      var result = new PointData { Name = array.GetName(), Data = new double[array.GetNumberOfTuples()] };
      for (var i = 0; i < array.GetNumberOfTuples(); i++)
      {
        result.Data[i] = array.GetTuple1(i);
        result.Min = Math.Min(result.Min, result.Data[i]);
        result.Max = Math.Max(result.Max, result.Data[i]);
      }
      return result;
    }

    public override string ToString()
    {
      return string.Format("{0}: {1} Point(s)", Name, Data == null ? 0 :  Data.Length);
    }

  }
}
