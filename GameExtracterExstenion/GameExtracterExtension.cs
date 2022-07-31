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
    [COMServerAssociation(AssociationType.ClassOfExtension, ".txt")]
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
            //  Builder for the output
            var builder = new StringBuilder();

            //  Go through each file
            foreach (var filePath in SelectedItemPaths)
            {
                //  Count the lines
                builder.AppendLine(string.Format("{0} - {1} Lines",
                  Path.GetFileName(filePath), File.ReadAllLines(filePath).Length));
            }

            //  Show the output
            MessageBox.Show(builder.ToString());
        }
    }
}
