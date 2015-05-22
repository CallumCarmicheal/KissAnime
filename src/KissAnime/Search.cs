using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace KissAnime {
    public partial class Search : Form {
        public Search() {
            InitializeComponent();
        }



        private void autoCompleteTextbox1_TextChanged(object sender, EventArgs e) {
            BackgroundWorker wokR = new BackgroundWorker();

            wokR.DoWork += new DoWorkEventHandler(workerDo);
            wokR.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (workerFinsihed);
            wokR.WorkerSupportsCancellation = false;
        }

        void workerDo(object sender, DoWorkEventArgs e) {

            
        }

        void workerFinsihed(object sender, RunWorkerCompletedEventArgs e) {

        }
    }
}