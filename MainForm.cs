﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Kitware.VTK;
using LibEditSpatial.Model;
using VTKViewer.Interfaces;
using VTKViewer.Model;

namespace VTKViewer
{
  public partial class MainForm : Form
  {

    ParallelUnstructuredModel Model { get; set; }

    public String[] PaletteFiles { get; set; }

    public string CurrentPalette { get; set; }

    internal DmpPalette Default { get; set; }

    ISingleRenderer CurrentRenderer 
    {
      get
      {
        if (tabControl1.SelectedIndex == 1)
          return (ISingleRenderer) controlVTK1;
        if (tabControl1.SelectedIndex == 0)
          return (ISingleRenderer)controlDmp1;
        return null;
      }
    }

    public PointF SelectedPoint { get; set;  }


    public MainForm()
    {
      InitializeComponent();

      controlGraph1.ProgressBar = toolStripProgressBar1;

      Model = new ParallelUnstructuredModel();
      SelectedPoint = Model.Bounds.Location;

      controlPlayback1.PositionChanged += (o, v) => DisplayEntry(v);
      controlPlayback1.PlaybackChanged += (o, v) => timer1.Enabled = v;

      controlDmp1.DmpControl.DataLocationChanged += (o, e) => 
      {
        if (ModifierKeys == Keys.Shift)
        { 
          SelectedPoint = e;
          lblPos.Text = string.Format("X: {0} Y: {1}", e.X, e.Y);
          if (controlGraph1.Model == Model) 
          controlGraph1.DisplayPoint(SelectedPoint);
        }
      };
      
      txtTicks.Text = timer1.Interval.ToString();

    }

    public void OpenFile(string filename)
    {
      timer1.Enabled = false;
      Model = ParallelUnstructuredModel.FromFile(filename);
      SelectedPoint = Model.Bounds.Location;
      cmbVariables.Items.Clear();
      cmbVariables.Items.AddRange(Model.Variables);
      if (cmbVariables.Items.Count > 0)
        cmbVariables.SelectedItem = cmbVariables.Items[0];
      controlGraph1.InitializeFrom(Model, SelectedPoint);
      OnPaletteChanged(this, EventArgs.Empty);
      UpdateUI();
    }

    private void OnOpenClick(object sender, EventArgs e)
    {

      using (var dialog = new OpenFileDialog
      {
        AutoUpgradeEnabled = true,
        Filter = "PVD files|*.pvd|VTU files|*.vtu;*.pvtu|All files|*.*"
      })
      {
        if (dialog.ShowDialog() == DialogResult.OK)
        {
          OpenFile(dialog.FileName);
        }
      }

    }

    private void DisplayEntry(int index)
    {
      if (Model == null || Model.Files == null || index < 0 || Model.Files.Count == 0) return;

      if (index >= Model.Files.Count)
        index = Model.Files.Count - 1;

      DisplayEntry(Model.Files[index]);
    }

    private void DisplayEntry(UnstructuredModel entry)
    {
      if (entry == null) return;

      entry.SelectedVariable = Model.CurrentVariable;
      Model.Current = entry;

      lblMessage.Text = string.Format("{0}", Model.Current.Time);

      var current = CurrentRenderer;
      if (current == null) return;

      current.DisplayModel(entry);
    }


    private void UpdateUI()
    {
      if (Model.Current == null || string.IsNullOrEmpty(Model.Current.FileName)) return;

      controlPlayback1.Visible = (Model.Files.Count > 0) ;
      controlPlayback1.InitializeRange(0, Model.Files.Count);

      DisplayEntry(Model.Current);
 
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
      controlPlayback1.Next();
    }
    
    private void NewModel()
    {      
      timer1.Enabled = false;
      Model = new ParallelUnstructuredModel();
      UpdateUI();
    }

    private void OnNewClick(object sender, EventArgs e)
    {
      NewModel();
    }

    private void OnTicksChanged(object sender, EventArgs e)
    {
      int interval;
      if (!int.TryParse(txtTicks.Text, out interval)) return;
      timer1.Interval = interval;
    }

    private void OnExitClick(object sender, EventArgs e)
    {
      Close();
    }

    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
      timer1.Enabled = false;
    }

    private void OnVariableChanged(object sender, EventArgs e)
    {
      Model.CurrentVariable = cmbVariables.SelectedItem as string;
      
      DisplayEntry(Model.Current);
    }

    private void OnTabPageChanged(object sender, EventArgs e)
    {
      if (tabControl1.SelectedIndex >= 2) return;
      
      DisplayEntry(Model.Current);
    }

    private void OnPaletteChanged(object sender, EventArgs e)
    {
      int index = cmbPalettes.SelectedIndex;

      if (index < 0) return;

      if ((string)cmbPalettes.Items[index] == CurrentPalette)
        return;

      if (index == 0)
      {
        DmpPalette.Default = Default;
        //ctrlPalette1.ChangePalette(DmpPalette.Default);
      }
      else
        try
        {
          DmpPalette.Default = DmpPalette.FromFile(PaletteFiles[index - 1]);          
        }
        catch
        {
        }
      CurrentPalette = (string)cmbPalettes.Items[index];
      DisplayEntry(Model.Current);
    }

    private void LoadPalettes(string baseDirectory)
    {
      PaletteFiles = Directory.GetFiles(baseDirectory, "*.txt", SearchOption.TopDirectoryOnly);
      cmbPalettes.Items.Clear();
      cmbPalettes.Items.Add("Default");
      foreach (string file in PaletteFiles)
      {
        cmbPalettes.Items.Add(Path.GetFileNameWithoutExtension(file));
      }
      cmbPalettes.SelectedText = "Default";
    }

    private void OnLoad(object sender, EventArgs e)
    {
      Default = DmpPalette.Default;
      //ctrlPalette1.Palette = DmpPalette.Default;

      LoadPalettes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Palettes"));
    }

    private void OnExportDmpClick(object sender, EventArgs e)
    {
      var dir = LibEditSpatial.Util.GetDir(null);
      for (int i = 0; i < Model.Variables.Length; i++)
      {
        var current = Path.Combine(dir, string.Format("conc_{0}.dmp", Model.Variables[i]));
        var dmp = Model.Current.ToDmp(i);
        dmp.SaveAs(current);
      }
    }

    #region Drag / Drop

    private void MainForm_DragDrop(object sender, DragEventArgs e)
    {
      try
      {
        var sFilenames = (string[])e.Data.GetData(DataFormats.FileDrop);
        var oInfo = new FileInfo(sFilenames[0]);
        if (oInfo.Extension.ToLower() == ".pvd" || oInfo.Extension.ToLower() == ".vtu")
        {
          OpenFile(sFilenames[0]);
        }
      }
      catch (Exception)
      {
      }
    }

    private void MainForm_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        var sFilenames = (string[])e.Data.GetData(DataFormats.FileDrop);
        var oInfo = new FileInfo(sFilenames[0]);
        if (oInfo.Extension.ToLower() == ".pvd" || oInfo.Extension.ToLower() == ".vtu")
        {
          e.Effect = DragDropEffects.Copy;
          return;
        }
      }
      e.Effect = DragDropEffects.None;
    }

    #endregion

  }
}
