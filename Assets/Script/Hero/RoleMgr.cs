using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RoleMgr : Singleton<RoleMgr>
{
    public int Money { get; internal set; }
    public int Diamond { get; set; }
}
