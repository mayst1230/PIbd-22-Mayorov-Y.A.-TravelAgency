using TravelAgencyBusinnesLogic.HelperModels;
using System.Collections.Generic;

namespace TravelAgencyBusinnesLogic.HelperModels
{
    class WordParagraph
    {
        public List<(string, WordTextProperties)> Texts { get; set; }
        public WordTextProperties TextProperties { get; set; }
    }
}
