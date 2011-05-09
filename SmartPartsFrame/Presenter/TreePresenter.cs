using System;
using System.Collections.Generic;
using System.Text;
using SmartPartsFrame.View.Interface;
using System.Windows.Forms;
using SmartPartsFrame.Model;
using System.IO;

namespace SmartPartsFrame.Presenter
{
    class TreePresenter
    {
        ITreeSmartPart view;
        FileSystemModel model = new FileSystemModel();

        public TreePresenter(ITreeSmartPart view)
        {
            this.view = view;
        }

        internal void ExpandNode()
        {
            string path = view.CurrentNode.FullPath + "\\";
            string[] f = model.GetFileNames(new DirectoryInfo(path));
            string[] d = model.GetDirectoryNames(new DirectoryInfo(path));

            for (int i = 0; i < f.Length; i++)
            {
                f[i] = f[i].ToLowerInvariant();
            }

            for (int i = 0; i < d.Length; i++)
            {
                d[i] = d[i].ToUpperInvariant();
            }

            string[] fs = new string[f.Length + d.Length];
            d.CopyTo(fs, 0);
            f.CopyTo(fs, d.Length);
            

            view.AddNodes(fs);
        }
    }
}
