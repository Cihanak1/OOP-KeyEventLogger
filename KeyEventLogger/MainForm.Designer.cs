namespace KeyEventLogger;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel panelTop;
    private Label lblStatus;
    private Label lblLastKey;
    private ListBox lstEvents;
    private Panel panelBottom;
    private Button btnClear;
    private Button btnSave;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelTop = new Panel();
        lblLastKey = new Label();
        lblStatus = new Label();
        lstEvents = new ListBox();
        panelBottom = new Panel();
        btnSave = new Button();
        btnClear = new Button();
        panelTop.SuspendLayout();
        panelBottom.SuspendLayout();
        SuspendLayout();

        // panelTop
        panelTop.Dock = DockStyle.Top;
        panelTop.Height = 70;
        panelTop.Controls.Add(lblLastKey);
        panelTop.Controls.Add(lblStatus);
        panelTop.Padding = new Padding(12);

        // lblStatus
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(12, 10);
        lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        lblStatus.Text = "Tuş olaylarını izlemek için pencereye tıklayıp klavyeyi kullanın.";

        // lblLastKey
        lblLastKey.AutoSize = true;
        lblLastKey.Location = new Point(12, 36);
        lblLastKey.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblLastKey.Text = "Son Basılan Tuş: (Henüz basılmadı)";

        // panelBottom
        panelBottom.Dock = DockStyle.Bottom;
        panelBottom.Height = 50;
        panelBottom.Controls.Add(btnSave);
        panelBottom.Controls.Add(btnClear);
        panelBottom.Padding = new Padding(10);

        // btnClear
        btnClear.Location = new Point(12, 10);
        btnClear.Size = new Size(120, 30);
        btnClear.Text = "Listeyi Temizle";
        btnClear.UseVisualStyleBackColor = true;

        // btnSave
        btnSave.Location = new Point(140, 10);
        btnSave.Size = new Size(150, 30);
        btnSave.Text = "Metin Dosyasına Kaydet";
        btnSave.UseVisualStyleBackColor = true;

        // lstEvents
        lstEvents.Dock = DockStyle.Fill;
        lstEvents.Font = new Font("Consolas", 9.5F, FontStyle.Regular);
        lstEvents.ItemHeight = 15;

        // MainForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(620, 420);
        Controls.Add(lstEvents);
        Controls.Add(panelTop);
        Controls.Add(panelBottom);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Key Event Logger";

        panelTop.ResumeLayout(false);
        panelTop.PerformLayout();
        panelBottom.ResumeLayout(false);
        ResumeLayout(false);
    }
}
