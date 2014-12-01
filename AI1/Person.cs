using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI1
{
    public class Person
    {
        public Level    age             { get; set; }
        public Employer employer        { get; set; }
        public Level    fnlwgt          { get; set; }
        public School   school          { get; set; }
        public Level    schoolCode      { get; set; }
        public Marital  marital         { get; set; }
        public Industry industry        { get; set; }
        public Relation relation        { get; set; }
        public Race     race            { get; set; }
        public Gender   gender          { get; set; }
        public Level    wealth          { get; set; }
        public Level    debt            { get; set; }
        public Level    manHour         { get; set; }
        public Country  country         { get; set; }
        public bool     incomeOver50k   { get; set; }

        public Person(String line)
        {
            String[] values = line.Split(',');

            this.age            = setLevel(30, 40, 50, 60,                  values[0]);
            this.employer       = (Employer)replaceHyphen(typeof(Employer), values[1]);
            this.fnlwgt         = setLevel(300000, 600000, 900000, 1200000, values[2]);
            this.school         = setSchool(                                values[3]);
            this.schoolCode     = setLevel(8, 10, 12, 14,                   values[4]);
            this.marital        = (Marital)replaceHyphen(typeof(Marital),   values[5]);
            this.industry       = (Industry)replaceHyphen(typeof(Industry), values[6]);
            this.relation       = (Relation)replaceHyphen(typeof(Relation), values[7]);
            this.race           = (Race)replaceHyphen(typeof(Race),         values[8]);
            this.gender         = (Gender)replaceHyphen(typeof(Gender),     values[9]);
            this.wealth         = setLevel(1, 2000, 5000, 8000,             values[10]);
            this.debt           = setLevel(1, 500, 1000, 2000,              values[11]);
            this.manHour        = setLevel(20, 40, 60, 80,                  values[12]);
            this.country        = setCountry(                               values[13]);
            this.incomeOver50k  = setIncomeOver(                            values[14]);
        }

        public Person(
                Level    age,
                Employer employer,
                Level    fnlwgt,
                School   school,
                Level    schoolCode,
                Marital  marital,
                Industry industry,
                Relation relation,
                Race     race,
                Gender   gender,
                Level    wealth,
                Level    debt,
                Level    manHour,
                Country  country
            )
        {
            this.age        = age;
            this.employer   = employer;
            this.fnlwgt     = fnlwgt;
            this.school     = school;
            this.schoolCode = schoolCode;
            this.marital    = marital;
            this.industry   = industry;
            this.relation   = relation;
            this.race       = race;
            this.gender     = gender;
            this.wealth     = wealth;
            this.debt       = debt;
            this.manHour    = manHour;
            this.country    = country;
        }

        private object replaceHyphen(Type type, String raw)
        {
            return Enum.Parse(type, raw.Replace('-', '_'));
        }

        private Level setLevel(int low, int lowMid, int mid, int midHigh, string valueString)
        {
            if (low >= lowMid ||
                lowMid >= mid ||
                mid >= midHigh)
            {
                Console.WriteLine("Hiba: a szintek nem növekvő sorrendben vannak megadva!");
                return Level.Low;
            }

            Level level = Level.Low;

            int value = Int32.Parse(valueString);

            if (value < low)                        level = Level.Low;
            if (value >= low && value < lowMid)     level = Level.LowMid;
            if (value >= lowMid && value < mid)     level = Level.Mid;
            if (value >= mid && value < midHigh)    level = Level.HighMid;
            if (value >= midHigh)                   level = Level.High;

            return level;
        }

        private School setSchool(string value)
        {
            School school;

            if      (value == "11th")       school = School._11th;
            else if (value == "9th")        school = School._9th;
            else if (value == "7th-8th")    school = School._7th_8th;
            else if (value == "12th")       school = School._12th;
            else if (value == "1st-4th")    school = School._1st_4th;
            else if (value == "10th")       school = School._10th;
            else if (value == "5th-6th")    school = School._5th_6th;
            else                            school = (School)replaceHyphen(typeof(School), value);

            return school;
        }

        private bool setIncomeOver(string overString)
        {
            bool incomeOver = false;

            if      (overString == "<=50K") incomeOver = false;
            else if (overString == ">50K")  incomeOver = true;
            else                            Console.WriteLine("Hiba! Nem lehet a keresetet bool értékké konvertálni: \"" + overString + "\"");

            return incomeOver;
        }

        public Country setCountry(string value)
        {
            Country country;

            if      (value == "Outlying-US(Guam-USVI-etc)") country = Country.Outlying_US;
            else if (value == "Trinadad&Tobago")            country = Country.TrinadadAndTobago;
            else                                            country = (Country)replaceHyphen(typeof(Country), value);

            return country;
        }
    }

    public enum Employer
    {
        Private,
        Self_emp_not_inc,
        Self_emp_inc,
        Federal_gov,
        Local_gov,
        State_gov,
        Without_pay,
        Never_worked
    };

    public enum Marital
    {
        Married_civ_spouse,
        Divorced,
        Never_married,
        Separated,
        Widowed,
        Married_spouse_absent,
        Married_AF_spouse
    }

    public enum Industry
    {
        Tech_support,
        Craft_repair,
        Other_service,
        Sales,
        Exec_managerial,
        Prof_specialty,
        Handlers_cleaners,
        Machine_op_inspct,
        Adm_clerical,
        Farming_fishing,
        Transport_moving,
        Priv_house_serv,
        Protective_serv,
        Armed_Forces
    }

    public enum School
    {
        Bachelors,
        Some_college,
        _11th,
        HS_grad,
        Prof_school,
        Assoc_acdm,
        Assoc_voc,
        _9th,
        _7th_8th,
        _12th,
        Masters,
        _1st_4th,
        _10th,
        Doctorate,
        _5th_6th,
        Preschool
    }

    public enum Relation
    {
        Wife,
        Own_child,
        Husband,
        Not_in_family,
        Other_relative,
        Unmarried
    }

    public enum Race
    {
        White,
        Asian_Pac_Islander,
        Amer_Indian_Eskimo,
        Other,
        Black
    }

    public enum Gender
    {
        Female,
        Male
    }

    public enum Country
    {
        United_States,
        Cambodia,
        England,
        Puerto_Rico,
        Canada,
        Germany,
        Outlying_US,
        India,
        Japan,
        Greece,
        South,
        China,
        Cuba,
        Iran,
        Honduras,
        Philippines,
        Italy,
        Poland,
        Jamaica,
        Vietnam,
        Mexico,
        Portugal,
        Ireland,
        France,
        Dominican_Republic,
        Laos,
        Ecuador,
        Taiwan,
        Haiti,
        Columbia,
        Hungary,
        Guatemala,
        Nicaragua,
        Scotland,
        Thailand,
        Yugoslavia,
        El_Salvador,
        TrinadadAndTobago,
        Peru,
        Hong,
        Holand_Netherlands
    }

    public enum Level
    {
        Low,
        LowMid,
        Mid,
        HighMid,
        High
    }
}
