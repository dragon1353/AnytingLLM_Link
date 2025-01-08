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
            // 獲取 TextBox 中的輸入值
            string msg = TextMsg.Text;

            if (string.IsNullOrWhiteSpace(msg))
            {
                MessageBox.Show("請輸入內容!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // API URL 和 JSON 資料
            string url = "http://localhost:3001/api/v1/workspace/hwashu_ai/chat";

            var jsonData = new
            {
                message = msg,
                mode = "query"
            };

            // 將 JSON 資料序列化為字串
            string jsonString = JsonSerializer.Serialize(jsonData);
            using (HttpClient client = new())
            {
                // 設定 Timeout 為 5 分鐘
                client.Timeout = TimeSpan.FromMinutes(5);
                // 設置標頭
                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer ART79RH-ASK4X8F-MRY83AZ-E25E7Y3");

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                CancellationTokenSource cts = new(); // 建立取消控制
                try
                {
                    // 啟動動畫
                    Task animationTask = StartAnimationAsync(cts.Token);

                    MsgLabel.Text = "...";
                    // 發送 POST 請求
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        using JsonDocument doc = JsonDocument.Parse(responseBody);
                        var json = doc.RootElement.GetProperty("textResponse").GetString();
                        MsgLabel.Text = $"伺服器回應：{json}";
                    }
                    else
                    {
                        MessageBox.Show($"發生錯誤：{response.StatusCode}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // 停止動畫
                    cts.Cancel();
                    await animationTask; // 確保動畫結束
                }
                catch (Exception ex)
                {
                    if (ex.Message.Equals("A task was canceled.")) { }
                    else
                    {
                        MessageBox.Show($"請求失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    cts.Dispose(); // 清理資源
                }
            }
        }

        private async void EnterMessage_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;//滑鼠loading
                await ExecutePostRequestAsync();
            }
            finally { Cursor.Current = Cursors.Default; }//滑鼠恢復
        }
        private async Task StartAnimationAsync(CancellationToken token)
        {
            string[] dots = { "...－", "...＼", "...｜" ,"...／"};
            int index = 0;

            while (!token.IsCancellationRequested)
            {
                MsgLabel.Text = dots[index];
                index = (index + 1) % dots.Length; // 循環更新文字
                await Task.Delay(300, token); // 延遲 500ms 更新一次
            }
        }
    }
}
