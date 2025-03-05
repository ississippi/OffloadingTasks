using System.Threading;
using System.Windows.Forms;

namespace OffloadingTasks
{
    public partial class Form1 : Form
    {
        object lockObj = new object();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => ShowMessage("First message", 3000));
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => ShowMessage("Second message", 3000));
            thread.Start();
        }

        private void ShowMessage(string message, int delay)
        {
            lock (lockObj)
            {
                if (lblMessage.InvokeRequired)
                {
                    lblMessage.Invoke(new Action(() => lblMessage.Text = message));
                }
                else
                {
                    lblMessage.Text = message;
                }
            }
        }
        private async void button1Async_Click(object sender, EventArgs e)
        {
            await ShowMessageAsync("First Message", 3000);
        }

        private async void button2Async_Click(object sender, EventArgs e)
        {
            await ShowMessageAsync("Second Message", 3000);
        }
        private async Task ShowMessageAsync(string message, int delay)
        {
            await Task.Delay(delay);

            lblMessage.Text = message;
        }
    }
}
