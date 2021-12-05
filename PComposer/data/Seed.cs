using Data.Entities;
using Data.Enums;

namespace Data
{
    static public class Seed
    {
        public static readonly Component[] Data = new Component[] {
                new Processor {Price = 1599, Manufacturer = Manufacturer.AMD,   NumOfCores = 10},
                new Processor {Price = 1999, Manufacturer = Manufacturer.Intel, NumOfCores = 8},
                new Processor {Price = 1899, Manufacturer = Manufacturer.AMD,   NumOfCores = 8},
                new Processor {Price = 899,  Manufacturer = Manufacturer.Intel, NumOfCores = 4},

                new Memory {Price = 140, Manufacturer = Manufacturer.Samsung, SizeInGB = 4},
                new Memory {Price = 299, Manufacturer = Manufacturer.Crucial, SizeInGB = 8},

                new HardDrive {Price = 499, Manufacturer = Manufacturer.WD,      Type = HardDriveType.HDD, SizeInTB = 2, WeightInKg = 2},
                new HardDrive {Price = 349, Manufacturer = Manufacturer.Seagate, Type = HardDriveType.HDD, SizeInTB = 1, WeightInKg = 1},
                new HardDrive {Price = 899, Manufacturer = Manufacturer.WD,      Type = HardDriveType.SSD, SizeInTB = 2, WeightInKg = 0},
                new HardDrive {Price = 700, Manufacturer = Manufacturer.Samsung, Type = HardDriveType.SSD, SizeInTB = 1, WeightInKg = 0},

                new Case {Price = 999,  Manufacturer = Manufacturer.NZXT,    Material = CaseMaterial.Metal,   WeightInKg = 1.5M},
                new Case {Price = 399,  Manufacturer = Manufacturer.Corsair, Material = CaseMaterial.Plastic, WeightInKg = 1},
                new Case {Price = 1499, Manufacturer = Manufacturer.Corsair, Material = CaseMaterial.Carbon,  WeightInKg = 0.5M},
        };
    }
}
