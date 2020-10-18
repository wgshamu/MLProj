using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Data;
using static Microsoft.ML.Transforms.NormalizingEstimator;
using System.Linq;
using System.Collections.Generic;
using Microsoft.ML.FastTree;
using System.Data.Common;
using ConsoleHelper;

using Microsoft.Azure; // Namespace for Azure Configuration Manager
using Microsoft.Azure.Storage; // Namespace for Storage Client Library
using Microsoft.Azure.Storage.Blob; // Namespace for Azure Blobs
using Microsoft.Azure.Storage.File; // Namespace for Azure Files
namespace glean
{
    public class Learn2
    {
        // I used a program to write this, I know this is an absurd amount of variables.
        [LoadColumn(0)]
        public float date;
        [LoadColumn(1)]
        public float last;
        [LoadColumn(2)]
        public float open;
        [LoadColumn(3)]
        public float close;
        [LoadColumn(4)]
        public float result;
        [LoadColumn(5)]
        public float overnight;
        [LoadColumn(6)]
        public float cap;
        [LoadColumn(7)]
        public float capFracIndex;
        [LoadColumn(8)]
        public float capFracSector;
        [LoadColumn(9)]
        public float capFracIndustry;
        [LoadColumn(10)]
        public float rev;
        [LoadColumn(11)]
        public float earn;
        [LoadColumn(12)]
        public float equity;
        [LoadColumn(13)]
        public float volume;
        [LoadColumn(14)]
        public float adjearn;
        [LoadColumn(15)]
        public float treasury10Y;
        [LoadColumn(16)]
        public float volatility1;
        [LoadColumn(17)]
        public float volatility2;
        [LoadColumn(18)]
        public float volatility4;
        [LoadColumn(19)]
        public float volatility8;
        [LoadColumn(20)]
        public float volatility16;
        [LoadColumn(21)]
        public float volatility32;
        [LoadColumn(22)]
        public float volatility64;
        [LoadColumn(23)]
        public float volatility128;
        [LoadColumn(24)]
        public float volatility256;
        [LoadColumn(25)]
        public float volatility512;
        [LoadColumn(26)]
        public float momentum1;
        [LoadColumn(27)]
        public float momentum2;
        [LoadColumn(28)]
        public float momentum4;
        [LoadColumn(29)]
        public float momentum8;
        [LoadColumn(30)]
        public float momentum16;
        [LoadColumn(31)]
        public float momentum32;
        [LoadColumn(32)]
        public float momentum64;
        [LoadColumn(33)]
        public float momentum128;
        [LoadColumn(34)]
        public float momentum256;
        [LoadColumn(35)]
        public float momentum512;
        [LoadColumn(36)]
        public float volmomentum1;
        [LoadColumn(37)]
        public float volmomentum2;
        [LoadColumn(38)]
        public float volmomentum4;
        [LoadColumn(39)]
        public float volmomentum8;
        [LoadColumn(40)]
        public float volmomentum16;
        [LoadColumn(41)]
        public float volmomentum32;
        [LoadColumn(42)]
        public float volmomentum64;
        [LoadColumn(43)]
        public float volmomentum128;
        [LoadColumn(44)]
        public float volmomentum256;
        [LoadColumn(45)]
        public float volmomentum512;
        [LoadColumn(46)]
        public float revenuemomentum1;
        [LoadColumn(47)]
        public float revenuemomentum2;
        [LoadColumn(48)]
        public float revenuemomentum4;
        [LoadColumn(49)]
        public float revenuemomentum8;
        [LoadColumn(50)]
        public float revenuemomentum16;
        [LoadColumn(51)]
        public float revenuemomentum32;
        [LoadColumn(52)]
        public float revenuemomentum64;
        [LoadColumn(53)]
        public float revenuemomentum128;
        [LoadColumn(54)]
        public float revenuemomentum256;
        [LoadColumn(55)]
        public float revenuemomentum512;
        [LoadColumn(56)]
        public float earningsmomentum1;
        [LoadColumn(57)]
        public float earningsmomentum2;
        [LoadColumn(58)]
        public float earningsmomentum4;
        [LoadColumn(59)]
        public float earningsmomentum8;
        [LoadColumn(60)]
        public float earningsmomentum16;
        [LoadColumn(61)]
        public float earningsmomentum32;
        [LoadColumn(62)]
        public float earningsmomentum64;
        [LoadColumn(63)]
        public float earningsmomentum128;
        [LoadColumn(64)]
        public float earningsmomentum256;
        [LoadColumn(65)]
        public float earningsmomentum512;
        [LoadColumn(66)]
        public float equitymomentum1;
        [LoadColumn(67)]
        public float equitymomentum2;
        [LoadColumn(68)]
        public float equitymomentum4;
        [LoadColumn(69)]
        public float equitymomentum8;
        [LoadColumn(70)]
        public float equitymomentum16;
        [LoadColumn(71)]
        public float equitymomentum32;
        [LoadColumn(72)]
        public float equitymomentum64;
        [LoadColumn(73)]
        public float equitymomentum128;
        [LoadColumn(74)]
        public float equitymomentum256;
        [LoadColumn(75)]
        public float equitymomentum512;
        [LoadColumn(76)]
        public float treasurymomentum1;
        [LoadColumn(77)]
        public float treasurymomentum2;
        [LoadColumn(78)]
        public float treasurymomentum4;
        [LoadColumn(79)]
        public float treasurymomentum8;
        [LoadColumn(80)]
        public float treasurymomentum16;
        [LoadColumn(81)]
        public float treasurymomentum32;
        [LoadColumn(82)]
        public float treasurymomentum64;
        [LoadColumn(83)]
        public float treasurymomentum128;
        [LoadColumn(84)]
        public float treasurymomentum256;
        [LoadColumn(85)]
        public float treasurymomentum512;
        [LoadColumn(86)]
        public float earningspertreasurymomentum1;
        [LoadColumn(87)]
        public float earningspertreasurymomentum2;
        [LoadColumn(88)]
        public float earningspertreasurymomentum4;
        [LoadColumn(89)]
        public float earningspertreasurymomentum8;
        [LoadColumn(90)]
        public float earningspertreasurymomentum16;
        [LoadColumn(91)]
        public float earningspertreasurymomentum32;
        [LoadColumn(92)]
        public float earningspertreasurymomentum64;
        [LoadColumn(93)]
        public float earningspertreasurymomentum128;
        [LoadColumn(94)]
        public float earningspertreasurymomentum256;
        [LoadColumn(95)]
        public float earningspertreasurymomentum512;
        [LoadColumn(96)]
        public float volatilityI1;
        [LoadColumn(97)]
        public float volatilityI2;
        [LoadColumn(98)]
        public float volatilityI4;
        [LoadColumn(99)]
        public float volatilityI8;
        [LoadColumn(100)]
        public float volatilityI16;
        [LoadColumn(101)]
        public float volatilityI32;
        [LoadColumn(102)]
        public float volatilityI64;
        [LoadColumn(103)]
        public float volatilityI128;
        [LoadColumn(104)]
        public float volatilityI256;
        [LoadColumn(105)]
        public float volatilityI512;
        [LoadColumn(106)]
        public float momentumI1;
        [LoadColumn(107)]
        public float momentumI2;
        [LoadColumn(108)]
        public float momentumI4;
        [LoadColumn(109)]
        public float momentumI8;
        [LoadColumn(110)]
        public float momentumI16;
        [LoadColumn(111)]
        public float momentumI32;
        [LoadColumn(112)]
        public float momentumI64;
        [LoadColumn(113)]
        public float momentumI128;
        [LoadColumn(114)]
        public float momentumI256;
        [LoadColumn(115)]
        public float momentumI512;
        [LoadColumn(116)]
        public float volmomentumI1;
        [LoadColumn(117)]
        public float volmomentumI2;
        [LoadColumn(118)]
        public float volmomentumI4;
        [LoadColumn(119)]
        public float volmomentumI8;
        [LoadColumn(120)]
        public float volmomentumI16;
        [LoadColumn(121)]
        public float volmomentumI32;
        [LoadColumn(122)]
        public float volmomentumI64;
        [LoadColumn(123)]
        public float volmomentumI128;
        [LoadColumn(124)]
        public float volmomentumI256;
        [LoadColumn(125)]
        public float volmomentumI512;
        [LoadColumn(126)]
        public float volatilityS1;
        [LoadColumn(127)]
        public float volatilityS2;
        [LoadColumn(128)]
        public float volatilityS4;
        [LoadColumn(129)]
        public float volatilityS8;
        [LoadColumn(130)]
        public float volatilityS16;
        [LoadColumn(131)]
        public float volatilityS32;
        [LoadColumn(132)]
        public float volatilityS64;
        [LoadColumn(133)]
        public float volatilityS128;
        [LoadColumn(134)]
        public float volatilityS256;
        [LoadColumn(135)]
        public float volatilityS512;
        [LoadColumn(136)]
        public float momentumS1;
        [LoadColumn(137)]
        public float momentumS2;
        [LoadColumn(138)]
        public float momentumS4;
        [LoadColumn(139)]
        public float momentumS8;
        [LoadColumn(140)]
        public float momentumS16;
        [LoadColumn(141)]
        public float momentumS32;
        [LoadColumn(142)]
        public float momentumS64;
        [LoadColumn(143)]
        public float momentumS128;
        [LoadColumn(144)]
        public float momentumS256;
        [LoadColumn(145)]
        public float momentumS512;
        [LoadColumn(146)]
        public float volmomentumS1;
        [LoadColumn(147)]
        public float volmomentumS2;
        [LoadColumn(148)]
        public float volmomentumS4;
        [LoadColumn(149)]
        public float volmomentumS8;
        [LoadColumn(150)]
        public float volmomentumS16;
        [LoadColumn(151)]
        public float volmomentumS32;
        [LoadColumn(152)]
        public float volmomentumS64;
        [LoadColumn(153)]
        public float volmomentumS128;
        [LoadColumn(154)]
        public float volmomentumS256;
        [LoadColumn(155)]
        public float volmomentumS512;
        [LoadColumn(156)]
        public float momentumY1;
        [LoadColumn(157)]
        public float momentumY2;
        [LoadColumn(158)]
        public float momentumY4;
        [LoadColumn(159)]
        public float momentumY8;
        [LoadColumn(160)]
        public float momentumY16;
        [LoadColumn(161)]
        public float momentumY32;
        [LoadColumn(162)]
        public float momentumY64;
        [LoadColumn(163)]
        public float momentumY128;
        [LoadColumn(164)]
        public float momentumY256;
        [LoadColumn(165)]
        public float momentumY512;
        [LoadColumn(166)]
        public float volmomentumY1;
        [LoadColumn(167)]
        public float volmomentumY2;
        [LoadColumn(168)]
        public float volmomentumY4;
        [LoadColumn(169)]
        public float volmomentumY8;
        [LoadColumn(170)]
        public float volmomentumY16;
        [LoadColumn(171)]
        public float volmomentumY32;
        [LoadColumn(172)]
        public float volmomentumY64;
        [LoadColumn(173)]
        public float volmomentumY128;
        [LoadColumn(174)]
        public float volmomentumY256;
        [LoadColumn(175)]
        public float volmomentumY512;
        [LoadColumn(176)]
        public float volatilityY1;
        [LoadColumn(177)]
        public float volatilityY2;
        [LoadColumn(178)]
        public float volatilityY4;
        [LoadColumn(179)]
        public float volatilityY8;
        [LoadColumn(180)]
        public float volatilityY16;
        [LoadColumn(181)]
        public float volatilityY32;
        [LoadColumn(182)]
        public float volatilityY64;
        [LoadColumn(183)]
        public float volatilityY128;
        [LoadColumn(184)]
        public float volatilityY256;
        [LoadColumn(185)]
        public float volatilityY512;
        [LoadColumn(186)]
        public float rvolatilityI1;
        [LoadColumn(187)]
        public float rvolatilityI2;
        [LoadColumn(188)]
        public float rvolatilityI4;
        [LoadColumn(189)]
        public float rvolatilityI8;
        [LoadColumn(190)]
        public float rvolatilityI16;
        [LoadColumn(191)]
        public float rvolatilityI32;
        [LoadColumn(192)]
        public float rvolatilityI64;
        [LoadColumn(193)]
        public float rvolatilityI128;
        [LoadColumn(194)]
        public float rvolatilityI256;
        [LoadColumn(195)]
        public float rvolatilityI512;
        [LoadColumn(196)]
        public float rmomentumI1;
        [LoadColumn(197)]
        public float rmomentumI2;
        [LoadColumn(198)]
        public float rmomentumI4;
        [LoadColumn(199)]
        public float rmomentumI8;
        [LoadColumn(200)]
        public float rmomentumI16;
        [LoadColumn(201)]
        public float rmomentumI32;
        [LoadColumn(202)]
        public float rmomentumI64;
        [LoadColumn(203)]
        public float rmomentumI128;
        [LoadColumn(204)]
        public float rmomentumI256;
        [LoadColumn(205)]
        public float rmomentumI512;
        [LoadColumn(206)]
        public float rvolmomentumI1;
        [LoadColumn(207)]
        public float rvolmomentumI2;
        [LoadColumn(208)]
        public float rvolmomentumI4;
        [LoadColumn(209)]
        public float rvolmomentumI8;
        [LoadColumn(210)]
        public float rvolmomentumI16;
        [LoadColumn(211)]
        public float rvolmomentumI32;
        [LoadColumn(212)]
        public float rvolmomentumI64;
        [LoadColumn(213)]
        public float rvolmomentumI128;
        [LoadColumn(214)]
        public float rvolmomentumI256;
        [LoadColumn(215)]
        public float rvolmomentumI512;
        [LoadColumn(216)]
        public float rvolatilityS1;
        [LoadColumn(217)]
        public float rvolatilityS2;
        [LoadColumn(218)]
        public float rvolatilityS4;
        [LoadColumn(219)]
        public float rvolatilityS8;
        [LoadColumn(220)]
        public float rvolatilityS16;
        [LoadColumn(221)]
        public float rvolatilityS32;
        [LoadColumn(222)]
        public float rvolatilityS64;
        [LoadColumn(223)]
        public float rvolatilityS128;
        [LoadColumn(224)]
        public float rvolatilityS256;
        [LoadColumn(225)]
        public float rvolatilityS512;
        [LoadColumn(226)]
        public float rmomentumS1;
        [LoadColumn(227)]
        public float rmomentumS2;
        [LoadColumn(228)]
        public float rmomentumS4;
        [LoadColumn(229)]
        public float rmomentumS8;
        [LoadColumn(230)]
        public float rmomentumS16;
        [LoadColumn(231)]
        public float rmomentumS32;
        [LoadColumn(232)]
        public float rmomentumS64;
        [LoadColumn(233)]
        public float rmomentumS128;
        [LoadColumn(234)]
        public float rmomentumS256;
        [LoadColumn(235)]
        public float rmomentumS512;
        [LoadColumn(236)]
        public float rvolmomentumS1;
        [LoadColumn(237)]
        public float rvolmomentumS2;
        [LoadColumn(238)]
        public float rvolmomentumS4;
        [LoadColumn(239)]
        public float rvolmomentumS8;
        [LoadColumn(240)]
        public float rvolmomentumS16;
        [LoadColumn(241)]
        public float rvolmomentumS32;
        [LoadColumn(242)]
        public float rvolmomentumS64;
        [LoadColumn(243)]
        public float rvolmomentumS128;
        [LoadColumn(244)]
        public float rvolmomentumS256;
        [LoadColumn(245)]
        public float rvolmomentumS512;
        [LoadColumn(246)]
        public float rmomentumY1;
        [LoadColumn(247)]
        public float rmomentumY2;
        [LoadColumn(248)]
        public float rmomentumY4;
        [LoadColumn(249)]
        public float rmomentumY8;
        [LoadColumn(250)]
        public float rmomentumY16;
        [LoadColumn(251)]
        public float rmomentumY32;
        [LoadColumn(252)]
        public float rmomentumY64;
        [LoadColumn(253)]
        public float rmomentumY128;
        [LoadColumn(254)]
        public float rmomentumY256;
        [LoadColumn(255)]
        public float rmomentumY512;
        [LoadColumn(256)]
        public float rvolmomentumY1;
        [LoadColumn(257)]
        public float rvolmomentumY2;
        [LoadColumn(258)]
        public float rvolmomentumY4;
        [LoadColumn(259)]
        public float rvolmomentumY8;
        [LoadColumn(260)]
        public float rvolmomentumY16;
        [LoadColumn(261)]
        public float rvolmomentumY32;
        [LoadColumn(262)]
        public float rvolmomentumY64;
        [LoadColumn(263)]
        public float rvolmomentumY128;
        [LoadColumn(264)]
        public float rvolmomentumY256;
        [LoadColumn(265)]
        public float rvolmomentumY512;
        [LoadColumn(266)]
        public float rvolatilityY1;
        [LoadColumn(267)]
        public float rvolatilityY2;
        [LoadColumn(268)]
        public float rvolatilityY4;
        [LoadColumn(269)]
        public float rvolatilityY8;
        [LoadColumn(270)]
        public float rvolatilityY16;
        [LoadColumn(271)]
        public float rvolatilityY32;
        [LoadColumn(272)]
        public float rvolatilityY64;
        [LoadColumn(273)]
        public float rvolatilityY128;
        [LoadColumn(274)]
        public float rvolatilityY256;
        [LoadColumn(275)]
        public float rvolatilityY512;
        [LoadColumn(276)]
        public float dMomentum1;
        [LoadColumn(277)]
        public float dMomentum2;
        [LoadColumn(278)]
        public float dMomentum4;
        [LoadColumn(279)]
        public float dMomentum8;
        [LoadColumn(280)]
        public float dMomentum16;
        [LoadColumn(281)]
        public float dMomentum32;
        [LoadColumn(282)]
        public float dMomentum64;
        [LoadColumn(283)]
        public float dMomentum128;
        [LoadColumn(284)]
        public float dMomentum256;
        [LoadColumn(285)]
        public float dMomentum512;
        [LoadColumn(286)]
        public float dVolatility1;
        [LoadColumn(287)]
        public float dVolatility2;
        [LoadColumn(288)]
        public float dVolatility4;
        [LoadColumn(289)]
        public float dVolatility8;
        [LoadColumn(290)]
        public float dVolatility16;
        [LoadColumn(291)]
        public float dVolatility32;
        [LoadColumn(292)]
        public float dVolatility64;
        [LoadColumn(293)]
        public float dVolatility128;
        [LoadColumn(294)]
        public float dVolatility256;
        [LoadColumn(295)]
        public float dVolatility512;
        [LoadColumn(296)]
        public float dVolMomentum1;
        [LoadColumn(297)]
        public float dVolMomentum2;
        [LoadColumn(298)]
        public float dVolMomentum4;
        [LoadColumn(299)]
        public float dVolMomentum8;
        [LoadColumn(300)]
        public float dVolMomentum16;
        [LoadColumn(301)]
        public float dVolMomentum32;
        [LoadColumn(302)]
        public float dVolMomentum64;
        [LoadColumn(303)]
        public float dVolMomentum128;
        [LoadColumn(304)]
        public float dVolMomentum256;
        [LoadColumn(305)]
        public float dVolMomentum512;
        [LoadColumn(306)]
        public float Sample;
        public Learn2()
        {
            //constructor?
        }
        // loop for each ticker, and take the best 3 and the worst 3.
        //first make the data
        //have a way to rate the data
        //"Specify data preparation and model training pipeline"
        //Train model(somehow)
        //...make a prediction?
        //Compare predicted price and real price.
        //test data.
        //compare predicted and test data.
        public void Start(int SplitStart, double timespan, String date1 = "", Schema b = null)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
    CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
            CloudFileShare share = fileClient.GetShareReference("stockdata");
            if (!share.Exists()) throw new Exception("no share");
            var rootDir = share.GetRootDirectoryReference();
            //this simply connects to an azure database.
            MLContext mlcontext = new MLContext(seed: 0);
            BuildModel(mlcontext, b, rootDir, SplitStart, timespan, date1);






            //make an int array that = the length of the ticker list.
            //output each result into this float* array
            //get the number of the worst and best 3 through a sorting algorithm. 
            //output is 3 stocks to buy, 3 stocks to sell, and expected outcome.
            //test it on a given day and see how the results match the real deal.
        }
        private static void BuildModel(MLContext mlcontext, Schema b, CloudFileDirectory dir, int SplitStart, double Timespan, String date1)
        {
            //this calls to find a file.
            List<string> list = new List<string>();
            var profiles = Profile.ReadFile();
            foreach (var ticker in profiles.Keys)
            {

                string file = findFile(ticker, b);
                if (file == null)
                {
                    continue;
                }
                using (CloudTextReader tr = new CloudTextReader(file))
                {
                    string line = tr.ReadLine();
                    while (null != (line = tr.ReadLine()))
                    {
                        if (line.StartsWith("d"))
                        {

                        }
                        else
                            list.Add(line);
                    }
                }
            }
            //this is a fairly basic ML.net code
            IDataView trainingdata = mlcontext.Data.LoadFromEnumerable<Learn2>(Mydata(list));

            var split = mlcontext.Data.TrainTestSplit(trainingdata, 0.1, "Sample");

            var UpTrain = mlcontext.Data.FilterRowsByColumn(trainingdata, "date", lowerBound: SplitStart - Timespan - 600, SplitStart - Timespan);
            var trainer = mlcontext.Regression.Trainers.FastTreeTweedie(labelColumnName: "Label", featureColumnName: "Features", exampleWeightColumnName: "Date");
            var dataProcessPipeline =
mlcontext.Transforms.Concatenate(outputColumnName: "volatilityfeatures", nameof(Learn2.volatility1), nameof(Learn2.volatility2), nameof(Learn2.volatility4), nameof(Learn2.volatility8), nameof(Learn2.volatility16), nameof(Learn2.volatility32), nameof(Learn2.volatility64), nameof(Learn2.volatility128), nameof(Learn2.volatility256), nameof(Learn2.volatility512))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "momentumfeatures", nameof(Learn2.momentum1), nameof(Learn2.momentum2), nameof(Learn2.momentum4), nameof(Learn2.momentum8), nameof(Learn2.momentum16), nameof(Learn2.momentum32), nameof(Learn2.momentum64), nameof(Learn2.momentum128), nameof(Learn2.momentum256), nameof(Learn2.momentum512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "volmomentumfeatures", nameof(Learn2.volmomentum1), nameof(Learn2.volmomentum2), nameof(Learn2.volmomentum4), nameof(Learn2.volmomentum8), nameof(Learn2.volmomentum16), nameof(Learn2.volmomentum32), nameof(Learn2.volmomentum64), nameof(Learn2.volmomentum128), nameof(Learn2.volmomentum256), nameof(Learn2.volmomentum512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "revenuemomentumfeatures", nameof(Learn2.revenuemomentum1), nameof(Learn2.revenuemomentum2), nameof(Learn2.revenuemomentum4), nameof(Learn2.revenuemomentum8), nameof(Learn2.revenuemomentum16), nameof(Learn2.revenuemomentum32), nameof(Learn2.revenuemomentum64), nameof(Learn2.revenuemomentum128), nameof(Learn2.revenuemomentum256), nameof(Learn2.revenuemomentum512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "earningsmomentumfeatures", nameof(Learn2.earningsmomentum1), nameof(Learn2.earningsmomentum2), nameof(Learn2.earningsmomentum4), nameof(Learn2.earningsmomentum8), nameof(Learn2.earningsmomentum16), nameof(Learn2.earningsmomentum32), nameof(Learn2.earningsmomentum64), nameof(Learn2.earningsmomentum128), nameof(Learn2.earningsmomentum256), nameof(Learn2.earningsmomentum512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "equitymomentumfeatures", nameof(Learn2.equitymomentum1), nameof(Learn2.equitymomentum2), nameof(Learn2.equitymomentum4), nameof(Learn2.equitymomentum8), nameof(Learn2.equitymomentum16), nameof(Learn2.equitymomentum32), nameof(Learn2.equitymomentum64), nameof(Learn2.equitymomentum128), nameof(Learn2.equitymomentum256), nameof(Learn2.equitymomentum512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "treasurymomentumfeatures", nameof(Learn2.treasurymomentum1), nameof(Learn2.treasurymomentum2), nameof(Learn2.treasurymomentum4), nameof(Learn2.treasurymomentum8), nameof(Learn2.treasurymomentum16), nameof(Learn2.treasurymomentum32), nameof(Learn2.treasurymomentum64), nameof(Learn2.treasurymomentum128), nameof(Learn2.treasurymomentum256), nameof(Learn2.treasurymomentum512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "earningspertreasurymomentumfeatures", nameof(Learn2.earningspertreasurymomentum1), nameof(Learn2.earningspertreasurymomentum2), nameof(Learn2.earningspertreasurymomentum4), nameof(Learn2.earningspertreasurymomentum8), nameof(Learn2.earningspertreasurymomentum16), nameof(Learn2.earningspertreasurymomentum32), nameof(Learn2.earningspertreasurymomentum64), nameof(Learn2.earningspertreasurymomentum128), nameof(Learn2.earningspertreasurymomentum256), nameof(Learn2.earningspertreasurymomentum512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "volatilityIfeatures", nameof(Learn2.volatilityI1), nameof(Learn2.volatilityI2), nameof(Learn2.volatilityI4), nameof(Learn2.volatilityI8), nameof(Learn2.volatilityI16), nameof(Learn2.volatilityI32), nameof(Learn2.volatilityI64), nameof(Learn2.volatilityI128), nameof(Learn2.volatilityI256), nameof(Learn2.volatilityI512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: " momentumIfeatures", nameof(Learn2.momentumI1), nameof(Learn2.momentumI2), nameof(Learn2.momentumI4), nameof(Learn2.momentumI8), nameof(Learn2.momentumI16), nameof(Learn2.momentumI32), nameof(Learn2.momentumI64), nameof(Learn2.momentumI128), nameof(Learn2.momentumI256), nameof(Learn2.momentumI512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "volmomentumIfeatures", nameof(Learn2.volmomentumI1), nameof(Learn2.volmomentumI2), nameof(Learn2.volmomentumI4), nameof(Learn2.volmomentumI8), nameof(Learn2.volmomentumI16), nameof(Learn2.volmomentumI32), nameof(Learn2.volmomentumI64), nameof(Learn2.volmomentumI128), nameof(Learn2.volmomentumI256), nameof(Learn2.volmomentumI512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "volatilitySfeatures", nameof(Learn2.volatilityS1), nameof(Learn2.volatilityS2), nameof(Learn2.volatilityS4), nameof(Learn2.volatilityS8), nameof(Learn2.volatilityS16), nameof(Learn2.volatilityS32), nameof(Learn2.volatilityS64), nameof(Learn2.volatilityS128), nameof(Learn2.volatilityS256), nameof(Learn2.volatilityS512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "momentumSfeatures", nameof(Learn2.momentumS1), nameof(Learn2.momentumS2), nameof(Learn2.momentumS4), nameof(Learn2.momentumS8), nameof(Learn2.momentumS16), nameof(Learn2.momentumS32), nameof(Learn2.momentumS64), nameof(Learn2.momentumS128), nameof(Learn2.momentumS256), nameof(Learn2.momentumS512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "volmomentumSfeatures", nameof(Learn2.volmomentumS1), nameof(Learn2.volmomentumS2), nameof(Learn2.volmomentumS4), nameof(Learn2.volmomentumS8), nameof(Learn2.volmomentumS16), nameof(Learn2.volmomentumS32), nameof(Learn2.volmomentumS64), nameof(Learn2.volmomentumS128), nameof(Learn2.volmomentumS256), nameof(Learn2.volmomentumS512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "momentumYfeatures", nameof(Learn2.momentumY1), nameof(Learn2.momentumY2), nameof(Learn2.momentumY4), nameof(Learn2.momentumY8), nameof(Learn2.momentumY16), nameof(Learn2.momentumY32), nameof(Learn2.momentumY64), nameof(Learn2.momentumY128), nameof(Learn2.momentumY256), nameof(Learn2.momentumY512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "volmomentumYfeatures", nameof(Learn2.volmomentumY1), nameof(Learn2.volmomentumY2), nameof(Learn2.volmomentumY4), nameof(Learn2.volmomentumY8), nameof(Learn2.volmomentumY16), nameof(Learn2.volmomentumY32), nameof(Learn2.volmomentumY64), nameof(Learn2.volmomentumY128), nameof(Learn2.volmomentumY256), nameof(Learn2.volmomentumY512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "volatilityYfeatures", nameof(Learn2.volatilityY1), nameof(Learn2.volatilityY2), nameof(Learn2.volatilityY4), nameof(Learn2.volatilityY8), nameof(Learn2.volatilityY16), nameof(Learn2.volatilityY32), nameof(Learn2.volatilityY64), nameof(Learn2.volatilityY128), nameof(Learn2.volatilityY256), nameof(Learn2.volatilityY512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "rvolatilityIfeatures", nameof(Learn2.rvolatilityI1), nameof(Learn2.rvolatilityI2), nameof(Learn2.rvolatilityI4), nameof(Learn2.rvolatilityI8), nameof(Learn2.rvolatilityI16), nameof(Learn2.rvolatilityI32), nameof(Learn2.rvolatilityI64), nameof(Learn2.rvolatilityI128), nameof(Learn2.rvolatilityI256), nameof(Learn2.rvolatilityI512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "rmomentumIfeatures", nameof(Learn2.rmomentumI1), nameof(Learn2.rmomentumI2), nameof(Learn2.rmomentumI4), nameof(Learn2.rmomentumI8), nameof(Learn2.rmomentumI16), nameof(Learn2.rmomentumI32), nameof(Learn2.rmomentumI64), nameof(Learn2.rmomentumI128), nameof(Learn2.rmomentumI256), nameof(Learn2.rmomentumI512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "rvolmomentumIfeatures", nameof(Learn2.rvolmomentumI1), nameof(Learn2.rvolmomentumI2), nameof(Learn2.rvolmomentumI4), nameof(Learn2.rvolmomentumI8), nameof(Learn2.rvolmomentumI16), nameof(Learn2.rvolmomentumI32), nameof(Learn2.rvolmomentumI64), nameof(Learn2.rvolmomentumI128), nameof(Learn2.rvolmomentumI256), nameof(Learn2.rvolmomentumI512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "rvolatilitySfeatures", nameof(Learn2.rvolatilityS1), nameof(Learn2.rvolatilityS2), nameof(Learn2.rvolatilityS4), nameof(Learn2.rvolatilityS8), nameof(Learn2.rvolatilityS16), nameof(Learn2.rvolatilityS32), nameof(Learn2.rvolatilityS64), nameof(Learn2.rvolatilityS128), nameof(Learn2.rvolatilityS256), nameof(Learn2.rvolatilityS512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "rmomentumSfeatures", nameof(Learn2.rmomentumS1), nameof(Learn2.rmomentumS2), nameof(Learn2.rmomentumS4), nameof(Learn2.rmomentumS8), nameof(Learn2.rmomentumS16), nameof(Learn2.rmomentumS32), nameof(Learn2.rmomentumS64), nameof(Learn2.rmomentumS128), nameof(Learn2.rmomentumS256), nameof(Learn2.rmomentumS512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "rvolmomentumSfeatures", nameof(Learn2.rvolmomentumS1), nameof(Learn2.rvolmomentumS2), nameof(Learn2.rvolmomentumS4), nameof(Learn2.rvolmomentumS8), nameof(Learn2.rvolmomentumS16), nameof(Learn2.rvolmomentumS32), nameof(Learn2.rvolmomentumS64), nameof(Learn2.rvolmomentumS128), nameof(Learn2.rvolmomentumS256), nameof(Learn2.rvolmomentumS512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "rmomentumYfeatures", nameof(Learn2.rmomentumY1), nameof(Learn2.rmomentumY2), nameof(Learn2.rmomentumY4), nameof(Learn2.rmomentumY8), nameof(Learn2.rmomentumY16), nameof(Learn2.rmomentumY32), nameof(Learn2.rmomentumY64), nameof(Learn2.rmomentumY128), nameof(Learn2.rmomentumY256), nameof(Learn2.rmomentumY512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "rvolmomentumYfeatures", nameof(Learn2.rvolmomentumY1), nameof(Learn2.rvolmomentumY2), nameof(Learn2.rvolmomentumY4), nameof(Learn2.rvolmomentumY8), nameof(Learn2.rvolmomentumY16), nameof(Learn2.rvolmomentumY32), nameof(Learn2.rvolmomentumY64), nameof(Learn2.rvolmomentumY128), nameof(Learn2.rvolmomentumY256), nameof(Learn2.rvolmomentumY512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "rvolatilityYfeatures", nameof(Learn2.rvolatilityY1), nameof(Learn2.rvolatilityY2), nameof(Learn2.rvolatilityY4), nameof(Learn2.rvolatilityY8), nameof(Learn2.rvolatilityY16), nameof(Learn2.rvolatilityY32), nameof(Learn2.rvolatilityY64), nameof(Learn2.rvolatilityY128), nameof(Learn2.rvolatilityY256), nameof(Learn2.rvolatilityY512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "dMomentumfeatures", nameof(Learn2.dMomentum1), nameof(Learn2.dMomentum2), nameof(Learn2.dMomentum4), nameof(Learn2.dMomentum8), nameof(Learn2.dMomentum16), nameof(Learn2.dMomentum32), nameof(Learn2.dMomentum64), nameof(Learn2.dMomentum128), nameof(Learn2.dMomentum256), nameof(Learn2.dMomentum512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "dVolatilityfeatures", nameof(Learn2.dVolatility1), nameof(Learn2.dVolatility2), nameof(Learn2.dVolatility4), nameof(Learn2.dVolatility8), nameof(Learn2.dVolatility16), nameof(Learn2.dVolatility32), nameof(Learn2.dVolatility64), nameof(Learn2.dVolatility128), nameof(Learn2.dVolatility256), nameof(Learn2.dVolatility512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "dVolMomentumfeatures", nameof(Learn2.dVolMomentum1), nameof(Learn2.dVolMomentum2), nameof(Learn2.dVolMomentum4), nameof(Learn2.dVolMomentum8), nameof(Learn2.dVolMomentum16), nameof(Learn2.dVolMomentum32), nameof(Learn2.dVolMomentum64), nameof(Learn2.dVolMomentum128), nameof(Learn2.dVolMomentum256), nameof(Learn2.dVolMomentum512)))
.Append(mlcontext.Transforms.Concatenate(outputColumnName: "Features", nameof(Learn2.overnight),
nameof(Learn2.cap), nameof(Learn2.capFracIndex), nameof(Learn2.capFracSector), nameof(Learn2.capFracIndustry),
nameof(Learn2.rev), nameof(Learn2.earn), nameof(Learn2.equity), nameof(Learn2.volume), nameof(Learn2.adjearn),
nameof(Learn2.treasury10Y), nameof(Learn2.last), nameof(Learn2.open), nameof(Learn2.close),
"volatilityfeatures", "momentumfeatures", "volmomentumfeatures", "revenuemomentumfeatures",
"earningsmomentumfeatures", "equitymomentumfeatures", "treasurymomentumfeatures",
"earningspertreasurymomentumfeatures", "volatilityIfeatures", " momentumIfeatures",
"volmomentumIfeatures", "volatilitySfeatures", "momentumSfeatures", "volmomentumSfeatures",
"momentumYfeatures", "volmomentumYfeatures", "volatilityYfeatures", "rvolatilityIfeatures",
"rmomentumIfeatures", "rvolmomentumIfeatures", "rvolatilitySfeatures", "rmomentumSfeatures",
"rvolmomentumSfeatures", "rmomentumYfeatures", "rvolmomentumYfeatures", "rvolatilityYfeatures",
"dMomentumfeatures", "dVolatilityfeatures", "dVolMomentumfeatures")).Append(mlcontext.Transforms.CopyColumns("Date", (nameof(Learn2.date))))
.Append(mlcontext.Transforms.CopyColumns("Label", nameof(Learn2.result)).Append(trainer));

            //      var crossValidationResults = mlcontext.Regression.CrossValidate(data: trainingdata, estimator: dataProcessPipeline, numberOfFolds: 6, labelColumnName: "Label");
            try
            {
                String filestring;
                var model = dataProcessPipeline.Fit(UpTrain);
                if (date1 == "")
                {
                    filestring = $"C:/TickerRegression/Regress{date1}.zip";
                }
                else
                {
                    filestring = $"C:/TickerRegression/RegressTest/Regress{date1}.zip";
                }
                foreach (var ticker in profiles)
                {
                    Ticker a = ticker.Key;
                    System.IO.Directory.CreateDirectory($"C:/TickerRegression/");
                    //  using (var tw = File.OpenWrite($"C:/TickerRegression/Regress.zip"))
                    //  {
                    mlcontext.Model.Save(model, UpTrain.Schema, filestring);
                    //   }
                    var predictionEngine = mlcontext.Model.CreatePredictionEngine<Learn2, VectorPrediction>(model);
                    Console.WriteLine($"Becoming human with {a.LC}!");
                    List<string> tickerlist = new List<string>();
                    string file = findFile(a, b);
                    if (file == null)
                    {
                        continue;
                    }
                    using (CloudTextReader tr = new CloudTextReader(file))
                    {
                        string line = tr.ReadLine();
                        while (null != (line = tr.ReadLine()))
                        {
                            if (line.StartsWith("d"))
                            {

                            }
                            else
                                tickerlist.Add(line);
                        }
                    }
                    var tickerdata = mlcontext.Data.LoadFromEnumerable<Learn2>(Mydata(tickerlist));
                    UpTrain = mlcontext.Data.FilterRowsByColumn(tickerdata, "date", lowerBound: SplitStart - Timespan - 600, SplitStart - Timespan);
                    var UpTest = mlcontext.Data.FilterRowsByColumn(tickerdata, "date", SplitStart - Timespan, SplitStart - Timespan + 1);
                    var trainset = mlcontext.Data.CreateEnumerable<Learn2>(UpTrain, reuseRowObject: false);
                    var testset = mlcontext.Data.CreateEnumerable<Learn2>(UpTest, true);

                    int i = 0;

                    foreach (var row in testset)
                    {
                        //this organizes the data so it sorts by top 3 as it goes through
                        if (i == Learn2Cmd.date.Length)
                            break;
                        VectorPrediction prediction = predictionEngine.Predict(row);
                        Console.WriteLine($"Date: {new DateTime(1998, 12, 1).AddDays(row.date)}");
                        if (prediction.Score.Equals(0))
                            Console.WriteLine($"{a.LC} failed!");
                        else
                        {
                            if (Learn2Cmd.rank[0, i] <= prediction.Score)
                            {
                                Learn2Cmd.rank[2, i] = Learn2Cmd.rank[1, i];
                                Learn2Cmd.tickrank[2, i] = Learn2Cmd.tickrank[1, i];
                                Learn2Cmd.rank[1, i] = Learn2Cmd.rank[0, i];
                                Learn2Cmd.tickrank[1, i] = Learn2Cmd.tickrank[0, i];
                                Learn2Cmd.rank[0, i] = prediction.Score;
                                Learn2Cmd.tickrank[0, i] = a.LC;
                            }
                            else if (Learn2Cmd.rank[1, i] <= prediction.Score)
                            {
                                Learn2Cmd.rank[2, i] = Learn2Cmd.rank[1, i];
                                Learn2Cmd.tickrank[2, i] = Learn2Cmd.tickrank[1, i];
                                Learn2Cmd.rank[1, i] = prediction.Score;
                                Learn2Cmd.tickrank[1, i] = a.LC;
                            }
                            else if (Learn2Cmd.rank[2, i] <= prediction.Score)
                            {
                                Learn2Cmd.rank[2, i] = prediction.Score;
                                Learn2Cmd.tickrank[2, i] = a.LC;
                            }
                            if (Learn2Cmd.rank[5, i] >= prediction.Score || Learn2Cmd.rank[5, i] == 0)
                            {
                                Learn2Cmd.rank[3, i] = Learn2Cmd.rank[4, i];
                                Learn2Cmd.tickrank[3, i] = Learn2Cmd.tickrank[4, i];
                                Learn2Cmd.rank[4, i] = Learn2Cmd.rank[5, i];
                                Learn2Cmd.tickrank[4, i] = Learn2Cmd.tickrank[5, i];
                                Learn2Cmd.rank[5, i] = prediction.Score;
                                Learn2Cmd.tickrank[5, i] = a.LC;
                            }
                            else if (Learn2Cmd.rank[4, i] >= prediction.Score || Learn2Cmd.rank[4, i] == 0)
                            {
                                Learn2Cmd.rank[3, i] = Learn2Cmd.rank[4, i];
                                Learn2Cmd.tickrank[3, i] = Learn2Cmd.tickrank[4, i];
                                Learn2Cmd.rank[4, i] = prediction.Score;
                                Learn2Cmd.tickrank[4, i] = a.LC;
                            }
                            else if (Learn2Cmd.rank[3, i] >= prediction.Score || Learn2Cmd.rank[3, i] == 0)
                            {
                                Learn2Cmd.rank[3, i] = prediction.Score;
                                Learn2Cmd.tickrank[3, i] = a.LC;
                            }
                            Learn2Cmd.date[i] = new DateTime(1998, 12, 1).AddDays(row.date);
                            Console.WriteLine($"Prediction: {prediction.Score} Real value: {row.result}");
                            Console.WriteLine($"Variance: {prediction.Score / row.result}");
                        }
                        i++;

                    }
                }
            }
            catch (Exception d)
            {
                Console.WriteLine($"failed due to {d}");
            }

        }

        public static void TestCurr(int startdate, string fileadd = "")
        {

            //this is a seperate code from my earlier code which uses my (preused model) so I can compare models.
            var profiles = Profile.ReadFile();
            foreach (var ticker in profiles)
            {
                try
                {

                    Ticker a = ticker.Key;
                    MLContext mlcontext = new MLContext();
                    ITransformer trainedmodel;
                    DataViewSchema modelInputSchema;
                    var filestring = $"C:/TickerRegression/RegressTest/Regress{fileadd}.zip";

                    trainedmodel = mlcontext.Model.Load(filestring, out modelInputSchema);
                    var predictionEngine = mlcontext.Model.CreatePredictionEngine<Learn2, VectorPrediction>(trainedmodel);
                    Console.WriteLine($"Becoming human with {a.LC}!");
                    List<string> tickerlist = new List<string>();
                    string file = findFile(a, null);
                    if (file == null)
                    {
                        continue;
                    }
                    using (CloudTextReader tr = new CloudTextReader(file))
                    {
                        string line = tr.ReadLine();
                        while (null != (line = tr.ReadLine()))
                        {
                            if (line.StartsWith("d"))
                            {

                            }
                            else
                                tickerlist.Add(line);
                        }
                        var tickerdata = mlcontext.Data.LoadFromEnumerable<Learn2>(Mydata(tickerlist));
                        var UpTest = mlcontext.Data.FilterRowsByColumn(tickerdata, "date", startdate, startdate + 30);
                        var testset = mlcontext.Data.CreateEnumerable<Learn2>(UpTest, true);
                        int i = 0;
                        //similar ranking system from earlier.
                        foreach (var row in testset)
                        {
                            if (i == Learn2Cmd.date.Length)
                                break;
                            VectorPrediction prediction = predictionEngine.Predict(row);
                            Console.WriteLine($"Date: {new DateTime(1998, 12, 1).AddDays(row.date)}");
                            if (prediction.Score.Equals(0))
                                Console.WriteLine($"{a.LC} failed!");
                            else
                            {
                                if (Learn2Cmd.rank[0, i] <= prediction.Score)
                                {
                                    Learn2Cmd.rank[2, i] = Learn2Cmd.rank[1, i];
                                    Learn2Cmd.tickrank[2, i] = Learn2Cmd.tickrank[1, i];
                                    Learn2Cmd.rank[1, i] = Learn2Cmd.rank[0, i];
                                    Learn2Cmd.tickrank[1, i] = Learn2Cmd.tickrank[0, i];
                                    Learn2Cmd.rank[0, i] = prediction.Score;
                                    Learn2Cmd.tickrank[0, i] = a.LC;
                                }
                                else if (Learn2Cmd.rank[1, i] <= prediction.Score)
                                {
                                    Learn2Cmd.rank[2, i] = Learn2Cmd.rank[1, i];
                                    Learn2Cmd.tickrank[2, i] = Learn2Cmd.tickrank[1, i];
                                    Learn2Cmd.rank[1, i] = prediction.Score;
                                    Learn2Cmd.tickrank[1, i] = a.LC;
                                }
                                else if (Learn2Cmd.rank[2, i] <= prediction.Score)
                                {
                                    Learn2Cmd.rank[2, i] = prediction.Score;
                                    Learn2Cmd.tickrank[2, i] = a.LC;
                                }
                                if (Learn2Cmd.rank[5, i] >= prediction.Score || Learn2Cmd.rank[5, i] == 0)
                                {
                                    Learn2Cmd.rank[3, i] = Learn2Cmd.rank[4, i];
                                    Learn2Cmd.tickrank[3, i] = Learn2Cmd.tickrank[4, i];
                                    Learn2Cmd.rank[4, i] = Learn2Cmd.rank[5, i];
                                    Learn2Cmd.tickrank[4, i] = Learn2Cmd.tickrank[5, i];
                                    Learn2Cmd.rank[5, i] = prediction.Score;
                                    Learn2Cmd.tickrank[5, i] = a.LC;
                                }
                                else if (Learn2Cmd.rank[4, i] >= prediction.Score || Learn2Cmd.rank[4, i] == 0)
                                {
                                    Learn2Cmd.rank[3, i] = Learn2Cmd.rank[4, i];
                                    Learn2Cmd.tickrank[3, i] = Learn2Cmd.tickrank[4, i];
                                    Learn2Cmd.rank[4, i] = prediction.Score;
                                    Learn2Cmd.tickrank[4, i] = a.LC;
                                }
                                else if (Learn2Cmd.rank[3, i] >= prediction.Score || Learn2Cmd.rank[3, i] == 0)
                                {
                                    Learn2Cmd.rank[3, i] = prediction.Score;
                                    Learn2Cmd.tickrank[3, i] = a.LC;
                                }
                                Learn2Cmd.date[i] = new DateTime(1998, 12, 1).AddDays(row.date);
                                Console.WriteLine($"Prediction: {prediction.Score} Real value: {row.result}");
                                Console.WriteLine($"Variance: {prediction.Score / row.result}");
                            }
                            i++;

                        }
                    }
                }
                catch (Exception d)
                {
                    Console.WriteLine($"failed due to {d}");
                }


            }

        }


        public static double regress(Ticker a, Schema b)
        {
            //this returns the data for a single day, instead of looping through an predetermined amount of time.
            try
            {
                MLContext mlcontext = new MLContext();
                ITransformer trainedmodel;
                DataViewSchema modelInputSchema;
                var filestring = $"C:/TickerRegression/Regress.zip";

                trainedmodel = mlcontext.Model.Load(filestring, out modelInputSchema);

                var predictionEngine = mlcontext.Model.CreatePredictionEngine<Learn2, VectorPrediction>(trainedmodel);
                List<String> tickerlist = new List<string>();

                using (CloudTextReader tr = new CloudTextReader($"{a.LC}/babycsv.csv"))
                {
                    string line = tr.ReadLine();
                    tickerlist.Add(line);

                }
                var tickerdata = mlcontext.Data.LoadFromEnumerable<Learn2>(Mydata(tickerlist));
                var split = tickerlist[0].Split(',');
                var SplitStart = Double.Parse(split[0]);
                var UpTest = mlcontext.Data.FilterRowsByColumn(tickerdata, "date", SplitStart, SplitStart + 1);
                var testset = mlcontext.Data.CreateEnumerable<Learn2>(UpTest, true);
                foreach (var row in testset)
                {
                    VectorPrediction prediction = predictionEngine.Predict(row);
                    return prediction.Score;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public static String findFile(Ticker a, Schema b)
        {
            String filedir = Vector.FileDirectoryCSVName(a, b);
            List<String> filelist = new List<String>();
            foreach (var file in Cloud.EnumerateFiles(filedir))
            {
                filelist.Add(file);
            }
            filelist.Sort();
            filelist.Reverse();
            if (filelist.Count() == 0)
            {
                Console.WriteLine($"{a.LC} has no csv");
                return null;
            }
            return filelist[0];
        }

        public static IEnumerable<Learn2> Mydata(List<string> list)
        {


            foreach (String s in list)
            {


                Learn2 l = new Learn2();
                string[] v = s.Split(',');


                l.date = (float)Double.Parse(v[0].ToString());
                l.last = (float)Double.Parse(v[1].ToString());
                l.open = (float)Double.Parse(v[2].ToString());
                l.close = (float)Double.Parse(v[3].ToString());
                l.result = (float)Double.Parse(v[4].ToString());
                l.overnight = (float)Double.Parse(v[5].ToString());
                l.cap = (float)Double.Parse(v[6].ToString());
                l.capFracIndex = (float)Double.Parse(v[7].ToString());
                l.capFracSector = (float)Double.Parse(v[8].ToString());
                l.capFracIndustry = (float)Double.Parse(v[9].ToString());
                l.rev = (float)Double.Parse(v[10].ToString());
                l.earn = (float)Double.Parse(v[11].ToString());
                l.equity = (float)Double.Parse(v[12].ToString());
                l.volume = (float)Double.Parse(v[13].ToString());
                l.adjearn = (float)Double.Parse(v[14].ToString());
                l.treasury10Y = (float)Double.Parse(v[15].ToString());
                l.volatility1 = (float)Double.Parse(v[16].ToString()); l.volatility2 = (float)Double.Parse(v[17].ToString()); l.volatility4 = (float)Double.Parse(v[18].ToString()); l.volatility8 = (float)Double.Parse(v[19].ToString()); l.volatility16 = (float)Double.Parse(v[20].ToString()); l.volatility32 = (float)Double.Parse(v[21].ToString()); l.volatility64 = (float)Double.Parse(v[22].ToString()); l.volatility128 = (float)Double.Parse(v[23].ToString()); l.volatility256 = (float)Double.Parse(v[24].ToString()); l.volatility512 = (float)Double.Parse(v[25].ToString());
                l.momentum1 = (float)Double.Parse(v[26].ToString()); l.momentum2 = (float)Double.Parse(v[27].ToString()); l.momentum4 = (float)Double.Parse(v[28].ToString()); l.momentum8 = (float)Double.Parse(v[29].ToString()); l.momentum16 = (float)Double.Parse(v[30].ToString()); l.momentum32 = (float)Double.Parse(v[31].ToString()); l.momentum64 = (float)Double.Parse(v[32].ToString()); l.momentum128 = (float)Double.Parse(v[33].ToString()); l.momentum256 = (float)Double.Parse(v[34].ToString()); l.momentum512 = (float)Double.Parse(v[35].ToString());
                l.volmomentum1 = (float)Double.Parse(v[36].ToString()); l.volmomentum2 = (float)Double.Parse(v[37].ToString()); l.volmomentum4 = (float)Double.Parse(v[38].ToString()); l.volmomentum8 = (float)Double.Parse(v[39].ToString()); l.volmomentum16 = (float)Double.Parse(v[40].ToString()); l.volmomentum32 = (float)Double.Parse(v[41].ToString()); l.volmomentum64 = (float)Double.Parse(v[42].ToString()); l.volmomentum128 = (float)Double.Parse(v[43].ToString()); l.volmomentum256 = (float)Double.Parse(v[44].ToString()); l.volmomentum512 = (float)Double.Parse(v[45].ToString());
                l.revenuemomentum1 = (float)Double.Parse(v[46].ToString()); l.revenuemomentum2 = (float)Double.Parse(v[47].ToString()); l.revenuemomentum4 = (float)Double.Parse(v[48].ToString()); l.revenuemomentum8 = (float)Double.Parse(v[49].ToString()); l.revenuemomentum16 = (float)Double.Parse(v[50].ToString()); l.revenuemomentum32 = (float)Double.Parse(v[51].ToString()); l.revenuemomentum64 = (float)Double.Parse(v[52].ToString()); l.revenuemomentum128 = (float)Double.Parse(v[53].ToString()); l.revenuemomentum256 = (float)Double.Parse(v[54].ToString()); l.revenuemomentum512 = (float)Double.Parse(v[55].ToString());
                l.earningsmomentum1 = (float)Double.Parse(v[56].ToString()); l.earningsmomentum2 = (float)Double.Parse(v[57].ToString()); l.earningsmomentum4 = (float)Double.Parse(v[58].ToString()); l.earningsmomentum8 = (float)Double.Parse(v[59].ToString()); l.earningsmomentum16 = (float)Double.Parse(v[60].ToString()); l.earningsmomentum32 = (float)Double.Parse(v[61].ToString()); l.earningsmomentum64 = (float)Double.Parse(v[62].ToString()); l.earningsmomentum128 = (float)Double.Parse(v[63].ToString()); l.earningsmomentum256 = (float)Double.Parse(v[64].ToString()); l.earningsmomentum512 = (float)Double.Parse(v[65].ToString());
                l.equitymomentum1 = (float)Double.Parse(v[66].ToString()); l.equitymomentum2 = (float)Double.Parse(v[67].ToString()); l.equitymomentum4 = (float)Double.Parse(v[68].ToString()); l.equitymomentum8 = (float)Double.Parse(v[69].ToString()); l.equitymomentum16 = (float)Double.Parse(v[70].ToString()); l.equitymomentum32 = (float)Double.Parse(v[71].ToString()); l.equitymomentum64 = (float)Double.Parse(v[72].ToString()); l.equitymomentum128 = (float)Double.Parse(v[73].ToString()); l.equitymomentum256 = (float)Double.Parse(v[74].ToString()); l.equitymomentum512 = (float)Double.Parse(v[75].ToString());
                l.treasurymomentum1 = (float)Double.Parse(v[76].ToString()); l.treasurymomentum2 = (float)Double.Parse(v[77].ToString()); l.treasurymomentum4 = (float)Double.Parse(v[78].ToString()); l.treasurymomentum8 = (float)Double.Parse(v[79].ToString()); l.treasurymomentum16 = (float)Double.Parse(v[80].ToString()); l.treasurymomentum32 = (float)Double.Parse(v[81].ToString()); l.treasurymomentum64 = (float)Double.Parse(v[82].ToString()); l.treasurymomentum128 = (float)Double.Parse(v[83].ToString()); l.treasurymomentum256 = (float)Double.Parse(v[84].ToString()); l.treasurymomentum512 = (float)Double.Parse(v[85].ToString());
                l.earningspertreasurymomentum1 = (float)Double.Parse(v[86].ToString()); l.earningspertreasurymomentum2 = (float)Double.Parse(v[87].ToString()); l.earningspertreasurymomentum4 = (float)Double.Parse(v[88].ToString()); l.earningspertreasurymomentum8 = (float)Double.Parse(v[89].ToString()); l.earningspertreasurymomentum16 = (float)Double.Parse(v[90].ToString()); l.earningspertreasurymomentum32 = (float)Double.Parse(v[91].ToString()); l.earningspertreasurymomentum64 = (float)Double.Parse(v[92].ToString()); l.earningspertreasurymomentum128 = (float)Double.Parse(v[93].ToString()); l.earningspertreasurymomentum256 = (float)Double.Parse(v[94].ToString()); l.earningspertreasurymomentum512 = (float)Double.Parse(v[95].ToString());
                l.volatilityI1 = (float)Double.Parse(v[96].ToString()); l.volatilityI2 = (float)Double.Parse(v[97].ToString()); l.volatilityI4 = (float)Double.Parse(v[98].ToString()); l.volatilityI8 = (float)Double.Parse(v[99].ToString()); l.volatilityI16 = (float)Double.Parse(v[100].ToString()); l.volatilityI32 = (float)Double.Parse(v[101].ToString()); l.volatilityI64 = (float)Double.Parse(v[102].ToString()); l.volatilityI128 = (float)Double.Parse(v[103].ToString()); l.volatilityI256 = (float)Double.Parse(v[104].ToString()); l.volatilityI512 = (float)Double.Parse(v[105].ToString());
                l.momentumI1 = (float)Double.Parse(v[106].ToString()); l.momentumI2 = (float)Double.Parse(v[107].ToString()); l.momentumI4 = (float)Double.Parse(v[108].ToString()); l.momentumI8 = (float)Double.Parse(v[109].ToString()); l.momentumI16 = (float)Double.Parse(v[110].ToString()); l.momentumI32 = (float)Double.Parse(v[111].ToString()); l.momentumI64 = (float)Double.Parse(v[112].ToString()); l.momentumI128 = (float)Double.Parse(v[113].ToString()); l.momentumI256 = (float)Double.Parse(v[114].ToString()); l.momentumI512 = (float)Double.Parse(v[115].ToString());
                l.volmomentumI1 = (float)Double.Parse(v[116].ToString()); l.volmomentumI2 = (float)Double.Parse(v[117].ToString()); l.volmomentumI4 = (float)Double.Parse(v[118].ToString()); l.volmomentumI8 = (float)Double.Parse(v[119].ToString()); l.volmomentumI16 = (float)Double.Parse(v[120].ToString()); l.volmomentumI32 = (float)Double.Parse(v[121].ToString()); l.volmomentumI64 = (float)Double.Parse(v[122].ToString()); l.volmomentumI128 = (float)Double.Parse(v[123].ToString()); l.volmomentumI256 = (float)Double.Parse(v[124].ToString()); l.volmomentumI512 = (float)Double.Parse(v[125].ToString());
                l.volatilityS1 = (float)Double.Parse(v[126].ToString()); l.volatilityS2 = (float)Double.Parse(v[127].ToString()); l.volatilityS4 = (float)Double.Parse(v[128].ToString()); l.volatilityS8 = (float)Double.Parse(v[129].ToString()); l.volatilityS16 = (float)Double.Parse(v[130].ToString()); l.volatilityS32 = (float)Double.Parse(v[131].ToString()); l.volatilityS64 = (float)Double.Parse(v[132].ToString()); l.volatilityS128 = (float)Double.Parse(v[133].ToString()); l.volatilityS256 = (float)Double.Parse(v[134].ToString()); l.volatilityS512 = (float)Double.Parse(v[135].ToString());
                l.momentumS1 = (float)Double.Parse(v[136].ToString()); l.momentumS2 = (float)Double.Parse(v[137].ToString()); l.momentumS4 = (float)Double.Parse(v[138].ToString()); l.momentumS8 = (float)Double.Parse(v[139].ToString()); l.momentumS16 = (float)Double.Parse(v[140].ToString()); l.momentumS32 = (float)Double.Parse(v[141].ToString()); l.momentumS64 = (float)Double.Parse(v[142].ToString()); l.momentumS128 = (float)Double.Parse(v[143].ToString()); l.momentumS256 = (float)Double.Parse(v[144].ToString()); l.momentumS512 = (float)Double.Parse(v[145].ToString());
                l.volmomentumS1 = (float)Double.Parse(v[146].ToString()); l.volmomentumS2 = (float)Double.Parse(v[147].ToString()); l.volmomentumS4 = (float)Double.Parse(v[148].ToString()); l.volmomentumS8 = (float)Double.Parse(v[149].ToString()); l.volmomentumS16 = (float)Double.Parse(v[150].ToString()); l.volmomentumS32 = (float)Double.Parse(v[151].ToString()); l.volmomentumS64 = (float)Double.Parse(v[152].ToString()); l.volmomentumS128 = (float)Double.Parse(v[153].ToString()); l.volmomentumS256 = (float)Double.Parse(v[154].ToString()); l.volmomentumS512 = (float)Double.Parse(v[155].ToString());
                l.momentumY1 = (float)Double.Parse(v[156].ToString()); l.momentumY2 = (float)Double.Parse(v[157].ToString()); l.momentumY4 = (float)Double.Parse(v[158].ToString()); l.momentumY8 = (float)Double.Parse(v[159].ToString()); l.momentumY16 = (float)Double.Parse(v[160].ToString()); l.momentumY32 = (float)Double.Parse(v[161].ToString()); l.momentumY64 = (float)Double.Parse(v[162].ToString()); l.momentumY128 = (float)Double.Parse(v[163].ToString()); l.momentumY256 = (float)Double.Parse(v[164].ToString()); l.momentumY512 = (float)Double.Parse(v[165].ToString());
                l.volmomentumY1 = (float)Double.Parse(v[166].ToString()); l.volmomentumY2 = (float)Double.Parse(v[167].ToString()); l.volmomentumY4 = (float)Double.Parse(v[168].ToString()); l.volmomentumY8 = (float)Double.Parse(v[169].ToString()); l.volmomentumY16 = (float)Double.Parse(v[170].ToString()); l.volmomentumY32 = (float)Double.Parse(v[171].ToString()); l.volmomentumY64 = (float)Double.Parse(v[172].ToString()); l.volmomentumY128 = (float)Double.Parse(v[173].ToString()); l.volmomentumY256 = (float)Double.Parse(v[174].ToString()); l.volmomentumY512 = (float)Double.Parse(v[175].ToString());
                l.volatilityY1 = (float)Double.Parse(v[176].ToString()); l.volatilityY2 = (float)Double.Parse(v[177].ToString()); l.volatilityY4 = (float)Double.Parse(v[178].ToString()); l.volatilityY8 = (float)Double.Parse(v[179].ToString()); l.volatilityY16 = (float)Double.Parse(v[180].ToString()); l.volatilityY32 = (float)Double.Parse(v[181].ToString()); l.volatilityY64 = (float)Double.Parse(v[182].ToString()); l.volatilityY128 = (float)Double.Parse(v[183].ToString()); l.volatilityY256 = (float)Double.Parse(v[184].ToString()); l.volatilityY512 = (float)Double.Parse(v[185].ToString());
                l.rvolatilityI1 = (float)Double.Parse(v[186].ToString()); l.rvolatilityI2 = (float)Double.Parse(v[187].ToString()); l.rvolatilityI4 = (float)Double.Parse(v[188].ToString()); l.rvolatilityI8 = (float)Double.Parse(v[189].ToString()); l.rvolatilityI16 = (float)Double.Parse(v[190].ToString()); l.rvolatilityI32 = (float)Double.Parse(v[191].ToString()); l.rvolatilityI64 = (float)Double.Parse(v[192].ToString()); l.rvolatilityI128 = (float)Double.Parse(v[193].ToString()); l.rvolatilityI256 = (float)Double.Parse(v[194].ToString()); l.rvolatilityI512 = (float)Double.Parse(v[195].ToString());
                l.rmomentumI1 = (float)Double.Parse(v[196].ToString()); l.rmomentumI2 = (float)Double.Parse(v[197].ToString()); l.rmomentumI4 = (float)Double.Parse(v[198].ToString()); l.rmomentumI8 = (float)Double.Parse(v[199].ToString()); l.rmomentumI16 = (float)Double.Parse(v[200].ToString()); l.rmomentumI32 = (float)Double.Parse(v[201].ToString()); l.rmomentumI64 = (float)Double.Parse(v[202].ToString()); l.rmomentumI128 = (float)Double.Parse(v[203].ToString()); l.rmomentumI256 = (float)Double.Parse(v[204].ToString()); l.rmomentumI512 = (float)Double.Parse(v[205].ToString());
                l.rvolmomentumI1 = (float)Double.Parse(v[206].ToString()); l.rvolmomentumI2 = (float)Double.Parse(v[207].ToString()); l.rvolmomentumI4 = (float)Double.Parse(v[208].ToString()); l.rvolmomentumI8 = (float)Double.Parse(v[209].ToString()); l.rvolmomentumI16 = (float)Double.Parse(v[210].ToString()); l.rvolmomentumI32 = (float)Double.Parse(v[211].ToString()); l.rvolmomentumI64 = (float)Double.Parse(v[212].ToString()); l.rvolmomentumI128 = (float)Double.Parse(v[213].ToString()); l.rvolmomentumI256 = (float)Double.Parse(v[214].ToString()); l.rvolmomentumI512 = (float)Double.Parse(v[215].ToString());
                l.rvolatilityS1 = (float)Double.Parse(v[216].ToString()); l.rvolatilityS2 = (float)Double.Parse(v[217].ToString()); l.rvolatilityS4 = (float)Double.Parse(v[218].ToString()); l.rvolatilityS8 = (float)Double.Parse(v[219].ToString()); l.rvolatilityS16 = (float)Double.Parse(v[220].ToString()); l.rvolatilityS32 = (float)Double.Parse(v[221].ToString()); l.rvolatilityS64 = (float)Double.Parse(v[222].ToString()); l.rvolatilityS128 = (float)Double.Parse(v[223].ToString()); l.rvolatilityS256 = (float)Double.Parse(v[224].ToString()); l.rvolatilityS512 = (float)Double.Parse(v[225].ToString());
                l.rmomentumS1 = (float)Double.Parse(v[226].ToString()); l.rmomentumS2 = (float)Double.Parse(v[227].ToString()); l.rmomentumS4 = (float)Double.Parse(v[228].ToString()); l.rmomentumS8 = (float)Double.Parse(v[229].ToString()); l.rmomentumS16 = (float)Double.Parse(v[230].ToString()); l.rmomentumS32 = (float)Double.Parse(v[231].ToString()); l.rmomentumS64 = (float)Double.Parse(v[232].ToString()); l.rmomentumS128 = (float)Double.Parse(v[233].ToString()); l.rmomentumS256 = (float)Double.Parse(v[234].ToString()); l.rmomentumS512 = (float)Double.Parse(v[235].ToString());
                l.rvolmomentumS1 = (float)Double.Parse(v[236].ToString()); l.rvolmomentumS2 = (float)Double.Parse(v[237].ToString()); l.rvolmomentumS4 = (float)Double.Parse(v[238].ToString()); l.rvolmomentumS8 = (float)Double.Parse(v[239].ToString()); l.rvolmomentumS16 = (float)Double.Parse(v[240].ToString()); l.rvolmomentumS32 = (float)Double.Parse(v[241].ToString()); l.rvolmomentumS64 = (float)Double.Parse(v[242].ToString()); l.rvolmomentumS128 = (float)Double.Parse(v[243].ToString()); l.rvolmomentumS256 = (float)Double.Parse(v[244].ToString()); l.rvolmomentumS512 = (float)Double.Parse(v[245].ToString());
                l.rmomentumY1 = (float)Double.Parse(v[246].ToString()); l.rmomentumY2 = (float)Double.Parse(v[247].ToString()); l.rmomentumY4 = (float)Double.Parse(v[248].ToString()); l.rmomentumY8 = (float)Double.Parse(v[249].ToString()); l.rmomentumY16 = (float)Double.Parse(v[250].ToString()); l.rmomentumY32 = (float)Double.Parse(v[251].ToString()); l.rmomentumY64 = (float)Double.Parse(v[252].ToString()); l.rmomentumY128 = (float)Double.Parse(v[253].ToString()); l.rmomentumY256 = (float)Double.Parse(v[254].ToString()); l.rmomentumY512 = (float)Double.Parse(v[255].ToString());
                l.rvolmomentumY1 = (float)Double.Parse(v[256].ToString()); l.rvolmomentumY2 = (float)Double.Parse(v[257].ToString()); l.rvolmomentumY4 = (float)Double.Parse(v[258].ToString()); l.rvolmomentumY8 = (float)Double.Parse(v[259].ToString()); l.rvolmomentumY16 = (float)Double.Parse(v[260].ToString()); l.rvolmomentumY32 = (float)Double.Parse(v[261].ToString()); l.rvolmomentumY64 = (float)Double.Parse(v[262].ToString()); l.rvolmomentumY128 = (float)Double.Parse(v[263].ToString()); l.rvolmomentumY256 = (float)Double.Parse(v[264].ToString()); l.rvolmomentumY512 = (float)Double.Parse(v[265].ToString());
                l.rvolatilityY1 = (float)Double.Parse(v[266].ToString()); l.rvolatilityY2 = (float)Double.Parse(v[267].ToString()); l.rvolatilityY4 = (float)Double.Parse(v[268].ToString()); l.rvolatilityY8 = (float)Double.Parse(v[269].ToString()); l.rvolatilityY16 = (float)Double.Parse(v[270].ToString()); l.rvolatilityY32 = (float)Double.Parse(v[271].ToString()); l.rvolatilityY64 = (float)Double.Parse(v[272].ToString()); l.rvolatilityY128 = (float)Double.Parse(v[273].ToString()); l.rvolatilityY256 = (float)Double.Parse(v[274].ToString()); l.rvolatilityY512 = (float)Double.Parse(v[275].ToString());
                l.dMomentum1 = (float)Double.Parse(v[276].ToString()); l.dMomentum2 = (float)Double.Parse(v[277].ToString()); l.dMomentum4 = (float)Double.Parse(v[278].ToString()); l.dMomentum8 = (float)Double.Parse(v[279].ToString()); l.dMomentum16 = (float)Double.Parse(v[280].ToString()); l.dMomentum32 = (float)Double.Parse(v[281].ToString()); l.dMomentum64 = (float)Double.Parse(v[282].ToString()); l.dMomentum128 = (float)Double.Parse(v[283].ToString()); l.dMomentum256 = (float)Double.Parse(v[284].ToString()); l.dMomentum512 = (float)Double.Parse(v[285].ToString());
                l.dVolatility1 = (float)Double.Parse(v[286].ToString()); l.dVolatility2 = (float)Double.Parse(v[287].ToString()); l.dVolatility4 = (float)Double.Parse(v[288].ToString()); l.dVolatility8 = (float)Double.Parse(v[289].ToString()); l.dVolatility16 = (float)Double.Parse(v[290].ToString()); l.dVolatility32 = (float)Double.Parse(v[291].ToString()); l.dVolatility64 = (float)Double.Parse(v[292].ToString()); l.dVolatility128 = (float)Double.Parse(v[293].ToString()); l.dVolatility256 = (float)Double.Parse(v[294].ToString()); l.dVolatility512 = (float)Double.Parse(v[295].ToString());
                l.dVolMomentum1 = (float)Double.Parse(v[296].ToString()); l.dVolMomentum2 = (float)Double.Parse(v[297].ToString()); l.dVolMomentum4 = (float)Double.Parse(v[298].ToString()); l.dVolMomentum8 = (float)Double.Parse(v[299].ToString()); l.dVolMomentum16 = (float)Double.Parse(v[300].ToString()); l.dVolMomentum32 = (float)Double.Parse(v[301].ToString()); l.dVolMomentum64 = (float)Double.Parse(v[302].ToString()); l.dVolMomentum128 = (float)Double.Parse(v[303].ToString()); l.dVolMomentum256 = (float)Double.Parse(v[304].ToString()); l.dVolMomentum512 = (float)Double.Parse(v[305].ToString());
                l.Sample = (float)Double.Parse(v[306].ToString());

                yield return l;

            }
        }
        public void findTick(Learn2 tick)
        {
            MLContext mlcontext = new MLContext();
            ITransformer trainedmodel;
            using (var stream = File.OpenRead($"C:/TickerRegression/Regress.zip"))
            {
                trainedmodel = mlcontext.Model.Load(stream, out var modelInputSchema);
            }
            var predictionengine = mlcontext.Model.CreatePredictionEngine<Learn2, VectorPrediction>(trainedmodel);
            Console.WriteLine("Testing Model");
            //var prediction = predictionengine.Predict()
        }

        public static void helpPrint()
        {
            //i used this program to help me write some code.
            int i = 0;
            using (CloudTextWriter tw = new CloudTextWriter(".common/helpwriter.txt"))
            {
                Vector.helpWriter(tw, i, "volatility");
                i += 10;
                Vector.helpWriter(tw, i, "momentum");
                i += 10;
                Vector.helpWriter(tw, i, "volmomentum");
                i += 10;
                Vector.helpWriter(tw, i, "revenuemomentum");
                i += 10;
                Vector.helpWriter(tw, i, "earningsmomentum");
                i += 10;
                Vector.helpWriter(tw, i, "equitymomentum");
                i += 10;
                Vector.helpWriter(tw, i, "treasurymomentum");
                i += 10;
                Vector.helpWriter(tw, i, "earningspertreasurymomentum");
                i += 10;
                Vector.helpWriter(tw, i, "volatilityI");
                i += 10;
                Vector.helpWriter(tw, i, " momentumI");
                i += 10;
                Vector.helpWriter(tw, i, "volmomentumI");
                i += 10;
                Vector.helpWriter(tw, i, "volatilityS");
                i += 10;
                Vector.helpWriter(tw, i, "momentumS");
                i += 10;
                Vector.helpWriter(tw, i, "volmomentumS");
                i += 10;
                Vector.helpWriter(tw, i, "momentumY");
                i += 10;
                Vector.helpWriter(tw, i, "volmomentumY");
                i += 10;
                Vector.helpWriter(tw, i, "volatilityY");
                i += 10;
                Vector.helpWriter(tw, i, "rvolatilityI");
                i += 10;
                Vector.helpWriter(tw, i, "rmomentumI");
                i += 10;
                Vector.helpWriter(tw, i, "rvolmomentumI");
                i += 10;
                Vector.helpWriter(tw, i, "rvolatilityS");
                i += 10;
                Vector.helpWriter(tw, i, "rmomentumS");
                i += 10;
                Vector.helpWriter(tw, i, "rvolmomentumS");
                i += 10;
                Vector.helpWriter(tw, i, "rmomentumY");
                i += 10;

                Vector.helpWriter(tw, i, "rvolmomentumY");
                i += 10;
                Vector.helpWriter(tw, i, "rvolatilityY");
                i += 10;
                Vector.helpWriter(tw, i, "dMomentum");
                i += 10;
                Vector.helpWriter(tw, i, "dVolatility");
                i += 10;
                Vector.helpWriter(tw, i, "dVolMomentum");
                i += 10;

            }
        }
    }
}
