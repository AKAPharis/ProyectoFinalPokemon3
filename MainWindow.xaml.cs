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

namespace ProyectoFinalPokemon3
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInicio_MouseEnter(object sender, MouseEventArgs e)
        {

            

        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            SeleccionPoke seleccionPoke = new SeleccionPoke();
            seleccionPoke.Show();
            this.Close();
        }
    }
}
