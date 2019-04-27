using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquazioniLibrary_Bell
{
    public class DataCardio
    {
        //FUNZIONALITÀ 1
        //calcolo la frequenza cardiaca massima
        public static string FrequenzaCMax(string eta)
        {
            //inizializzo la variabile di ritorno
            string risp = "";

            try
            {
                //converto l'età da tipo string a double
                double E = Convert.ToDouble(eta);

                //controllo se l'età inserita è negativa
                if (E <= 0)
                {
                    risp = "Errore";
                }
                else
                {
                    //calcolo la frequenza cardiaca massima
                    double FCMax = 220 - E;
                    risp = Convert.ToString(FCMax);
                }
            }
            catch (Exception)
            {
                risp = "Errore";
            }

            return risp;
        }

        //calcolo il numero dei battiti minimi
        public static string NBattitiMin(string FCMax)
        {
            //inizializzo la variabile di ritorno
            string risp = "";

            try
            {
                //converto la frequenza cardiaca massima da tipo string a double
                double FCM = Convert.ToDouble(FCMax);

                //controllo se la frequenza cardiaca massima inserita è negativa
                if (FCM <= 0)
                {
                    risp = "Errore";
                }
                else
                {
                    //calcolo il numero dei battiti minimi
                    double BMin = FCM * 0.7;
                    risp = Convert.ToString(BMin);
                }
            }
            catch (Exception)
            {
                risp = "Errore";
            }

            return risp;
        }

        //calcolo il numero dei battiti massimi
        public static string NBattitiMax(string FCMax)
        {
            //inizializzo la variabile di ritorno
            string risp = "";

            try
            {
                //converto la frequenza cardiaca massima da tipo string a double
                double FCM = Convert.ToDouble(FCMax);

                //controllo se la frequenza cardiaca massima inserita è negativa
                if (FCM <= 0)
                {
                    risp = "Errore";
                }
                else
                {
                    //calcolo il numero dei battiti massimi
                    double BMax = FCM * 0.9;
                    risp = Convert.ToString(BMax);
                }
            }
            catch (Exception)
            {
                risp = "Errore";
            }

            return risp;
        }

        //FUNZIONALITÀ 2
        //interpreto i valori di frequenza cardiaca a riposo
        public static string FCRiposo(string FCRiposo)
        {
            //inizializzo la variabile di ritorno
            string risp = "";

            try
            {
                //converto la frequenza cardiaca a riposo da tipo string a double
                double FCR = Convert.ToDouble(FCRiposo);

                //controllo se la frequenza cardiaca a riposo inserita è negativa
                if (FCR <= 0)
                {
                    risp = "Errore";
                }
                else
                {
                    //confronto la frequenza cardiaca a riposo con i valori standard
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

        //FUNZIONALITÀ 3
        //calcolo le calorie bruciate
        public static string CBruciate(string Sesso, string FCardiaca, string Peso, string Eta, string Tempo)
        {
            //inizializzo la variabile di ritorno
            string risp = "";

            try
            {
                //converto la frequenza cardiaca, il peso, l'età e il tempo da tipo string a double
                double FC = Convert.ToDouble(FCardiaca);
                double P = Convert.ToDouble(Peso);
                double E = Convert.ToDouble(Eta);
                double T = Convert.ToDouble(Tempo);

                //controllo se le variabili sopra elencate hanno valore negativo e restituisco messaggi specifiche
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
                    //tutti i parametri in input sono corretti
                    //inizializzo la variabile di appoggio dove inserirò il risulato del calcolo
                    double Calorie_Bruciate = 0;

                    //controllo se il sesso inserito dall'utente è maschio=M, femmina=F, oppure se non è nessuno dei due restituisco un messaggio
                    if (Sesso == "M")
                    {
                        Calorie_Bruciate = ((E * 0.2017) + (P * 0.199) + (FC * 0.6309) - 55.0969) * T / 4.184;
                        //((30 * 0.2017) + (77 * 0.199) + (70 * 0.6309) - 55.0969) * 30 / 4.184;
                        //((6.051) + (15,323) + (44.163) - 55.0969) * 30 / 4.184;
                        //(65.537 - 55.0969) * 30 / 4.184;
                        //10.4401 * 30 / 4.184;
                        //313,203 / 4.184;

                        //controllo se il risultato del calcolo è negativo
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

                        //controllo se il risultato del calcolo è negativo
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

        //FUNZIONALITÀ 4
        //calcolo le spesa energetica
        public static string SEnergetica(string Passo, string Spazio, string Peso)
        {
            //inizializzo la variabile di ritorno
            string risp = "";

            try
            {
                //converto lo spazio e il peso da tipo string a double
                double S = Convert.ToDouble(Spazio);
                double P = Convert.ToDouble(Peso);

                //controllo se le variabili sopra elencate hanno valore negativo e restituisco messaggi specifiche
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
                    //tutti i parametri in input sono corretti
                    //inizializzo la variabile di appoggio dove inserirò il risulato del calcolo
                    double SEnergetica = 0;

                    //controllo quale tipo di andamento è stato inserito e se non è presente tra quelli in lista restituisco un messaggio
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

        //FUNZIONALITÀ 5
        //calcolo della media giornaliera dei battiti cardiaci
        public static string MediaDBC(string[] battitiS)
        {
            //inizializzo la variabile di ritorno
            string risp = "";

            //inizializzo il nuovo array di tipo double
            double[] battitiD = new double[6];
            double media = 0;

            try
            {
                //converto i dati presenti nell'arrey di stringhe in double e li inserisco in un nuovo array dello stesso tipo
                battitiD[0] = Convert.ToDouble(battitiS[0]);
                battitiD[1] = Convert.ToDouble(battitiS[1]);
                battitiD[2] = Convert.ToDouble(battitiS[2]);
                battitiD[3] = Convert.ToDouble(battitiS[3]);
                battitiD[4] = Convert.ToDouble(battitiS[4]);
                battitiD[5] = Convert.ToDouble(battitiS[5]);

                //controllo se i dati inseriti nell'array sono negativi
                if (battitiD[0] <= 0 || battitiD[1] <= 0 || battitiD[2] <= 0 || battitiD[3] <= 0 || battitiD[4] <= 0 || battitiD[5] <= 0)
                {
                    risp = "I battiti da lei inseriti sono negativi";
                }
                else
                {
                    //calcolo la media
                    media = (battitiD[0] + battitiD[1] + battitiD[2] + battitiD[3] + battitiD[4] + battitiD[5]) / 6;
                    risp = Convert.ToString(media);
                }
            }
            catch
            {
                risp = "Errore";
            }

            return risp;
        }

        //calcolo battito cardiaco a riposo
        public static string BCRiposo(string[] battitiS)
        {
            //inizializzo la variabile di ritorno
            string risp = "";

            //inizializzo il nuovo array di tipo double
            double[] battitiD = new double[6];
            double media = 0;

            try
            {
                //converto i dati presenti nell'arrey di stringhe in double e li inserisco in un nuovo array dello stesso tipo
                battitiD[0] = Convert.ToDouble(battitiS[0]);
                battitiD[1] = Convert.ToDouble(battitiS[1]);
                battitiD[2] = Convert.ToDouble(battitiS[2]);
                battitiD[3] = Convert.ToDouble(battitiS[3]);
                battitiD[4] = Convert.ToDouble(battitiS[4]);
                battitiD[5] = Convert.ToDouble(battitiS[5]);

                //controllo se i dati inseriti nell'array sono negativi
                if (battitiD[0] <= 0 || battitiD[1] <= 0 || battitiD[2] <= 0 || battitiD[3] <= 0 || battitiD[4] <= 0 || battitiD[5] <= 0)
                {
                    risp = "I battiti da lei inseriti sono negativi";
                }
                else
                {
                    //moltiplico i battiti inseriti per quattro (poichè una volta misurati almeno 6 battiti per 15 secondi essi si ripetono costanti per un minuto) e ne calcolo la media
                    media = ((battitiD[0] + battitiD[1] + battitiD[2] + battitiD[3] + battitiD[4] + battitiD[5]) * 4) / 24;
                    risp = Convert.ToString(media);
                }
            }
            catch
            {
                risp = "Errore";
            }

            return risp;
        }

        //calcolo la variabilità del battito cardiaco
        public static string VariabilitàBC(string[] battitiS)
        {
            //inizializzo la variabile di ritorno
            string risp = "";

            //inizializzo il nuovo array di tipo double
            double[] battitiD = new double[6];
            double max = 0;
            double min = 0;
            double variabilità = 0;

            try
            {
                //converto i dati presenti nell'arrey di stringhe in double e li inserisco in un nuovo array dello stesso tipo
                battitiD[0] = Convert.ToDouble(battitiS[0]);
                battitiD[1] = Convert.ToDouble(battitiS[1]);
                battitiD[2] = Convert.ToDouble(battitiS[2]);
                battitiD[3] = Convert.ToDouble(battitiS[3]);
                battitiD[4] = Convert.ToDouble(battitiS[4]);
                battitiD[5] = Convert.ToDouble(battitiS[5]);

                //controllo se i dati inseriti nell'array sono negativi
                if (battitiD[0] <= 0 || battitiD[1] <= 0 || battitiD[2] <= 0 || battitiD[3] <= 0 || battitiD[4] <= 0 || battitiD[5] <= 0)
                {
                    risp = "I battiti da lei inseriti sono negativi";
                }
                else
                {
                    //ordino l'array in modo da trovare subito il valore maggiore e quello minore
                    Array.Sort(battitiD);
                    max = battitiD[0];
                    min = battitiD[5];

                    //calcolo la differenza
                    variabilità = max - min;
                    risp = Convert.ToString(variabilità);
                }
            }
            catch
            {
                risp = "Errore";
            }

            return risp;
        }

        //calcolo l'ordine crescente dei battiti
        public static string OrdineCB(string[] battitiS)
        {
            //inizializzo la variabile di ritorno
            string risp = "";
            double[] battitiD = new double[6];
            string frase = "";

            try
            {
                //converto i dati presenti nell'arrey di stringhe in double e li inserisco in un nuovo array dello stesso tipo
                battitiD[0] = Convert.ToDouble(battitiS[0]);
                battitiD[1] = Convert.ToDouble(battitiS[1]);
                battitiD[2] = Convert.ToDouble(battitiS[2]);
                battitiD[3] = Convert.ToDouble(battitiS[3]);
                battitiD[4] = Convert.ToDouble(battitiS[4]);
                battitiD[5] = Convert.ToDouble(battitiS[5]);

                //controllo se i dati inseriti nell'array sono negativi
                if (battitiD[0] <= 0 || battitiD[1] <= 0 || battitiD[2] <= 0 || battitiD[3] <= 0 || battitiD[4] <= 0 || battitiD[5] <= 0)
                {
                    risp = "I battiti da lei inseriti sono negativi";
                }
                else
                {
                    //ordino l'array
                    Array.Sort(battitiD);

                    //faccio un ciclo for con il quale inserisco in una stringa i valori ordinati
                    for (int i = 0; i < battitiD.Length; i++)
                    {
                        frase = frase + battitiD[i] + " ";
                    }

                    risp = frase;
                }
            }
            catch
            {
                risp = "Errore";
            }

            return risp;
        }

        //FUNZIONALITÀ 6
        //fabbisogno energetico
        public static string FabbisognoE(string Sesso, string Peso, string Eta, string Altezza, string TipoVita)
        {
            //inizializzo la variabile di ritorno
            string risp = "";
            double fattore = 0;

            try
            {
                //converto il peso, l'età e l'altezza da tipo string a double
                double P = Convert.ToDouble(Peso);
                double E = Convert.ToDouble(Eta);
                double A = Convert.ToDouble(Altezza);

                //controllo se le variabili sopra elencate hanno valore negativo e restituisco messaggi specifiche
                if (A <= 0 || P <= 0 || E <= 0)
                {
                    if (A <= 0)
                    {
                        risp = "L'altezza da lei inserita è negativa";
                    }

                    if (P <= 0)
                    {
                        risp = "Il peso da lei inserito è negativo";
                    }

                    if (E <= 0)
                    {
                        risp = "L'età da lei inserita è negativa";
                    }
                }
                else
                {
                    //tutti i parametri in input sono corretti
                    //inizializzo la variabile di appoggio dove inserirò il risulato del calcolo
                    double Fabbisogno_Energetico = 0;

                    //controllo se il sesso inserito dall'utente è maschio=M, femmina=F, oppure se non è nessuno dei due restituisco un messaggio
                    if (Sesso == "M")
                    {
                        Fabbisogno_Energetico = 66.5 + (13.75 * P) + (5 * A) - (6.775 * E);
                        //66.5 + (13.75 * 77) + (5 * 175) - (6.775 * 30)
                        //66.5 + (1058.75) + (875) - (203,25)
                        //1797

                        //controllo se il risultato è negativo
                        if (Fabbisogno_Energetico <= 0)
                        {
                            risp = "Il Fabbisogno Energetico risulta negativo, i dati inseriti non sono corretti";
                        }
                        else
                        {
                            //controllo che il tipo di vita inserito sia valido altrimenti restituisco un messaggio
                            if (TipoVita == "L" || TipoVita == "M" || TipoVita == "H")
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

                                //concludo l'operazione moltiplicando il risultato precedente per il tipo di vita inserito
                                Fabbisogno_Energetico = Fabbisogno_Energetico * fattore;
                                //1797 * 1.7
                                //3054,9

                                risp = Convert.ToString(Fabbisogno_Energetico);
                            }
                            else
                            {
                                risp = "Il Tipo di Vita da lei inserito non è valido";
                            }
                        }
                    }
                    else if (Sesso == "F")
                    {
                        Fabbisogno_Energetico = 655.1 + (9.563 * P) + (1.85 * A) - (4.676 * E);
                        //655.1 + (9.563 * 57) + (1.85 * 160) - (4.676 * 30)
                        //655.1 + (545.091) + (296) - (140.28)
                        //1355,911

                        //controllo se il risultato è negativo
                        if (Fabbisogno_Energetico <= 0)
                        {
                            risp = "Il Fabbisogno Energetico risulta negativo, i dati inseriti non sono corretti";
                        }
                        else
                        {
                            //controllo che il tipo di vita inserito sia valido altrimenti restituisco un messaggio
                            if (TipoVita == "L" || TipoVita == "M" || TipoVita == "H")
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

                                //concludo l'operazione moltiplicando il risultato precedente per il tipo di vita inserito
                                Fabbisogno_Energetico = Fabbisogno_Energetico * fattore;
                                //1355,911 * 1.56
                                //2115,22116

                                risp = Convert.ToString(Fabbisogno_Energetico);
                            }
                            else
                            {
                                risp = "il Tipo di Vita da lei inserito non è valido";
                            }
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

        //peso forma
        public static string PesoForma(string Sesso, string Eta, string Altezza)
        {
            //inizializzo la variabile di ritorno
            string risp = "";

            try
            {
                //converto l'età e l'altezza da tipo string a double
                double E = Convert.ToDouble(Eta);
                double A = Convert.ToDouble(Altezza);

                //controllo se le variabili sopra elencate hanno valore negativo e restituisco messaggi specifiche
                if (A <= 0 || E <= 0)
                {
                    if (A <= 0)
                    {
                        risp = "L'altezza da lei inserita è negativa";
                    }

                    if (E <= 0)
                    {
                        risp = "L'età da lei inserita è negativa";
                    }
                }
                else
                {
                    //tutti i parametri in input sono corretti
                    //inizializzo la variabile di appoggio dove inserirò il risulato del calcolo
                    double Peso_Forma = 0;

                    //controllo se il sesso inserito dall'utente è maschio=M, femmina=F, oppure se non è nessuno dei due restituisco un messaggio
                    if (Sesso == "M")
                    {
                        Peso_Forma = (A - 100) + (E / 10);

                        //controllo se il risultato è negativo
                        if (Peso_Forma < 0)
                        {
                            risp = "Il Fabbisogno Energetico risulta negativo, i dati inseriti non sono corretti";
                        }
                        else
                        {
                            risp = Convert.ToString(Peso_Forma);
                        }
                    }
                    else if (Sesso == "F")
                    {
                        Peso_Forma = ((A - 100) + (E / 10)) * 0.9;

                        //controllo se il risultato è negativo
                        if (Peso_Forma < 0)
                        {
                            risp = "Il Fabbisogno Energetico risulta negativo, i dati inseriti non sono corretti";
                        }
                        else
                        {
                            risp = Convert.ToString(Peso_Forma);
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

        //6 perdere peso
        public static string PerderePeso(string Peso, string PesoForma)
        {
            //inizializzo la variabile di ritorno
            string risp = "";

            try
            {
                //converto il peso e il peso forma da tipo string a double
                double P = Convert.ToDouble(Peso);
                double PS = Convert.ToDouble(PesoForma);

                //controllo se le variabili sopra elencate hanno valore negativo e restituisco messaggi specifiche
                if (P <= 0 || PS <= 0)
                {
                    if (P <= 0)
                    {
                        risp = "Il peso da lei inserito è negativo";
                    }

                    if (PS <= 0)
                    {
                        risp = "Il peso forma da lei inserito è negativo";
                    }
                }
                else
                {
                    //tutti i parametri in input sono corretti
                    //inizializzo la variabile di appoggio dove inserirò il risulato del calcolo
                    double differenza = 0;

                    differenza = P - PS;

                    //controllo se il risultato è maggiore, minore o uguale a zero e restituisco messaggi opportuni
                    if (differenza < 0)
                    {
                        risp = "Lei è sottopeso rispetto al suo peso ideale";
                    }
                    else if (differenza == 0)
                    {
                        risp = "Lei è perfettamente in linea con il suo peso ideale";
                    }
                    else if (differenza > 0)
                    {
                        risp = Convert.ToString(differenza);
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