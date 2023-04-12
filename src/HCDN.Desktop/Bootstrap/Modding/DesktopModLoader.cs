﻿using System.Collections.Generic;
using HCDN.API;
using HCDN.API.Modding;

namespace HCDN.Desktop.Bootstrap.Modding; 

public class DesktopModLoader : IModLoader {
    public IDictionary<string, IMod> Mods { get; } = new Dictionary<string, IMod>();
}
