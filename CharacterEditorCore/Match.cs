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

        public DateTime Date { get; set; }

        public List<Character> Team1 { get; set; }

        public List<Character> Team2 { get; set; }

        [BsonIgnoreIfNull]
        public int Result
        {
            //-1 - error
            //0 - draw
            //1 - team1
            //2 - team2
            get;
            set;
        }
    }
}
