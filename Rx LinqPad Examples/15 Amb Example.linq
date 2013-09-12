<Query Kind="Program">
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

private Random random = new Random();

void Main()
{
	var obs1 = Observable.Create<int>(o=>
			{
				NewThreadScheduler.Default.Schedule(()=>{
					Thread.Sleep(random.Next(500,2000));
					o.OnNext(1);
					o.OnNext(2);
					o.OnNext(3);
					o.OnCompleted();
					
				});
				return Disposable.Empty;
			}
		);
	
		var obs2 = Observable.Create<int>(o=>
			{
				NewThreadScheduler.Default.Schedule(()=>{
					Thread.Sleep(random.Next(500,2000));
					o.OnNext(10);
					o.OnNext(20);
					o.OnNext(30);
					o.OnCompleted();
				});
				return Disposable.Empty;
			}
		);

	var winner = Observable.Amb(obs1, obs2);
	
	winner.Dump();
}

