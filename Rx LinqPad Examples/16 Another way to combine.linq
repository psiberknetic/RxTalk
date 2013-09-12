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

var observables = new []
{
	Observable.Interval(TimeSpan.FromSeconds(1)).Take(4),
	Observable.Interval(TimeSpan.FromSeconds(0.8)).Select(x=>x + 100).Take(4),
	Observable.Interval(TimeSpan.FromSeconds(0.2)).Select(x=>x + 200).Take(8),
	Observable.Interval(TimeSpan.FromSeconds(0.4)).Select(x=>x + 300).Take(12)
};


var merged = observables.Merge();

merged.Dump();