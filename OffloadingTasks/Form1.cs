using System.Threading;
using System.Windows.Forms;

namespace OffloadingTasks
{
    public partial class Form1 : Form
    {
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
            Thread.Sleep(delay);
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
}
