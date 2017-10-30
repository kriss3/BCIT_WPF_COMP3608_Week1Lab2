﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BCIT_WPF_COMP3608_Week1Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (FontFamily f in Fonts.SystemFontFamilies)
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = f.ToString();
                lbi.FontFamily = f;
                listBox1.Items.Add(lbi);
            }

        }

        private void btnBold_Click(object sender, RoutedEventArgs e)
        {
            var selection = richTextBox1.Selection.GetPropertyValue(FontWeightProperty).ToString();
            if (selection.Equals("Bold"))
                richTextBox1.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Normal);
            else
                richTextBox1.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
        }

        private void btnItalic_Click(object sender, RoutedEventArgs e)
        {
            var selection = richTextBox1.Selection.GetPropertyValue(FontStyleProperty).ToString();
            if (selection.Equals("Italic"))
                richTextBox1.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Normal);
            else
                richTextBox1.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
        }

        private void fontSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                richTextBox1.Selection.ApplyPropertyValue(FontSizeProperty, fontSlider.Value.ToString());
            }
            catch { }
            //{
                //MessageBox.Show(ex.Message,"Error Occured",MessageBoxButton.OK,MessageBoxImage.Error);
                //throw;
            //}
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            richTextBox1.Selection.ApplyPropertyValue(FontFamilyProperty, ((ListBoxItem)listBox1.SelectedItem).FontFamily);
        }
    }
}
