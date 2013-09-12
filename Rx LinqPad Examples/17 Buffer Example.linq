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

var obs = Observable.Create<long>(o=>
	{
		var rand = new Random();
		long i = 0;
		while(true)
		{
			Thread.Sleep(rand.Next(50, 2000));
			o.OnNext(i++);
		}
		return Disposable.Empty;
	}
);

//var buffered = obs.Take(50).Buffer(3);
var buffered = obs.Take(50).Buffer(TimeSpan.FromSeconds(3));

buffered.Subscribe(x=>x.Dump());