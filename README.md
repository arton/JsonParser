# JsonParser
Easy to import stringified JSON to dynamic object for .NET world.

For VB
Import Art.On
'...
Dim json As Object = JsonParser.Parse("{""StrProp"":""ABC"", ""NumProp"":32, ""BoolProp"":true}")
System.Console.WriteLine("StrProp=" & json.StrProp & ", NumProp=" & json.NumProp & ", BoolProp=" & json.BoolProp) 

For C#
using Art.On;
// ...
var json = JsonParser.Parse(@"{""StrProp"":""ABC"", ""NumProp"":32, ""BoolProp"":true}");
System.Console.WriteLine($"StrProp={json.StrProp}, NumProp={json.NumProp}, BoolProp={json.BoolProp}");
