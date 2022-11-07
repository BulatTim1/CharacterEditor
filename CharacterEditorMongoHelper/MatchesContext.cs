using CharacterEditorCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CharacterEditorMongoHelper
{
    public class MatchesContext
    {
        public List<Match> GetAllMatches()
        {
            return MongoDBHelper.matchCollection.Find(match => true).ToList();
        }
        public Match GetMatch(string id)
        {
            return MongoDBHelper.matchCollection.Find(match => match.Id == id).FirstOrDefault();
        }
        public Match CreateMatch(Match match)
        {
            MongoDBHelper.matchCollection.InsertOne(match);
            return match;
        }
        public void UpdateMatch(string id, Match matchIn)
        {
            MongoDBHelper.matchCollection.ReplaceOne(match => match.Id == id, matchIn);
        }
        public void RemoveMatch(Match matchIn)
        {
            MongoDBHelper.matchCollection.DeleteOne(match => match.Id == matchIn.Id);
        }
        public void RemoveMatch(string id)
        {
            MongoDBHelper.matchCollection.DeleteOne(match => match.Id == id);
        }
    }
}
