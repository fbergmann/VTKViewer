using System;
using System.Windows.Forms;

namespace VTKViewer.Controls
{
  public partial class ControlPlayback : UserControl
  {

    public event EventHandler<int> PositionChanged;
    public event EventHandler<bool> PlaybackChanged;

    protected virtual void OnPlaybackChanged(bool e)
    {
      var handler = PlaybackChanged;
      if (handler != null) handler(this, e);
    }

    protected virtual void OnPositionChanged(int e)
    {
      trackBar1.Value = e;
      var handler = PositionChanged;
      if (handler != null) handler(this, e);
    }

    public ControlPlayback()
    {
      InitializeComponent();

      txtCurr.DataBindings.Add("Text", trackBar1, "Value");

    }

    public void InitializeRange(int min, int max)
    {
      trackBar1.Minimum = min;
      trackBar1.Maximum = max;
      
    }

    private void cmdFirst_Click(object sender, EventArgs e)
    {
      OnPositionChanged(trackBar1.Minimum);
    }

    private void cmdPrev_Click(object sender, EventArgs e)
    {
      if (trackBar1.Value -1 < trackBar1.Minimum)
        OnPositionChanged(trackBar1.Minimum);
      else
        OnPositionChanged(trackBar1.Value-1);
    }

    public void Next()
    {
      if (trackBar1.Value + 1 > trackBar1.Maximum)
        OnPositionChanged(trackBar1.Maximum);
      else
        OnPositionChanged(trackBar1.Value + 1);
    }
    private void cmdNext_Click(object sender, EventArgs e)
    {
      Next();
    }

    private void cmdLast_Click(object sender, EventArgs e)
    {
      OnPositionChanged(trackBar1.Maximum);
    }

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
      OnPositionChanged(trackBar1.Value);
    }

    private void cmdPlayPause_Click(object sender, EventArgs e)
    {
      if (cmdPlayPause.Text == "|>")
      {
        cmdPlayPause.Text = "||";
      }
      else
      {
        cmdPlayPause.Text = "|>";
      }

      OnPlaybackChanged(cmdPlayPause.Text == "||");

    }



  }
}
