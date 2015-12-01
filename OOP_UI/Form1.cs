using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Root
            TreeNode node = new TreeNode("DesignPatterns");
            treeView1.Nodes.Add(node);
            // All Types
            Type[] types = Assembly.Load("DesignPatterns").GetTypes();
            var list = types.Select(t => t.Namespace).Distinct().Where(t => t != null);
            foreach (var item in list)
            {
                // Create Pattern Node for tree
                TreeNode PatternGroupNode = new TreeNode(item);

                // Add Patterns to Tree as Sub
                var PatternUsages = types.Where(t => t.Name.StartsWith("Usage") && t.Namespace.Contains(item)).Select(t => t.Name);
                foreach (var patternUsage in PatternUsages)
                {
                    PatternGroupNode.Nodes.Add(patternUsage, patternUsage);
                }
                // Add NameSpaces to Tree
                treeView1.Nodes[0].Nodes.Add(PatternGroupNode);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // No chieldren then run class ext.
            if (e.Node.FullPath.EndsWith(e.Node.Text))
            {
                // var a = GangOfFour.Structural.UsageAdapter.UsageMethod();
                //tempClass.GetMethod("Run", BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
                //          GangOfFour.Structural.UsageAdapter
                //DesignPatterns\GangOfFour.Structural\UsageAdapter
                string assName = string.Join(".", e.Node.FullPath.Split('\\').Skip(1));
                Type.GetType(assName).GetMethod("UsageMethod").Invoke(null, null);
                myInvoke(assName, "UsageMethod");
                var ass = new AssemblyName(assName);
                
                Type asseblyType = ass.GetType();
                var secilenPattern = Activator.CreateInstance(asseblyType);
                Type patternType = secilenPattern.GetType();
                //Invoke<asseblyType>();
                MethodInfo mi = patternType.GetMethod("UsageMethod", BindingFlags.NonPublic | BindingFlags.Instance);
                var result = mi.Invoke(secilenPattern, null);
                //  ass.GetType().GetMethod(assName.Split('.').Last()).Invoke(null, null);
            }

        }
        public void myInvoke<T>() where T : new()
        {
            T instance = new T();
            MethodInfo method = typeof(T).GetMethod("UsageMethod");
            method.Invoke(instance, null);
        }
        public void myInvoke(string typeName, string methodName)
        {
            Type type = Type.GetType(typeName);
            object instance = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod(methodName);
            method.Invoke(instance, null);
        }
    }
}
