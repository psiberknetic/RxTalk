<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <NuGetReference>Rx-Core</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
</Query>

var obs = Observable.Never<string>();
var obs2 = obs.Timeout(TimeSpan.FromSeconds(5));
var obs3 = Observable.Generate( 200, val => val <= 3000, val=>val = val + 200, val=>val,val=>TimeSpan.FromMilliseconds(val)).Timeout(TimeSpan.FromSeconds(2));
var obs4 = obs3.Timeout(TimeSpan.FromSeconds(2));

//obs.DumpLive("Original");
//obs2.DumpLive("Timeout Version");

obs4
.Subscribe(
	x=>x.Dump(),
	ex=>string.Format("Exception: {0}", ex).Dump(),
	()=>"Observable Completed".Dump()
);