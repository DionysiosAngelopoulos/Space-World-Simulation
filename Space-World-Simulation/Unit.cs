using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questia {
    class Unit {
        Sector sector;
        public Faction faction;
        public string name;
        public int hull = 5;
        public int hullSpace = 2;
        public int dpt      = 1; // Damage per tick.
        public Unit(string name, Sector sector, Faction faction) {
            this.name = name;
            this.sector = sector;
            this.faction = faction;
        }
    }
}
