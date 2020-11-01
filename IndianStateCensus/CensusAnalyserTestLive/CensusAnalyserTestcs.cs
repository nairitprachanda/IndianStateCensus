using System;
using System.Collections.Generic;
using System.Text;
using IndianStateCensus.POCO;
using NUnit.Framework;
using static IndianStateCensus.CensusAnalyser;
using IndianStateCensus;

namespace CensusAnalyserTestLive
{
    class CensusAnalyserTestcs
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\nairi\Desktop\Folders\Repositories\IndianStateCensus\CensusAnalyserTestLive\Utility\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\nairi\Desktop\Folders\Repositories\IndianStateCensus\CensusAnalyserTestLive\Utility\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\nairi\Desktop\Folders\Repositories\GITHUB\IndianSTateLocal\IndianStateCensus\IndianStateCensus\CensusAnalyserTestLive\Utility\DelimiterIndiaStateCensusData.csv";
        //static string wrongIndianStateCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\nairi\Desktop\Folders\Repositories\GITHUB\IndianSTateLocal\IndianStateCensus\IndianStateCensus\CensusAnalyserTestLive\Utility\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"C:\Users\nairi\Desktop\Folders\Repositories\IndianStateCensus\CensusAnalyserTestLive\Utility\IndiaStateCode.csv";
        //static string wrongIndianStateCodeFileType = @"C:\Users\nairi\Desktop\Folders\Repositories\IndianStateCensus\CensusAnalyserTestLive\Utility\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\nairi\Desktop\Folders\Repositories\IndianStateCensus\CensusAnalyserTestLive\Utility\DelimiterIndiaStateCensusData.csv";
        //static string wrongHeaderStateCodeFilePath = @"C:\Users\nairi\Desktop\Folders\Repositories\IndianStateCensus\CensusAnalyserTestLive\Utility\WrongIndiaStateCode.csv";

        //US Census FilePath
        //static string usCensusHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        //static string usCensusFilepath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.csv";
        //static string wrongUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USData.csv";
        //static string wrongUSCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.txt";
        //static string wrongHeaderUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\WrongHeaderUSCensusData.csv";
        //static string delimeterUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\DelimiterUSCensusData.csv";

        IndianStateCensus.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensus.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongFilePathThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File not Found", e.Message);
            }
        }
        [Test]
        public void GivenWrongFileTypeThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }
        [Test]
        public void GivenWrongFileDelimiterThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        [Test]
        public void GivenWrongFileHeaderThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }


    }
}
