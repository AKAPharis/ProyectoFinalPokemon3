using System;
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
using System.Windows.Shapes;

namespace ProyectoFinalPokemon3
{
    /// <summary>
    /// Lógica de interacción para CambioPokemon.xaml
    /// </summary>
    public partial class CambioPokemon : Window
    {
        int[] ID = new int[6];

        public CambioPokemon()
        {
            InitializeComponent();
            

        }

        public void setArrayId(int[] arrayId)
        {
            ID = arrayId;
       
            imgPokeEleccion1.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + ID[0] + ".png", UriKind.Relative));
            imgPokeEleccion2.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + ID[1] + ".png", UriKind.Relative));
            imgPokeEleccion3.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + ID[2] + ".png", UriKind.Relative));
            imgPokeEleccion4.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + ID[3] + ".png", UriKind.Relative));
            imgPokeEleccion5.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + ID[4] + ".png", UriKind.Relative));
            imgPokeEleccion6.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + ID[5] + ".png", UriKind.Relative)); 
        }

        private void btnOpcion1_Click(object sender, RoutedEventArgs e)
        {
            Combate ventanaCombate = new Combate();
            if (ventanaCombate.pokeIdActual != ID[0])
            {
                ventanaCombate.z = 0;
                ventanaCombate.InicializacionDeMovPokesUser(ID[ventanaCombate.z]);
                ventanaCombate.InicializacionPokeUser(ventanaCombate.z, ID[ventanaCombate.z]);
                ventanaCombate.SaludActualPoke[ventanaCombate.z] = ventanaCombate.SaludPoke[ventanaCombate.z];
                ventanaCombate.barraVidaUser.Value = ventanaCombate.SaludActualPoke[ventanaCombate.z];

            }

            this.Close();
            ventanaCombate.Show();


        }

        private void btnOpcion2_Click(object sender, RoutedEventArgs e)
        {
            Combate ventanaCombate = new Combate();
            if (ventanaCombate.pokeIdActual != ID[1])
            {
                ventanaCombate.z = 1;
                ventanaCombate.InicializacionDeMovPokesUser(ID[ventanaCombate.z]);
                ventanaCombate.InicializacionPokeUser(ventanaCombate.z, ID[ventanaCombate.z]);
                ventanaCombate.SaludActualPoke[ventanaCombate.z] = ventanaCombate.SaludPoke[ventanaCombate.z];
                ventanaCombate.barraVidaUser.Value = ventanaCombate.SaludActualPoke[ventanaCombate.z];

            }

            this.Close();
            ventanaCombate.Show();
        }

        private void btnOpcion3_Click(object sender, RoutedEventArgs e)
        {
            Combate ventanaCombate = new Combate();
            if (ventanaCombate.pokeIdActual != ID[2])
            {
                ventanaCombate.z = 2;
                ventanaCombate.InicializacionDeMovPokesUser(ID[ventanaCombate.z]);
                ventanaCombate.InicializacionPokeUser(ventanaCombate.z, ID[ventanaCombate.z]);
                ventanaCombate.SaludActualPoke[ventanaCombate.z] = ventanaCombate.SaludPoke[ventanaCombate.z];

                ventanaCombate.barraVidaUser.Value = ventanaCombate.SaludActualPoke[ventanaCombate.z];

            }

            this.Close();
            ventanaCombate.Show();
        }

        private void btnOpcion4_Click(object sender, RoutedEventArgs e)
        {
            Combate ventanaCombate = new Combate();
            if (ventanaCombate.pokeIdActual != ID[3])
            {
                ventanaCombate.z = 3;
                ventanaCombate.InicializacionDeMovPokesUser(ID[ventanaCombate.z]);
                ventanaCombate.InicializacionPokeUser(ventanaCombate.z, ID[ventanaCombate.z]);
                ventanaCombate.SaludActualPoke[ventanaCombate.z] = ventanaCombate.SaludPoke[ventanaCombate.z];

                ventanaCombate.barraVidaUser.Value = ventanaCombate.SaludActualPoke[ventanaCombate.z];

            }

            this.Close();
            ventanaCombate.Show();
        }

        private void btnOpcion5_Click(object sender, RoutedEventArgs e)
        {
            Combate ventanaCombate = new Combate();
            if (ventanaCombate.pokeIdActual != ID[4])
            {
                ventanaCombate.z = 4;
                ventanaCombate.InicializacionDeMovPokesUser(ID[ventanaCombate.z]);
                ventanaCombate.InicializacionPokeUser(ventanaCombate.z, ID[ventanaCombate.z]);
                ventanaCombate.SaludActualPoke[ventanaCombate.z] = ventanaCombate.SaludPoke[ventanaCombate.z];

                ventanaCombate.barraVidaUser.Value = ventanaCombate.SaludActualPoke[ventanaCombate.z];

            }

            this.Close();
            ventanaCombate.Show();
        }

        private void btnOpcion6_Click(object sender, RoutedEventArgs e)
        {
            Combate ventanaCombate = new Combate();
            if (ventanaCombate.pokeIdActual != ID[5])
            {
                ventanaCombate.z = 5;
                ventanaCombate.InicializacionDeMovPokesUser(ID[ventanaCombate.z]);
                ventanaCombate.InicializacionPokeUser(ventanaCombate.z, ID[ventanaCombate.z]);
                ventanaCombate.SaludActualPoke[ventanaCombate.z] = ventanaCombate.SaludPoke[ventanaCombate.z];

                ventanaCombate.barraVidaUser.Value = ventanaCombate.SaludActualPoke[ventanaCombate.z];

            }

            this.Close();
            ventanaCombate.Show();
        }

        private void btnVolverCambio_Click(object sender, RoutedEventArgs e)
        {
            Combate ventanaCombate = new Combate();
            this.Close();
            ventanaCombate.Show(); 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnOpcion1.IsHitTestVisible = true;
            btnOpcion2.IsHitTestVisible = true;
            btnOpcion3.IsHitTestVisible = true;
            btnOpcion4.IsHitTestVisible = true;
            btnOpcion5.IsHitTestVisible = true;
            btnOpcion6.IsHitTestVisible = true;
            btnVolverCambio.IsHitTestVisible = true;

        }
    }
}
