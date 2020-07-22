using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace Modcomposer
{
    public partial class ModComposer : Form
    {
        public ModComposer()
        {
            InitializeComponent();
        }

        private int mods = 0, enabled = 0;

        private void btnFolderBrowse_Click(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                pathBox.Text = folderDialog.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            modList.Items.Clear();
            ScanMods();
        }
        private void ScanMods()
        {
            mods = 0;
            mdsCntNmb.Text = "0";
            string path = pathBox.Text;
            string serverpath = serverBox.Text;
            Console.WriteLine(string.Format("Mod path >> {0}", path));
            Console.WriteLine(string.Format("Server path >> {0}", serverpath));
            if (!Directory.Exists(path) || (!string.IsNullOrWhiteSpace(serverpath) && !Directory.Exists(serverpath)))
            {
                pathValidatorText.Text = "Invalid directory!";
                pathValidatorText.ForeColor = Color.Red;
                return;
            }
            else
            {
                pathValidatorText.Text = "Directory valid!";
                pathValidatorText.ForeColor = Color.Green;
            }

            string[] paths = Directory.GetDirectories(path);
            foreach (string p in paths)
            {
                Console.WriteLine(string.Format("-> found dir >> {0}", p));
                try
                {
                    string[] modfiles = Directory.GetFiles(p, "meta.cpp");
                    if (modfiles.Length != 0)
                    {
                        Console.WriteLine(string.Format(" -> Found mod descriptor for >> {0}", p));
                        string s = File.ReadAllLines(modfiles[0]).FirstOrDefault(n => n.StartsWith("name"));
                        if (string.IsNullOrWhiteSpace(s))
                        {
                            Console.WriteLine(" -> Cannot retrieve name, moving on.");
                            continue;
                        }
                        Console.WriteLine(string.Format(" -> Name: {0} >> {1}", s, p));
                        s = Regex.Match(s, "\"([\\S\\s]+)\";$").Groups[1].Value;
                        RegisterMod(p, s);
                        mods++;
                    }
                    else
                    {
                        Console.WriteLine(string.Format("Ignoring directory, no mod descriptor >> {0}", p));
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine(string.Format("Dir does not exist >> {0}", p));
                }
            }
            mdsCntNmb.Text = mods.ToString();
            Console.WriteLine("Mod scan complete. Mods found: " + mods.ToString());

        }

        //readonly string pattern = (@"$[\s\w]+\\");
        private string Relativize(string abs, string refr)
        {
            Uri absuri = new Uri(abs);
            Uri refruri = new Uri(refr);
            string last = Path.GetFileName(refr);
            return Uri.UnescapeDataString(refruri.MakeRelativeUri(absuri).ToString().Replace('/', Path.DirectorySeparatorChar)).Substring(last.Length + 1);
        }

        private void RegisterMod(string path, string name)
        {
            ListViewItem it = new ListViewItem(new[] { name, path, "No" })
            {
                Tag = false,
                ForeColor = Color.Red
            };
            modList.Items.Add(it);
        }

        private void btnEnSel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem it in modList.SelectedItems)
            {
                it.Tag = true;
                it.ForeColor = Color.Green;
                it.SubItems[2].Text = "Yes";
            }
            modList.Update();
            UpdateInds();
            Console.WriteLine(modList.SelectedItems.Count.ToString() + " mods enabled!");
        }

        private void UpdateInds()
        {
            enabled = 0;
            foreach (ListViewItem it in modList.Items)
            {
                if ((bool)it.Tag)
                {
                    enabled++;
                }
            }
            mdsSelCnt.Text = enabled.ToString();
        }

        private void modList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSelected();
            }
        }

        private void UpdateSelected()
        {
            foreach (ListViewItem it in modList.SelectedItems)
            {
                it.Tag = !(bool)it.Tag;
                it.ForeColor = (bool)it.Tag ? Color.Green : Color.Red;
                it.SubItems[2].Text = (bool)it.Tag ? "Yes" : "No";
                if ((bool)it.Tag)
                {
                    enabled++;
                }
                else
                {
                    enabled--;
                }
            }
            modList.Update();
            mdsSelCnt.Text = enabled.ToString();
        }

        private void btnDiSel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem it in modList.SelectedItems)
            {
                it.Tag = false;
                it.ForeColor = Color.Red;
                it.SubItems[2].Text = "No";
            }
            modList.Update();
            UpdateInds();
            Console.WriteLine(modList.SelectedItems.Count.ToString() + " mods disabled!");
        }

        private void btnEnAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem it in modList.Items)
            {
                it.Tag = true;
                it.ForeColor = Color.Green;
                it.SubItems[2].Text = "Yes";
            }
            modList.Update();
            UpdateInds();
            Console.WriteLine(mods + " mods enabled!");
        }

        private void btnDiAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem it in modList.Items)
            {
                it.Tag = false;
                it.ForeColor = Color.Red;
                it.SubItems[2].Text = "No";
            }
            modList.Update();
            UpdateInds();
            Console.WriteLine(mods + " mods disabled!");
        }

        private static readonly JsonSerializerOptions opt = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = null,
            WriteIndented = true,
        };

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mods < 1)
            {
                return;
            }
            if (configSaveDialog.ShowDialog() == DialogResult.OK)
            {
                List<Mod> mods = new List<Mod>();
                foreach (ListViewItem it in modList.Items)
                {
                    mods.Add(new Mod()
                    {
                        IsEnabled = (bool)it.Tag,
                        Name = it.SubItems[0].Text,
                        Path = it.SubItems[1].Text
                    });
                }
                using (Stream s = configSaveDialog.OpenFile())
                {

                    ConfigModel obj = new ConfigModel()
                    {
                        Version = "1.0.1",
                        Mods = mods.ToArray(),
                        ModPath = pathBox.Text,
                        ServerPath = string.IsNullOrWhiteSpace(serverBox.Text) ? null : serverBox.Text,
                    };
                    byte[] str = JsonSerializer.SerializeToUtf8Bytes(obj, opt);
                    s.Write(str, 0, str.Length);
                    s.Flush();
                    Console.WriteLine("Config saved!");
                }
            }
        }

        private void btnCfgLoad_Click(object sender, EventArgs e)
        {
            if (configLoadDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = configLoadDialog.OpenFile())
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        try
                        {
                            Console.WriteLine("Loading config!");
                            ConfigModel cfg = JsonSerializer.Deserialize<ConfigModel>(sr.ReadToEnd(), opt);
                            Console.WriteLine("Autosetting main path!");
                            pathBox.Text = cfg.ModPath;
                            serverBox.Text = cfg.ServerPath;
                            Console.WriteLine("Scanning mods!");
                            ScanMods();
                            Console.WriteLine("Successfull mod scan!");
                            foreach (Mod m in cfg.Mods)
                            {
                                if (!m.IsEnabled)
                                {
                                    continue;
                                }

                                if (!Directory.Exists(m.Path))
                                {
                                    continue;
                                }

                                var it = modList.FindItemWithText(m.Name);
                                it.Tag = true;
                                it.ForeColor = Color.Green;
                                it.SubItems[2].Text = "Yes";
                            }
                            Console.WriteLine("Config loaded!");
                        }
                        catch (Exception ee)
                        {
                            Console.WriteLine("There was an error during config loading!");
                            Console.WriteLine(ee.ToString());
                        }
                    }
                }
            }
        }

        private void modList_DoubleClick(object sender, EventArgs e)
        {
            UpdateSelected();
        }

        private string ConstructParams()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("-mod=");
            bool isB = string.IsNullOrWhiteSpace(serverBox.Text);
            foreach (ListViewItem it in modList.Items)
            {
                if ((bool)it.Tag)
                {
                    sb.Append(isB ? it.SubItems[1].Text : Relativize(it.SubItems[1].Text, serverBox.Text)).Append(";");
                }
            }

            sb.Remove(sb.Length - 1, 1);
            string post = sb.ToString();
            if (post.Contains(' '))
            {
                post = "\"" + post + "\"";
            }

            return post;
        }

        private void btnSaveParamsCb_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ConstructParams());
            Console.WriteLine("Parameters copied to clipboard!");
        }

        private void btnSaveParamsFile_Click(object sender, EventArgs e)
        {
            if (paramSaveDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = paramSaveDialog.OpenFile())
                {
                    byte[] par = Encoding.UTF8.GetBytes(ConstructParams());
                    s.Write(par, 0, par.Length);
                    s.Flush();
                    Console.WriteLine("Params saved to file >> " + paramSaveDialog.FileName);
                }
            }
        }

        private void loadCfgFromHtml_Click(object sender, EventArgs e)
        {
            if ((htmlDialog.ShowDialog() == DialogResult.OK) && mods > 0)
            {
                XmlDocument doc = new XmlDocument();
                try
                {
                    List<string> miss = new List<string>();
                    doc.Load(htmlDialog.FileName);
                    Console.WriteLine(doc.DocumentElement.Name);
                    //Console.WriteLine(File.ReadAllText(htmlDialog.FileName));
                    List<string> mods = new List<string>();
                    //Console.WriteLine(doc.SelectNodes("//table").Count);
                    foreach (XmlNode n in doc.SelectNodes("//table")[0].ChildNodes)
                    {
                        mods.Add(n.FirstChild.InnerText);
                        Console.WriteLine("-> " + n.FirstChild.InnerText);
                    }
                    foreach (string mod in mods)
                    {
                        var it = modList.FindItemWithText(mod);
                        if (it == null)
                        {
                            Console.WriteLine("Missing mod >> " + mod);
                            miss.Add(mod);
                            continue;
                        }
                        it.Tag = true;
                        it.ForeColor = Color.Green;
                        it.SubItems[2].Text = "Yes";
                    }
                    Console.WriteLine("Successfully loaded HTML!");
                    if (miss.Count > 0)
                    {
                        Console.WriteLine(miss.Count.ToString() + " mods are missing!");
                        Console.WriteLine("List of missing mods:");
                        foreach (string mod in miss)
                        {
                            Console.WriteLine(string.Format("-> {0}", mod));
                        }

                    }
                }
                catch (Exception ee)
                {
                    Console.WriteLine("There was a problem loading configuration.");
                    Console.WriteLine(ee.ToString());
                }
            }

        }

        private void ModComposer_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Init successful!");
            Console.WriteLine("Select main mod path. Symlinks are supported.");
            string pth = Path.Combine(Application.UserAppDataPath, "tempsettings.a3ml");
            if (File.Exists(pth))
            {
                Console.WriteLine("Found temp config file... Loading config...");
                try
                {
                    Console.WriteLine("Loading config!");
                    ConfigModel cfg = JsonSerializer.Deserialize<ConfigModel>(File.ReadAllText(pth, Encoding.UTF8), opt);
                    Console.WriteLine("Autosetting main path!");
                    pathBox.Text = cfg.ModPath;
                    serverBox.Text = cfg.ServerPath;
                    Console.WriteLine("Scanning mods!");
                    ScanMods();
                    Console.WriteLine("Successfull mod scan!");
                    foreach (Mod m in cfg.Mods)
                    {
                        if (!m.IsEnabled)
                        {
                            continue;
                        }

                        if (!Directory.Exists(m.Path))
                        {
                            continue;
                        }

                        var it = modList.FindItemWithText(m.Name);
                        it.Tag = true;
                        it.ForeColor = Color.Green;
                        it.SubItems[2].Text = "Yes";
                    }
                    Console.WriteLine("Config loaded!");
                }
                catch (Exception ee)
                {
                    Console.WriteLine("There was an error during config loading!");
                    Console.WriteLine(ee.ToString());
                }
            }
        }

        private void ModComposer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Saving temp mod config!");
            if (this.mods < 1)
            {
                return;
            }

            List<Mod> mods = new List<Mod>();
            foreach (ListViewItem it in modList.Items)
            {
                mods.Add(new Mod()
                {
                    IsEnabled = (bool)it.Tag,
                    Name = it.SubItems[0].Text,
                    Path = it.SubItems[1].Text
                });
            }


            ConfigModel obj = new ConfigModel()
            {
                Version = "1.0.1",
                Mods = mods.ToArray(),
                ModPath = pathBox.Text,
                ServerPath = string.IsNullOrWhiteSpace(serverBox.Text) ? null : serverBox.Text,
            };

            File.WriteAllText(Path.Combine(Application.UserAppDataPath, "tempsettings.a3ml"), JsonSerializer.Serialize(obj, opt), Encoding.UTF8);
            Console.WriteLine("Config saved!");

        }
    }
}
