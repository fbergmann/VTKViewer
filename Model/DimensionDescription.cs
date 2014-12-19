using System;
using System.Collections.Generic;
using System.Drawing;
using Kitware.VTK;

namespace VTKViewer.Model
{

  public class DimensionDescription
  {
    public double MinX { get; set; }
    public double MaxX { get; set; }
    public double MinY { get; set; }
    public double MaxY { get; set; }
    double DistanceX { get; set;  }
    double DistanceY { get; set;  }
    public double[,] Coordinates { get; set; }


    /// <summary>
    /// Initializes a new instance of the <see cref="DimensionDescription"/> class.
    /// </summary>
    public DimensionDescription()
    {
      MinX = 0d;
      MaxX = 0d;
      MinY = 0d;
      MaxY = 0d;
      Coordinates = new double[0,0];
    }

    public RectangleF Bounds 
    {
      get { 
        return new RectangleF(
        (float)MinX, (float)MinY, 
        (float)(MaxX - MinX), (float)(MaxY - MinY)
        ); 
      }
    }

    public static DimensionDescription FromPoints(vtkPoints points)
    {
      if (points == null) return null;

      var bounds = points.GetBounds();
      var numPoints = points.GetNumberOfPoints();
      var result = new DimensionDescription
      {
        MinX = bounds[0],
        MaxX = bounds[1],
        MinY = bounds[2],
        MaxY = bounds[3],
        Coordinates = new double[numPoints, 4]
      };

      var xIndices = new List<double>();
      var yIndices = new List<double>();

      for (var i = 0; i < numPoints; i++)
      {
        var current = points.GetPoint(i);
        if (!xIndices.Contains(current[0]))
          xIndices.Add(current[0]);
        if (!yIndices.Contains(current[1]))
          yIndices.Add(current[1]);
      }

      xIndices.Sort();
      yIndices.Sort();

      if (xIndices.Count > 0)
      result.DistanceX = xIndices[1]- xIndices[0];
      if (yIndices.Count > 0)
        result.DistanceY = yIndices[1] - yIndices[0];

      for (var i = 0; i < numPoints; i++)
      {
        var current = points.GetPoint(i);

        result.Coordinates[i, 0] = current[0];
        result.Coordinates[i, 1] = current[1];
        result.Coordinates[i, 2] = xIndices.IndexOf(current[0]);
        result.Coordinates[i, 3] = yIndices.IndexOf(current[1]);
      }

      return result;
    }

    public int GetIndexFor(PointF point)
    {
      for (int i = 0;i < Coordinates.GetLength(0); ++i)
        if (
          Math.Pow(Coordinates[i, 0] - point.X, 2)  +
          Math.Pow(Coordinates[i, 1] - point.Y, 2)
          < (DistanceX*DistanceY/2))
          return i;
      return -1;
    }
    public override string ToString()
    {
      return string.Format("Dim: [{0}..{1}]x[{2}..{3}]", MinX, MaxX, MinY, MaxY);
    }

  }
}
