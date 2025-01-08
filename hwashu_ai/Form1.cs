using System.Text;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
namespace hwashu_ai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async Task ExecutePostRequestAsync()
        {
            // ��� TextBox ������J��
            string msg = TextMsg.Text;

            if (string.IsNullOrWhiteSpace(msg))
            {
                MessageBox.Show("�п�J���e!", "���~", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // API URL �M JSON ���
            string url = "http://localhost:3001/api/v1/workspace/hwashu_ai/chat";

            var jsonData = new
            {
                message = msg,
                mode = "query"
            };

            // �N JSON ��ƧǦC�Ƭ��r��
            string jsonString = JsonSerializer.Serialize(jsonData);
            using (HttpClient client = new())
            {
                // �]�w Timeout �� 5 ����
                client.Timeout = TimeSpan.FromMinutes(5);
                // �]�m���Y
                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer ART79RH-ASK4X8F-MRY83AZ-E25E7Y3");

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                CancellationTokenSource cts = new(); // �إߨ�������
                try
                {
                    // �Ұʰʵe
                    Task animationTask = StartAnimationAsync(cts.Token);

                    MsgLabel.Text = "...";
                    // �o�e POST �ШD
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        using JsonDocument doc = JsonDocument.Parse(responseBody);
                        var json = doc.RootElement.GetProperty("textResponse").GetString();
                        MsgLabel.Text = $"���A���^���G{json}";
                    }
                    else
                    {
                        MessageBox.Show($"�o�Ϳ��~�G{response.StatusCode}", "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // ����ʵe
                    cts.Cancel();
                    await animationTask; // �T�O�ʵe����
                }
                catch (Exception ex)
                {
                    if (ex.Message.Equals("A task was canceled.")) { }
                    else
                    {
                        MessageBox.Show($"�ШD���ѡG{ex.Message}", "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    cts.Dispose(); // �M�z�귽
                }
            }
        }

        private async void EnterMessage_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;//�ƹ�loading
                await ExecutePostRequestAsync();
            }
            finally { Cursor.Current = Cursors.Default; }//�ƹ���_
        }
        private async Task StartAnimationAsync(CancellationToken token)
        {
            string[] dots = { "...��", "...�@", "...�U" ,"...��"};
            int index = 0;

            while (!token.IsCancellationRequested)
            {
                MsgLabel.Text = dots[index];
                index = (index + 1) % dots.Length; // �`����s��r
                await Task.Delay(300, token); // ���� 500ms ��s�@��
            }
        }
    }
}
