using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SmartPartsFrame.View.Interface;
using SmartPartsFrame.SmartParts.Common;
using SmartPartsFrame.Presenter;

namespace SmartPartsFrame.View.SmartParts.General
{
    public partial class TreeSmartPart : SmartPartBase, ITreeSmartPart
    {
        TreePresenter presenter;

        public TreeSmartPart()
        {
            InitializeComponent();

            presenter = new TreePresenter(this);
        }

        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            CurrentNode = e.Node;
            presenter.ExpandNode();
        }

        public TreeNode CurrentNode
        {
            get { return treeView.SelectedNode ;}
            set { treeView.SelectedNode = value; }
        }

        public void AddNodes(string[] nodes)
        {
            TreeNode[] tn = new TreeNode[nodes.Length];

            for(int i =0; i < nodes.Length; i++)
            {
                tn[i] = new TreeNode(nodes[i], new TreeNode[] { new TreeNode("") });
            }

            treeView.SelectedNode.Nodes.Clear();
            treeView.SelectedNode.Nodes.AddRange(tn);
        }
    }
}
