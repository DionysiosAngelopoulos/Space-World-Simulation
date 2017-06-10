using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_World_Simulation {
	class Conflict {
		public List<Faction> factions;	// The factions involved.
		public List<Sector> sectors;	// The sectors involved.

		public Conflict(List<Faction> factions, Sector sector) {
			// Does not take a List<Sector> because when you create a conflict it will only
			// be in one sector.
			this.factions = factions;
			this.sectors = new List<Sector>();
			this.sectors.Add(sector);
		}
	}
}
