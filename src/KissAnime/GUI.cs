using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Web;
using System.Net;
using System.Net.WebSockets;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Net.Http;

namespace KissAnime {
    public partial class GUI : Form {
        public GUI() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            wb.StatusTextChanged += pageStatusChanged;
        }

        private void button1_Click(object sender, EventArgs e) {
            query("http://kissanime.com/Anime/One-Piece", "One Piece");

            //wb.Navigate("http://kissanime.com/Anime/One-Piece");
            //wb.DocumentCompleted += pageLoaded;
        }

        string anime = "One Piece";
        int r = 0;
        private void pageLoaded(object sender, WebBrowserDocumentCompletedEventArgs e) {

            string src = wb.DocumentText;

            if (r == 0) {
                r++;
                wb.Navigate("http://kissanime.com/Anime/One-Piece");
                return;
            }
            if (src != null) {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(src);
                var headers = doc.DocumentNode.SelectNodes("//tr/th");
                DataTable data = new DataTable();

                foreach (HtmlNode header in headers)
                    data.Columns.Add(header.InnerText); // create columns from th

                data.Columns.Add("Link");

                // select rows with td elements 
                foreach (var row in doc.DocumentNode.SelectNodes("//tr[td]")) {
                    var raw = row.SelectNodes("td").Select(td => td.InnerHtml).ToArray();
                    var html = raw[0];
                    var regex = new Regex("<a [^>]*href=(?:'(?<href>.*?)')|(?:\"(?<href>.*?)\")", RegexOptions.IgnoreCase);
                    var urls = "http://kissanime.com" + regex.Matches(html).OfType<Match>().Select(m => m.Groups["href"].Value).ToArray()[0];

                    string[] args = row.SelectNodes("td").Select(td => td.InnerText).ToArray();
                    data.Rows.Add(args[0], args[1], urls);

                }

                foreach (DataRow row in data.Rows) {
                    string rowData = ((string)row[data.Columns[0]]);
                    rowData = rowData.Trim();

                    if (rowData.Contains(anime)) {
                        wb.DocumentCompleted -= pageLoaded;
                        wb.Stop();

                        dataGridView1.DataSource = data;
                        return;
                    }
                }
            }
        }

        WebBrowser webB = new WebBrowser();
        private void query(string site, string anime) {
            webB.ScriptErrorsSuppressed = true;
            webB.StatusTextChanged += pageStatusChanged;

            webB.Navigate(site);
            while (webB.ReadyState != WebBrowserReadyState.Interactive) { 
                System.Windows.Forms.Application.DoEvents(); 
            }

            webB.Navigate(site);
            while (webB.ReadyState != WebBrowserReadyState.Complete) {
                System.Windows.Forms.Application.DoEvents();
            }


            // GET ANAMUNAY INFO -------------

            string src = webB.DocumentText;

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(src);
            var headers = doc.DocumentNode.SelectNodes("//tr/th");
            DataTable data = new DataTable();

            foreach (HtmlNode header in headers)
                data.Columns.Add(header.InnerText); 

            data.Columns.Add("Link");

            foreach (var row in doc.DocumentNode.SelectNodes("//tr[td]")) {
                var raw = row.SelectNodes("td").Select(td => td.InnerHtml).ToArray();
                var html = raw[0];
                var regex = new Regex("<a [^>]*href=(?:'(?<href>.*?)')|(?:\"(?<href>.*?)\")", RegexOptions.IgnoreCase);
                var urls = "http://kissanime.com" + regex.Matches(html).OfType<Match>().Select(m => m.Groups["href"].Value).ToArray()[0];

                string[] args = row.SelectNodes("td").Select(td => td.InnerText).ToArray();
                data.Rows.Add(args[0], args[1], urls);

            }

            foreach (DataRow row in data.Rows) {
                string rowData = ((string)row[data.Columns[0]]);
                rowData = rowData.Trim();

                if (rowData.Contains(anime)) {
                    webB.Stop();

                    dataGridView1.DataSource = data;
                    return;
                }
            }
        }

        private void pageStatusChanged(object sender, EventArgs e) {
            //toolStripStatusLabel1.Text = wb.StatusText;
            toolStripStatusLabel1.Text = webB.StatusText;
        }

        public string DownloadString(string site) {
            return "";
        }

        /*
         * Examplar usage : 
         *      LEN(string* source, string* stringToFind);
         *      LEN("<html> <tr> once upon a time </tr> </html>", "/once/upon/a/time/");
         */
        private int LEN(string src, string find) {
            string source = "/once/upon/a/time/";
            int count = 0;
            foreach (char c in source)
                if (c == '/') count++;

            return count;
        }
    }
}
