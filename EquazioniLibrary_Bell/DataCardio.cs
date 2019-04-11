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
                            risp = "Le calorie bruciate risultano negative, i dati non sono corretti";
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
                            risp = "Le calorie bruciate risultano negative, i dati non sono corretti";
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
        
    }
}
