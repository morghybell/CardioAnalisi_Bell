using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataCardio_Bell.Test
{
    [TestClass]
    public class UnitTest1
    {
        //FUNZIONALITÀ 1
        //testo la frequenza cardiaca massima
        [DataRow("18", "202")]
        [DataRow("a", "Errore")]
        [DataRow("0", "Errore")]
        [DataRow("-5", "Errore")]
        [TestMethod]
        public void TestFrequenzaCMax(string E, string Atteso)
        {
            string eta = E;
            string FCMax_Atteso = Atteso;

            string FCMax_Calcolato = EquazioniLibrary_Bell.DataCardio.FrequenzaCMax(eta);

            Assert.AreEqual(FCMax_Atteso, FCMax_Calcolato);
        }

        //testo il numero dei battiti massimi
        [DataRow("204", "183,6")]
        [DataRow("a", "Errore")]
        [DataRow("0", "Errore")]
        [DataRow("-5", "Errore")]
        [TestMethod]
        public void TestNBattitiMax(string FCM, string Atteso)
        {
            string FCMax = FCM;
            string BMax_Atteso = Atteso;

            string BMax_Calcolato = EquazioniLibrary_Bell.DataCardio.NBattitiMax(FCMax);

            Assert.AreEqual(BMax_Atteso, BMax_Calcolato);
        }

        //testo il numero dei battiti minimi
        [DataRow("204", "142,8")]
        [DataRow("a", "Errore")]
        [DataRow("0", "Errore")]
        [DataRow("-5", "Errore")]
        [TestMethod]
        public void TestNBattitiMin(string FCM, string Atteso)
        {
            string FCMax = FCM;
            string BMin_Atteso = Atteso;

            string BMin_Calcolato = EquazioniLibrary_Bell.DataCardio.NBattitiMin(FCMax);

            Assert.AreEqual(BMin_Atteso, BMin_Calcolato);
        }

        //FUNZIONALITÀ 2
        //testo i valori di frequenza cardiaca a riposo
        [DataRow("55", "Bradicardia")]
        [DataRow("111,2", "Tachicardia")]
        [DataRow("70", "Normale")]
        [DataRow("a", "Errore")]
        [DataRow("0", "Errore")]
        [DataRow("-5", "Errore")]
        [TestMethod]
        public void TestFCRiposo1(string a, string b)
        {
            string FCRiposo = a;
            string FCR_Atteso = b;

            string FCR_Calcolato = EquazioniLibrary_Bell.DataCardio.FCRiposo(FCRiposo);

            Assert.AreEqual(FCR_Atteso, FCR_Calcolato);
        }

        //FUNZIONALITÀ 3
        //testo i valori delle calorie bruciate
        [DataRow("F", "75", "57", "30", "30", "58,6218929254302")]
        [DataRow("M", "70", "77", "30", "30", "74,8573135755259")]
        [DataRow("B", "70", "77", "30", "30", "Il genere da lei inserito non è valido")]
        [DataRow("M", "F", "77", "30", "30", "Errore")]
        [DataRow("F", "-5", "57", "30", "30", "La frequenza cardiaca da lei inserita è negativa")]
        [DataRow("F", "75", "-5", "30", "30", "Il peso da lei inserito è negativo")]
        [DataRow("F", "75", "57", "-5", "30", "L'età da lei inserita è negativa")]
        [DataRow("M", "75", "57", "30", "-5", "Il Tempo da lei inserito è negativo")]
        [DataRow("F", "2", "2", "2", "2", "Le calorie bruciate risultano negative, i dati inseriti non sono corretti")]
        [DataRow("M", "2", "2", "2", "2", "Le calorie bruciate risultano negative, i dati inseriti non sono corretti")]
        [TestMethod]
        public void CBruciate(string S, string FC, string P, string E, string T, string Atteso)
        {
            string Sesso = S;
            string FCardiaca = FC;
            string Peso = P;
            string eta = E;
            string Tempo = T;
            string CB_Atteso = Atteso;

            string CB_Calcolato = EquazioniLibrary_Bell.DataCardio.CBruciate(Sesso, FCardiaca, Peso, eta, Tempo);

            Assert.AreEqual(CB_Atteso, CB_Calcolato);
        }

        //FUNZIONALITÀ 4
        //testo i valori della spesa energetica
        [DataRow("corsa", "10", "57", "513")]
        [DataRow("camm", "10", "57", "285")]
        [DataRow("camm", "10", "-5", "Il peso da lei inserito è negativo")]
        [DataRow("camm", "-5", "57", "Lo spazio da lei inserito è negativo")]
        [DataRow("saltello", "10", "57", "L'andamento da lei inserito non è valido")]
        [DataRow("corsa", "j", "57", "Errore")]
        [TestMethod]
        public void SEnergetica(string Pa, string S, string P, string Atteso)
        {
            string Passo = Pa;
            string Spazio = S;
            string Peso = P;
            string SE_Attesa = Atteso;

            string SE_Calcolata = EquazioniLibrary_Bell.DataCardio.SEnergetica(Passo, Spazio, Peso);

            Assert.AreEqual(SE_Attesa, SE_Calcolata);
        }

        //FUNZIONALITÀ 5
        //testo i valori della media giornaliera dei battiti cardiaci
        [DataRow("95", "80,3", "66", "72", "77", "62,1", "75,4")]
        [DataRow("95", "-80,3", "66", "72", "77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("-95", "80,3", "66", "72", "77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "80,3", "-66", "72", "77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "80,3", "66", "-72", "77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "80,3", "66", "72", "-77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "80,3", "66", "72", "77", "-62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "-80,3", "-66", "72", "77", "62,1", "I battiti da lei inseriti sono negativi")]
        [TestMethod]
        public void MediaDBC(string B1, string B2, string B3, string B4, string B5, string B6, string Atteso)
        {
            string[] battiti = new string[6];

            battiti[0] = B1;
            battiti[1] = B2;
            battiti[2] = B3;
            battiti[3] = B4;
            battiti[4] = B5;
            battiti[5] = B6;

            string MDBC_Attesa = Atteso;

            string MDCB_Calcolata = EquazioniLibrary_Bell.DataCardio.MediaDBC(battiti);

            Assert.AreEqual(MDBC_Attesa, MDCB_Calcolata);
        }

        //testo il battito cardiaco a riposo
        [DataRow("66", "70", "77", "69", "71", "72", "70,8333333333333")]
        [DataRow("-66", "70", "77", "69", "71", "72", "I battiti da lei inseriti sono negativi")]
        [DataRow("66", "-70", "77", "69", "71", "72", "I battiti da lei inseriti sono negativi")]
        [DataRow("66", "70", "-77", "69", "71", "72", "I battiti da lei inseriti sono negativi")]
        [DataRow("66", "70", "77", "-69", "71", "72", "I battiti da lei inseriti sono negativi")]
        [DataRow("66", "70", "77", "69", "-71", "72", "I battiti da lei inseriti sono negativi")]
        [DataRow("66", "70", "77", "69", "71", "-72", "I battiti da lei inseriti sono negativi")]
        [TestMethod]
        public void BCRiposo(string B1, string B2, string B3, string B4, string B5, string B6, string Atteso)
        {
            string[] battiti = new string[6];

            battiti[0] = B1;
            battiti[1] = B2;
            battiti[2] = B3;
            battiti[3] = B4;
            battiti[4] = B5;
            battiti[5] = B6;

            string media_Attesa = Atteso;

            string media_Calcolata = EquazioniLibrary_Bell.DataCardio.BCRiposo(battiti);

            Assert.AreEqual(media_Attesa, media_Calcolata);
        }

        //testo la variabilità del battito cardiaco
        [DataRow("95", "80,3", "66", "72", "77", "62,1", "62,1 66 72 77 80,3 95 ")]
        [DataRow("-95", "80,3", "66", "72", "77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "-80,3", "66", "72", "77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "80,3", "-66", "72", "77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "80,3", "66", "-72", "77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "80,3", "66", "72", "-77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "80,3", "66", "72", "77", "-62,1", "I battiti da lei inseriti sono negativi")]
        [TestMethod]
        public void VariabilitàBC(string B1, string B2, string B3, string B4, string B5, string B6, string Atteso)
        {
            string[] battiti = new string[6];

            battiti[0] = B1;
            battiti[1] = B2;
            battiti[2] = B3;
            battiti[3] = B4;
            battiti[4] = B5;
            battiti[5] = B6;

            string variabilità_Attesa = Atteso;

            string variabilità_Calcolata = EquazioniLibrary_Bell.DataCardio.VariabilitàBC(battiti);

            Assert.AreEqual(variabilità_Attesa, variabilità_Attesa);
        }

        //testo l'ordine crescente dei battiti
        [DataRow("95", "80,3", "66", "72", "77", "62,1", "62,1 66 72 77 80,3 95 ")]
        [DataRow("-95", "80,3", "66", "72", "77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "-80,3", "66", "72", "77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "80,3", "-66", "72", "77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "80,3", "66", "-72", "77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "80,3", "66", "72", "-77", "62,1", "I battiti da lei inseriti sono negativi")]
        [DataRow("95", "80,3", "66", "72", "77", "-62,1", "I battiti da lei inseriti sono negativi")]
        [TestMethod]
        public void OrdineCB(string B1, string B2, string B3, string B4, string B5, string B6, string Atteso)
        {
            string[] battiti = new string[6];

            battiti[0] = B1;
            battiti[1] = B2;
            battiti[2] = B3;
            battiti[3] = B4;
            battiti[4] = B5;
            battiti[5] = B6;

            string ordine_Atteso = Atteso;

            string ordine_Calcolato = EquazioniLibrary_Bell.DataCardio.OrdineCB(battiti);

            Assert.AreEqual(ordine_Atteso, ordine_Calcolato);
        }

        //FUNZIONALITÀ 6
        //testo i valori del fabbisogno energetico
        [DataRow("F", "57", "30", "160", "M", "2115,22116")]
        [DataRow("M", "77", "30", "175", "M", "3054,9")]
        [DataRow("B", "77", "30", "175", "M", "Il genere da lei inserito non è valido")]
        [DataRow("M", "F", "30", "175", "M", "Errore")]
        [DataRow("F", "77", "30", "-175", "M", "L'altezza da lei inserita è negativa")]
        [DataRow("F", "-75", "5", "30", "L", "Il peso da lei inserito è negativo")]
        [DataRow("F", "75", "-57", "-5", "H", "L'età da lei inserita è negativa")]
        [DataRow("M", "75", "57", "30", "5", "Il Tipo di Vita da lei inserito non è valido")]
        [DataRow("F", "1", "200", "1", "M", "Il Fabbisogno Energetico risulta negativo, i dati inseriti non sono corretti")]
        [DataRow("M", "1", "200", "1", "L", "Il Fabbisogno Energetico risulta negativo, i dati inseriti non sono corretti")]
        [TestMethod]
        public void FabbisognoE(string S, string P, string E, string A, string TV, string Atteso)
        {
            string Sesso = S;
            string Peso = P;
            string Eta = E;
            string Altezza = A;
            string TipoVita = TV;
            string FE_Atteso = Atteso;

            string FE_Calcolato = EquazioniLibrary_Bell.DataCardio.FabbisognoE(Sesso, Peso, Eta, Altezza, TipoVita);

            Assert.AreEqual(FE_Atteso, FE_Calcolato);
        }

        //testo i valori del peso forma
        [DataRow("F", "17", "160", "55,53")]
        [DataRow("M", "17", "170", "71,7")]
        [DataRow("B", "17", "160", "Il genere da lei inserito non è valido")]
        [DataRow("M", "17", "M", "Errore")]
        [DataRow("F", "17", "-160", "L'altezza da lei inserita è negativa")]
        [DataRow("F", "-17", "160", "L'età da lei inserita è negativa")]
        [DataRow("F", "2", "2", "Il Peso Forma risulta negativo, i dati inseriti non sono corretti")]
        [DataRow("M", "2", "2", "Il Peso Forma risulta negativo, i dati inseriti non sono corretti")]
        [TestMethod]
        public void FabbisognoE(string S, string E, string A, string Atteso)
        {
            string Sesso = S;
            string Eta = E;
            string Altezza = A;
            string PS_Atteso = Atteso;

            string PS_Calcolato = EquazioniLibrary_Bell.DataCardio.PesoForma(Sesso, Eta, Altezza);

            Assert.AreEqual(PS_Atteso, PS_Calcolato);
        }

        //testo i valori di perdere peso
        [DataRow("-65", "56", "Il peso da lei inserito è negativo")]
        [DataRow("65", "-56", "Il peso forma da lei inserito è negativo")]
        [DataRow("65", "56", "9")]
        [DataRow("56", "65", "Lei è sottopeso rispetto al suo peso ideale")]
        [DataRow("56", "56", "Lei è perfettamente in linea con il suo peso ideale")]
        [DataRow("F", "56", "Errore")]
        [TestMethod]
        public void FabbisognoE(string P, string PS, string Atteso)
        {
            string Peso = P;
            string PesoForma = PS;
            string PP_Atteso = Atteso;

            string PP_Calcolato = EquazioniLibrary_Bell.DataCardio.PerderePeso(Peso, PesoForma);

            Assert.AreEqual(PP_Atteso, PP_Calcolato);
        }
    }
}