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
using BL;
using BO;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for UserControlCarros.xaml
    /// </summary>
    public partial class UserControlCarros : UserControl
    {
        BusinessLayer bl;

        public UserControlCarros(BusinessLayer bl)
        {
            this.bl = bl;
            InitializeComponent();
            LoadComboBoxData();
        }
        
        /// <summary>
        /// Metodo para carregar os dados na ComboBox
        /// </summary>
        private void LoadComboBoxData()
        {
            IDComboBox.ItemsSource = bl.Concessionarios();
        }

        /// <summary>
        /// Metodo para permitir controlar a lista com a roda do rato
        /// </summary>
        private void ListaCarros_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        /// <summary>
        /// Metodo para carregar os dados na lista conforme a opçao escolhida na ComboBox
        /// </summary>
        private void IDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = ((Concessionario)IDComboBox.SelectedItem).Id;

            ListaCarros.ItemsSource = bl.ListaCarros(id);
            ListaCarros.Items.Refresh();
        }

        /// <summary>
        /// Metodo para abrir a janela de inscriçao de um novo carro
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (IDComboBox.SelectedItem != null)
            {
                UserControls.AddCarro ficha = new UserControls.AddCarro(bl, ((Concessionario)IDComboBox.SelectedItem).Id);
                ListaCarros.Items.Refresh();
                ficha.Show();
            }
        }


        /// <summary>
        /// Metodo para remover item selecionado na lista
        /// </summary>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListaCarros.SelectedItem != null && IDComboBox.SelectedItem != null)
            {
                bl.DeleteCarro(((Carro)ListaCarros.SelectedItem).Vin);
            }
            ListaCarros.Items.Refresh();
        }
    }
}
