using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Configuration;

namespace ProyectoFinalPokemon3
{
    /// <summary>
    /// Lógica de interacción para SeleccionPoke.xaml
    /// </summary>
    public partial class SeleccionPoke : Window
    {
        bool subido = false, btnEleccionPoke1 = false, btnEleccionPoke2 = false, btnEleccionPoke3 = false, btnEleccionPoke4 = false, btnEleccionPoke5 = false, btnEleccionPoke6 = false, presionado = false;

        

        int poke1 = 1;
        int poke2 = 2;
        int poke3 = 3;
        int poke4 = 4;
        int poke5 = 5;
        int poke6 = 6;

        

        public int[] pokeId = new int[6];
        public int[] pokeIdEne = new int[6];
        Random numeroRandom = new Random();

        BitmapImage imagen1 = new BitmapImage();
        BitmapImage imagen2 = new BitmapImage();
        BitmapImage imagen3 = new BitmapImage();
        BitmapImage imagen4 = new BitmapImage();
        BitmapImage imagen5 = new BitmapImage();
        BitmapImage imagen6 = new BitmapImage();

        string connecionString = ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString;// User ID=DESKTOP-B3CE0A4\baez_;Password=Ch19102004@#$";

        public int[] getPokeId()
        {
             return pokeId; 
        } 

        public SeleccionPoke()
        {
            InitializeComponent();

            imagen1 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke1 + ".png", UriKind.Relative));
            imagen2 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke2 + ".png", UriKind.Relative));
            imagen3 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke3 + ".png", UriKind.Relative));
            imagen4 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke4 + ".png", UriKind.Relative));
            imagen5 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke5 + ".png", UriKind.Relative));
            imagen6 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke6 + ".png", UriKind.Relative));

            pokeBox1.Source = imagen1;
            pokeBox2.Source = imagen2;
            pokeBox3.Source = imagen3;
            pokeBox4.Source = imagen4;
            pokeBox5.Source = imagen5;
            pokeBox6.Source = imagen6;

           
           

        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (poke1 < 151)
            {
                poke1 = poke1 + 6;
                poke2 = poke2 + 6;
                poke3 = poke3 + 6;
                poke4 = poke4 + 6;
                poke5 = poke5 + 6;
                poke6 = poke6 + 6;

            }
            else
            {
                poke1 = 1;
                poke2 = 2;
                poke3 = 3;
                poke4 = 4;
                poke5 = 5;
                poke6 = 6;
            }


            imagen1 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke1 + ".png", UriKind.Relative));
            imagen2 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke2 + ".png", UriKind.Relative));
            imagen3 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke3 + ".png", UriKind.Relative));
            imagen4 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke4 + ".png", UriKind.Relative));
            imagen5 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke5 + ".png", UriKind.Relative));
            imagen6 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke6 + ".png", UriKind.Relative));


            pokeBox1.Source = imagen1;
            pokeBox2.Source = imagen2;
            pokeBox3.Source = imagen3;
            pokeBox4.Source = imagen4;
            pokeBox5.Source = imagen5;
            pokeBox6.Source = imagen6;










        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            if (poke1 > 1)
            {
                poke1 = poke1 - 6;
                poke2 = poke2 - 6;
                poke3 = poke3 - 6;
                poke4 = poke4 - 6;
                poke5 = poke5 - 6;
                poke6 = poke6 - 6;

            }
            else
            {
                poke1 = 151;
                poke2 = 152;
                poke3 = 153;
                poke4 = 154;
                poke5 = 155;
                poke6 = 156;
            }

            imagen1 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke1 + ".png", UriKind.Relative));
            imagen2 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke2 + ".png", UriKind.Relative));
            imagen3 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke3 + ".png", UriKind.Relative));
            imagen4 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke4 + ".png", UriKind.Relative));
            imagen5 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke5 + ".png", UriKind.Relative));
            imagen6 = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke6 + ".png", UriKind.Relative));


            pokeBox1.Source = imagen1;
            pokeBox2.Source = imagen2;
            pokeBox3.Source = imagen3;
            pokeBox4.Source = imagen4;
            pokeBox5.Source = imagen5;
            pokeBox6.Source = imagen6;


        }

        public void MovimientoImagen(int num)
        {
            DoubleAnimation animacionY = new DoubleAnimation();
            animacionY.From = 0;  // posición inicial
            animacionY.To = -20;  // posición final
            animacionY.Duration = TimeSpan.FromSeconds(0.45);  // duración de la animación
            animacionY.RepeatBehavior = RepeatBehavior.Forever; // hacer la animación infinita

            TranslateTransform transform = new TranslateTransform();

            if (num == 1)
                pokeBox1.RenderTransform = transform;
            if (num == 2)
                pokeBox2.RenderTransform = transform;
            if (num == 3)
                pokeBox3.RenderTransform = transform;
            if (num == 4)
                pokeBox4.RenderTransform = transform;
            if (num == 5)
                pokeBox5.RenderTransform = transform;
            if (num == 6)
                pokeBox6.RenderTransform = transform;



            transform.BeginAnimation(TranslateTransform.YProperty, animacionY);
            


        }

        public void MovimientoEmpezar()
        {
            DoubleAnimation animacionY = new DoubleAnimation();
            animacionY.From = 5;  // posición inicial
            animacionY.To = -5;  // posición final
            animacionY.Duration = TimeSpan.FromSeconds(1);  // duración de la animación
            animacionY.RepeatBehavior = RepeatBehavior.Forever; // hacer la animación infinita

            TranslateTransform transform = new TranslateTransform();

            lblEmpezar.RenderTransform = transform;
            transform.BeginAnimation(TranslateTransform.YProperty, animacionY);

        }

        public void DetenerEmpezar()
        {
            lblEmpezar.RenderTransform.BeginAnimation(TranslateTransform.YProperty, null);
        }



        public void DetenerAnimacion(int num)
        {
            if (num == 1)
                pokeBox1.RenderTransform.BeginAnimation(TranslateTransform.YProperty, null);
            if (num == 2)
                pokeBox2.RenderTransform.BeginAnimation(TranslateTransform.YProperty, null);
            if (num == 3)
                pokeBox3.RenderTransform.BeginAnimation(TranslateTransform.YProperty, null);
            if (num == 4)
                pokeBox4.RenderTransform.BeginAnimation(TranslateTransform.YProperty, null);
            if (num == 5)
                pokeBox5.RenderTransform.BeginAnimation(TranslateTransform.YProperty, null);
            if (num == 6)
                pokeBox6.RenderTransform.BeginAnimation(TranslateTransform.YProperty, null);
        }

        public void definicionDeIdPokeEne()
        {
            for (int x = 0; x <= 5; x++)
            {        
                pokeIdEne[x] = numeroRandom.Next(1, 151);

            }


        }




        private void btnEleccion1_MouseEnter(object sender, MouseEventArgs e)
        {
            if (btnEleccionPoke1 == false)
                MovimientoImagen(1);

        }

        private void btnEleccion2_MouseEnter(object sender, MouseEventArgs e)
        {
            if ( btnEleccionPoke2 == false)
            MovimientoImagen(2);

        }

        private void btnEleccion3_MouseEnter(object sender, MouseEventArgs e)
        {
            if (btnEleccionPoke3 == false)
            MovimientoImagen(3);

        }

        private void btnEleccion4_MouseEnter(object sender, MouseEventArgs e)
        {
            if (btnEleccionPoke4 == false)
                MovimientoImagen(4);

        }

        private void btnEleccion5_MouseEnter(object sender, MouseEventArgs e)
        {
            if (btnEleccionPoke5 == false)
                MovimientoImagen(5);

        }

        private void btnEleccion6_MouseEnter(object sender, MouseEventArgs e)
        {
            if (btnEleccionPoke6 == false)
                MovimientoImagen(6);

        }

        private void btnEleccion6_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnEleccionPoke6 == false)
                DetenerAnimacion(6);

        }

        private void btnEleccion5_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnEleccionPoke5 == false)
                DetenerAnimacion(5);

        }

        private void btnEleccion4_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnEleccionPoke4 == false)
                DetenerAnimacion(4);

        }

        private void btnEleccion3_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnEleccionPoke3 == false)
                DetenerAnimacion(3);

        }

        private void btnEleccion2_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnEleccionPoke2 == false)
                DetenerAnimacion(2);

        }

        private void btnEleccion1_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnEleccionPoke1 == false)
            DetenerAnimacion(1);
        }

        private void btnPanelEquipo_Click(object sender, RoutedEventArgs e)
        {


        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            if (subido == true)
            {
                Thickness currentMargin = equipoPanel.Margin;

                currentMargin.Top += 650;


                equipoPanel.Margin = currentMargin;
            }


            subido = false;

            btnEleccion1.IsHitTestVisible = true;
            btnEleccion2.IsHitTestVisible = true;
            btnEleccion3.IsHitTestVisible = true;
            btnEleccion4.IsHitTestVisible = true;
            btnEleccion5.IsHitTestVisible = true;
            btnEleccion6.IsHitTestVisible = true;
        }

        //ANIMACION DE LOS POKEMONS
        private void btnPanelEquipo_MouseEnter(object sender, MouseEventArgs e)
        {
            if (subido == false)
            {
                Thickness currentMargin = equipoPanel.Margin;

                currentMargin.Top -= 650;


                equipoPanel.Margin = currentMargin;
            }

            btnEleccion1.IsHitTestVisible = false;
            btnEleccion2.IsHitTestVisible = false;
            btnEleccion3.IsHitTestVisible = false;
            btnEleccion4.IsHitTestVisible = false;
            btnEleccion5.IsHitTestVisible = false;
            btnEleccion6.IsHitTestVisible = false;
            subido = true;
        }

        //BOTON 1 DEL PANEL DE EQUIPO

        private void btnPokeEquipo1_Click(object sender, RoutedEventArgs e)
        {
            

            if (btnEleccionPoke1 == true)
            {
                ImagenBotonPoke1.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke1 + ".png", UriKind.Relative));
                pokeId[0] = poke1;

            }

            if (btnEleccionPoke2 == true)
            {
                ImagenBotonPoke1.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke2 + ".png", UriKind.Relative));
                pokeId[0] = poke2;

            }

            if (btnEleccionPoke3 == true)
            {
                ImagenBotonPoke1.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke3 + ".png", UriKind.Relative));
                pokeId[0] = poke3;


            }

            if (btnEleccionPoke4 == true)
            {
                ImagenBotonPoke1.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke4 + ".png", UriKind.Relative));
                pokeId[0] = poke4;

            }

            if (btnEleccionPoke5 == true)
            {
                ImagenBotonPoke1.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke5 + ".png", UriKind.Relative));
                pokeId[0] = poke5;

            }

            if (btnEleccionPoke6 == true)
            {
                ImagenBotonPoke1.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke6 + ".png", UriKind.Relative));
                pokeId[0] = poke6;

            }

        }

        //BOTON 2 DEL PANEL DE EQUIPO


        private void btnPokeEquipo2_Click(object sender, RoutedEventArgs e)
        {
            if (btnEleccionPoke1 == true)
            {
                ImagenBotonPoke2.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke1 + ".png", UriKind.Relative));
                pokeId[1] = poke1;

            }

            if (btnEleccionPoke2 == true)
            {
                ImagenBotonPoke2.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke2 + ".png", UriKind.Relative));
                pokeId[1] = poke2;

            }

            if (btnEleccionPoke3 == true)
            {
                ImagenBotonPoke2.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke3 + ".png", UriKind.Relative));
                pokeId[1] = poke3;


            }

            if (btnEleccionPoke4 == true)
            {
                ImagenBotonPoke2.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke4 + ".png", UriKind.Relative));
                pokeId[1] = poke4;

            }

            if (btnEleccionPoke5 == true)
            {
                ImagenBotonPoke2.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke5 + ".png", UriKind.Relative));
                pokeId[1] = poke5;

            }

            if (btnEleccionPoke6 == true)
            {
                ImagenBotonPoke2.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke6 + ".png", UriKind.Relative));
                pokeId[1] = poke6;

            }

        }
        //BOTON 3 DEL PANEL DE EQUIPO



        private void btnPokeEquipo3_Click(object sender, RoutedEventArgs e)
        {
            if (btnEleccionPoke1 == true)
            {
                ImagenBotonPoke3.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke1 + ".png", UriKind.Relative));
                pokeId[2] = poke1;

            }

            if (btnEleccionPoke2 == true)
            {
                ImagenBotonPoke3.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke2 + ".png", UriKind.Relative));
                pokeId[2] = poke2;

            }

            if (btnEleccionPoke3 == true)
            {
                ImagenBotonPoke3.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke3 + ".png", UriKind.Relative));
                pokeId[2] = poke3;


            }

            if (btnEleccionPoke4 == true)
            {
                ImagenBotonPoke3.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke4 + ".png", UriKind.Relative));
                pokeId[2] = poke4;

            }

            if (btnEleccionPoke5 == true)
            {
                ImagenBotonPoke3.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke5 + ".png", UriKind.Relative));
                pokeId[2] = poke5;

            }

            if (btnEleccionPoke6 == true)
            {
                ImagenBotonPoke3.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke6 + ".png", UriKind.Relative)); 
                pokeId[2] = poke6;

            }



        }

        //BOTON 4 DEL PANEL DE EQUIPO


        private void btnPokeEquipo4_Click(object sender, RoutedEventArgs e)
        {
            if (btnEleccionPoke1 == true)
            {
                ImagenBotonPoke4.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke1 + ".png", UriKind.Relative));
                pokeId[3] = poke1;

            }

            if (btnEleccionPoke2 == true)
            {
                ImagenBotonPoke4.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke2 + ".png", UriKind.Relative));
                pokeId[3] = poke2;

            }

            if (btnEleccionPoke3 == true)
            {
                ImagenBotonPoke4.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke3 + ".png", UriKind.Relative));
                pokeId[3] = poke3;


            }

            if (btnEleccionPoke4 == true)
            {
                ImagenBotonPoke4.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke4 + ".png", UriKind.Relative));
                pokeId[3] = poke4;

            }

            if (btnEleccionPoke5 == true)
            {
                ImagenBotonPoke4.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke5 + ".png", UriKind.Relative));
                pokeId[3] = poke5;

            }

            if (btnEleccionPoke6 == true)
            {
                ImagenBotonPoke4.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke6 + ".png", UriKind.Relative));
                pokeId[3] = poke6;

            }


        }
        //BOTON 5 DEL PANEL DE EQUIPO



        private void btnPokeEquipo5_Click(object sender, RoutedEventArgs e)
        {
            if (btnEleccionPoke1 == true)
            {
                ImagenBotonPoke5.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke1 + ".png", UriKind.Relative));
                pokeId[4] = poke1;

            }

            if (btnEleccionPoke2 == true)
            {
                ImagenBotonPoke5.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke2 + ".png", UriKind.Relative));
                pokeId[4] = poke2;

            }

            if (btnEleccionPoke3 == true)
            {
                ImagenBotonPoke5.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke3 + ".png", UriKind.Relative));
                pokeId[4] = poke3;


            }

            if (btnEleccionPoke4 == true)
            {
                ImagenBotonPoke5.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke4 + ".png", UriKind.Relative));
                pokeId[4] = poke4;

            }

            if (btnEleccionPoke5 == true)
            {
                ImagenBotonPoke5.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke5 + ".png", UriKind.Relative));
                pokeId[4] = poke5;

            }

            if (btnEleccionPoke6 == true)
            {
                ImagenBotonPoke5.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke6 + ".png", UriKind.Relative));
                pokeId[4] = poke6;

            }

        }
        //BOTON 6 DEL PANEL DE EQUIPO


        private void btnPokeEquipo6_Click(object sender, RoutedEventArgs e)
        {
            if (btnEleccionPoke1 == true)
            {
                ImagenBotonPoke6.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke1 + ".png", UriKind.Relative));
                pokeId[5] = poke1;

            }

            if (btnEleccionPoke2 == true)
            {
                ImagenBotonPoke6.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke2 + ".png", UriKind.Relative));
                pokeId[5] = poke2;

            }

            if (btnEleccionPoke3 == true)
            {
                ImagenBotonPoke6.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke3 + ".png", UriKind.Relative));
                pokeId[5] = poke3;


            }

            if (btnEleccionPoke4 == true)
            {
                ImagenBotonPoke6.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke4 + ".png", UriKind.Relative));
                pokeId[5] = poke4;

            }

            if (btnEleccionPoke5 == true)
            {
                ImagenBotonPoke6.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke5 + ".png", UriKind.Relative));
                pokeId[5] = poke5;

            }

            if (btnEleccionPoke6 == true)
            {
                ImagenBotonPoke6.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + poke6 + ".png", UriKind.Relative));
                pokeId[5] = poke6;

            }

        }

        private void btnEmpezar_MouseEnter(object sender, MouseEventArgs e)
        {
            if (presionado == false)
                MovimientoEmpezar();
        }

        private void btnEmpezar_MouseLeave(object sender, MouseEventArgs e)
        {
            if(presionado == false)
            DetenerEmpezar();
        }

        

        private void btnEmpezar_Click(object sender, RoutedEventArgs e)
        {
            if (presionado == false)
            {
                DetenerEmpezar();
                Thickness marginEmpezar = lblEmpezar.Margin;
                marginEmpezar.Top -= 10;
                lblEmpezar.Margin = marginEmpezar;
            }
            
             presionado = true;

            Combate combate = new Combate();
            definicionDeIdPokeEne();
            combate.setArrayIdEne(pokeIdEne);
            combate.setArrayId(pokeId);
            combate.Show();
            this.Close();


        }



        //CLICK EN LOS POKEMONES PARA LA SELECCION DE LOS MISMOS

        private void btnEleccion1_Click(object sender, RoutedEventArgs e)
        {
            MovimientoImagen(1);
            Thickness marginBtn6 = pokeBox6.Margin;
            Thickness marginBtn5 = pokeBox5.Margin;
            Thickness marginBtn4 = pokeBox4.Margin;
            Thickness marginBtn3 = pokeBox3.Margin;
            Thickness marginBtn2 = pokeBox2.Margin;
            Thickness marginBtn1 = pokeBox1.Margin;
            if (btnEleccionPoke1 == false)
            {
                marginBtn1.Top -= 20;
                pokeBox1.Margin = marginBtn1;
                btnEleccion1.Margin = marginBtn1;
            }


            if (btnEleccionPoke2 == true)
            {
                DetenerAnimacion(2);

                marginBtn2.Top += 20;
                pokeBox2.Margin = marginBtn2;
                btnEleccion2.Margin = marginBtn2;
            }

            if (btnEleccionPoke3 == true)
            {
                DetenerAnimacion(3);

                marginBtn3.Top += 20;
                pokeBox3.Margin = marginBtn3;
                btnEleccion3.Margin = marginBtn3;
            }

            if (btnEleccionPoke4 == true)
            {
                DetenerAnimacion(4);

                marginBtn4.Top += 20;
                pokeBox4.Margin = marginBtn4;
                btnEleccion4.Margin = marginBtn4;

            }
            if (btnEleccionPoke5 == true)
            {
                DetenerAnimacion(5);

                marginBtn5.Top += 20;
                pokeBox5.Margin = marginBtn5;
                btnEleccion5.Margin = marginBtn5;

            }
            if (btnEleccionPoke6 == true)
            {
                DetenerAnimacion(6);

                marginBtn6.Top += 20;
                pokeBox6.Margin = marginBtn6;
                btnEleccion6.Margin = marginBtn6;

            }

            btnEleccionPoke1 = true;
            btnEleccionPoke2 = false;
            btnEleccionPoke3 = false;
            btnEleccionPoke4 = false;
            btnEleccionPoke5 = false;
            btnEleccionPoke6 = false;
            e.Handled = true;

           
        }

        private void btnEleccion2_Click(object sender, RoutedEventArgs e)
        {
            MovimientoImagen(2);

            Thickness marginBtn6 = pokeBox6.Margin;
            Thickness marginBtn5 = pokeBox5.Margin;
            Thickness marginBtn4 = pokeBox4.Margin;
            Thickness marginBtn3 = pokeBox3.Margin;
            Thickness marginBtn2 = pokeBox2.Margin;
            Thickness marginBtn1 = pokeBox1.Margin;
            if (btnEleccionPoke2 == false)
            {
                marginBtn2.Top -= 20;
                pokeBox2.Margin = marginBtn2;
                btnEleccion2.Margin = marginBtn2;
            }


            if (btnEleccionPoke1 == true)
            {
                DetenerAnimacion(1);

                marginBtn1.Top += 20;
                pokeBox1.Margin = marginBtn1;
                btnEleccion1.Margin = marginBtn1;
            }

            if (btnEleccionPoke3 == true)
            {
                DetenerAnimacion(3);

                marginBtn3.Top += 20;
                pokeBox3.Margin = marginBtn3;
                btnEleccion3.Margin = marginBtn3;
            }

            if (btnEleccionPoke4 == true)
            {
                DetenerAnimacion(4);

                marginBtn4.Top += 20;
                pokeBox4.Margin = marginBtn4;
                btnEleccion4.Margin = marginBtn4;

            }
            if (btnEleccionPoke5 == true)
            {
                DetenerAnimacion(5);

                marginBtn5.Top += 20;
                pokeBox5.Margin = marginBtn5;
                btnEleccion5.Margin = marginBtn5;

            }
            if (btnEleccionPoke6 == true)
            {
                DetenerAnimacion(6);

                marginBtn6.Top += 20;
                pokeBox6.Margin = marginBtn6;
                btnEleccion6.Margin = marginBtn6;

            }

            btnEleccionPoke1 = false;
            btnEleccionPoke2 = true;
            btnEleccionPoke3 = false;
            btnEleccionPoke4 = false;
            btnEleccionPoke5 = false;
            btnEleccionPoke6 = false;
            e.Handled = true;

            
        }

        private void btnEleccion3_Click(object sender, RoutedEventArgs e)
        {
            MovimientoImagen(3);


            Thickness marginBtn6 = pokeBox6.Margin;
            Thickness marginBtn5 = pokeBox5.Margin;
            Thickness marginBtn4 = pokeBox4.Margin;
            Thickness marginBtn3 = pokeBox3.Margin;
            Thickness marginBtn2 = pokeBox2.Margin;
            Thickness marginBtn1 = pokeBox1.Margin;
            if (btnEleccionPoke3 == false)
            {
                marginBtn3.Top -= 20;
                pokeBox3.Margin = marginBtn3;
                btnEleccion3.Margin = marginBtn3;
            }


            if (btnEleccionPoke2 == true)
            {
                DetenerAnimacion(2);

                marginBtn2.Top += 20;
                pokeBox2.Margin = marginBtn2;
                btnEleccion2.Margin = marginBtn2;
            }

            if (btnEleccionPoke1 == true)
            {
                DetenerAnimacion(1);

                marginBtn1.Top += 20;
                pokeBox1.Margin = marginBtn1;
                btnEleccion1.Margin = marginBtn1;
            }

            if (btnEleccionPoke4 == true)
            {
                DetenerAnimacion(4);

                marginBtn4.Top += 20;
                pokeBox4.Margin = marginBtn4;
                btnEleccion4.Margin = marginBtn4;

            }
            if (btnEleccionPoke5 == true)
            {
                DetenerAnimacion(5);

                marginBtn5.Top += 20;
                pokeBox5.Margin = marginBtn5;
                btnEleccion5.Margin = marginBtn5;

            }
            if (btnEleccionPoke6 == true)
            {
                DetenerAnimacion(6);

                marginBtn6.Top += 20;
                pokeBox6.Margin = marginBtn6;
                btnEleccion6.Margin = marginBtn6;

            }

            btnEleccionPoke1 = false;
            btnEleccionPoke2 = false;
            btnEleccionPoke3 = true;
            btnEleccionPoke4 = false;
            btnEleccionPoke5 = false;
            btnEleccionPoke6 = false;
            e.Handled = true;

            
        }
        private void btnEleccion4_Click(object sender, RoutedEventArgs e)
        {
            MovimientoImagen(4);

            Thickness marginBtn6 = pokeBox6.Margin;
            Thickness marginBtn5 = pokeBox5.Margin;
            Thickness marginBtn4 = pokeBox4.Margin;
            Thickness marginBtn3 = pokeBox3.Margin;
            Thickness marginBtn2 = pokeBox2.Margin;
            Thickness marginBtn1 = pokeBox1.Margin;
            if (btnEleccionPoke4 == false)
            {
                marginBtn4.Top -= 20;
                pokeBox4.Margin = marginBtn4;
                btnEleccion4.Margin = marginBtn4;
            }


            if (btnEleccionPoke2 == true)
            {
                DetenerAnimacion(2);

                marginBtn2.Top += 20;
                pokeBox2.Margin = marginBtn2;
                btnEleccion2.Margin = marginBtn2;
            }

            if (btnEleccionPoke3 == true)
            {
                DetenerAnimacion(4);

                marginBtn3.Top += 20;
                pokeBox3.Margin = marginBtn3;
                btnEleccion3.Margin = marginBtn3;
            }

            if (btnEleccionPoke1 == true)
            {
                DetenerAnimacion(1);

                marginBtn1.Top += 20;
                pokeBox1.Margin = marginBtn1;
                btnEleccion1.Margin = marginBtn1;

            }
            if (btnEleccionPoke5 == true)
            {
                DetenerAnimacion(5);

                marginBtn5.Top += 20;
                pokeBox5.Margin = marginBtn5;
                btnEleccion5.Margin = marginBtn5;

            }
            if (btnEleccionPoke6 == true)
            {
                DetenerAnimacion(6);

                marginBtn6.Top += 20;
                pokeBox6.Margin = marginBtn6;
                btnEleccion6.Margin = marginBtn6;

            }

            btnEleccionPoke1 = false;
            btnEleccionPoke2 = false;
            btnEleccionPoke3 = false;
            btnEleccionPoke4 = true;
            btnEleccionPoke5 = false;
            btnEleccionPoke6 = false;
            e.Handled = true;

           
        }
        private void btnEleccion5_Click(object sender, RoutedEventArgs e)
        {
            MovimientoImagen(5);

            Thickness marginBtn6 = pokeBox6.Margin;
            Thickness marginBtn5 = pokeBox5.Margin;
            Thickness marginBtn4 = pokeBox4.Margin;
            Thickness marginBtn3 = pokeBox3.Margin;
            Thickness marginBtn2 = pokeBox2.Margin;
            Thickness marginBtn1 = pokeBox1.Margin;
            if (btnEleccionPoke5 == false)
            {
                marginBtn5.Top -= 20;
                pokeBox5.Margin = marginBtn5;
                btnEleccion5.Margin = marginBtn5;
            }


            if (btnEleccionPoke2 == true)
            {
                DetenerAnimacion(2);

                marginBtn2.Top += 20;
                pokeBox2.Margin = marginBtn2;
                btnEleccion2.Margin = marginBtn2;
            }

            if (btnEleccionPoke3 == true)
            {
                DetenerAnimacion(3);

                marginBtn3.Top += 20;
                pokeBox3.Margin = marginBtn3;
                btnEleccion3.Margin = marginBtn3;
            }

            if (btnEleccionPoke4 == true)
            {
                DetenerAnimacion(4);

                marginBtn4.Top += 20;
                pokeBox4.Margin = marginBtn4;
                btnEleccion4.Margin = marginBtn4;

            }
            if (btnEleccionPoke1 == true)
            {
                DetenerAnimacion(1);

                marginBtn1.Top += 20;
                pokeBox1.Margin = marginBtn1;
                btnEleccion1.Margin = marginBtn1;

            }
            if (btnEleccionPoke6 == true)
            {
                DetenerAnimacion(6);

                marginBtn6.Top += 20;
                pokeBox6.Margin = marginBtn6;
                btnEleccion6.Margin = marginBtn6;

            }

            btnEleccionPoke1 = false;
            btnEleccionPoke2 = false;
            btnEleccionPoke3 = false;
            btnEleccionPoke4 = false;
            btnEleccionPoke5 = true;
            btnEleccionPoke6 = false;

            e.Handled = true;

        }
        private void btnEleccion6_Click(object sender, RoutedEventArgs e)
        {
            MovimientoImagen(6);

            Thickness marginBtn6 = pokeBox6.Margin;
            Thickness marginBtn5 = pokeBox5.Margin;
            Thickness marginBtn4 = pokeBox4.Margin;
            Thickness marginBtn3 = pokeBox3.Margin;
            Thickness marginBtn2 = pokeBox2.Margin;
            Thickness marginBtn1 = pokeBox1.Margin;
            if (btnEleccionPoke6 == false)
            {
                marginBtn6.Top -= 20;
                pokeBox6.Margin = marginBtn6;
                btnEleccion6.Margin = marginBtn6;
            }


            if (btnEleccionPoke2 == true)
            {
                DetenerAnimacion(2);

                marginBtn2.Top += 20;
                pokeBox2.Margin = marginBtn2;
                btnEleccion2.Margin = marginBtn2;
            }
                
            if (btnEleccionPoke3 == true)
            {
                DetenerAnimacion(3);

                marginBtn3.Top += 20;
                pokeBox3.Margin = marginBtn3;
                btnEleccion3.Margin = marginBtn3;
            }
                
            if (btnEleccionPoke4 == true)
            {
                DetenerAnimacion(4);

                marginBtn4.Top += 20;
                pokeBox4.Margin = marginBtn4;
                btnEleccion4.Margin = marginBtn4;

            }
            if (btnEleccionPoke5 == true)
            {
                DetenerAnimacion(5);

                marginBtn5.Top += 20;
                pokeBox5.Margin = marginBtn5;
                btnEleccion5.Margin = marginBtn5;

            }
            if (btnEleccionPoke1 == true)
            {
                DetenerAnimacion(1);

                marginBtn1.Top += 20;
                pokeBox1.Margin = marginBtn1;
                btnEleccion1.Margin = marginBtn1;

            }

            btnEleccionPoke1 = false;
            btnEleccionPoke2 = false;
            btnEleccionPoke3 = false;
            btnEleccionPoke4 = false;
            btnEleccionPoke5 = false;
            btnEleccionPoke6 = true;

            e.Handled = true;

            
         
            
        }

    }
}
