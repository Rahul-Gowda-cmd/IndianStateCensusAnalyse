using NUnit.Framework;
using IndianStateCensusAnalyse;
using IndianStateCensusAnalyse.POCO;
using static IndianStateCensusAnalyse.CensusAnalyser;
using System.Collections.Generic;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"C:\Users\HP\csharp\IndianStateCensusAnalyse\CensusAnalyserTest\CsvFiles\IndiaStateCensusData.csv";
        static string wrongDataFilePath = @"C:\Users\HP\csharp\IndianStateCensusAnalyse\CensusAnalyserTest\CsvFiles\IndianData.csv";
        static string IndianStateCensus = @"C:\Users\HP\csharp\IndianStateCensusAnalyse\CensusAnalyserTest\CsvFiles\IndianStateCensus.txt";
        static string wrongIndianStateCensusFileHeader = @"C:\Users\HP\csharp\IndianStateCensusAnalyse\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string IndianStateCesusFilePathWithWrongDelimeter = @"C:\Users\HP\csharp\IndianStateCensusAnalyse\CensusAnalyserTest\CsvFiles\IndianStateCesusDelimeter.csv";

        static string indianStateCodeHeaders = @"SrNo,State Name,TIN,StateCode";
        static string indianStateCodePath = @"C:\Users\HP\csharp\IndianStateCensusAnalyse\CensusAnalyserTest\CsvFiles\IndiaStateCodes.csv";
        static string WrongIndianStateCodeFilePath = @"C:\Users\HP\csharp\IndianStateCensusAnalyse\CensusAnalyserTest\CsvFiles\WrongIndiaStateCodes.csv";
        static string WrongIndianStateCodeFileTypePath = @"C:\Users\HP\csharp\IndianStateCensusAnalyse\CensusAnalyserTest\CsvFiles\WronTypeIndiaStateCodes.txt";
        static string IndianStateCodeFilePathWrongDelimeter = @"C:\Users\HP\csharp\IndianStateCensusAnalyse\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCodes.csv";
        static string IndianStateCodeFilePathWrongHeader = @"C:\Users\HP\csharp\IndianStateCensusAnalyse\CensusAnalyserTest\CsvFiles\WrongHeaderIndiaStateCodes.csv";
        IndianStateCensusAnalyse.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecords;


        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(5, totalRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongDataFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);

        }
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCensus, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileHeader, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCesusFilePathWithWrongDelimeter, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]
        public void GivenIndianStateCodeFile_WhenRead_ShouldReturnCensusDataCount()
        {
            stateRecords = censusAnalyser.LoadCensusData(indianStateCodePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecords.Count);
        }
        [Test]
        public void GivenWrongStateCodeFile_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(WrongIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(WrongIndianStateCodeFileTypePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        [Test]
        public void GivenIndianStateCodeFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCodeFilePathWrongDelimeter, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
        [Test]
        public void GivenIndianStateCodeFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCodeFilePathWrongHeader, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}