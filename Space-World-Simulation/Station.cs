using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_World_Simulation {
	class Station {
		public List<Unit> units;	// The units stationed here.
		public Faction owner;		// The faction that owns this station.
        public List<Unit> blacklist;// The blacklist ships that cant dock here.
        
        public Station(Faction owner) {
            this.owner = owner;
            units = new List<Unit>();
            blacklist = new List<Unit>();
        }

		public virtual bool Dock(Unit unit) {
            if (blacklist.Contains(unit)) {
                // if this unit is blacklisted don't allow him.
                return false;
            }
			// Request to dock to station.
			if (owner.enemies.Contains(unit.faction)) {
				// Is the ship of an enemy faction?
				// If so deny him entry.
				return false;
			}
			// Else allow him entry.
			units.Add(unit);
			unit.station = this;

            // Update all the ships people.
            foreach (Person person in unit.staff) {
                person.location = this;
            }
            foreach (Person person in unit.captains) {
                person.location = this;
            }
            return true;
		}

		public virtual void UnDock(Unit unit) {
            // A unit has requested to undock.
            // Simply allow him.
            // Request for all of the staff to come back to the ship.
            unit.RequestReturn();
			units.Remove(unit);
			unit.station = null;
		}
	}
}
