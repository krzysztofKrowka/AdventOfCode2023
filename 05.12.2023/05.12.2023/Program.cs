using Microsoft.VisualBasic;
using System.IO;
using System.Numerics;

namespace _05._12._2023
{
    public class AdventObject
    {
        public BigInteger destination,source,range;
        public AdventObject(BigInteger destination, BigInteger source, BigInteger range) {
            this.destination = destination;
            this.source = source;
            this.range = range;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<AdventObject> seedToSoil = new List<AdventObject>();
            List<AdventObject> soilToFertilizer = new List<AdventObject>();
            List<AdventObject> fertilizerToWater = new List<AdventObject>();
            List<AdventObject> waterToLight = new List<AdventObject>();
            List<AdventObject> lightToTemperature = new List<AdventObject>();
            List<AdventObject> temperatureToHumidity = new List<AdventObject>();
            List<AdventObject> humidityToLocation = new List<AdventObject>();
            List<BigInteger> locations = new List<BigInteger>();
            Console.WriteLine("Input seeds");
            string input = Console.ReadLine();
            List<BigInteger> seeds = new List<BigInteger>();
            BigInteger smallLocation = 99999999999999999;
            foreach (string seed in input.Split(" "))
            {
                if (seed.Contains(':')) 
                    continue;
                seeds.Add(BigInteger.Parse(seed));
            }
            Console.ReadLine();
            Console.WriteLine("input seed to soil");
            while ((input = Console.ReadLine()) != "")
            {
                var numbers = input.Split(" ");
                if (input.Contains(':'))
                    continue;
                seedToSoil.Add(new AdventObject(BigInteger.Parse(numbers[0]), BigInteger.Parse(numbers[1]), BigInteger.Parse(numbers[2])));
            }
            Console.WriteLine("input soil to fertilizer");
            while ((input = Console.ReadLine()) != "")
            {
                if (input.Contains(':'))
                    continue;
                var numbers = input.Split(" ");
                soilToFertilizer.Add(new AdventObject(BigInteger.Parse(numbers[0]), BigInteger.Parse(numbers[1]), BigInteger.Parse(numbers[2])));
            }
            Console.WriteLine("input fertilizer to ...");
            while ((input = Console.ReadLine()) != "")
            {
                if (input.Contains(':'))
                    continue;
                var numbers = input.Split(" ");
                fertilizerToWater.Add(new AdventObject(BigInteger.Parse(numbers[0]), BigInteger.Parse(numbers[1]), BigInteger.Parse(numbers[2])));
            }
            Console.WriteLine("input water to ...");
            while ((input = Console.ReadLine()) != "")
            {
                if (input.Contains(':'))
                    continue;
                var numbers = input.Split(" ");
                waterToLight.Add(new AdventObject(BigInteger.Parse(numbers[0]), BigInteger.Parse(numbers[1]), BigInteger.Parse(numbers[2])));
            }
            Console.WriteLine("input light to ...");
            while ((input = Console.ReadLine()) != "")
            {
                if (input.Contains(':'))
                    continue;
                var numbers = input.Split(" ");
                lightToTemperature.Add(new AdventObject(BigInteger.Parse(numbers[0]), BigInteger.Parse(numbers[1]), BigInteger.Parse(numbers[2])));
            }
            Console.WriteLine("input temperature to ...");
            while ((input = Console.ReadLine()) != "")
            {
                if (input.Contains(':'))
                    continue;
                var numbers = input.Split(" ");
                temperatureToHumidity.Add(new AdventObject(BigInteger.Parse(numbers[0]), BigInteger.Parse(numbers[1]), BigInteger.Parse(numbers[2])));
            }
            Console.WriteLine("input humidity to ...");
            while ((input = Console.ReadLine()) != "")
            {
                if (input.Contains(':'))
                    continue;
                var numbers = input.Split(" ");
                humidityToLocation.Add(new AdventObject(BigInteger.Parse(numbers[0]), BigInteger.Parse(numbers[1]), BigInteger.Parse(numbers[2])));
            }


            BigInteger all = seeds[1] + seeds[3] + seeds[5] + seeds[7] + seeds[9] + seeds[11] + seeds[13] + seeds[15] + seeds[17] + seeds[19];
            //Console.WriteLine(all);
            BigInteger lowLocation = 9999999999999999999,source=9;
           /* foreach(var location in humidityToLocation)
            {
                if (location.destination < lowLocation)
                {
                    lowLocation = location.destination;
                    source = location.source;
                }
            }
            foreach (AdventObject tth in temperatureToHumidity)
            {
                if (source >= tth.destination && source <= tth.destination + tth.range)
                {
                    Console.WriteLine("hi");
                    Console.WriteLine(tth.source+" dest-> "+tth.destination);
                    break;
                }
                else
                {
                    Console.WriteLine("hello");
                }
            }
*/
            Console.WriteLine("location-> "+lowLocation+" source->"+source);
            for (int i = 0; i < seeds.Count; i += 2)
            {
                for (BigInteger j = seeds[i]; j < seeds[i] + seeds[i + 1]; j++)
                {
                    BigInteger seed = j;

                    BigInteger soil = 0, fertilizer = 0, water = 0, light = 0, temperature = 0, humidity = 0, location = 0;
                    foreach (AdventObject fuck in seedToSoil)
                    {
                        if (seed >= fuck.source && seed <= fuck.source + fuck.range)
                        {
                            soil = fuck.destination + seed - fuck.source;
                            break;
                        }
                        else
                        {
                            soil = seed;
                        }
                    }

                    foreach (AdventObject fuck in soilToFertilizer)
                    {
                        if (soil >= fuck.source && soil <= fuck.source + fuck.range)
                        {
                            fertilizer = fuck.destination + soil - fuck.source;
                            break;
                        }
                        else
                        {
                            fertilizer = soil;
                        }
                    }

                    foreach (AdventObject fuck in fertilizerToWater)
                    {
                        if (fertilizer >= fuck.source && fertilizer <= fuck.source + fuck.range)
                        {
                            water = fuck.destination + fertilizer - fuck.source;
                            break;
                        }
                        else
                        {
                            water = fertilizer;
                        }
                    }

                    foreach (AdventObject fuck in waterToLight)
                    {
                        if (water >= fuck.source && water <= fuck.source + fuck.range)
                        {
                            light = fuck.destination + water - fuck.source;
                            break;
                        }
                        else
                        {
                            light = water;
                        }
                    }

                    foreach (AdventObject fuck in lightToTemperature)
                    {
                        if (light >= fuck.source && light <= fuck.source + fuck.range)
                        {
                            temperature = fuck.destination + light - fuck.source;
                            break;
                        }
                        else
                        {
                            temperature = light;
                        }
                    }

                    foreach (AdventObject fuck in temperatureToHumidity)
                    {
                        if (temperature >= fuck.source && temperature <= fuck.source + fuck.range)
                        {
                            humidity = fuck.destination + temperature - fuck.source;
                            break;
                        }
                        else
                        {
                            humidity = temperature;
                        }
                    }

                    foreach (AdventObject fuck in humidityToLocation)
                    {
                        if (humidity >= fuck.source && humidity <= fuck.source + fuck.range)
                        {
                            location = fuck.destination + humidity - fuck.source;
                            break;
                        }
                        else
                        {
                            location = humidity;
                        }
                    }

                    if (location < smallLocation)
                        smallLocation = location;
                }
                Console.WriteLine(i);
            }

            /*foreach (BigInteger seed in seeds)
            {
                BigInteger soil = 0, fertilizer = 0, water = 0, light = 0, temperature = 0, humidity = 0, location = 0;
                foreach (AdventObject fuck in seedToSoil)
                {
                    if (seed >= fuck.source && seed <= fuck.source + fuck.range)
                    {
                        soil = fuck.destination + seed - fuck.source;
                        break;
                    }
                    else
                    {
                        soil = seed;
                    }
                }

                foreach (AdventObject fuck in soilToFertilizer)
                {
                    if (soil >= fuck.source && soil <= fuck.source + fuck.range)
                    {
                        fertilizer = fuck.destination + soil - fuck.source;
                        break;
                    }
                    else
                    {
                        fertilizer = soil;
                    }
                }

                foreach (AdventObject fuck in fertilizerToWater)
                {
                    if (fertilizer >= fuck.source && fertilizer <= fuck.source + fuck.range)
                    {
                        water = fuck.destination + fertilizer - fuck.source;
                        break;
                    }
                    else
                    {
                        water = fertilizer;
                    }
                }

                foreach (AdventObject fuck in waterToLight)
                {
                    if (water >= fuck.source && water <= fuck.source + fuck.range)
                    {
                        light = fuck.destination + water - fuck.source;
                        break;
                    }
                    else
                    {
                        light = water;
                    }
                }

                foreach (AdventObject fuck in lightToTemperature)
                {
                    if (light >= fuck.source && light <= fuck.source + fuck.range)
                    {
                        temperature = fuck.destination + light - fuck.source;
                        break;
                    }
                    else
                    {
                        temperature = light;
                    }
                }

                foreach (AdventObject fuck in temperatureToHumidity)
                {
                    if (temperature >= fuck.source && temperature <= fuck.source + fuck.range)
                    {
                        humidity = fuck.destination + temperature - fuck.source;
                        break;
                    }
                    else
                    {
                        humidity = temperature;
                    }
                }

                foreach (AdventObject fuck in humidityToLocation)
                {
                    if (humidity >= fuck.source && humidity <= fuck.source + fuck.range)
                    {
                        location = fuck.destination + humidity - fuck.source;
                        break;
                    }
                    else
                    {
                        location = humidity;
                    }
                }

                Console.WriteLine("Seed: " + seed);
                Console.WriteLine("Location: " + location);
                if(smallLocation>location)
                    smallLocation=location;
            }
*/
            Console.WriteLine(smallLocation);
            File.WriteAllText(@"C:\Users\krzys\OneDrive\Pulpit\Technikum\4 Technikum\Advent of code\05.12.2023\file.txt", smallLocation.ToString());

        }
    }
}