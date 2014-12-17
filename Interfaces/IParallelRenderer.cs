using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTKViewer.Model;

namespace VTKViewer.Interfaces
{
  interface IParallelRenderer
  {
    ParallelUnstructuredModel Model { get; set; }

    void InitializeFrom(ParallelUnstructuredModel model);

    void CleanUp();
  }
}
