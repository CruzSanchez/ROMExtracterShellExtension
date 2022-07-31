using SharpShell.SharpContextMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameExtracterExstenion
{
    
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
            
        }
    }
}
