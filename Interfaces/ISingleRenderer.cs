using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VTKViewer.Model;

namespace VTKViewer.Interfaces
{
  interface ISingleRenderer
  {
    UnstructuredModel Model { get; set; }

    void DisplayModel(UnstructuredModel model);
    
    void CleanUp();
  }
}