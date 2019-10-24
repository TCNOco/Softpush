using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;

using IniParser;
using IniParser.Model;

// Created by TechNobo
// Simple program to redirect a website to a locally hosted .html file.
//
// How it works:
// requestedsite.com >> 127.0.4.20 [Non-existent IP address] >> 127.0.0.1:33312 [With hosted html. Can be different port]
//
// Uses Windows' hosts file functionality for a DNS redirect.
// Uses Windows' netsh to redirect from nonexistant IP to your locally hosted file. [hosts can't redirect to localhost, and a custom port. Only works with port 80. Causes conflicts]


// --------------------------
// ---------- TODO ----------
// --------------------------
// - Add textbox for user to set background image URL. Provide list of "Random" image providers, like the currently used one.
// - Make service that hosts the web stuff, instead of in the program. Makes quitting a lot easier.
//      -> FileSystemWatcher on a settings file (https://stackoverflow.com/questions/721714/notification-when-a-file-changes)
//      -> Exit doesn't stop the service. This is just the control panel for it.
//      -> Notify user that the service has been installed, as it's needed for the program to run.
//      -> Add restart service button?
// --------------------------

namespace Softpush
{
    public partial class frmSoftpushOptions : Form
    {
        // Basic settings
        bool pageRedirect = false, exitAndStop = false;
        string pageRedirectURL = "https://google.com";
        string pageResponsePath = @"default.html";

        // Advanced settings.
        int port = 33312, existStartLine = 0, existEndLine = 0;
        string listenaddress = "127.0.4.20";
        string hostsPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\drivers\\etc\\hosts";

        Thread bgWorkerThread;
        System.Net.HttpListener listener = new System.Net.HttpListener();
        IniData settings = new IniData();

        public void iniLoad()
        {
            var parser = new FileIniDataParser();
            try
            {
                settings = parser.ReadFile("config.ini");
            }
            catch (Exception)
            {
                settings.Sections.AddSection("BlockedAction");
                settings["BlockedAction"].AddKey("redirect", "false");
                settings["BlockedAction"].AddKey("redirectURL", "https://google.com");
                settings["BlockedAction"].AddKey("pageResponseFilename", @"default.html");
                settings["HostSettings"].AddKey("port", "33312");
                settings["HostSettings"].AddKey("listenaddress", "127.0.4.20");

                iniSave();
            }

            pageRedirect = bool.Parse(settings["BlockedAction"]["redirect"]);
            pageRedirectURL = settings["BlockedAction"]["redirectURL"];
            tbRedirectURL.Text = pageRedirectURL;

            port = int.Parse(settings["HostSettings"]["port"]);
            listenaddress = settings["HostSettings"]["listenaddress"];
        }
        public void iniSave()
        {
            settings["BlockedAction"]["redirect"] = pageRedirect.ToString();
            settings["BlockedAction"]["redirectURL"] = pageRedirectURL;

            settings["HostSettings"]["port"] = port.ToString();
            settings["HostSettings"]["listenaddress"] = listenaddress;

            var parser = new FileIniDataParser();
            parser.WriteFile("config.ini", settings);
        }

        public frmSoftpushOptions()
        {
            InitializeComponent();
        }

        private string getResponseText()
        {
            if (!File.Exists(pageResponsePath))
            {
                return "default.html was deleted from the program's directory. Check it exists and is accessible, or redownload it." + Environment.NewLine +
                    "We will check every minute for a new file -- You can disable this in settings.";
                // IMPLIMENT TIMED CHECK?
            }
            else
                return File.ReadAllText(pageResponsePath);
        }
        private void frmSoftpushOptions_Load(object sender, EventArgs e)
        {
            iniLoad();
#if DEBUG
            pageResponsePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\\..\\..\\..\\WebInterface\\default.html";
#endif
            Debug.WriteLine("default.html: " + pageResponsePath);

            // Add netsh forward for server.
            // Needed to redirect default URL port (80) to hosted server -- You can't host more than one program on the same port.
            Debug.WriteLine("Adding netsh v4tov4 redirect (" + listenaddress + " to 127.0.0.1:" + port + ")");
            string netshCommand =    "netsh interface portproxy add v4tov4 listenport=80 listenaddress=" + listenaddress + " connectport=" + port + " connectaddress=127.0.0.1";
            string netshCommandSSL = "netsh interface portproxy add v4tov4 listenport=443 listenaddress=" + listenaddress + " connectport=" + port + " connectaddress=127.0.0.1";
            Debug.WriteLine("-> Executing: "+ netshCommand);
            Debug.WriteLine("-> Executing: "+ netshCommandSSL);
            // To check netsh redirects, use "netsh interface portproxy dump"
            // To remove the above code, you'd use the following command (Written to debug command line, but you can manually put it together)
            // or use `netsh interface portproxy reset`
            Debug.WriteLine("--> To remove: netsh interface portproxy delete v4tov4 listenport=80 listenaddress=" + listenaddress);
            Debug.WriteLine("--> And:       netsh interface portproxy delete v4tov4 listenport=443 listenaddress=" + listenaddress);
            Debug.WriteLine(netshCommand + " && " + netshCommandSSL + "&& pause");
            System.Diagnostics.Process.Start("cmd.exe", "/c " + netshCommand + " & " + netshCommandSSL);

            // Load existing settings from hosts file
            loadExisting();


            //Set up and start listener
            string[] prefixes = new string[1];
            prefixes[0] = "http://*:" + port + "/";

            bgWorkerThread = new Thread(() => ProcessRequests(prefixes));
            bgWorkerThread.Start();
        }
        private void ProcessRequests(string[] prefixes)
        {
            // Tell user server is starting
            tsslblWebServer.Text = "Web server: Starting...";

            if (!System.Net.HttpListener.IsSupported)
            {
                Debug.WriteLine("Windows XP SP2 or higher required.");
                return;
            }

            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            foreach (string s in prefixes)
                listener.Prefixes.Add(s);

            try
            {
                listener.Start();
                Debug.WriteLine("");
                Debug.WriteLine("Listening...");
                // Tell user server is starting
                tsslblWebServer.Text = "Web server: OK";
                for (int i = 0; i <= 2; i += 0)
                {
                    HttpListenerResponse response = null;
                    try
                    {
                        HttpListenerContext context = listener.GetContext();
                        string inURL = context.Request.RawUrl;
                        string responseString = "";
                        response = context.Response;
                        if (!pageRedirect)
                        {
                            // Send user the html page.
                            responseString = getResponseText();
                        }
                        else
                        {
                            // Redirect user to the selected page instead.
                            responseString = "<html><head><meta http-equiv=\"Refresh\" content=\"0;url = " + pageRedirectURL + "\"></head></html>";
                        }

                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                        response.ContentLength64 = buffer.Length;
                        System.IO.Stream output = response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                    }
                    catch (HttpListenerException ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    finally
                    {
                        if (response != null)
                            response.Close();
                    }
                }
            }
            catch (HttpListenerException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                listener.Close();
                Debug.WriteLine("Done Listening...");
            }
        }

        private void rbShowRedirect_CheckedChanged(object sender, EventArgs e)
        {
            pageRedirect = rbShowRedirect.Checked;
            tbRedirectURL.Enabled = rbShowRedirect.Checked;
        }

        private void rbShowPage_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbRedirectURL_TextChanged(object sender, EventArgs e)
        {
            pageRedirectURL = tbRedirectURL.Text;
        }

        private void frmSoftpushOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            iniSave();
            if (!exitAndStop)
            {
                string exitMessageTitle = "Softpush - Important information!",
                exitMessage = "Hitting this exit button WON'T close this program entirely!\n1. Blocked sites will still be blocked, unless you click UNBLOCK.\n2. The web redirect service will still run.\n\nTo completely close: click \"Exit & Stop server\".\nClick Yes to leave server running, or No to go back.";
                if (MessageBox.Show(exitMessage, exitMessageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnExitStop_Click(object sender, EventArgs e)
        {
            iniSave();
            listener.Stop(); // Stop background web host listener.
            bgWorkerThread.Abort(); // Close background web host thread. No data can be lost, so Abort() is fine.
            exitAndStop = true; // Stops "Are you sure" message.
            Application.Exit();
        }

        private void btnUnblock_Click(object sender, EventArgs e)
        {
            string unblockMessageTitle = "Softpush - Are you sure?",
            unblockMessage = "Are you sure you want to unblock your listed sites?\n\nBlocking then was the entire reason you installed this software.\nTake a moment to think about this.";
            if (MessageBox.Show(unblockMessage, unblockMessageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                // Unblock
                hostsFindFirstLast();
                string tempFile = Path.GetTempFileName();
                hostsCopyToTemp(null, tempFile); // Parsing null isntead of string array stops Softpush writing it's blocking rules.
                hostsMoveFromTemp(tempFile);

                // Move from program list to text file
                txtURLsRemoveWhitespace();
                string oldTextFilename = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\old.txt";
                if (File.Exists(oldTextFilename))
                    File.Delete(oldTextFilename);
                File.WriteAllText(oldTextFilename, txtURLs.Text);
                txtURLs.Clear();

                string unblockedMessageTitle = "Softpush - Unblocked.",
                unblockedMessage = "Websites have been unblocked.\n\nThe list has been saved to the program's directory as \"old.txt\".";
                MessageBox.Show(unblockedMessage, unblockedMessageTitle);
            }
        }
        int currentLine = 0;
        string line = "";
        private void hostsFindFirstLast()
        {
            // Check if already written rules to hosts file
            using (var hostsReader = new StreamReader(hostsPath))
            {
                // Check to see if information is already written to hosts file
                // See where it starts and ends if it has already bene written.
                Debug.WriteLine("->Reading hosts file");
                while ((line = hostsReader.ReadLine()) != null)
                {
                    Debug.WriteLine(line);                                                                                  // TEMP
                    if (line == "# >>>>>>>> Softpush  redirects <<<<<<<<" && existStartLine == 0) // First line is current. First line not already found.
                        existStartLine = currentLine;
                    else if (existStartLine != 0 && line == "# >>> End of Softpush redirects <<<") // First line found. Last line is current.
                    {
                        existEndLine = currentLine;
                        break;
                    }
                    currentLine++;
                }
                hostsReader.Close();
                currentLine = 0;
            }
        }
        private void hostsCopyToTemp(string[] URLs, string tempFile)
        {
            // Copy the hosts file redirects and information that is NOT added by this program.
            // If info from this program is written, it skips it.
            Debug.WriteLine("Temp hosts file: " + tempFile);
            Debug.WriteLine("Starting copy from hosts to temporary hosts file.");
            using (var sr = new StreamReader(hostsPath))
            using (var sw = new StreamWriter(tempFile))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if ((existStartLine != 0 && !(currentLine >= existStartLine && currentLine <= existEndLine)) || existStartLine == 0) // Copies if: (Redirects written AND not in upper/lower bounds) OR (Redirects not writen)
                    {
                        sw.WriteLine(line);
                    }
                    currentLine++;
                }
                Debug.WriteLine("Finished copying hosts text that was NOT put in by this program");
                if (URLs != null && URLs.Length > 0)
                {
                    Debug.WriteLine("Adding redirects and information.");
                    sw.WriteLine("# >>>>>>>> Softpush  redirects <<<<<<<<");
                    sw.WriteLine("# >> Created by TechNobo");
                    sw.WriteLine("# >> github link when it exists.");
                    sw.WriteLine("# -------------------------------------");
                    sw.WriteLine("# >> DO NOT EDIT - USE THE INTERFACE <<");

                    foreach (string URL in URLs)
                        sw.WriteLine(URL);

                    sw.WriteLine("# >>> End of Softpush redirects <<<");
                }
                else
                {
                    Debug.WriteLine("No urls in list. Not adding any text.");
                }
            }
        }
        private void hostsMoveFromTemp(string tempFile)
        { 
            // Copy information from temp hosts file to Windows' hosts file, without deleting either. [Will give "in use by another program" if attempted without doing it this long way around].
            Debug.WriteLine("Emptying the hosts file.");
            File.WriteAllText(hostsPath, string.Empty);

            Debug.WriteLine("Copying temporary hosts file to replace original hosts file.");
            using (var sr = new StreamReader(tempFile))
            using (var sw = new StreamWriter(hostsPath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    sw.WriteLine(line);
                }
            }
            Debug.WriteLine("Done!");
            File.Delete(tempFile);
        }

        private void btnLoadList_Click(object sender, EventArgs e)
        {
            // User selects file
            OpenFileDialog selectedFile = new OpenFileDialog();
            selectedFile.InitialDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            selectedFile.RestoreDirectory = true;
            selectedFile.Title = "Select text file to load";
            selectedFile.DefaultExt = "txt";
            selectedFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            selectedFile.FilterIndex = 2;
            selectedFile.CheckPathExists = true;

            selectedFile.ShowDialog();
            txtURLs.Text = File.ReadAllText(selectedFile.FileName);
            txtURLsRemoveWhitespace();
        }

        private void txtURLsRemoveWhitespace() { txtURLs.Text = Regex.Replace(txtURLs.Text, @"^\s*$[\r\n]*", string.Empty, RegexOptions.Multiline).TrimEnd(); }
        private void btnSaveURL_Click(object sender, EventArgs e)
        {
            txtURLsRemoveWhitespace();
            if (txtURLs.TextLength == 0)
            {
                MessageBox.Show("Nothing was entered.", "Softpush - Error saving!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Add IP Address next to URL for hosts file.
                string[] URLs = txtURLs.Lines;
                int i = 0;
                foreach (string url in URLs)
                {
                    URLs[i] = listenaddress + " " + url;
                    i++;
                }

                // Check access to hosts file
                Debug.WriteLine(URLs);                                                                                      // TEMP
                Debug.WriteLine(hostsPath);                                                                                 // TEMP

                hostsFindFirstLast();
                string tempFile = Path.GetTempFileName();
                hostsCopyToTemp(URLs, tempFile);
                hostsMoveFromTemp(tempFile);
            }
        }

        private void loadExisting()
        {
            using (var sr = new StreamReader(hostsPath))
            {
                Debug.WriteLine("->Reading hosts file");
                int currentLine = 0;
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    Debug.WriteLine(line);                                                                                  // TEMP
                    if (line == "# >>>>>>>> Softpush  redirects <<<<<<<<" && existStartLine == 0) // First line is current. First line not already found.
                        existStartLine = currentLine;
                    else if (existStartLine != 0 && line == "# >>> End of Softpush redirects <<<") // First line found. Last line is current.
                    {
                        existEndLine = currentLine;
                        break;
                    } else if (existStartLine != 0 && !line.StartsWith("#")) // Start found. Not a commented line. This is where the IPs are, as long as it's not broken.
                    {
                        txtURLs.AppendText(line.Split(' ')[1]+"\r\n");
                    }
                    currentLine++;
                }

            }
        }
    }
}