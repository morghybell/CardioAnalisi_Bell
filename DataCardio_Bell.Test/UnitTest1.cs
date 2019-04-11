﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataCardio_Bell.Test
{
    [TestClass]
    public class UnitTest1
    {
        //testo la frequenza cardiaca massima
        [TestMethod]
        public void TestFrequenzaCMax()
        {
            string eta = "18";
            string FCMax_Atteso = "202";

            string FCMax_Calcolato = EquazioniLibrary_Bell.DataCardio.FrequenzaCMax(eta);

            Assert.AreEqual(FCMax_Atteso, FCMax_Calcolato);
        }

        [TestMethod]
        public void TestFrequenzaCMax1()
        {
            string eta = "a";
            string FCMax_Atteso = "Errore";

            string FCMax_Calcolato = EquazioniLibrary_Bell.DataCardio.FrequenzaCMax(eta);

            Assert.AreEqual(FCMax_Atteso, FCMax_Calcolato);
        }

        [TestMethod]
        public void TestFrequenzaCMax2()
        {
            string eta = "0";
            string FCMax_Atteso = "Errore";

            string FCMax_Calcolato = EquazioniLibrary_Bell.DataCardio.FrequenzaCMax(eta);

            Assert.AreEqual(FCMax_Atteso, FCMax_Calcolato);
        }

        [TestMethod]
        public void TestFrequenzaCMax3()
        {
            string eta = "-5";
            string FCMax_Atteso = "Errore";

            string FCMax_Calcolato = EquazioniLibrary_Bell.DataCardio.FrequenzaCMax(eta);

            Assert.AreEqual(FCMax_Atteso, FCMax_Calcolato);
        }

        //testo il numero dei battiti massimi
        [TestMethod]
        public void TestNBattitiMax()
        {
            string FCMax = "204";
            string BMax_Atteso = "183,6";

            string BMax_Calcolato = EquazioniLibrary_Bell.DataCardio.NBattitiMax(FCMax);

            Assert.AreEqual(BMax_Atteso, BMax_Calcolato);
        }

        [TestMethod]
        public void TestNBattitiMax1()
        {
            string FCMax = "a";
            string BMax_Atteso = "Errore";

            string BMax_Calcolato = EquazioniLibrary_Bell.DataCardio.NBattitiMax(FCMax);

            Assert.AreEqual(BMax_Atteso, BMax_Calcolato);
        }

        [TestMethod]
        public void TestNBattitiMax2()
        {
            string FCMax = "0";
            string BMax_Atteso = "Errore";

            string BMax_Calcolato = EquazioniLibrary_Bell.DataCardio.NBattitiMax(FCMax);

            Assert.AreEqual(BMax_Atteso, BMax_Calcolato);
        }

        [TestMethod]
        public void TestNBattitiMax3()
        {
            string FCMax = "-5";
            string BMax_Atteso = "Errore";

            string BMax_Calcolato = EquazioniLibrary_Bell.DataCardio.NBattitiMax(FCMax);

            Assert.AreEqual(BMax_Atteso, BMax_Calcolato);
        }

        //testo il numero dei battiti minimi
        [TestMethod]
        public void TestNBattitiMin()
        {
            string FCMax = "204";
            string BMin_Atteso = "142,8";

            string BMin_Calcolato = EquazioniLibrary_Bell.DataCardio.NBattitiMin(FCMax);

            Assert.AreEqual(BMin_Atteso, BMin_Calcolato);
        }

        [TestMethod]
        public void TestNBattitiMin1()
        {
            string FCMax = "a";
            string BMin_Atteso = "Errore";

            string BMin_Calcolato = EquazioniLibrary_Bell.DataCardio.NBattitiMin(FCMax);

            Assert.AreEqual(BMin_Atteso, BMin_Calcolato);
        }

        [TestMethod]
        public void TestNBattitiMin2()
        {
            string FCMax = "0";
            string BMin_Atteso = "Errore";

            string BMin_Calcolato = EquazioniLibrary_Bell.DataCardio.NBattitiMin(FCMax);

            Assert.AreEqual(BMin_Atteso, BMin_Calcolato);
        }

        [TestMethod]
        public void TestNBattitiMin3()
        {
            string FCMax = "-5";
            string BMin_Atteso = "Errore";

            string BMin_Calcolato = EquazioniLibrary_Bell.DataCardio.NBattitiMin(FCMax);

            Assert.AreEqual(BMin_Atteso, BMin_Calcolato);
        }

        //testo i valori di frequenza cardiaca a riposo
        [DataRow("55", "Bradicardia")]
        [DataRow("111.2", "Tachicardia")]
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

        //testo i valori di frequenza cardiaca a riposo
        [DataRow("F", "75", "57", "30", "30", "58,6218929254302")]
        [DataRow("M", "70", "77", "30", "30", "74,8573135755259")]
        [DataRow("B", "70", "77", "30", "30", "Il genere da lei inserito non è valido")]
        [DataRow("M", "F", "77", "30", "30", "Errore")]
        [DataRow("F", "-5", "57", "30", "30", "La frequenza cardiaca da lei inserita è negativa")]
        [DataRow("F", "75", "-5", "30", "30", "Il peso da lei inserito è negativo")]
        [DataRow("F", "75", "57", "-5", "30", "L'età da lei inserita è negativa")]
        [DataRow("M", "75", "57", "30", "-5", "Il Tempo da lei inserito è negativo")]
        [DataRow("F", "2", "2", "2", "2", "Le calorie bruciate risultano negative, i dati non sono corretti")]
        [DataRow("M", "2", "2", "2", "2", "Le calorie bruciate risultano negative, i dati non sono corretti")]
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
    }
}