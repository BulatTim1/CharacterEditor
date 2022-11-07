using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    public class Match
    {
        private string _id;
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {

            get => _id;
            set => _id = value;
        }

        private DateTime _date;
        public DateTime Date { get; set; }

        private List<Character> _team1;
        public List<Character> Team1 { get; set; }

        private List<Character> _team2;
        public List<Character> Team2 { get; set; }
    }
}
