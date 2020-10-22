using System;
using Dominio;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace IndustrialRevolutionTimeLine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DateBox.IsReadOnly = true;
            description.IsReadOnly = true;
        }
        public bool AreFieldsEmpty()
        {
            bool areEmpty = false;

            if (Daybox.Text.Length == 0 || MonthBox.Text.Length == 0 || YearBox.Text.Length == 0)
            {
                areEmpty = true;
            }

            return areEmpty;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            int year;
            int day;
            int month;
            if(AreFieldsEmpty() == true)
            {
                MessageBox.Show("Aun no introduce todos lo datos","Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                year = Int32.Parse(YearBox.Text);
                day = Int32.Parse(Daybox.Text);
                month = int.Parse(MonthBox.Text);
                Logica logicaPrograma = new Logica();

                if (datosValidos(month, day))
                {
                    if (rangoCorrecto(year))
                    {
                        if (!esFuturo(year))
                        {
                            if (hayIndustria(year))
                            {
                                if (logicaPrograma.esFechaValida(year, month, day))
                                {
                                    escribirFase(year);
                                }
                                else
                                {
                                    ErrorMesage.Text = "Ups! intente de nuevo";
                                }
                            }
                            else
                            {
                                ErrorMesage.Text = "Ups! La industria todavía no surgia como tal";
                            }
                        }
                        else
                        {
                            ErrorMesage.Text = "Ups! No sé adivinar el futuro";
                        }
                    }
                    else
                    {
                        ErrorMesage.Text = "Ups! Fuera de rango";
                    }
                }
            }
        }

        private void IsNumber2(object sender, TextCompositionEventArgs e)
        {
            if (!IsNumber(e.Text))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        public static bool IsNumber(string number)
        {
            Regex numberRegularExpression = new Regex(@"\d");

            return numberRegularExpression.IsMatch(number);
        }

        public bool rangoCorrecto(int year)
        {
            return (year >= 1700 && year <= 2100);
        }

        public bool esFuturo(int inputYear)
        {
            return inputYear > 2020;
        }

        public bool hayIndustria(int year)
        {
            return (year >= 1760);
        }

        public bool datosValidos(int mes, int dia)
        {
            bool validos = true;

            if (mes > 12)
            {
                ErrorMesage.Text = "Mes no valido";
                validos = false;
            }

            if (dia > 31)
            {
                ErrorMesage.Text = "Dias no validos";
                validos = false;
            }

            return validos;
        }

        public void escribirFase(int year)
        {
            if (year >= 1760 && year <= 1830)
            {
                description.Text = "Un día del período de la Industria 1.0 " +
                    "que se caracterizó por la predominancia de las industrias" +
                    " metalúrgica, textil y por el ferrocarril como principal " +
                    "medio de transporte, que utilizaba el carbón como fuente de energía. " +
                    "Por su parte, el telégrafo y el teléfono revolucionaron la forma en la que las " +
                    "comunicaciones eran concebidas hasta ese momento.  ";
            }
            else if (year >= 1850 && year <= 1914)
            {
                description.Text = "Un día del período de la Industria 2.0 el cual supuso el desarrollo de las industrias química," +
                    " eléctrica y automovilística.El coche y más tarde el avión, nacieron al albor de los cambios en este segundo" +
                    " periodo, que se extendió durante más de un siglo.Estos medios cambiaron el carbón por el petróleo como fuente" +
                    " de energía.";
            }
            else if (year >= 1960 && year <= 1970)
            {
                description.Text = "Un día del período de la Industria 3.0 caracterizada por el uso de la electrónica, " +
                    "las tecnologías de la información y las telecomunicaciones. Estos cambios permitieron la automatización" +
                    " de los procesos de producción y el surgimiento de Internet, que sin duda, ha supuesto una importante innovación " +
                    "en nuestro modo de ver y entender la vida y sobre todo la comunicación. Las energías alternativas y renovables," +
                    " la nuclear y el petróleo se han erigido durante estos años como las principales fuentes de energía.";
            }else if (year >= 2011 && year <= 2020)
            {
                description.Text = "Un día del período de la Industria 4.0, esta nueva revolución no ha hecho sino multiplicar" +
                    " la velocidad, el alcance y el impacto de las herramientas que surgieron en el periodo anterior, mediante" +
                    " la conexión de los mundos digital, físico y biológico. Fábricas inteligentes, lugares de producción en los" +
                    " que los dispositivos están conectados entre sí con el objetivo de difuminar las barreras entre la demanda, " +
                    "el diseño, la fabricación y el suministro. ";
            }
            else
            {
                description.Text = "Período de transición entre evoluciones industriales";
            }

            DateBox.Text = year.ToString();
            ErrorMesage.Text = "";
        }
    }
}