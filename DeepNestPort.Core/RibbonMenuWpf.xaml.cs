﻿using DeepNestLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace DeepNestPort.Core
{
    /// <summary>
    /// Interaction logic for RibbonMenuWpf.xaml
    /// </summary>
    public partial class RibbonMenuWpf : System.Windows.Controls.UserControl
    {
        public RibbonMenuWpf()
        {
            InitializeComponent();
            RibbonWin.SelectionChanged += RibbonWin_SelectionChanged;
            RibbonWin.KeyDown += RibbonWin_KeyDown;
            
        }

        private void RibbonWin_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                if (RibbonWin.SelectedIndex != RibbonWin.Items.Count - 1)
                {
                    RibbonWin.SelectedIndex++;
                }
                else
                {
                    RibbonWin.SelectedIndex = 0;
                }
            }
        }

        public event Action TabChanged;
        private void RibbonWin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabChanged?.Invoke();            
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            Form1.Form.AddDetail();
        }
        private void Run_Click(object sender, RoutedEventArgs e)
        {
            Form1.Form.RunNest();
        }

        private void RibbonButton_Click_1(object sender, RoutedEventArgs e)
        {
            Form1.Form.StopNesting();
        }

        private void RibbonButton_Click_2(object sender, RoutedEventArgs e)
        {
            Form1.Form.Export();
        }
    }
}