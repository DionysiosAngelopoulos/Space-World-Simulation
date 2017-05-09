using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questia {
    class Program {
        static void Main(string[] args) {
            Sector sector = new Sector();
            Faction f1 = new Faction();
            Faction f2 = new Faction();
            f1.MakeEnemy(f2);
            f2.MakeEnemy(f1);
            sector.units.Add(new Unit("F1-1", sector, f1));
            sector.units.Add(new Unit("F1-2", sector, f1));
            sector.units.Add(new Unit("F2-1", sector, f2));
            sector.units.Add(new Unit("F2-2", sector, f2));
            sector.units.Add(new Unit("F2-3", sector, f2));
            sector.units.Add(new Unit("F2-4", sector, f2));
            sector.Update();
            Console.ReadKey();
            Console.Clear();
            f1.enemies.Remove(f2);
            f2.enemies.Remove(f1);
            sector.Update();
            Console.ReadKey();
        }
    }
}
