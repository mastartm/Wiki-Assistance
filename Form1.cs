using System.Diagnostics;

namespace wiki_bilgi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Python'u çalýþtýrýyoruz (Kelimeyi TextBox'tan alýyoruz)
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = "python";
                start.Arguments = $"wiki_bot.py \"{txtSearch.Text}\"";
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                start.CreateNoWindow = true;

                using (Process process = Process.Start(start))
                {
                    process.WaitForExit(); // Python'un yazmasýný bekle
                }

                // --- ÝÞTE TEST EDECEÐÝMÝZ KISIM ---
                if (File.Exists("bilgi.txt"))
                {
                    string ozet = File.ReadAllText("bilgi.txt");
                    rtbResult.Text = ozet; // RichTextBox'a yazdýr
                }
                else
                {
                    rtbResult.Text = "Hata: Python dosyayý oluþturamadý!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluþtu: " + ex.Message);
            }
        }
    }
}
