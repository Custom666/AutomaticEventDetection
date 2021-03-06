﻿using System;
using System.Collections.Generic;
using System.Linq;
using AEDCore.Interfaces;
using AEDCore.Models;

namespace AEDCore.SymptomAlgorithms
{
    public class BagOfWords : ISymptomAlgorithm
    {
        private static readonly char[] WORD_SPLIT_PATTERN = 
            {' ', ',', '.', '!', '?', ':', ';', '(', ')', '/', '\\', '-', '"', '–', '‘', '|', '“'};

        public void GenerateSymptoms(IList<EventModel> models)
        {
            // initialize dictionary
            var dictionary = getDictionary(models.Select(m => m.Message).ToArray());

            // for each EventModel generate symptom
            foreach (var eventModel in models)
            {
                // initialize vector
                var symptom = new SymptomModel(dictionary.Count);

                // get all words in event message
                var words = eventModel.Message.Split(WORD_SPLIT_PATTERN, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    // find word index in dictionary
                    var index = dictionary.IndexOf(word.ToLower());

                    // increase word count in symptom
                    symptom.Symptom[index]++;
                }

                eventModel.SymptomModel = symptom;
            }
        }

        private IList<string> getDictionary(IEnumerable<string> messages)
        {
            var dictionary = new List<string>();

            foreach (var message in messages)
            {
                var words = message.Split(WORD_SPLIT_PATTERN, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words) if(!dictionary.Contains(word.ToLower())) dictionary.Add(word.ToLower());
            }

            //dictionary.Sort();

            return dictionary;
        }
    }
}
