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

		public void Generate(Sector initSector, int size) {
			Random rand = new Random();
			int x = 1;

			List<Sector> frontier = new List<Sector>();
			frontier.Add(initSector);
			Sector current;
			while(true) {
				current = frontier[0];
				int len = rand.Next(1, 9);
				current.connections = new Sector[len];
				for (int i = 0; i < len; i++) {
					current.connections[i] = new Sector("s" + x, this);
					frontier.Add(current.connections[i]);
					sectors.Add(current.connections[i]);
				}
				frontier.Remove(current);
				x++;
				if (x > size) {
					break;
				}
			}
		}
	}
}
