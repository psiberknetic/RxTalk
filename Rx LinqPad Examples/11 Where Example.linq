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

var obs = Observable.Interval(TimeSpan.FromSeconds(1));

var obs2 = obs.Where(x=>x % 2 == 0 );

obs.DumpLive("Original");
obs2.DumpLive("Filtered");