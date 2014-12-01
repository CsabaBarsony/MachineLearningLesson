using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("train.data");
            String[] dataLines= reader.ReadToEnd().Split('\n');
            List<Person> persons = new List<Person>();
            foreach (String line in dataLines)
            {
                if(line != "") persons.Add(new Person(line));
            }

            int incomeOver   = 0;
            int incomeUnder  = 0;
            int personNumber = 0;

            int ageOver,
                ageUnder,
                employerOver,
                employerUnder,
                fnlwgtOver,
                fnlwgtUnder,
                schoolOver,
                schoolUnder,
                schoolCodeOver,
                schoolCodeUnder,
                maritalOver,
                maritalUnder,
                industryOver,
                industryUnder,
                relationOver,
                relationUnder,
                raceOver,
                raceUnder,
                genderOver,
                genderUnder,
                wealthOver,
                wealthUnder,
                debtOver,
                debtUnder,
                manHourOver,
                manHourUnder,
                countryOver,
                countryUnder;

            Person person = new Person(
                Level.Low,
                Employer.State_gov,
                Level.LowMid,
                School.Bachelors,
                Level.High,
                Marital.Divorced,
                Industry.Craft_repair,
                Relation.Unmarried,
                Race.Amer_Indian_Eskimo,
                Gender.Female,
                Level.High,
                Level.Low,
                Level.Low,
                Country.United_States
            );

            foreach (Person p in persons)
            {
                if (p.incomeOver50k)
                {

                }
                else
                {

                }
            }

            Console.ReadKey();
        }
    }
}
