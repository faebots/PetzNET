# PetzNET

An open-source .NET library for reading and writing files for the P.F. Magic Petz games. A work in progress.

**Currently supports:**
- .dog, .cat breed files
- auto-detects game version (Petz 3, Petz 4, Petz 5, Unibreed)
- parse/read LNZ
- parse/read RCData (breed name, hex ID, etc)
- read SCP into raw binary dump

**Planned features**
- write to files
- Petz II support
- dump/add/remove embedded BMP, WAV files
- .pet, .toy, .clo, .env files
- SCP parser
- convert to different game versions
- improve the LNZ file API to be more user-friendly

**Not planned**
- front end interface or GUI - I may implement a CLI down the road though
- Babyz or Oddballz support