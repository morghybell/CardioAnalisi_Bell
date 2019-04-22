using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquazioniLibrary_Bell
{
    public class DataCardio
    {
        //calcolo la frequenza cardiaca massima
        public static string FrequenzaCMax(string eta)
        {
            string FCM = "";

            try
            {
                double numero = Convert.ToDouble(eta);

                if (numero <= 0)
                {
                    FCM = "Errore";
                }
                else
                {
                    double FCMax = 220 - numero;

                    FCM = Convert.ToString(FCMax);
                }
            }
            catch (Exception)
            {
                FCM = "Errore";
            }

            return FCM;
        }

        //calcolo il numero dei battiti minimi
        public static string NBattitiMin(string FCMax)
        {
            string BM = "";

            try
            {
                double FCM = Convert.ToDouble(FCMax);

                if (FCM <= 0)
                {
                    BM = "Errore";
                }
                else
                {
                    double BMin = FCM * 0.7;

                    BM = Convert.ToString(BMin);
                }
            }
            catch (Exception)
            {
                BM = "Errore";
            }

            return BM;
        }

        //calcolo il numero dei battiti massimi
        public static string NBattitiMax(string FCMax)
        {
            string BM = "";

            try
            {
                double FCM = Convert.ToDouble(FCMax);

                if (FCM <= 0)
                {
                    BM = "Errore";
                }
                else
                {
                    double BMax = FCM * 0.9;

                    BM = Convert.ToString(BMax);
                }
            }
            catch (Exception)
            {
                BM = "Errore";
            }

            return BM;
        }

        //interpreto i valori di frequenza cardiaca a riposo
        public static string FCRiposo(string FCRiposo)
        {
            string risp = "";

            try
            {
                double FCR = Convert.ToDouble(FCRiposo);

                if (FCR <= 0)
                {
                    risp = "Errore";
                }
                else
                {

                    if (FCR < 60)
                    {
                        risp = "Bradicardia";
                    }
                    else if (FCR > 100)
                    {
                        risp = "Tachicardia";
                    }
                    else
                    {
                        risp = "Normale";
                    }
                }
            }
            catch (Exception)
            {
                risp = "Errore";
            }

            return risp;
        }

        //calcolo le calorie bruciate
        public static string CBruciate(string Sesso, string FCardiaca, string Peso, string Eta, string Tempo)
        {
            string risp = "";

            try
            {
                double FC = Convert.ToDouble(FCardiaca);
                double P = Convert.ToDouble(Peso);
                double E = Convert.ToDouble(Eta);
                double T = Convert.ToDouble(Tempo);

                if (FC < 0 || P < 0 || E < 0 || T < 0)
                {
                    if (FC < 0)
                    {
                        risp = "La frequenza cardiaca da lei inserita è negativa";
                    }

                    if (P < 0)
                    {
                        risp = "Il peso da lei inserito è negativo";
                    }

                    if (E < 0)
                    {
                        risp = "L'età da lei inserita è negativa";
                    }

                    if (T < 0)
                    {
                        risp = "Il Tempo da lei inserito è negativo";
                    }
                }
                else
                {
                    double Calorie_Bruciate = 0;

                    if (Sesso == "M")
                    {
                        Calorie_Bruciate = ((E * 0.2017) + (P * 0.199) + (FC * 0.6309) - 55.0969) * T / 4.184;
                        //((30 * 0.2017) + (77 * 0.199) + (70 * 0.6309) - 55.0969) * 30 / 4.184;
                        //((6.051) + (15,323) + (44.163) - 55.0969) * 30 / 4.184;
                        //(65.537 - 55.0969) * 30 / 4.184;
                        //10.4401 * 30 / 4.184;
                        //313,203 / 4.184;

                        if (Calorie_Bruciate < 0)
                        {
                            risp = "Le calorie bruciate risultano negative, i dati inseriti non sono corretti";
                        }
                        else
                        {
                            risp = Convert.ToString(Calorie_Bruciate);
                        }
                    }
                    else if (Sesso == "F")
                    {
                        Calorie_Bruciate = ((E * 0.074) - (P * 0.126) + (FC * 0.4472) - 20.4022) * T / 4.184;
                        //((30 * 0.074) - (57 * 0.126) + (75 * 0.4472) - 20.4022) * 30 / 4.184;
                        //((2.22) - (7.182) + (33.54) - 20.4022) * 30 / 4.184;
                        //(28,578 - 20.4022) * 30 / 4.184;
                        //8.1758 * 30 / 4.184;
                        //245.274 / 4.184;

                        if (Calorie_Bruciate < 0)
                        {
                            risp = "Le calorie bruciate risultano negative, i dati inseriti non sono corretti";
                        }
                        else
                        {
                            risp = Convert.ToString(Calorie_Bruciate);
                        }
                    }
                    else
                    {
                        risp = "Il genere da lei inserito non è valido";
                    }
                }
            }
            catch (Exception)
            {
                risp = "Errore";
            }

            return risp;
        }

        //calcolo le spesa energetica
        public static string SEnergetica(string Passo, string Spazio, string Peso)
        {
            string risp = "";

            try
            {
                double S = Convert.ToDouble(Spazio);
                double P = Convert.ToDouble(Peso);

                if (P < 0 || S < 0)
                {
                    if (S < 0)
                    {
                        risp = "Lo spazio da lei inserito è negativo";
                    }

                    if (P < 0)
                    {
                        risp = "Il peso da lei inserito è negativo";
                    }
                }
                else
                {
                    double SEnergetica = 0;

                    if (Passo == "corsa")
                    {
                        SEnergetica = 0.9 * S * P;

                        risp = Convert.ToString(SEnergetica);
                    }
                    else if (Passo == "camm")
                    {
                        SEnergetica = 0.5 * S * P;

                        risp = Convert.ToString(SEnergetica);
                    }
                    else
                    {
                        risp = "L'andamento da lei inserito non è valido";
                    }
                }
            }
            catch (Exception)
            {
                risp = "Errore";
            }

            return risp;
        }

        //5 calcolo della media giornaliera dei battiti cardiaci
        public static string MediaDBC(string Battito1, string Battito2, string Battito3, string Battito4, string Battito5, string Battito6)
        {
            string risp = "";

            try
            {
                double B1 = Convert.ToDouble(Battito1);
                double B2 = Convert.ToDouble(Battito2);
                double B3 = Convert.ToDouble(Battito3);
                double B4 = Convert.ToDouble(Battito4);
                double B5 = Convert.ToDouble(Battito5);
                double B6 = Convert.ToDouble(Battito6);

                double media = (B1 + B2 + B3 + B4 + B5 + B6) / 6;

                risp = Convert.ToString(media);
            }
            catch
            {
                risp = "Errore";
            }

            return risp;
        }

        //5 calcolo battito cardiaco a riposo
        public static string BCRiposo()
        {
            string risp = "";




            return risp;
        }

        //5 variabilità del battito cardiaco
        public static string VariabilitàBC()
        {
            string risp = "";




            return risp;
        }

        //5 ordine crescente dei battiti
        public static string OrdineCB()
        {
            string risp = "";




            return risp;
        }

        //6 fabbisogno energetico
        public static string FabbisognoE(string Sesso, string Peso, string Eta, string Altezza, string TipoVita)
        {
            string risp = "";
            double fattore = 0;

            try
            {
                double P = Convert.ToDouble(Peso);
                double E = Convert.ToDouble(Eta);
                double A = Convert.ToDouble(Altezza);

                if (A < 0 || P < 0 || E < 0)
                {
                    if (A < 0)
                    {
                        risp = "L'altezza da lei inserita è negativa";
                    }

                    if (P < 0)
                    {
                        risp = "Il peso da lei inserito è negativo";
                    }

                    if (E < 0)
                    {
                        risp = "L'età da lei inserita è negativa";
                    }
                }
                else
                {
                    double Fabbisogno_Energetico = 0;

                    if (Sesso == "M")
                    {
                        Fabbisogno_Energetico = 66.5 + (13.75 * P) + (5 * A) - (6.775 * E);
                        //66.5 + (13.75 * 77) + (5 * 175) - (6.775 * 30)
                        //66.5 + (1058.75) + (875) - (203,25)
                        //1797

                        if (Fabbisogno_Energetico < 0)
                        {
                            risp = "Il Fabbisogno Energetico risulta negativo, i dati inseriti non sono corretti";
                        }
                        else
                        {
                            if (TipoVita != "L" && TipoVita != "M" && TipoVita != "H")
                            {
                                switch (TipoVita)
                                {
                                    case "L":
                                        fattore = 1.41;
                                        break;

                                    case "M":
                                        fattore = 1.7;
                                        break;

                                    case "H":
                                        fattore = 2.01;
                                        break;
                                }

                                Fabbisogno_Energetico = Fabbisogno_Energetico * fattore;
                                //1797 * 1.7
                                //3054,9

                                risp = Convert.ToString(Fabbisogno_Energetico);
                            }
                            else
                            {
                                risp = "il Tipo di Vita da lei inserito non è valido";
                            }
                        }
                    }
                    else if (Sesso == "F")
                    {
                        Fabbisogno_Energetico = 655.1 + (9.563 * P) + (1.85 * A) - (4.676 * E);
                        //655.1 + (9.563 * 57) + (1.85 * 160) - (4.676 * 30)
                        //655.1 + (545.091) + (296) - (140.28)
                        //1328,911

                        if (Fabbisogno_Energetico < 0)
                        {
                            risp = "Il Fabbisogno Energetico risulta negativo, i dati inseriti non sono corretti";
                        }
                        else
                        {
                            if (TipoVita != "L" && TipoVita != "M" && TipoVita != "H")
                            {
                                switch (TipoVita)
                                {
                                    case "L":
                                        fattore = 1.42;
                                        break;

                                    case "M":
                                        fattore = 1.56;
                                        break;

                                    case "H":
                                        fattore = 1.73;
                                        break;
                                }

                                Fabbisogno_Energetico = Fabbisogno_Energetico * fattore;
                                //1328,911 * 1.56
                                //2073,10116

                                risp = Convert.ToString(Fabbisogno_Energetico);
                            }
                            else
                            {
                                risp = "il Tipo di Vita da lei inserito non è valido";
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                risp = "Errore";
            }

            return risp;
        }
    }
}
