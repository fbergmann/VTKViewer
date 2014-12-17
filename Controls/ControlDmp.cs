using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibEditSpatial.Controls;
using LibEditSpatial.Model;
using VTKViewer.Interfaces;
using VTKViewer.Model;

namespace VTKViewer.Controls
{
  public partial class ControlDmp : UserControl, ISingleRenderer
  {
    public DmpRenderControl DmpControl { get { return dmpRenderControl1; } }

    public ControlDmp()
    {
      InitializeComponent();
      dmpRenderControl1.LoadModel(new DmpModel(1, 1));
      dmpRenderControl1.DisableEditing = true;
    }

    public UnstructuredModel Model { get; set; }

    public DmpModel DmpModel { get; set;  }

    public void DisplayModel(UnstructuredModel model)
    {
      Model = model;
      DmpModel = model.ToDmp();
      dmpRenderControl1.LoadModel(DmpModel);
    }

    public void CleanUp()
    {
      
    }
  }
}
