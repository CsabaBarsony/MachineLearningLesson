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
            StreamReader trainPersonsReader = new StreamReader("train.data");
            StreamReader devPersonsReader = new StreamReader("dev.data");
            String[] trainPersonsData = trainPersonsReader.ReadToEnd().Split('\n');
            String[] devPersonsData = devPersonsReader.ReadToEnd().Split('\n');
            List<Person> trainPersons = new List<Person>();
            List<Person> devPersons = new List<Person>();
            double hits = 0;

            foreach (String line in trainPersonsData)
            {
                if(line != "") trainPersons.Add(new Person(line));
            }

            foreach (String line in devPersonsData)
            {
                if (line != "") devPersons.Add(new Person(line));
            }

            double personsNumber = trainPersons.Count;
            double incomeOver    = 0;
            double incomeUnder   = 0;

            double[] ageOverValues         = new double[Person.levelCount()];
            double[] ageUnderValues        = new double[Person.levelCount()];
            double[] employerOverValues    = new double[Person.employerCount()]; 
            double[] employerUnderValues   = new double[Person.employerCount()]; 
            double[] fnlwgtOverValues      = new double[Person.levelCount()];
            double[] fnlwgtUnderValues     = new double[Person.levelCount()];
            double[] schoolOverValues      = new double[Person.schoolCount()];
            double[] schoolUnderValues     = new double[Person.schoolCount()];
            double[] schoolCodeOverValues  = new double[Person.levelCount()];
            double[] schoolCodeUnderValues = new double[Person.levelCount()];
            double[] maritalOverValues     = new double[Person.maritalCount()];
            double[] maritalUnderValues    = new double[Person.maritalCount()];
            double[] industryOverValues    = new double[Person.industryCount()];
            double[] industryUnderValues   = new double[Person.industryCount()];
            double[] relationOverValues    = new double[Person.relationCount()];
            double[] relationUnderValues   = new double[Person.relationCount()];
            double[] raceOverValues        = new double[Person.raceCount()];
            double[] raceUnderValues       = new double[Person.raceCount()];
            double[] genderOverValues      = new double[Person.genderCount()];
            double[] genderUnderValues     = new double[Person.genderCount()];
            double[] wealthOverValues      = new double[Person.levelCount()];
            double[] wealthUnderValues     = new double[Person.levelCount()];
            double[] debtOverValues        = new double[Person.levelCount()];
            double[] debtUnderValues       = new double[Person.levelCount()];
            double[] manHourOverValues     = new double[Person.levelCount()];
            double[] manHourUnderValues    = new double[Person.levelCount()];
            double[] countryOverValues     = new double[Person.countryCount()];
            double[] countryUnderValues    = new double[Person.countryCount()];

            foreach (Person p in trainPersons)
            {
                if (p.incomeOver50k)
                {
                    incomeOver++;

                    ageOverValues        [(int)p.age]++;
                    employerOverValues   [(int)p.employer]++;
                    fnlwgtOverValues     [(int)p.fnlwgt]++;
                    schoolOverValues     [(int)p.school]++;
                    schoolCodeOverValues [(int)p.schoolCode]++;
                    maritalOverValues    [(int)p.marital]++;
                    industryOverValues   [(int)p.industry]++;
                    relationOverValues   [(int)p.relation]++;
                    raceOverValues       [(int)p.race]++;
                    genderOverValues     [(int)p.gender]++;
                    wealthOverValues     [(int)p.wealth]++;
                    debtOverValues       [(int)p.debt]++;
                    manHourOverValues    [(int)p.manHour]++;
                    countryOverValues    [(int)p.country]++;
                }
                else
                {
                    incomeUnder++;

                    ageUnderValues        [(int)p.age]++;
                    employerUnderValues   [(int)p.employer]++;
                    fnlwgtUnderValues     [(int)p.fnlwgt]++;
                    schoolUnderValues     [(int)p.school]++;
                    schoolCodeUnderValues [(int)p.schoolCode]++;
                    maritalUnderValues    [(int)p.marital]++;
                    industryUnderValues   [(int)p.industry]++;
                    relationUnderValues   [(int)p.relation]++;
                    raceUnderValues       [(int)p.race]++;
                    genderUnderValues     [(int)p.gender]++;
                    wealthUnderValues     [(int)p.wealth]++;
                    debtUnderValues       [(int)p.debt]++;
                    manHourUnderValues    [(int)p.manHour]++;
                    countryUnderValues    [(int)p.country]++;
                }
            }

            foreach (Person person in devPersons)
            {
                double over = incomeOver / personsNumber;
                double under = incomeUnder / personsNumber;

                double ageOver = ageOverValues[(int)person.age] / incomeOver;
                double ageUnder = ageUnderValues[(int)person.age] / incomeUnder;
                double employerOver = employerOverValues[(int)person.employer] / incomeOver;
                double employerUnder = employerUnderValues[(int)person.employer] / incomeUnder;
                double fnlwgtOver = fnlwgtOverValues[(int)person.fnlwgt] / incomeOver;
                double fnlwgtUnder = fnlwgtUnderValues[(int)person.fnlwgt] / incomeUnder;
                double schoolOver = schoolOverValues[(int)person.school] / incomeOver;
                double schoolUnder = schoolUnderValues[(int)person.school] / incomeUnder;
                double schoolCodeOver = schoolCodeOverValues[(int)person.schoolCode] / incomeOver;
                double schoolCodeUnder = schoolCodeUnderValues[(int)person.schoolCode] / incomeUnder;
                double maritalOver = maritalOverValues[(int)person.marital] / incomeOver;
                double maritalUnder = maritalUnderValues[(int)person.marital] / incomeUnder;
                double industryOver = industryOverValues[(int)person.industry] / incomeOver;
                double industryUnder = industryUnderValues[(int)person.industry] / incomeUnder;
                double relationOver = relationOverValues[(int)person.relation] / incomeOver;
                double relationUnder = relationUnderValues[(int)person.relation] / incomeUnder;
                double raceOver = raceOverValues[(int)person.race] / incomeOver;
                double raceUnder = raceUnderValues[(int)person.race] / incomeUnder;
                double genderOver = genderOverValues[(int)person.gender] / incomeOver;
                double genderUnder = genderUnderValues[(int)person.gender] / incomeUnder;
                double wealthOver = wealthOverValues[(int)person.wealth] / incomeOver;
                double wealthUnder = wealthUnderValues[(int)person.wealth] / incomeUnder;
                double debtOver = debtOverValues[(int)person.debt] / incomeOver;
                double debtUnder = debtUnderValues[(int)person.debt] / incomeUnder;
                double manHourOver = manHourOverValues[(int)person.manHour] / incomeOver;
                double manHourUnder = manHourUnderValues[(int)person.manHour] / incomeUnder;
                double countryOver = countryOverValues[(int)person.country] / incomeOver;
                double countryUnder = countryUnderValues[(int)person.country] / incomeUnder;

                double overResult = over *
                                    ageOver *
                                    employerOver *
                                    fnlwgtOver *
                                    schoolOver *
                                    schoolCodeOver *
                                    maritalOver *
                                    industryOver *
                                    relationOver *
                                    raceOver *
                                    genderOver *
                                    wealthOver *
                                    debtOver *
                                    manHourOver *
                                    countryOver;

                double underResult = under *
                                     ageUnder *
                                     employerUnder *
                                     fnlwgtUnder *
                                     schoolUnder *
                                     schoolCodeUnder *
                                     maritalUnder *
                                     industryUnder *
                                     relationUnder *
                                     raceUnder *
                                     genderUnder *
                                     wealthUnder *
                                     debtUnder *
                                     manHourUnder *
                                     countryUnder;

                bool incomeOver50K;

                if (overResult > underResult) incomeOver50K = true;
                else incomeOver50K = false;

                if (incomeOver50K == person.incomeOver50k) hits++;
            }

            Console.WriteLine(hits / (double)devPersons.Count);
            Console.ReadKey();
        }

        public int enumLength(Enum e)
        {
            return Enum.GetNames(typeof(Marital)).Length;
        }
    }
}
