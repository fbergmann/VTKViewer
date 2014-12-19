using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Compare.DataTypes;
using Kitware.VTK;

namespace VTKViewer.Model
{
  public class ParallelUnstructuredModel
  {
    public string  CurrentVariable { get; set;}
    public List<UnstructuredModel> Files { get; set; }
    public UnstructuredModel Current { get; set; }

    public RectangleF Bounds
    {
      get
      {
       return Dimensions.Bounds;
      }
    }

    public DimensionDescription Dimensions
    {
      get { 
        var current = Current ?? Files.FirstOrDefault();
        if (current == null) return new DimensionDescription();
        return current.Dimensions;
      }
    }

    public string[] Variables
    {
      get 
      { 
      
        if (Current == null) return new string[0];

        return Current.Variables;

      }
    }

    
    public ResultSet GetCsvFor(PointF point)
    {      

      var headers = new List<string> {"Time"};
      headers.AddRange(Variables); 
      
      var data = new double[Files.Count, headers.Count];

      for (int i = 0; i < Files.Count; i++)
      {
        var item = Files[i];
        data[i, 0] = item.Time;
        var row = item.GetValuesAt(point);
        for (int j = 0; j < row.Count; ++j)
          data[i, 1 + j] = row[j];
      }

      var result = new ResultSet(headers, data);
      
      return result;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ParallelUnstructuredModel"/> class.
    /// </summary>
    public ParallelUnstructuredModel()
    {
      Files = new List<UnstructuredModel>();
      Current = null;
    }

    public static ParallelUnstructuredModel FromFile(string fileName)
    {
      var result = new ParallelUnstructuredModel();

      if (fileName.ToLowerInvariant().EndsWith(".pvd"))
      {
        var element = XElement.Load(fileName);
        var collection = element.Element("Collection");

        if (collection == null) return result;

        var sets = collection.Elements("DataSet");

        foreach (var entry in sets)
        {
          double time;
          double.TryParse((string)entry.Attribute("timestep"), out time);
          string file = (string)entry.Attribute("file");

          var model = UnstructuredModel.FromFile(Path.Combine(Path.GetDirectoryName(fileName), file), time);
          result.Files.Add(model);
        }
      }
      else
      {
        var model = UnstructuredModel.FromFile(fileName, 0);
        result.Files.Add(model);
      }

      if (result.Files.Any())
        result.Current = result.Files[0];

      return result;

    }
  }
}
