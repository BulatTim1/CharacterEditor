using CharacterEditorCore;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CharacterEditorMongoHelper
{
    public static class MongoDBHelper
    {
        private static readonly MongoClient client = new MongoClient("mongodb://localhost");
        internal static readonly IMongoDatabase db = client.GetDatabase("CharacterEditor");
        internal static readonly IMongoCollection<Character> collection = db.GetCollection<Character>("NewCharacters");
        internal static readonly IMongoCollection<Match> matchCollection = db.GetCollection<Match>("Matches");
    }
}