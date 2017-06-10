using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_World_Simulation {
	class World {
		// The world will contain everything.
		public List<Sector> sectors;
		public List<Conflict> conflicts;

		public static void Move(Sector curentSector, Unit unit, Sector sector) {
			// Check if the sectors are connected.
			if (curentSector.connections.Contains(sector) == false) {
				// We cant move there!

				// TODO: Add debug error reporting (When we implement visuals).
				return;
			} 
			sector.units.Add(unit);				// Add it to the new Sector.
			curentSector.units.Remove(unit);	// Remove it from the old sector.
		}

		public World() {
			sectors = new List<Sector>();
			conflicts = new List<Conflict>();
		}

		public void Generate() {
			//TODO: Generate sectors and connect them.
		}
	}
}
