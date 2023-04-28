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
using System.Windows.Automation.Peers;
using System.Configuration;
using System.Data.SQLite;

namespace ProyectoFinalPokemon3
{
    /// <summary>
    /// Lógica de interacción para Combate.xaml
    /// </summary>
    public partial class Combate : Window
    {
        //        private string connectionString = @"Data Source=oscarbc\SQLSERVER;Initial Catalog=Pokemons;Integrated Security=True";// User ID=DESKTOP-B3CE0A4\baez_;Password=Ch19102004@#$";

        private string connectionString = ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString;// User ID=DESKTOP-B3CE0A4\baez_;Password=Ch19102004@#$";
        //Uri hola = new Uri();

        BitmapImage imgMov1 = new BitmapImage();
        BitmapImage imgMov2 = new BitmapImage();
        BitmapImage imgMov3 = new BitmapImage();
        BitmapImage imgMov4 = new BitmapImage();

        Random numeRandom = new Random();

   

        public int o = 0;
        public int k = 0;
        public int j = 0;
         
         
        public string[] NombrePoke = new string[6];
        public string[] TipoPoke1 = new string[6];
        public string[] TipoPoke2 = new string[6];
        public int[] SaludPoke = new int[6];
        public int[] AtaquePoke = new int[6];
        public int[] DefensaPoke = new int[6];
        public int[] Ataque_EspecialPoke = new int[6];
        public int[] Defensa_EspecialPoke = new int[6];
        public int[] VelocidadPoke = new int[6];
        public int[] SaludActualPoke = new int[6];
         
        public string[] NombrePokeEne = new string[6];
        public string[] TipoPokeEne1 = new string[6];
        public string[] TipoPokeEne2 = new string[6];
        public int[] SaludPokeEne = new int[6];
        public int[] AtaquePokeEne = new int[6];
        public int[] DefensaPokeEne = new int[6];
        public int[] Ataque_EspecialPokeEne = new int[6];
        public int[] Defensa_EspecialPokeEne = new int[6];
        public int[] VelocidadPokeEne = new int[6];
        public int[] SaludActualPokeEne = new int[6];
         
        public int h = 0;
         
        public int pokeIdActual;
        public int pokeEneIdActual;
         
        public int z = 0;
         
        public int[] ppMov1 = new int[6];
        public int[] ppMov2 = new int[6];
        public int[] ppMov3 = new int[6];
        public int[] ppMov4 = new int[6];


        BitmapImage imgTipoMovi = new BitmapImage();

        public string prueba = "Esto es una prueba";

       public string[] nombremov = new string[4];
       public string[] tipomov = new string[4];
       public int[] PP = new int[4];
       public int[] potencia = new int[4];
       public string[] medio = new string[4];

       public string[] nombremovEne = new string[4];
       public string[] tipomovEne = new string[4];
       public int[] PPEne = new int[4];
       public int[] potenciaEne = new int[4];
       public string[] medioEne = new string[4];

       public int i = 0;

        public string eficacia = "";

        public int[] pokeIdCombate = new int[6];
        public int[] pokeIdCombateEne = new int[6];

        /// <summary>
        string estadoUser = "";
        string estadoEne = "";
        int cont = 0;
        /// </summary>



        public Combate()
        {
            InitializeComponent();




        }

        public string Estado(string mov, string tipoM, string tipoE1, string tipoE2)
        {
            string estado = "";

            int prob = numeRandom.Next(1, 100);

            #region Paralisis

            if (mov == "Triataque")
            {
                if (prob <= 7)
                    estado = "Paralizado";


            }

            if (mov == "Impactrueno" || mov == "Rayo" || mov == "Puño trueno")
            {
                if (prob <= 10)
                    estado = "Paralizado";


            }

            if (mov == "Trueno" || mov == "Golpe cuerpo" || mov == "Lenüetazo")
            {
                if (prob <= 30)
                    estado = "Paralizado";


            }


            if (mov == "Paralizador" || mov == "Deslumbrar" || mov == "Onda trueno")
            {

                estado = "Paralizado";


            }
            #endregion



            #region Envenenado


            if (tipoE1 != "Veneno" && tipoE2 != "Veneno")
            {


                if (mov == "Residuos" || mov == "Picotazo veneno")
                {
                    if (prob <= 30)
                        estado = "Envenenado";
                }

                if (mov == "Polucion")
                {
                    if (prob <= 40)
                        estado = "Envenenado";
                }

                if (mov == "Polvo veneno" || mov == "Gas venenoso")
                    estado = "Envenenado";



                if (mov == "Toxico")
                {
                    if (prob <= 85)
                        estado = "Gravemente envenenado";
                }


            }


            #endregion

            #region Quemado

            if (tipoE1 != "Fuego" && tipoE2 != "Fuego")
            {

                if (mov == "Ascuas" || mov == "Lanzallamas" || mov == "Llamarada" || mov == "Puño fuego")
                {
                    if (prob <= 10)
                        estado = "Quemado";
                }



                if (mov == "Triataque")
                {
                    if (prob <= 7)
                        estado = "Quemado";


                }




            }



            #endregion

            #region Congelado

            if (tipoE1 != "Hielo" && tipoE2 != "Hielo")
            {


                if (mov == "Puño hielo" || mov == "Ventisca" || mov == "Rayo hielo")
                {
                    if (prob <= 10)
                        estado = "Congelado";
                }

                if (mov == "Triataque")
                {
                    if (prob <= 7)
                        estado = "Congelado";


                }







            }



            #endregion


            #region Dormido

            if (mov == "Beso amoroso" || mov == "Espora" || mov == "Canto" || mov == "Somnifero" || mov == "Hipnosis")
                estado = "dormido";





            #endregion

            #region Confuso
            if (mov == "Confusion" || mov == "Psicorrayo")
            {
                if (prob <= 10)
                    estado = "Confundido";
            }

            if (mov == "Puño mareo")
            {
                if (prob <= 20)
                    estado = "Confundido";
            }
            if (mov == "Rayo confuso" || mov == "Supersonico")
                estado = "Confundido";

            #endregion


            #region Drenadoras

            if (tipoE1 != "Planta" && tipoE2 != "Planta")
            {
                if (mov == "Drenadoras")
                    estado = "Drenadoras";
            }




            #endregion

            #region Amedrentado

            if (mov == "Hueso palo" || mov == "Hipercolmillo")
            {
                if (prob <= 10)
                    estado = "Amedrentado";
            }
            if (mov == "Cascada")
            {

                if (prob <= 20)
                    estado = "Amedrentado";
            }
            if (mov == "Golpe cabeza" || mov == "Patada baja" || mov == "Patada giro" || mov == "Pisoton" || mov == "Avalancha" || mov == "Ataque aereo")
            {

                if (prob <= 30)
                    estado = "Amedrentado";
            }

            #endregion

            #region Atadura

            if (mov == "Atadura" || mov == "Constriccion" || mov == "Giro fuego" || mov == "Tenaza")
                estado = "Atado";


            #endregion




            return estado;
        }

        public double Eficacia(string TipoA, string TipoD1)
        {
            double e = 1;

            if (TipoA == "Agua")
            {
                if (TipoD1 == "Fuego" || TipoD1 == "Roca" || TipoD1 == "Tierra")
                {
                    e = 2;
                }
                if (TipoD1 == "Agua" || TipoD1 == "Dragon" || TipoD1 == "Planta")
                {
                    e = 0.5;
                }
            }

            if (TipoA == "Fuego")
            {
                if (TipoD1 == "Bicho" || TipoD1 == "Hielo" || TipoD1 == "Planta")
                {
                    e = 2;
                }
                if (TipoD1 == "Roca" || TipoD1 == "Dragon" || TipoD1 == "Fuego" || TipoD1 == "Agua")
                {
                    e = 0.5;
                }
            }
            if (TipoA == "Planta")
            {
                if (TipoD1 == "Agua" || TipoD1 == "Roca" || TipoD1 == "Tierra")
                {
                    e = 2;
                }
                if (TipoD1 == "Bicho" || TipoD1 == "Dragon" || TipoD1 == "Fuego" || TipoD1 == "Volador" || TipoD1 == "Planta" || TipoD1 == "Veneno")
                {
                    e = 0.5;
                }
            }
            if (TipoA == "Tierra")
            {
                if (TipoD1 == "Electrico" || TipoD1 == "Roca" || TipoD1 == "Fuego" || TipoD1 == "Veneno")
                {
                    e = 2;
                }
                if (TipoD1 == "Bicho" || TipoD1 == "Planta")
                {
                    e = 0.5;
                }
                if (TipoD1 == "Volador")
                {
                    e = 0;
                }


            }
            if (TipoA == "Roca")
            {
                if (TipoD1 == "Fuego" || TipoD1 == "Volador" || TipoD1 == "Bicho" || TipoD1 == "Hielo")
                {
                    e = 2;
                }
                if (TipoD1 == "Lucha" || TipoD1 == "Tierra")
                {
                    e = 0.5;
                }
            }
            if (TipoA == "Electrico")
            {
                if (TipoD1 == "Agua" || TipoD1 == "Volador")
                {
                    e = 2;
                }
                if (TipoD1 == "Electrico" || TipoD1 == "Planta" || TipoD1 == "Dragon")
                {
                    e = 0.5;
                }
                if (TipoD1 == "Tierra")
                {
                    e = 0;
                }
            }
            if (TipoA == "Dragon")
            {
                if (TipoD1 == "Dragon")
                {
                    e = 2;
                }

            }
            if (TipoA == "Hielo")
            {
                if (TipoD1 == "Planta" || TipoD1 == "Volador" || TipoD1 == "Dragon" || TipoD1 == "Tierra")
                {
                    e = 2;
                }
                if (TipoD1 == "Lucha" || TipoD1 == "Fuego" || TipoD1 == "Agua")
                {
                    e = 0.5;
                }
            }
            if (TipoA == "Fantasma")
            {
                if (TipoD1 == "Psiquico" || TipoD1 == "Fantasma")
                {
                    e = 2;
                }
                if (TipoD1 == "Normal")
                {
                    e = 0;
                }
            }
            if (TipoA == "Lucha")
            {
                if (TipoD1 == "Normal" || TipoD1 == "Hielo" || TipoD1 == "Roca")
                {
                    e = 2;
                }
                if (TipoD1 == "Volador" || TipoD1 == "Veneno" || TipoD1 == "Psiquico" || TipoD1 == "Bicho")
                {
                    e = 0.5;
                }
                if (TipoD1 == "Fantasma")
                {
                    e = 0;
                }

            }
            if (TipoA == "Normal")
            {
                if (TipoD1 == "Roca")
                {
                    e = 0.5;
                }
                if (TipoD1 == "Fantasma")
                {
                    e = 0;
                }
            }

            if (TipoA == "Veneno")
            {
                if (TipoD1 == "Planta")
                {
                    e = 2;
                }
                if (TipoD1 == "Fantasma" || TipoD1 == "Veneno" || TipoD1 == "Roca" || TipoD1 == "Tierra")
                {
                    e = 0.5;
                }

            }

            if (TipoA == "Bicho")
            {
                if (TipoD1 == "Planta" || TipoD1 == "Psiquico")
                {
                    e = 2;
                }
                if (TipoD1 == "Volador" || TipoD1 == "Veneno" || TipoD1 == "Fantasma" || TipoD1 == "Fuego" || TipoD1 == "Lucha")
                {
                    e = 0.5;
                }

            }

            if (TipoA == "Volador")
            {
                if (TipoD1 == "Planta" || TipoD1 == "Lucha" || TipoD1 == "Bicho")
                {
                    e = 2;
                }
                if (TipoD1 == "Electrico" || TipoD1 == "Roca")
                {
                    e = 0.5;
                }

            }

            if (TipoA == "Psiquico")
            {

                if (TipoD1 == "Veneno" || TipoD1 == "Lucha")
                {
                    e = 2;
                }
                if (TipoD1 == "Psiquico")
                {
                    e = 0.5;
                }






            }

            return e;

        }


        public double Damage(int LVL, int AtaquePA, int PotenciaPA, int DefensaPE, string TipoAPA, string TipoPA1, string TipoPA2, string TipoPE1, string TipoPE2)
        {
            double damage = 0;
            double b = 1;
            double e = 1;




            if (PotenciaPA > 0)
            {
                int v = numeRandom.Next(85, 100);

                if (TipoAPA == TipoPA1 || TipoAPA == TipoPA2)
                {
                    b = 1.5;
                }

                e = Eficacia(TipoAPA, TipoPE1) * Eficacia(TipoAPA, TipoPE2);

                if (e == 1.5)
                    eficacia = "Eficaz";

                if (e == 2)
                    eficacia = "Super Eficaz";

                if (e == 4)
                    eficacia = "Hiper Eficaz";

                if (e <= 0.75)
                    eficacia = "Poco Eficaz";

                damage = Math.Truncate(0.01 * b * e * v * ((((0.2 + LVL + 1) * AtaquePA * PotenciaPA) / (25 * DefensaPE)) + 2));

            }


            /*
                miTotalDano = 0.01 * B * miE * V * ((((0.2 + miLVL + 1) * AtaquePoke * miPoderAtaque) / (25 * eneDefensaPoke)) + 2);
                miTotalDano = Math.Truncate(miTotalDano); */


            return damage;
        }



        public void CombateB()
        {
            int paralisis = numeRandom.Next(1, 100);
            


            int atk = 0;
            int def = 0;
            double dmg = 0;
            j = numeRandom.Next(0, 3);



            if (VelocidadPoke[z] > VelocidadPokeEne[o])
            {

                if (medio[k] == "Fisico")
                {

                    atk = AtaquePoke[z];
                    def = DefensaPokeEne[o];

                }

                if (medio[k] == "Especial")
                {

                    atk = Ataque_EspecialPoke[z];
                    def = Defensa_EspecialPokeEne[o];

                }

                if (estadoUser != "Paralizado" && paralisis >= 25)
                {

                    dmg = Damage(1, atk, potencia[k], def, tipomov[k], TipoPoke1[z], TipoPoke2[z], TipoPokeEne1[o], TipoPokeEne2[o]);
                    estadoEne = Estado(nombremov[k], tipomov[k], TipoPokeEne1[o], TipoPokeEne2[o]);

                    SaludActualPokeEne[o] = SaludActualPokeEne[o] - Convert.ToInt32(dmg);
                }

                if (SaludActualPokeEne[o] > 0)
                {


                    if (medioEne[j] == "Fisico")
                    {

                        atk = AtaquePokeEne[o];
                        def = DefensaPoke[z];

                    }

                    if (medioEne[j] == "Especial")
                    {

                        atk = Ataque_EspecialPokeEne[o];
                        def = Defensa_EspecialPoke[z];

                    }

                    if (estadoEne != "Paralisis" && paralisis >= 25)
                    {
                        dmg = Damage(1, atk, potenciaEne[j], def, tipomovEne[j], TipoPokeEne1[o], TipoPokeEne2[o], TipoPoke1[z], TipoPoke2[z]);

                        SaludActualPoke[z] = SaludActualPoke[z] - Convert.ToInt32(dmg);
                        estadoUser = Estado(nombremovEne[j], tipomovEne[j], TipoPoke1[z], TipoPoke2[z]);
                    }

                }




            }


            if (VelocidadPoke[z] < VelocidadPokeEne[o])
            {


                if (medioEne[j] == "Fisico")
                {

                    atk = AtaquePokeEne[o];
                    def = DefensaPoke[z];

                }

                if (medioEne[j] == "Especial")
                {

                    atk = Ataque_EspecialPokeEne[o];
                    def = Defensa_EspecialPoke[z];

                }
                if (estadoUser != "Paralizado" && paralisis >= 25)
                {

                    dmg = Damage(1, atk, potenciaEne[j], def, tipomovEne[j], TipoPokeEne1[o], TipoPokeEne2[o], TipoPoke1[z], TipoPoke2[z]);
                    estadoUser = Estado(nombremovEne[j], tipomovEne[j], TipoPoke1[z], TipoPoke2[z]);
                }
                SaludActualPoke[z] = SaludActualPoke[z] - Convert.ToInt32(dmg);

                if (SaludActualPoke[z] > 0)
                {

                    if (medio[k] == "Fisico")
                    {

                        atk = AtaquePoke[z];
                        def = DefensaPokeEne[o];

                    }

                    if (medio[k] == "Especial")
                    {

                        atk = Ataque_EspecialPoke[z];
                        def = Defensa_EspecialPokeEne[o];

                    }

                    if (estadoUser != "Paralizado" && paralisis >= 25)
                    {
                        dmg = Damage(1, atk, potencia[k], def, tipomov[k], TipoPoke1[z], TipoPoke2[z], TipoPokeEne1[o], TipoPokeEne2[o]);

                        SaludActualPokeEne[o] = SaludActualPokeEne[o] - Convert.ToInt32(dmg);
                        estadoEne = Estado(nombremov[k], tipomov[k], TipoPokeEne1[o], TipoPokeEne2[o]);
                    }

                }

            }


            if (estadoUser == "Envenenado" || estadoUser == "Quemado")
            {
                SaludActualPoke[k] = SaludActualPoke[k] - (SaludPoke[k] / 16); 
            }

            if (estadoEne == "Envenenado" || estadoEne == "Quemado")
            {
                SaludActualPokeEne[o] = SaludActualPokeEne[o] - (SaludPokeEne[o] / 16);
            }

            if (estadoUser == "Gravemente envenenado")
            {
                
                cont++;
                SaludActualPoke[k] = SaludActualPoke[k] - (SaludPoke[k] / 16 * cont);
            }

            if (estadoEne == "Gravemente envenenado")
            {
                cont++;
                SaludActualPokeEne[o] = SaludActualPokeEne[o] - (SaludPokeEne[o] / 16 * cont);
            }









        }







        public void setArrayId(int[] arrayId)
        {
            pokeIdCombate = arrayId;
            pokeIdActual = pokeIdCombate[z];
            pokeEneIdActual = pokeIdCombateEne[o];

            //--Copiado  pokeIdActual = pokeIdCombate[0];


            //--Copiado   imgPokemonUser.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Back/" + pokeIdActual + "b.png", UriKind.Relative));

            InicializacionStatPoke();

            SaludActualPoke = SaludPoke;
            SaludActualPokeEne = SaludPokeEne;


            InicializacionStatPokeEne();
            InicializacionDeMovPokesUser(pokeIdActual);
            InicializacionDeMovPokesEne(pokeEneIdActual);
            InicializacionPokeUser(z, pokeIdActual);


            barraVidaUser.Value = SaludActualPoke[z];
            barraVidaUser.Maximum = SaludPoke[z];

            barraVidaEne.Value = SaludActualPokeEne[z];
            barraVidaEne.Maximum = SaludPokeEne[z];








        }

        public void InicializacionStatPokeEne()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                i = 0;

                for (int i = 0; i <= 5; i++)
                {


                    string queryPoke = $"Select Nombre,Tipo1,Tipo2,PS,ATK,DEF,S_ATK,S_DEF,VEL from Pokemon where IdPokemon = {pokeIdCombateEne[i]}";

                    SQLiteCommand commandPoke = new SQLiteCommand(queryPoke, connection);

                    SQLiteDataReader readerPoke = commandPoke.ExecuteReader();

                    while (readerPoke.Read())
                    {

                        NombrePokeEne[i] = readerPoke.GetString(0);
                        TipoPokeEne1[i] = readerPoke.GetString(1);
                        TipoPokeEne2[i] = readerPoke.GetString(2);
                        SaludPokeEne[i] = readerPoke.GetInt32(3);
                        AtaquePokeEne[i] = readerPoke.GetInt32(4);
                        DefensaPokeEne[i] = readerPoke.GetInt32(5);
                        Ataque_EspecialPokeEne[i] = readerPoke.GetInt32(6);
                        Defensa_EspecialPokeEne[i] = readerPoke.GetInt32(7);
                        VelocidadPokeEne[i] = readerPoke.GetInt32(8);

                    }
                    readerPoke.Close();
                }


            }
        }

        public void InicializacionStatPoke()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                i = 0;

                for (int i = 0; i <= 5; i++)
                {


                    string queryPoke = $"Select Nombre,Tipo1,Tipo2,PS,ATK,DEF,S_ATK,S_DEF,VEL from Pokemon where IdPokemon = {pokeIdCombate[i]}";

                    SQLiteCommand commandPoke = new SQLiteCommand(queryPoke, connection);

                    SQLiteDataReader readerPoke = commandPoke.ExecuteReader();

                    while (readerPoke.Read())
                    {

                        NombrePoke[i] = readerPoke.GetString(0);
                        TipoPoke1[i] = readerPoke.GetString(1);
                        TipoPoke2[i] = readerPoke.GetString(2);
                        SaludPoke[i] = readerPoke.GetInt32(3);
                        AtaquePoke[i] = readerPoke.GetInt32(4);
                        DefensaPoke[i] = readerPoke.GetInt32(5);
                        Ataque_EspecialPoke[i] = readerPoke.GetInt32(6);
                        Defensa_EspecialPoke[i] = readerPoke.GetInt32(7);
                        VelocidadPoke[i] = readerPoke.GetInt32(8);

                    }
                    readerPoke.Close();
                }


            }
        }


        public void InicializacionDeMovPokesUser(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                i = 0;

                string query = $"Select m.NombreMovimiento,m.Tipo,m.PP,m.Potencia,m.Medio from Movimiento m\r\ninner join Movimiento_Pokemon mp on mp.IdMovimiento = m.IdMovimiento\r\ninner join Pokemon p on p.IdPokemon = mp.IdPokemon\r\nwhere p.IdPokemon = {id}";

                SQLiteCommand command = new SQLiteCommand(query, connection);

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    nombremov[i] = reader.GetString(0);
                    tipomov[i] = reader.GetString(1);
                    PP[i] = reader.GetInt32(2);
                    potencia[i] = reader.GetInt32(3);
                    medio[i] = reader.GetString(4);
                    i++;

                }
                reader.Close();



            }

        }


        public void InicializacionDeMovPokesEne(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                i = 0;

                string query = $"Select m.NombreMovimiento,m.Tipo,m.PP,m.Potencia,m.Medio from Movimiento m\r\ninner join Movimiento_Pokemon mp on mp.IdMovimiento = m.IdMovimiento\r\ninner join Pokemon p on p.IdPokemon = mp.IdPokemon\r\nwhere p.IdPokemon = {id}";

                SQLiteCommand command = new SQLiteCommand(query, connection);

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    nombremovEne[i] = reader.GetString(0);
                    tipomovEne[i] = reader.GetString(1);
                    PPEne[i] = reader.GetInt32(2);
                    potenciaEne[i] = reader.GetInt32(3);
                    medioEne[i] = reader.GetString(4);
                    i++;

                }
                reader.Close();



            }
        }


        public void InicializacionPokeUser(int idPosicion, int idPoke)
        {
            imgPokemonUser.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Back/" + idPoke + "b.png", UriKind.Relative));

            pokeIdActual = pokeIdCombate[idPosicion];

            imgMov1 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[0] + ".png", UriKind.Relative));
            btnMov1.Content = nombremov[0];
            imgBtnMov1.Source = imgMov1;

            imgMov2 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[1] + ".png", UriKind.Relative));
            btnMov2.Content = nombremov[1];
            imgBtnMov2.Source = imgMov2;

            imgMov3 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[2] + ".png", UriKind.Relative));
            btnMov3.Content = nombremov[2];
            imgBtnMov3.Source = imgMov3;

            imgMov4 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[3] + ".png", UriKind.Relative));
            btnMov4.Content = nombremov[3];
            imgBtnMov4.Source = imgMov4;

            ppMov1[idPosicion] = PP[0];
            ppMov2[idPosicion] = PP[1];
            ppMov3[idPosicion] = PP[2];
            ppMov4[idPosicion] = PP[3];

        }

        public void setArrayIdEne(int[] IdEne)
        {
            pokeIdCombateEne = IdEne;
            imgPokemonEnemigo.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + pokeIdCombateEne[z] + ".png", UriKind.Relative));
        }



        private void btnLucha_Click(object sender, RoutedEventArgs e)
        {
            canvasMovimientos.Margin = stkPaneBotonesLucha.Margin;
            btnLucha.IsHitTestVisible = false;
            btnMochila.IsHitTestVisible = false;
            btnHuir.IsHitTestVisible = false;
            btnPokemon.IsHitTestVisible = false;

        }

        private async void btnMov1_Click(object sender, RoutedEventArgs e)
        {

            canvasMovimientos.Margin = new Thickness(0, 480, 0, -117);

            btnLucha.IsHitTestVisible = true;
            btnMochila.IsHitTestVisible = true;
            btnHuir.IsHitTestVisible = true;
            btnPokemon.IsHitTestVisible = true;

            k = 0;
            CombateB();

            txtCombate.FontSize = 20;

            await AnimacionTextos(VelocidadPoke[z], VelocidadPokeEne[o]);

            barraVidaUser.Value = SaludActualPoke[z];
            barraVidaEne.Value = SaludActualPokeEne[o];

            if (barraVidaEne.Value < barraVidaEne.Maximum * 0.50)
                barraVidaEne.Foreground = new SolidColorBrush(Colors.Yellow);
            if (barraVidaEne.Value < barraVidaEne.Maximum * .25)
                barraVidaEne.Foreground = new SolidColorBrush(Colors.Red);

            if (barraVidaUser.Value < barraVidaUser.Maximum * 0.50)
                barraVidaUser.Foreground = new SolidColorBrush(Colors.Yellow);
            if (barraVidaUser.Value < barraVidaUser.Maximum * 0.35)
                barraVidaUser.Foreground = new SolidColorBrush(Colors.Red);

            if (barraVidaEne.Value <= 0 && o <= 6)
            {
                o++;
                imgPokemonEnemigo.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + pokeIdCombateEne[o] + ".png", UriKind.Relative));

                SaludActualPokeEne[o] = SaludPokeEne[o];
                estadoEne = "";

                barraVidaEne.Value = SaludActualPokeEne[o];
                barraVidaEne.Maximum = SaludPokeEne[o];
                barraVidaEne.Foreground = new SolidColorBrush(Colors.Green);

            }

            if (barraVidaUser.Value <= 0 && z <= 6)
            {
                z++;
                imgPokemonUser.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + pokeIdCombate[z] + ".png", UriKind.Relative));
                pokeIdActual = pokeIdCombate[z];

                SaludActualPoke[z] = SaludPoke[z];
                estadoUser = "";

                barraVidaUser.Value = SaludActualPoke[z];
                barraVidaUser.Maximum = SaludPoke[z];
                barraVidaUser.Foreground = new SolidColorBrush(Colors.Green);

                InicializacionDeMovPokesUser(pokeIdActual);

            }

            if (estadoEne != "")
            {
                if (estadoEne == "Gravemente envenenado" || estadoEne == "Envenenado")
                    imgEstadoEne.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/Envenenado.png", UriKind.Relative));
                else
                    imgEstadoEne.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/{estadoEne}.png", UriKind.Relative));
            }

            if (estadoUser != "")
            {
                if (estadoUser == "Gravemente envenenado" || estadoUser == "Envenenado")
                    imgEstadoUser.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/Envenenado.png", UriKind.Relative));
                else
                    imgEstadoUser.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/{estadoUser}.png", UriKind.Relative));
            }

           

            imgMov1 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[k] + "Hover.png", UriKind.Relative));


            imgBtnMov1.Source = imgMov1;

            if (ppMov1[z] > 0)
            {
                ppMov1[z]--;
                lblPPMov.Content = $"PP: {ppMov1[z]}/{PP[k]}";
            }

            








        }

        private void btnMov1_MouseEnter(object sender, MouseEventArgs e)
        {
            k = 0;

            imgMov1 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[k] + "Hover.png", UriKind.Relative));
            imgTipoMovi = new BitmapImage(new Uri("Recursos/Imagenes/Tipos/" + tipomov[k] + ".png", UriKind.Relative));
            imgTipoMov.Source = imgTipoMovi;

            imgBtnMov1.Source = imgMov1;

            lblPPMov.Content = $"PP: {ppMov1[z]}/{PP[0]}";


        }

        private void btnMov1_MouseLeave(object sender, MouseEventArgs e)
        {
            imgMov1 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[k] + ".png", UriKind.Relative));


            imgBtnMov1.Source = imgMov1;
        }

        private async void btnMov2_Click(object sender, RoutedEventArgs e)
        {

            canvasMovimientos.Margin = new Thickness(0, 480, 0, -117);

            btnLucha.IsHitTestVisible = true;
            btnMochila.IsHitTestVisible = true;
            btnHuir.IsHitTestVisible = true;
            btnPokemon.IsHitTestVisible = true;

            k = 1;
            CombateB();
            txtCombate.FontSize = 20;

            await AnimacionTextos(VelocidadPoke[z], VelocidadPokeEne[o]);

            barraVidaUser.Value = SaludActualPoke[z];
            barraVidaEne.Value = SaludActualPokeEne[o];

            if (barraVidaEne.Value < barraVidaEne.Maximum * 0.50)
                barraVidaEne.Foreground = new SolidColorBrush(Colors.Yellow);
            if (barraVidaEne.Value < barraVidaEne.Maximum * .25)
                barraVidaEne.Foreground = new SolidColorBrush(Colors.Red);

            if (barraVidaUser.Value < barraVidaUser.Maximum * 0.50)
                barraVidaUser.Foreground = new SolidColorBrush(Colors.Yellow);
            if (barraVidaUser.Value < barraVidaUser.Maximum * 0.35)
                barraVidaUser.Foreground = new SolidColorBrush(Colors.Red);

            if (barraVidaEne.Value <= 0 && o <= 6)
            {
                o++;
                imgPokemonEnemigo.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + pokeIdCombateEne[o] + ".png", UriKind.Relative));

                SaludActualPokeEne[o] = SaludPokeEne[o];
                estadoEne = "";

                barraVidaEne.Value = SaludActualPokeEne[o];
                barraVidaEne.Maximum = SaludPokeEne[o];
                barraVidaEne.Foreground = new SolidColorBrush(Colors.Green);

            }

            if (barraVidaUser.Value <= 0 && z <= 6)
            {
                z++;
                imgPokemonUser.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + pokeIdCombate[z] + ".png", UriKind.Relative));
                pokeIdActual = pokeIdCombate[z];

                SaludActualPoke[z] = SaludPoke[z];
                estadoUser = "";

                barraVidaUser.Value = SaludActualPoke[z];
                barraVidaUser.Maximum = SaludPoke[z];
                barraVidaUser.Foreground = new SolidColorBrush(Colors.Green);

                InicializacionDeMovPokesUser(pokeIdActual);

            }

            if (estadoEne != "")
            {
                if (estadoEne == "Gravemente envenenado" || estadoEne == "Envenenado")
                    imgEstadoEne.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/Envenenado.png", UriKind.Relative));
                else
                    imgEstadoEne.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/{estadoEne}.png", UriKind.Relative));
            }

            if (estadoUser != "")
            {
                if (estadoUser == "Gravemente envenenado" || estadoUser == "Envenenado")
                    imgEstadoUser.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/Envenenado.png", UriKind.Relative));
                else
                    imgEstadoUser.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/{estadoUser}.png", UriKind.Relative));
            }


            imgMov2 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[k] + "Hover.png", UriKind.Relative));

            if (ppMov2[z] > 0)
            {
                imgBtnMov2.Source = imgMov2;
                ppMov2[z]--;
                lblPPMov.Content = $"PP: {ppMov2[z]}/{PP[k]}";
            }

            




        }

        private async Task AnimacionTextos(int velocidadUser, int velocidadEne)
        {
            string[] textos;
            if (velocidadUser > velocidadEne)
            {
                if (estadoEne == "")
                    if (estadoUser != "")
                        textos = new string[] { "Tu pokemon ha sido mas rapido", $"{NombrePoke[z]} ha usado {nombremov[k]}", eficacia, $"El {NombrePokeEne[o]} enemigo ha usado {nombremovEne[j]} ", $"Tu {NombrePoke[z]} ha sido {estadoUser}" };
                          else
                             textos = new string[] { "Tu pokemon ha sido mas rapido", $"{NombrePoke[z]} ha usado {nombremov[k]}", eficacia, $"El {NombrePokeEne[o]} enemigo ha usado {nombremovEne[j]}" };
                else
                    if (estadoUser != "")
                    textos = new string[] { "Tu pokemon ha sido mas rapido", $"{NombrePoke[z]} ha usado {nombremov[k]}", eficacia,$"El {NombrePokeEne[o]} ha sido {estadoEne}" ,$"El {NombrePokeEne[o]} enemigo ha usado {nombremovEne[j]}", $"Tu {NombrePoke[z]} ha sido {estadoUser}" };
                    else
                    textos = new string[] { "Tu pokemon ha sido mas rapido", $"{NombrePoke[z]} ha usado {nombremov[k]}", eficacia, $"El {NombrePokeEne[o]} ha sido {estadoEne}", $"El {NombrePokeEne[o]} enemigo ha usado {nombremovEne[j]} "};

                foreach (string texto in textos)
                {
                    await animacionTexto(texto, txtCombate);
                }
            }
            else
            {
                if (estadoUser == "")
                    if (estadoEne != "")
                        textos = new string[] { $"El {NombrePokeEne[o]} ha sido mas rapido", $"El {NombrePokeEne[o]} enemigo ha usado {nombremovEne[j]}", $"{NombrePoke[z]} ha usado {nombremov[k]}", eficacia, $"El {NombrePoke[z]} ha sido {estadoUser}" };
                    else
                     textos = new string[] { $"El {NombrePokeEne[o]} ha sido mas rapido", $"El {NombrePokeEne[o]} enemigo ha usado {nombremovEne[j]}", $"{NombrePoke[z]} ha usado {nombremov[k]}", eficacia };
                else
                    if(estadoEne != "")
                    textos = new string[] { $"El {NombrePokeEne[o]} ha sido mas rapido", $"El {NombrePokeEne[o]} enemigo ha usado {nombremovEne[j]}", $"Tu {NombrePoke[z]} ha sido {estadoUser}" ,$"{NombrePoke[z]} ha usado {nombremov[k]}", eficacia, $"El {NombrePokeEne[o]} ha sido {estadoEne}" };
                    else
                    textos = new string[] { $"El {NombrePokeEne[o]} ha sido mas rapido", $"El {NombrePokeEne[o]} enemigo ha usado {nombremovEne[j]}", $"{NombrePoke[z]} ha usado {nombremov[k]}", eficacia, $"El {NombrePokeEne[o]} ha sido {estadoEne}" };




                foreach (string texto in textos)
                {
                    await animacionTexto(texto, txtCombate);
                }
                
            }


        }

        private void btnMov2_MouseEnter(object sender, MouseEventArgs e)
        {
            k = 1;


            imgMov2 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[k] + "Hover.png", UriKind.Relative));
            imgTipoMovi = new BitmapImage(new Uri("Recursos/Imagenes/Tipos/" + tipomov[k] + ".png", UriKind.Relative));
            imgTipoMov.Source = imgTipoMovi;

            imgBtnMov2.Source = imgMov2;
            lblPPMov.Content = $"PP: {ppMov2[z]}/{PP[k]}";

        }

        private void btnMov2_MouseLeave(object sender, MouseEventArgs e)
        {
            imgMov2 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[1] + ".png", UriKind.Relative));


            imgBtnMov2.Source = imgMov2;
        }

        private async void btnMov3_Click(object sender, RoutedEventArgs e)
        {

            canvasMovimientos.Margin = new Thickness(0, 480, 0, -117);

            btnLucha.IsHitTestVisible = true;
            btnMochila.IsHitTestVisible = true;
            btnHuir.IsHitTestVisible = true;
            btnPokemon.IsHitTestVisible = true;

            k = 2;

            CombateB();

            txtCombate.FontSize = 20;

            await AnimacionTextos(VelocidadPoke[z], VelocidadPokeEne[o]);

            barraVidaUser.Value = SaludActualPoke[z];
            barraVidaEne.Value = SaludActualPokeEne[o];

            if (barraVidaEne.Value < barraVidaEne.Maximum * 0.50)
                barraVidaEne.Foreground = new SolidColorBrush(Colors.Yellow);
            if (barraVidaEne.Value < barraVidaEne.Maximum * .25)
                barraVidaEne.Foreground = new SolidColorBrush(Colors.Red);

            if (barraVidaUser.Value < barraVidaUser.Maximum * 0.50)
                barraVidaUser.Foreground = new SolidColorBrush(Colors.Yellow);
            if (barraVidaUser.Value < barraVidaUser.Maximum * 0.35)
                barraVidaUser.Foreground = new SolidColorBrush(Colors.Red);

            if (barraVidaEne.Value <= 0 && o <= 6)
            {
                o++;
                imgPokemonEnemigo.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + pokeIdCombateEne[o] + ".png", UriKind.Relative));

                SaludActualPokeEne[o] = SaludPokeEne[o];
                estadoEne = "";

                barraVidaEne.Value = SaludActualPokeEne[o];
                barraVidaEne.Maximum = SaludPokeEne[o];
                barraVidaEne.Foreground = new SolidColorBrush(Colors.Green);

            }

            if (barraVidaUser.Value <= 0 && z <= 6)
            {
                z++;
                imgPokemonUser.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + pokeIdCombate[z] + ".png", UriKind.Relative));
                pokeIdActual = pokeIdCombate[z];

                SaludActualPoke[z] = SaludPoke[z];
                estadoUser = "";

                barraVidaUser.Value = SaludActualPoke[z];
                barraVidaUser.Maximum = SaludPoke[z];
                barraVidaUser.Foreground = new SolidColorBrush(Colors.Green);

                InicializacionDeMovPokesUser(pokeIdActual);

            }

            if (estadoEne != "")
            {
                if (estadoEne == "Gravemente envenenado" || estadoEne == "Envenenado")
                    imgEstadoEne.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/Envenenado.png", UriKind.Relative));
                else
                    imgEstadoEne.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/{estadoEne}.png", UriKind.Relative));
            }

            if (estadoUser != "")
            {
                if (estadoUser == "Gravemente envenenado" || estadoUser == "Envenenado")
                    imgEstadoUser.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/Envenenado.png", UriKind.Relative));
                else
                    imgEstadoUser.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/{estadoUser}.png", UriKind.Relative));
            }

            


            imgMov3 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[k] + "Hover.png", UriKind.Relative));

            if (ppMov3[z] > 0)
            {
                imgBtnMov3.Source = imgMov3;
                ppMov3[z]--;
                lblPPMov.Content = $"PP: {ppMov3[z]}/{PP[k]}";
            }

           


        }

        private void btnMov3_MouseEnter(object sender, MouseEventArgs e)
        {
            k = 2;

            imgMov3 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[k] + "Hover.png", UriKind.Relative));
            imgTipoMovi = new BitmapImage(new Uri("Recursos/Imagenes/Tipos/" + tipomov[k] + ".png", UriKind.Relative));
            imgTipoMov.Source = imgTipoMovi;

            imgBtnMov3.Source = imgMov3;
            lblPPMov.Content = $"PP: {ppMov3[z]}/{PP[k]}";

        }

        private void btnMov3_MouseLeave(object sender, MouseEventArgs e)
        {
            imgMov3 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[2] + ".png", UriKind.Relative));


            imgBtnMov3.Source = imgMov3;
        }

        private async void btnMov4_Click(object sender, RoutedEventArgs e)
        {

            canvasMovimientos.Margin = new Thickness(0, 480, 0, -117);

            btnLucha.IsHitTestVisible = true;
            btnMochila.IsHitTestVisible = true;
            btnHuir.IsHitTestVisible = true;
            btnPokemon.IsHitTestVisible = true;

            k = 3;

            CombateB();

            txtCombate.FontSize = 20;

            await AnimacionTextos(VelocidadPoke[z], VelocidadPokeEne[o]);

            barraVidaUser.Value = SaludActualPoke[z];
            barraVidaEne.Value = SaludActualPokeEne[o];

            if (barraVidaEne.Value < barraVidaEne.Maximum * 0.50)
                barraVidaEne.Foreground = new SolidColorBrush(Colors.Yellow);
            if (barraVidaEne.Value < barraVidaEne.Maximum * .25)
                barraVidaEne.Foreground = new SolidColorBrush(Colors.Red);

            if (barraVidaUser.Value < barraVidaUser.Maximum * 0.50)
                barraVidaUser.Foreground = new SolidColorBrush(Colors.Yellow);
            if (barraVidaUser.Value < barraVidaUser.Maximum * 0.35)
                barraVidaUser.Foreground = new SolidColorBrush(Colors.Red);

            if (barraVidaEne.Value <= 0 && o <= 6) 
            {
                o++;
                imgPokemonEnemigo.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + pokeIdCombateEne[o] + ".png", UriKind.Relative));

                SaludActualPokeEne[o] = SaludPokeEne[o];
                estadoEne = "";

                barraVidaEne.Value = SaludActualPokeEne[o];
                barraVidaEne.Maximum = SaludPokeEne[o];
                barraVidaEne.Foreground = new SolidColorBrush(Colors.Green);

            }

            if (barraVidaUser.Value <= 0 && z <= 6)
            {
                z++;
                imgPokemonUser.Source = new BitmapImage(new Uri("/Recursos/Imagenes/Pokemons/" + pokeIdCombate[z] + ".png", UriKind.Relative));
                pokeIdActual = pokeIdCombate[z];

                SaludActualPoke[z] = SaludPoke[z];
                estadoUser = "";

                barraVidaUser.Value = SaludActualPoke[z];
                barraVidaUser.Maximum = SaludPoke[z];
                barraVidaUser.Foreground = new SolidColorBrush(Colors.Green);

                InicializacionDeMovPokesUser(pokeIdActual);

            }


            if (estadoEne != "")
            {
                if (estadoEne == "Gravemente envenenado" || estadoEne == "Envenenado")
                    imgEstadoEne.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/Envenenado.png", UriKind.Relative));
                else
                imgEstadoEne.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/{estadoEne}.png", UriKind.Relative));
            }

            if (estadoUser != "")
            {
                if (estadoUser == "Gravemente envenenado" || estadoUser == "Envenenado")
                    imgEstadoUser.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/Envenenado.png", UriKind.Relative));
                else
                    imgEstadoUser.Source = new BitmapImage(new Uri($"/Recursos/Imagenes/Estados Alterados/{estadoUser}.png", UriKind.Relative));
            }

            


            imgMov4 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[k] + "Hover.png", UriKind.Relative));

            if (ppMov2[z] > 0)
            {
                imgBtnMov4.Source = imgMov4;
                ppMov4[z]--;
                lblPPMov.Content = $"PP: {ppMov4[z]}/{PP[k]}";
            }

           



        }

        private void btnMov4_MouseEnter(object sender, MouseEventArgs e)
        {
            k = 3;

            imgMov4 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[k] + "Hover.png", UriKind.Relative));

            imgTipoMovi = new BitmapImage(new Uri("Recursos/Imagenes/Tipos/" + tipomov[k] + ".png", UriKind.Relative));
            imgTipoMov.Source = imgTipoMovi;

            imgBtnMov4.Source = imgMov4;
            lblPPMov.Content = $"PP: {ppMov4[z]}/{PP[k]}";

        }

        private void btnMov4_MouseLeave(object sender, MouseEventArgs e)
        {
            imgMov4 = new BitmapImage(new Uri("./Recursos/Imagenes/Botones Movimientos/Movimiento" + tipomov[3] + ".png", UriKind.Relative));


            imgBtnMov4.Source = imgMov4;
        }

        private void btnPokemon_Click(object sender, RoutedEventArgs e)
        {
            CambioPokemon cambioPokemon = new CambioPokemon();
            cambioPokemon.setArrayId(pokeIdCombate);
            cambioPokemon.Show();
            this.Close();
        }




        private async Task animacionTexto(string texto, TextBox textBox)
        {
            txtCombate.Text = "";

            foreach (char c in texto)
            {
                txtCombate.Text += c;
                await Task.Delay(55);
            }

            textBox.Text += Environment.NewLine; // agrega un salto de línea después de cada texto

        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {



            txtCombate.IsHitTestVisible = false;



        }

        private void txtCombate_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
