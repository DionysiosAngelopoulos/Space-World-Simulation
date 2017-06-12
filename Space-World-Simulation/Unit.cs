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
		public Station station;     // The station the ship is currently in. (null if not in one)

        public List<Person> captains;      // The ships captains.
        public List<Person> staff;         // The ships staff.

        public Unit(string name, Faction faction) {
            this.name    = name;
            this.faction = faction;
        }

		public virtual void Update(Sector sector) {
			// Will be overriden in subclass.
		}

        public virtual bool RequestReturn() {
            foreach (Person person in staff) {
                if (person.RequestReturnToWork(station) == true) {
                    // The person came we are good.
                } else {
                    // He didn't. Fire him.
                    // FIXME: Properly handle this.
                }
            }
            foreach (Person person in captains) {
                if (person.RequestReturnToWork(station) == true) {
                    // The person came we are good.
                } else {
                    // He didn't. This is a captain so we can't go.
                    return false;
                }
            }
            return true;
        }
    }
}
