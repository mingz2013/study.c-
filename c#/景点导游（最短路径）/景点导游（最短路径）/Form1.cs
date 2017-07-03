using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;//变长数组arrarylist
namespace 景点导游_最短路径_
{
    //窗口类
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
    //边类
    public class Edge
    {
        public int StartNodeID;
        public int EndNodeID;
        public double Weight; //权值，代价        
    }
    //节点类
    public class Node
    {
        public int ID;
       // public string Name;//景点名称
       // public string Info;//景点介绍
    }
    //图类
    public class Graph
    {
        int[,] Graph = new int[10,10];

        // 初始化拓扑图
       
        public void Init()
        {
            //节点
           Node anode=new Node() ;
           anode.ID = 1;
           Node bnode = new Node();
           bnode.ID = 2;
           Node cnode = new Node();
           cnode.ID = 3;
           Node dnode = new Node();
           dnode.ID = 4;
           Node enode = new Node();
           enode.ID = 5;
           Node fnode = new Node();
           fnode.ID = 6;
           Node gnode = new Node();
           gnode.ID = 7;
           Node hnode = new Node();
           hnode.ID = 8;
           Node inode = new Node();
           inode.ID = 9;
           Node jnode = new Node();
           jnode.ID = 0;
            //边
           Graph[1, 2] = 100;
           Graph[2, 3] = 200; Graph[2, 6] = 100;
           Graph[3, 4] = 200;
           Graph[4, 5] = 100;
           Graph[5, 6] = 50;Graph[5, 8] = 50;
           Graph[6, 7] = 100;
           Graph[7, 0] = 300;
           Graph[8, 9] = 150; Graph[8, 0] = 200;
        }


        //图的最短路径算法
        public void ShortestPath(Node StartNode,Node LastNode)
        {
            //int[] Path;//存放路径
            //Path[0] = StartNode.ID;
            ArrayList Pash = new ArrayList();
            Pash.Add(StartNode .ID );










 
        }
    }

   




}
