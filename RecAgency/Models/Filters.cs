using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace RecAgency.Models
{
    public class Filters
    {
        public IEnumerable<Vacancy> ForSalary(IEnumerable<Vacancy> input, int n)
        {
            List<Vacancy> output = new List<Vacancy>();
            foreach(var i in input)
            {
                if (i.Salary >= n)
                {
                    output.Add(i);
                }
            }
            return output;
        }
        public IEnumerable<Vacancy> ForKeyWords(IEnumerable<Vacancy> input, string words)
        {
            List<Vacancy> output = new List<Vacancy>();
            string[] w = words.Split(' ');
            List<Regex> regex = new List<Regex>();
            foreach(var i in w)
            {
                regex.Add(new Regex(i, RegexOptions.IgnoreCase));
            }
            
            foreach(var i in input)
            {
                foreach(var r in regex)
                {
                    if (r.IsMatch(i.Field) || r.IsMatch(i.Info) || r.IsMatch(i.Name) || r.IsMatch(i.Organization) || r.IsMatch(i.Schedule))
                    {
                        output.Add(i);
                        break;
                    }
                }
            }
            return output;
        }
    }
}