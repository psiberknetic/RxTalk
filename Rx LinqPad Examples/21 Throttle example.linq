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

var obs = Observable.Generate( 200, val => val <= 3000, val=>val = val + 200, val=>val,val=>TimeSpan.FromMilliseconds(val));

var throttled = obs.Throttle(TimeSpan.FromMilliseconds(700));

int i = 0;
throttled.Subscribe(x=>
	{
		x.Dump(string.Format("Throttle {0}", i++));
	}
);