using System;
using System.Windows.Forms;

namespace KeyEventLogger;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        KeyPreview = true;

        KeyDown += MainForm_KeyDown;
        KeyUp += MainForm_KeyUp;
        KeyPress += MainForm_KeyPress;
        btnClear.Click += btnClear_Click;
    }

    private void MainForm_KeyDown(object? sender, KeyEventArgs e)
    {
        lblLastKey.Text = "Son Basılan Tuş: " + e.KeyCode;
        AddRecord("KeyDown", e.KeyCode.ToString());
    }

    private void MainForm_KeyUp(object? sender, KeyEventArgs e)
    {
        AddRecord("KeyUp", e.KeyCode.ToString());
    }

    private void MainForm_KeyPress(object? sender, KeyPressEventArgs e)
    {
        string character = char.IsControl(e.KeyChar) ? $"[Kontrol: {(int)e.KeyChar}]" : e.KeyChar.ToString();
        AddRecord("KeyPress", character);
    }

    private void AddRecord(string eventType, string keyName)
    {
        KeyEventRecord record = new KeyEventRecord(eventType, keyName, DateTime.Now);
        lstEvents.Items.Add(record);
        lstEvents.TopIndex = lstEvents.Items.Count - 1;
    }

    private void btnClear_Click(object? sender, EventArgs e)
    {
        lstEvents.Items.Clear();
        lblLastKey.Text = "Son Basılan Tuş: (Temizlendi)";
    }
}
