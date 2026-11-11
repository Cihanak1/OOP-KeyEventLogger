using System;
using System.IO;
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
        btnSave.Click += btnSave_Click;
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
        lstEvents.Focus();
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (lstEvents.Items.Count == 0)
        {
            MessageBox.Show("Kaydedilecek tuş kaydı bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lstEvents.Focus();
            return;
        }

        using (SaveFileDialog saveDialog = new SaveFileDialog())
        {
            saveDialog.Filter = "Metin Dosyası (*.txt)|*.txt";
            saveDialog.Title = "Tuş Kayıtlarını Kaydet";
            saveDialog.FileName = "tus_kayitlari.txt";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                    {
                        foreach (var item in lstEvents.Items)
                        {
                            writer.WriteLine(item.ToString());
                        }
                    }

                    MessageBox.Show("Kayıtlar kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya kaydedilemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        lstEvents.Focus();
    }
}
