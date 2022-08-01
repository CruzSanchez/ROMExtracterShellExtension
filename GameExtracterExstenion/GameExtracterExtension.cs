using GameExtracterExstenion.ExtensionMethods;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GameExtracterExstenion
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.Directory)]
    internal class GameExtracterExtension : SharpContextMenu
    {
        //Array of ROM file extensions
        private readonly string[] _extensions = new string[] { ".iso", ".gb", ".gba", ".nes", ".sfc", ".z64", ".bin", ".cue", ".n64", ".gcz", ".gbc" };

        protected override bool CanShowMenu()
        {
            //Always show menu for directory types
            return true;
        }

        protected override ContextMenuStrip CreateMenu()
        {
            //Creating a menu
            var menu = new ContextMenuStrip();

            //Creating the command
            var extract = new ToolStripMenuItem()
            {
                Text = "Extract Games",
                ShortcutKeys = Keys.Control | Keys.B                               
            };

            //Adding the ExtractGames() to the click event
            extract.Click += (s, e) => ExtractGames();

            //Adding the command to the menu
            menu.Items.Add(extract);

            return menu;
        }

        private void ExtractGames()
        {
            //Get the paths of the selected folders
            var paths = SelectedItemPaths;

            foreach (var path in paths)
            {
                //Get the parent directory for the selected folder(s)
                var parent = Directory.GetParent(path).FullName;

                //Get all the file names in the selected folder(s)
                var files = Directory.EnumerateFiles(path);

                //If there are not any files with any of the ROM extensions, in the current folder, go to the next folder
                if (!files.ContainsAny(_extensions))
                {
                    MessageBox.Show($"There are no game files in {path}");
                    continue;
                }

                //Move the game files to the another folder (in this case one folder above the selected folder)
                MoveFiles(files, parent);
            }
        }

        private void MoveFiles(IEnumerable<string> files, string parentDirectory)
        {
            foreach (var file in files)
            {
                //Get the file info for the current file, this will be used to get the file path for the Move method
                var fileInfo = new FileInfo(file);

                //If the current file is a game file, move it to the parent folder
                if (file.EndsWithAny(_extensions))
                {
                    try
                    {
                        File.Move(fileInfo.FullName, $@"{parentDirectory}\{fileInfo.Name}");
                    }
                    catch (Exception e)
                    {
                        /*
                         * I am just catching any exception here and letting the user know what happened.
                         * With this shell command, from what I have seen, throwing an exception really doesn't break anything
                         * it is like nothing ever happened.
                         */
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }
    }
}
