using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_World_Simulation {
    class Unit {
        public Faction faction;		// The factions in which the ship belongs.
        public string name;			// The ships name.
        public int hull = 5;        // The ships hull (Per side)
		public Station station;		// The station the ship is currently in. (null if not in one)
        public Unit(string name, Faction faction) {
            this.name    = name;
            this.faction = faction;
        }

		public virtual void Update(Sector sector) {
			// Will be overriden in subclass.
		}
    }
}
