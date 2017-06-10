using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_World_Simulation {
	class Station {
		public List<Unit> units;	// The units stationed here.
		public Faction owner;		// The faction that owns this station.

		public bool Dock(Unit unit) {
			// Request to dock to station.
			if (owner.enemies.Contains(unit.faction)) {
				// Is the ship of an enemy faction?
				// If so deny him entry.
				return false;
			}
			// Else allow him entry.
			units.Add(unit);
			unit.station = this;
			return true;
		}

		public void UnDock(Unit unit) {
			// A unit has requested to undock.
			// Simply allow him.
			units.Remove(unit);
			unit.station = null;
		}
	}
}
