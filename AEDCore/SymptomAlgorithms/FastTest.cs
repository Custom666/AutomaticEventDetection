using AEDCore.Interfaces;
using AEDCore.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AEDCore.SymptomAlgorithms
{
    public class FastTest : ISymptomAlgorithm
    {
        private string _dictionaryPath;

        private string _binaryDictionaryPath => 
            _dictionaryPath.Substring(0,  _dictionaryPath.LastIndexOf(Path.DirectorySeparatorChar) + 1) + "FastTest.bin";

        private static readonly char[] WORD_SPLIT_PATTERN =
            {' ', ',', '.', '!', '?', ':', ';', '(', ')', '/', '\\', '-', '"', '–', '‘', '|', '“'};
        
        public FastTest(string dicPath)
        {
            _dictionaryPath = dicPath;
        }

        public void GenerateSymptoms(IList<EventModel> models)
        {
            // initialize dictionary
            var dictionary = getDictionary();

            // for each EventModel generate symptom
            foreach (var eventModel in models)
            {
                // initialize vector
                var symptom = new SymptomModel(dictionary.Values.First().Length);

                // get all words in event message
                var words = eventModel.Message.Split(WORD_SPLIT_PATTERN, StringSplitOptions.RemoveEmptyEntries);
                
                foreach (var word in words)
                {
                    // find vector associated with this word in dictionary
                    if (dictionary.TryGetValue(word, out var vector))
                    {
                        // sumarize all words vector
                        for (var index = 0; index < vector.Length; index++) symptom.Symptom[index] += vector[index];

                        // make average of sum
                        for (var index = 0; index < vector.Length; index++) symptom.Symptom[index] /= words.Length;
                    }
                }

                eventModel.SymptomModel = symptom;
            }
        }

        private IDictionary<string, double[]> getDictionary()
        {
            Dictionary<string, double[]>  dictionary = null;

            if(File.Exists(_binaryDictionaryPath))
            {
                dictionary = SerializationHelper.Deserialize<Dictionary<string, double[]>>(File.Open(_binaryDictionaryPath, FileMode.Open));

                return dictionary;
            }

            dictionary = new Dictionary<string, double[]>();

            using (var stream = new StreamReader(_dictionaryPath))
            {
                var fileHeader = stream.ReadLine().Split(" ");

                var lineCount = int.Parse(fileHeader[0]);

                var vectorLength = int.Parse(fileHeader[1]);

                var actualLine = 0;

                // read line by line and parse them to dictionary as word => vector
                while (!stream.EndOfStream)
                {
                    var line = stream.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    if (line.Length - 1 != vectorLength) continue;

                    var vector = new double[line.Length - 1];

                    var stringVector = line.Skip(1).ToArray();

                    bool wrongNumberFormatInFile = false;

                    for (var index = 0; index < vectorLength; index++)
                    {
                        if (double.TryParse(stringVector[index],
                            NumberStyles.Number,
                            new NumberFormatInfo { NegativeSign = "-" },
                            out var partAsDouble)) vector[index] = partAsDouble;
                        else wrongNumberFormatInFile = true;
                    }

                    if (wrongNumberFormatInFile) continue;
                    
                    if (!dictionary.ContainsKey(line[0])) dictionary.Add(line[0], vector);

                    Console.Write($"\rCreating dictionary { ++actualLine } / { lineCount }");
                }
            }

            SerializationHelper.Serialize(dictionary, File.Open(_binaryDictionaryPath, FileMode.Create));

            return dictionary;
        }
    }
}
