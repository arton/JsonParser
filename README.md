# JsonParser
Easy to import stringified JSON to dynamic object for .NET world.

```VBusage.vb
Import Art.On
'...
Dim json As Object = JsonParser.Parse("{""StrProp"":""ABC"", ""NumProp"":32, ""BoolProp"":true}")
System.Console.WriteLine("StrProp=" & json.StrProp & ", NumProp=" & json.NumProp & ", BoolProp=" & json.BoolProp) 
```

```CSUsage.cs
using Art.On;
using System;
// ...
var json = JsonParser.Parse(@"{""StrProp"":""ABC"", ""NumProp"":32, ""BoolProp"":true}");
Console.WriteLine($"StrProp={json.StrProp}, NumProp={json.NumProp}, BoolProp={json.BoolProp}");
json = JsonParser.Parse(@"{""obj"":{""prop1"": 32},
                           ""array"":[32,48,56]
                          }");
Console.WriteLine(json.obj.prop1); // => 32
Console.WriteLine(json.array[1]);  // => 48

```
