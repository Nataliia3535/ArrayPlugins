using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using BasePlugin;

namespace ArrayPlugins
{
    public partial class Form1 : Form
    {
        int[] arr = new int[4];
        Dictionary<string, IArrayBase> _ibasearrey = new Dictionary<string, IArrayBase>();
        public Form1()
        {
            InitializeComponent();
            var assembly = Assembly.GetExecutingAssembly();
            var folder = Path.GetDirectoryName(assembly.Location);

            LoadIArray(folder);
            CreateArrayMenu();
        }
        void LoadIArray(string folder)
        {
            _ibasearrey.Clear();
            foreach (var dll in Directory.GetFiles(folder, "*.dll"))
            {
                try
                {
                    var asm = Assembly.LoadFrom(dll);
                    foreach (var type in asm.GetTypes())
                    {
                        if (type.GetInterface("IArrayBase")==typeof(IArrayBase))
                        {
                            var iarray = Activator.CreateInstance(type) as IArrayBase;
                            _ibasearrey[iarray.Name] = iarray;
                        }
                    }
                }
                catch
                {

                }
            }
        }
        void CreateArrayMenu()
        {
            pluginsToolStripMenuItem.DropDownItems.Clear();
            foreach(KeyValuePair<string,IArrayBase> pair in _ibasearrey)
            {
                var item = new ToolStripMenuItem(pair.Key);
                item.Click += new EventHandler(menuItem_Click);
                pluginsToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            var iarray = _ibasearrey[menuItem.Text];
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                textBox2.Text = String.Join("",iarray.RunPlugin(arr));
            }
            catch
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        
        private void createArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            Random rand = new Random();
            for (i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0,10);
                textBox1.Text = String.Join("", arr);
            }
             
            
        }

        
    }
}
