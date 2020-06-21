using System.Collections.Generic;

namespace FYP1.Models
{
    public class DataSets
    {
        public static List<string> Fav_Hobby()
        {
            return new List<string>()
            {
                "Content Writing",
                "Englisn Debates",
                "Gaming",
                "Guitarist",
                "Listening songs",
                "Networking",
                "Programming",
                "Reading books",
                "Shooting",
                "Travelling"
            };
        }
        public static List<string> Fav_Subject()
        {
            return new List<string>()
            {
                "Applied Engineering",
                "Computer Science",
                "Data science",
                "Graphic designing",
                "Health Educator",
                "Humanities",
                "Media science",
                "Phsycology",
                "Social media manager",
                "Statistic",
                "Teaching",
                "Technical writing"
            };
        }
        public static List<string> Fav_Sports()
        {
          return  new List<string>()
            {
                "Basketball",
                "Boxing",
                "Cricket",
                "Drawing",
                "Football",
                "Golf",
                "Ice hockey",
                "Spoon race",
                "Tennis"
            };
        }
    }
}


