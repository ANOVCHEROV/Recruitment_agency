using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace RecuirementAgency.Models.Dao_Summ
{
    public class VO_Summ
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int idOfAuthor { get; set; }
        public DateTime date { get; set; }
        public string info { get; set; }
        public List<string> professions = new List<string>();
        public List<Experience> experience = new List<Experience>();
    }
}