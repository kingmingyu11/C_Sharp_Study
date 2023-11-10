using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncFileIOWinForm
{
    public partial class MainForm : Form
    {
        private btnSyncCopy;
        public MainForm()
        {
            InitializeComponent();
        }

        private async Task<long> CopyAsync(string FromPath,string ToPath)
        {
            btnSyncCopy.Enabled = false;
            long totalCopied = 0;
            using (FileStream fromStream =
                new FileStream(FromPath, FileMode.Open))
            {
                using (FileStream toStream = new FileStream(ToPath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024*1024];

                    int nRead = 0;
                    while((nRead = 
                        await fromStream.ReadAsync(buffer,0,buffer.Length))!=0)
                    {
                        await toStream.WriteAsync(buffer, 0, nRead);
                        totalCopied += nRead;

                        // 프로그레스바에 현재 파일 복사 상태 표시
                        pbCopy.Value = (int)(((double)totalCopied / (double)fromStream.Length)
                            *pbCopy.Maximum);
                        
                    }
                }
            }
            btnAsyncCopy.Enabled = true;
            return totalCopied;
                    }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
