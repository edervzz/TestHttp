using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHttp;

public class AccountCreate
{
    public string product { get; set; } = default!;
    public string currencyCode { get; set; } = default!;
    public string startDate { get; set; } = default!;
    public int holder { get; set; } = default!;
    public int orgUnit { get; set; } = default!;

}
