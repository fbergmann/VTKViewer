using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VTKViewer
{
  internal static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      var form = new MainForm();
      
      foreach (var arg in args)
        if (File.Exists(arg))
        { 
          form.OpenFile(arg);
          break;
        }

      Application.Run(form);
    }
  }
}
