using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameExtracterExstenion
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.Directory)]
    internal class GameExtracterExtension : SharpContextMenu
    {
        protected override bool CanShowMenu()
        {
            return true;
        }

        protected override ContextMenuStrip CreateMenu()
        {
            var menu = new ContextMenuStrip();

            var extract = new ToolStripMenuItem()
            {
                Text = "Extract Games"
            };

            extract.Click += (s, e) => ExtractGames();

            menu.Items.Add(extract);

            return menu;
        }

        private void ExtractGames()
        {
            foreach (var path in SelectedItemPaths.ToList())
            {
                var parent = Directory.GetParent(path).FullName;

                foreach (var file in Directory.EnumerateFiles(path))
                {
                    if (file.EndsWith(".sfc"))
                    {
                        var fileInfo = new FileInfo(file);
                        try
                        {
                            File.Move(fileInfo.FullName, $@"{parent}\{fileInfo.Name}");
                            MessageBox.Show($"File: {fileInfo.Name}, was moved to: {parent}");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                            MessageBox.Show($@"((BROKEN))File: {fileInfo.Name}, was not moved to: E:\GB");
                        }
                    }
                }
            }            
        }
    }
}
