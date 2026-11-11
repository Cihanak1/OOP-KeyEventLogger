using System.Windows.Forms;

namespace KeyEventLogger;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        KeyPreview = true;
    }
}
