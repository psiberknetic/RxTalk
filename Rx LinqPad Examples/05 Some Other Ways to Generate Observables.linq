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

var obs = Enumerable.Range(1,10).ToObservable();

var obs1 = Observable.Range(1,10);

var obs2 = Observable.Interval(TimeSpan.FromSeconds(1)).Take(10);

var obs3 = Observable.Generate( 0, val => val <= 10, val=>val = val + 1, val=>val);

var obs4 = Observable.Generate( 200, val => val <= 3000, val=>val = val + 200, val=>val);

var obs5 = Observable.Generate( 200, val => val <= 3000, val=>val = val + 200, val=>val,val=>TimeSpan.FromMilliseconds(val));

obs5.Subscribe(x=>x.Dump(), ex=>"Exception".Dump(), ()=>"Done".Dump());
